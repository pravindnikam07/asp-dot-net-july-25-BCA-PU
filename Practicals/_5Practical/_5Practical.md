# Practical 5: Demonstrate Label, Button and TextBox Controls in ASP.NET Core

## 1. Aim

To develop an ASP.NET Core web application that demonstrates the use of **Label, TextBox, and Button controls** using Razor Pages.

---

## 2. Learning Objectives

After completing this practical, students will be able to:

- Create an ASP.NET Core Razor Pages application.
- Design a webpage using HTML form controls.
- Use a TextBox to accept user input.
- Use a Button to submit user input.
- Display the entered information using a Label-like HTML element.
- Handle form submission using C# code.

---

## 3. Software Requirements

- Windows or macOS
- Visual Studio Code
- .NET SDK
- C#
- ASP.NET Core
- Web Browser

---

# 4. Practical Concept

In ASP.NET Core Razor Pages, traditional Web Forms controls such as:

- Label
- TextBox
- Button

are generally implemented using **HTML elements** and handled using **C# Razor Page code**.

| Traditional Control | Razor Pages / HTML    |
| ------------------- | --------------------- |
| Label               | `<label>` / `<span>`  |
| TextBox             | `<input type="text">` |
| Button              | `<button>`            |
| Event handling      | `OnPost()` method     |

The basic flow is:

```text
User enters data
       ↓
TextBox
       ↓
Button Click / Form Submit
       ↓
OnPost() in C#
       ↓
Display result
```

---

# 5. Create the ASP.NET Core Project

Open the terminal in VS Code.

Run:

```bash
dotnet new webapp -n ControlsDemo
```

Move into the project:

```bash
cd ControlsDemo
```

Open the project in VS Code:

```bash
code .
```

Run the application once to verify that the project works:

```bash
dotnet run
```

You will see an address similar to:

```text
http://localhost:5000
```

Open the displayed address in your browser.

Stop the application using:

```text
Ctrl + C
```

---

# 6. Project Structure

The important files are:

```text
ControlsDemo/
│
├── Pages/
│   ├── Index.cshtml
│   ├── Index.cshtml.cs
│   └── ...
│
├── wwwroot/
│   ├── css/
│   └── js/
│
├── Program.cs
├── appsettings.json
└── ControlsDemo.csproj
```

For this practical, we mainly modify:

```text
Pages/Index.cshtml
Pages/Index.cshtml.cs
```

---

# 7. Design the Webpage

Open:

```text
Pages/Index.cshtml
```

Delete the existing contents and add:

```html
@page @model ControlsDemo.Pages.IndexModel

<!DOCTYPE html>
<html>
  <head>
    <meta charset="utf-8" />
    <title>Controls Demo</title>

    <style>
      body {
        font-family: Arial, sans-serif;
        margin: 40px;
      }

      .container {
        width: 400px;
      }

      h1 {
        margin-bottom: 25px;
      }

      .form-group {
        margin-bottom: 15px;
      }

      label {
        display: block;
        margin-bottom: 5px;
        font-weight: bold;
      }

      input {
        width: 100%;
        padding: 8px;
        box-sizing: border-box;
      }

      button {
        margin-top: 10px;
        padding: 8px 20px;
        cursor: pointer;
      }

      .result {
        margin-top: 20px;
        padding: 10px;
        background-color: #f2f2f2;
      }
    </style>
  </head>

  <body>
    <div class="container">
      <h1>Student Information</h1>

      <form method="post">
        <div class="form-group">
          <label for="studentName"> Student Name </label>

          <input
            type="text"
            id="studentName"
            name="StudentName"
            placeholder="Enter student name"
          />
        </div>

        <button type="submit">Submit</button>
      </form>

      @if (!string.IsNullOrEmpty(Model.Message)) {
      <div class="result">
        <strong>Message:</strong>
        @Model.Message
      </div>
      }
    </div>
  </body>
</html>
```

---

# 8. Understand the HTML Controls

### Label

```html
<label for="studentName"> Student Name </label>
```

The label identifies what information the user should enter.

---

### TextBox

In Razor Pages, a TextBox can be created using:

```html
<input type="text" id="studentName" name="StudentName" />
```

It allows the user to enter text.

Example:

```text
Student Name
[ Pravin Nikam        ]
```

---

### Button

The button is:

```html
<button type="submit">Submit</button>
```

When the user clicks the button, the form is submitted to the server.

---

# 9. Write the C# Code

Open:

```text
Pages/Index.cshtml.cs
```

Replace its contents with:

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ControlsDemo.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string StudentName { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (!string.IsNullOrWhiteSpace(StudentName))
            {
                Message = $"Welcome, {StudentName}!";
            }
            else
            {
                Message = "Please enter your name.";
            }
        }
    }
}
```

---

# For increment and decrement Button

## Pages/Counter.cshtml

```html
@page @model ControlsDemo.Pages.CounterModel

<!DOCTYPE html>
<html>
  <head>
    <meta charset="utf-8" />
    <title>Counter Page</title>

    <style>
      body {
        font-family: Arial, sans-serif;
        text-align: center;
        margin-top: 100px;
      }

      .counter {
        font-size: 40px;
        margin: 20px;
      }

      button {
        padding: 10px 25px;
        font-size: 18px;
        margin: 5px;
        cursor: pointer;
      }
    </style>
  </head>

  <body>
    <h1>Counter Button</h1>

    <div class="counter">Counter: @Model.Count</div>

    <form method="post">
      <button type="submit" name="action" value="increment">Increment</button>

      <button type="submit" name="action" value="decrement">Decrement</button>
    </form>
  </body>
</html>
```

## Pages/Counter.cshtml.cs

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ControlsDemo.Pages
{
    public class IndexModel : PageModel
    {
        [TempData]
        public int Count { get; set; }

        public void OnGet()
        {
        }

        public void OnPost(string action)
        {
            if (action == "increment")
            {
                Count++;
            }
            else if (action == "decrement")
            {
                Count--;
            }
        }
    }
}
```

---

# 10. Understanding the C# Code

## `[BindProperty]`

```csharp
[BindProperty]
public string StudentName { get; set; } = string.Empty;
```

`[BindProperty]` connects the form input with the C# property.

The HTML TextBox has:

```html
name="StudentName"
```

and the C# class has:

```csharp
public string StudentName { get; set; }
```

Therefore, when the form is submitted, the entered value is automatically assigned to:

```csharp
StudentName
```

---

## OnGet()

```csharp
public void OnGet()
{
}
```

`OnGet()` executes when the webpage is opened using an HTTP GET request.

---

## OnPost()

```csharp
public void OnPost()
{
    ...
}
```

`OnPost()` executes when the form is submitted using:

```html
<form method="post"></form>
```

Therefore:

```text
Click Submit
     ↓
POST request
     ↓
OnPost()
     ↓
StudentName received
     ↓
Message generated
     ↓
Page displayed
```

---

# 11. Run the Application

Open the terminal.

Run:

```bash
dotnet run
```

Open the URL displayed by the terminal.

For example:

```text
http://localhost:5000
```

or

```text
https://localhost:7000
```

---

# 12. Test the Application

The webpage should display:

```text
Student Information

Student Name
[ Enter student name ]

[ Submit ]
```

Enter:

```text
Pravin Nikam
```

Click:

```text
Submit
```

The result should be:

```text
Message: Welcome, Pravin Nikam!
```

---

# 13. Test Empty Input

Leave the TextBox empty and click:

```text
Submit
```

The application should display:

```text
Message: Please enter your name.
```

This demonstrates basic server-side input checking.

---

# 14. Complete Working Flow

```text
                 Browser
                    │
                    ▼
          ┌──────────────────┐
          │ Student Name     │
          │ [ TextBox      ] │
          │                  │
          │ [ Submit Button ]│
          └────────┬─────────┘
                   │
                   │ POST
                   ▼
          ┌──────────────────┐
          │    OnPost()      │
          │      C#          │
          └────────┬─────────┘
                   │
                   ▼
          StudentName Property
                   │
                   ▼
          Generate Message
                   │
                   ▼
          Display on Webpage
```

---

# 15. Important Concepts

### Label

Used to identify an input field.

Example:

```html
<label>Student Name</label>
```

### TextBox

Used to accept text from the user.

Example:

```html
<input type="text" />
```

### Button

Used to submit the form.

Example:

```html
<button type="submit">Submit</button>
```

### Form

Groups input controls and sends their values to the server.

Example:

```html
<form method="post"></form>
```

### OnPost()

Handles the submitted form on the server.

```csharp
public void OnPost()
{
}
```

### Data Binding

Connects the HTML input value with a C# property.

```text
HTML TextBox
     ↓
name="StudentName"
     ↓
[BindProperty]
     ↓
StudentName
```

---

# 16. Final Project Structure

After completing the practical:

```text
ControlsDemo/
│
├── Pages/
│   ├── Index.cshtml
│   ├── Index.cshtml.cs
│   ├── Error.cshtml
│   ├── Error.cshtml.cs
│   └── Shared/
│
├── wwwroot/
│   ├── css/
│   └── js/
│
├── appsettings.json
├── Program.cs
└── ControlsDemo.csproj
```

---

# 17. Common Errors

### Error 1: Namespace mismatch

If the project is named:

```text
ControlsDemo
```

the code should contain:

```csharp
namespace ControlsDemo.Pages
```

and:

```html
@model ControlsDemo.Pages.IndexModel
```

---

### Error 2: `OnPost()` is not executing

Make sure the form contains:

```html
<form method="post"></form>
```

and the button contains:

```html
<button type="submit"></button>
```

---

### Error 3: StudentName is empty

Make sure the TextBox contains:

```html
name="StudentName"
```

and the C# property contains:

```csharp
[BindProperty]
public string StudentName { get; set; }
```

The names must match.

---

### Error 4: Application is not running

Run:

```bash
dotnet build
```

If there are no errors, run:

```bash
dotnet run
```

---

# 18. Viva Questions

### Q1. What is Razor Pages?

Razor Pages is a page-based programming model in ASP.NET Core used to build web applications.

### Q2. What is a TextBox?

A TextBox is an input control that allows users to enter text.

### Q3. How is a TextBox created in Razor Pages?

Using an HTML input element:

```html
<input type="text" />
```

### Q4. What is the purpose of a Button?

A Button allows the user to perform an action, such as submitting a form.

### Q5. What is `OnPost()`?

`OnPost()` is a Razor Pages handler method that executes when a form sends an HTTP POST request.

### Q6. What is `[BindProperty]`?

`[BindProperty]` enables form data to be bound automatically to a PageModel property.

### Q7. What is the purpose of `method="post"`?

It specifies that the form data should be sent to the server using an HTTP POST request.

### Q8. What is the difference between `OnGet()` and `OnPost()`?

| Method     | Purpose               |
| ---------- | --------------------- |
| `OnGet()`  | Handles GET requests  |
| `OnPost()` | Handles POST requests |

---

# 19. Result

The ASP.NET Core Razor Pages application was successfully developed to demonstrate the use of **Label, TextBox, and Button controls**. The application accepts the student's name through a TextBox, processes the submitted value using the `OnPost()` method, and displays the result on the webpage.
