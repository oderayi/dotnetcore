# VS Tip
`Ctrl + .` for intellisence of dotnetcore helpful snippets and code completion
`prop` tab tab: To generate class property
`propa`, `propfull`, `propg`


# Dotnet Commands
dotnet
dotnet --help
dotnet new (lists all project templates)
dotnet new --help (help for new command)
dotnet new console --help (help for console app)

## To create a new console app:
dotnet new console appname

## To create a new app (into another directory):
dotnet new web -o mywebapp
appname.csprog is where all package references are stored
dotnet build (to build)
dotnet run (To run the application)

## MVC
To add MVC capability to a normal "web" template project:
- Open Startup, under ConfigureServices: add services.AddMvc()
  under Configure: add app.UseMvc()

Add the root level: add "Pages" folder
Under pages, add "index.cshtml" (Razor page) and other cshtml files
Razor pages edit does not require recompilling, just refresh browser.
Razor pages must start with: `@page`

To add dynamic date to Razor, @DateTime.Now or block:

```csharp
@{
var i = 2 + 2
}
```

In Razor:
`The time is @i pm.`

Static Files:
 We can make dotnet serve static files like "aboutus.html" (not containing @page directive) by adding:
 `app.UseStaticFiles()` middleware to Statup->Configure method.

dotnet publish (To publish project)

## App Specific Configuration
Add appsettings.json to the root of the app dir.
To import the setting, in Startup.cs add constructor method:

```csharp
public IConfiguration Configuration { get; set; }
  public Startup(IConfiguration config)
  {
    Configuration = config;
  }
```
config will be passed in through Dependency Injection.
You can have `appsettings.Development.json` and other variations.

I can use this Configuration in my Razor page too, I only have to Inject it:
@using Microsoft.Extensions.Configuration
@inject IConfiguration Configuration

## _ViewImports.cshtml
I can combine all of the `@using` imports, `@namespace` etc. that I want all my razor pages to have in one file called `_ViewImports.cshtml` under `Pages` folder.

## _ViewStart.cshtml
This runs for every view. There you can specify things like the parent layout.

## DB Context
In Startup:
 - Add `using Microsoft.EntityFramework` 
 - `services.AddDbContext<YourDBContextClassName>()` in ConfigureService

