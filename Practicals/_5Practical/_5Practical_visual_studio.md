# Practical 5: ASP.NET Webpage Using Label, Button and TextBox Controls

## Aim

To design an **ASP.NET Web Forms webpage** using the following server controls:

- Label
- TextBox
- Button

and display the data entered by the user.

---

# 1. Objective

This practical demonstrates how ASP.NET Web Forms controls are used to:

- Accept input using a `TextBox`.
- Display text using a `Label`.
- Perform an action using a `Button`.
- Handle a button click event using C#.
- Display the entered information dynamically on a webpage.

---

# 2. Technologies Used

- C#
- ASP.NET Web Forms
- .NET Framework
- Visual Studio

---

# 3. Create the ASP.NET Web Forms Project

Open **Visual Studio**.

Select:

```text
Create a new project
```

Search for:

```text
ASP.NET Web Application (.NET Framework)
```

Select:

```text
ASP.NET Web Application (.NET Framework)
```

Click **Next**.

Enter:

```text
Project Name: ControlsDemo
```

Select the required location.

Click **Create**.

Select:

```text
Web Forms
```

Click **Create**.

---

# 4. Project Folder Structure

The project will contain files similar to:

```text
ControlsDemo/
│
├── App_Code/
├── App_Data/
├── Content/
├── Scripts/
│
├── Default.aspx
├── Default.aspx.cs
├── Default.aspx.designer.cs
│
├── Global.asax
├── Site.Master
├── Site.Master.cs
│
├── Web.config
│
└── ControlsDemo.csproj
```

For this practical, the main files are:

```text
Default.aspx
       ↓
Webpage design

Default.aspx.cs
       ↓
C# event-handling logic

Default.aspx.designer.cs
       ↓
Automatically generated control declarations
```

---

# 5. ASP.NET Web Forms Controls

ASP.NET provides server-side controls that can be placed on a webpage.

The controls used in this practical are:

| Control | Purpose            |
| ------- | ------------------ |
| Label   | Displays text      |
| TextBox | Accepts input      |
| Button  | Performs an action |

These controls use:

```aspx
runat="server"
```

which allows them to be accessed and controlled from C# code.

---

# 6. Design of the Webpage

The webpage will contain:

```text
------------------------------------------
          USER INFORMATION
------------------------------------------

Enter Name:

[____________________________]

[ Display ]

Message:

Hello, Rahul!

------------------------------------------
```

The user enters a name into the TextBox and clicks the Button.

The Label then displays a message.

---

# 7. Add Label Control

Open:

```text
Default.aspx
```

Add a Label:

```aspx
<asp:Label
    ID="lblName"
    runat="server"
    Text="Enter Name:">
</asp:Label>
```

### Important Properties

| Property | Value         |
| -------- | ------------- |
| `ID`     | `lblName`     |
| `Text`   | `Enter Name:` |
| `runat`  | `server`      |

The `Text` property specifies what the Label displays.

---

# 8. Add TextBox Control

Add a TextBox:

```aspx
<asp:TextBox
    ID="txtName"
    runat="server">
</asp:TextBox>
```

The TextBox allows the user to enter information.

Important property:

```text
ID = txtName
```

The value entered by the user can be accessed in C# using:

```csharp
txtName.Text
```

---

# 9. Add Button Control

Add a Button:

```aspx
<asp:Button
    ID="btnDisplay"
    runat="server"
    Text="Display"
    OnClick="btnDisplay_Click" />
```

The Button performs an operation when clicked.

Important properties:

| Property  | Value              |
| --------- | ------------------ |
| `ID`      | `btnDisplay`       |
| `Text`    | `Display`          |
| `OnClick` | `btnDisplay_Click` |

---

# 10. Add Output Label

Add another Label to display the result:

```aspx
<asp:Label
    ID="lblMessage"
    runat="server">
</asp:Label>
```

The C# code will change its `Text` property.

---

# 11. Complete Default.aspx

Replace the contents of `Default.aspx` with:

```aspx
<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="ControlsDemo.Default" %>

<!DOCTYPE html>

<html>
<head runat="server">

    <title>ASP.NET Controls Demo</title>

    <style>

        body
        {
            font-family: Arial;
            margin: 50px;
        }

        .container
        {
            width: 500px;
            margin: auto;
        }

        h2
        {
            text-align: center;
        }

        .row
        {
            margin-bottom: 15px;
        }

        .textbox
        {
            width: 250px;
        }

    </style>

</head>

<body>

<form id="form1" runat="server">

    <div class="container">

        <h2>User Information</h2>

        <div class="row">

            <asp:Label
                ID="lblName"
                runat="server"
                Text="Enter Name:">
            </asp:Label>

        </div>

        <div class="row">

            <asp:TextBox
                ID="txtName"
                runat="server"
                CssClass="textbox">
            </asp:TextBox>

        </div>

        <div class="row">

            <asp:Button
                ID="btnDisplay"
                runat="server"
                Text="Display"
                OnClick="btnDisplay_Click" />

        </div>

        <div class="row">

            <asp:Label
                ID="lblMessage"
                runat="server">
            </asp:Label>

        </div>

    </div>

</form>

</body>
</html>
```

---

# 12. Understand the Page Directive

The first line is:

```aspx
<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="ControlsDemo.Default" %>
```

It specifies important information about the webpage.

### Language

```text
Language="C#"
```

Specifies that C# is used for the code-behind.

### CodeBehind

```text
CodeBehind="Default.aspx.cs"
```

Specifies the C# code-behind file.

### Inherits

```text
Inherits="ControlsDemo.Default"
```

Connects the webpage with its C# class.

---

# 13. Understand `runat="server"`

ASP.NET server controls contain:

```aspx
runat="server"
```

For example:

```aspx
<asp:TextBox
    ID="txtName"
    runat="server">
</asp:TextBox>
```

This makes the control available to the server-side C# code.

Therefore, the TextBox can be accessed using:

```csharp
txtName.Text
```

---

# 14. Create the Button Click Event

Open:

```text
Default.aspx.cs
```

Create the button click event:

```csharp
protected void btnDisplay_Click(
    object sender,
    EventArgs e)
{
    lblMessage.Text =
        "Hello, " + txtName.Text;
}
```

When the user clicks the button:

```text
Button Click
     ↓
btnDisplay_Click()
     ↓
Read txtName.Text
     ↓
Update lblMessage.Text
```

---

# 15. Complete Default.aspx.cs

The complete code is:

```csharp
using System;

namespace ControlsDemo
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(
            object sender,
            EventArgs e)
        {
        }

        protected void btnDisplay_Click(
            object sender,
            EventArgs e)
        {
            lblMessage.Text =
                "Hello, " + txtName.Text;
        }
    }
}
```

---

# 16. How the Application Works

Suppose the user enters:

```text
Rahul
```

in the TextBox.

The value can be accessed using:

```csharp
txtName.Text
```

When the user clicks:

```text
Display
```

the following statement executes:

```csharp
lblMessage.Text =
    "Hello, " + txtName.Text;
```

The Label displays:

```text
Hello, Rahul
```

---

# 17. Application Flow

```text
User
 ↓
Enters Name
 ↓
TextBox
 ↓
Clicks Button
 ↓
Button Click Event
 ↓
C# Code
 ↓
Read TextBox Value
 ↓
Update Label
 ↓
Display Result
```

---

# 18. Understanding the Controls

## Label

A Label displays text.

Example:

```aspx
<asp:Label
    ID="lblName"
    runat="server"
    Text="Enter Name:">
</asp:Label>
```

Its displayed text can also be changed using C#:

```csharp
lblMessage.Text = "Hello";
```

---

## TextBox

A TextBox accepts user input.

Example:

```aspx
<asp:TextBox
    ID="txtName"
    runat="server">
</asp:TextBox>
```

The entered value is obtained using:

```csharp
txtName.Text
```

---

## Button

A Button performs an action.

Example:

```aspx
<asp:Button
    ID="btnDisplay"
    runat="server"
    Text="Display"
    OnClick="btnDisplay_Click" />
```

The `OnClick` property specifies the C# method executed when the button is clicked.

---

# 19. Important Properties

### ID

Uniquely identifies a control.

Example:

```aspx
ID="txtName"
```

C# can then access the control using:

```csharp
txtName
```

---

### Text

Specifies the text displayed by a control.

Example:

```aspx
Text="Display"
```

For a TextBox, the entered value is available through:

```csharp
txtName.Text
```

---

### runat

```aspx
runat="server"
```

Makes the ASP.NET control available to server-side C# code.

---

### OnClick

Used with Button controls to specify the method executed after clicking the button.

Example:

```aspx
OnClick="btnDisplay_Click"
```

---

# 20. Run the Application

Save all files.

In Visual Studio, press:

```text
Ctrl + F5
```

or select:

```text
Start Without Debugging
```

The webpage will open in the browser.

---

# 21. Test the Application

### Test 1

Enter:

```text
Rahul
```

Click:

```text
Display
```

Expected output:

```text
Hello, Rahul
```

### Test 2

Enter:

```text
Priya
```

Click:

```text
Display
```

Expected output:

```text
Hello, Priya
```

---

# 22. Optional Improvement: Empty Input

The application can also check whether the TextBox is empty.

Replace the button event with:

```csharp
protected void btnDisplay_Click(
    object sender,
    EventArgs e)
{
    if (string.IsNullOrWhiteSpace(txtName.Text))
    {
        lblMessage.Text =
            "Please enter your name.";
    }
    else
    {
        lblMessage.Text =
            "Hello, " + txtName.Text;
    }
}
```

Now, if the user clicks **Display** without entering a name, the webpage displays:

```text
Please enter your name.
```

---

# 23. Final Folder Structure

The important project files are:

```text
ControlsDemo/
│
├── App_Code/
├── App_Data/
├── Content/
├── Scripts/
│
├── Default.aspx
│       ↓
│   ASP.NET webpage
│
├── Default.aspx.cs
│       ↓
│   C# code-behind
│
├── Default.aspx.designer.cs
│       ↓
│   Generated control declarations
│
├── Global.asax
│
├── Site.Master
├── Site.Master.cs
│
├── Web.config
│
└── ControlsDemo.csproj
```

For this practical, the main development work is performed in:

```text
Default.aspx
Default.aspx.cs
```

---

# 24. Complete Practical Workflow

```text
1. Open Visual Studio
        ↓
2. Create ASP.NET Web Application (.NET Framework)
        ↓
3. Select Web Forms
        ↓
4. Create project
        ↓
5. Open Default.aspx
        ↓
6. Add Label
        ↓
7. Add TextBox
        ↓
8. Add Button
        ↓
9. Add Output Label
        ↓
10. Set control IDs
        ↓
11. Set Button OnClick event
        ↓
12. Write C# event-handling code
        ↓
13. Save project
        ↓
14. Run application
        ↓
15. Enter data
        ↓
16. Click Display
        ↓
17. Verify output
```

---

# 25. Result

An **ASP.NET Web Forms webpage** is successfully developed using **Label, TextBox, and Button controls**. The application accepts user input through the TextBox and displays the result dynamically using the Label when the Button is clicked.

---

# 26. Viva Questions

1. What is ASP.NET Web Forms?
2. What is a Label control?
3. What is a TextBox control?
4. What is a Button control?
5. What is the purpose of the `ID` property?
6. What is `runat="server"`?
7. How can the value entered in a TextBox be accessed in C#?
8. What is the purpose of the `OnClick` property?
9. What is an event handler?
10. What is a code-behind file?
11. What is the purpose of `Default.aspx`?
12. What is the purpose of `Default.aspx.cs`?
13. What happens when the Display button is clicked?
14. How can the Label text be changed using C#?
15. What is the difference between `TextBox.Text` and `Label.Text`?
