# `dotnet new reactjs`
This bootstrap used the `create-react-app` command to build a standalone ReactJS application that builds directly into .NET Core.

## For Development
**NOTE:** Be sure to run `npm install` before trying any of these commands.

You can use the following to run your application during development. 

 - `npm start`
 - `dotnet build` then `dotnet run`

If you use `npm start`, you will get live refreshes on your browser with code changes. We recommend using either of these commands (both do the same thing) during development, then use `dotnet build` and `dotnet publish` commands when you are ready to release.

## For Docker
You will need to first install docker. 
[Docker Community Edition](https://www.docker.com/community-edition)

Once installed, you can use `npm run docker` to build and run a docker container called `reactapp`. Once this command completes, you can access the site by hitting `http://localhost:3000`, unless you tweak the port mapping in the build commands.

## Contributions! 
If something doesn't work, or you think we need to change something, please let us know in the issues section!
