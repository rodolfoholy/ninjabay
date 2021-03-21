FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build_env
# FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine AS build_env
WORKDIR build

# copy sln solution
COPY ./*.sln ./

# copy all .csproj and restore
COPY ./*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ./${file%.*}/ && mv $file ./${file%.*}/; done

#COPY ./tests/*/*.csproj ./
#RUN for file in $(ls *.csproj); do mkdir -p tests/${file%.*}/ && mv $file ./tests/${file%.*}/; done

RUN ["dotnet", "restore"]

COPY . ./ 

# run tests
#WORKDIR /build/tests/PayRentee.Tests
#RUN dotnet build PayRentee.Tests.csproj -c Release
#RUN dotnet test PayRentee.Tests.csproj

# restore and build app
WORKDIR /build/NinjaBay.Web
RUN dotnet publish -c Release -o out
RUN ["dotnet", "publish", "-c", "Release", "-o", "/build/publish", "--no-restore"]

#run app
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build_env /build/publish .

EXPOSE 5050
ENTRYPOINT ["dotnet", "NinjaBay.Web.dll"]