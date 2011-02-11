The intent of Chewie is to bring some of the niceties of gems bundler to nuget. 
Chewie uses a file named .Nugetfile to find all the nugets and you want installed along with how and from where you would like to install them. Chewie is delivered as a set of powershell scripts and a powershell module.

## Getting started 
PS>chewie-init.ps1  
This will create the sample .NugetFile you can use to begin working with Chewie.  


Below are some examples of the features in Chewie and how to use them.  

### source 
usage =>  source <some_nuget_feed_url>  
example => source 'http://nuget.random.org/'  

This will set the default source for all of you nugets. Use this if you plan to use some of feed other than the one defined in nuget.exe. 

### install_to
usage => install_to <some_folder_name>  
example => install_to 'lib'  

This will tell nuget to install the following nugets to the specified folder. Install_To will create the folder if it does not already exist.

### nuget
usage => nuget <name> [-v/-version <version_to_install>] [-s/-source <some_nuget_feed_url>]  
example => nuget 'ninject'  
example => nuget 'ninject' '2.0.1.0'  
example => nuget 'ninject' -v '2.0.1.0'  
example => nuget 'ninject' '2.0.1.0' 'http://somethingrandom.feed.org'  
example => nuget 'ninject  -source 'http://somethingrandom.feed.org' -v '2.0.1.0'   
I think you get the idea....  

## using the module
using the module is not much different than the script itself except for a couple of changes.  

To init a Chewie file once the module is imported you can :  
PS>chewie-init

Once you import the module you can get can get chewie doing its thing by calling :  
PS>gimmie-noms

## Projects using Chewie
https://github.com/codereflection/Giles  
