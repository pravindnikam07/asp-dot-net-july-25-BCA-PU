# Practical 3: Software Development Using Windows Forms and ADO.NET

## Aim

To develop a **Windows Forms desktop application using C# and ADO.NET** for performing CRUD operations on student records stored in SQL Server.

---

# 1. Software Requirements

The following software is required:

- .NET SDK
- Visual Studio or Visual Studio Code
- SQL Server
- SQL Server Management Studio (SSMS)

The application uses:

```text
C#
↓
Windows Forms
↓
ADO.NET
↓
SQL Server
```

---

# 2. Application to Be Developed

A **Student Management System** is developed with the following operations:

1. Add Student
2. View Students
3. Update Student
4. Delete Student
5. Clear Form

The application contains:

- Student ID
- Student Name
- Location
- Age
- Gender
- Add button
- Update button
- Delete button
- Clear button
- DataGridView for displaying records

---

# 3. Database Creation

Before creating the application, create the database and table in SQL Server.

Open **SQL Server Management Studio (SSMS)** and execute the following SQL commands.

## Create Database

```sql
CREATE DATABASE CollegeDB;
```

Select the database:

```sql
USE CollegeDB;
```

## Create Student Table

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

## Insert Sample Records

The following records can be inserted for testing:

```sql
INSERT INTO Student
(StudentName, Location, Age, Gender)
VALUES
('Rahul', 'Vadodara', 20, 'Male'),
('Priya', 'Ahmedabad', 21, 'Female'),
('Amit', 'Surat', 20, 'Male');
```

Check the records:

```sql
SELECT * FROM Student;
```

The database structure is:

```text
CollegeDB
   │
   └── Student
        ├── StudentID
        ├── StudentName
        ├── Location
        ├── Age
        └── Gender
```

---

# 4. Create the Windows Forms Application

Open Terminal or Command Prompt.

Create a folder for the practical:

```bash
mkdir StudentWinForms
```

Move into the folder:

```bash
cd StudentWinForms
```

Create a Windows Forms application:

```bash
dotnet new winforms
```

Install the SQL Server ADO.NET provider:

```bash
dotnet add package Microsoft.Data.SqlClient
```

Open the project in Visual Studio Code:

```bash
code .
```

Run the application to verify that the project was created correctly:

```bash
dotnet run
```

A Windows Forms window should appear.

---

# 5. Project Folder Structure

After creating the project, the folder structure will be similar to:

```text
StudentWinForms/
│
├── bin/
├── obj/
│
├── Form1.cs
├── Form1.Designer.cs
├── Form1.resx
│
├── Program.cs
│
├── StudentWinForms.csproj
│
└── StudentWinForms.sln
```

### Important Files

| File                | Purpose                                       |
| ------------------- | --------------------------------------------- |
| `Program.cs`        | Starting point of the application             |
| `Form1.cs`          | Contains form logic and event-handling code   |
| `Form1.Designer.cs` | Contains automatically generated UI code      |
| `Form1.resx`        | Contains form resources                       |
| `.csproj`           | Project configuration and package information |
| `bin/`              | Contains compiled application files           |
| `obj/`              | Contains temporary build files                |

### Important

Most application logic should be written in:

```text
Form1.cs
```

Do not manually modify:

```text
Form1.Designer.cs
```

when using the Windows Forms Designer.

---

# 6. Open the Project in Visual Studio

For students using **Visual Studio**, open the project/solution in Visual Studio.

The Windows Forms Designer can be used to visually design the form.

The basic process is:

```text
Open Project
    ↓
Open Form1
    ↓
Open Windows Forms Designer
    ↓
Drag controls onto the form
    ↓
Set control properties
    ↓
Write C# event-handling code
```

---

# 7. Design the Form

Create the following user interface.

```text
----------------------------------------------------
              STUDENT MANAGEMENT SYSTEM
----------------------------------------------------

Student ID     [________________________]

Student Name   [________________________]

Location       [________________________]

Age            [________________________]

Gender         [ Select Gender ▼ ]

             [ Add ] [ Update ] [ Delete ] [ Clear ]

----------------------------------------------------
                    STUDENT LIST
----------------------------------------------------

----------------------------------------------------
| ID | Name | Location | Age | Gender             |
----------------------------------------------------
|    |      |          |     |                    |
|    |      |          |     |                    |
----------------------------------------------------
```

---

# 8. Add Labels

Add five `Label` controls.

Set their Text properties to:

```text
Student ID
Student Name
Location
Age
Gender
```

---

# 9. Add TextBoxes

Add four `TextBox` controls.

Set their `Name` properties as:

| Field        | Control Name     |
| ------------ | ---------------- |
| Student ID   | `txtStudentID`   |
| Student Name | `txtStudentName` |
| Location     | `txtLocation`    |
| Age          | `txtAge`         |

The Student ID field is mainly used to identify an existing record for Update and Delete operations.

---

# 10. Add ComboBox

Add a `ComboBox`.

Set its name to:

```text
cmbGender
```

Add the following items:

```text
Male
Female
Other
```

The ComboBox allows the user to select a gender instead of entering it manually.

---

# 11. Add Buttons

Add four Button controls.

Set their properties as follows:

| Button | Name        | Text   |
| ------ | ----------- | ------ |
| Add    | `btnAdd`    | Add    |
| Update | `btnUpdate` | Update |
| Delete | `btnDelete` | Delete |
| Clear  | `btnClear`  | Clear  |

The **Name** property is used in C# code.

The **Text** property is displayed on the button.

---

# 12. Add DataGridView

Add a `DataGridView` control to the bottom portion of the form.

Set its name to:

```text
dgvStudents
```

The DataGridView displays records retrieved from SQL Server.

Example:

```text
--------------------------------------------------------
| StudentID | StudentName | Location | Age | Gender   |
--------------------------------------------------------
| 1         | Rahul       | Vadodara | 20  | Male     |
| 2         | Priya       | Ahmedabad| 21  | Female   |
--------------------------------------------------------
```

---

# 13. Final Control List

The form should contain approximately the following controls:

```text
Labels
├── lblStudentID
├── lblStudentName
├── lblLocation
├── lblAge
└── lblGender

TextBoxes
├── txtStudentID
├── txtStudentName
├── txtLocation
└── txtAge

ComboBox
└── cmbGender

Buttons
├── btnAdd
├── btnUpdate
├── btnDelete
└── btnClear

DataGridView
└── dgvStudents
```

The exact names of Label controls are not important for the CRUD code, but the names of the input controls should match the code.

---

# 14. Install ADO.NET SQL Server Package

The project uses `Microsoft.Data.SqlClient` to communicate with SQL Server.

If it has not already been installed, execute:

```bash
dotnet add package Microsoft.Data.SqlClient
```

After installation, the project file contains the package reference.

---

# 15. Import Required Namespace

Open:

```text
Form1.cs
```

At the top of the file, add:

```csharp
using Microsoft.Data.SqlClient;
using System.Data;
```

---

# 16. Create Database Connection String

Inside the `Form1` class, define the connection string:

```csharp
string connectionString =
    @"Server=.\SQLEXPRESS;
      Database=CollegeDB;
      Trusted_Connection=True;
      TrustServerCertificate=True;";
```

### Connection String Explanation

```text
Server
   ↓
SQL Server instance

Database
   ↓
CollegeDB

Trusted_Connection
   ↓
Windows authentication

TrustServerCertificate
   ↓
Allows the local SQL Server connection
```

If the SQL Server instance is different, the `Server` value must be changed accordingly.

Common examples include:

```text
.\SQLEXPRESS
```

or

```text
localhost
```

or

```text
(localdb)\MSSQLLocalDB
```

---

# 17. Complete Form Code

The following code contains the complete CRUD functionality.

Open:

```text
Form1.cs
```

Keep the automatically generated constructor and add the required methods and event handlers.

```csharp
using Microsoft.Data.SqlClient;
using System.Data;

namespace StudentWinForms
{
    public partial class Form1 : Form
    {
        string connectionString =
            @"Server=.\SQLEXPRESS;
              Database=CollegeDB;
              Trusted_Connection=True;
              TrustServerCertificate=True;";

        public Form1()
        {
            InitializeComponent();
        }

        // Load students into DataGridView
        void LoadStudents()
        {
            using SqlConnection con =
                new SqlConnection(connectionString);

            string query = "SELECT * FROM Student";

            using SqlCommand cmd =
                new SqlCommand(query, con);

            con.Open();

            using SqlDataReader reader =
                cmd.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(reader);

            dgvStudents.DataSource = dt;
        }

        // Add Student
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using SqlConnection con =
                new SqlConnection(connectionString);

            string query = @"INSERT INTO Student
                            (StudentName, Location, Age, Gender)
                            VALUES
                            (@StudentName, @Location, @Age, @Gender)";

            using SqlCommand cmd =
                new SqlCommand(query, con);

            cmd.Parameters.AddWithValue(
                "@StudentName",
                txtStudentName.Text);

            cmd.Parameters.AddWithValue(
                "@Location",
                txtLocation.Text);

            cmd.Parameters.AddWithValue(
                "@Age",
                int.Parse(txtAge.Text));

            cmd.Parameters.AddWithValue(
                "@Gender",
                cmbGender.Text);

            con.Open();

            cmd.ExecuteNonQuery();

            MessageBox.Show("Student added successfully.");

            LoadStudents();

            ClearFields();
        }

        // Update Student
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using SqlConnection con =
                new SqlConnection(connectionString);

            string query = @"UPDATE Student
                             SET StudentName = @StudentName,
                                 Location = @Location,
                                 Age = @Age,
                                 Gender = @Gender
                             WHERE StudentID = @StudentID";

            using SqlCommand cmd =
                new SqlCommand(query, con);

            cmd.Parameters.AddWithValue(
                "@StudentID",
                int.Parse(txtStudentID.Text));

            cmd.Parameters.AddWithValue(
                "@StudentName",
                txtStudentName.Text);

            cmd.Parameters.AddWithValue(
                "@Location",
                txtLocation.Text);

            cmd.Parameters.AddWithValue(
                "@Age",
                int.Parse(txtAge.Text));

            cmd.Parameters.AddWithValue(
                "@Gender",
                cmbGender.Text);

            con.Open();

            cmd.ExecuteNonQuery();

            MessageBox.Show("Student updated successfully.");

            LoadStudents();

            ClearFields();
        }

        // Delete Student
        private void btnDelete_Click(object sender, EventArgs e)
        {
            using SqlConnection con =
                new SqlConnection(connectionString);

            string query =
                "DELETE FROM Student WHERE StudentID = @StudentID";

            using SqlCommand cmd =
                new SqlCommand(query, con);

            cmd.Parameters.AddWithValue(
                "@StudentID",
                int.Parse(txtStudentID.Text));

            con.Open();

            cmd.ExecuteNonQuery();

            MessageBox.Show("Student deleted successfully.");

            LoadStudents();

            ClearFields();
        }

        // Clear fields
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        void ClearFields()
        {
            txtStudentID.Clear();
            txtStudentName.Clear();
            txtLocation.Clear();
            txtAge.Clear();

            cmbGender.SelectedIndex = -1;
        }

        // Form Load
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadStudents();
        }

        // Select DataGridView row
        private void dgvStudents_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row =
                    dgvStudents.Rows[e.RowIndex];

                txtStudentID.Text =
                    row.Cells["StudentID"].Value.ToString();

                txtStudentName.Text =
                    row.Cells["StudentName"].Value.ToString();

                txtLocation.Text =
                    row.Cells["Location"].Value.ToString();

                txtAge.Text =
                    row.Cells["Age"].Value.ToString();

                cmbGender.Text =
                    row.Cells["Gender"].Value.ToString();
            }
        }
    }
}
```

---

# 18. Understanding the Code

The application works through the following sequence:

```text
User
 ↓
Windows Forms Control
 ↓
Button Click Event
 ↓
C# Code
 ↓
SqlConnection
 ↓
SqlCommand
 ↓
SQL Server
 ↓
Database Operation
 ↓
DataGridView
```

---

# 19. Read Operation

The Read operation is implemented through:

```csharp
void LoadStudents()
```

The SQL query is:

```sql
SELECT * FROM Student;
```

The command is executed using:

```csharp
SqlDataReader reader = cmd.ExecuteReader();
```

The retrieved data is placed into a `DataTable`:

```csharp
DataTable dt = new DataTable();

dt.Load(reader);
```

Finally, the DataTable is displayed in the DataGridView:

```csharp
dgvStudents.DataSource = dt;
```

---

# 20. Create Operation

The Add button executes:

```sql
INSERT INTO Student
(StudentName, Location, Age, Gender)
VALUES
(@StudentName, @Location, @Age, @Gender);
```

The values are obtained from the controls:

```csharp
txtStudentName.Text
txtLocation.Text
txtAge.Text
cmbGender.Text
```

The SQL command is executed using:

```csharp
cmd.ExecuteNonQuery();
```

---

# 21. Update Operation

The Update button uses:

```sql
UPDATE Student
SET StudentName = @StudentName,
    Location = @Location,
    Age = @Age,
    Gender = @Gender
WHERE StudentID = @StudentID;
```

The `StudentID` identifies which record should be modified.

For example:

```text
StudentID = 2
```

means that the record whose ID is `2` will be updated.

---

# 22. Delete Operation

The Delete button uses:

```sql
DELETE FROM Student
WHERE StudentID = @StudentID;
```

For example:

```text
StudentID = 3
```

deletes the student whose ID is `3`.

---

# 23. Selecting a Record

When a row in the DataGridView is clicked:

```csharp
dgvStudents_CellClick()
```

is executed.

The selected row's values are copied into the controls:

```text
DataGridView
     ↓
Selected Row
     ↓
TextBoxes / ComboBox
```

For example:

```text
DataGridView
------------------------------------------------
| 2 | Priya | Ahmedabad | 21 | Female |
------------------------------------------------
             ↓
Student ID   → 2
Name         → Priya
Location     → Ahmedabad
Age          → 21
Gender       → Female
```

This makes it possible to select a record and then update or delete it.

---

# 24. Connecting Events to Methods

The event handlers must be connected to the corresponding controls.

The required events are:

```text
Add Button
    ↓
btnAdd_Click

Update Button
    ↓
btnUpdate_Click

Delete Button
    ↓
btnDelete_Click

Clear Button
    ↓
btnClear_Click

Form
    ↓
Form1_Load

DataGridView
    ↓
dgvStudents_CellClick
```

In Visual Studio, these events can be connected through the **Properties → Events** section of the control.

Alternatively, double-clicking a button in the Windows Forms Designer automatically creates its Click event handler.

---

# 25. Run the Application

Save all files and execute:

```bash
dotnet run
```

The Student Management window should open.

---

# 26. Test the Add Operation

Enter:

```text
Student Name : Neha
Location     : Vadodara
Age          : 21
Gender       : Female
```

Click:

```text
Add
```

A new record should be inserted into SQL Server.

The DataGridView should refresh automatically.

---

# 27. Test the Update Operation

Select a student record from the DataGridView.

The student's information will appear in the input fields.

Change any value.

For example:

```text
Location : Ahmedabad
```

Click:

```text
Update
```

The selected student's record should be updated.

---

# 28. Test the Delete Operation

Select a student from the DataGridView.

Click:

```text
Delete
```

The selected record should be removed from the database.

---

# 29. Test the Clear Operation

Enter any values in the controls.

Click:

```text
Clear
```

All input fields should become empty.

---

# 30. Verify Data in SQL Server

Open SSMS and execute:

```sql
USE CollegeDB;

SELECT * FROM Student;
```

The changes made through the Windows Forms application should be visible in the database.

---

# 31. CRUD Mapping

| Operation | SQL Command | Windows Forms Control |
| --------- | ----------- | --------------------- |
| Create    | `INSERT`    | Add                   |
| Read      | `SELECT`    | DataGridView          |
| Update    | `UPDATE`    | Update                |
| Delete    | `DELETE`    | Delete                |

---

# 32. Important ADO.NET Classes

### SqlConnection

Used to establish a connection with SQL Server.

```csharp
SqlConnection con =
    new SqlConnection(connectionString);
```

### SqlCommand

Used to execute SQL commands.

```csharp
SqlCommand cmd =
    new SqlCommand(query, con);
```

### SqlDataReader

Used to read data returned from SQL Server.

```csharp
SqlDataReader reader =
    cmd.ExecuteReader();
```

### DataTable

Stores retrieved records in memory.

```csharp
DataTable dt = new DataTable();
```

---

# 33. Important Methods

| Method              | Purpose                            |
| ------------------- | ---------------------------------- |
| `Open()`            | Opens database connection          |
| `ExecuteNonQuery()` | Executes INSERT, UPDATE and DELETE |
| `ExecuteReader()`   | Executes SELECT and reads records  |
| `DataTable.Load()`  | Loads data from DataReader         |
| `Clear()`           | Clears TextBox content             |

---

# 34. Why `using` Is Used

The application uses:

```csharp
using SqlConnection con =
    new SqlConnection(connectionString);
```

and:

```csharp
using SqlCommand cmd =
    new SqlCommand(query, con);
```

`using` automatically disposes the database objects after they are no longer required.

This helps manage database resources properly.

---

# 35. Parameterized SQL Queries

The application does not directly concatenate user input into SQL.

Instead, it uses parameters:

```csharp
cmd.Parameters.AddWithValue(
    "@StudentName",
    txtStudentName.Text);
```

The SQL query contains:

```sql
@StudentName
```

Parameterized queries are preferred because they separate SQL commands from user-provided values and help prevent SQL injection.

---

# 36. Final Project Structure

After completing the practical, the important project structure is:

```text
StudentWinForms/
│
├── bin/
│
├── obj/
│
├── Form1.cs
├── Form1.Designer.cs
├── Form1.resx
│
├── Program.cs
│
├── StudentWinForms.csproj
│
└── StudentWinForms.sln
```

The main files used during development are:

```text
Form1.cs
    ↓
Application logic

Form1.Designer.cs
    ↓
Windows Forms UI code

Program.cs
    ↓
Application startup

StudentWinForms.csproj
    ↓
Project configuration and NuGet packages
```

---

# 37. Complete Practical Workflow

The complete procedure can be remembered as:

```text
1. Create Database
        ↓
2. Create Table
        ↓
3. Create WinForms Project
        ↓
4. Install Microsoft.Data.SqlClient
        ↓
5. Design Form
        ↓
6. Set Control Names
        ↓
7. Create Connection String
        ↓
8. Write LoadStudents()
        ↓
9. Write Add Operation
        ↓
10. Write Update Operation
        ↓
11. Write Delete Operation
        ↓
12. Write Clear Operation
        ↓
13. Connect Events
        ↓
14. Run Application
        ↓
15. Test CRUD Operations
        ↓
16. Verify Data in SQL Server
```

---

# 38. Common Errors

## Error 1: `Microsoft.Data.SqlClient` Not Found

Install the package:

```bash
dotnet add package Microsoft.Data.SqlClient
```

Then rebuild:

```bash
dotnet build
```

---

## Error 2: SQL Server Connection Failed

Check:

```text
Server name
Database name
SQL Server service
Authentication method
```

For example:

```csharp
Server=.\SQLEXPRESS;
Database=CollegeDB;
```

must match the SQL Server installation.

---

## Error 3: Table Not Found

Verify that the database and table exist:

```sql
USE CollegeDB;

SELECT * FROM Student;
```

---

## Error 4: Invalid Age

The code uses:

```csharp
int.Parse(txtAge.Text)
```

Therefore, Age must contain a valid integer.

Example:

```text
21
```

is valid.

```text
twenty-one
```

is invalid.

---

## Error 5: Event Handler Not Executing

Verify that the button's Click event is connected to the correct method:

```text
btnAdd_Click
btnUpdate_Click
btnDelete_Click
btnClear_Click
```

---

# 39. Expected Result

A Windows Forms-based **Student Management System** is successfully developed using **C# and ADO.NET**.

The application provides a graphical interface for:

- Adding student records
- Displaying student records
- Updating student records
- Deleting student records
- Clearing input fields

The application communicates with SQL Server through ADO.NET.

---

# 40. Viva Questions

1. What is Windows Forms?
2. What is ADO.NET?
3. What is the purpose of `SqlConnection`?
4. What is the purpose of `SqlCommand`?
5. What is `SqlDataReader`?
6. What is the use of `DataGridView`?
7. Which SQL command is used for inserting data?
8. Which method executes INSERT, UPDATE and DELETE?
9. Which method is used to read records?
10. Why are parameterized queries used?
11. What is the purpose of `Form1.cs`?
12. What is the purpose of `Form1.Designer.cs`?
13. What is the purpose of `Program.cs`?
14. Why is `StudentID` used in Update and Delete?
15. What is the difference between a console application and a Windows Forms application?
