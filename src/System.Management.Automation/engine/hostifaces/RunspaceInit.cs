// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Dbg = System.Management.Automation.Diagnostics;
using DWORD = System.UInt32;

namespace System.Management.Automation.Runspaces
{
    /// <summary>
    /// Runspace class for local runspace
    /// </summary>

    internal sealed partial
    class LocalRunspace : RunspaceBase
    {
        /// <summary>
        /// initialize default values of preference vars
        /// </summary>
        /// <returns> Does not return a value </returns>
        /// <remarks>  </remarks>

        private void InitializeDefaults()
        {
            SessionStateInternal ss = _engine.Context.EngineSessionState;
            Dbg.Assert(ss != null, "SessionState should not be null");

            // Add the variables that must always be there...
            ss.InitializeFixedVariables();
        }
    }
}

