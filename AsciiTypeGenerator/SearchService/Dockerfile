FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY AsciiTypeGenerator.sln .
COPY SearchService/SearchService.csproj ./SearchService/
COPY Contracts/Contracts.csproj ./Contracts/

RUN dotnet restore ./SearchService/SearchService.csproj

COPY . .
RUN dotnet publish ./SearchService/SearchService.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
EXPOSE 80
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SearchService.dll"]