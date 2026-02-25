# 🧠 Copilot Users Kata (Guía MUY guiada)

> Vas a usar Copilot como toca. No a lo loco. Paso a paso. Con prompts
> incluidos 😄

------------------------------------------------------------------------

## 🎯 Objetivo

Entrenar:

-   ✍️ Autocompletado
-   💬 Ask
-   ✂️ Edit
-   🧠 Plan
-   🤖 Agent

Con TDD y un único proyecto evolutivo.

Empiezas en rojo 🔴\
Acabas en verde 🟢\
Sales sabiendo **cuándo delegar y cuándo pensar**.

------------------------------------------------------------------------

## 🧩 Requerimientos mínimos

-   .NET 10
-   Web API
-   EF Core InMemory
-   xUnit
-   Async/await

### Endpoint único

`POST /users`

✔ 201 → `{ "id": "guid" }`\
❌ 400 →

``` json
{
  "errors": [
    { "code": "UNDERAGE", "message": "User must be at least 18 years old." }
  ]
}
```

------------------------------------------------------------------------

## 🧪 Estado inicial

Hay un test:

    POST_users_returns_201_and_id

Y falla 💥 porque el repositorio no guarda.

NO lo arregles a mano.\
Eso es parte del ejercicio.

------------------------------------------------------------------------

# 🗺️ Paso a paso

------------------------------------------------------------------------

## 🟢 Paso 0 --- AUTOCOMPLETADO

NO ABRAS EL CHAT.

### 0.1 Crear la entidad

Escribe:

``` csharp
public class User
{
    // Copilot completa las propiedades típicas de una entidad de usuario
}
```

### 0.2 Crear el request

``` csharp
public class CreateUserRequest
{
    // name, email, birthDate
}
```

### 0.3 Crear el response

``` csharp
public class CreateUserResponse
{
    // solo Id
}
```

### 0.4 Error contract

``` csharp
public class ErrorResponse
{
    // lista de ValidationError con Code y Message
}
```

💡 Si Copilot no acierta → mejora el comentario.

------------------------------------------------------------------------

## 🔵 Paso 1 --- ASK (modo mentor)

### Prompt 1

> Where should validation live in this API and why?

### Prompt 2

> Why is using error codes better than plain strings for test stability?

⚠️ Regla: NO aplicar cambios.

------------------------------------------------------------------------

## 🟡 Paso 2 --- EDIT (modo cirujano)

Selecciona el archivo del service.

### Prompt mapping

> Map CreateUserRequest to User. Normalize Name and Email. Generate Guid
> and CreatedAtUtc.

Selecciona el controller.

### Prompt controller

> Call the service and return 201 Created with the id.

El test seguirá fallando.\
Todo correcto.

------------------------------------------------------------------------

## 🔴 Paso 3 --- TEST ROJO → VERDE

Selecciona el repositorio.

### Prompt

> Implement AddAsync using EF Core and SaveChangesAsync. Do not change
> tests.

Ejecuta tests.

Son verdes → sonríe.

------------------------------------------------------------------------

## 🧠 Paso 4 --- PLAN

### Prompt

> Create a step-by-step plan to add a minimum age validation (18) to
> user creation, including new tests and API error response.

Debe incluir:

-   dónde validar
-   qué cambiar
-   qué test crear

SIN código.

------------------------------------------------------------------------

## 🤖 Paso 5 --- AGENT

### Prompt

> Implement the minimum age validation following the plan and make all
> tests pass.

Aquí Copilot:

-   crea el test
-   implementa la validación
-   devuelve el error UNDERAGE
-   deja todo en verde

Tú solo miras.

------------------------------------------------------------------------

# 🏁 DONE cuando

-   ✅ Test inicial verde
-   ✅ Test de edad verde
-   ✅ No tocaste los tests para "que pasen"
-   ✅ Sigues teniendo dignidad como developer

------------------------------------------------------------------------

# ☕ Bonus (nivel pro)

Prompt:

> Refactor validation to a dedicated component without breaking tests.

Si pasa → ya estás usando Copilot en serio.

------------------------------------------------------------------------

# ▶️ Comandos

``` bash
dotnet restore
dotnet build
dotnet test
dotnet run --project CopilotUsers.Api
```

------------------------------------------------------------------------

# 🧘 Regla universal

Si algo sale mal:

No es Copilot.\
Es el prompt.

Siempre es el prompt.
