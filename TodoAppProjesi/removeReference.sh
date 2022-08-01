#!/bin/bash
dotnet remove DataAccess/DataAccess.csproj reference Entities/Entities.csproj &&\
dotnet remove Business/Business.csproj reference DataAccess/DataAccess.csproj &&\
dotnet remove Business/Business.csproj reference Dtos/Dtos.csproj &&\
dotnet remove Business/Business.csproj reference Common/Common.csproj && \
dotnet remove UI/UI.csproj reference Business/Business.csproj 
