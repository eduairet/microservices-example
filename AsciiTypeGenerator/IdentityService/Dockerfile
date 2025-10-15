FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY AsciiTypeGenerator.sln .
COPY IdentityService/IdentityService.csproj ./IdentityService/
COPY Contracts/Contracts.csproj ./Contracts/

RUN dotnet restore ./IdentityService/IdentityService.csproj

COPY . .
RUN dotnet publish ./IdentityService/IdentityService.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
EXPOSE 80
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "IdentityService.dll"]