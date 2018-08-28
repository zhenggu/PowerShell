// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Management.Automation;

namespace Microsoft.PowerShell.Commands
{
    /// <summary>
    /// The implementation of the "New-TemporaryFile" cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "TemporaryFile", SupportsShouldProcess = true, HelpUri = "https://go.microsoft.com/fwlink/?LinkId=821836")]
    [OutputType(typeof(System.IO.FileInfo))]
    public class NewTemporaryFileCommand : Cmdlet
    {
        /// <summary>
        /// Returns a TemporaryFile.
        /// </summary>
        protected override void EndProcessing()
        {
            string filePath = null;
            string tempPath = Path.GetTempPath();
            if (ShouldProcess(tempPath))
            {
                try
                {
                    filePath = Path.GetTempFileName();
                }
                catch (IOException ioException)
                {
                    ThrowTerminatingError(
                        new ErrorRecord(
                            ioException,
                            "NewTemporaryFileWriteError",
                            ErrorCategory.WriteError,
                            tempPath));
                    return;
                }
                if (!string.IsNullOrEmpty(filePath))
                {
                    FileInfo file = new FileInfo(filePath);
                    WriteObject(file);
                }
            }
        }
    }
}
