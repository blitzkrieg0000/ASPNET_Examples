# ASP.NET ENTITY CORE CHEAT SHEAT
## INSTALL PACKAGES
**Nuget Package Manager or csproj file**
*Major versiyonların 5. olması ASP.NET CORE 5 kullanırken önemli (örnek: "5.0.17")*
```
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="5.0.17"/>
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="5.0.17"/>
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="5.0.17"/>
    <PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="5.0.10"/>
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="5.0.17"/>
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