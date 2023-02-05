#!/bin/bash
dotnet add DataAccess/DataAccess.csproj reference Entities/Entities.csproj &&\
dotnet add Business/Business.csproj reference DataAccess/DataAccess.csproj &&\
dotnet add Business/Business.csproj reference Dtos/Dtos.csproj &&\
dotnet add Business/Business.csproj reference Common/Common.csproj &&\
dotnet add UI/UI.csproj reference Business/Business.csproj


