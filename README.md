# Layered Product & Category Management API

This repository is a learning project that demonstrates a layered backend architecture with **C#, .NET 8 and ASP.NET Core Web API**.

## Technologies

- C# and .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- Microsoft SQL Server
- Autofac dependency injection
- Swagger / OpenAPI

## Architecture

- `Entities`: domain entities
- `DataAccess`: Entity Framework data-access implementations
- `Business`: business services and rules
- `Core`: reusable infrastructure and result structures
- `WebAPI`: HTTP controllers, dependency configuration and API startup
- `ConsoleUI`: console-based test client

## Implemented API operations

- List all products
- Get a product by ID
- Filter products by category
- Add a product
- Product and category endpoints
- Constructor injection through service interfaces
- CORS configuration for an Angular client running locally

## Current status

The main layered structure and initial product/category endpoints are implemented. The next improvements will include complete update/delete operations, request validation, authentication, automated tests and clearer environment setup instructions.

## Repository purpose

This project is part of my transition from professional web development toward backend and full-stack .NET development.
