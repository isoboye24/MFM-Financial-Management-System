# MFM Financial Management System — Backend

A church financial management system backend built with **ASP.NET Core Web API, .NET 9, Entity Framework Core, and Microsoft SQL Server**.

> This README is based on the project files, startup code, database context, migration, and test project details shared so far. Verify paths and run the commands in your local checkout before using them in a production environment.

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Technology Stack](#technology-stack)
- [Architecture](#architecture)
- [Project Structure](#project-structure)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Database Configuration](#database-configuration)
- [Database Migrations](#database-migrations)
- [Running the API](#running-the-api)
- [API Documentation](#api-documentation)
- [Testing](#testing)
- [Security and Configuration](#security-and-configuration)
- [Related Project](#related-project)
- [License](#license)

## Overview

MFM Financial Management System (MFMFMS) provides backend functionality for managing church financial records, members, meetings, documents, and monthly financial reports.

The solution separates HTTP endpoints, application use cases, domain logic, infrastructure services, persistence, and security concerns.

## Features

### Financial management
- Manage financial categories.
- Record and manage givings, including offering and tithe-related categories.
- Record and manage expenditures.
- Maintain monthly financial summary reports.

### Church administration
- Manage members and positions.
- Manage meetings and meeting categories.
- Record male, female, and children's meeting attendance.
- Manage months and reporting periods.

### Documents and reports
- Manage document records and document types.
- Generate PDF service reports using QuestPDF.
- Support monthly financial summary reporting.

### Security and validation
- ASP.NET Core Identity API integration.
- Authentication and authorization middleware.
- Administrator seeding at application startup.
- FluentValidation for application validation.
- Custom exception-handling middleware.

## Technology Stack

| Technology | Purpose |
|---|---|
| C# | Backend programming language |
| .NET 9 | Application platform |
| ASP.NET Core Web API | HTTP API and controllers |
| Entity Framework Core 9 | ORM and database access |
| Microsoft SQL Server | Relational database |
| ASP.NET Core Identity | Identity and authentication integration |
| AutoMapper 16.2.0 | Object mapping |
| FluentValidation 12.1.1 | Application validation |
| Scrutor 7.0.0 | Dependency injection scanning |
| DotNetEnv 3.2.0 | Environment variable loading |
| QuestPDF 2026.9.1 | PDF document generation |
| Microsoft.AspNetCore.OpenApi 9.0.18 | OpenAPI document support |
| MSTest 3.6.4 | Automated testing |
| Microsoft.NET.Test.Sdk 17.12.0 | Test execution |

Package versions listed above are taken from the project files shared for this README.

## Architecture

The solution follows a layered, Clean Architecture-inspired organization.

- **API** — application entry point, HTTP controllers, DTOs, middleware, and API configuration.
- **Application** — use cases, contracts, features, and validation.
- **Domain** — entities, common domain types, enums, exceptions, and business rules.
- **Infrastructure** — infrastructure services, including PDF generation.
- **Persistence** — EF Core context, entity configurations, migrations, repositories, and unit-of-work support.
- **Security** — identity and security-related services.
- **Tests** — automated tests.

The API references Application, Infrastructure, Persistence, and Security. Application references Domain. Persistence references Application for its contracts.

## Project Structure

The following is a logical overview of the folders shown in the solution.

```text
MFM Financial Management System/
├── API/
│   └── MFMFMS.API/
│       ├── Controllers/
│       ├── DTOs/
│       ├── Middleware/
│       ├── Utilities/
│       ├── Program.cs
│       └── appsettings.json
├── Application/
│   └── MFMFMS.Application/
│       ├── Contracts/
│       ├── Exceptions/
│       ├── Features/
│       └── Utilities/
├── Domain/
│   └── MFMFMS.Domain/
│       ├── Common/
│       ├── Entities/
│       ├── Enums/
│       ├── Exceptions/
│       └── ValueObjects/
├── Infrastructure/
│   └── MFMFMS.Infrastructure/
│       └── PDF/
├── Persistence/
│   └── MFMFMS.Persistence/
│       ├── Configurations/
│       ├── Migrations/
│       ├── Repositories/
│       ├── UnitOfWork/
│       └── MFMFMSDBContext.cs
├── Security/
│   └── MFMFMS.Security/
├── Tests/
│   └── MFMFMS.Test/
└── MFM Financial Management System.sln
```

The `.sln` file is shown as the expected solution-root location; its exact filename and presence should be confirmed in the local checkout. Visual Studio may show the solution and projects without displaying the `.sln` file as a project item.

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Microsoft SQL Server or an accessible SQL Server instance
- Visual Studio with the ASP.NET and web development workload, or the .NET CLI
- Entity Framework Core CLI (`dotnet-ef`) for migrations

Check the installed SDK:

```bash
dotnet --info
```

The Persistence project uses Entity Framework Core 9.0.0. If needed, install a matching EF Core CLI tool:

```bash
dotnet tool install --global dotnet-ef --version 9.0.0
```

If the tool is already installed, update it instead:

```bash
dotnet tool update --global dotnet-ef --version 9.0.0
```

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/isoboye24/MFM-Financial-Management-System.git
cd MFM-Financial-Management-System
```

If your backend repository URL or folder name differs, replace the values above.

### 2. Restore dependencies

From the directory containing the solution file:

```bash
dotnet restore
```

### 3. Configure the database

The API reads the connection string named `MFMFMSConnection`. Configure it before starting the API. See [Database Configuration](#database-configuration).

## Database Configuration

The API's `appsettings.json` includes this connection-string key:

```json
{
  "ConnectionStrings": {
    "MFMFMSConnection": ""
  }
}
```

The persistence dependency injection registers SQL Server using:

```csharp
options.UseSqlServer(
    configuration.GetConnectionString("MFMFMSConnection"));
```

Configure a valid connection string using environment-specific settings. For example, in PowerShell:

```powershell
$env:ConnectionStrings__MFMFMSConnection = "Server=YOUR_SERVER;Database=YOUR_DB;Trusted_Connection=True;TrustServerCertificate=True"
```

Replace `YOUR_SERVER` and the authentication options with values appropriate for your environment. This is an example, not a universal SQL Server connection string.

The application calls `Env.TraversePath().Load()`, which allows environment variables to be loaded from a `.env` file discovered by DotNetEnv. Keep `.env` files containing secrets out of version control.

**Never commit database passwords, production connection strings, signing keys, or other secrets.**

## Database Migrations

The Persistence project contains Entity Framework Core migrations. Before applying them, verify the relative project paths in your checkout and ensure the connection string points to the intended database.

If the project paths match the structure shown above, an example command is:

```bash
dotnet ef database update \
  --project Persistence/MFMFMS.Persistence/MFMFMS.Persistence.csproj \
  --startup-project API/MFMFMS.API/MFMFMS.API.csproj
```

For PowerShell, the same command can be entered on one line:

```powershell
dotnet ef database update --project Persistence/MFMFMS.Persistence/MFMFMS.Persistence.csproj --startup-project API/MFMFMS.API/MFMFMS.API.csproj
```

If your actual folders differ, adjust the paths. Review migrations before applying them to a shared or production database.

To create a migration, adapt this command to your project layout:

```powershell
dotnet ef migrations add MigrationName --project Persistence/MFMFMS.Persistence/MFMFMS.Persistence.csproj --startup-project API/MFMFMS.API/MFMFMS.API.csproj
```

## Running the API

The API configures Kestrel to listen on port `7200` on all network interfaces.

If the paths match the structure above, run:

```bash
dotnet run --project API/MFMFMS.API/MFMFMS.API.csproj
```

The local base URL is typically:

```text
http://localhost:7200
```

The API's launch profile or hosting environment may affect the displayed URLs. Port `7200` is configured directly in `Program.cs`.

## API Documentation

The API registers OpenAPI services using `AddOpenApi()` and maps the OpenAPI document with `MapOpenApi()` in the Development environment.

With the default OpenAPI route and the application running in Development, try:

```text
http://localhost:7200/openapi/v1.json
```

The provided `Program.cs` does not configure Swagger UI. The OpenAPI JSON endpoint is the documented interface visible in the startup code.

## Testing

The test project targets .NET 9 and uses:

- `Microsoft.NET.Test.Sdk` 17.12.0
- `MSTest` 3.6.4

The test project references Application, Domain, and Infrastructure.

Run all tests from the solution root:

```bash
dotnet test
```

If the test project path matches the shown folder structure, build the test project directly with:

```powershell
dotnet build Tests/MFMFMS.Test/MFMFMS.Test.csproj
```

### Example: Category domain tests

`CategoryTests` verifies that:

- A category is created when its name is valid.
- A new category receives a non-empty identifier.
- Null, empty, and whitespace-only names are rejected.
- A valid name can be assigned through `UpdateName`.
- Invalid updates throw `BusinessRuleException` with the expected message: `Category's name is required.`

These tests document domain invariants and help prevent regressions.

## Security and Configuration

The startup code registers security services and maps ASP.NET Core Identity API endpoints using `MapIdentityApi<User>()`. It also enables authentication and authorization middleware.

At startup, the API calls `SecuritySeeder.SeedAdminAsync` to seed an administrator. Review that implementation to determine how the initial administrator credentials are configured.

Before deploying:

- Store secrets in environment variables, user secrets, or an appropriate secret manager.
- Verify the administrator seeding process and credentials.
- Review authentication and authorization policies.
- Configure HTTPS for production.
- Restrict database access to trusted hosts and identities.
- Keep secret-bearing `.env` and local configuration files out of Git.

HTTPS redirection is commented out in the provided `Program.cs`; production HTTPS should be configured at the application or hosting layer.

## Related Project

- **Backend repository:** [MFM Financial Management System](https://github.com/isoboye24/MFM-Financial-Management-System)
- **Frontend:** The companion WPF desktop application. [MFM Financial Management System Frontend](https://github.com/isoboye24/MFM_Financial_Management_System.Frontend)

## License

Private
