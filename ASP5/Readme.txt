//setup yeoman and .net5 templates
npm install -g generator-aspnet
npm install -g yo

//Start yeoman template generator tool
yo aspnet

//browse to the dir and download all the .net dependencies from the project.json file (might have to call "dnvm upgrade" first)
dnu restore 

//start the project from command line (Similar to F5 in VS)
dnx web