# ASP.NET ENTITY CORE CHEAT SHEET

## SOLUTION
**Create Solution**
```
    $ dotnet new sln
```

**Create Class Library**
```
    $ dotnet new classlib -o <LibraryName> -f <netVersion>
```

**Create New Project**
```
    $ dotnet new web --name UI -f net5.0
```

**Add Reference**
```
    $ dotnet add /A.csproj reference /B.csproj
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

## INSTALL PACKAGES
*Major versiyonların 5. olması ASP.NET CORE 5 kullanırken önemlidir. (örnek: "5.0.17")*

**Add Package**
```
    $ dotnet add package <PackageName> --version=<versionNumber>
```
*.csproj:*
```
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="5.0.17" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Proxies" Version="5.0.17" /> //LazyLoading
    <PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="5.0.10" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="5.0.17" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="5.0.17" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="5.0.17" />
```


## MIGRATIONS
**Add New Migration**
```
    $ dotnet ef migrations add <MigrationName>   
    
    Not: MigrationName olarak 'InitialCreate' genelde ilk migration için kullanılır.
```
***
**Sync Update Migration**
```
    $ dotnet ef database update
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
