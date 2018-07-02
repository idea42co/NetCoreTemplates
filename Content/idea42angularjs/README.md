# `dotnet new angularjsapp`

This template implements the LTS version of AngularJS (v1.7.x) for those projects where the next version of Angular is just not an option.

## For Development

To get development going, you will need to do the following:

- `npm install -g gulp-cli`
- `npm install`
- `dotnet restore`
- `dotnet build`
- `dotnet run`

After changes, just run the following commands again.

-  `dotnet build` then `dotnet run`

## Docker

You will need to first install docker. [Docker Community Edition](https://www.docker.com/community-edition)

Once installed, you can use `npm run docker` to build and run a docker container called `authreactapp`. Once this command completes, you can access the site by hitting `http://localhost:3000`, unless you tweak the port mapping in the build commands.
  
## Contributions!

If something doesn't work, or you think we need to change something, please let us know in the issues section!