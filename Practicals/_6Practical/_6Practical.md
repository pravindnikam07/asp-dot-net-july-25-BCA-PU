# Practical 6: Design an ASP.NET Webpage Containing ListBox & DropDownList

## Aim

To design an ASP.NET Core webpage containing a **ListBox** and **DropDownList** and demonstrate how to select values from both controls.

---

## Learning Objectives

After completing this practical, you will be able to:

- Create an ASP.NET Core Razor Pages application.
- Create a ListBox using HTML/Razor.
- Create a DropDownList using HTML/Razor.
- Handle selected values using C#.
- Display the selected values on the webpage.

---

## Software Requirements

| Requirement      | Software                |
| ---------------- | ----------------------- |
| Operating System | macOS / Windows         |
| IDE              | Visual Studio Code      |
| Language         | C#                      |
| Framework        | ASP.NET Core            |
| Browser          | Chrome / Edge / Firefox |

---

# 1. Concept

A webpage can provide different controls for allowing users to select values.

### ListBox

A **ListBox** displays multiple options in a visible list. The user can select one or multiple options.

Example:

```text
Select Skills

☐ C#
☐ Java
☐ Python
☐ JavaScript
☐ SQL
```

### DropDownList

A **DropDownList** displays options in a compact dropdown menu. Normally, the user selects one option.

Example:

```text
Select City
[ Vadodara ▼ ]
```

In ASP.NET Core Razor Pages, these controls can be created using standard HTML elements:

```html
<select></select>
```

A ListBox can be created by using the `multiple` attribute, while a normal `<select>` element is used as a DropDownList.

---

# 2. Create the Project

Open VS Code and open a terminal.

Create a new ASP.NET Core Razor Pages project:

```bash
dotnet new webapp -n ListBoxDropDownDemo
```

Move into the project:

```bash
cd ListBoxDropDownDemo
```

Open the project in VS Code:

```bash
code .
```

---

# 3. Project Structure

The important files are:

```text
ListBoxDropDownDemo/
│
├── Pages/
│   ├── Index.cshtml
│   └── Index.cshtml.cs
│
├── wwwroot/
│
├── appsettings.json
├── Program.cs
└── ListBoxDropDownDemo.csproj
```

For this practical, we will modify:

```text
Pages/Index.cshtml
Pages/Index.cshtml.cs
```

---

# 4. Design the Webpage

Open:

```text
Pages/Index.cshtml
```

Replace its contents with:

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
        cursor: pointer;
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

      @if (!string.IsNullOrEmpty(Model.SelectedCity)) {
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

# 5. Handle Selected Values Using C#

Open:

```text
Pages/Index.cshtml.cs
```

Replace its contents with:

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
        public List<string> SelectedSkills { get; set; } = new List<string>();

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

# 6. Understanding the Code

## DropDownList

The following code creates the DropDownList:

```html
<select id="city" name="SelectedCity"></select>
```

The available options are:

```html
<option value="Vadodara">Vadodara</option>
<option value="Ahmedabad">Ahmedabad</option>
<option value="Surat">Surat</option>
<option value="Rajkot">Rajkot</option>
```

The user can select **one city**.

---

## ListBox

The ListBox is created using:

```html
<select id="skills" name="SelectedSkills" multiple></select>
```

The important attribute is:

```text
multiple
```

It allows the user to select multiple options.

The available options are:

```html
<option value="C#">C#</option>
<option value="Java">Java</option>
<option value="Python">Python</option>
<option value="JavaScript">JavaScript</option>
<option value="SQL">SQL</option>
```

---

# 7. Data Binding Between HTML and C#

The DropDownList uses:

```html
name="SelectedCity"
```

and the C# page model contains:

```csharp
[BindProperty]
public string SelectedCity { get; set; }
```

Similarly, the ListBox uses:

```html
name="SelectedSkills"
```

and the C# page model contains:

```csharp
[BindProperty]
public List<string> SelectedSkills { get; set; }
```

ASP.NET Core binds the submitted form values to these properties.

The basic flow is:

```text
User Selection
      ↓
HTML Form
      ↓
POST Request
      ↓
ASP.NET Core Model Binding
      ↓
C# Properties
      ↓
Razor Page
      ↓
Display Result
```

---

# 8. Run the Application

Open the terminal in the project directory:

```bash
dotnet run
```

The terminal will display a local URL similar to:

```text
Now listening on: http://localhost:5000
```

The port number may be different.

Open the displayed URL in a browser.

---

# 9. Expected Output

The webpage displays:

```text
ListBox and DropDownList

Select City
[ -- Select City --          ▼ ]

Select Skills
┌──────────────────────────┐
│ C#                       │
│ Java                     │
│ Python                   │
│ JavaScript               │
│ SQL                      │
└──────────────────────────┘

[ Submit ]
```

The city dropdown allows one selection.

The ListBox allows multiple selections.

---

# 10. Test the Application

### Test 1: DropDownList

Select:

```text
Vadodara
```

### Test 2: ListBox

Select:

```text
C#
Java
SQL
```

Then click:

```text
Submit
```

The result should display:

```text
Selected Values

City: Vadodara

Skills: C#, Java, SQL
```

---

# 11. ListBox vs DropDownList

| Feature             | ListBox             | DropDownList  |
| ------------------- | ------------------- | ------------- |
| Displays options    | List                | Dropdown      |
| Multiple selection  | Yes                 | Normally no   |
| Space required      | More                | Less          |
| HTML implementation | `<select multiple>` | `<select>`    |
| Example             | Skills              | City          |
| Suitable for        | Multiple choices    | Single choice |

---

# 12. Important HTML Elements

### `<select>`

Creates a selection control.

```html
<select></select>
```

### `<option>`

Defines an option:

```html
<option value="Java">Java</option>
```

### `multiple`

Allows multiple selections:

```html
<select multiple></select>
```

### `name`

Associates the HTML control with a server-side property:

```html
<select name="SelectedCity"></select>
```

---

# 13. Common Errors

### Error 1: `dotnet` command not found

Check whether the .NET SDK is installed:

```bash
dotnet --version
```

If the command is not recognized, install the .NET SDK.

---

### Error 2: Page does not show selected values

Make sure the form contains:

```html
<form method="post"></form>
```

and the controls have the correct `name` attributes:

```html
name="SelectedCity"
```

and:

```html
name="SelectedSkills"
```

---

### Error 3: Multiple skills are not received

Make sure the ListBox contains:

```html
multiple
```

and the C# property is a collection:

```csharp
public List<string> SelectedSkills { get; set; }
```

---

# 14. Viva Questions

### 1. What is a ListBox?

A ListBox is a control that displays a list of options and can allow the user to select one or multiple values.

### 2. What is a DropDownList?

A DropDownList displays a list of options in a dropdown menu, normally allowing one option to be selected.

### 3. Which HTML element is used for both controls?

The HTML `<select>` element is used.

### 4. How is multiple selection enabled?

The `multiple` attribute is used:

```html
<select multiple></select>
```

### 5. What is the purpose of the `<option>` element?

It defines an individual option inside a selection control.

### 6. What is `[BindProperty]`?

`[BindProperty]` allows ASP.NET Core Razor Pages to bind submitted form values to a PageModel property.

### 7. Why is `List<string>` used for ListBox values?

Because the ListBox can contain multiple selected values.

### 8. What is the difference between `OnGet()` and `OnPost()`?

`OnGet()` handles HTTP GET requests, while `OnPost()` handles form submissions using HTTP POST.

### 9. Why is `method="post"` used?

It sends the selected form values to the server using an HTTP POST request.

### 10. What is model binding?

Model binding is the process of automatically mapping HTTP request data to C# properties or parameters.

---

# Result

An ASP.NET Core webpage containing a **ListBox and DropDownList** was successfully designed using Razor Pages. The application accepts selections from both controls and displays the selected values using C# model binding.
