param(
  [Parameter(Position=0,Mandatory=0)]
  [string]$solutionFile = "$(Split-Path $pwd -leaf).sln"
)

$solutionFile = Resolve-Path $solutionFile
$giles = @(Get-ChildItem .\* -recurse -include giles-x86.exe)[0].FullName
& $giles -s $solutionFile