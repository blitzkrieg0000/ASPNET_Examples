#!/bin/bash
dotnet ef migrations add InitialCreate -o Migrations --project DataAccess.csproj -s ../UI/UI.csproj