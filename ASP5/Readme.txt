//setup yeoman and .net5 templates
npm install -g generator-aspnet
npm install -g yo

//Start yeoman template generator tool
yo aspnet

//downloads all the .net dependencies from the project.json file
dnu restore 