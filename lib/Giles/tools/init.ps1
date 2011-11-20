param($rootPath, $toolsPath, $package, $project)

$gilesRunnerFrom = $toolsPath + "\giles.ps1"
$gilesRunnerTo = "giles.ps1"

if(!(Test-Path $gilesRunnerTo))
{
  Copy-Item $gilesRunnerFrom $gilesRunnerTo
}

$gilesRunnerFrom = $toolsPath + "\giles-x86.ps1"
$gilesRunnerTo = "giles-x86.ps1"

if(!(Test-Path $gilesRunnerTo))
{
  Copy-Item $gilesRunnerFrom $gilesRunnerTo
}