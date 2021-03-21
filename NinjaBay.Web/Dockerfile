#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["NinjaBay.Web/NinjaBay.Web.csproj", "NinjaBay.Web/"]
COPY ["NinjaBay.Web.Config/NinjaBay.Web.Config.csproj", "NinjaBay.Web.Config/"]
COPY ["NinjaBay.Logging/NinjaBay.Logging.csproj", "NinjaBay.Logging/"]
COPY ["NinjaBay.Shared/NinjaBay.Shared.csproj", "NinjaBay.Shared/"]
COPY ["NinjaBay.Infra/NinjaBay.Infra.csproj", "NinjaBay.Infra/"]
COPY ["NinjaBay.Domain/NinjaBay.Domain.csproj", "NinjaBay.Domain/"]
COPY ["NinjaBay.Data/NinjaBay.Data.csproj", "NinjaBay.Data/"]
RUN dotnet restore "NinjaBay.Web/NinjaBay.Web.csproj"
COPY . .
WORKDIR "/src/NinjaBay.Web"
RUN dotnet build "NinjaBay.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NinjaBay.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NinjaBay.Web.dll"]