<h1 align="center">api-base-net8</h1>

<p align="center">
  <img src="https://img.shields.io/badge/.NET-8.0-blue" alt=".NET">
  <img src="https://img.shields.io/badge/SQLite-3-blue" alt="SQLite">
  <img src="https://img.shields.io/badge/Architecture-Layered-orange" alt="Architecture">
</p>

This project serves as a template for .NET 8 APIs, following Clean Architecture principles. It includes a basic authentication and authorization flow, providing a robust and scalable structure for building secure APIs.

Frontend repository: https://github.com/AugustoOmena/Frontend-api-base-net8

## Features

- **Layered Architecture**: clear separation of concerns between layers.
- **.NET 8.0**: modern runtime and tooling.
- **SQLite**: local database for fast setup.
- **Extensible**: easy to adapt for different API scenarios.
- **Best Practices**: dependency injection and repository pattern.

## Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/download)
- [Entity Framework Core tools](https://learn.microsoft.com/ef/core/cli/dotnet)

## How to run (current setup with SQLite)

1. Restore dependencies:

   ```bash
   dotnet restore
   ```

2. Confirm connection string in `WebAppBase.API/appsettings.json`:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Data Source=basen.api.db"
   }
   ```

3. Create/apply migrations (from repository root):

   ```bash
   dotnet ef migrations add InitialSqlite --project WebAppBase.Persistence/WebAppBase.Persistence.csproj --startup-project WebAppBase.API/WebAppBase.API.csproj --context AppDbContext
   dotnet ef database update --project WebAppBase.Persistence/WebAppBase.Persistence.csproj --startup-project WebAppBase.API/WebAppBase.API.csproj --context AppDbContext
   ```

   If a migration already exists, run only `dotnet ef database update`.

4. Start the API:

   ```bash
   dotnet run --project WebAppBase.API/WebAppBase.API.csproj
   ```

5. Access:

- Swagger: [http://localhost:5022/swagger](http://localhost:5022/swagger)
- Root URL (`/`) returns 404 by default in this template.

## Contact

For inquiries or support:

- **Email**: augusto.n.omena@gmail.com
- **LinkedIn**: [august-omena](https://www.linkedin.com/in/augusto-omena/)
