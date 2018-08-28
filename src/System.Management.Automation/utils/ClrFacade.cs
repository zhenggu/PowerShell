// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management.Automation.Internal;
using System.Management.Automation.Language;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Security;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices.ComTypes;

namespace System.Management.Automation
{
    /// <summary>
    /// ClrFacade contains all diverging code (different implementation for FullCLR and CoreCLR using if/def).
    /// It exposes common APIs that can be used by the rest of the code base.
    /// </summary>
    internal static class ClrFacade
    {
        /// <summary>
        /// Initialize powershell AssemblyLoadContext and register the 'Resolving' event, if it's not done already.
        /// If powershell is hosted by a native host such as DSC, then PS ALC might be initialized via 'SetPowerShellAssemblyLoadContext' before loading S.M.A.
        /// </summary>
        static ClrFacade()
        {
            if (PowerShellAssemblyLoadContext.Instance == null)
            {
                PowerShellAssemblyLoadContext.InitializeSingleton(string.Empty);
            }
        }

        #region Assembly

        internal static IEnumerable<Assembly> GetAssemblies(TypeResolutionState typeResolutionState, TypeName typeName)
        {
            string typeNameToSearch = typeResolutionState.GetAlternateTypeName(typeName.Name) ?? typeName.Name;
            return GetAssemblies(typeNameToSearch);
        }

        /// <summary>
        /// Facade for AppDomain.GetAssemblies
        /// </summary>
        /// <param name="namespaceQualifiedTypeName">
        /// In CoreCLR context, if it's for string-to-type conversion and the namespace qualified type name is known, pass it in so that
        /// powershell can load the necessary TPA if the target type is from an unloaded TPA.
        /// </param>
        internal static IEnumerable<Assembly> GetAssemblies(string namespaceQualifiedTypeName = null)
        {
            return PSAssemblyLoadContext.GetAssembly(namespaceQualifiedTypeName) ??
                   AppDomain.CurrentDomain.GetAssemblies().Where(a =>
                       !TypeDefiner.DynamicClassAssemblyName.Equals(a.GetName().Name, StringComparison.Ordinal));
        }

        /// <summary>
        /// Get the namespace-qualified type names of all available .NET Core types shipped with PowerShell Core.
        /// This is used for type name auto-completion in PS engine.
        /// </summary>
        internal static IEnumerable<string> AvailableDotNetTypeNames => PSAssemblyLoadContext.AvailableDotNetTypeNames;

        /// <summary>
        /// Get the assembly names of all available .NET Core assemblies shipped with PowerShell Core.
        /// This is used for type name auto-completion in PS engine.
        /// </summary>
        internal static HashSet<string> AvailableDotNetAssemblyNames => PSAssemblyLoadContext.AvailableDotNetAssemblyNames;

        private static PowerShellAssemblyLoadContext PSAssemblyLoadContext => PowerShellAssemblyLoadContext.Instance;

        #endregion Assembly

        #region Encoding

        /// <summary>
        /// Facade for getting default encoding
        /// </summary>
        internal static Encoding GetDefaultEncoding()
        {
            if (s_defaultEncoding == null)
            {
                // load all available encodings
                EncodingRegisterProvider();
                s_defaultEncoding = new UTF8Encoding(false);
            }
            return s_defaultEncoding;
        }

        private static volatile Encoding s_defaultEncoding;

        /// <summary>
        /// Facade for getting OEM encoding
        /// OEM encodings work on all platforms, or rather codepage 437 is available on both Windows and Non-Windows
        /// </summary>
        internal static Encoding GetOEMEncoding()
        {
            if (s_oemEncoding == null)
            {
                // load all available encodings
                EncodingRegisterProvider();
#if UNIX
                s_oemEncoding = new UTF8Encoding(false);
#else
                uint oemCp = NativeMethods.GetOEMCP();
                s_oemEncoding = Encoding.GetEncoding((int)oemCp);
#endif
            }
            return s_oemEncoding;
        }

        private static volatile Encoding s_oemEncoding;

        private static void EncodingRegisterProvider()
        {
            if (s_defaultEncoding == null && s_oemEncoding == null)
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            }
        }

        #endregion Encoding

#if !UNIX
        #region Security

        /// <summary>
        /// Facade to get the SecurityZone information of a file.
        /// </summary>
        internal static SecurityZone GetFileSecurityZone(string filePath)
        {
            Diagnostics.Assert(Path.IsPathRooted(filePath), "Caller makes sure the path is rooted.");
            Diagnostics.Assert(File.Exists(filePath), "Caller makes sure the file exists.");
            return MapSecurityZone(filePath);
        }

        /// <summary>
        /// Map the file to SecurityZone.
        /// </summary>
        /// <remarks>
        /// The algorithm is as follows:
        ///
        /// 1. Alternate data stream "Zone.Identifier" is checked first. If this alternate data stream has content, then the content is parsed to determine the SecurityZone.
        /// 2. If the alternate data stream "Zone.Identifier" doesn't exist, or its content is not expected, then the file path will be analyzed to determine the SecurityZone.
        ///
        /// For #1, the parsing rules are observed as follows:
        ///   A. Read content of the data stream line by line. Each line is trimmed.
        ///   B. Try to match the current line with '^\[ZoneTransfer\]'.
        ///        - if matching, then do step (#C) starting from the next line
        ///        - if not matching, then continue to do step (#B) with the next line.
        ///   C. Try to match the current line with '^ZoneId\s*=\s*(.*)'
        ///        - if matching, check if the ZoneId is valid. Then return the corresponding SecurityZone if the 'ZoneId' is valid, or 'NoZone' if invalid.
        ///        - if not matching, then continue to do step (#C) with the next line.
        ///   D. Reach EOF, then return 'NoZone'.
        /// After #1, if the returned SecurityZone is 'NoZone', then proceed with #2. Otherwise, return it as the mapping result.
        ///
        /// For #2, the analysis rules are observed as follows:
        ///   A. If the path is a UNC path, then
        ///       - if the host name of the UNC path is IP address, then mapping it to "Internet" zone.
        ///       - if the host name of the UNC path has dot (.) in it, then mapping it to "internet" zone.
        ///       - otherwise, mapping it to "intranet" zone.
        ///   B. If the path is not UNC path, then get the root drive,
        ///       - if the drive is CDRom, mapping it to "Untrusted" zone
        ///       - if the drive is Network, mapping it to "Intranet" zone
        ///       - otherwise, mapping it to "MyComputer" zone.
        ///
        /// The above algorithm has two changes comparing to the behavior of "Zone.CreateFromUrl" I observed:
        ///   (1) If a file downloaded from internet (ZoneId=3) is not on the local machine, "Zone.CreateFromUrl" won't respect the MOTW.
        ///       I think it makes more sense for powershell to always check the MOTW first, even for files not on local box.
        ///   (2) When it's a UNC path and is actually a loopback (\\127.0.0.1\c$\test.txt), "Zone.CreateFromUrl" returns "Internet", but
        ///       the above algorithm changes it to be "MyComputer" because it's actually the same computer.
        /// </remarks>
        private static SecurityZone MapSecurityZone(string filePath)
        {
            SecurityZone reval = ReadFromZoneIdentifierDataStream(filePath);
            if (reval != SecurityZone.NoZone) { return reval; }
            // If it reaches here, then we either couldn't get the ZoneId information, or the ZoneId is invalid.
            // In this case, we try to determine the SecurityZone by analyzing the file path.
            Uri uri = new Uri(filePath);
            if (uri.IsUnc)
            {
                if (uri.IsLoopback)
                {
                    return SecurityZone.MyComputer;
                }

                if (uri.HostNameType == UriHostNameType.IPv4 ||
                    uri.HostNameType == UriHostNameType.IPv6)
                {
                    return SecurityZone.Internet;
                }

                // This is also an observation of Zone.CreateFromUrl/Zone.SecurityZone. If the host name
                // has 'dot' in it, the file will be treated as in Internet security zone. Otherwise, it's
                // in Intranet security zone.
                string hostName = uri.Host;
                return hostName.IndexOf('.') == -1 ? SecurityZone.Intranet : SecurityZone.Internet;
            }

            string root = Path.GetPathRoot(filePath);
            DriveInfo drive = new DriveInfo(root);
            switch (drive.DriveType)
            {
                case DriveType.NoRootDirectory:
                case DriveType.Unknown:
                case DriveType.CDRom:
                    return SecurityZone.Untrusted;
                case DriveType.Network:
                    return SecurityZone.Intranet;
                default:
                    return SecurityZone.MyComputer;
            }
        }

        /// <summary>
        /// Read the 'Zone.Identifier' alternate data stream to determin SecurityZone of the file.
        /// </summary>
        private static SecurityZone ReadFromZoneIdentifierDataStream(string filePath)
        {
            try
            {
                FileStream zoneDataSteam = AlternateDataStreamUtilities.CreateFileStream(
                                            filePath, "Zone.Identifier", FileMode.Open,
                                            FileAccess.Read, FileShare.Read);

                // If we successfully get the zone data stream, try to read the ZoneId information
                using (StreamReader zoneDataReader = new StreamReader(zoneDataSteam, GetDefaultEncoding()))
                {
                    string line = null;
                    bool zoneTransferMatched = false;

                    // After a lot experiments with Zone.CreateFromUrl/Zone.SecurityZone, the way it handles the alternate
                    // data stream 'Zone.Identifier' is observed as follows:
                    //    1. Read content of the data stream line by line. Each line is trimmed.
                    //    2. Try to match the current line with '^\[ZoneTransfer\]'.
                    //           - if matching, then do step #3 starting from the next line
                    //           - if not matching, then continue to do step #2 with the next line.
                    //    3. Try to match the current line with '^ZoneId\s*=\s*(.*)'
                    //           - if matching, check if the ZoneId is valid. Then return the corresponding SecurityZone if valid, or 'NoZone' if invalid.
                    //           - if not matching, then continue to do step #3 with the next line.
                    //    4. Reach EOF, then return 'NoZone'.
                    while ((line = zoneDataReader.ReadLine()) != null)
                    {
                        line = line.Trim();
                        if (!zoneTransferMatched)
                        {
                            zoneTransferMatched = Regex.IsMatch(line, @"^\[ZoneTransfer\]", RegexOptions.IgnoreCase);
                        }
                        else
                        {
                            Match match = Regex.Match(line, @"^ZoneId\s*=\s*(.*)", RegexOptions.IgnoreCase);
                            if (!match.Success) { continue; }

                            // Match found. Validate ZoneId value.
                            string zoneIdRawValue = match.Groups[1].Value;
                            match = Regex.Match(zoneIdRawValue, @"^[+-]?\d+", RegexOptions.IgnoreCase);
                            if (!match.Success) { return SecurityZone.NoZone; }

                            string zoneId = match.Groups[0].Value;
                            SecurityZone result;
                            return LanguagePrimitives.TryConvertTo(zoneId, out result) ? result : SecurityZone.NoZone;
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                // FileNotFoundException may be thrown by AlternateDataStreamUtilities.CreateFileStream when the data stream 'Zone.Identifier'
                // does not exist, or when the underlying file system doesn't support alternate data stream.
            }

            return SecurityZone.NoZone;
        }

        #endregion Security
#endif

        #region Misc

        /// <summary>
        /// Facade for RemotingServices.IsTransparentProxy(object)
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsTransparentProxy(object obj)
        {
#if CORECLR // Namespace System.Runtime.Remoting is not in CoreCLR
            return false;
#else
            return System.Runtime.Remoting.RemotingServices.IsTransparentProxy(obj);
#endif
        }

        /// <summary>
        /// Facade for ManagementDateTimeConverter.ToDmtfDateTime(DateTime)
        /// </summary>
        internal static string ToDmtfDateTime(DateTime date)
        {
#if CORECLR
            // This implementation is copied from ManagementDateTimeConverter.ToDmtfDateTime(DateTime date) with a minor adjustment:
            // Use TimeZoneInfo.Local instead of TimeZone.CurrentTimeZone. System.TimeZone is not in CoreCLR.
            // According to MSDN, CurrentTimeZone property corresponds to the TimeZoneInfo.Local property, and
            // it's recommended to use TimeZoneInfo.Local whenever possible.

            const int maxsizeUtcDmtf = 999;
            string UtcString = String.Empty;
            // Fill up the UTC field in the DMTF date with the current zones UTC value
            TimeZoneInfo curZone = TimeZoneInfo.Local;
            TimeSpan tickOffset = curZone.GetUtcOffset(date);
            long OffsetMins = (tickOffset.Ticks / TimeSpan.TicksPerMinute);
            IFormatProvider frmInt32 = (IFormatProvider)CultureInfo.InvariantCulture.GetFormat(typeof(Int32));

            // If the offset is more than that what can be specified in DMTF format, then
            // convert the date to UniversalTime
            if (Math.Abs(OffsetMins) > maxsizeUtcDmtf)
            {
                date = date.ToUniversalTime();
                UtcString = "+000";
            }
            else
                if ((tickOffset.Ticks >= 0))
            {
                UtcString = "+" + ((tickOffset.Ticks / TimeSpan.TicksPerMinute)).ToString(frmInt32).PadLeft(3, '0');
            }
            else
            {
                string strTemp = OffsetMins.ToString(frmInt32);
                UtcString = "-" + strTemp.Substring(1, strTemp.Length - 1).PadLeft(3, '0');
            }

            string dmtfDateTime = date.Year.ToString(frmInt32).PadLeft(4, '0');

            dmtfDateTime = (dmtfDateTime + date.Month.ToString(frmInt32).PadLeft(2, '0'));
            dmtfDateTime = (dmtfDateTime + date.Day.ToString(frmInt32).PadLeft(2, '0'));
            dmtfDateTime = (dmtfDateTime + date.Hour.ToString(frmInt32).PadLeft(2, '0'));
            dmtfDateTime = (dmtfDateTime + date.Minute.ToString(frmInt32).PadLeft(2, '0'));
            dmtfDateTime = (dmtfDateTime + date.Second.ToString(frmInt32).PadLeft(2, '0'));
            dmtfDateTime = (dmtfDateTime + ".");

            // Construct a DateTime with with the precision to Second as same as the passed DateTime and so get
            // the ticks difference so that the microseconds can be calculated
            DateTime dtTemp = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, 0);
            Int64 microsec = ((date.Ticks - dtTemp.Ticks) * 1000) / TimeSpan.TicksPerMillisecond;

            // fill the microseconds field
            String strMicrosec = microsec.ToString((IFormatProvider)CultureInfo.InvariantCulture.GetFormat(typeof(Int64)));
            if (strMicrosec.Length > 6)
            {
                strMicrosec = strMicrosec.Substring(0, 6);
            }
            dmtfDateTime = dmtfDateTime + strMicrosec.PadLeft(6, '0');
            // adding the UTC offset
            dmtfDateTime = dmtfDateTime + UtcString;

            return dmtfDateTime;
#else
            return ManagementDateTimeConverter.ToDmtfDateTime(date);
#endif
        }

        /// <summary>
        /// Facade for ProfileOptimization.SetProfileRoot
        /// </summary>
        /// <param name="directoryPath">The full path to the folder where profile files are stored for the current application domain.</param>
        internal static void SetProfileOptimizationRoot(string directoryPath)
        {
            PSAssemblyLoadContext.SetProfileOptimizationRootImpl(directoryPath);
        }

        /// <summary>
        /// Facade for ProfileOptimization.StartProfile
        /// </summary>
        /// <param name="profile">The file name of the profile to use.</param>
        internal static void StartProfileOptimization(string profile)
        {
            PSAssemblyLoadContext.StartProfileOptimizationImpl(profile);
        }

        #endregion Misc

        /// <summary>
        /// Native methods that are used by facade methods
        /// </summary>
        private static class NativeMethods
        {
            /// <summary>
            /// Pinvoke for GetOEMCP to get the OEM code page.
            /// </summary>
            [DllImport(PinvokeDllNames.GetOEMCPDllName, SetLastError = false, CharSet = CharSet.Unicode)]
            internal static extern uint GetOEMCP();
        }
    }
}
