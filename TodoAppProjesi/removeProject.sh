#!/bin/bash
dotnet sln TodoAppProjesi.sln remove UI/UI.csproj &&\
dotnet sln TodoAppProjesi.sln remove Business/Business.csproj &&\
dotnet sln TodoAppProjesi.sln remove DataAccess/DataAccess.csproj &&\
dotnet sln TodoAppProjesi.sln remove Dtos/Dtos.csproj &&\
dotnet sln TodoAppProjesi.sln remove Entities/Entities.csproj &&\
dotnet sln TodoAppProjesi.sln remove Common/Common.csproj