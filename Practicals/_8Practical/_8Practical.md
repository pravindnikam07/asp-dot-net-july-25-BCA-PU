# Practical 8: Create a Web Service for Arithmetic Operations

## Aim

To create an ASP.NET Core Web API web service that performs arithmetic operations such as:

* Addition
* Subtraction
* Multiplication
* Division

---

## Learning Objectives

After completing this practical, you will be able to:

* Create an ASP.NET Core Web API project.
* Understand the basic structure of a web service.
* Create API endpoints.
* Accept values through an HTTP request.
* Perform arithmetic operations using C#.
* Return results from a web service.
* Test API endpoints using a web browser.

---

# 1. Software Requirements

| Requirement      | Software                |
| ---------------- | ----------------------- |
| Operating System | macOS / Windows         |
| IDE              | Visual Studio Code      |
| Language         | C#                      |
| Framework        | ASP.NET Core            |
| API Type         | REST Web API            |
| Browser          | Chrome / Edge / Firefox |

---

# 2. What is a Web Service?

A **web service** is an application that provides functionality through a network using web-based communication.

In this practical, the web service provides arithmetic operations.

For example:

```text
Client
   |
   | HTTP Request
   ↓
ASP.NET Core Web Service
   |
   | Addition / Subtraction /
   | Multiplication / Division
   ↓
Result
   |
   | HTTP Response
   ↓
Client
```

---

# 3. Create the ASP.NET Core Web API Project

Open **VS Code**.

Open:

```text
Terminal → New Terminal
```

Check the .NET SDK:

```bash
dotnet --version
```

Create a new Web API project:

```bash
dotnet new webapi -n ArithmeticWebService
```

Move into the project directory:

```bash
cd ArithmeticWebService
```

Open the project in VS Code:

```bash
code .
```

---

# 4. Run the Initial Project

Before modifying the project, verify that it works:

```bash
dotnet run
```

The terminal will display URLs similar to:

```text
Now listening on: http://localhost:5000
Now listening on: https://localhost:7000
```

The port numbers may be different.

Stop the application:

```text
Ctrl + C
```

---

# 5. Project Structure

The project will contain files similar to:

```text
ArithmeticWebService/
│
├── Controllers/
│   └── WeatherForecastController.cs
│
├── Properties/
│   └── launchSettings.json
│
├── Program.cs
├── appsettings.json
├── appsettings.Development.json
└── ArithmeticWebService.csproj
```

We will create our own controller:

```text
Controllers/
└── ArithmeticController.cs
```

The existing `WeatherForecastController.cs` is not required for this practical and can be deleted.

---

# 6. Create the Arithmetic Controller

Inside the `Controllers` folder, create:

```text
ArithmeticController.cs
```

Add the following code:

```csharp
using Microsoft.AspNetCore.Mvc;

namespace ArithmeticWebService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArithmeticController : ControllerBase
    {
        [HttpGet("add")]
        public IActionResult Add(double a, double b)
        {
            double result = a + b;

            return Ok(new
            {
                Operation = "Addition",
                Number1 = a,
                Number2 = b,
                Result = result
            });
        }

        [HttpGet("subtract")]
        public IActionResult Subtract(double a, double b)
        {
            double result = a - b;

            return Ok(new
            {
                Operation = "Subtraction",
                Number1 = a,
                Number2 = b,
                Result = result
            });
        }

        [HttpGet("multiply")]
        public IActionResult Multiply(double a, double b)
        {
            double result = a * b;

            return Ok(new
            {
                Operation = "Multiplication",
                Number1 = a,
                Number2 = b,
                Result = result
            });
        }

        [HttpGet("divide")]
        public IActionResult Divide(double a, double b)
        {
            if (b == 0)
            {
                return BadRequest("Division by zero is not allowed.");
            }

            double result = a / b;

            return Ok(new
            {
                Operation = "Division",
                Number1 = a,
                Number2 = b,
                Result = result
            });
        }
    }
}
```

---

# 7. Understand the Controller

The controller is:

```csharp
public class ArithmeticController : ControllerBase
```

It contains the operations provided by the web service.

---

## API Route

```csharp
[Route("api/[controller]")]
```

Since the controller is named:

```text
ArithmeticController
```

the base URL becomes:

```text
/api/Arithmetic
```

---

# 8. Addition Operation

The addition endpoint is:

```csharp
[HttpGet("add")]
public IActionResult Add(double a, double b)
```

The complete URL is:

```text
/api/Arithmetic/add
```

For example:

```text
/api/Arithmetic/add?a=10&b=5
```

The operation:

```csharp
double result = a + b;
```

produces:

```text
15
```

---

# 9. Subtraction Operation

The endpoint is:

```csharp
[HttpGet("subtract")]
public IActionResult Subtract(double a, double b)
```

Example:

```text
/api/Arithmetic/subtract?a=10&b=5
```

Result:

```text
5
```

---

# 10. Multiplication Operation

The endpoint is:

```csharp
[HttpGet("multiply")]
public IActionResult Multiply(double a, double b)
```

Example:

```text
/api/Arithmetic/multiply?a=10&b=5
```

Result:

```text
50
```

---

# 11. Division Operation

The endpoint is:

```csharp
[HttpGet("divide")]
public IActionResult Divide(double a, double b)
```

Example:

```text
/api/Arithmetic/divide?a=10&b=5
```

Result:

```text
2
```

The application also checks for division by zero:

```csharp
if (b == 0)
{
    return BadRequest("Division by zero is not allowed.");
}
```

---

# 12. Verify Program.cs

Open:

```text
Program.cs
```

The default Web API project should contain code similar to:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
```

The important lines are:

```csharp
builder.Services.AddControllers();
```

and:

```csharp
app.MapControllers();
```

These enable the API controllers.

No changes are normally required in `Program.cs`.

---

# 13. Run the Web Service

Save all files.

Run:

```bash
dotnet run
```

The terminal will display something similar to:

```text
Now listening on: http://localhost:5000
```

Use the actual URL and port shown in your terminal.

---

# 14. Test Addition

Open the browser and enter:

```text
http://localhost:5000/api/Arithmetic/add?a=10&b=5
```

Expected response:

```json
{
  "operation": "Addition",
  "number1": 10,
  "number2": 5,
  "result": 15
}
```

---

# 15. Test Subtraction

Open:

```text
http://localhost:5000/api/Arithmetic/subtract?a=10&b=5
```

Expected response:

```json
{
  "operation": "Subtraction",
  "number1": 10,
  "number2": 5,
  "result": 5
}
```

---

# 16. Test Multiplication

Open:

```text
http://localhost:5000/api/Arithmetic/multiply?a=10&b=5
```

Expected response:

```json
{
  "operation": "Multiplication",
  "number1": 10,
  "number2": 5,
  "result": 50
}
```

---

# 17. Test Division

Open:

```text
http://localhost:5000/api/Arithmetic/divide?a=10&b=5
```

Expected response:

```json
{
  "operation": "Division",
  "number1": 10,
  "number2": 5,
  "result": 2
}
```

---

# 18. Test Division by Zero

Open:

```text
http://localhost:5000/api/Arithmetic/divide?a=10&b=0
```

The service should return an error:

```text
Division by zero is not allowed.
```

The HTTP response status will be:

```text
400 Bad Request
```

---

# 19. API Endpoint Summary

| Operation      | HTTP Method | Endpoint                   | Example     |
| -------------- | ----------- | -------------------------- | ----------- |
| Addition       | GET         | `/api/Arithmetic/add`      | `?a=10&b=5` |
| Subtraction    | GET         | `/api/Arithmetic/subtract` | `?a=10&b=5` |
| Multiplication | GET         | `/api/Arithmetic/multiply` | `?a=10&b=5` |
| Division       | GET         | `/api/Arithmetic/divide`   | `?a=10&b=5` |

---

# 20. Important Web API Concepts

### Controller

A controller handles HTTP requests and returns responses.

```csharp
public class ArithmeticController : ControllerBase
```

### HTTP GET

```csharp
[HttpGet("add")]
```

defines an HTTP GET endpoint.

### Query Parameters

In:

```text
?a=10&b=5
```

`a` and `b` are query parameters.

They are received by:

```csharp
double a, double b
```

### IActionResult

```csharp
public IActionResult Add(...)
```

allows the method to return an HTTP response.

### Ok()

```csharp
return Ok(...);
```

returns a successful HTTP response.

The usual status code is:

```text
200 OK
```

### BadRequest()

```csharp
return BadRequest(...);
```

returns an HTTP 400 error when the request is invalid.

---

# 21. Testing Table

Test all operations using the following values:

| Operation      | Input  | Expected Result |
| -------------- | ------ | --------------: |
| Addition       | 20, 10 |              30 |
| Subtraction    | 20, 10 |              10 |
| Multiplication | 20, 10 |             200 |
| Division       | 20, 10 |               2 |
| Division       | 20, 0  |           Error |

---

# 22. Common Errors

## Error 1: 404 Not Found

Check that the URL is correct:

```text
/api/Arithmetic/add
```

Also make sure:

```csharp
app.MapControllers();
```

exists in `Program.cs`.

---

## Error 2: Controller not detected

Make sure the file is inside:

```text
Controllers/
```

and the class contains:

```csharp
[ApiController]
```

---

## Error 3: Wrong port

Do not assume the port is always `5000`.

Check the terminal after running:

```bash
dotnet run
```

and use the URL displayed there.

---

## Error 4: HTTPS certificate warning

If the browser shows a local HTTPS certificate warning, use the HTTP URL displayed by `dotnet run`, for example:

```text
http://localhost:5000
```

---

# 23. Viva Questions

1. What is a web service?
2. What is ASP.NET Core Web API?
3. What is a controller?
4. What is the purpose of `[ApiController]`?
5. What is `[Route]`?
6. What does `[HttpGet]` represent?
7. What are query parameters?
8. What is `IActionResult`?
9. What is the purpose of `Ok()`?
10. What is the purpose of `BadRequest()`?
11. What HTTP status code represents a successful request?
12. What HTTP status code represents a bad request?
13. Why should division by zero be checked?
14. What is REST?
15. What is the difference between a web application and a web service?

---

# Result

An **ASP.NET Core Web API web service** was successfully developed using C# to perform **addition, subtraction, multiplication, and division** operations. The service was tested using HTTP GET requests and returned the arithmetic results as HTTP responses.
