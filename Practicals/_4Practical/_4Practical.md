# Practical 4: Display Student Information Using Data Binding in ASP.NET

## Aim

To develop an ASP.NET application that uses **Data Binding** to display student information:

- Student Name
- Student ID
- Student Location
- Age
- Gender

---

# 1. Introduction

**Data Binding** is the process of connecting a user interface control to a data source so that data can be displayed automatically.

In this practical:

```text
SQL Server Database
        ↓
     ADO.NET
        ↓
     DataTable
        ↓
    Data Binding
        ↓
ASP.NET Web Form
        ↓
Student Information
```

The student records stored in SQL Server are retrieved and displayed on an ASP.NET webpage using data binding.

---

# 2. Technology Used

- C#
- ASP.NET Web Forms
- ADO.NET
- SQL Server
- Visual Studio

> **Note:** ASP.NET Web Forms is a .NET Framework technology. Therefore, this practical uses a **.NET Framework ASP.NET Web Forms project**, not the modern `dotnet new` ASP.NET Core templates.

---

# 3. Database Setup

The application uses the `CollegeDB` database.

Open **SQL Server Management Studio (SSMS)** and execute:

```sql
CREATE DATABASE CollegeDB;
```

If the database already exists from the previous practical, do not create it again.

Select the database:

```sql
USE CollegeDB;
```

Create the Student table:

```sql
CREATE TABLE Student
(
    StudentID INT PRIMARY KEY IDENTITY(1,1),
    StudentName VARCHAR(100) NOT NULL,
    Location VARCHAR(100),
    Age INT,
    Gender VARCHAR(20)
);
```

Insert sample data:

```sql
INSERT INTO Student
(StudentName, Location, Age, Gender)
VALUES
('Rahul', 'Vadodara', 20, 'Male'),
('Priya', 'Ahmedabad', 21, 'Female'),
('Amit', 'Surat', 20, 'Male'),
('Neha', 'Rajkot', 22, 'Female');
```

Verify the records:

```sql
SELECT * FROM Student;
```

Expected result:

```text
StudentID   StudentName   Location     Age   Gender
------------------------------------------------------
1           Rahul         Vadodara     20    Male
2           Priya         Ahmedabad    21    Female
3           Amit          Surat        20    Male
4           Neha          Rajkot       22    Female
```

---

# 4. Create ASP.NET Web Forms Application

## Using Visual Studio

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
Project Name: StudentDataBinding
```

Select the required location and click **Create**.

In the next window select:

```text
Web Forms
```

Click **Create**.

---

# 5. Project Folder Structure

After creating the project, the structure will be similar to:

```text
StudentDataBinding/
│
├── App_Code/
│
├── App_Data/
│
├── Content/
│
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
└── StudentDataBinding.csproj
```

The important files for this practical are:

| File                       | Purpose                                         |
| -------------------------- | ----------------------------------------------- |
| `Default.aspx`             | Webpage design and ASP.NET controls             |
| `Default.aspx.cs`          | C# code-behind                                  |
| `Default.aspx.designer.cs` | Automatically generated control declarations    |
| `Web.config`               | Application configuration and connection string |
| `.csproj`                  | Project configuration                           |

---

# 6. Web Forms Page Structure

ASP.NET Web Forms uses two important files:

```text
Default.aspx
     ↓
User Interface

Default.aspx.cs
     ↓
C# Code
```

For example:

```text
Default.aspx
    |
    |-- Label
    |-- GridView
    |-- HTML/CSS
    |
    ↓
Default.aspx.cs
    |
    |-- Database connection
    |-- SQL query
    |-- Data binding
```

---

# 7. Design the Webpage

Open:

```text
Default.aspx
```

The page will display student records in a table.

The required fields are:

```text
Student ID
Student Name
Location
Age
Gender
```

The final webpage will look approximately like:

```text
----------------------------------------------------------
                 STUDENT INFORMATION
----------------------------------------------------------

----------------------------------------------------------
| ID | Student Name | Location | Age | Gender           |
----------------------------------------------------------
| 1  | Rahul        | Vadodara | 20  | Male             |
| 2  | Priya        | Ahmedabad| 21  | Female           |
| 3  | Amit         | Surat    | 20  | Male             |
| 4  | Neha         | Rajkot   | 22  | Female           |
----------------------------------------------------------
```

---

# 8. Add GridView Control

The `GridView` control is used to display tabular data.

Add the following GridView to `Default.aspx`:

```aspx
<asp:GridView
    ID="gvStudents"
    runat="server"
    AutoGenerateColumns="False">

    <Columns>

        <asp:BoundField
            DataField="StudentID"
            HeaderText="Student ID" />

        <asp:BoundField
            DataField="StudentName"
            HeaderText="Student Name" />

        <asp:BoundField
            DataField="Location"
            HeaderText="Location" />

        <asp:BoundField
            DataField="Age"
            HeaderText="Age" />

        <asp:BoundField
            DataField="Gender"
            HeaderText="Gender" />

    </Columns>

</asp:GridView>
```

---

# 9. Complete Default.aspx

Replace the contents of `Default.aspx` with:

```aspx
<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="StudentDataBinding.Default" %>

<!DOCTYPE html>

<html>
<head runat="server">

    <title>Student Data Binding</title>

    <style>

        body
        {
            font-family: Arial;
            margin: 40px;
        }

        h2
        {
            text-align: center;
        }

        .grid
        {
            width: 80%;
            margin: auto;
        }

        .grid th,
        .grid td
        {
            padding: 10px;
            text-align: center;
        }

    </style>

</head>

<body>

<form id="form1" runat="server">

    <h2>Student Information</h2>

    <div class="grid">

        <asp:GridView
            ID="gvStudents"
            runat="server"
            AutoGenerateColumns="False">

            <Columns>

                <asp:BoundField
                    DataField="StudentID"
                    HeaderText="Student ID" />

                <asp:BoundField
                    DataField="StudentName"
                    HeaderText="Student Name" />

                <asp:BoundField
                    DataField="Location"
                    HeaderText="Location" />

                <asp:BoundField
                    DataField="Age"
                    HeaderText="Age" />

                <asp:BoundField
                    DataField="Gender"
                    HeaderText="Gender" />

            </Columns>

        </asp:GridView>

    </div>

</form>

</body>
</html>
```

---

# 10. Configure Database Connection

Open:

```text
Web.config
```

Inside the `<configuration>` element, add:

```xml
<connectionStrings>

    <add name="CollegeDBConnection"
         connectionString="Server=.\SQLEXPRESS;Database=CollegeDB;Trusted_Connection=True;TrustServerCertificate=True;"
         providerName="System.Data.SqlClient" />

</connectionStrings>
```

The structure will be:

```xml
<configuration>

    <connectionStrings>

        <add name="CollegeDBConnection"
             connectionString="Server=.\SQLEXPRESS;Database=CollegeDB;Trusted_Connection=True;TrustServerCertificate=True;"
             providerName="System.Data.SqlClient" />

    </connectionStrings>

</configuration>
```

If the SQL Server instance is different, change:

```text
.\SQLEXPRESS
```

to the appropriate server name.

---

# 11. Why Store the Connection String in Web.config?

The connection string should not be repeatedly written inside the C# code.

Instead:

```text
Web.config
     ↓
Connection String
     ↓
C# Code
     ↓
SQL Server
```

This makes the database configuration easier to manage.

---

# 12. Write the C# Code

Open:

```text
Default.aspx.cs
```

The code-behind file contains the C# logic for the webpage.

Add the following namespaces:

```csharp
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
```

---

# 13. Retrieve Student Records

The following method retrieves records from SQL Server:

```csharp
private void LoadStudents()
{
    string connectionString =
        ConfigurationManager
        .ConnectionStrings["CollegeDBConnection"]
        .ConnectionString;

    using (SqlConnection con =
        new SqlConnection(connectionString))
    {
        string query = "SELECT * FROM Student";

        using (SqlCommand cmd =
            new SqlCommand(query, con))
        {
            con.Open();

            using (SqlDataReader reader =
                cmd.ExecuteReader())
            {
                DataTable dt = new DataTable();

                dt.Load(reader);

                gvStudents.DataSource = dt;

                gvStudents.DataBind();
            }
        }
    }
}
```

---

# 14. Understand Data Binding

The most important two statements are:

```csharp
gvStudents.DataSource = dt;
```

and:

```csharp
gvStudents.DataBind();
```

### DataSource

```text
DataSource
    ↓
Specifies where the data comes from
```

In this practical:

```text
DataTable
```

is the data source.

### DataBind()

```text
DataBind()
    ↓
Connects the control with its data source
    ↓
Displays the data
```

Therefore:

```text
SQL Server
    ↓
SqlDataReader
    ↓
DataTable
    ↓
DataSource
    ↓
DataBind()
    ↓
GridView
```

---

# 15. Load Data When Page Opens

The student records should be displayed automatically when the webpage opens.

Use the `Page_Load` event:

```csharp
protected void Page_Load(object sender, EventArgs e)
{
    if (!IsPostBack)
    {
        LoadStudents();
    }
}
```

### Why `!IsPostBack`?

`Page_Load` can execute every time the page is requested.

`!IsPostBack` ensures that the initial data binding happens when the page is opened for the first time.

The flow is:

```text
Page Opens
    ↓
Page_Load
    ↓
!IsPostBack
    ↓
LoadStudents()
    ↓
DataBind()
    ↓
GridView displays records
```

---

# 16. Complete Default.aspx.cs

The complete code-behind file is:

```csharp
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace StudentDataBinding
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(
            object sender,
            EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadStudents();
            }
        }

        private void LoadStudents()
        {
            string connectionString =
                ConfigurationManager
                .ConnectionStrings["CollegeDBConnection"]
                .ConnectionString;

            using (SqlConnection con =
                new SqlConnection(connectionString))
            {
                string query =
                    "SELECT * FROM Student";

                using (SqlCommand cmd =
                    new SqlCommand(query, con))
                {
                    con.Open();

                    using (SqlDataReader reader =
                        cmd.ExecuteReader())
                    {
                        DataTable dt =
                            new DataTable();

                        dt.Load(reader);

                        gvStudents.DataSource = dt;

                        gvStudents.DataBind();
                    }
                }
            }
        }
    }
}
```

---

# 17. How the Application Works

The complete execution process is:

```text
User opens webpage
       ↓
Default.aspx loads
       ↓
Page_Load executes
       ↓
LoadStudents()
       ↓
Connection to SQL Server
       ↓
SELECT * FROM Student
       ↓
SqlDataReader
       ↓
DataTable
       ↓
gvStudents.DataSource = dt
       ↓
gvStudents.DataBind()
       ↓
Student records displayed
```

---

# 18. Understanding GridView Binding

The GridView contains:

```aspx
<asp:BoundField
    DataField="StudentName"
    HeaderText="Student Name" />
```

Here:

### `DataField`

Specifies the database column:

```text
StudentName
```

### `HeaderText`

Specifies the column heading displayed on the webpage:

```text
Student Name
```

Therefore:

```text
Database Column
       ↓
StudentName
       ↓
DataField
       ↓
GridView
       ↓
Student Name
```

The same process is used for:

```text
StudentID
StudentName
Location
Age
Gender
```

---

# 19. Run the Application

Save all files.

In Visual Studio, press:

```text
Ctrl + F5
```

or click:

```text
Start Without Debugging
```

The browser will open the ASP.NET webpage.

The GridView should display the student records stored in SQL Server.

---

# 20. Expected Output

The webpage should display:

```text
                 Student Information

----------------------------------------------------------
| Student ID | Student Name | Location | Age | Gender   |
----------------------------------------------------------
| 1          | Rahul        | Vadodara | 20  | Male     |
| 2          | Priya        | Ahmedabad| 21  | Female   |
| 3          | Amit         | Surat    | 20  | Male     |
| 4          | Neha         | Rajkot   | 22  | Female   |
----------------------------------------------------------
```

---

# 21. Data Binding Concepts Used

This practical demonstrates:

### Data Source

The source containing the data.

```text
DataTable
```

### Data Control

The ASP.NET control displaying the data.

```text
GridView
```

### Data Binding

The process of connecting the data source with the control.

```csharp
gvStudents.DataSource = dt;
gvStudents.DataBind();
```

---

# 22. Important Classes and Controls

| Component       | Purpose                         |
| --------------- | ------------------------------- |
| `SqlConnection` | Connects to SQL Server          |
| `SqlCommand`    | Executes SQL query              |
| `SqlDataReader` | Reads database records          |
| `DataTable`     | Stores retrieved records        |
| `GridView`      | Displays records                |
| `DataSource`    | Specifies the data source       |
| `DataBind()`    | Binds data to the control       |
| `Page_Load`     | Executes when the webpage loads |

---

# 23. Important Files

```text
StudentDataBinding/
│
├── Default.aspx
│       ↓
│   Webpage/UI
│
├── Default.aspx.cs
│       ↓
│   C# database and binding logic
│
├── Default.aspx.designer.cs
│       ↓
│   Generated control declarations
│
├── Web.config
│       ↓
│   Database connection configuration
│
└── StudentDataBinding.csproj
        ↓
    Project configuration
```

---

# 24. Troubleshooting

## Error: "The name 'ConfigurationManager' does not exist"

Make sure this namespace is included:

```csharp
using System.Configuration;
```

For some .NET Framework project configurations, the `System.Configuration` assembly/reference may also need to be available.

---

## Error: "Cannot open database"

Check the connection string:

```xml
Server=.\SQLEXPRESS;
Database=CollegeDB;
```

Verify that:

- SQL Server is running.
- `CollegeDB` exists.
- The `Student` table exists.
- The server name is correct.

---

## Error: "Invalid object name 'Student'"

Make sure the query is using:

```sql
USE CollegeDB;
```

and that the table exists:

```sql
SELECT * FROM Student;
```

---

## Error: GridView Is Empty

Check the following:

1. Student records exist in the database.
2. The SQL query is correct.
3. `LoadStudents()` is called.
4. `DataSource` is assigned.
5. `DataBind()` is called.
6. `DataField` names match the database column names.

---

# 25. Practical Verification

Execute:

```sql
SELECT * FROM Student;
```

in SQL Server.

Then open the ASP.NET application.

The records displayed in the GridView should correspond to the records returned by the SQL query.

---

# 26. Result

A **Student Information ASP.NET Web Forms application** is successfully developed using **C# and ADO.NET**.

The application retrieves student information from SQL Server and displays it in a GridView using **Data Binding**.

---

# 27. Viva Questions

1. What is Data Binding?
2. What is ASP.NET Web Forms?
3. What is the purpose of GridView?
4. What is `DataSource`?
5. What is the purpose of `DataBind()`?
6. What is the difference between `DataSource` and `DataBind()`?
7. What is the purpose of `SqlConnection`?
8. What is `SqlDataReader`?
9. Why is `DataTable` used?
10. What is the purpose of `Page_Load`?
11. Why is `!IsPostBack` used?
12. What is the purpose of `Web.config`?
13. What is `DataField` in GridView?
14. What is the difference between `DataField` and `HeaderText`?
15. Explain the complete flow from SQL Server to GridView.
