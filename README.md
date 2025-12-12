# ENB Insurance and Claims Management System

A comprehensive, enterprise-grade insurance and claims management platform built with modern .NET technologies and following Domain-Driven Design principles.

## Overview

This system provides a complete solution for managing insurance policies, processing claims, and generating detailed reports. Built with ASP.NET Core MVC, Entity Framework Core, and a layered architecture, it ensures scalability, maintainability, and robust performance.

## Project Structure

The solution is organized into four main projects following clean architecture principles:

### 1. **ENB.InsuranceAndClaims.EF**
Entity Framework Core data access layer handling database operations, migrations, and data persistence.

### 2. **ENB.InsuranceAndClaims.Entities**
Core domain entities and value objects representing the insurance domain model, including:
- Insurance policies
- Claims
- Customers
- Transactions and settlements

### 3. **ENB.InsuranceAndClaims.Infrastructure**
Infrastructure services and utilities, including:
- Repository implementations
- External service integrations
- Cross-cutting concerns
- Dependency injection configuration

### 4. **ENB.InsuranceAndClaims.MVC**
ASP.NET Core MVC presentation layer providing:
- Web interface for insurance management
- Claims processing workflows
- Report generation and viewing
- User authentication and authorization

### 5. **Winreport**
Windows-based reporting tool for generating and analyzing insurance claim reports.

## Features

- **Policy Management**: Create, update, and manage insurance policies
- **Claims Processing**: Streamlined claim submission and processing workflows
- **Report Generation**: Comprehensive reporting capabilities with multiple formats
- **User Management**: Role-based access control and authentication
- **Data Validation**: Robust validation across all layers
- **Audit Trail**: Track all system activities and changes

## Technology Stack

- **.NET Framework**: .NET 8.0
- **Web Framework**: ASP.NET Core MVC
- **ORM**: Entity Framework Core
- **Architecture**: Domain-Driven Design, Layered Architecture
- **Database**: SQL Server (configured via Entity Framework)
- **Frontend**: HTML5, CSS3, JavaScript (Bootstrap)

## Prerequisites

- .NET 8.0 SDK or later
- SQL Server 2019 or later
- Visual Studio 2022 or Visual Studio Code
- Git

## Getting Started

### 1. Clone the Repository
```bash
git clone https://github.com/Etngandu/InsuranceClaim.git
cd InsuranceClaim
```

### 2. Restore Dependencies
```bash
dotnet restore
```

### 3. Configure Database
Update the connection string in `ENB.InsuranceAndClaims.MVC/appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=InsuranceClaimsDB;Trusted_Connection=true;"
  }
}
```

### 4. Apply Database Migrations
```bash
dotnet ef database update -p ENB.InsuranceAndClaims.EF
```

### 5. Run the Application
```bash
cd ENB.InsuranceAndClaims.MVC
dotnet run
```

The application will be available at `https://localhost:5001`

## Project Configuration

### Application Settings
Configuration files are located in `ENB.InsuranceAndClaims.MVC/`:
- `appsettings.json` - Default settings
- `appsettings.Development.json` - Development-specific settings

### Library Management
The project uses LibMan for managing client-side libraries. Configuration is in `libman.json`.

## Architecture Principles

This project follows **Domain-Driven Design** (DDD) principles:

1. **Bounded Contexts**: Each project represents a logical boundary
2. **Ubiquitous Language**: Domain terminology is consistent throughout the codebase
3. **Entities and Value Objects**: Core domain models with business rules enforced at the entity level
4. **Repositories**: Data access abstraction for domain objects
5. **Aggregates**: Related entities grouped with clear root boundaries
6. **Services**: Domain and application services for complex business logic

## Building the Solution

### Debug Build
```bash
dotnet build --configuration Debug
```

### Release Build
```bash
dotnet build --configuration Release
```

## Testing

Run unit tests (if available):
```bash
dotnet test
```

## API Endpoints

The MVC application includes API controllers. Key endpoints:
- **Members**: `/api/members` - Member management
- **Claims**: `/api/claims` - Claims processing
- **Policies**: `/api/policies` - Policy management

## Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## Project Dependencies

Key NuGet packages:
- EntityFrameworkCore
- AspNetCore packages
- Logging libraries
- Validation libraries

For complete dependency list, see `.csproj` files in each project.

## Troubleshooting

### Database Connection Issues
- Verify SQL Server is running
- Check connection string in `appsettings.json`
- Ensure database user has appropriate permissions

### Migration Issues
- Clear `bin` and `obj` directories
- Re-run `dotnet restore`
- Apply migrations step by step

### Build Errors
- Ensure .NET 8.0 SDK is installed: `dotnet --version`
- Check all projects are built in correct order

## License

This project is proprietary. All rights reserved.

## Support

For issues, questions, or suggestions, please open an issue in the GitHub repository.

## Author

Developed by Etngandu

---

**Last Updated**: December 2025  
**Version**: 1.0.0
