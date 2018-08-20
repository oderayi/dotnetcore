Domain-Driven Architectures:
- Clean Architecture
- Onion Architecture
- Hexagonal Architecture
- Ports and Adaptors

Clean Architecture: Commalities among archs
- Architecture & design
- Domain Layer
- Application Layer
- Persistence Layer : data concerns
- Infrastructure Layer: external concerns
- Presentation Layer

Clean Architectures
- Independent of frameworks
- Testable
- Independent of UI
- Independent of database
- Independent of external agency

Domain Layer - Enterprise Logic (can be moved to another app)
Application Layer - Depends on domain. Business logic specific to app (cant be moved to another app)
Presentation - Web app, Angular SPA, Mobile app. Depends on Application layer
Persistence - Used by applicaton layer. App layer depends on persistent layer. 
              Part of infrastructure, Data stuff eg Entity framework
Infrastructure - Used by application layer. 
                 Notifications, other web api, SMS, Security and access control. 
                 In short Persistence and Infratsructure can be merged.

Unit of Work and Repository Patterns
---------------------------------------
 Should we be implementing these patterns instead of using the Entity framework directly?
 It isn't always the best choice, because:
 - DbContext insulates your code from database changes i.e. DbContext is db agnostic like RedBean. 
    You can always change the provider underneath from Oracle to MySQL or SQLServer
 - DbContext acts as a unit of work
 - DbSet acts as a repository
 - EF Core has features for unit testing without repositories

 Key Points
 - Domain contains enterprise-wide types and logic
 - Application contains application-specific models and logic
 - Infrastructure (including Persistence) contain all external concerns
 - Presentation contains frontend apps
 - Infrastructure and Presentation components can be replaced with minimal effort

 Overview

 DOMAIN LAYER
------------------------
Contains:
 - Entites
 - Value Objects
 - Enumerations
 - Logic
 - Exceptions
Key Points:
 - Use data annotations sparingly in domain
 - Always define foreign keys
 - Use value objects when appropriate
 - Initialize all collections
 - Models (CustomerListModel, CustomerDetailModel etc) are for Application layer, Entities (Customer, Order, Product etc.) are for Domain Layer

 APPLICATION LAYER
--------------------------
Contains:
- Interfaces
- Models
- Logic
- Validators
- Events
- Exceptions (Custom Exceptions)
Key Points:
- Use CQRS (Command and Query Responsibility Segregation) 
    (Commands, Queries, Models separated) to simplify your overall design
- Use Mediator to simplify management of requests / responses commands, queries,
    notifications and events
- Know the difference between View Models (VMs) and Data Transfer Objects (DTOs)
- Use FluentValidation for complex validation scenarios
- Create custom application exceptions

PSERSISTENCE LAYER
-------------------
Contains:
- DbContext
- Configurations
- Migrations
- Seeding
- Abstractions
Key Points:
- Independent of database
- Conventions over configuration
- Use Fluent API configuration over Data Annotations for clean entities
- Use an extension to automatically apply all entity type configurations

INFRASTRUCTURE LAYER
---------------------
It's everything else external. No layer depends on infrastructure. If an application depends on infrastructure,
you're going to be writing logic to interact with that is outside of the application layer. It depends on application layer.

Contains:
- Clients e.g REST API
- File System
- Email / SMS
- System Clock e.g DateTime.Now, it will be hard to test logic that depends on DateTime.Now. You can abstract system clock 
    and in UAT environment allow users to set system clock.
Key Points:
- Contains classes for accessing external resources
- Implements interfaces within the Application layer
- Utilizes DTOs defined within the Application layer
- No layers depend on Infrastructure layer e.g Presentation layer

PRESENTATION LAYER
----------------------
- Web Forms
- MVC
- Razor Pages
- Web API
- Single Page Applications (Angular mostly)
- WCF Service
Key Points:
- Controllers should not contain any application logic
- All application logic belongs in the application layer
- Utilising Open API (Swagger) bridges the gap between the frontend and backend
- Create and consume well defined view models
Recommended Books / Resources:
- bit.ly/northwind-traders
- Architecting Modern Web Applications with ASP.NET Core and Microsoft Azure by Steve Smith
  (About Building Monoliths, Clean Architecture, Azure) (aka.ms/webappebook)
- .NET Microservices Architecture for containerized .NET Applications 
  (About Building Microservices, Containers, DDD, Azure) (aka.ms/microservices)
- Clean Architecture by Robert C. Martin 
  (bit.ly/clean-architecture-book)












