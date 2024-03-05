FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

ENV ASPNETCORE_ENVIRONMENT=Development

COPY api/*.csproj ./api/
RUN dotnet restore "./api/bikes.csproj"

COPY api/ ./api/
WORKDIR /app/api
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/api/out .
ENTRYPOINT ["dotnet", "bikes.dll"]
