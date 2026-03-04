# Architecture

## Overview

The backend of this project follows **Clean Architecture principles**.  
This approach separates the application into layers so that business logic remains independent of frameworks, databases, and external services.

The system is divided into four layers.

---

## Domain Layer

The Domain layer contains the core business model.

Responsibilities:

- Business entities
- Core contracts

Example components:

- User entity
- IUserRepository interface

This layer has **no dependency on frameworks or infrastructure**.

---

## Application Layer

The Application layer contains the use cases of the system.

Responsibilities:

- Application logic
- Coordinating domain operations
- Data transfer objects (DTOs)

Key use cases:

- RegisterUserCommand
- LoginUserCommand
- GetUserDetailsQuery

This layer depends only on the Domain layer.

---

## Infrastructure Layer

The Infrastructure layer implements technical details required by the application.

Responsibilities:

- Database persistence
- Security implementations
- External integrations

Key components include:

- Entity Framework Core DbContext
- PostgreSQL repository implementations
- JWT token generation
- BCrypt password hashing

This layer implements interfaces defined in the Domain layer.

---

## API Layer

The API layer exposes the application through HTTP endpoints.

Responsibilities:

- Controllers
- Authentication configuration
- Dependency injection setup
- Swagger documentation

This layer acts as the entry point to the system.

---

## Frontend Architecture

The frontend is built using **React with Vite and Tailwind CSS**.

Structure:

src  
│  
├── api  
├── components  
├── context  
├── pages  
├── routes  
│  
├── App.jsx  
├── main.jsx  
└── index.css

Responsibilities:

- API folder handles communication with the backend
- Context manages authentication state
- ProtectedRoute ensures authenticated access
- Pages implement the main views (Register, Login, User Details)

---

## Benefits of This Architecture

- Clear separation of concerns
- Independent business logic
- Easier testing
- Easier maintenance
- Scalable structure for future features
