Retail Order Web API
A modern, scalable web API for managing retail orders built with .NET Aspire and ASP.NET Core. This API provides comprehensive order management capabilities including customer management, product catalog, and order processing.
🚀 Features

Customer Management: Complete CRUD operations for customer data
Product Catalog: Full product and category management
Order Processing: Create orders, track status, and manage order lifecycle
Caching: Redis integration for improved performance
Observability: Built-in telemetry and monitoring with OpenTelemetry
Database: PostgreSQL integration with Entity Framework Core
API Documentation: Swagger/OpenAPI documentation

🛠️ Tech Stack

.NET Aspire - Cloud-native application framework
ASP.NET Core C# 8 - Web API framework
PostgreSQL - Primary database
Redis - Caching layer
Entity Framework Core - ORM
AutoMapper - Object mapping
Swagger/OpenAPI - API documentation

📦 Project Structure
TARetailOrder/
├── TARetailOrder.ApiService/                   # Main API project
├── TARetailOrder.AppHost/						# Aspire orchestration host
├── TARetailOrder.ServiceDefaults/				# Shared Aspire service configurations
└── TARetailOrder.Tests/						# No unit test implemented.		
└── TARetailOrder.Web/							# Blazoer Web - but not the main focused.
└── README.md
🗄️ Database Entities

Customer: Customer information and contact details
Product: Product catalog with pricing and specifications
Category: Product categorization
Order: Order management with header and detail structure

🔧 Dependencies
API Project

Aspire.Npgsql.EntityFrameworkCore.PostgreSQL (9.0.0)
AutoMapper (14.0.0)
Microsoft.EntityFrameworkCore.Design (8.0.17)
Microsoft.EntityFrameworkCore.Tools (8.0.17)
Swashbuckle.AspNetCore (9.0.1)
Swashbuckle.AspNetCore.Annotations (9.0.1)

AppHost Project

Aspire.Hosting.AppHost (9.0.0)
Aspire.Hosting.PostgreSQL (9.0.0)
Aspire.Hosting.Redis (9.0.0)
Microsoft.EntityFrameworkCore.Design (9.0.6)

Service Defaults

Microsoft.Extensions.Http.Resilience (9.0.0)
Microsoft.Extensions.ServiceDiscovery (9.0.0)
OpenTelemetry.Exporter.OpenTelemetryProtocol (1.9.0)
OpenTelemetry.Extensions.Hosting (1.9.0)
OpenTelemetry.Instrumentation.AspNetCore (1.9.0)
OpenTelemetry.Instrumentation.Http (1.9.0)
OpenTelemetry.Instrumentation.Runtime (1.9.0)

🚀 Getting Started
Prerequisites

.NET 8 SDK
Docker Desktop (required to load PostgreSQL database and Redis cache)
Visual Studio 2022 or VS Code
