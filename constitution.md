# Proyecto de formación: GitHub Copilot (Autocomplete + Ask + Edit + Plan + Agent) con API Users (.NET 10)

## Objetivo

Crear un repositorio evolutivo para practicar todos los modos de Copilot
usando una API mínima de usuarios con TDD.

## Stack

-   .NET 10 Web API
-   EF Core InMemory
-   xUnit

## Estructura

CopilotUsers.sln

-   CopilotUsers.Api
-   CopilotUsers.Tests

## Entidad User

-   Guid Id
-   string Name
-   string Email
-   DateOnly? BirthDate
-   bool IsActive
-   DateTime CreatedAtUtc

Normalización: - Name → Trim() - Email → Trim().ToLowerInvariant()

## Endpoint

POST /users

### Request

{ "name": "Alice", "email": "alice@example.com", "birthDate":
"2000-01-01" }

### Response 201

{ "id": "guid" }

## ErrorResponse

{ "errors": \[ { "code": "UNDERAGE", "message": "User must be at least
18 years old." } \] }

## Reglas de edad (fase posterior)

Edad mínima: 18

## Persistencia

AppDbContext con DbSet`<User>`{=html}

Repositorio: Task AddAsync(User user, CancellationToken ct)

Inicialmente lanzar NotImplementedException.

## Servicio

CreateAsync: - normaliza - crea User - Id = Guid.NewGuid() -
CreatedAtUtc = DateTime.UtcNow - IsActive = true - llama a repo -
devuelve { id }

## Controller

POST /users return Created(\$"/users/{id}", response)

## Test inicial (rojo)

POST_users_returns_201_and_id

Assert: - 201 - id válido

Debe fallar por repositorio no implementado.

## Test edad (posterior)

POST_users_underage_returns_400_with_UNDERAGE_error

## Informacion para el readme

### Módulo 0 Autocomplete

Generar modelos y DTOs.

### Módulo 1 Ask

Preguntar: - dónde validar - formato de error

### Módulo 2 Edit

-   mapping request → entity
-   controller usa servicio

### Módulo 3 Plan

Plan para validación de edad + tests.

### Módulo 4 Agent

Implementar el plan y dejar tests en verde.

## Comandos

dotnet restore dotnet build dotnet test dotnet run --project
CopilotUsers.Api
