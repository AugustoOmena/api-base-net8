<h1 align="center">Base-API-Layered-Architecture</h1>


<p align="center">
  <img src="https://img.shields.io/badge/.NET-8.0-blue" alt=".NET">
  <img src="https://img.shields.io/badge/PostgreSQL-16-blue" alt="PostgreSQL">
  <img src="https://img.shields.io/badge/Architecture-Layered-orange" alt="Architecture">
</p>


## Overview

**Base-API-Layered-Architecture** is a foundational project for creating other APIs, providing a pre-configured layered architecture using .NET and PostgreSQL. This repository is designed to offer a scalable and maintainable structure to start building APIs quickly and efficiently.

## Features

- **Layered Architecture**: Clear separation of concerns between layers (e.g., Presentation, Business, Data Access).
- **.NET 8.0**: Latest .NET version with performance improvements.
- **PostgreSQL**: Pre-configured integration with PostgreSQL database.
- **Extensible**: Easy to extend and adapt for various types of APIs.
- **Best Practices**: Implements good coding practices like dependency injection and repository pattern.

## Technologies Used

- **.NET 8.0**
- **PostgreSQL**
- **Entity Framework Core**
- **Dependency Injection**
- **Repository Pattern**

## Layers

1. **Api Layer**: Responsible for handling incoming HTTP requests and routing them to the appropriate services. This layer defines the API endpoints and coordinates responses.
2. **Core Layer**: Contains the business logic, validation, and core functionalities of the application. It manages the interaction between the API and infrastructure layers.
3. **Infra Layer**: Responsible for data persistence and retrieval. This layer implements data access using Entity Framework Core and manages integration with the PostgreSQL database.
4. **Test Layer**: Includes unit and integration tests to ensure the application’s reliability. It covers testing of business logic, API endpoints, and data access components.

## Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)

## Setup

1. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/Base-API-Layered-Architecture.git
   cd Base-API-Layered-Architecture

2. Atualize o `appsettings.json` com sua string de conexão do PostgreSQL:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Host=localhost;Database=seubanco;Username=seuusuario;Password=suasenha"
   }

3. Execute as migrações do banco de dados:

        dotnet ef database update


4. Inicie a API:
   
       dotnet run
