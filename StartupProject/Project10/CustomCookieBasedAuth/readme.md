# ASP.NET ENTITY CORE CHEAT SHEET

## DEPLOY NEW PROJECT
**.sh dosyası ile ortam oluştur.**
```
	Hızlı bir şekilde yeni bir katmanlı mimari projesi oluşturmak için dotnet-cli komutlarını kullanan ve paketleri en güncel haliyle yükleyen bir "BUILD_NET6.sh" scripti yazıldı. Bu dosya çalıştırıldığı klasörün ismini proje ismi olarak kabul edecek ve klasöre gerekli ortamı kuracaktır. Bu yüzden yeni bir klasör oluşturup içerisinde bu dosyayı çalıştırınız. İnternet bağlantısı ve dotnet-cli toolünün ilgili makinede yüklü olması gereklidir.
```

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
	  Domains -->
 
	$ dotnet add DataAccess/DataAccess.csproj reference Domains/Domains.csproj
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
	$ dotnet sln TodoAppProjesi.sln add Domains/Domains.csproj
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
			"program": "${workspaceFolder}/UI/bin/Debug/net6.0/UI.dll",
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
*omnisharp.json* : *vscode için c# dosyalarının formatını belirler. Ana dizinde olmalıdır veya manuel belirtilmelidir.*
```
{
	"FormattingOptions": {
		"NewLinesForBracesInLambdaExpressionBody": false,
		"NewLinesForBracesInAnonymousMethods": false,
		"NewLinesForBracesInAnonymousTypes": false,
		"NewLinesForBracesInControlBlocks": false,
		"NewLinesForBracesInTypes": false,
		"NewLinesForBracesInMethods": false,
		"NewLinesForBracesInProperties": false,
		"NewLinesForBracesInObjectCollectionArrayInitializers": false,
		"NewLinesForBracesInAccessors": false,
		"NewLineForElse": false,
		"NewLineForCatch": false,
		"NewLineForFinally": false,
		"SpaceBetweenEmptySquareBrackets": false,
		"SpaceBeforeOpenSquareBracket": false,
		"SpaceBetweenEmptyMethodCallParentheses": false,
		"SpaceAfterMethodCallName": false,
		"SpaceBetweenEmptyMethodDeclarationParentheses": false,
		"SpacingAfterMethodDeclarationName": false
	},
	"RoslynExtensionsOptions": {
		"enableAnalyzersSupport": true
	}
}

```
*vscode settings*
```
{
    "files.autoSave": "afterDelay",
    "files.exclude": {
        "**/bin": true,
        "**/obj": true
    },
    "editor.unicodeHighlight.ambiguousCharacters": false,
    "editor.accessibilityPageSize": 12,
    "editor.fontSize": 18,
    "editor.suggest.preview": true,
    "editor.bracketPairColorization.independentColorPoolPerBracketType": true,
    "workbench.iconTheme": "material-icon-theme",
    "workbench.editor.autoLockGroups": {
        "jsProfileVisualizer.cpuprofile.table": true
    },
    "workbench.editor.enablePreviewFromQuickOpen": true,
    "emmet.showSuggestionsAsSnippets": true,
    "emmet.useInlineCompletions": true,
    "emmet.triggerExpansionOnTab": true,
    "emmet.includeLanguages": {
        "aspnetcorerazor": "html, css"
    },
    "explorer.compactFolders": false,
    "C_Cpp.vcFormat.newLine.closeBraceSameLine.emptyFunction": true,
    "C_Cpp.vcFormat.newLine.closeBraceSameLine.emptyType": true,
    "C_Cpp.vcFormat.space.betweenEmptyBraces": true,
    "csharp.referencesCodeLens.enabled": false,
    "omnisharp.enableEditorConfigSupport": false,
    "omnisharp.enableImportCompletion": true,
    "omnisharp.useEditorFormattingSettings": false,
    "omnisharp.enableRoslynAnalyzers": true,
    "omnisharp.organizeImportsOnFormat": true,
    "[aspnetcorerazor]": {
        "editor.defaultFormatter": "ms-dotnettools.csharp"
    },
    "yaml.format.printWidth": 0,
    "html.format.wrapLineLength": 0,
    "audioCues.lineHasInlineSuggestion": "off",
    "commentTranslate.targetLanguage": "tr",
    "dotnet-interactive.minimumDotNetSdkVersion": "6.0",
    "yaml.format.proseWrap": "never"
}
```

## INSTALL PACKAGES
*Major versiyonların "CoreVersion." olması (Yani "6." gibi) ASP.NET CORE kullanırken önemlidir. (örnek: "6.0.17")*

**Add Package**
```
	$ dotnet add package <PackageName> --version=<VersionNumber>
```
*.csproj:*
```
	<PackageReference Include="Microsoft.EntityFrameworkCore" Version="" />            				// DataAccess : Veriye erişim varsa buraya ekle
	<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="" />  				// DataAccess
	<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="" />      				// DataAccess
	<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="" />     				// DataAccess, UI
	<PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="" />    				// DataAccess
	<PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL.Design" Version=""/> 			// DataAccess
	<PackageReference Include="Microsoft.EntityFrameworkCore.Proxies" Version="" />    				// DataAccess, (LazyLoading)
	<PackageReference Include="AutoMapper" Version="" /> 								 			// Business, UI
	<PackageReference Include="FluentValidation" Version="" />                         				// Business	: Yapılacak iş yükü varsa buraya ekle
	<PackageReference Include="FluentValidation.DependencyInjectionExtensions" Version="" /> 		// Business
	<PackageReference Include="Microsoft.EntityFrameworkCore.Relational" Version="" /> 				// Business
	<PackageReference Include="Microsoft.AspNetCore.Identity" Version="" />							// DataAccess
	<PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="" /> 	// DataAccess
	<PackageReference Include="AutoMapper.Extensions.Microsoft.DependencyInjection" Version="" /> 	// Business
	<PackageReference Include="Google.Protobuf" Version="" />										// Business
    <PackageReference Include="Grpc.AspNetCore" Version="" />										// Business
    <PackageReference Include="Grpc.Net.Client" Version="" />										// Business
    <PackageReference Include="Grpc.Tools" Version="">												// Business
	<PackageReference Include="Microsoft.AspNetCore.SignalR" Version="" />							// Business
```

## SCAFFOLD PostgreSQL
```
	dotnet ef dbcontext scaffold "Host=localhost;Database=aspnetcore;Username=aspnetcore;Password=aspnetcore" Npgsql.EntityFrameworkCore.PostgreSQL -o ../Entities/Scaffold/ --project UI/UI.csproj
```

## MIGRATIONS
**Add New Migration**
```
	$ dotnet ef migrations add <MigrationName> --output <MigrationsFolderPath> -s <StartupProjectName>  // Project klasörününde belirtilmesi gerekebilir.
	Not: MigrationName olarak 'InitialCreate' genelde ilk migration için kullanılır.
	Not: DataAccess'de yapılır. DataAccessLayer ve UI, "Microsoft.EntityFrameworkCore.Design" Paketine ihtiyaç duyar.
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

## DOTNET PUBLISH

*UI'ın F# dosyasını boş bir klasöre kopyalayın ve "dotnet restore" komutunu çağırın*
```
F# Dosyası : UI/*.csproj
dotnet restore
```
*Tüm proje katmanlarını ve ana klasörünü UI.csproj dosyasını attığınız yere kopyalayın*
*Publish komutlarını çağırın*
*"--self-contained true" parametresi hedef cihazda .NETRuntime kurulu olmasa bile; programın çalışabilmesi için programı yapılandıracaktır.*
```
Tüm Proje : WebApp/*
build UI/UI.csproj -o /app -r linux-x64 /p:PublishReadyToRun=true
dotnet publish UI/UI.csproj -o /publish -r linux-x64 --self-contained true --no-restore p:PublishTrimmed=true /p:PublishReadyToRun=true /p:PublishSingleFile=true
```
*Derlenmiş "publish" klasörünüzü projeyi çalıştıracağınız yere kopyalayın.*
*"npm install" ile varsa yeniden "node_modules" klasörünüzü oluşturun*

*Artık projeyi dll veya exe üzerinden ayağa kaldırabilirsiniz.*
*Projeyi ayağa kaldırmak için, kendi senaryonuza uygun ilgili komutları Microsoft'un kendi sitesinden okuyunuz.*