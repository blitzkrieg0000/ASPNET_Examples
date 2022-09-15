# ASP.NET ENTITY CORE CHEAT SHEET

## SOLUTION
**Create Solution**
```
	$ dotnet new sln
```

**Create Class Library**
```
	$ dotnet new classlib -o <LibraryName> -f <NetVersion>
```

**Create New Project**
```
	$ dotnet new web --name <ProjectName> -f <NetVersion>
```

**Add Reference**
```
	$ dotnet add <A_ProjectName> reference <B_ProjectName>
```
*Example:*
```
	DEPENDENCIES:
						  Dtos -->
								  |
	  ---------------> DataAccess --> Business --> UI
				  |
	  Entities -->
 
	$ dotnet add DataAccess/DataAccess.csproj reference Entities/Entities.csproj
	$ dotnet add Business/Business.csproj reference DataAccess/DataAccess.csproj
	$ dotnet add Business/Business.csproj reference Dtos/Dtos.csproj
	$ dotnet add UI/UI.csproj reference Business/Business.csproj
```
**Add Projects To SLN**
```
	$ dotnet sln <SLN_NAME> add <ProjectName>
```
*Example:*
```
	$ dotnet sln TodoAppProjesi.sln add UI/UI.csproj
	$ dotnet sln TodoAppProjesi.sln add Business/Business.csproj 
	$ dotnet sln TodoAppProjesi.sln add DataAccess/DataAccess.csproj
	$ dotnet sln TodoAppProjesi.sln add Dtos/Dtos.csproj
	$ dotnet sln TodoAppProjesi.sln add Entities/Entities.csproj
```
**BUILD**

*1-) tasks.json ve launch.json dosyası .vscode klsörüne eklenir:*
*2-) SLN dosyasının olduğu yerde "dotnet build" ile ilk derlemeyi yaparız.*

*launch.json:*
```
{
	"version": "0.2.0",
	"configurations": [
		{
			// Use IntelliSense to find out which attributes exist for C# debugging
			// Use hover for the description of the existing attributes
			// For further information visit https://github.com/OmniSharp/omnisharp-vscode/blob/master/debugger-launchjson.md
			"name": ".NET Core Launch (web)",
			"type": "coreclr",
			"request": "launch",
			"preLaunchTask": "build",
			// If you have changed target frameworks, make sure to update the program path.
			"program": "${workspaceFolder}/UI/bin/Debug/net5.0/UI.dll",
			"args": [],
			"cwd": "${workspaceFolder}/UI",
			"stopAtEntry": false,
			// Enable launching a web browser when ASP.NET Core starts. For more information: https://aka.ms/VSCode-CS-LaunchJson-WebBrowser
			"serverReadyAction": {
				"action": "openExternally",
				"pattern": "\\bNow listening on:\\s+(https?://\\S+)"
			},
			"env": {
				"ASPNETCORE_ENVIRONMENT": "Development"
			},
			"sourceFileMap": {
				"/Views": "${workspaceFolder}/Views"
			}
		},
		{
			"name": ".NET Core Attach",
			"type": "coreclr",
			"request": "attach"
		}
	]
}

```
*tasks.json:*
```
{
	"version": "2.0.0",
	"tasks": [
		{
			"label": "build",
			"command": "dotnet",
			"type": "process",
			"args": [
				"build",
				"${workspaceFolder}/UI/UI.csproj",
				"/property:GenerateFullPaths=true",
				"/consoleloggerparameters:NoSummary"
			],
			"problemMatcher": "$msCompile"
		},
		{
			"label": "publish",
			"command": "dotnet",
			"type": "process",
			"args": [
				"publish",
				"${workspaceFolder}/UI/UI.csproj",
				"/property:GenerateFullPaths=true",
				"/consoleloggerparameters:NoSummary"
			],
			"problemMatcher": "$msCompile"
		},
		{
			"label": "watch",
			"command": "dotnet",
			"type": "process",
			"args": [
				"watch",
				"run",
				"--project",
				"${workspaceFolder}/UI/UI.csproj"
			],
			"problemMatcher": "$msCompile"
		}
	]
}
```

## INSTALL PACKAGES
*Major versiyonların 5. olması ASP.NET CORE 5 kullanırken önemlidir. (örnek: "5.0.17")*

**Add Package**
```
	$ dotnet add package <PackageName> --version=<VersionNumber>
```
*.csproj:*
```
	<PackageReference Include="Microsoft.EntityFrameworkCore" Version="5.0.17" />            		// DataAccess
	<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="5.0.17" />  		// DataAccess
	<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="5.0.17" />      		// DataAccess
	<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="5.0.17" />     		// DataAccess, UI
	<PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="5.0.10" />    		// DataAccess
	<PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL.Design" Version="1.1.0"/> 		// DataAccess
	<PackageReference Include="Microsoft.EntityFrameworkCore.Proxies" Version="5.0.17" />    		// DataAccess, (LazyLoading)
	<PackageReference Include="AutoMapper" Version="11.0.1" /> 								 		// Business, UI
	<PackageReference Include="FluentValidation" Version="11.1.0" />                         		// Business
	<PackageReference Include="FluentValidation.DependencyInjectionExtensions" Version="11.1.0" /> 	// Business
	<PackageReference Include="Microsoft.EntityFrameworkCore.Relational" Version="5.0.17" /> 		// Business
	
	
	//Identity
	<PackageReference Include="Microsoft.AspNetCore.Identity" Version="2.2.0" />
	<PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="5.0.17" /> //İçerisinde EFCore Var
	<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="5.0.17" />
	<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="5.0.17" />

	//API
	<PackageReference Include="Microsoft.AspNetCore.Mvc.NewtonsoftJson" Version="5.0.17" />	 		//ServerSide
	<PackageReference Include="Newtonsoft.Json" Version="13.0.1" />                          		//ClientSide
	
	//JWT
	<PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="5.0.17" />   //ServerSide
```

## SCAFFOLD 
```
	dotnet ef dbcontext scaffold "Host=localhost;Database=tenis;Username=tenis;Password=2sfcNavA89A294V4" Npgsql.EntityFrameworkCore.PostgreSQL -o ../Entities/Scaffold/ --project UI/UI.csproj
```

## MIGRATIONS
**Add New Migration**
```
	$ dotnet ef migrations add <MigrationName> --output <MigrationsFolderPath> -s <StartupProjectName>
	Not: MigrationName olarak 'InitialCreate' genelde ilk migration için kullanılır.
	Not: DataAccess de yapılır. DataAccessLayer, UI da "Design" Paketine ihtiyaç duyar.
```
***
**Sync Update Migration**
```
	$ dotnet ef database update -s <StartupProjectName>
```
***
**List Available Migration**
```
	$ dotnet ef database list
```
***
**Remove Pending Migration**
```
	$ dotnet ef database remove
```
