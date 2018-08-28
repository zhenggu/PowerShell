# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.
Describe "Register-EngineEvent" -Tags "CI" {

    Context "Check return type of Register-EngineEvent" {
	It "Should return System.Management.Automation.PSEventJob as return type of Register-EngineEvent" {
	    Register-EngineEvent -SourceIdentifier PesterTestRegister -Action {echo registerengineevent} | Should -BeOfType System.Management.Automation.PSEventJob
	    Unregister-Event -sourceidentifier PesterTestRegister
	}
    }
}
