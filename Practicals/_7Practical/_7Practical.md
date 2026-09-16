# Practical 7: Develop a Registration Form with Validation Controls

## Aim

To develop a registration form in ASP.NET Core using Razor Pages and demonstrate form validation for user input.

---

## Learning Objectives

After completing this practical, you will be able to:

- Create a registration form using ASP.NET Core Razor Pages.
- Accept user input through form controls.
- Apply required-field validation.
- Validate string length.
- Validate email format.
- Validate numeric values.
- Compare two fields such as password and confirm password.
- Display validation messages on the webpage.
- Process valid form data using C#.

---

# 1. Software Requirements

| Requirement      | Software                |
| ---------------- | ----------------------- |
| Operating System | macOS / Windows         |
| IDE              | Visual Studio Code      |
| Language         | C#                      |
| Framework        | ASP.NET Core            |
| Browser          | Chrome / Edge / Firefox |

---

# 2. Validation Controls

A registration form should validate user input before processing it.

This practical demonstrates the following validation requirements:

| Validation               | Purpose                                                    |
| ------------------------ | ---------------------------------------------------------- |
| Required validation      | Ensures a field is not empty                               |
| String length validation | Ensures input has an appropriate length                    |
| Email validation         | Checks whether an email has a valid format                 |
| Range validation         | Checks whether a numeric value is within a specified range |
| Compare validation       | Checks whether two values match                            |
| Custom validation        | Allows application-specific validation rules               |

ASP.NET Core uses **Data Annotation attributes** to implement these validations.

---

# 3. Create the ASP.NET Core Project

Open **VS Code**.

Open:

**Terminal → New Terminal**

Check the .NET SDK:

```bash
dotnet --version
```

Create the project:

```bash
dotnet new webapp -n RegistrationValidationDemo
```

Move into the project:

```bash
cd RegistrationValidationDemo
```

Open the project:

```bash
code .
```

---

# 4. Run the Initial Project

Before making changes, verify that the project works:

```bash
dotnet run
```

The terminal will display a URL similar to:

```text
Now listening on: http://localhost:5000
```

The port may be different.

Open the URL in a browser.

Stop the application:

```text
Ctrl + C
```

---

# 5. Project Structure

The important files are:

```text
RegistrationValidationDemo/
│
├── Pages/
│   ├── Index.cshtml
│   └── Index.cshtml.cs
│
├── wwwroot/
│   ├── css/
│   └── js/
│
├── appsettings.json
├── Program.cs
└── RegistrationValidationDemo.csproj
```

For this practical, modify:

```text
Pages/Index.cshtml
Pages/Index.cshtml.cs
```

---

# 6. Create the Registration Model

Open:

```text
Pages/Index.cshtml.cs
```

Replace the existing code with:

```csharp
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RegistrationValidationDemo.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(50, MinimumLength = 3,
            ErrorMessage = "Full name must be between 3 and 50 characters.")]
        public string FullName { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Age is required.")]
        [Range(18, 60, ErrorMessage = "Age must be between 18 and 60.")]
        public int? Age { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(20, MinimumLength = 8,
            ErrorMessage = "Password must be between 8 and 20 characters.")]
        public string Password { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Confirm password is required.")]
        [Compare("Password",
            ErrorMessage = "Password and Confirm Password must match.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^[0-9]{10}$",
            ErrorMessage = "Phone number must contain exactly 10 digits.")]
        public string Phone { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                Message = "Registration successful!";
            }
        }
    }
}
```

---

# 7. Understanding the Validation Attributes

The validation rules are defined using Data Annotation attributes.

## Required

```csharp
[Required(ErrorMessage = "Full name is required.")]
```

Ensures that the user provides a value.

---

## StringLength

```csharp
[StringLength(50, MinimumLength = 3)]
```

Ensures that the name contains between 3 and 50 characters.

---

## EmailAddress

```csharp
[EmailAddress(ErrorMessage = "Enter a valid email address.")]
```

Checks whether the entered value follows an email address format.

Example:

```text
student@example.com
```

---

## Range

```csharp
[Range(18, 60)]
```

Ensures that the age is between 18 and 60.

---

## Compare

```csharp
[Compare("Password")]
```

Compares `ConfirmPassword` with `Password`.

The two values must match.

---

## RegularExpression

```csharp
[RegularExpression(@"^[0-9]{10}$")]
```

Checks that the phone number contains exactly 10 digits.

Example:

```text
9876543210
```

---

# 8. Design the Registration Form

Open:

```text
Pages/Index.cshtml
```

Delete the existing contents and add:

```cshtml
@page
@model RegistrationValidationDemo.Pages.IndexModel

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />

    <title>Registration Form</title>

    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 40px;
        }

        .container {
            width: 500px;
            margin: auto;
        }

        h1 {
            text-align: center;
            margin-bottom: 25px;
        }

        .form-group {
            margin-bottom: 18px;
        }

        label {
            display: block;
            font-weight: bold;
            margin-bottom: 6px;
        }

        input,
        select {
            width: 100%;
            padding: 9px;
            box-sizing: border-box;
            font-size: 15px;
        }

        .gender {
            width: auto;
        }

        .validation {
            color: red;
            font-size: 14px;
        }

        .summary {
            color: red;
            margin-bottom: 15px;
        }

        button {
            padding: 10px 25px;
            font-size: 16px;
            cursor: pointer;
        }

        .success {
            margin-top: 20px;
            padding: 12px;
            border: 1px solid #999;
        }
    </style>
</head>

<body>

<div class="container">

    <h1>Registration Form</h1>

    <form method="post">

        <div asp-validation-summary="All" class="summary"></div>

        <!-- Full Name -->
        <div class="form-group">

            <label asp-for="FullName">
                Full Name
            </label>

            <input asp-for="FullName" />

            <span asp-validation-for="FullName"
                  class="validation">
            </span>

        </div>

        <!-- Email -->
        <div class="form-group">

            <label asp-for="Email">
                Email
            </label>

            <input asp-for="Email"
                   type="email" />

            <span asp-validation-for="Email"
                  class="validation">
            </span>

        </div>

        <!-- Age -->
        <div class="form-group">

            <label asp-for="Age">
                Age
            </label>

            <input asp-for="Age"
                   type="number" />

            <span asp-validation-for="Age"
                  class="validation">
            </span>

        </div>

        <!-- Phone -->
        <div class="form-group">

            <label asp-for="Phone">
                Phone Number
            </label>

            <input asp-for="Phone"
                   type="text" />

            <span asp-validation-for="Phone"
                  class="validation">
            </span>

        </div>

        <!-- City -->
        <div class="form-group">

            <label asp-for="City">
                City
            </label>

            <select asp-for="City">

                <option value="">
                    -- Select City --
                </option>

                <option value="Vadodara">
                    Vadodara
                </option>

                <option value="Ahmedabad">
                    Ahmedabad
                </option>

                <option value="Surat">
                    Surat
                </option>

                <option value="Rajkot">
                    Rajkot
                </option>

            </select>

            <span asp-validation-for="City"
                  class="validation">
            </span>

        </div>

        <!-- Gender -->
        <div class="form-group">

            <label>
                Gender
            </label>

            <input asp-for="Gender"
                   type="radio"
                   value="Male"
                   class="gender" />

            Male

            <input asp-for="Gender"
                   type="radio"
                   value="Female"
                   class="gender" />

            Female

            <br />

            <span asp-validation-for="Gender"
                  class="validation">
            </span>

        </div>

        <!-- Password -->
        <div class="form-group">

            <label asp-for="Password">
                Password
            </label>

            <input asp-for="Password"
                   type="password" />

            <span asp-validation-for="Password"
                  class="validation">
            </span>

        </div>

        <!-- Confirm Password -->
        <div class="form-group">

            <label asp-for="ConfirmPassword">
                Confirm Password
            </label>

            <input asp-for="ConfirmPassword"
                   type="password" />

            <span asp-validation-for="ConfirmPassword"
                  class="validation">
            </span>

        </div>

        <button type="submit">
            Register
        </button>

    </form>

    @if (!string.IsNullOrEmpty(Model.Message))
    {
        <div class="success">
            <strong>@Model.Message</strong>
        </div>
    }

</div>

</body>
</html>
```

---

# 9. Important Validation Elements

### Validation Summary

```html
<div asp-validation-summary="All"></div>
```

Displays all validation errors together.

### Field Validation

For example:

```html
<span asp-validation-for="Email" class="validation"> </span>
```

Displays the validation message associated with the Email property.

### Input Binding

```html
<input asp-for="Email" />
```

connects the HTML input with:

```csharp
public string Email { get; set; }
```

---

# 10. Form Processing

The form uses:

```html
<form method="post"></form>
```

When the user clicks **Register**, the form is submitted to the server.

The following method handles the submission:

```csharp
public void OnPost()
{
    if (ModelState.IsValid)
    {
        Message = "Registration successful!";
    }
}
```

`ModelState.IsValid` checks whether all validation rules have been satisfied.

The flow is:

```text
User enters data
       ↓
Submit Registration Form
       ↓
ASP.NET Core Model Binding
       ↓
Validation
       ↓
ModelState.IsValid
       ↓
 ┌───────────────┐
 │               │
Valid          Invalid
 │               │
 ↓               ↓
Success       Show Errors
```

---

# 11. Run the Application

Save both files.

Run:

```bash
dotnet run
```

Open the URL displayed in the terminal.

---

# 12. Test Validation

## Test 1: Empty Form

Click **Register** without entering any information.

Validation messages should appear for the required fields.

---

## Test 2: Invalid Email

Enter:

```text
abc
```

The application should display:

```text
Enter a valid email address.
```

---

## Test 3: Invalid Age

Enter:

```text
15
```

The application should display:

```text
Age must be between 18 and 60.
```

---

## Test 4: Invalid Phone Number

Enter:

```text
12345
```

The application should display:

```text
Phone number must contain exactly 10 digits.
```

---

## Test 5: Password Mismatch

Enter:

```text
Password:       student123
Confirm Password: student456
```

The application should display:

```text
Password and Confirm Password must match.
```

---

## Test 6: Valid Registration

Enter valid information:

```text
Full Name:       Aarav Patel
Email:           aarav@example.com
Age:             20
Phone:           9876543210
City:            Vadodara
Gender:          Male
Password:        student123
Confirm Password: student123
```

Click:

```text
Register
```

The application should display:

```text
Registration successful!
```

---

# 13. Validation Controls Used

| Validation Requirement | ASP.NET Core Implementation |
| ---------------------- | --------------------------- |
| Required Field         | `[Required]`                |
| String Length          | `[StringLength]`            |
| Email                  | `[EmailAddress]`            |
| Range                  | `[Range]`                   |
| Compare                | `[Compare]`                 |
| Pattern                | `[RegularExpression]`       |
| Display all errors     | `asp-validation-summary`    |
| Display field error    | `asp-validation-for`        |

---

# 14. Result

A registration form was successfully developed using **ASP.NET Core Razor Pages**. The form accepts user information and validates the input using Data Annotation validation attributes such as `Required`, `StringLength`, `EmailAddress`, `Range`, `Compare`, and `RegularExpression`.

---

# Viva Questions

1. What is form validation?
2. Why is validation required in a registration form?
3. What is the purpose of `[Required]`?
4. What is `[StringLength]` used for?
5. What does `[EmailAddress]` validate?
6. What is the purpose of `[Range]`?
7. Why is `[Compare]` used for passwords?
8. What is `[RegularExpression]`?
9. What is `ModelState.IsValid`?
10. What is `asp-validation-for`?
11. What is `asp-validation-summary`?
12. What is the difference between client-side and server-side validation?
13. What is model binding in ASP.NET Core?
14. What is the purpose of `[BindProperty]`?
15. What happens when the submitted form contains invalid data?
