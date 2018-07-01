# dotnet new angularjs
This bootstrap used the `ng new` command to build a standalone AngularJS application that builds directly into .NET Core.

## For Development
You can use the following to run your application during development. 

 - `ng serve` or `npm start`
 - `dotnet build` then `dotnet run`

If you use `ng serve` or `npm start`, you will get live refreshes on your browser with code changes. We recommend using either of these commands (both do the same thing) during development, then use `dotnet build` and `dotnet publish` commands when you are ready to release.

## For Docker
You will need to first install docker. 
[Docker Community Edition](https://www.docker.com/community-edition)

Once installed, you can use `npm run docker` to build and run a docker container called `angularapp`. Once this command completes, you can access the site by hitting `http://localhost:4200`, unless you tweak the port mapping in the build commands.

## Contributions! 
If something doesn't work, or you think we need to change something, please let us know in the issues section!

# Items from AngularCLI

## Code scaffolding

Run  `ng generate component component-name`  to generate a new component. You can also use  `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Running unit tests

Run  `ng test`  to execute the unit tests via  [Karma](https://karma-runner.github.io/).

## Running end-to-end tests

Run  `ng e2e`  to execute the end-to-end tests via  [Protractor](http://www.protractortest.org/).

## Further help

To get more help on the Angular CLI use  `ng help`  or go check out the  [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).
