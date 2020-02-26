FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_Environment=Production
#ENV ASPNETCORE_URLS=http://*:80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY . .


CMD ASPNETCORE_URLS=http://*:$PORT dotnet SenacSp.ProjetoIntegrador.Web.dll
#ENTRYPOINT ["dotnet", "SenacSp.ProjetoIntegrador.Web.dll"]