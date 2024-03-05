# Bike Rental API

### Considerações
- O projeto foi desenvolvido ultizando um Mac , portanto tentei criar um setup que pudesse ser executado em qualquer ambiente.
- Evitei utilizar o Visual Studio uma vez que já está deprecado para mac.
- O projeto tinha muitos requisitos e eu tentei focar em entregar o que foi pedido, entretanto nem todas as features foram implementadas.
- Gosto de programar com testes, mas preferi maximizar a entrega visto que é desafio.
- Resolvi experimentar o EF ao invés de utilizar SQL puro ou Nhibernate (o que eu estou mais acostumado).
- Nas "Features" eu listei o que foi feito e o que não foi feito (e que pretendia fazer caso continuasse o projeto).

### How to run

Run Everything:
docker compose --profile default up

Run Infra only:
docker compose --profile infra up

Create Migrations:
dotnet ef migrations add MigrationName

Run migrations:
dotnet ef database update

### Features

- [x] Bikes
  - [x] Create [Bike]
  - [x] List [Bike] filter by [Bike].plate
  - [x] Update [Bike].plate
  - [x] Remove [Bike]
- [x] Riders
  - [x] Create [Rider]
  - [x] Update [Rider].[cnhPhotoUrl]
- [x] Upload Image
  - [x] Minio setup on docker-compose
  - [x] Uploading image file -> url
- [ ] Rentals
  - [x] RentalPlans [RentalPlan]
  - [x] Create [Rental].
  - [x] Block Remove [Bike] if [Bike].[Rental] is active
  - [x] Only [Bike] that are not rented can be rented
  - [x] Calculate Return Price with fees
- [ ] Orders
  - [ ] Create Order
  - [ ] Accept Order
  - [ ] Finish Order
- [ ] Notifications
  - [ ] Add RabbitMQ instance to docker-compose
  - [ ] Create consumer that saves to db
  - [ ] Get notified riders
  - [ ] Notify Riders when a new bike is available
- [ ] Project setup
  - [x] docker-compose setup
  - [x] minio setup
  - [ ] rabbitmq setup
  - [x] ef core setup with postgres
  - [x] migrations

### If There is Time
- [ ] Auth
  - [ ] define what is possible for Riders and Admins, with Identity
- [ ] Tests
  - [ ] Unit
  - [ ] Integration
- [ ] Frontend

### Pending Refactors / Optimizations
- [ ] Move logic from controllers to services
- [ ] Rename [Bike] to [Vehicle]?
- [ ] Optimize Data access
- [ ] Move bucket creation to a docker-compose service

### Definitions
- [Bike]
  - id
  - plate(unique)
  - model
  - year
- [Rider]
  - id
  - name
  - cnpj(unique)
  - birthdate
  - cnhNumber(unique)
  - cnhType("A", "B", "A+B")
  - cnhPhotoUrl
- [Rental]
  - id
  - bikeId(only one bike per rental)
  - riderId
  - planId
  - endAt
- [RentalPlans]
  - 7 days, price per day 30
  - 15 days, price per day 28
  - 30 days, price per day 22

