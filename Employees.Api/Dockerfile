#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:3.1-bionic AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/aspnet:3.1-bionic AS build
#WORKDIR /src
#COPY . .
#RUN dotnet restore "./Employees.Api.csproj"
#COPY . .
#WORKDIR "/src/."
#RUN dotnet build "Employees.Api.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "Employees.Api.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Employees.Api.dll"]

#  FROM mcr.microsoft.com/dotnet/aspnet:3.1-bionic
FROM mcr.microsoft.com/dotnet/aspnet:3.1-bionic
COPY bin/netcoreapp3.1/publish/ App/
WORKDIR /App
EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "Employees.Api.dll"]