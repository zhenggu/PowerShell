# Changelog

## v6.1.0-rc.1 - 2018-08-22

### Engine Updates and Fixes

- Fix to not duplicate the `System32` module path when starting `pwsh` from `pwsh` (#7414)
- Fix sequence point update for `switch/if/for/while/do-while/do-until` statements (#7305)
- Set the cursor to the place where a user hits tab key (#7299)
- Adding `LanguagePrimitives.TryCompare` to provide faster comparisons (#7438) (Thanks @powercode!)
- Improving performance of `LanguagePrimitives.TryConvertTo` (#7418) (Thanks @powercode!)
- Set `PowerShellVersion` to `3.0` for built-in modules to make Windows PowerShell work when starting from PowerShell Core (#7365)
- Avoid extra unnecessary allocations in `PSMemberInfoInternalCollection<T>` (#7435) (Thanks @iSazonov!)
- Enforce the `CompatiblePSEditions` check for modules from the legacy `System32` module path (#7183)
- Make sure that `SettingFile` argument is parsed before we load the settings (#7449)
- Default to `DefaultConsoleWidth` when DotNet says `WindowWidth` is 0 (#7465)

### General Cmdlet Updates and Fixes

- Fix parameter name in the `Get-Variable` cmdlet error message (#7384) (Thanks @sethvs!)
- Fix `Move-Item -Path` with wildcard character (#7397) (Thanks @kwkam!)
- Ignore `Newtonsoft.Json` metadata properties in `ConvertFrom-Json` (#7308) (Thanks @louistio!)
- Fix several issues in Markdown cmdlets (#7329)
- Add support for parsing Link Header with variable whitespace (#7322)
- Change parameter order in `Get-Help` and help in order to get first `-Full` and
  then `-Functionality` when using Get-Help `-Fu` followed by pressing tab and help `-Fu` followed by pressing tab (#7370) (Thanks @sethvs!)
- Add support for passing files and Markdown directly to `Show-Markdown` (#7354)
- Add `-SkipIndex` parameter to `Select-Object` (#7483) (Thanks @powercode!)
- Improve performance of `Import-CSV` up to 10 times (#7413) (Thanks @powercode!)
- Update `Enable-PSRemoting` so configuration name is unique for Preview releases (#7202)
- Improve performance on JSON to PSObject conversion (#7482) (Thanks @powercode!)
- Fix error message for `Add-Type` when `-AssemblyName` with wildcard is not found (#7444)
- Make native globbing on Unix return an absolute path when it is given an absolute path (#7106)
- Improve the performance of `Group-Object` (#7410) (Thanks @powercode!)
- Remove one unneeded verbose output from `ConvertTo-Json` (#7487) (Thanks @devblackops!)
- Enable `Get-ChildItem` to produce `Mode` property even if cannot determine if hard link (#7355)

### Code Cleanup

- Remove empty XML comment lines (#7401) (Thanks @iSazonov!)
- Cleanup Docker files (#7328)
- Correct the comment for `WSManReceiveDataResult.Unmarshal` (#7364)
- Format Utility `csproj` with updated `codeformatter` (#7263) (Thanks @iSazonov!)
- Bulk update format for files in Management folder with `codeformatter` (#7346) (Thanks @iSazonov!)
- Cleanup: replace `Utils.FileExists()/DirectoryExists()/ItemExists()` with DotNet methods (#7129) (Thanks @iSazonov!)
- Update `Utils.IsComObject` to use `Marshal.IsComObject` since CAS is no longer supported in DotNet Core (#7344)
- Fix some style issues in engine code (#7246) (Thanks @iSazonov!)

### Test

- Use `-BeExactly` and `-HaveCount` instead of `-Be` in `BugFix.Tests.ps1` (#7386) (Thanks @sethvs!)
- Use `-BeExactly` and `-HaveCount` instead of `-Be` in `TabCompletion.Tests.ps1` (#7380) (Thanks @sethvs!)
- Update CI scripts to support running tests for experimental features (#7419)
- Use `-HaveCount` instead of `-Be` in `Where-Object.Tests.ps1` (#7379) (Thanks @sethvs!)
- Fix ThreadJob tests so that they will run more reliably (#7360)
- Make logging tests for macOS pending (#7433)

### Build and Packaging Improvements

- Update Build script owners (#7321)
- Make `MUSL` NuGet package optional (#7316)
- Enable `pwsh-preview` to work on Windows (#7345)
- Fix SDK dependencies
- Add back the `powershell-core` NuGet source for hosting tests
- Fix typo in environment checker (#7547 & #7549)
- Only remove the revision if it is `0` from module version when restoring modules (#7538)
- Update `WCF` and `NJsonSchema` NuGet packages to latest released patch version (#7411) (Thanks @bergmeister!)
- Add Linux and macOS VSTS CI (#7490, #7527, #7535, #7515 & #7516)
- Updated ThreadJob to version `1.1.2` (#7522)
- Add xUnit project to `PowerShell.sln` and make it runnable from within VisualStudio (#7254) (Thanks @bergmeister!)
- Update NuGet packaging code for the new markdown assembly (#7431)
- Update version of modules shipped with PowerShell (#7531)
- Retry restore on failure (#7544 & #7550)
- Update `PowerShellGet` version
- Update NuGet package metadata (#7517)
- Update reference to use packages from `NuGet.org` (#7525)
- `Start-DevPowerShell`: add `-Configuration` and handle `-ArgumentList` more properly (#7300) (Thanks @jazzdelightsme!)
- Add preview icon to macOS launcher (#7448) (Thanks @thezim!)
- Add `Microsoft.PowerShell.MarkdownRender` to `signing.xml` (#7472)
- Fix building on RedHat Enterprise Linux (#7489)
- Build: Also search PATH for `rcedit`  (#7503) (Thanks @kwkam!)
- Save modules to un-versioned folder to enable servicing (#7518 & #7523)
- Fix macOS launcher app to allow release and preview versions (#7306) (Thanks @thezim!)

### Documentation and Help Content

- Fix docs comments in utility folder (#7192) (Thanks @iSazonov!)
- Fix a typo in `issue-management.md` (#7393) (Thanks @alexandair!)
- Fix casing of `GitHub` in `best-practice.md` (#7392) (Thanks @alexandair!)
- Fix typos in `docs/maintainers/README.md` (#7390) (Thanks @alexandair!)
- Add maintainer's best practice document and update maintainer list (#7311)
- Update Docker link to `PowerShell-Docker` (#7351) (Thanks @JoshuaCooper!)
- Add `Snapcraft` to spelling dictionary (#7318)
- Update `README.md` and `metadata.json` for release `v6.0.4` (#7497)
- Add `Former Repository Maintainers` section in `maintainers/README.md` (#7475)
- Update the `HelpUri` for `Get-ExperimentalFeature` (#7466)

## v6.1.0-preview.4 - 2018-07-19

### Breaking Changes

- Remove the `VisualBasic` support from Add-Type (#7284)
- Update PowerShell Direct to try `pwsh` then fallback to `powershell` (#7241)
- Make pwsh able to start in a directory with wildcards in the name (#7240)
- Update `Enable-PSRemoting` so configuration name is unique for Preview releases (#7202)
- Enforce the `CompatiblePSEditions` check for modules from the legacy `System32` module path (#7183)

### Engine Updates and Fixes

- Add support to experimental features (#7242)
- Fix error when using `Get-ChildItem c:` (#7033) (Thanks @sethvs!)
- Add location history for `Set-Location` to enable `cd -` scenario (issue #2188) (#5051) (Thanks @bergmeister!)
- Fix padding for right aligned column in table formatting (#7136)
- Fix a performance regression to the `-replace` operator after adding `ScriptBlock` support (#7135)
- Fix tab expansion for `Get-Process` on macOS (#7176)
- When using PSRP, if we receive text instead of XML, output it as error to help troubleshoot (#7168)
- Fix trimming of whitespace when table is wrapped (#7184)
- Modified the `Group-Object -AsHashTable` to use the base object of `PSObject` as the key for the `Hashtable` (#7123)
- Add back ADSI and WMI type accelerators (#7085)
- Add `CompatiblePSEditions` to PowerShell Core built-in modules (#7083)
- Make `Start-Process -ArgumentList` to accept `@()` or `$null` (#6597)
- Avoid calling native APIs to check for existence of FileSystem items (#6929) (Thanks @iSazonov!)
- Add copy environment variables from `ProcessStartInfo` to key/pair array used in creating SSH process (#7070)
- Add markdown rendering feature assemblies to the trusted assembly list (#7280)
- Don't fail if `SaferPolicy` API is not available on Windows 10 IoT or NanoServer (#7075)
- Fix conditions for transcription of `Write-Information` command. (#6917) (Thanks @hubuk!)
- Fix a parsing error when `break` and `continue` are used in a switch statement in a finally block (#7273)
- Fix prompt string to be platform agnostic and keep its trailing spaces (#7255)
- Make progress panel display correctly on UNIX when the user is typing. (#6972)
- Revert change to have `SetLocation()` treat wildcarded path as literal if it exists (#7101)
- Make `Select-Object`/`ForEach-Object`/`Where-Object` see dynamic properties (#6898) (Thanks @jazzdelightsme!)
- Fix class searcher to ignore hidden properties (#7188)
- Update remote prompt when using SSH to show username if different (#7191)
- Remove `SemanticVersion` from `knowntypes` list in serialization code to enable interop between Windows PowerShell and PowerShell Core (#7016)
- Add more information to job process failure error (#7251)
- Use .Net Core `File.Delete()` method to remove symbolic links and alternate streams (#7017) (Thanks @iSazonov!)
- Enable `UseShellExecute` on all platforms (#7198)
- Methods with return type `[object]` should return `null` for an empty result (#7138)

### General Cmdlet Updates and Fixes

- Add Markdown rendering cmdlets (#6926)
- `Send-MailMessage`: Update all parameters to support `ValueFromPipelineByPropertyName`. (#6911) (Thanks @sethvs!)
- Allow Basic Auth over HTTPS (#6890)
- Add `ThreadJob` module package and tests (#7169)
- Fix Windows Event Log channel isolation semantics (#6956) (Thanks @Robo210!)
- Make `Measure-Object` handle `scriptblock` properties. (#6934)
- Added functionality to retry in `Invoke-RestMethod` and `Invoke-WebRequest`. (#5760)
- Add type inference for `Select-Object` command (#7171) (Thanks @powercode!)
- Add `-AllStats` Switch parameter for `Measure-Object` cmdlet (#7220) (Thanks @kvprasoon!)

### Code Cleanup

- Remove unneeded code that forces ARM platforms to run PowerShell in CL mode (#7046)
- Bulk update code base to put `null` on the right-hand-side of a comparison expression (#6949) (Thanks @iSazonov!)
- Remove `MapSecurityZoneWithUrlmon` method and related code (#7103)
- Cleanup: remove the unneeded type `RemotingCommandUtils` (#7029)
- Remove unneeded "Windows-Full" modules (#7030)
- CodeFactor code style cleanup: replace literal empty strings with `string.Empty` (#6950) (Thanks @iSazonov!)
- Remove dummy comments in Utility module files (#7224) (Thanks @iSazonov!)
- Use empty array for Functions/Cmdlets/`AliasesToExport` to follow the best practice (#7108)
- Refactor module code related to `Get-Module -ListAvailable` (#7145)
- Refactor module specification logic (#7126)

### Test

- Add tests for module specifications (#7140)
- Update test string for better clarity in `Send-MailMessage.Tests.ps1` (#7195) (Thanks @sethvs!)
- Add test to verify filesystem provider isn't used when accessing root path in `PSDrive` (#7173)
- Fix to address `ThreadJob` tests reliability and speed (#7270)
- Add additional checks for test that passes inconsistently (#7051)

### Build and Packaging Improvements

- `install-powershell.sh` filter pre-releases (when available), `params` documentation (#6849) (Thanks @DarwinJS!)
- Fedora 28 was released, Fedora 26 and 25 went end of life. (#7079) (Thanks @adelton!)
- Disambiguate icon on Windows for preview builds/installers to use `Powershell_av_colors` and
  make daily build use `Powershell_avatar` instead (#7086) (Thanks @bergmeister!)
- Update to build for Alpine (#7139)
- Update build and packaging modules for Alpine (#7149)
- Add ability to install previews side-by-side with production releases (#7194) (Thanks @DarwinJS!)
- Enable NuGet Package Registration for compliance (#7053)
- Fix the preview macOS package link (#7061)
- Remove PSReadLine from then `PowerShell.sln` file (#7137)
- Fix the file `PowerShell.sln` that was corrupted by accident (#7288)
- Fix the encoding of `PowerShell.sln` to be `utf-8` (#7289)
- Make sure all references to the Package ID for previews packages is powershell-preview (#7066)
- Update `internals.md` with the latest build changes (#7058)
- When installing using MSI, set the working directory of the shortcut to the user home directory (#7072)
- Move to dotnet core 2.1.1 (#7161) (Thanks @iSazonov!)
- Update to latest package references, runtime framework, and SDK (#7272)
- AppVeyor build matrix: more efficient build job split to reduce total time by another 5 minutes (#7021) (Thanks @bergmeister!)
- Build: Fix the source location of `PowerShell.Core.Instrumentation.dll` (#7226)
- Add Andrew to the default reviewers of the build related files (#7019)
- Build: Fix a check to avoid null argument in case `vcvarsall.bat` is absent (#7218) (Thanks @PetSerAl!)
- Update `releaseTag` in `tools/metadata.json` (#7214)
- Update `Start-PSPester` to make it more user friendly (#7210) (Thanks @bergmeister!)
- Make `Start-PSBuild -Clean` not prompt due to locked files when Visual Studio is open by excluding `sqlite3` folder and use `-x` instead of `-X` option on `git clean` (#7235) (Thanks @bergmeister!)

### Documentation and Help Content

- Fix typos in `DOCSMIGRATION.md` (#7094) (Thanks @alexandair!)
- Add instructions to update Homebrew formula for the preview version PowerShell (#7067) (Thanks @vors!)
- Merge Third Party Notices and License updates (#7203)
- Update third party notices (#7042)
- Fix Markdown and spelling errors in `CHANGELOG.md` (#7064)
- Fix `New-TemporaryFile` online help URI (#6608)
- Fix links to PowerShell install docs (#7001) (Thanks @jokajak!)
- Update links that contain `en-us` culture (#7013) (Thanks @bergmeister!)
- Update docs for `ArgumentCompleterAttribute` class (#7227) (Thanks @Meir017!)
- Fix the name of a `Register-EngineEvent` test (#7222) (Thanks @alexjordan6!)
- Update README files for native code for migration (#7248)
- Comment about dynamic members for the `DotNetAdapter`, `GetMember` and `GetMembers` (#7087)
- Update the PowerShell executable location in building guide docs (#7205) (Thanks @louistio!)

## v6.1.0-preview.3 - 2018-06-07

### Breaking Changes

- Clean up uses of `CommandTypes.Workflow` and `WorkflowInfo` (#6708)
- Disallow Basic Auth over HTTP in PowerShell Remoting on Unix (#6787)
- Change packaging to differentiate only between major versions and previews (#6968)
- Enhance and refactor `Add-Type` cmdlet (#6141) (Thanks @iSazonov!)
    - A few error strings were removed and thus the corresponding fully qualified error ids are no longer in use.

### Engine Updates and Fixes

- Fix crash when terminal is reset (#6777)
- Fix a module-loading regression that caused an infinite loop (#6843)
- Further improve `PSMethod` to `Delegate` conversion (#6851)
- Blacklist `System.Windows.Forms` from loading to prevent a crash (#6822)
- Fix `Format-Table` where rows were being trimmed unnecessarily if there's only one row of headers (#6772)
- Fix `SetDate` function in `libpsl-native` to avoid corrupting memory during `P/Invoke` (#6881)
- Fix tab completions for hash table (#6839) (Thanks @iSazonov!)
- Fix parser to continue parsing key-value pairs after an `If-Statement` value in a `HashExpression` (#7002)
- Add error handling for `#requires` in an interactive session (#6469)

### General Cmdlet Updates and Fixes

- Improve parameter validation in `ExportCsvHelper` (#6816) (Thanks @sethvs!)
- Quote `Multipart` form-data field names (#6782) (Thanks @markekraus!)
- Fix Web Cmdlets for .NET Core 2.1 (#6806) (Thanks @markekraus!)
- Fix `Set-Location DriveName:` to restore current working directory in the drive (#6774) (Thanks @mcbobke!)
- Add the alias `-lp` for `-LiteralPath` parameters #6732 (#6770) (Thanks @kvprasoon!)
- Remove `more` function and move the `$env:PAGER` capability into the `help` function (#6059) (Thanks @iSazonov!)
- Add line break to the error message for `Set-ExecutionPolicy` (#6803) (Thanks @wesholton84!)

### Code Cleanup

- Clean up `#if SILVERLIGHT` (#6907) (Thanks @iSazonov!)
- Clean up the unused method `NonWindowsGetDomainName()` (#6948) (Thanks @iSazonov!)
- Clean up FileSystem provider (#6909) (Thanks @iSazonov!)

### Test

- Add tests for PowerShell hosting API to verify MyGet packages (#6737)
- Remove Web Cmdlets tests using proxy environment variables (#6808) (Thanks @iSazonov!)
- Enable Web Cmdlets tests for greater platform support (#6836) (Thanks @markekraus!)
- Convert `ShouldBeErrorId` to `Should -Throw -ErrorId` in PowerShell tests (#6682)
- Fix CIM cmdlets tests (#6755) (Thanks @sethvs!)
- Add tests for PowerShell classes inheriting from abstract .NET classes (#6752)
- Fix `Select-Object.Tests.ps1` which previously failed intermittently on Unix platforms. (#6747)
- Update docker package tests to fix error on OpenSUSE 42 (#6783)
- Fix test and infrastructure that block code coverage runs (#6790)
- Update Tests `Isfile` to correct response for `"/"` (#6754) (Thanks @Patochun!)
- Improve code coverage in `Export-Csv.Tests.ps1` (#6795) (Thanks @sethvs!)
- Change `-Quiet` parameter of `Invoke-Pester` to `-Show None` in `OpenCover.psm1` (#6798) (Thanks @sethvs!)
- Replace `Dbg.Assert` with `if () throw` in `CSVCommands.cs` (#6910) (Thanks @sethvs!)
- Fix xUnit test `GetTempFileName` (#6943) (Thanks @iSazonov!)

### Build and Packaging Improvements

- Add Windows Compatibility Pack 2.0.0 to PowerShell Core and adopt the official .NET Core 2.1 (#6958)
- Add Jumplist 'Run as Administrator' to Taskbar on Windows (#6913, #6985) (Thanks @bergmeister!)
- Use AppVeyor matrix for faster Pull Request builds (#6945) (Thanks @bergmeister!)
- Fix `build.psm1` to not add tool path to $PATH twice (#6834)
- Add script to create a container manifest (#6735)
- Fix docker manifest creation script to work with more complex tags and with repeated use (#6852)
- Add functions to merge Pester and xUnit logs (#6854)
- Enable generating full symbols for the Windows debug build (#6853)
- Add functions into `build.psm1` to save and restore `PSOptions` between different sessions. (#6884)
- Update signing XML based on new signing guidelines (#6893)
- Update the release docker files to allow specifying the version of to-be-installed PowerShell and the version of image to use (#6835)
- Updates docker files for Fedora 27 and Kali Linux (#6819)
- Change packaging to support Ubuntu 17.10 and 18.04 (#6769)
- Update `Get-ChangeLog` to make it more accurate (#6764)
- Fix comparison to see if sudo test is needed in `install-*.sh` (#6771) (Thanks @bjh7242!)
- Packaging: Add registry keys to support library folder background for explorer context menu (#6784) (Thanks @bergmeister!)
- Skip `dotnet-cli` initialization and stop caching the `dotnet` folder for Travis CI (#7007)
- Skip compiling the non-supported cmdlets on Unix in `System.Management.Automation.dll` to fix the crash in Unix debug build (#6939)
- Use `PSReadLine` 2.0.0-beta2 from PSGallery (#6998)
- Update `PSRP` Linux NuGet package version to 1.4.2-* (#6711)
- Add path cleanup utility `Reset-PWSHSystemPath.ps1` (#6892) (Thanks @DarwinJS!)
- Add logic to create signing XML for NuGet packages (#6921)
- Add and config the `Settings.StyleCop` file (#6930, #6986) (Thanks @iSazonov!)
- Fix the double curly bracket typo in a docker file (#6960) (Thanks @adelton!)
- Remove dependencies on `libcurl` and `libunwind` in packaging to match the .NET Core behavior (#6964) (Thanks @qmfrederik!)
- Make the docker build fail when the curl operation fails. (#6961) (Thanks @adelton!)

### Documentation and Help Content

- Update installation doc about Raspbian (#6859)
- Add code coverage report generation instructions (#6515)
- Migrate docs from PowerShell repository to Docs repository (#6899)
- Fix broken links due to migrating GitHub docs on Installation, Known Issues and Breaking Changes to `docs.microsoft.com` (#6981) (Thanks @bergmeister!)
- Update documentation on how to write tests verifying errors conditions (#6687)
- Fix preview download links in `README.md` (#6762)

## v6.1.0-preview.2 - 2018-04-27

### Breaking Changes

- Remove support for file to opt-out of telemetry, only support environment variable (#6601)
- Simplify the installation paths the MSI uses (#6442)

### Engine Updates and Fixes

- Fix running `pwsh` produced from `dotnet build` (#6549)
- Remove the `FullCLR-only` symbol-info related code from `EventManager.cs` (#6563)
- Improve `PSMethod-to-Delegate` conversion (#6570)
- Fix `PsUtils.GetManModule()` to avoid infinite loop when there was no main module (#6358)
- Fix error in windows environment provider when the environment variable has duplicates that differ only by case (#6489) (Thanks @mklement0!)
- Make sure that the width of the header is at least the size of the label (or property name) (#6487)
- Enable `[Environment]::OSVersion` to return current OS rather than compatible version (#6457)
- Change the `SaveError` method in Parser to use `nameof` for error ids (#6498)
- Fix error when `Format-Wide -AutoSize | Out-String` is called (#6491) (Thanks @stknohg!)
- Make `LanguagePrimitive.GetEnumerable` treat `DataTable` as Enumerable (#6511)
- Fix formatting of tables where headers span multiple rows (#6504)
- Improve performance of parsing `RegexOption` for `-split` by using `if` branches (#6605) (Thanks @iSazonov!)
- Enable specifying `sshd` subsystem to use via `-Subsystem` (#6603)
- Add some optimizations in formatting subsystem (#6678) (Thanks @iSazonov!)
- Throw better parsing error when statements should be put in named block (#6434)
- Use `Unregister-Event` to remove an event subscriber when removing `PSEdit` function (#6449)
- Make the `PSISERemoteSessionOpenFile` a support event (#6582)
- Add `-WorkingDirectory` parameter to `pwsh` (#6612)
- Support importing module paths that end in trailing directory separator (#6602)
- Formatting: Use cache for dash padding strings for tables (#6625) (Thanks @iSazonov!)
- Port Windows PowerShell AppLocker and DeviceGuard `UMCI` application white listing support (#6133)
- Reduce allocations in `TableWriter` (#6648) (Thanks @iSazonov!)

### General Cmdlet Updates and Fixes

- Add `-Resume` Feature to WebCmdlets (#6447) (Thanks @markekraus!)
- Support `user@host:port` syntax for `SSH` transport (#6558)
- Add ported `Test-Connection` cmdlet (#5328) (Thanks @iSazonov!)
- Added line break to Access-Denied error message (#6607)
- Some fixes in `Get-Date -UFormat` (#6542) (Thanks @iSazonov!)
- Added check for existence of Location HTTP header before using it (#6560) (Thanks @ffeldhaus!)
- Enable `Update-Help` to save help content in user scope by default (#6352)
- Update `Enable-PSRemoting` to create PowerShell.6 endpoint and version specific endpoint (#6519, #6630)
- Update error message that `Disconnect-PSSession` is only supported with `WSMan` (#6689)
- Make `Export-FormatData` print pretty XML output (#6691) (Thanks @iSazonov!)
- Add `-AsArray` parameter to `ConvertoTo-Json` command (#6438)
- Add `Test-Json` cmdlet (`NJsonSchema`) (#5229) (Thanks @iSazonov!)
- Correct a typo in comment for `Invoke-WebRequest` (#6700) (Thanks @gabrielsroka!)
- Re-order `UFormat` options in `Get-Date` (#6627) (Thanks @iSazonov!)
- Add the parameter `-Not` to `Where-Object` (#6464) (Thanks @SimonWahlin!)

### Code Cleanup

- Engine: Fix several code cleanup issues (#6552, #6609)
- Clean up workflow logic in the module loading component (#6523)
- Engine: Clean up unneeded `GetTypeInfo()` calls (#6613, #6636, #6633, #6635, #6634)

### Test

- Fix line ending in `DefaultCommands.Tests.ps1` from `CRLF` to `LF` (#6553)
- Use new Pester parameter syntax in tests (#6490, #6574, #6535, #6536, #6488, #6366, #6351, #6349, #6256, #6250) (Thanks @KevinMarquette, @sethvs, @bergmeister!)
- Fix `Copy.Item.Tests.ps1` (#6596) (Thanks @sethvs!)
- Fix typos or formatting in some test files (#6595, #6593, #6594, #6592, #6591) (Thanks @sethvs!)
- Add missing `Start-WebListener` to WebCmdlets tests (#6604) (Thanks @markekraus!)
- Update Dockerfile test to use Ubuntu 17.10 as the base image (#6503)
- Add PowerShell logging tests for macOS and Linux (#6025)
- Add tests for `Format-Table -Wrap` (#6670) (Thanks @iSazonov!)
- Reformat `Format-Table` tests (#6657) (Thanks @iSazonov!)
- Add new reliable tests for `Get-Date -UFormat` (#6614) (Thanks @iSazonov!)

### Build and Packaging Improvements

- Use C# latest language in `.csproj` files (#6559) (Thanks @iSazonov!)
- Update `installpsh-<distrofamily>.sh` installers to handle "preview" in version number (#6573) (Thanks @DarwinJS!)
- Enable `PowerShell.sln` to work in VisualStudio (#6546)
- Remove duplicate `Restore-PSPackage` (#6544)
- Use `-WorkingDirectory` parameter to handle context menu when path contains single quotes (#6660) (Thanks @bergmeister!)
- Make `-CI` not depend on `-PSModuleRestore` in `Start-PSBuild` (#6450)
- Restore for official Linux arm builds (#6455)
- Fix error about setting readonly variable in `install-powershell.sh` (#6617)
- Make release macOS build work better (#6619, #6610)
- MSI: add function to generate a `MSP` package (#6445)

### Documentation and Help Content

- Doc: Update Ubuntu source creation commands to use `curl -o` (#6510) (Thanks @M-D-M!)
- Update stale bot message (#6462) (Thanks @iSazonov!)
- Remove extraneous SSH and install docs from the 'demos' folder (#6628)

## v6.1.0-preview.1 - 2018-03-23

### Breaking Changes

- Throw terminating error in `New-TemporaryFile` and make it not rely on the presence of the `TEMP` environment variable (#6182) (Thanks @bergmeister!)
- Remove the unnecessary `AddTypeCommandBase` class from `Add-Type` (#5407) (Thanks @iSazonov!)
- Remove unsupported members from the enum `Language` in `Add-Type` (#5829) (Thanks @iSazonov!)
- Fix range operator to work better with character ranges (#5732) (Thanks @iSazonov!)

### Engine Updates and Fixes

- Fix `ValidateSet` with generator in a module (#5702)
- Update `SAL` annotation and fix warnings (#5617)
- Add `ForEach` and `Where` methods to `PSCustomobject` (#5756) (Thanks @iSazonov!)
- Add `Count` and `Length` properties to `PSCustomobject` (#5745) (Thanks @iSazonov!)
- Make minor fixes in compiler to properly handle void type expression (#5764)
- Logging: Fix the escaped characters when generating `.resx` file from PowerShell `ETW` manifest. (#5892)
- Remove `PSv2` only code from `Types_Ps1Xml.cs` and `HostUtilities.cs` (#5907) (Thanks @iSazonov!)
- Enable passing arrays to `pwsh -EncodedArguments` on debug builds. (#5836)
- Logging: Handle path that contains spaces in `RegisterManifest.ps1` (#5859) (Thanks @tandasat!)
- Add `-settingsfile` to `pwsh` to support loading a custom powershell config file. (#5920)
- Return better error for `pwsh -WindowStyle` on unsupported platforms. (#5975) (Thanks @thezim!)
- Enable conversions from `PSMethod` to `Delegate` (#5287) (Thanks @powercode!)
- Minor code clean-up changes in tab completion code (#5737) (Thanks @kwkam!)
- Add lambda support to `-replace` operator (#6029) (Thanks @IISResetMe!)
- Fix retrieval of environment variables on Windows in cases where variable names differ only by case. (#6320)
- Fix the `NullRefException` when using `-PipelineVariable` with `DynamicParam` block (#6433)
- Add `NullReference` checks to two code paths related to `PseudoParameterBinder` (#5738) (Thanks @kwkam!)
- Fix `PropertyOnlyAdapter` to allow calling base methods (#6394)
- Improve table view for `Certs` and `Signatures` by adding `EnhancedKeyUsageList` and `StatusMessage` (#6123)
- Fix the filtering of analytic events on Unix platforms. (#6086)
- Update copyright and license headers (#6134)
- Set pipeline thread stack size to 10MB (#6224) (Thanks @iSazonov!)

### General Cmdlet Updates and Fixes

- Fix the `NullRefException` in `Enter-PSHostProcess` (#5995)
- Merge and Sort `BasicHtmlWebResponseObject` and `ContentHelper` in Web Cmdlets (#5720) (Thanks @markekraus!)
- Encoding for `New-ModuleManifest` on all platforms should be `UTF-8 NoBOM` (#5923)
- Make `Set-Location` use path with wildcard characters as literal if it exists (#5839)
- Combine Web Cmdlets partial class files (#5612) (Thanks @markekraus!)
- Change `Microsoft.PowerShell.Commands.SetDateCommand.SystemTime` to `struct`. (#6006) (Thanks @stknohg!)
- Add Simplified `multipart/form-data` support to Web Cmdlets through `-Form` parameter (#5972) (Thanks @markekraus!)
- Make a relative redirect URI absolute when `Authorization` header present (#6325) (Thanks @markekraus!)
- Make relation-link handling in Web Cmdlets case-insensitive (#6338)
- Make `Get-ChildItem -LiteralPath` accept `Include` or `Exclude` filter (#5462)
- Stop `ConvertTo-Json` when `Ctrl+c` is hit (#6392)
- Make `Resolve-Path -Relative` return useful path when `$PWD` and `-Path` is on different drive (#5740) (Thanks @kwkam!)
- Correct the `%c`, `%l`, `%k`, `%s` and `%j` formats in `Get-Date -UFormat` (#4805) (Thanks @iSazonov!)
- Add standard deviation implementation on `Measure-Object` (#6238) (Thanks @CloudyDino!)
- Make `Get-ChildItem <PATH>/* -file` include `<Path>` as search directory (#5431)
- Enable setting `PSSession` Name when using `SSHTransport` and add `Transport` property (#5954)
- Add `Path` alias to `-FilePath` parameters and others for several commands (#5817) (Thanks @KevinMarquette!)
- Add the parameter `-Password` to `Get-PfxCertificate` (#6113) (Thanks @maybe-hello-world!)
- Don't add trailing spaces to last column when using `Format-Table` (#5568)
- Fix table alignment and padding. (#6230)
- Add `-SkipHeaderValidation` Support to `ContentType` on Web Cmdlets (#6018) (Thanks @markekraus!)
- Add common aliases for all `write-*` commands default message parameter (#5816) (Thanks @KevinMarquette!)
- Make `UTF-8` the default encoding for `application/json` (#6109) (Thanks @markekraus!)
- Enable `$env:PAGER` to work correctly if arguments are used (#6144)

### Test

- Convert Web Cmdlets test to `one-true-brace-style` formatting (#5716) (Thanks @markekraus!)
- Add a test for `IValidateSetValuesGenerator` in a module (#5830) (Thanks @iSazonov!)
- Fix function to test for docker OS due to change to use `linuxkit` for macOS (#5843)
- Replace `HttpListener` tests with `WebListener` (#5806, #5840, #5872) (Thanks @markekraus!)
- Stop `HttpListener` from running in Web Cmdlets tests (#5921) (Thanks @markekraus!)
- Fix `PSVersion` in `PSSessionConfiguration` tests (#5554) (Thanks @iSazonov!)
- Update test framework to support Pester v4 (#6064)
- Update tests to use Pester v4 Syntax. (#6294, #6257, #6306, #6304, #6298)
- Add negative tests for `Copy-Item` over remote sessions (#6231)
- Markdown test: Use strict in JavaScript (#6328)
- Add tests for `Get-Process` about the `-Module` and `-FileVersion` parameters (#6272)
- Add test for the `OsLocalDateTime` property of `Get-ComputerInfo`. (#6253)
- Change `Get-FileHash` tests to use raw bytes (#6430)
- Remove `runas.exe` from tests as we have tags to control this behavior (#6432)
- Refactor the `Get-Content` tests to use `-TestCases`. (#6082)
- Use `RequireAdminOnWindows` tag in `Set-Date` tests (#6034) (Thanks @stknohg!)
- Remove `-TimeOutSec` from non timeout related tests (#6055) (Thanks @markekraus!)
- Add verbosity and more accurate timeout implementation for `Start-WebListener` (#6013) (Thanks @markekraus!)
- Skip tests that use `ExecutionPolicy` cmdlets on Unix (#6021)
- Change Web Cmdlet tests to use `127.0.0.1` instead of `Localhost` (#6069) (Thanks @markekraus!)
- Fix `Start-PSPester` to include or exclude `RequireSudoOnUnix` tag smartly on Unix (#6241)
- Fix the terse output on Windows for test runs without admin privilege (#6252)
- Add `RequireSudoOnUnix` tag for `Get-Help` tests. (#6223)
- Add tests for `*-Item` Cmdlets in function provider (#6172)
- Support running tests in root privilege on Linux. (#6145)

### Build and Packaging Improvements

- Add option to add explorer shell context menu in Windows installer (#5774) (Thanks @bergmeister!)
- Make the explorer shell context menu registry entries platform specific to allow side by side of `x86` and `x64`. (#5824) (Thanks @bergmeister!)
- Fix start menu folder clash of shortcut when `x86` and `x64` are both installed by appending ` (x86)` for `x86` installation. (#5826) (Thanks @bergmeister!)
- Reduce image file sizes using lossless compression with `imgbot` (#5808) (Thanks @bergmeister!)
- Windows installer: Allow `Launch PowerShell` checkbox to be toggled using the space bar. (#5792) (Thanks @bergmeister!)
- Fix release packaging build (#6459)
- Fail `AppVeyor` Build if `MSI` does not build (#5755) (Thanks @bergmeister!)
- Cleanup temporarily created `WiX` files after compilation to be able to have a clean re-build (#5757) (Thanks @bergmeister!)
- Fix `install-powershell.ps1` for running during window setup (#5727)
- Start using `Travis-CI` cache (#6003)
- Fix build, packaging and installation scripts for `SLES` (#5918) (Thanks @tomconte!)
- Update recommended `WiX` toolset link to be generic to `WiX 3.x` but mention that latest version of 3.11 has to be taken (#5926) (Thanks @bergmeister!)
- Add service point manager call in `Install-PowerShell.ps1` to force `TLS1.2`. (#6310) (Thanks @DarqueWarrior!)
- Add `-Restore` when build `win-arm` and `win-arm64` (#6353)
- Make sure package verification failure fails the `AppVeyor` build (#6337)
- Specify the runtime when running `dotnet restore` in `Start-PSBuild` (#6345)
- Rename `log` and `logerror` to `Write-Log [$message] [-error]` (#6333)
- Make Linux packages use correct version scheme for preview releases (#6318)
- Add support for Debian in `installpsh-debian.sh` (#6314) (Thanks @Pawamoy!)
- MSI: Make preview builds to install Side by side with release builds (#6301)
- Add `TLS1.2` workaround for code coverage script (#6299)
- Cleanup after Powershell install for `CentOS` and `Fedora` Docker images (#6264) (Thanks @strawgate!)
- MSI: Update the environment variable PATH with proper value (#6441)
- MSI: Remove the version from the product name (#6415)
- Support non-GitHub commits in the change log generation script (#6389)
- Fix secret and JavaScript compliance issues (#6408)
- Remove `AppVeyor` specific cmdlet from `Start-NativeExecution` (#6263)
- Restore modules from the `NuGet` package cache by using `dotnet restore` (#6111)
- CI Build: Use `TRAVIS_PULL_REQUEST_SHA` to accurately get the commit message (#6024)
- Use `TLS1.2` on Windows during `Start-PSBootstrap` (#6235) (Thanks @CallmeJoeBob!)
- Use `TLS1.2` in `Start-PSBootStrap` without breaking `HTTPS` (#6236) (Thanks @markekraus!)
- Add options to enable `PSRemoting` and register Windows Event Logging Manifest to MSI installer (#5999) (Thanks @bergmeister!)

### Documentation and Help Content

- Separate macOS from Linux install instructions. (#5823) (Thanks @thezim!)
- Show usage (short) help if command line parameter is wrong (#5780) (Thanks @iSazonov!)
- Add the breaking changes doc for 6.0.0 release. (#5620) (Thanks @maertendMSFT!)
- Remove DockerFile for Fedora 25 and add DockerFile for Fedora 27 (#5984) (Thanks @seemethere!)
- Add a missing step to prepare the build environment on Mac. (#5901) (Thanks @zackJKnight!)
- Update `BREAKINGCHANGES.md` to include WebCmdlets breaking changes (#5852) (Thanks @markekraus!)
- Fix typos in `BREAKINGCHANGES.md` (#5913) (Thanks @brianbunke!)
- Update `macos.md` to use `brew cask upgrade` for upgrading powershell (#5875) (Thanks @timothywlewis!)
- Add verification step to macOS install docs (#5860) (Thanks @rpalo!)
- Fix links in macOS install docs (#5861) (Thanks @kanjibates!)
- Update docs with test guidelines with the `RequireSudoOnUnix` tag. (#6274)
- Add `Alpine` Linux support (#6367) (Thanks @kasper3!)
- Update to Governance doc to reflect current working model (#6323)
- Add guidance on adding copyright and license header to new source files (#6140)
- Fix the command to build type catalog in `internals.md` (#6084) (Thanks @ppadmavilasom!)
- Fix `Pull Request Process` dead link (#6066) (Thanks @IISResetMe!)
- Update processes to allow for coordinated vulnerability disclosure (#6042)
- Rework Windows Start menu folder name (#5891) (Thanks @Stanzilla!)
- Update `Raspbian` installation instructions to create `symlink` for `pwsh` (#6122)
- Fix various places that still refer to old versions of `pwsh` (#6179) (Thanks @bergmeister!)
- Correct a Linux installation typo (#6219) (Thanks @mababio!)
- Change synopsis of `install-powershell.ps1` to reflect that it works cross-platform (#5465) (Thanks @bergmeister!)

## v6.0.2 - 2018-03-15

### Engine updates and fixes

- Update PowerShell to use `2.0.6` dotnet core runtime and packages (#6403)
    - This change addresses this vulnerability: [Microsoft Security Advisory `CVE-2018-0875`: Hash Collision can cause Denial of Service](https://github.com/PowerShell/Announcements/issues/4)

### Build and Packaging Improvements

- Add Ubuntu build without `AppImage` (#6380)
- Add scripts to set and or update the release tag in `VSTS` (#6107)
- Fix `DSC` Configuration compilation (#6225)
- Fix errors in `Start-PSBootStrap` during release builds (#6159)
- Fix spelling failures in `CI` (#6191)
- Use PowerShell `windowsservercore` Docker image for release builds (#6226)
- Use `ADD` instead of `Invoke-WebRequest` in `nanoserver` Docker file (#6255)
- When doing daily/test build in a non-release branch use the branch name as the preview name (#6355)
- Add Environment Variable override of telemetry (#6063) (Thanks @diddledan!)
- Build: Remove two unneeded lines from `Invoke-AppveyorFinish` (#6344)
- MSI: Refactor `New-MsiPackage` into `packaging.psm1`
  and various fixes to enable patching
  (#5871, #6221, #6254, #6303, #6356, #6208, #6334, #6379, #6094, #6192)
- MSI: Use `HKLM` instead of `HKCU` registry keys since the current installation scope is per-machine. (#5915) (Thanks @bergmeister!)

## v6.0.1 - 2018-01-25

### Engine updates and fixes

- Update PowerShell to use `2.0.5` dotnet core runtime and packages. (#5903, #5961) (Thanks @iSazonov!)

### Build and Packaging Improvements

- Re-release of `v6.0.0` as `v6.0.1` due to issues upgrading from pre-release versions

### Test

- Update regular expression to validate `GitCommitId` in `$PSVersionTable` to not require a pre-release tag (#5893)

## v6.0.0 - 2018-01-10

### Breaking changes

- Remove `sc` alias which conflicts with `sc.exe` (#5827)
- Separate group policy settings and enable policy controlled logging in PowerShell Core (#5791)

### Engine updates and fixes

- Handle `DLLImport` failure of `libpsrpclient` in PowerShell Remoting on Unix platforms (#5622)

### Test

- Replace `lee.io` Tests with `WebListener` (#5709) (Thanks @markekraus!)
- Update the docker based release package tests due to the removal of `Pester` module and other issues (#5692)
- Replace Remaining `HttpBin.org` Tests with `WebListener` (#5665) (Thanks @markekraus!)

### Build and Packaging Improvements

- Update x86 and x64 `MSI` packages to not overwrite each other (#5812) (Thanks @bergmeister!)
- Update `Restore-PSPester` to include the fix for nested describe errors (#5771)
- Automate the generation of release change log draft (#5712)

### Documentation and Help Content

- Updated help Uri to point to latest help content for `Microsoft.PowerShell.Core` module (#5820)
- Update the installation doc for `Raspberry-Pi` about supported devices (#5773)
- Fix a typo and a Markdown linting error in the Pull Request Template (#5807) (Thanks @markekraus!)
- Update submodule documentation for pester removal (#5786) (Thanks @bergmeister!)
- Change `Github` to `GitHub` in `CONTRIBUTING.md` (#5697) (Thanks @stuntguy3000!)
- Fix incorrect release date on the changelog (#5698) (Thanks @SwarfegaGit!)
- Add instructions to deploy `win-arm` build on Windows IoT (#5682)

## v6.0.0-rc.2 - 2017-12-14

### Breaking changes

- Skip null-element check for collections with a value-type element type (#5432)
- Make `AllSigned` execution policy require modules under `$PSHome` to be signed (#5511)

### Engine updates and fixes

- Update PowerShell to use `2.0.4` dotnet core runtime. (#5677)
- Remove references to the old executable `powershell` or `powershell.exe` (#5408)

### General cmdlet updates and fixes

- Remove unnecessary check for `Paths.count > 0`, in the `*-FileCatalog` CmdLets (#5596)
- Use explicit `libpsl-native` binary name for `dllimport`. (#5580)

### Build and Packaging Improvements

- Fix `Get-EnvironmentInformation` to properly check for CoreCLR (#5592) (Thanks @markekraus!)
- Make Travis CI use `libcurl+openssl+gssapi` (#5629) (Thanks @markekraus!)
- Disambiguate icon for daily builds on Windows (#5467) (Thanks @bergmeister!)
- Fix `Import-CliXml` tests which still use `powershell` instead of `pwsh` and make sure it fails if it regresses (#5521) (Thanks @markekraus!)
- Update port number used for WebCmdlets tests which broke due to a change in AppVeyor (#5520) (Thanks @markekraus!)
- Clean up use of `Runspaceconfiguration` from comments and xUnit test code (#5569) (Thanks @Bhaal22!)
- Replace `HttpListener` Response Tests with WebListener (#5540, #5605) (Thanks @markekraus!)
- Fix the path to `powershell_xxx.inc` in Start-Build (#5538) (Thanks @iSazonov!)
- Remove Pester as a module include with the PowerShell Packages.
  You should be able to add it by running `Install-Module Pester`. (#5623, #5631)
- Refactor `New-UnixPackaging` into functions to make the large function more readable. (#5625)
- Make the experience better when `Start-PSPester` doesn't find Pester (#5673)
- Update packaging and release build scripts to produce zip packages for `win-arm` and `win-arm64` (#5664)
- Enable `Install-Debian` to work with VSTS Hosted Linux Preview (#5659)
- Add `linux-arm` tarball package to release build (#5652, #5660)
- Enable building for `win-arm` and `win-arm64` (#5524)
- Make macOS package require 10.12 or newer (#5649, #5654)
- Update signing subjects to something meaningful (#5650)
- Make `New-UnixPackage` more readable (#5625)
- Update `PowerShellGet` tests to validate the new install location of `AllUsers` scope. (#5633)
- Increase reliability of flaky test that fails intermittently in CI (#5641)
- Exclude markdown files from `Pester` folder from the Markdown meta test (#5636)
- Run tests for Windows installer only on Windows (#5619)
- Suppress the expected errors from `Select-Xml` tests (#5591)
- Add retry logic to prerequisite URL and output URL on failure so you can more easily troubleshoot (#5601, #5570)
- Make sure submodule are initialized when running Mac release build (#5496)
- Remove duplicate files in Windows packages in a folder called `signed` (#5527)
- Add PowerShell VSCode style settings (#5529) (Thanks @bergmeister)
- Add Travis CI matrix for improved job tagging (#5547)
- Remove community docker files from official docker image validation (#5508)

### Documentation and Help Content

- XML documentation fix for `CompletionResult` (#5550) (Thanks @bergmeister!)
- Change synopsis of `install-powershell.ps1` to reflect that it works cross-platform (#5465) (Thanks @bergmeister!)
- Add more helpful message for `AmbiguousParameterSet` exception (#5537) (Thanks @kvprasoon!)
- Update the contribution guideline to note that updating the changelog is required. (#5586)
- Updated doc to build arm/arm64 versions of `psrp.windows` and `PowerShell.Core.Instrumentation.dll` libraries (#5668)
- Update Contribution guidelines with work in progress guidance (#5655)
- Update code coverage tests to get GitCommitId using the ProductVersion from Assembly (#5651)
- Remove requirement to updating changelog update in PR (#5644, #5586)
- Minor refactoring of the release build scripts (#5632)
- Update PowerShell executable name in `using-vscode.md` (#5593)
- Fix xUnit test for PS (#4780)
- Update install link and instructions for R-Pi (#5495)

### Compliance Work

[Compliance](https://github.com/PowerShell/PowerShell/blob/master/docs/maintainers/issue-management.md#miscellaneous-labels)
work is required for Microsoft to continue to sign and release packages from the project as official Microsoft packages.

- Remove `PerformWSManPluginReportCompletion`, which was not used, from `pwrshplugin.dll` (#5498) (Thanks @bergmeister!)
- Remove exclusion for hang and add context exception for remaining instances (#5595)
- Replace `strlen` with `strnlen` in native code (#5510)

## v6.0.0-rc - 2017-11-16

### Breaking changes

- Fix `-Verbose` to not override `$ErrorActionPreference`. (#5113)
- Fix `Get-Item -LiteralPath a*b` to return error if `a*b` doesn't actually exist. (#5197)
- Remove `AllScope` from most default aliases to reduce overhead on creating new scopes. (#5268)
- Change `$OutputEncoding` default to be `UTF8` without `BOM` rather than `ASCII`. (#5369)
- Add error on legacy credential over non-HTTPS for Web Cmdlets. (#5402) (Thanks @markekraus!)
- Fix single value JSON `null` in `Invoke-RestMethod`. (#5338) (Thanks @markekraus!)
- Add `PSTypeName` Support for `Import-Csv` and `ConvertFrom-Csv`. (#5389) (Thanks @markekraus!)

### Engine updates and fixes

- Add char range overload to the `..` operator, so `'a'..'z'` returns characters from 'a' to 'z'. (#5026) (Thanks @IISResetMe!)
- Remove `CommandFactory` because it serves no real purpose. (#5266)
- Change to not insert line breaks at console window width to output (except for tables). (#5193)
- Use `Ast` for context in parameter binding and fix to glob the native command argument only when it's not quoted. (#5188)
- Fix dynamic class assembly name. (#5292)
- Update PowerShell to use `2.0.4-servicing` dotnet core runtime. (#5295)
- Fix `ExecutionContext.LoadAssembly` to load with name when file cannot be found. (#5161)
- Speed up the check for suspicious content in script texts. (#5302)
- Use native `os_log` APIs on macOS for PowerShell Core logging. (#5310)
- Redirect `ETW` logging to `Syslog` on Linux. (#5144)
- Improve how we pass the array literal to native commands. (#5301)
- Make `SemanticVersion` compatible with `SemVer 2.0`. (#5037) (Thanks @iSazonov!)
- Revert refactoring changes that broke remoting to Windows PowerShell 5.1. (#5321)
- Port some fixes in `Job` for an issue that causes PowerShell to not respond. (#5258)
- Multiple improvements by `CodeRush` static analysis. (#5132) (Thanks @Himura2la!)
- Fix the Runspace cleanup issue that causes PowerShell to not respond on exit. (#5356)
- Update PowerShell to depend on new version of `psrp` and `libmi` nuget packages on Unix platforms. (#5469)

### General cmdlet updates and fixes

- Add `-AsHashtable` to `ConvertFrom-Json` to return a `Hashtable` instead. (#5043) (Thanks @bergmeister!)
- Fix `Import-module` to not report a loaded module was not found. (#5238)
- Fix performance issues in `Add-Type`. (#5243) (Thanks @iSazonov!)
- Fix `PSUserAgent` generation for Web Cmdlets on Windows 7. (#5256) (Thanks @markekraus!)
- Remove `DCOM` support from `*-Computer` cmdlets. (#5277)
- Add multiple link header support to Web Cmdlets. (#5265) (Thanks @markekraus!)
- Use wider columns for process id and user. (#5303)
- Add `Remove-Alias` Command. (#5143) (Thanks @PowershellNinja!)
- Update `installpsh-suse.sh` to work with the `tar.gz` package. (#5309)
- Add `Jobject` serialization support to `ConvertTo-Json`. (#5141)
- Display full help with 'help' function. (#5195) (Thanks @rkeithhill!)
- Fix `help` function to not pipe to `more` if objects are returned instead of help text. (#5395)
- Fix `Unblock-File` to not write an error if the file is already unblocked. (#5362) (Thanks @iSazonov!)
- Clean up FullCLR code from Web Cmdlets. (#5376) (Thanks @markekraus!)
- Exclude cmdlets that are not supported on Unix platforms. (#5083)
- Make `Import-Csv` support `CR`, `LF` and `CRLF` as line delimiters. (#5363) (Thanks @iSazonov!)
- Fix spelling in Web Cmdlet errors. (#5427) (Thanks @markekraus!)
- Add `SslProtocol` support to Web Cmdlets. (#5329) (Thanks @markekraus!)

### Build and Packaging Improvements

- Use `RCEdit` to embed icon and version information into `pwsh.exe`. (#5178)
- Update Docker file for Nano Server 1709 release. (#5252)
- Change VSCode build task to use `pwsh`. (#5255)
- Refactor building and packaging scripts for signing in release build workflow. (#5300)
- Always build with `-CrossGen` in CI to verify a fix in `CrossGen` tool. (#5315)
- Separate `Install-PowerShellRemoting.ps1` from `psrp.windows` nuget package. (#5330)
- Include symbols folder an embedded zip when packaging symbols. (#5333)
- Add Uniform Type Identifier conforming with Apple standards using a reverse DNS style prefix. (#5323)
- Update `Wix` toolset download link to newer version 3.11 (#5339) (Thanks @bergmeister!)
- Re-enable macOS launcher after fixing an issue that blocked macOS package generation. (#5291) (Thanks @thezim!)
- Set expected binaries and variable name for folder for symbols build. (#5357)
- Rename and update PowerShell `ETW` manifest to remove the Windows PowerShell dependency. (#5360)
- Add ability to produce `tar.gz` package for Raspbian. (#5387)
- Update `Find-Dotnet` to find dotnet with the compatible SDK. (#5341) (Thanks @rkeithhill!)
- Add signing manifest and script to update it with production values. (#5397)
- Add `install-powershell.ps1` to install PowerShell Core on windows. (#5383)
- Make `-Name` a dynamic parameter in `Start-PSPackage`. (#5415)
- Support `[package]` tag in PR CI and fix nightly build on macOS. (#5410)
- Enhance `install-powershell.ps1` to work on Linux and macOS. (#5411)
- Move the `RCEdit` step to the build phase rather than the packaging phase. (#5404)
- Allow packaging from a zip package to allow for signing. (#5418)
- Add automation to validate PowerShell Core packages using Docker containers. (#5401)
- Fix the `brew update` issue in bootstrap script. (#5400)
- Enable `install-powershell.ps1` to update the current running PowerShell Core. (#5429)
- Add standard set of VSCode workspace setting files. (#5457) (Thanks @rkeithhill!)
- Add support for installing PowerShell Core on Amazon Linux via `install-powershell.sh`. (#5461) (Thanks @DarwinJS!)
- Get `PowerShellGet` and `PackageManagement` from the PowerShell Gallery. (#5452)
- Fix `Start-PSBuild` on `WSL` if repository was already built on Windows. (#5346) (Thanks @bergmeister!)
- Fix build in VSCode and use an improved version of `tasks.json` from @rkeithhill. (#5453)
- Add scripts for signing packages in the release build workflow. (#5463)

### Documentation and Help Content

- Fix the codebase to use the consistent copyright string. (#5210)
- Add documentation about how to create `libpsl` and `psrp.windows` nuget packages. (#5278)
- Add help strings in PowerShell banner. (#5275) (Thanks @iSazonov!)
- Change all links in `README.md` to absolute as they are being used in other places outside of GitHub. (#5354)
- Update instructions to build on VSCode based on `pwsh`. (#5368)
- Update `FAQ.md` about how to use PowerShell Core nuget packages. (#5366)
- Correct the Fedora documentation (#5384) (Thanks @offthewoll!)
- Add instructions about how to create the `PowerShell.Core.Instrumentation` nuget package. (#5396)
- Updated PowerShell to use the latest help package. (#5454)

### Compliance Work

[Compliance](https://github.com/PowerShell/PowerShell/blob/master/docs/maintainers/issue-management.md#miscellaneous-labels)
work is required for Microsoft to continue to sign and release packages from the project as official Microsoft packages.

- Replace the word `hang` with something more appropriate and add rules about other terms. (#5213, #5297, #5358)
- Use simplified names for compliance folders (#5388)
- Add compliance label description (#5355)
- Set `requestedExecutionLevel` to `asInvoker` for `pwsh.exe` on Windows. (#5285)
- Add `HighEntropyVA` to building pwsh. (#5455)

## v6.0.0-beta.9 - 2017-10-24

### Breaking changes

- Fix `ValueFromRemainingArguments` to have consistent behavior between script and C# cmdlets. (#2038) (Thanks @dlwyatt)
- Remove parameters `-importsystemmodules` and `-psconsoleFile` from `powershell.exe`. (#4995)
- Removed code to show a GUI prompt for credentials as PowerShell Core prompts in console. (#4995)
- Remove `-ComputerName` from `Get/Set/Remove-Service`. (#5094)
- Rename the executable name from `powershell` to `pwsh`. (#5101)
- Remove `RunspaceConfiguration` support. (#4942)
- Remove `-ComputerName` support since .NET Core `Process.GetProcesses(computer)` returns local processes. (#4960)
- Make `-NoTypeInformation` the default on `Export-Csv` and `ConvertTo-Csv`. (#5164) (Thanks @markekraus)
- Unify cmdlets with parameter `-Encoding` to be of type `System.Text.Encoding`. (#5080)

### Engine updates and fixes

- Fix PowerShell to update the `PATH` environment variable only if `PATH` exists. (#5021)
- Enable support of folders and files with colon in name on Unix. (#4959)
- Fix detection of whether `-LiteralPath` was used to suppress wildcard expansion for navigation cmdlets. (#5038)
- Enable using filesystem from a UNC location. (#4998)
- Escape trailing backslash when dealing with native command arguments. (#4965)
- Change location of `ModuleAnalysisCache` so it isn't shared with Windows PowerShell. (#5133)
- Put command discovery before scripts for Unix. (#5116)

### General cmdlet updates and fixes

- Correct comma position in `SecureStringCommands.resx`. (#5033) (Thanks @markekraus)
- User Agent of Web Cmdlets now reports the OS platform (#4937) (Thanks @LDSpits)
- Add the positional parameter attribute to `-InputObject` for `Set-Service`. (#5017) (Thanks @travisty-)
- Add `ValidateNotNullOrEmpty` attribute to `-UFormat` for `Get-Date`. (#5055) (Thanks @DdWr)
- Add `-NoNewLine` switch for `Out-String`. (#5056) (Thanks @raghav710)
- Improve progress messages written by Web Cmdlets. (#5078) (Thanks @markekraus)
- Add verb descriptions and alias prefixes for `Get-Verb`. (#4746) (Thanks @Tadas)
- Fix `Get-Content -Raw` to not miss the last line feed character. (#5076)
- Add authentication parameters to Web Cmdlets. (#5052) (Thanks @markekraus)
    - Add `-Authentication` that provides three options: Basic, OAuth, and Bearer.
    - Add `-Token` to get the bearer token for OAuth and Bearer options.
    - Add `-AllowUnencryptedAuthentication` to bypass authentication that is provided for any transport scheme other than HTTPS.
- Fix `MatchInfoContext` clone implementation (#5121) (Thanks @dee-see)
- Exclude `PSHostProcess` cmdlets from Unix platforms. (#5105)
- Fix `Add-Member` to fetch resource string correctly. (#5114)
- Enable `Import-Module` to be case insensitive. (#5097)
- Add exports for `syslog` APIs in `libpsl-native`. (#5149)
- Fix `Get-ChildItem` to not ignore `-Depth` parameter when using with `-Include` or `-Exclude`. (#4985) (Thanks @Windos)
- Added properties `UserName`, `Description`, `DelayedAutoStart`, `BinaryPathName` and `StartupType` to the `ServiceController` objects returned by `Get-Service`. (#4907) (Thanks @joandrsn)

### Build and Packaging Improvements

- Treat `.rtf` files as binary so EOL don't get changed. (#5020)
- Improve the output of `tools/installpsh-osx.sh` and update Travis-CI to use Ruby 2.3.3. (#5065)
- Improve `Start-PSBootstrap` to locate dotnet SDK before installing it. (#5059) (Thanks @PetSerAl)
- Fix the prerequisite check of the MSI package. (#5070)
- Support creating `tar.gz` package for Linux and macOS. (#5085)
- Add release builds that produce symbols for compliance scans. (#5086)
- Update existing Docker files for the Linux package changes. (#5102)
- Add compiler switches and replace dangerous function with safer ones. (#5089)
- Add macOS launcher. (#5138) (Thanks @thezim)
- Replace `httpbin.org/response-headers` Tests with WebListener. (#5058) (Thanks @markekraus)
- Update `appimage.sh` to reflect the new name `pwsh`. (#5172)
- Update the man help file used in packaging. (#5173)
- Update to use `pwsh` in macOS launcher. (#5174) (Thanks @thezim)
- Add code to send web hook for Travis-CI daily build. (#5183)
- Add `global.json` to pick correct SDK version. (#5118) (Thanks @rkeithhill)
- Update packaging to only package PowerShell binaries when packaging symbols. (#5145)
- Update Docker files and related due to the name change. (#5156)

### Code Cleanup

- Clean up Json cmdlets. (#5001) (Thanks @iSazonov)
- Remove code guarded by `RELATIONSHIP_SUPPORTED` and `SUPPORTS_IMULTIVALUEPROPERTYCMDLETPROVIDER`, which has never been used. (#5066)
- Remove PSMI code that has never been used. (#5075)
- Remove unreachable code for `Stop-Job`. (#5091) (Thanks @travisty-)
- Removed font and codepage handling code that is only applicable to Windows PowerShell. (#4995)

### Test

- Fix a race condition between `WebListener` and Web Cmdlets tests. (#5035) (Thanks @markekraus)
- Add warning to `Start-PSPester` if Pester module is not found (#5069) (Thanks @DdWr)
- Add tests for DSC configuration compilation on Windows. (#5011)
- Test fixes and code coverage automation fixes. (#5046)

### Documentation and Help Content

- Update Pi demo instructions about installing libunwind8. (#4974)
- Add links on best practice guidelines in coding guideline. (#4983) (Thanks @iSazonov)
- Reformat command line help for `powershell -help` (#4989) (Thanks @iSazonov)
- Change logo in readme to current black icon. (#5030)
- Fix RPM package name in `README.md`. (#5044)
- Update `docs/building/linux.md` to reflect the current status of powershell build. (#5068) (Thanks @dee-see)
- Add black version of `.icns` file for macOS. (#5073) (Thanks @thezim)
- Update Arch Linux installation instructions. (#5048) (Thanks @kylesferrazza)
- Add submodule reminder to `testing-guidelines.md`. (#5061) (Thanks @DdWr)
- Update instructions in `docs/building/internals.md` for building from source. (#5072) (Thanks @kylesferrazza)
- Add UserVoice link to Issue Template. (#5100) (Thanks @markekraus)
- Add `Get-WebListenerUrl` Based Examples to WebListener `README.md`. (#4981) (Thanks @markekraus)
- Add document about how to create cmdlet with dotnet CLI. (#5117) (Thanks @rkeithhill)
- Update the help text for PowerShell executable with the new name `pwsh`. (#5182)
- Add new forward links for PowerShell 6.0.0 help content. (#4978)
- Fix VSCode `launch.json` to point to `pwsh`. (#5189)
- Add example of how to create .NET Core cmdlet with Visual Studio. (#5096)

## v6.0.0-beta.8 - 2017-10-05

### Breaking changes

* Changed `New-Service` to return error when given unsupported `-StartupType` and fixed `Set-Service` icon failing test. (#4802)
* Allow `*` to be used in registry path for `Remove-Item`. (#4866)
* Remove unsupported `-ShowWindow` switch from `Get-Help`. (#4903)
* Fix incorrect position of a parameter which resulted in the args passed as input instead of as args for `InvokeScript()`. (#4963)

### Engine updates and fixes

* Make calls to `void CodeMethod` work. (#4850) (Thanks @powercode)
* Get `PSVersion` and `GitCommitId` from the `ProductVersion` attribute of assembly (#4863) (Thanks @iSazonov)
* Fix `powershell -version` and built-in help for `powershell.exe` to align with other native tools. (#4958 & #4931) (Thanks @iSazonov)
* Load assemblies with `Assembly.LoadFrom` before `Assembly.Load` when the file path is given. (#4196)
* Add a generic file watcher function in `HelpersCommon.psm1`. (#4775)
* Update old links and fix broken links in `docs/host-powershell/README.md`. (#4877)
* Fix when importing remote modules using version filters (and added tests). (#4900)
* Enable transcription of native commands on non-Windows platforms. (#4871)
* Add a new line to `CommandNotFoundException` error string. (#4934 & #4991)
* Fix bug where PowerShell would exit with an error within an SSH remoting connection on Linux. (#4993)
* Fix issues with expression redirected to file. (#4847)

### General cmdlet updates and fixes

* Added `Remove-Service` to Management module. (#4858) (Thanks @joandrsn)
* Added functionality to set credentials on `Set-Service` command. (#4844) (Thanks @joandrsn)
* Fix `Select-String` to exclude directories (as opposed to individual files) discovered from `-Path`. (#4829) (Thanks @iSazonov)
* `Get-Date` now supports more argument completion scenarios by adding `ArgumentCompletionsAttribute`. (#4835) (Thanks @iSazonov)
* Exclude `-ComObject` parameter of `New-Object` on unsupported (currently non-Windows) platforms. (#4922) (Thanks @iSazonov)
* Updated default `ModuleVersion` in `New-ModuleManifest` to `0.0.1` to align with SemVer. (#4842) (Thanks @LDSpits)
* Add Multipart support to web cmdlets. (#4782) (Thanks @markekraus)
* Add `-ResponseHeadersVariable` to `Invoke-RestMethod` to enable the capture of response headers. (#4888) (Thanks @markekraus)
* Initialize web cmdlets headers dictionary only once. (#4853) (Thanks @markekraus)
* Change web cmdlets `UserAgent` from `WindowsPowerShell` to `PowerShell`. (#4914) (Thanks @markekraus)

### Build and Packaging Improvements

* Make the build output the WiX compilation log if it failed. (#4831) (Thanks @bergmeister)
* Use a simple file based check in the MSI for the VC++ 2015 redistributables. (#4745) (Thanks @bergmeister)
* New icon for PowerShell Core. (#4848)
* Build Powershell Core using the generic RID `linux-x64`. (#4841)
* Create generic Linux-x64 packages that are portable to all supported RPM Linux distros (and more similar for Debian based distros). (#4902 & #4994)
* Suppress the output of building test tools in `Compress-TestContent`. (#4957)
* Remove unnecessary error messages from output. (#4954)
* Update Travis CI script so that PRs can fail due to Pester tests. (#4830)
* Move release build definition into PowerShell. (#4884)
* Fix credential scan issues. (#4927 & #4935)
* Enable security flags in native compiler. (#4933)
* Add VS 2017 solution file for `powershell-win-core`. (#4748)

### Code Cleanup

* Remove remainder of `Utility.Activities` (Workflow code). (#4880)
* Remove `Microsoft.PowerShell.CoreCLR.AssemblyLoadContext.dll`. (#4868)
* Enable auto EOL on Git repo side, fix some character encoding issues. (#4912)
* Updated EOL for all files to be LF in the repository. (#4943 & #4956)
* Removed leading whitespace. (#4991)

### DSC Language

* Update version of `PSDesiredStateConfiguration` in project files to fix complication of MOF files with the `Configuration` keyword. (#4979)

### Test

* Replace httpbin.org tests with `WebListener`. (Thanks @markekraus)
    * headers (#4799)
    * user-agent (#4798)
    * redirect (#4852)
    * encoding (#4869)
    * delay (#4905)
    * gzip & enable deflate (#4948)
    * related changes and fixes (#4920)
* Port tests for constrained language mode. (#4816)
* Enable `Select-String` test from a network path. (#4921) (Thanks @iSazonov)
* Reformat `Measure-Object` test. (#4972) (Thanks @iSazonov)
* Mitigate intermittent failures in access denied tests. (#4788)
* Fix tests that incorrectly use `ShouldBeErrorId`. (#4793)
* Fix a test issue that causes tests to be skipped in Travis CI run (#4891)
* Skip web cmdlet certificate authentication tests on CentOS and Mac. (#4822)
* Validate product resource strings against resx files. (#4811 & #4861)
* Add source files for coverage run. (#4925)
* Add the UTC offset correctly in tests for CDXML cmdlets. (#4867)
* Be sure to change `PSDefaultParameterValue` in the global scope. (#4977 & #4892)
* Reduce output of Pester for CI. (#4855)
* Add tests for
    * `Get-Content` (#4723) (Thanks @sarithsutha)
    * Remoting and Jobs (#4928)
    * `Get-Help` (#4895)
    * `Get-Command -ShowCommandInfo` (#4906)
    * `Get-Content -Tail` (#4790)
    * `Get-Module` over remoting (#4787)
    * `Start/Stop/Suspend/Resume/Restart-Service` cmdlets (#4774)
    * WSMan Config provider tests (#4756)
    * CDXML CIM `DateTime` test (#4796)

### Documentation and Graphics

* Sort `.spelling` (Thanks @markekraus)
* Improve the guideline for performance consideration. (#4824)
* Add setup steps for MacOS to use PSRP over SSH. (#4872)
* Instructions to demo PowerShell Core on Raspbian. (#4882)
* Added instructions to get permission to use PowerShell image assets. (#4938)
* Added demo for using Windows PowerShell modules. (#4886)

## v6.0.0-beta.7 - 2017-09-13

### Breaking change

* Fix `Get-Content -Delimiter` to not include the delimiter in the array elements returned (#3706) (Thanks @mklement0)
* Rename `$IsOSX` to `$IsMacOS` (#4757)

### Engine updates and fixes

* Use stricter rules when unwrapping a PSObject that wraps a COM object (#4614)
* Remove appended Windows PowerShell `PSModulePath` on Windows. (#4656)
* Ensure `GetNetworkCredential()` returns null if PSCredential has null or empty user name (#4697)
* Push locals of automatic variables to 'DottedScopes' when dotting script cmdlets (#4709)
* Fix `using module` when module has non-terminating errors handled with `SilentlyContinue` (#4711) (Thanks @iSazonov)
* Enable use of 'Singleline,Multiline' option in split operator (#4721) (Thanks @iSazonov)
* Fix error message in `ValidateSetAttribute.ValidateElement()` (#4722) (Thanks @iSazonov)

### General cmdlet updates and fixes

* Add Meta, Charset, and Transitional parameters to `ConvertTo-HTML` (#4184) (Thanks @ergo3114)
* Prevent `Test-ModuleManifest` from loading unnecessary modules (#4541)
* Remove AlternateStream code and `-Stream` from provider cmdlets on non-Windows (#4567)
* Add explicit ContentType detection to `Invoke-RestMethod` (#4692)
* Fix an error on `Enter-PSSession` exit (#4693)
* Add `-WhatIf` switch to `Start-Process` cmdlet (#4735) (Thanks @sarithsutha)
* Remove double spaces in .cs, .ps1, and .resx files (#4741 & #4743) (Thanks @korygill)
* Replace 'Windows PowerShell' with 'PowerShell' in resx files (#4758) (Thanks @iSazonov)

### Build and Packaging Improvements

* Refactor MSBuild project files to get PowerShell version from git tag (#4182) (Thanks @iSazonov)
* Create a single package for each Windows supported architecture (x86 and amd64) (#4540)
* Set the default windows RID to win7-<arch> (#4701)
* Enable cross-compiling for Raspberry-PI arm32 (#4742)
* Fix macOS brew reinstall command (#4627) (Thanks @TheNewStellW)
* Improvements to the Travis-CI script (#4689, #4731, #4807)
* Update OpenSUSE docker image to 42.2 (#4737)
* Confirm `Start-PSPackage` produces a package (#4795)

### Code Cleanup

* Remove Workflow code (#4777)
* Clean up CORECLR preprocessor directives in TraceSource (#4684)

### Test

* Add test WebListener module and tests for Web Cmdlet Certificate Authentication (#4622) (Thanks @markekraus)
* Move WebCmdlets HTTPS tests to WebListener (#4733) (Thanks @markekraus)
* Replace httpbin.org/get tests With WebListener (#4738) (Thanks @markekraus)
* Use `-PassThru` on Pester tests to reliably catch failures (#4644)
* Display the same number of tests regardless of platform (#4728)
* Improve comparison of code coverage values for a file (#4764)
* Silence PSSessionConfiguration test warning messages in the log (#4794)
* Add tests for
    * `Get-Service` (#4773)
    * `Set-Service` and `New-Service` (#4785)
    * `Trace-Command` (#4288)
    * `StaticParameter` (#4779)
    * `Test-Wsman` (#4771)
    * `New-Object -ComObject` (#4776)
    * ProxyCommand APIs (#4791)
* Disable tests
    * 'VC++ Redistributable'(#4673 & #4729)
    * "Test 01. Standard Property test - all properties (<property>)" due to missing CsPhysicallyInstalledMemory (#4763)
    * `New-Service` failing test (#4806)

### Documentation

* Update WritingPesterTests.md to recommend ShouldBeErrorId (#4637)
* Clarify the Pull Request process, roles, and responsibilities (#4710)
* Add absolute URLs in the issue template and pull request template (#4718) (Thanks @chucklu)
* Add new approved Build and Deploy verbs (#4725)
* Update using-vscode.md to use the new exe path (#4736)
* Update coding guidelines to make it more concrete and useful in a review process (#4754)

## v6.0.0-beta.6 - 2017-08-24

### Breaking change

* Make invalid argument error messages for `-File` and `-Command` consistent and make exit codes consistent with Unix standards (#4573)

### Engine updates and fixes

* Make resource loading to work with PowerShell SxS installation (#4139)
* Add missing assemblies to TPA list to make Pwrshplughin.dll work (#4502)
* Make sure running `powershell` starts instance of the current version of PowerShell. (#4481)
* Make sure we only use Unicode output by default on Nano and IoT systems (#4074)
* Enable `powershell -WindowStyle` to work on Windows. (#4573)
* Enable enumeration of COM collections. (#4553)

### General cmdlet updates and fixes

* Fix Web CmdLets `-SkipHeaderValidation` to work with non-standard User-Agent headers. (#4479 & #4512) (Thanks @markekraus)
* Add Certificate authentication support for Web CmdLets. (#4646) (Thanks @markekraus)
* Add support for content headers to Web CmdLets. (#4494 & #4640) (Thanks @markekraus)
* Add support for converting enums to string (#4318) (Thanks @KirkMunro)
* Ignore casing when binding PSReadline KeyHandler functions (#4300) (Thanks @oising)
* Fix `Unblock-File` for the case of a read-only file. (#4395) (Thanks @iSazonov)
* Use supported API to set Central Access Policy ID (CAPID) in SACL. (#4496)
* Make `Start-Trace` support paths that require escaping in the underlying APIs (#3863)
* Removing `#if CORECLR` enabled, `Enable-PSRemoting` and `Disable-PSRemoting` (#2671)
* Enable WSManCredSSP cmdlets and add tests. (#4336)
* Use .NET Core's implementation for ShellExecute. (#4523)
* Fix SSH Remoting handling of KeyFileParameter when the path must be quoted. (#4529)
* Make Web CmdLets use HTML meta charset attribute value, if present (#4338)
* Move to .NET Core 2.0 final (#4603)

### Build/test and code cleanup

* Add Amazon Linux Docker image and enable related tests. (#4393) (Thanks @DarwinJS)
* Make MSI verify pre-requisites are installed. (#4602) (Thank @bergmeister)
* Fixed formatting issues in build files. (#4630) (Thanks @iSazonov)
* Make sure `install-powershell.sh` installs latest powershell on macOS, even if an old version is cached in brew. (#4509) (Thanks @richardszalay for reporting.)
* Fixes install scripts issue for macOS. (#4631) (Thanks @DarwinJS)
* Many stability improvements to our nightly code coverage automation. (#4313 & #4550)
* Remove hash validation from nanoserver-insider Docker file, due to frequent changes. (#4498)
* Update to make Travis-CI daily build badge more reliable. (#4522)
* Remove unused build files, build code, and product code. (#4532, #4580, #4590, #4589, #4588, #4587, #4586, #4583, #4582, #4581)
* Add additional acceptance tests for PowerShellGet. (#4531)
* Only publish a NuGet of the full PowerShell core package on daily builds and not merge. (#4517)
* Update nanoserver-insider Docker file due to breaking changes in the base image. (#4555)
* Cleanup engine tests (#4551)
* Fix intermittent failures in filesystem tests (#4566)
* Add tests for
    * `New-WinEvent`. (#4384)
    * tab completion.  (#4560)
    * various types. (#4503)
    * CDXML CmdLets. (#4537)
* Only allow packaging of powershell, if it was built from a repo at the root of the file system named powershell. (#4569 & #4600)
* Update `Format-Hex` test cases to use -TestCase instead of foreach loops. (#3800)
* Added functionality to get code coverage for a single file locally. (#4556)

### Documentation

* Added Ilya (@iSazonov) as a Maintainer. (#4365)
* Grammar fix to the Pull Request Guide. (#4322)
* Add homebrew for macOS to install documentation. (#3838)
* Added a CodeOwner file. (#4565 & #4597)

### Cleanup `#if CORECLR` code

PowerShell 6.0 will be exclusively built on top of CoreCLR,
so we are removing a large amount of code that's built only for FullCLR.
To read more about this, check out [this blog post](https://blogs.msdn.microsoft.com/powershell/2017/07/14/powershell-6-0-roadmap-coreclr-backwards-compatibility-and-more/).

## v6.0.0-beta.5 - 2017-08-02

### Breaking changes

* Remove the `*-Counter` cmdlets in `Microsoft.PowerShell.Diagnostics` due to the use of unsupported APIs until a better solution is found. (#4303)
* Remove the `Microsoft.PowerShell.LocalAccounts` due to the use of unsupported APIs until a better solution is found. (#4302)

### Engine updates and fixes

* Fix the issue where PowerShell Core wasn't working on Windows 7 or Windows Server 2008 R2/2012 (non-R2). (#4463)
* `ValidateSetAttribute` enhancement: support set values to be dynamically generated from a custom `ValidateSetValueGenerator`. (#3784) (Thanks to @iSazonov!)
* Disable breaking into debugger on Ctrl+Break when running non-interactively. (#4283) (Thanks to @mwrock!)
* Give error instead of crashing if WSMan client library is not available. (#4387)
* Allow passing `$true`/`$false` as a parameter to scripts using `powershell.exe -File`. (#4178)
* Enable `DataRow`/`DataRowView` adapters in PowerShell Core to fix an issue with `DataTable` usage. (#4258)
* Fix an issue where PowerShell class static methods were being shared across `Runspace`s/`SessionState`s. (#4209)
* Fix array expression to not return null or throw error. (#4296)
* Fixes a CIM deserialization bug where corrupted CIM classes were instantiating non-CIM types. (#4234)
* Improve error message when `HelpMessage` property of `ParameterAttribute` is set to empty string. (#4334)
* Make `ShellExecuteEx` run in a STA thread. (#4362)

### General cmdlet updates and fixes

* Add `-SkipHeaderValidation` switch to `Invoke-WebRequest` and `Invoke-RestMethod` to support adding headers without validating the header value. (#4085)
* Add support for `Invoke-Item -Path <folder>`. (#4262)
* Fix `ConvertTo-Html` output when using a single column header. (#4276)
* Fix output of `Length` for `FileInfo` when using `Format-List`. (#4437)
* Fix an issue in implicit remoting where restricted sessions couldn't use `Get-FormatData –PowerShellVersion`. (#4222)
* Fix an issue where `Register-PSSessionConfiguration` fails if `SessionConfig` folder doesn't exist. (#4271)

### Installer updates

* Create script to install latest PowerShell from Microsoft package repositories (or Homebrew) on non-Windows platforms. (#3608) (Thanks to @DarwinJS!)
* Enable MSI upgrades rather than a side-by-side install. (#4259)
* Add a checkbox to open PowerShell after the Windows MSI installer has finished. (#4203) (Thanks to @bergmeister!)
* Add Amazon Linux compatibility to `install-powershell.sh`. (#4360) (Thanks to @DarwinJS!)
* Add ability to package PowerShell Core as a NuGet package. (#4363)

### Build/test and code cleanup

* Add build check for MFC for Visual C++ during Windows builds.
  This fixes a long-standing (and very frustrating!) issue with missing build dependencies! (#4185) (Thanks to @KirkMunro!)
* Move building Windows PSRP binary out of `Start-PSBuild`.
  Now `Start-PSBuild` doesn't build PSRP binary on windows. Instead, we consume the PSRP binary from a NuGet package. (#4335)
* Add tests for built-in type accelerators. (#4230) (Thanks to @dchristian3188!)
* Increase code coverage of `Get-ChildItem` on file system. (#4342) (Thanks to @jeffbi!)
* Increase test coverage for `Rename-Item` and `Move-Item`. (#4329) (Thanks to @jeffbi!)
* Add test coverage for Registry provider. (#4354) (Thanks to @jeffbi!)
* Fix warnings and errors thrown by PSScriptAnalyzer. (#4261) (Thanks to @bergmeister!)
* Fix regressions that cause implicit remoting tests to fail. (#4326)
* Disable legacy UTC and SQM Windows telemetry by enclosing the code in '#if LEGACYTELEMETRY'. (#4190)

### Cleanup `#if CORECLR` code

PowerShell 6.0 will be exclusively built on top of CoreCLR,
so we are removing a large amount of code that's built only for FullCLR.
To read more about this, check out [this blog post](https://blogs.msdn.microsoft.com/powershell/2017/07/14/powershell-6-0-roadmap-coreclr-backwards-compatibility-and-more/).

## v6.0.0-beta.4 - 2017-07-12

## Windows PowerShell backwards compatibility

In the `beta.4` release, we've introduced a change to add the Windows PowerShell `PSModulePath` to the default `PSModulePath` in PowerShell Core on Windows. (#4132)

Along with the introduction of .NET Standard 2.0 in `6.0.0-beta.1` and a GAC probing fix in `6.0.0-beta.3`,
**this change will enable a large number of your existing Windows PowerShell modules/scripts to "just work" inside of PowerShell Core on Windows**.
(Note: We have also fixed the CDXML modules on Windows that were regressed in `6.0.0-beta.2` as part of #4144).

So that we can further enable this backwards compatibility,
we ask that you tell us more about what modules or scripts do and don't work in Issue #4062.
This feedback will also help us determine if `PSModulePath` should include the Windows PowerShell values by default in the long run.

For more information on this, we invite you to read [this blog post explaining PowerShell Core and .NET Standard in more detail](https://blogs.msdn.microsoft.com/powershell/?p=13355).

### Engine updates and fixes

- Add Windows PowerShell `PSModulePath` by default on Windows. (#4132)
- Move PowerShell to `2.0.0-preview3-25426-01` and using the .NET CLI version `2.0.0-preview2-006502`. (#4144)
- Performance improvement in PSReadline by minimizing writing ANSI escape sequences. (#4110)
- Implement Unicode escape parsing so that users can use Unicode characters as arguments, strings or variable names. (#3958) (Thanks to @rkeithhill!)
- Script names or full paths can have commas. (#4136) (Thanks to @TimCurwick!)
- Added `semver` as a type accelerator for `System.Management.Automation.SemanticVersion`. (#4142) (Thanks to @oising!)
- Close `eventLogSession` and `EventLogReader` to unlock an ETL log. (#4034) (Thanks to @iSazonov!)

### General cmdlet updates and fixes

- `Move-Item` cmdlet honors `-Include`, `-Exclude`, and `-Filter` parameters. (#3878)
- Add a parameter to `Get-ChildItem` called `-FollowSymlink` that traverses symlinks on demand, with checks for link loops. (#4020)
- Change `New-ModuleManifest` encoding to UTF8NoBOM on non-Windows platforms. (#3940)
- `Get-AuthenticodeSignature` cmdlets can now get file signature timestamp. (#4061)
- Add tab completion for `Export-Counter` `-FileFormat` parameter. (#3856)
- Fixed `Import-Module` on non-Windows platforms so that users can import modules with `NestedModules` and `RootModules`. (#4010)
- Close `FileStream` opened by `Get-FileHash`. (#4175) (Thanks to @rkeithhill!)

### Remoting

- Fixed PowerShell not responding when the SSH client abruptly terminates. (#4123)

### Documentation

- Added recommended settings for VS Code. (#4054) (Thanks to @iSazonov!)

## v6.0.0-beta.3 - 2017-06-20

### Breaking changes

- Remove the `BuildVersion` property from `$PSVersionTable`.
 This property was strongly tied to the Windows build version.
 Instead, we recommend that you use `GitCommitId` to retrieve the exact build version of PowerShell Core.
 (#3877) (Thanks to @iSazonov!)
- Change positional parameter for `powershell.exe` from `-Command` to `-File`.
 This fixes the usage of `#!` (aka as a shebang) in PowerShell scripts that are being executed from non-PowerShell shells on non-Windows platforms.
 This also means that you can now do things like `powershell foo.ps1` or `powershell fooScript` without specifying `-File`.
 However, this change now requires that you explicitly specify `-c` or `-Command` when trying to do things like `powershell.exe Get-Command`.
 (#4019)
- Remove `ClrVersion` property from `$PSVersionTable`.
 (This property is largely irrelevant for .NET Core,
 and was only preserved in .NET Core for specific legacy purposes that are inapplicable to PowerShell.)
 (#4027)

### Engine updates and fixes

- Add support to probe and load assemblies from GAC on Windows platform.
 This means that you can now load Windows PowerShell modules with assembly dependencies which reside in the GAC.
 If you're interested in running your traditional Windows PowerShell scripts and cmdlets using the power of .NET Standard 2.0,
 try adding your Windows PowerShell module directories to your PowerShell Core `$PSModulePath`.
 (E.g. `$env:PSModulePath += ';C:\Program Files\WindowsPowerShell\Modules;C:\WINDOWS\system32\WindowsPowerShell\v1.0\Modules'`)
 Even if the module isn't owned by the PowerShell Team, please tell us what works and what doesn't by leaving a comment in [issue #4062][issue-4062]! (#3981)
- Enhance type inference in tab completion based on runtime variable values. (#2744) (Thanks to @powercode!)
 This enables tab completion in situations like:
 ```powershell
 $p = Get-Process
 $p | Foreach-Object Prio<tab>
 ```
- Add `GitCommitId` to PowerShell Core banner.
 Now you don't have to run `$PSVersionTable` as soon as you start PowerShell to get the version! (#3916) (Thanks to @iSazonov!)
- Fix a bug in tab completion to make `native.exe --<tab>` call into native completer. (#3633) (Thanks to @powercode!)
- Fix PowerShell Core to allow use of long paths that are more than 260 characters. (#3960)
- Fix ConsoleHost to honour `NoEcho` on Unix platforms. (#3801)
- Fix transcription to not stop when a Runspace is closed during the transcription. (#3896)

[issue-4062]: https://github.com/PowerShell/PowerShell/issues/4062

### General cmdlet updates and fixes

- Enable `Send-MailMessage` in PowerShell Core. (#3869)
- Fix `Get-Help` to support case insensitive pattern matching on Unix platforms. (#3852)
- Fix tab completion on `Get-Help` for `about_*` topics. (#4014)
- Fix PSReadline to work in Windows Server Core container image. (#3937)
- Fix `Import-Module` to honour `ScriptsToProcess` when `-Version` is specified. (#3897)
- Strip authorization header on redirects with web cmdlets. (#3885)
- `Start-Sleep`: add the alias `ms` to the parameter `-Milliseconds`. (#4039) (Thanks to @Tadas!)

### Developer experience

- Make hosting PowerShell Core in your own .NET applications much easier by refactoring PowerShell Core to use the default CoreCLR loader. (#3903)
- Update `Add-Type` to support `CSharpVersion7`. (#3933) (Thanks to @iSazonov)

## v6.0.0-beta.2 - 2017-06-01

### Support backgrounding of pipelines with ampersand (`&`) (#3360)

- Putting `&` at the end of a pipeline will cause the pipeline to be run as a PowerShell job.
- When a pipeline is backgrounded, a job object is returned.
- Once the pipeline is running as a job, all of the standard `*-Job` cmdlets can be used to manage the job.
- Variables (ignoring process-specific variables) used in the pipeline are automatically copied to the job so `Copy-Item $foo $bar &` just works.
- The job is also run in the current directory instead of the user's home directory.
- For more information about PowerShell jobs, see [about_Jobs](https://msdn.microsoft.com/powershell/reference/6/about/about_jobs).

### Engine updates and fixes

- Crossgen more of the .NET Core assemblies to improve PowerShell Core startup time. (#3787)
- Enable comparison between a `SemanticVersion` instance and a `Version` instance that is constructed only with `Major` and `Minor` version values.
  This will fix some cases where PowerShell Core was failing to import older Windows PowerShell modules. (#3793) (Thanks to @mklement0!)

### General cmdlet updates and fixes

- Support Link header pagination in web cmdlets (#3828)
    - For `Invoke-WebRequest`, when the response includes a Link header we create a RelationLink property as a Dictionary representing the URLs and `rel` attributes and ensure the URLs are absolute to make it easier for the developer to use.
    - For `Invoke-RestMethod`, when the response includes a Link header we expose a `-FollowRelLink` switch to automatically follow `next` `rel` links until they no longer exist or once we hit the optional `-MaximumFollowRelLink` parameter value.
- Update `Get-ChildItem` to be more in line with the way that the *nix `ls -R` and the Windows `DIR /S` native commands handle symbolic links to directories during a recursive search.
  Now, `Get-ChildItem` returns the symbolic links it encountered during the search, but it won't search the directories those links target. (#3780)
- Fix `Get-ChildItem` to continue enumeration after throwing an error in the middle of a set of items.
  This fixes some issues where inaccessible directories or files would halt execution of `Get-ChildItem`. (#3806)
- Fix `ConvertFrom-Json` to deserialize an array of strings from the pipeline that together construct a complete JSON string.
  This fixes some cases where newlines would break JSON parsing. (#3823)
- Enable `Get-TimeZone` for macOS/Linux. (#3735)
- Change to not expose unsupported aliases and cmdlets on macOS/Linux. (#3595) (Thanks to @iSazonov!)
- Fix `Invoke-Item` to accept a file path that includes spaces on macOS/Linux. (#3850)
- Fix an issue where PSReadline was not rendering multi-line prompts correctly on macOS/Linux. (#3867)
- Fix an issue where PSReadline was not working on Nano Server. (#3815)

## v6.0.0-beta.1 - 2017-05-08

### Move to .NET Core 2.0 (.NET Standard 2.0 support)

PowerShell Core has moved to using .NET Core 2.0 so that we can leverage all the benefits of .NET Standard 2.0. (#3556)
To learn more about .NET Standard 2.0, there's some great starter content [on Youtube](https://www.youtube.com/playlist?list=PLRAdsfhKI4OWx321A_pr-7HhRNk7wOLLY),
on [the .NET blog](https://blogs.msdn.microsoft.com/dotnet/2016/09/26/introducing-net-standard/),
and [on GitHub](https://github.com/dotnet/standard/blob/master/docs/faq.md).
We'll also have more content soon in our [repository documentation](https://github.com/PowerShell/PowerShell/tree/master/docs) (which will eventually make its way to [official documentation](https://github.com/powershell/powershell-docs)).
In a nutshell, .NET Standard 2.0 allows us to have universal, portable modules between Windows PowerShell (which uses the full .NET Framework) and PowerShell Core (which uses .NET Core).
Many modules and cmdlets that didn't work in the past may now work on .NET Core, so import your favorite modules and tell us what does and doesn't work in our GitHub Issues!

### Telemetry

- For the first beta of PowerShell Core 6.0, telemetry has been to the console host to report two values (#3620):
    - the OS platform (`$PSVersionTable.OSDescription`)
    - the exact version of PowerShell (`$PSVersionTable.GitCommitId`)

If you want to opt-out of this telemetry, simply delete `$PSHome\DELETE_ME_TO_DISABLE_CONSOLEHOST_TELEMETRY`.
Even before the first run of Powershell, deleting this file will bypass all telemetry.
In the future, we plan on also enabling a configuration value for whatever is approved as part of [RFC0015](https://github.com/PowerShell/PowerShell-RFC/blob/master/1-Draft/RFC0015-PowerShell-StartupConfig.md).
We also plan on exposing this telemetry data (as well as whatever insights we leverage from the telemetry) in [our community dashboard](https://blogs.msdn.microsoft.com/powershell/2017/01/31/powershell-open-source-community-dashboard/).

If you have any questions or comments about our telemetry, please file an issue.

### Engine updates and fixes

- Add support for native command globbing on Unix platforms. (#3643)
    - This means you can now use wildcards with native binaries/commands (e.g. `ls *.txt`).
- Fix PowerShell Core to find help content from `$PSHome` instead of the Windows PowerShell base directory. (#3528)
    - This should fix issues where about_* topics couldn't be found on Unix platforms.
- Add the `OS` entry to `$PSVersionTable`. (#3654)
- Arrange the display of `$PSVersionTable` entries in the following way: (#3562) (Thanks to @iSazonov!)
    - `PSVersion`
    - `PSEdition`
    - alphabetical order for rest entries based on the keys
- Make PowerShell Core more resilient when being used with an account that doesn't have some key environment variables. (#3437)
- Update PowerShell Core to accept the `-i` switch to indicate an interactive shell. (#3558)
    - This will help when using PowerShell as a default shell on Unix platforms.
- Relax the PowerShell `SemanticVersion` constructors to not require 'minor' and 'patch' portions of a semantic version name. (#3696)
- Improve performance to security checks when group policies are in effect for ExecutionPolicy. (#2588) (Thanks to @powercode)
- Fix code in PowerShell to use `IntPtr(-1)` for `INVALID_HANDLE_VALUE` instead of `IntPtr.Zero`. (#3544) (Thanks to @0xfeeddeadbeef)

### General cmdlet updates and fixes

- Change the default encoding and OEM encoding used in PowerShell Core to be compatible with Windows PowerShell. (#3467) (Thanks to @iSazonov!)
- Fix a bug in `Import-Module` to avoid incorrect cyclic dependency detection. (#3594)
- Fix `New-ModuleManifest` to correctly check if a URI string is well formed. (#3631)

### Filesystem-specific updates and fixes

- Use operating system calls to determine whether two paths refer to the same file in file system operations. (#3441)
    - This will fix issues where case-sensitive file paths were being treated as case-insensitive on Unix platforms.
- Fix `New-Item` to allow creating symbolic links to file/directory targets and even a non-existent target. (#3509)
- Change the behavior of `Remove-Item` on a symbolic link to only removing the link itself. (#3637)
- Use better error message when `New-Item` fails to create a symbolic link because the specified link path points to an existing item. (#3703)
- Change `Get-ChildItem` to list the content of a link to a directory on Unix platforms. (#3697)
- Fix `Rename-Item` to allow Unix globbing patterns in paths. (#3661)

### Interactive fixes

- Add Hashtable tab completion for `-Property` of `Select-Object`. (#3625) (Thanks to @powercode)
- Fix tab completion with `@{<tab>` to avoid crash in PSReadline. (#3626) (Thanks to @powercode)
- Use `<id> - <name>` as `ToolTip` and `ListItemText` when tab completing process ID. (#3664) (Thanks to @powercode)

### Remoting fixes

- Update PowerShell SSH remoting to handle multi-line error messages from OpenSSH client. (#3612)
- Add `-Port` parameter to `New-PSSession` to create PowerShell SSH remote sessions on non-standard (non-22) ports. (#3499) (Thanks to @Lee303)

### API Updates

- Add the public property `ValidRootDrives` to `ValidateDriveAttribute` to make it easy to discover the attribute state via `ParameterMetadata` or `PSVariable` objects. (#3510) (Thanks to @indented-automation!)
- Improve error messages for `ValidateCountAttribute`. (#3656) (Thanks to @iSazonov)
- Update `ValidatePatternAttribute`, `ValidateSetAttribute` and `ValidateScriptAttribute` to allow users to more easily specify customized error messages. (#2728) (Thanks to @powercode)

## v6.0.0-alpha.18 - 2017-04-05

### Progress Bar

We made a number of fixes to the progress bar rendering and the `ProgressRecord` object that improved cmdlet performance and fixed some rendering bugs on non-Windows platforms.

- Fix a bug that caused the progress bar to drift on Unix platforms. (#3289)
- Improve the performance of writing progress records. (#2822) (Thanks to @iSazonov!)
- Fix the progress bar rendering on Unix platforms. (#3362) (#3453)
- Reuse `ProgressRecord` in Web Cmdlets to reduce the GC overhead. (#3411) (Thanks to @iSazonov!)

### Cmdlet updates

- Use `ShellExecute` with `Start-Process`, `Invoke-Item`, and `Get-Help -Online` so that those cmdlets use standard shell associations to open a file/URI.
  This means you `Get-Help -Online` will always use your default browser, and `Start-Process`/`Invoke-Item` can open any file or path with a handler.
  (Note: there are still some problems with STA threads.) (#3281, partially fixes #2969)
- Add `-Extension` and `-LeafBase` switches to `Split-Path` so that you can split paths between the filename extension and the rest of the filename. (#2721) (Thanks to @powercode!)
- Implement `Format-Hex` in C# along with some behavioral changes to multiple parameters and the pipeline. (#3320) (Thanks to @MiaRomero!)
- Add `-NoProxy` to web cmdlets so that they ignore the system-wide proxy setting. (#3447) (Thanks to @TheFlyingCorpse!)
- Fix `Out-Default -Transcript` to properly revert out of the `TranscribeOnly` state, so that further output can be displayed on Console. (#3436) (Thanks to @PetSerAl!)
- Fix `Get-Help` to not return multiple instances of the same help file. (#3410)

### Interactive fixes

- Enable argument auto-completion for `-ExcludeProperty` and `-ExpandProperty` of `Select-Object`. (#3443) (Thanks to @iSazonov!)
- Fix a tab completion bug that prevented `Import-Module -n<tab>` from working. (#1345)

### Cross-platform fixes

- Ignore the `-ExecutionPolicy` switch when running PowerShell on non-Windows platforms because script signing is not currently supported. (#3481)
- Standardize the casing of the `PSModulePath` environment variable. (#3255)

### JEA fixes

- Fix the JEA transcription to include the endpoint configuration name in the transcript header. (#2890)
- Fix `Get-Help` in a JEA session. (#2988)

## v6.0.0-alpha.17 - 2017-03-08

- Update PSRP client libraries for Linux and Mac.
    - We now support customer configurations for Office 365 interaction, as well as NTLM authentication for WSMan based remoting from Linux (more information [here](https://github.com/PowerShell/psl-omi-provider/releases/tag/v1.0.0.18)). (#3271)
- We now support remote step-in debugging for `Invoke-Command -ComputerName`. (#3015)
- Use prettier formatter with `ConvertTo-Json` output. (#2787) (Thanks to @kittholland!)
- Port `*-CmsMessage` and `Get-PfxCertificate` cmdlets to Powershell Core. (#3224)
- `powershell -version` now returns version information for PowerShell Core. (#3115)
- Add the `-TimeOut` parameter to `Test-Connection`. (#2492)
- Add `ShouldProcess` support to `New-FileCatalog` and `Test-FileCatalog` (fixes `-WhatIf` and `-Confirm`). (#3074) (Thanks to @iSazonov!)
- Fix `Test-ModuleManifest` to normalize paths correctly before validating.
  - This fixes some problems when using `Publish-Module` on non-Windows platforms. (#3097)
- Remove the `AliasProperty "Count"` defined for `System.Array`.
  - This removes the extraneous `Count` property on some `ConvertFrom-Json` output. (#3231) (Thanks to @PetSerAl!)
- Port `Import-PowerShellDatafile` from PowerShell script to C#. (#2750) (Thanks to @powercode!)
- Add `-CustomMethod` parameter to web cmdlets to allow for non-standard method verbs. (#3142) (Thanks to @Lee303!)
- Fix web cmdlets to include the HTTP response in the exception when the response status code is not success. (#3201)
- Expose a process' parent process by adding the `CodeProperty "Parent"` to `System.Diagnostics.Process`. (#2850) (Thanks to @powercode!)
- Fix crash when converting a recursive array to a bool. (#3208) (Thanks to @PetSerAl!)
- Fix casting single element array to a generic collection. (#3170)
- Allow profile directory creation failures for Service Account scenarios. (#3244)
- Allow Windows' reserved device names (e.g. CON, PRN, AUX, etc.) to be used on non-Windows platforms. (#3252)
- Remove duplicate type definitions when reusing an `InitialSessionState` object to create another Runspace. (#3141)
- Fix `PSModuleInfo.CaptureLocals` to not do `ValidateAttribute` check when capturing existing variables from the caller's scope. (#3149)
- Fix a race bug in WSMan command plug-in instance close operation. (#3203)
- Fix a problem where newly mounted volumes aren't available to modules that have already been loaded. (#3034)
- Remove year from PowerShell copyright banner at start-up. (#3204) (Thanks to @kwiknick!)
- Fixed spelling for the property name `BiosSerialNumber` for `Get-ComputerInfo`. (#3167) (Thanks to @iSazonov!)

## v6.0.0-alpha.16 - 2017-02-15

- Add `WindowsUBR` property to `Get-ComputerInfo` result
- Cache padding strings to speed up formatting a little
- Add alias `Path` to the `-FilePath` parameter of `Out-File`
- Fix the `-InFile` parameter of `Invoke-WebRequest`
- Add the default help content to powershell core
- Speed up `Add-Type` by crossgen'ing its dependency assemblies
- Convert `Get-FileHash` from script to C# implementation
- Fix lock contention when compiling the code to run in interpreter
- Avoid going through WinRM remoting stack when using `Get-ComputerInfo` locally
- Fix native parameter auto-completion for tokens that begin with a single "Dash"
- Fix parser error reporting for incomplete input to allow defining class in interactive host
- Add the `RoleCapabilityFiles` keyword for JEA support on Windows

## v6.0.0-alpha.15 - 2017-01-18

- Use parentheses around file length for offline files
- Fix issues with the Windows console mode (terminal emulation) and native executables
- Fix error recovery with `using module`
- Report `PlatformNotSupported` on IoT for Get/Import/Export-Counter
- Add `-Group` parameter to `Get-Verb`
- Use MB instead of KB for memory columns of `Get-Process`
- Add new escape character for ESC: `` `e``
- Fix a small parsing issue with a here string
- Improve tab completion of types that use type accelerators
- `Invoke-RestMethod` improvements for non-XML non-JSON input
- PSRP remoting now works on CentOS without addition setup

## v6.0.0-alpha.14 - 2016-12-14

- Moved to .NET Core 1.1
- Add Windows performance counter cmdlets to PowerShell Core
- Fix try/catch to choose the more specific exception handler
- Fix issue reloading modules that define PowerShell classes
- `Add ValidateNotNullOrEmpty` to approximately 15 parameters
- `New-TemporaryFile` and `New-Guid` rewritten in C#
- Enable client side PSRP on non-Windows platforms
- `Split-Path` now works with UNC roots
- Implicitly convert value assigned to XML property to string
- Updates to `Invoke-Command` parameters when using SSH remoting transport
- Fix `Invoke-WebRequest` with non-text responses on non-Windows platforms
- `Write-Progress` performance improvement from `alpha13` reverted because it introduced crash with a race condition

## v6.0.0-alpha.13 - 2016-11-22

- Fix `NullReferenceException` in binder after turning on constrained language mode
- Enable `Invoke-WebRequest` and `Invoke-RestMethod` to not validate the HTTPS certificate of the server if required.
- Enable binder debug logging in PowerShell Core
- Add parameters `-Top` and `-Bottom` to `Sort-Object` for Top/Bottom N sort
- Enable `Update-Help` and `Save-Help` on Unix platforms
- Update the formatter for `System.Diagnostics.Process` to not show the `Handles` column
- Improve `Write-Progress` performance by adding timer to update a progress pane every 100 ms
- Enable correct table width calculations with ANSI escape sequences on Unix
- Fix background jobs for Unix and Windows
- Add `Get-Uptime` to `Microsoft.PowerShell.Utility`
- Make `Out-Null` as fast as `> $null`
- Add DockerFile for 'Windows Server Core' and 'Nano Server'
- Fix WebRequest failure to handle missing ContentType in response header
- Make `Write-Host` fast by delay initializing some properties in InformationRecord
- Ensure PowerShell Core adds an initial `/` rooted drive on Unix platforms
- Enable streaming behavior for native command execution in pipeline, so that `ping | grep` doesn't block
- Make `Write-Information` accept objects from pipeline
- Fixes deprecated syscall issue on macOS 10.12
- Fix code errors found by the static analysis using PVS-Studio
- Add support to W3C Extended Log File Format in `Import-Csv`
- Guard against `ReflectionTypeLoadException` in type name auto-completion
- Update build scripts to support win7-x86 runtime
- Move PackageManagement code/test to oneget.org

## v6.0.0-alpha.12 - 2016-11-03

- Fix `Get-ChildItem -Recurse -ErrorAction Ignore` to ignore additional errors
- Don't block pipeline when running Windows EXE's
- Fix for PowerShell SSH remoting with recent Win32-OpenSSH change.
- `Select-Object` with `-ExcludeProperty` now implies `-Property *` if -Property is not specified.
- Adding ValidateNotNullOrEmpty to `-Name` parameter of `Get-Alias`
- Enable Implicit remoting commands in PowerShell Core
- Fix GetParentProcess() to replace an expensive WMI query with Win32 API calls
- Fix `Set-Content` failure to create a file in PSDrive under certain conditions.
- Adding ValidateNotNullOrEmpty to `-Name` parameter of `Get-Service`
- Adding support <Suppress> in `Get-WinEvent -FilterHashtable`
- Adding WindowsVersion to `Get-ComputerInfo`
- Remove the unnecessary use of lock in PseudoParameterBinder to avoid deadlock
- Refactor `Get-WinEvent` to use StringBuilder for XPath query construction
- Clean up and fix error handling of libpsl-native
- Exclude Registry and Certificate providers from UNIX PS
- Update PowerShell Core to consume .Net Core preview1-24530-04

## v6.0.0-alpha.11 - 2016-10-17

- Add '-Title' to 'Get-Credential' and unify the prompt experience
- Update dependency list for PowerShell Core on Linux and OS X
- Fix 'powershell -Command -' to not stop responding and to not ignore the last command
- Fix binary operator tab completion
- Enable 'ConvertTo-Html' in PowerShell Core
- Remove most Maximum* capacity variables
- Fix 'Get-ChildItem -Hidden' to work on system hidden files on Windows
- Fix 'JsonConfigFileAccessor' to handle corrupted 'PowerShellProperties.json'
    and defer creating the user setting directory until a write request comes
- Fix variable assignment to not overwrite read-only variables
- Fix 'Get-WinEvent -FilterHashtable' to work with named fields in UserData of event logs
- Fix 'Get-Help -Online' in PowerShell Core on Windows
- Spelling/grammar fixes

## v6.0.0-alpha.10 - 2016-09-15

- Fix passing escaped double quoted spaces to native executables
- Add DockerFiles to build each Linux distribution
- `~/.config/PowerShell` capitalization bug fixed
- Fix crash on Windows 7
- Fix remote debugging on Windows client
- Fix multi-line input with redirected stdin
- Add PowerShell to `/etc/shells` on installation
- Fix `Install-Module` version comparison bug
- Spelling fixes

## v6.0.0-alpha.9 - 2016-08-15

- Better man page
- Added third-party and proprietary licenses
- Added license to MSI

## v6.0.0-alpha.8 - 2016-08-11

- PowerShell packages pre-compiled with crossgen
- `Get-Help` content added
- `Get-Help` null reference exception fixed
- Ubuntu 16.04 support added
- Unsupported cmdlets removed from Unix modules
- PSReadline long prompt bug fixed
- PSReadline custom key binding bug on Linux fixed
- Default terminal colors now respected
- Semantic Version support added
- `$env:` fixed for case-sensitive variables
- Added JSON config files to hold some settings
- `cd` with no arguments now behaves as `cd ~`
- `ConvertFrom-Json` fixed for multiple lines
- Windows branding removed
- .NET CoreCLR Runtime patched to version 1.0.4
- `Write-Host` with unknown hostname bug fixed
- `powershell` man-page added to package
- `Get-PSDrive` ported to report free space
- Desired State Configuration MOF compilation ported to Linux
- Windows 2012 R2 / Windows 8.1 remoting enabled

## v6.0.0-alpha.7 - 2016-07-26

- Invoke-WebRequest and Invoke-RestMethod ported to PowerShell Core
- Set PSReadline default edit mode to Emacs on Linux
- IsCore variable renamed to IsCoreCLR
- Microsoft.PowerShell.LocalAccounts and other Windows-only assemblies excluded on Linux
- PowerShellGet fully ported to Linux
- PackageManagement NuGet provider ported
- Write-Progress ported to Linux
- Get-Process -IncludeUserName ported
- Enumerating symlinks to folders fixed
- Bugs around administrator permissions fixed on Linux
- ConvertFrom-Json multi-line bug fixed
- Execution policies fixed on Windows
- TimeZone cmdlets added back; excluded from Linux
- FileCatalog cmdlets added back for Windows
- Get-ComputerInfo cmdlet added back for Windows

## v0.6.0 - 2016-07-08

- Targets .NET Core 1.0 release
- PowerShellGet enabled
- [system.manage<tab>] completion issues fixed
- AssemblyLoadContext intercepts dependencies correctly
- Type catalog issues fixed
- Invoke-Item enabled for Linux and OS X
- Windows ConsoleHost reverted to native interfaces
- Portable ConsoleHost redirection issues fixed
- Bugs with pseudo (and no) TTY's fixed
- Source Depot synced to baseline changeset 717473
- SecureString stub replaced with .NET Core package

## v0.5.0 - 2016-06-16

- Paths given to cmdlets are now slash-agnostic (both / and \ work as directory separator)
- Lack of cmdlet support for paths with literal \ is a known issue
- .NET Core packages downgraded to build rc2-24027 (Nano's build)
- XDG Base Directory Specification is now respected and used by default
- Linux and OS X profile path is now `~/.config/powershell/profile.ps1`
- Linux and OS X history save path is now `~/.local/share/powershell/PSReadLine/ConsoleHost_history.txt`
- Linux and OS X user module path is now `~/.local/share/powershell/Modules`
- The `~/.powershell` folder is deprecated and should be deleted
- Scripts can be called within PowerShell without the `.ps1` extension
- `Trace-Command` and associated source cmdlets are now available
- `Ctrl-C` now breaks running cmdlets correctly
- Source Depot changesets up to 715912 have been merged
- `Set-PSBreakPoint` debugging works on Linux, but not on Windows
- MSI and APPX packages for Windows are now available
- Microsoft.PowerShell.LocalAccounts is available on Windows
- Microsoft.PowerShell.Archive is available on Windows
- Linux xUnit tests are running again
- Many more Pester tests are running

## v0.4.0 - 2016-05-17

- PSReadline is ported and included by default
- Original Windows ConsoleHost is ported and replaced CoreConsoleHost
- .NET Core packages set to the RC2 release at build 24103
- OS X 10.11 added to Continuous Integration matrix
- Third-party C# cmdlets can be built with .NET CLI
- Improved symlink support on Linux
- Microsoft.Management.Infrastructure.Native replaced with package
- Many more Pester tests

## v0.3.0 - 2016-04-11

- Supports Windows, Nano, OS X, Ubuntu 14.04, and CentOS 7.1
- .NET Core packages are build rc3-24011
- Native Linux commands are not shadowed by aliases
- `Get-Help -Online` works
- `more` function respects the Linux `$PAGER`; defaults to `less`
- `IsWindows`, `IsLinux`, `IsOSX`, `IsCore` built-in PowerShell variables added
- `Microsoft.PowerShell.Platform` removed for the above
- Cross-platform core host is now `CoreConsoleHost`
- Host now catches exceptions in `--command` scripts
- Host's shell ID changed to `Microsoft.PowerShellCore`
- Modules that use C# assemblies can be loaded
- `New-Item -ItemType SymbolicLink` supports arbitrary targets
- PSReadline implementation supports multi-line input
- `Ctrl-R` provides incremental reverse history search
- `$Host.UI.RawUI` now supported
- `Ctrl-K` and `Ctrl-Y` for kill and yank implemented
- `Ctrl-L` to clear screen now works
- Documentation was completely overhauled
- Many more Pester and xUnit tests added

## v0.2.0 - 2016-03-08

- Supports Windows, OS X, Ubuntu 14.04, and CentOS 7.1
- .NET Core packages are build 23907
- `System.Console` PSReadline is fully functional
- Tests pass on OS X
- `Microsoft.PowerShell.Platform` module is available
- `New-Item` supports symbolic and hard links
- `Add-Type` now works
- PowerShell code merged with upstream `rs1_srv_ps`

## v0.1.0 - 2016-02-23

- Supports Windows, OS X, and Ubuntu 14.04
