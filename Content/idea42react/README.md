# `dotnet new reactjs`
This bootstrap used the `ng new` command to build a standalone AngularJS application that builds directly into .NET Core.

## For Development
You can use the following to run your application during development. 

 - `npm start`
 - `dotnet build` then `dotnet run`

If you use `npm start`, you will get live refreshes on your browser with code changes. We recommend using either of these commands (both do the same thing) during development, then use `dotnet build` and `dotnet publish` commands when you are ready to release.

## For Docker
You will need to first install docker. 
[Docker Community Edition](https://www.docker.com/community-edition)

Once installed, you can use `npm run docker` to build and run a docker container called `angularapp`. Once this command completes, you can access the site by hitting `http://localhost:3000`, unless you tweak the port mapping in the build commands.

## Contributions! 
If something doesn't work, or you think we need to change something, please let us know in the issues section!
