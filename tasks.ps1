# Needed because running 'psake.bat -doc' result in $psake.build_success being false
$psake.build_success = $true

properties {
	. $(Get-DefaultPropertiesFile)
	$src_dir = Join-Path $base_dir "src"
	$project_name = "GildedRose.Console"
	$project_dir = Join-Path $src_dir $project_name
}

Import-DefaultTasks Version, Clean, Build, Test

Task Default -Depends Clean, Build, Test