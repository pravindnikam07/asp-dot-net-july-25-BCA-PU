# Practical 6: Design an ASP.NET Webpage Containing ListBox & DropDownList

## Aim

To design an ASP.NET Core webpage containing a **ListBox and DropDownList** and demonstrate selection of values using Razor Pages.

---

## 1. Software Requirements

| Requirement          | Details                 |
| -------------------- | ----------------------- |
| Operating System     | macOS / Windows         |
| IDE                  | Visual Studio Code      |
| Programming Language | C#                      |
| Framework            | ASP.NET Core            |
| Browser              | Chrome / Edge / Firefox |

---

# 2. Check .NET SDK

Before creating the project, open **VS Code**.

Open the integrated terminal:

**VS Code → Terminal → New Terminal**

Run:

```bash
dotnet --version
```

Example:

```text
10.0.100
```

The exact version may be different.

If a version number is displayed, the .NET SDK is installed correctly.

---

# 3. Create the ASP.NET Core Project

Navigate to the folder where you want to create the practical.

For example:

```bash
cd Desktop
```

Create a new ASP.NET Core Razor Pages project:

```bash
dotnet new webapp -n ListBoxDropDownDemo
```

The command creates a new project named:

```text
ListBoxDropDownDemo
```

---

# 4. Open the Project Folder

Move into the project directory:

```bash
cd ListBoxDropDownDemo
```

Open the project in VS Code:

```bash
code .
```

If the `code` command is not available, open VS Code manually and select:

**File → Open Folder → ListBoxDropDownDemo**

---

# 5. Restore Project Dependencies

Run:

```bash
dotnet restore
```

This downloads/restores the dependencies required by the project.

For this practical, **no additional NuGet package is required** because we are not using a database.

---

# 6. Verify the Project

Before modifying the code, run the default project:

```bash
dotnet run
```

The terminal will show something similar to:

```text
Now listening on: http://localhost:5000
```

The port may be different.

Open the displayed URL in your browser.

You should see the default ASP.NET Core Razor Pages application.

Stop the application using:

```text
Ctrl + C
```

---

# 7. Project Structure

After creating the project, the structure will look similar to:

```text
ListBoxDropDownDemo/
│
├── Pages/
│   ├── Error.cshtml
│   ├── Error.cshtml.cs
│   ├── Index.cshtml
│   ├── Index.cshtml.cs
│   ├── Privacy.cshtml
│   ├── Privacy.cshtml.cs
│   └── Shared/
│
├── Properties/
│   └── launchSettings.json
│
├── wwwroot/
│   ├── css/
│   ├── js/
│   └── favicon.ico
│
├── appsettings.json
├── appsettings.Development.json
├── Program.cs
└── ListBoxDropDownDemo.csproj
```

For this practical, we only need to modify:

```text
Pages/Index.cshtml
Pages/Index.cshtml.cs
```

---

# 8. Create the Webpage

Open:

```text
Pages/Index.cshtml
```

Delete the existing code and add:

```html
@page @model ListBoxDropDownDemo.Pages.IndexModel

<!DOCTYPE html>
<html>
  <head>
    <meta charset="utf-8" />
    <title>ListBox and DropDownList</title>

    <style>
      body {
        font-family: Arial, sans-serif;
        margin: 40px;
      }

      .container {
        width: 500px;
      }

      .control-group {
        margin-bottom: 25px;
      }

      label {
        display: block;
        font-weight: bold;
        margin-bottom: 8px;
      }

      select {
        width: 100%;
        padding: 8px;
        font-size: 16px;
      }

      .listbox {
        height: 130px;
      }

      button {
        padding: 10px 20px;
        font-size: 16px;
      }

      .result {
        margin-top: 20px;
        padding: 12px;
        border: 1px solid #ccc;
      }
    </style>
  </head>

  <body>
    <div class="container">
      <h1>ListBox and DropDownList</h1>

      <form method="post">
        <!-- DropDownList -->
        <div class="control-group">
          <label for="city"> Select City </label>

          <select id="city" name="SelectedCity">
            <option value="">-- Select City --</option>

            <option value="Vadodara">Vadodara</option>

            <option value="Ahmedabad">Ahmedabad</option>

            <option value="Surat">Surat</option>

            <option value="Rajkot">Rajkot</option>
          </select>
        </div>

        <!-- ListBox -->
        <div class="control-group">
          <label for="skills"> Select Skills </label>

          <select id="skills" name="SelectedSkills" class="listbox" multiple>
            <option value="C#">C#</option>
            <option value="Java">Java</option>
            <option value="Python">Python</option>
            <option value="JavaScript">JavaScript</option>
            <option value="SQL">SQL</option>
          </select>
        </div>

        <button type="submit">Submit</button>
      </form>

      @if (!string.IsNullOrEmpty(Model.SelectedCity) &&
      Model.SelectedSkills.Any()) {
      <div class="result">
        <h3>Selected Values</h3>

        <p>
          <strong>City:</strong>
          @Model.SelectedCity
        </p>

        <p>
          <strong>Skills:</strong>
          @string.Join(", ", Model.SelectedSkills)
        </p>
      </div>
      }
    </div>
  </body>
</html>
```

---

# 9. Add C# PageModel Code

Open:

```text
Pages/Index.cshtml.cs
```

Replace the existing code with:

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ListBoxDropDownDemo.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string SelectedCity { get; set; } = string.Empty;

        [BindProperty]
        public List<string> SelectedSkills { get; set; } = new();

        public void OnGet()
        {
        }

        public void OnPost()
        {
        }
    }
}
```

---

# 10. Understand the DropDownList

The DropDownList is created using:

```html
<select id="city" name="SelectedCity"></select>
```

Its options are created using `<option>`:

```html
<option value="Vadodara">Vadodara</option>
```

The user can select one city.

The selected value is automatically bound to:

```csharp
[BindProperty]
public string SelectedCity { get; set; }
```

---

# 11. Understand the ListBox

The ListBox is created using:

```html
<select id="skills" name="SelectedSkills" multiple></select>
```

The important attribute is:

```html
multiple
```

It allows the user to select more than one option.

The selected values are bound to:

```csharp
[BindProperty]
public List<string> SelectedSkills { get; set; }
```

Because multiple values can be selected, a `List<string>` is used.

---

# 12. How the Form Works

The webpage contains:

```html
<form method="post"></form>
```

When the user clicks **Submit**, the selected values are sent to the server.

The flow is:

```text
User selects City
        +
User selects Skills
        ↓
      Submit
        ↓
    HTTP POST
        ↓
ASP.NET Core Model Binding
        ↓
SelectedCity
SelectedSkills
        ↓
Razor Page
        ↓
Display selected values
```

---

# 13. Run the Application

Save all files.

In the VS Code terminal, run:

```bash
dotnet run
```

You will see a URL similar to:

```text
Now listening on: http://localhost:5000
```

Open that URL in your browser.

---

# 14. Test the DropDownList

Select:

```text
Vadodara
```

from the **Select City** dropdown.

---

# 15. Test the ListBox

Select multiple skills.

For example:

```text
C#
Java
SQL
```

On most systems, multiple items can be selected using:

- **Ctrl + Click** on Windows
- **Command (⌘) + Click** on macOS

---

# 16. Submit the Form

Click:

```text
Submit
```

The page should display:

```text
Selected Values

City: Vadodara

Skills: C#, Java, SQL
```

---

# 17. Expected Output

The webpage contains:

```text
ListBox and DropDownList

Select City
┌─────────────────────────────┐
│ -- Select City --         ▼ │
└─────────────────────────────┘

Select Skills
┌─────────────────────────────┐
│ C#                          │
│ Java                        │
│ Python                      │
│ JavaScript                  │
│ SQL                         │
└─────────────────────────────┘

[ Submit ]
```

After submitting:

```text
Selected Values

City: Vadodara

Skills: C#, Java, SQL
```

---

# 18. Difference Between ListBox and DropDownList

| Feature     | ListBox                      | DropDownList           |
| ----------- | ---------------------------- | ---------------------- |
| Display     | List of options              | Dropdown menu          |
| Selection   | Multiple selections possible | Normally one selection |
| HTML        | `<select multiple>`          | `<select>`             |
| C# property | `List<string>`               | `string`               |
| Example     | Skills                       | City                   |

---

# 19. Important Code

### DropDownList

```html
<select name="SelectedCity">
  <option value="Vadodara">Vadodara</option>
  <option value="Ahmedabad">Ahmedabad</option>
</select>
```

### ListBox

```html
<select name="SelectedSkills" multiple>
  <option value="C#">C#</option>
  <option value="Java">Java</option>
  <option value="Python">Python</option>
</select>
```

### C# Binding

```csharp
[BindProperty]
public string SelectedCity { get; set; } = string.Empty;

[BindProperty]
public List<string> SelectedSkills { get; set; } = new();
```

---

# 20. Common Errors

### `dotnet` command not found

Run:

```bash
dotnet --version
```

If it does not display a version, the .NET SDK needs to be installed.

### `code` command not found

Open the project manually in VS Code:

```text
File → Open Folder → ListBoxDropDownDemo
```

### Multiple ListBox values are not selected

Use:

- **Ctrl + Click** on Windows
- **Command + Click** on macOS

Also verify that the ListBox contains:

```html
multiple
```

### Selected values are not displayed

Verify:

```html
<form method="post"></form>
```

and make sure the names match the C# properties:

```html
name="SelectedCity"
```

```html
name="SelectedSkills"
```

---

# 21. Viva Questions

1. What is a ListBox?
2. What is a DropDownList?
3. Which HTML element is used to create these controls?
4. Which attribute allows multiple selection?
5. Why is `List<string>` used for the ListBox?
6. What is `[BindProperty]`?
7. What is model binding?
8. What is the purpose of `method="post"`?
9. What is the difference between `OnGet()` and `OnPost()`?
10. Why is a DropDownList useful in web applications?

---

# Result

An ASP.NET Core Razor Pages application was successfully created using VS Code. A **DropDownList** and **ListBox** were designed, and the selected values were received using C# model binding and displayed on the webpage.
