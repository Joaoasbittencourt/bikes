FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app/api

RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"
ENV ASPNETCORE_ENVIRONMENT=Development

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "mottu.dll"]
