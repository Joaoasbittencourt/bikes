
Run DB:
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
  - [ ] RentalPlans [RentalPlan].[id, name, pricePerDay, durationDays]
  - [ ] Create [Rental].[id, bikeId(only one bike per rental), riderId, planId, endAt]
  - [ ] Block Remove [Bike] if [Bike].[Rental] is active
- [ ] Return
  - [ ] Calculate Return Price [Rental].[id] -> price
  - [ ] Return Delay fee
- [ ] Orders
  - [ ] get notified riders
  - [ ] accept order
  - [ ] finish order
- [ ] Notifications
  - [ ] Add RabbitMQ instance to docker-compose
  - [ ] Create consumer that saves to db
  - [ ] Notify Riders when a new bike is available
- [ ] If There is Time
  - [ ] Authorization
    - [ ] define what is possible for Riders and Admins
  - [ ] Tests
    - [ ] Unit
    - [ ] Integration
  - [ ] Frontend


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
- [RentalPlans]
  - 7 days, price per day 30
  - 15 days, price per day 28
  - 30 days, price per day 22
