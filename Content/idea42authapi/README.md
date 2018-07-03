
# `dotnet new authapi`

This bootstrap takes [OpenIddict](https://github.com/openiddict/openiddict-core), Entity Framework (working with SQLite by default), creates models to create the Users and Roles tables, and builds a simple test API to allow you to test that things are working. 

## For Development
**NOTE:** Be sure to run `npm install` before trying any of these commands.

You can use the following to run your application during development.
-   `dotnet build`  then  `dotnet run`

Any changes to your application will require you to rerun the commands above unless you set up a file watcher to automatically rebuild after file changes. 

## First Time Use
Since we are using entity framework to build this API, you'll need to generate your first migration on your own. To do this, run:
```
dotnet ef migrations add initial
```
On `dotnet run`, the application will run the migration and add three roles and a default admin account. Default credentials are `admin` `P@ssw0rd`

In your first release to production, it's best that you either disable the default account script OR immediately change the admin's password after deployment. Either way, the best practice is to ensure default data by checking and adding, if needed, in [Data/DbContexts/ApplicationDbContextExtensions.cs](/Content/idea42authapi/Data/DbContexts/ApplicationDbContextExtensions.cs)

## Updating the DB
DB Changes, to help you follow the best patterns, should be handled through EF migrations. If you change any of the entities, you'll need to generate a migration for those changes. Do so by by running 
```
dotnet ef migrations add <migration name>
```
replacing `<migration name>` with quick description of your changes. 

## Default Data
Ensuring default data is done in code using this file
[Data/DbContexts/ApplicationDbContextExtensions.cs](/Content/idea42authapi/Data/DbContexts/ApplicationDbContextExtensions.cs)

These checks and inserts get ran on the `dotnet run` command and can be used to ensure you have all the data you need to properly run your application. 

## Using SQL Server (or any other DB server)
Firstly, please be advised that migrations are not cross platform... so if you switch DB's, it's best to delete your migrations and create a new initial migration. But, you can switch out the DB being used by updating [Startup.cs](/Content/idea42authapi/Startup.cs), replacing the following line with whaver support database type EF has for download.
```
options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
```
You'll need to also be sure to update your appsettings.json.

## Authenticating
Using curl for example, you would request a bearer token by calling the following: 

```javascript
curl --request POST \
  --url http://localhost:5000/token \
  --header 'Content-Type: application/x-www-form-urlencoded' \
  --data 'grant_type=password&username=admin&password=P%40ssw0rd'
```

This should return
```javascript
{
	"token_type":"Bearer",
	"access_token":"<bearer token>",
	"expires_in":3600
}
```

Now, just pass in to your header 
```
Authorization:Bearer <bearer token>
```

The application should decode the token, giving you access to whatever data you encoded in the token. For more information, please refer to the documenation at [OpenIddict's](https://github.com/openiddict/openiddict-core) github page.

## Docker

You will need to first install docker.  [Docker Community Edition](https://www.docker.com/community-edition)

Once installed, you can use  `npm run docker`  to build and run a docker container called  `authapiapp`. Once this command completes, you can access the site by hitting  `http://localhost:5000`, unless you tweak the port mapping in the build commands.

## Contributions!

If something doesn't work, or you think we need to change something, please let us know in the issues section!
