# CopilotUsers - GitHub Copilot Training Project

API mínima de usuarios con TDD para practicar todos los modos de GitHub Copilot.

## Stack

- .NET 10 Web API
- EF Core InMemory
- xUnit

## Comandos

```bash
dotnet restore
dotnet build
dotnet test
dotnet run --project CopilotUsers.Api
```

## Módulos de formación

### Módulo 0 — Autocomplete

Generar modelos y DTOs.

### Módulo 1 — Ask

Preguntar: dónde validar, formato de error.

### Módulo 2 — Edit

Mapping request → entity, controller usa servicio.

### Módulo 3 — Plan

Plan para validación de edad + tests.

### Módulo 4 — Agent

Implementar el plan y dejar tests en verde.
