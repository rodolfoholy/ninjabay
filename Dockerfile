FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app

ENV ASPNETCORE_Environment=Production

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["SenacSp.ProjetoIntegrador.Web/SenacSp.ProjetoIntegrador.Web.csproj", "SenacSp.ProjetoIntegrador.Web/"]
RUN dotnet restore "SenacSp.ProjetoIntegrador.Web/SenacSp.ProjetoIntegrador.Web.csproj"
COPY . .
WORKDIR "/src/SenacSp.ProjetoIntegrador.Web"

RUN dotnet build "SenacSp.ProjetoIntegrador.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SenacSp.ProjetoIntegrador.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet SenacSp.ProjetoIntegrador.Web.dll
#ENTRYPOINT ["dotnet", "SenacSp.ProjetoIntegrador.Web.dll"]