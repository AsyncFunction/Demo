//setup yeoman and .net5 templates
npm install -g generator-aspnet
npm install -g yo

//Start yeoman template generator tool
yo aspnet

//browse to the dir and download all the .net dependencies from the project.json file (might have to call "dnvm upgrade" first)
dnu restore 

//start the project from command line (Similar to F5 in VS)
dnx web

//Get list of items that can be generated 
// (e.g. yo aspnet:MvcController Runner) would create a runner controller
// (e.g. yo aspnet:WebApiController Runner2) would create a runner2 controller
yo aspnet --help