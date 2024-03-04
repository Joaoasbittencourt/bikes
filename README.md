
Run DB:
docker compose --profile infra up

Create Migrations:
dotnet ef migrations add InitialCreate


Run migrations:
dotnet ef database update
