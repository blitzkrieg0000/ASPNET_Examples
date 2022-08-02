#!/bin/bash
dotnet new sln &&\
dotnet new classlib -o Business -f net5.0 &&\
dotnet new classlib -o Common -f net5.0 &&\
dotnet new classlib -o DataAccess -f net5.0 &&\
dotnet new classlib -o Dtos -f net5.0 &&\
dotnet new classlib -o Entities -f net5.0 &&\
dotnet new web --name UI -f net5.0 &&\
#dotnet add DataAccess/DataAccess.csproj package Microsoft.EntityFrameworkCore.SqlServer --version=5.0.17 &&\
#dotnet add DataAccess/DataAccess.csproj package Microsoft.EntityFrameworkCore.Proxies --version=5.0.17 &&\
dotnet add DataAccess/DataAccess.csproj package Npgsql.EntityFrameworkCore.PostgreSQL --version=5.0.10 &&\
dotnet add DataAccess/DataAccess.csproj package Microsoft.EntityFrameworkCore --version=5.0.17 &&\
dotnet add DataAccess/DataAccess.csproj package Microsoft.EntityFrameworkCore.Design --version=5.0.17 &&\
dotnet add UI/UI.csproj package Microsoft.EntityFrameworkCore.Design --version=5.0.17 &&\
dotnet add DataAccess/DataAccess.csproj package Microsoft.EntityFrameworkCore --version=5.0.17 &&\
dotnet add Business/Business.csproj package AutoMapper &&\
dotnet add UI/UI.csproj package AutoMapper &&\
dotnet add Business/Business.csproj package FluentValidation &&\
dotnet add Business/Business.csproj package FluentValidation.DependencyInjectionExtensions  &&\
dotnet sln TennisWeb.sln add UI/UI.csproj &&\
dotnet sln TennisWeb.sln add Business/Business.csproj &&\
dotnet sln TennisWeb.sln add DataAccess/DataAccess.csproj &&\
dotnet sln TennisWeb.sln add Dtos/Dtos.csproj &&\
dotnet sln TennisWeb.sln add Entities/Entities.csproj &&\
dotnet sln TennisWeb.sln add Common/Common.csproj
dotnet add DataAccess/DataAccess.csproj reference Entities/Entities.csproj &&\
dotnet add Business/Business.csproj reference DataAccess/DataAccess.csproj &&\
dotnet add Business/Business.csproj reference Dtos/Dtos.csproj &&\
dotnet add Business/Business.csproj reference Common/Common.csproj &&\
dotnet add UI/UI.csproj reference Business/Business.csproj