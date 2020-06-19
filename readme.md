# 2C2P: Software Architect Technical Assignment
Implement a service to upload transaction data from CSV and XML file into database
and query transactions by specified criteria.

- by Currency: ISOCurrency format
- by Date range: format dd/MM/yyyy 
- by Status: A/R/D

## Technologies
* [.NET Core 3.1](https://dotnet.microsoft.com/download)
* [ASP.NET Core 3.1](https://docs.microsoft.com/en-us/aspnet/core)
* [Entity Framework Core 3.1](https://docs.microsoft.com/en-us/ef/core)
* [Nunit 3](https://nunit.org/)
* [Moq 4](https://github.com/moq/moq4)
* [log4net](http://logging.apache.org/log4net/)

## Layers
**Web:** API and Frontend.

**Services:** This layer to isolate between the controller and business logic.

**Business Logic:** This layer will handle business logic.

**Data Access:** DataAccess(DbContext) and Repository.
This layer will handle the data from the database for produces/consumes to the repository.

**Domain:** Domain object.

**Views:** ViewModels, Mapping data
