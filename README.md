SinteksApp - Design Patterns & Clean Architecture
A modern .NET 10 backend project designed to demonstrate real-world usage of
Design Patterns and Clean Architecture.

About the Project
This project is built around a retail management domain and focuses on solving real business problems such as:
Discount management system
Employee bonus calculation
Sales & stock management
Employee transfer logic
The main goal is to implement scalable, maintainable, and clean backend architecture using industry best practices.

Architecture
The project follows Clean Architecture principles:
Api → Application → Domain → Infrastructure
Layers
Api → HTTP endpoints (Controllers)
Application → Use cases (CQRS, business orchestration)
Domain → Core business logic and rules
Infrastructure → Database, external services

Technologies
.NET 10
ASP.NET Core Web API
Entity Framework Core
MediatR
Ardalis.Specification
FluentValidation
Mapster
Quartz.NET

Design Patterns Used
This project applies multiple design patterns in real-world scenarios:
- CQRS (Command Query Responsibility Segregation)
Separates read and write operations.

- Mediator Pattern (MediatR)
All requests are handled via MediatR.

- Strategy Pattern
Used for dynamic business logic:
Discount calculation
Bonus calculation

- Factory Pattern
Controlled object creation

- Decorator Pattern 
Implemented via MediatR pipeline:
ValidationBehavior
LoggingBehavior
TransactionBehavior

- Specification Pattern
Ardalis Specification and discount business logics

- Result Pattern
Result.Success()
Result.Fail()

- Chain of Responsibility
Used for rule validation:
Bonus eligibility checks
Discount applicability rules

Key Features
✔ Priority-based discount engine
✔ Dynamic bonus calculation (Top-N logic)
✔ Employee transfer-aware bonus system
✔ Stock tracking per branch
✔ Sale & return workflow
✔ Scheduled background jobs (Quartz)

Author
Beyhan Bayraktar
