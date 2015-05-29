@ECHO OFF

powershell -NoProfile -ExecutionPolicy Unrestricted -Command ^

$ErrorActionPreference = 'Stop'; ^
$WorkingDir = Convert-Path .; ^
$BuildPackageName = 'psake.net'; ^
$PSMajorVersion = 3; ^

if ($PSVersionTable.PSVersion.Major -lt $PSMajorVersion) { Write-Host -ForegroundColor Red "ERROR: The script cannot be run because it requires Windows PowerShell version 3.0 or greater"; exit 1 }; ^

function Get-PackageDir() { ^
	param([xml]$packagesXml, [string]$packagesDir, [string]$packageName); ^
	ForEach ($package in $packagesXml.packages.package) { ^
		if ($package.id -eq $packageName) { return Join-Path $packagesDir ($package.id + '.' + $package.version) } ^
	} else { ^
		Write-Host -ForegroundColor Red "ERROR: Cannot find '$packageName' package"; ^
		exit 1; ^
	}; ^
}; ^

function Test-LastExitCode { if ($LastExitCode -ne 0 -and $LastExitCode) { Write-Host "ExitCode: $LastExitCode" -ForegroundColor Red; exit $LastExitCode } }; ^

$NuGet = Join-Path $WorkingDir '.nuget\NuGet.exe'; ^
if (-not (Test-Path $NuGet)) { ^
	Write-Host 'Downloading NuGet.exe' -ForegroundColor Cyan; ^
	$(New-Object System.Net.WebClient).DownloadFile('https://www.nuget.org/nuget.exe', $NuGet); ^
}; ^

$PackagesDir = cmd /c "$NuGet" config RepositoryPath -AsPath; ^
if ($PackagesDir -eq '"WARNING: Key ''RepositoryPath'' not found.'") { Write-Host -ForegroundColor Red "ERROR: Cannot find 'RepositoryPath' key in NuGet.config"; exit 1 }; ^

$PackagesConfig = Join-Path $WorkingDir '.nuget\packages.config'; ^
if (-not (Test-Path $PackagesConfig)) { Write-Host -ForegroundColor Red "ERROR: Cannot find solution 'packages.config'"; exit 1 }; ^
[xml]$PackagesXml = Get-Content $PackagesConfig; ^

Write-Host "Restoring NuGet packages" -ForegroundColor Cyan; ^
cmd /c $NuGet restore; ^
Test-LastExitCode; ^

Write-Host "Atempting to resolve semantic version" -ForegroundColor Cyan; ^
$GitVersion =  Out-String -InputObject (cmd /c (Join-Path (Get-PackageDir $PackagesXml $PackagesDir 'GitVersion.CommandLine') 'tools\GitVersion.exe')); ^
try { Write-Host "Semantic version: " $(ConvertFrom-Json -InputObject $GitVersion).SemVer } catch [System.Exception] { Write-Host -ForegroundColor Red $GitVersion; exit 1 }; ^

$Psake = Join-Path (Get-PackageDir $PackagesXml $PackagesDir 'psake') 'tools\psake.psm1'; ^
if (Test-Path $(Join-Path $WorkingDir ($BuildPackageName + '\Functions.psm1'))) { ^
	$Functions = Join-Path $WorkingDir ($BuildPackageName + '\Functions.psm1') ^
} else { ^
	$Functions = Join-Path (Get-PackageDir $PackagesXml $PackagesDir $BuildPackageName) '\Functions.psm1'; ^
}; ^

Import-Module "$Psake", "$Functions"; ^
Write-Host 'Invoking psake' -ForegroundColor Cyan; ^
Invoke-psake $(Join-Path $WorkingDir '.\tasks.ps1') %*; ^

if (($psake.build_success -eq $false) -and ($LastExitCode -eq 0 -or -not ($LastExitCode))) { $LastExitCode = 1 }; ^
Test-LastExitCode;