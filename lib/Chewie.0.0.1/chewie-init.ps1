function make_a_new_nugetFile
{
	new-item -path $pwd -name .NugetFile -itemtype file
	add-content $pwd\.NugetFile "install_to 'lib'"
	add-content $pwd\.NugetFile "nuget 'machine.specifications'"
 }
 
if(!(test-path $pwd\.NugetFile)){make_a_new_nugetFile}