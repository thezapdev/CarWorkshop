# CarWorkshop

A web application for browsing car workshops and managing their services.

## Tech Stack

- **Backend:** .NET 8, ASP.NET Core MVC
- **Database:** SQL Server, Entity Framework Core 8
- **Authentication & Authorization:** ASP.NET Core Identity
- **Application Architecture:** MediatR
- **Object Mapping:** AutoMapper
- **Validation:** FluentValidation
- **Testing:** xUnit, Moq, FluentAssertions

## Solution Structure

- `CarWorkshop.Domain` – Domain entities and repository interfaces.
- `CarWorkshop.Application` – Application use cases, commands, queries, validation and mapping configurations.
- `CarWorkshop.Infrastucture` – Entity Framework Core configuration, repositories, dependency injection and database seeding.
- `CarWorkshop.MVC` – ASP.NET Core MVC application, controllers and views.
- `*.Tests` – Unit test projects.

> The existing `CarWorkshop.Infrastucture` project and namespace naming has been retained to preserve compatibility with existing project references.

## Requirements

- .NET 8 SDK
- SQL Server LocalDB or another SQL Server instance
- Visual Studio, JetBrains Rider or VS Code

## Getting Started

1. Clone the repository.
2. Open `CarWorkshop.slnx`.
3. Configure the SQL Server connection string in `CarWorkshop.MVC/appsettings.json`.
4. Ensure the connection string key matches the one configured in `CarWorkshop.Infrastucture/Extensions/ServiceCollectionExtension.cs`.
5. Apply the existing Entity Framework Core migrations to the configured database.
6. Set `CarWorkshop.MVC` as the startup project and run the application.

The default configuration uses SQL Server LocalDB.

**Note:** Do not commit production database credentials or other sensitive configuration values to the repository.

## Running Tests

Run all test projects from the solution directory:

```bash
dotnet test CarWorkshop.slnx
```

## Project Background

This project was initially developed as part of a programming course focused on .NET and ASP.NET Core. It was subsequently revisited and refined through independent code cleanup, refactoring and documentation improvements.
