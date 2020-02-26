#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/SenacSp.ProjetoIntegrador.Web/SenacSp.ProjetoIntegrador.Web.csproj", "src/SenacSp.ProjetoIntegrador.Web/"]
COPY ["src/SenacSp.ProjetoIntegrador.Shared/SenacSp.ProjetoIntegrador.Shared.csproj", "src/SenacSp.ProjetoIntegrador.Shared/"]
COPY ["src/SenacSp.ProjetoIntegrador.Logging/SenacSp.ProjetoIntegrador.Logging.csproj", "src/SenacSp.ProjetoIntegrador.Logging/"]
COPY ["src/SenacSp.ProjetoIntegrador.Web.Config/SenacSp.ProjetoIntegrador.Web.Config.csproj", "src/SenacSp.ProjetoIntegrador.Web.Config/"]
COPY ["src/SenacSp.ProjetoIntegrador.Data/SenacSp.ProjetoIntegrador.Data.csproj", "src/SenacSp.ProjetoIntegrador.Data/"]
COPY ["src/SenacSp.ProjetoIntegrador.Domain/SenacSp.ProjetoIntegrador.Domain.csproj", "src/SenacSp.ProjetoIntegrador.Domain/"]
COPY ["src/SenacSp.ProjetoIntegrador.Infra/SenacSp.ProjetoIntegrador.Infra.csproj", "src/SenacSp.ProjetoIntegrador.Infra/"]
RUN dotnet restore "src/SenacSp.ProjetoIntegrador.Web/SenacSp.ProjetoIntegrador.Web.csproj"
COPY . .
WORKDIR "/src/src/SenacSp.ProjetoIntegrador.Web"
RUN dotnet build "SenacSp.ProjetoIntegrador.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SenacSp.ProjetoIntegrador.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SenacSp.ProjetoIntegrador.Web.dll"]