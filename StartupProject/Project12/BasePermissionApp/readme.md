# ASP.NET ENTITY CORE CHEAT SHEET
 
</br>

***

## DOTNET CLI


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

**Add Package**
*Major versiyonların "CoreVersion." olması (Yani "8." gibi) ASP.NET CORE kullanırken önemlidir. (örnek: "8.0.17")*
```
	$ dotnet add package <PackageName> --version=<VersionNumber>
```
*.csproj dosyasında yüklü paketler şu şekilde görünürler:*
```
	<PackageReference Include="Microsoft.EntityFrameworkCore" Version="" />
	<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="" />
	<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="" />
	<PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="" />
	<PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL.Design" Version=""/>
	<PackageReference Include="Microsoft.EntityFrameworkCore.Proxies" Version="" />
	<PackageReference Include="AutoMapper" Version="" />
	<PackageReference Include="FluentValidation" Version="" />
	<PackageReference Include="FluentValidation.DependencyInjectionExtensions" Version="" />
	<PackageReference Include="Microsoft.EntityFrameworkCore.Relational" Version="" />
	<PackageReference Include="AutoMapper.Extensions.Microsoft.DependencyInjection" Version="" />
```

**Add Projects To SLN**
```
	$ dotnet sln <sln> add <csproj>
```

</br>

***

## Scaffold PostgreSQL
**Veri tabanındaki tabloları ve ayarları EntityFramework'ün anlayacağı şekilde C# kodu üretmeye yarar**
```
	dotnet ef dbcontext scaffold "Host=localhost;Database=aspnetcore;Username=aspnetcore;Password=aspnetcore" Npgsql.EntityFrameworkCore.PostgreSQL -o ../../Infrastructure/Persistence/Scaffold --project ./Onion/Presentation/UI/UI.csproj
```

## Add Migration
*MigrationName olarak 'InitialCreate' genelde ilk migration için kullanılır.*
*"Microsoft.EntityFrameworkCore.Design" paketine ihtiyaç duyulur.*
*Eğer ClassLib assembly sinde isek, classlibler entrypointlere sahip olmadığından, veri tabanı bağlantı ayarları gibi ayarları programın bilemeyeceği için 'Design Time Db Context Factory' isimli bir yapıya ihtiyacımız vardır.*
```
	$ dotnet ef migrations add <MigrationName> --output <MigrationsFolderPath>
```

## Update Database with Migrations
*Güncellenmeyen migrationları veri tabanına aktarır. Eğer ilgili sql veri tabanında mevcutsa hata verecektir.*
```
	$ dotnet ef database update
```

**Create SQL Query Script**
```
dotnet ef migrations script --output "Sql/migration.sql" --idempotent
```

**List Available Migration**
```
	$ dotnet ef database list
```

**Remove Pending Migration**
```
	$ dotnet ef database remove
```

</br>

***

## Publish
*1-Ana proje boş bir klasöre kopyalanır ve "dotnet restore" komutunu çağrılır. Bu komut dependecyleri güncelleyecek ve projeye ekleyecektir.*
```
	$ dotnet restore
```

***
*2-Proje build edilir ve 'error' alınmadığından emin olunur.*
*Proje linux-x64 mimarisinde derleniyor çünkü docker imajları %99 çekirdeksiz linux üzerine kuruludur.*
```
	$ dotnet build ./Onion/Presentation/UI/UI.csproj -o ./build -r linux-x64 /p:PublishReadyToRun=true /p:GenerateFullPaths=true
```

***
*3-Proje Publish edilerek .NET in bize sunduğu kod optimizasyonu gerçekleştirilir ve tüm kütüphanaler bir bütün haline getirilir.*
*"--self-contained true" parametresi hedef cihazda .NET Runtime kurulu olmasa bile; programın çalışabilmesi için programı yapılandıracaktır. Yine de .NET RUNTIME kurulu olması iyi olur.*
```
dotnet publish ./Onion/Presentation/UI/UI.csproj -c Release -o ./publish -r linux-x64 --self-contained true --no-restore /p:PublishTrimmed=true /p:PublishReadyToRun=true /p:PublishSingleFile=true
```
***
*4-Proje publish olduktan sonra publish klasöründe yalnızca projenin ayarlarını yapabileceğimiz ".json" dosyaları ve 'wwwroot' klasörü mevcuttur. Eğer proje içinde dosya işlemleri gerçekleştiriliyorsa bu klasör ile etkileşime geçilir. Hassas bilgiler application.json veya development.json gibi dosyalardan çıkarılır ve environment variable'lar ile projeye geçirilmek üzere saklanır.
Eğer EnvironmentVariable'larda (ortam değişkenlerinde) ilgili değerler yoksa bu secret.json, orada da yoksa application.json dosyalarında aranır.*

***
*5-Projede npm paketleri kullanılmışsa, proje derlendikten sonra dışarıda kalan package.json gibi dosyalar aracılığı ile 'npm install' komutu ile node_modules klasörü oluşturulur.*

***
*6-Projede senaryoya göre ek işlemler yapılır. Uygulama derlenen binary dosyasından(bizim senaryomuzda 'UI' executable dosyası) çalışmaya hazırdır.*

</br>

***

## VSCODE SETTINGS

**BUILD**
*1- tasks.json ve launch.json dosyası .vscode klsörüne eklenir:*
*2- SLN dosyasının olduğu yerde "dotnet build" ile ilk derlemeyi yaparız.*

***
*launch.json:*
```
{
	// Use IntelliSense to learn about possible attributes.
	// Hover to view descriptions of existing attributes.
	// For more information, visit: https://go.microsoft.com/fwlink/?linkid=830387
	"version": "0.2.0",
	"configurations": [
		{
			"name": ".NET Core Launch (console)",
			"type": "coreclr",
			"request": "launch",
			"preLaunchTask": "build",
			"program": "${workspaceFolder}/Onion/Presentation/UI/bin/Debug/net6.0/UI.dll",
			"args": [],
			"cwd": "${workspaceFolder}/Onion/Presentation/UI",
			"stopAtEntry": false,
			"serverReadyAction": {
				"action": "openExternally",
				"pattern": "\\bNow listening on:\\s+(https?://\\S+)"
			},
			"env": {
				"ASPNETCORE_ENVIRONMENT": "Development"
			},
			"sourceFileMap": {
				"/Views": "${workspaceFolder}/Onion/Presentation/UI/Views"
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

***
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
				"${workspaceFolder}/Onion/Presentation/UI/UI.csproj",
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
				"${workspaceFolder}/Onion/Presentation/UI/UI.csproj",
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
				"${workspaceFolder}/Onion/Presentation/UI/UI.csproj"
			],
			"problemMatcher": "$msCompile"
		}
	]
}
```

***
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

***
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
	"yaml.format.proseWrap": "never",
	"gitlens.codeLens.authors.enabled": false,
	"gitlens.codeLens.recentChange.enabled": false,
	"git.openRepositoryInParentFolders": "never",
	"explorer.autoReveal": false,
	"debug.onTaskErrors": "showErrors",
	"[python]": {
		"editor.formatOnType": true
	},
	"editor.minimap.maxColumn": 50,
	"csharpextensions.useFileScopedNamespace": true,
	"audioCues.notebookCellCompleted": "off",
	"audioCues.taskCompleted": "off",
	"files.associations": {
		"*.csproj": "xml"
	},
	"redhat.telemetry.enabled": false,
	"terminal.integrated.inheritEnv": false
}
```

