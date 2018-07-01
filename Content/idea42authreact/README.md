
  

# `dotnet new authreactjs`

  

Creates a combo application that implements the ReactJS template and the AuthAPI template together as one application. This application will run on its own without having a seperate API. Use this to rapidly prototype applications without needing to have a seperate API.

  

This template includes a simple login page and necessary ReactJS components, managers and service implementations to handle authentication. Note that even though Authentication is handled in ReactJS, ALWAYS PUT SAFEGUARDS IN YOUR API!

  

## For Development

  

You can use the following to run your application during development.

-  `dotnet build` then `dotnet run`

  

Though you can use `npm run start`, you won't have access to the API.

  

Any changes to your application will require you to rerun the commands above unless you set up a file watcher to automatically rebuild after file changes.

  

## First Time Use

Since we are using entity framework to build the API, you'll need to generate your first migration on your own. To do this, run:

```

dotnet ef migrations add initial

```

On `dotnet run`, the application will run the migration and add three roles and a default admin account. Default credentials are `admin`  `P@ssw0rd`

  

In your first release to production, it's best that you either disable the default account script OR immediately change the admin's password after deployment. Either way, the best practice is to ensure default data by checking and adding, if needed, in [Data/DbContexts/ApplicationDbContextExtensions.cs](/Content/idea42authreact/Data/DbContexts/ApplicationDbContextExtensions.cs)

  

## Updating the DB

DB Changes, to help you follow the best patterns, should be handled through EF migrations. If you change any of the entities, you'll need to generate a migration for those changes. Do so by by running

```

dotnet ef migrations add <migration name>

```

replacing `<migration name>` with quick description of your changes.

  

## Default Data

Ensuring default data is done in code using this file

[Data/DbContexts/ApplicationDbContextExtensions.cs](/Content/idea42authreact/Data/DbContexts/ApplicationDbContextExtensions.cs)

  

These checks and inserts get ran on the `dotnet run` command and can be used to ensure you have all the data you need to properly run your application.

  

## Using SQL Server (or any other DB server)

Firstly, please be advised that migrations are not cross platform... so if you switch DB's, it's best to delete your migrations and create a new initial migration. But, you can switch out the DB being used by updating [Startup.cs](/Content/idea42authreact/Startup.cs), replacing the following line with whaver support database type EF has for download.

```

options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));

```

You'll need to also be sure to update your appsettings.json.

  

## Authenticating

Using curl for example, you would request a bearer token by calling the following:

  

```javascript

curl --request  POST \

--url http://localhost:3000/token \

--header  'Content-Type: application/x-www-form-urlencoded' \

--data  'grant_type=password&username=admin&password=P%40ssw0rd'

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

  

## Authentication Components of ReactJS

Protecting routes happens on the page level in our implementation. By extending `AuthenticatedPage`,  your page will redirect to the configured `loginRoute` if it doesn't detect a bearer token in the store.

For example: 
```jsx
import AuthManager from '../../managers/authManager';
class ProtectedPage extends AuthenticatedPage {
 // Implement Page Here
}
export  default  ProtectedPage;
```

```jsx
import { Component } from 'react';
class UnprotectedPage extends Component {
 // Implement Page Here
}
export  default  UnprotectedPage;
```  
When dealing with the authentication, use the AuthManager. 

Include it anywhere you want to use it!
```jsx
import  AuthManager  from  '../../managers/authManager';
```
You can get access to the singleton by calling:
```jsx
var authManager = AuthManager.getInstance();
```
You can extend this to your liking to extract out data from the store regarding authentication.

If you need to log out, you can do so by calling: 
```jsx
var authManager = AuthManager.getInstance();
authManager.logOut();
```

Calling logout will notify all its subscribers (like the AuthenticatedPages) and force them to direct you to the `loginRoute`

## Docker

  

You will need to first install docker. [Docker Community Edition](https://www.docker.com/community-edition)

  

Once installed, you can use `npm run docker` to build and run a docker container called `authreactapp`. Once this command completes, you can access the site by hitting `http://localhost:3000`, unless you tweak the port mapping in the build commands.

  

## Contributions!

  

If something doesn't work, or you think we need to change something, please let us know in the issues section!