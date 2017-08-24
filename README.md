# Idea42 NetCoreTemplates
At Idea42, we strive to build things that help build better software. Since we love .NET Core, we thought we would build something to not only help us out, but help others out!

We will have more templates coming soon, so check back for updates, and reinstall your templates from time to time to keep them up-to-date!

## Prerequisites
Install .NET Core here (https://www.microsoft.com/net/core)

## Installation
To install our templates, simply run the following command:
`dotnet new --install Idea42.NetCore.Templates::*`

You should now have some new options avaliable for the `dotnet new` command. :-)

If you have issues getting up and running with one of our templates, please see the steps below for the template you are trying to work with

### `dotnet new idea42.angular1`
This is a basic angular 1.x template with a helpful `serviceBase.js` service and built in capabilities to inject settings from the `appSettings.json` files. Perform the following commands to compile. 

`npm install -g gulp-cli`

`dotnet restore`

`dotnet build`

`dotnet run`

**AFTER CHANGES**

To recompile, and make sure all thigns happen that need to happen with minification and SASS compilations, always run

`dotnet build`

`dotnet run`

### `dotnet new idea42.authapi`
This is a basic API with JSON WebToken authentication enabled. We are using EF and SQLite. You can change the database to SQL Server easily by replacing `options.UseSqlite` with `options.UseSqlServer` in `Startup.cs`. After you do this, you'll need to update your connection strings to work with SQL Server. You can see those connection string in the appSettings.json file. 

To build and get this template working as is, you need to do the following. 

`dotnet restore`

`dotnet ef migrations add initial`

`dotnet ef database update`

`dotnet build`

`dotnet run`

As always, if you add a new DB context, or change an existing one, create a new migration by using `dotnet ef migrations add migrationName` and then call `dotnet ef database update`
