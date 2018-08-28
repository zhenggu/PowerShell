# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.
Describe "Start-Sleep DRT Unit Tests" -Tags "CI" {

    # WaitHandle.WaitOne(milliseconds, exitContext) is not accurate.
    # The wait time varies from 980ms to 1150ms from observation, so
    # the tests here are changed to be greater than 950ms.
    $minTime = 950
    $maxTime = 1200

    It "Should work properly when sleeping with Second" {
        $watch = [System.Diagnostics.Stopwatch]::StartNew()
        Start-Sleep -Seconds 1
        $watch.Stop()
        $watch.ElapsedMilliseconds | Should -BeGreaterThan $minTime
        $watch.ElapsedMilliseconds | Should -BeLessThan $maxTime
    }

    It "Should work properly when sleeping with Milliseconds" {
        $watch = [System.Diagnostics.Stopwatch]::StartNew()
        Start-Sleep -Milliseconds 1000
        $watch.Stop()
        $watch.ElapsedMilliseconds | Should -BeGreaterThan $minTime
        $watch.ElapsedMilliseconds | Should -BeLessThan $maxTime
    }

    It "Should work properly when sleeping with ms alias" {
        $watch = [System.Diagnostics.Stopwatch]::StartNew()
        Start-Sleep -ms 1000
        $watch.Stop()
        $watch.ElapsedMilliseconds | Should -BeGreaterThan $minTime
        $watch.ElapsedMilliseconds | Should -BeLessThan $maxTime
    }
}

Describe "Start-Sleep" -Tags "CI" {

    Context "Validate Start-Sleep works properly" {
	It "Should only sleep for at least 1 second" {
	    $result = Measure-Command { Start-Sleep -s 1 }
	    $result.TotalSeconds | Should -BeGreaterThan 0.25
	}
    }
}
