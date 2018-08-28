// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Management.Automation.Language;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using System.Management.Automation.Internal;
using Dbg = System.Management.Automation.Diagnostics;

//
// Now define the set of commands for manipulating modules.
//

namespace Microsoft.PowerShell.Commands
{
    #region Module Specification class

    /// <summary>
    /// Represents module specification written in a module manifest (i.e. in RequiredModules member/field).
    ///
    /// Module manifest allows 2 forms of module specification:
    /// 1. string - module name
    /// 2. hashtable - [string]ModuleName (required) + [Version]ModuleVersion/RequiredVersion (required) + [Guid]GUID (optional)
    ///
    /// so we have a constructor that takes a string and a constructor that takes a hashtable
    /// (so that LanguagePrimitives.ConvertTo can cast a string or a hashtable to this type)
    /// </summary>
    public class ModuleSpecification
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ModuleSpecification()
        {
        }

        /// <summary>
        /// Construct a module specification from the module name.
        /// </summary>
        /// <param name="moduleName">The module name.</param>
        public ModuleSpecification(string moduleName)
        {
            if (string.IsNullOrEmpty(moduleName))
            {
                throw new ArgumentNullException(nameof(moduleName));
            }
            this.Name = moduleName;
            // Alias name of miniumVersion
            this.Version = null;
            this.RequiredVersion = null;
            this.MaximumVersion = null;
            this.Guid = null;
        }

        /// <summary>
        /// Construct a module specification from a hashtable.
        /// Keys can be ModuleName, ModuleVersion, and Guid.
        /// ModuleName must be convertible to <see cref="string"/>.
        /// ModuleVersion must be convertible to <see cref="Version"/>.
        /// Guid must be convertible to <see cref="Guid"/>.
        /// </summary>
        /// <param name="moduleSpecification">The module specification as a hashtable.</param>
        public ModuleSpecification(Hashtable moduleSpecification)
        {
            if (moduleSpecification == null)
            {
                throw new ArgumentNullException(nameof(moduleSpecification));
            }

            var exception = ModuleSpecificationInitHelper(this, moduleSpecification);
            if (exception != null)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Initialize moduleSpecification from hashtable. Return exception object, if hashtable cannot be converted.
        /// Return null, in the success case.
        /// </summary>
        /// <param name="moduleSpecification">object to initialize</param>
        /// <param name="hashtable">contains info about object to initialize.</param>
        /// <returns></returns>
        internal static Exception ModuleSpecificationInitHelper(ModuleSpecification moduleSpecification, Hashtable hashtable)
        {
            StringBuilder badKeys = new StringBuilder();
            try
            {
                foreach (DictionaryEntry entry in hashtable)
                {
                    string field = entry.Key.ToString();

                    if (field.Equals("ModuleName", StringComparison.OrdinalIgnoreCase))
                    {
                        moduleSpecification.Name = LanguagePrimitives.ConvertTo<string>(entry.Value);
                    }
                    else if (field.Equals("ModuleVersion", StringComparison.OrdinalIgnoreCase))
                    {
                        moduleSpecification.Version = LanguagePrimitives.ConvertTo<Version>(entry.Value);
                    }
                    else if (field.Equals("RequiredVersion", StringComparison.OrdinalIgnoreCase))
                    {
                        moduleSpecification.RequiredVersion = LanguagePrimitives.ConvertTo<Version>(entry.Value);
                    }
                    else if (field.Equals("MaximumVersion", StringComparison.OrdinalIgnoreCase))
                    {
                        moduleSpecification.MaximumVersion = LanguagePrimitives.ConvertTo<String>(entry.Value);
                        ModuleCmdletBase.GetMaximumVersion(moduleSpecification.MaximumVersion);
                    }
                    else if (field.Equals("GUID", StringComparison.OrdinalIgnoreCase))
                    {
                        moduleSpecification.Guid = LanguagePrimitives.ConvertTo<Guid?>(entry.Value);
                    }
                    else
                    {
                        if (badKeys.Length > 0)
                        {
                            badKeys.Append(", ");
                        }
                        badKeys.Append("'");
                        badKeys.Append(entry.Key.ToString());
                        badKeys.Append("'");
                    }
                }
            }
            // catch all exceptions here, we are going to report them via return value.
            // Example of catched exception: one of conversions to Version failed.
            catch (Exception e)
            {
                return e;
            }

            string message;
            if (badKeys.Length != 0)
            {
                message = StringUtil.Format(Modules.InvalidModuleSpecificationMember, "ModuleName, ModuleVersion, RequiredVersion, GUID", badKeys);
                return new ArgumentException(message);
            }

            if (string.IsNullOrEmpty(moduleSpecification.Name))
            {
                message = StringUtil.Format(Modules.RequiredModuleMissingModuleName);
                return new MissingMemberException(message);
            }

            if (moduleSpecification.RequiredVersion == null && moduleSpecification.Version == null && moduleSpecification.MaximumVersion == null)
            {
                message = StringUtil.Format(Modules.RequiredModuleMissingModuleVersion);
                return new MissingMemberException(message);
            }

            if (moduleSpecification.RequiredVersion != null && moduleSpecification.Version != null)
            {
                message = StringUtil.Format(SessionStateStrings.GetContent_TailAndHeadCannotCoexist, "ModuleVersion", "RequiredVersion");
                return new ArgumentException(message);
            }

            if (moduleSpecification.RequiredVersion != null && moduleSpecification.MaximumVersion != null)
            {
                message = StringUtil.Format(SessionStateStrings.GetContent_TailAndHeadCannotCoexist, "MaximumVersion", "RequiredVersion");
                return new ArgumentException(message);
            }
            return null;
        }

        internal ModuleSpecification(PSModuleInfo moduleInfo)
        {
            if (moduleInfo == null)
            {
                throw new ArgumentNullException(nameof(moduleInfo));
            }

            this.Name = moduleInfo.Name;
            this.Version = moduleInfo.Version;
            this.Guid = moduleInfo.Guid;
        }

        /// <summary>
        /// Implements ToString() for a module specification. If the specification
        /// just contains a Name, then that is returned as is. Otherwise, the object is
        /// formatted as a PowerSHell hashtable.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (Guid == null && Version == null && RequiredVersion == null && MaximumVersion == null)
            {
                return Name;
            }

            var moduleSpecBuilder = new StringBuilder();

            moduleSpecBuilder.Append("@{ ModuleName = '").Append(Name).Append("'");

            if (Guid != null)
            {
                moduleSpecBuilder.Append("; Guid = '{").Append(Guid).Append("}' ");
            }

            if (RequiredVersion != null)
            {
                moduleSpecBuilder.Append("; RequiredVersion = '").Append(RequiredVersion).Append("'");
            }
            else
            {
                if (Version != null)
                {
                    moduleSpecBuilder.Append("; ModuleVersion = '").Append(Version).Append("'");
                }
                if (MaximumVersion != null)
                {
                    moduleSpecBuilder.Append("; MaximumVersion = '").Append(MaximumVersion).Append("'");
                }
            }

            moduleSpecBuilder.Append(" }");

            return moduleSpecBuilder.ToString();
        }

        /// <summary>
        /// Parse the specified string into a ModuleSpecification object
        /// </summary>
        /// <param name="input">The module specification string</param>
        /// <param name="result">the ModuleSpecification object</param>
        /// <returns></returns>
        public static bool TryParse(string input, out ModuleSpecification result)
        {
            result = null;
            try
            {
                Hashtable hashtable;
                if (Parser.TryParseAsConstantHashtable(input, out hashtable))
                {
                    result = new ModuleSpecification(hashtable);
                    return true;
                }
            }
            catch
            {
                // Ignoring the exceptions to return false
            }

            return false;
        }

        /// <summary>
        /// The module name.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// The module GUID, if specified.
        /// </summary>
        public Guid? Guid { get; internal set; }

        /// <summary>
        /// The module version number if specified, otherwise null.
        /// </summary>
        public Version Version { get; internal set; }

        /// <summary>
        /// The module maxVersion number if specified, otherwise null.
        /// </summary>
        public String MaximumVersion { get; internal set; }

        /// <summary>
        /// The exact version of the module if specified, otherwise null.
        /// </summary>
        public Version RequiredVersion { get; internal set; }
    }

    /// <summary>
    /// Compares two ModuleSpecification objects for equality.
    /// </summary>
    internal class ModuleSpecificationComparer : IEqualityComparer<ModuleSpecification>
    {
        /// <summary>
        /// Check if two module specifications are property-wise equal.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>True if the specifications are equal, false otherwise.</returns>
        public bool Equals(ModuleSpecification x, ModuleSpecification y)
        {
            if (x == y)
            {
                return true;
            }

            return x != null && y != null
                && String.Equals(x.Name, y.Name, StringComparison.OrdinalIgnoreCase)
                && Guid.Equals(x.Guid, y.Guid)
                && Version.Equals(x.RequiredVersion, y.RequiredVersion)
                && Version.Equals(x.Version, y.Version)
                && String.Equals(x.MaximumVersion, y.MaximumVersion);
        }

        /// <summary>
        /// Get a property-based hashcode for a ModuleSpecification object.
        /// </summary>
        /// <param name="obj">The module specification for the object.</param>
        /// <returns>A hashcode that is always the same for any module specification with the same properties.</returns>
        public int GetHashCode(ModuleSpecification obj)
        {
            if (obj == null)
            {
                return 0;
            }

            return HashCode.Combine(obj.Name, obj.Guid, obj.RequiredVersion, obj.Version, obj.MaximumVersion);
        }
    }

    #endregion
} // Microsoft.PowerShell.Commands
