# Idea42, LLC .NET Core Templates
The purpose of these templates are to provide bootstraped applications that you can then build on and change as you need! We've implemented some of the most common items needed for coding ReactJS, Angular and WebAPI applications into .NET core apps, providing several pre-built commands (including docker stuff for those wanting to build docker containers) for you to run. 

## Prerequisites
Install .NET Core here ([https://www.microsoft.com/net/core](https://www.microsoft.com/net/core))

## Installing the templates
To install our templates, simply run the following command:  
```
dotnet new --install Idea42.NetCore.Templates::*
```

## Uninstalling the templates
If you just absolutely hate these templates, you can remove by running the following:
```
dotnet new --uninstall Idea42.NetCore.Templates
```

## Using the templates
After installation, the following templates will be avaliable. 

| Command | Description |  |
| --- | --- | -- |
| `dotnet new reactapp` | Will create a new .NET Core app that wraps the `react-scripts` commands to build production ready ReactJS in .NET Core. | [Documentation](/Content/idea42react/README.md)
| `dotnet new angularapp` | Will create a new .NET Core app that wraps the `ng` commands to build production ready Angular in .NET Core. |[Documentation](/Content/idea42angular/README.md)
| `dotnet new angularjsapp` | Will create a new .NET Core app that implements AngularJS's LTS version (1.7.x). |[Documentation](/Content/idea42angularjs/README.md)
| `dotnet new authapi` | Will create a simple Authenticating API using [OpenIddict](https://github.com/openiddict/openiddict-core) to handle authentication. | [Documentation](/Content/idea42authapi/README.md)
| `dotnet new authreact` | Creates a combo application that implements the ReactJS template above with the AuthAPI from above. This application will run on its own without having a seperate API. | [Documentation](/Content/idea42authreact/README.md)

## Contributions! 
If something doesn't work, or you think we need to change something, please let us know in the issues section!
