FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app

ENV ASPNETCORE_Environment=Production

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
RUN heroku addons:create heroku-postgresql:hobby-dev
WORKDIR /src
COPY ["NinjaBay.Web/NinjaBay.Web.csproj", "NinjaBay.Web/"]
RUN dotnet restore "NinjaBay.Web/NinjaBay.Web.csproj"
COPY . .
WORKDIR "/src/NinjaBay.Web"

RUN dotnet build "NinjaBay.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NinjaBay.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet NinjaBay.Web.dll
