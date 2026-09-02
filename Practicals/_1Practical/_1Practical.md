# Practical 1: CRUD Operations Using C# and ADO.NET

## Aim

To develop a console-based C# application using **ADO.NET** to perform **Create, Read, Update, and Delete (CRUD)** operations on a SQL Server database.

---

## 1. Objectives

After completing this practical, the following concepts are covered:

- Creating a C# console application.
- Connecting a C# application to SQL Server using ADO.NET.
- Using `SqlConnection` to establish a database connection.
- Using `SqlCommand` to execute SQL commands.
- Using `SqlDataReader` to read records.
- Performing `INSERT`, `SELECT`, `UPDATE`, and `DELETE` operations.
- Using parameterized SQL queries.
- Creating a simple menu-driven CRUD application.

---

# 2. Requirements

### Software Requirements

- .NET SDK
- C#
- SQL Server
- SQL Server Management Studio (SSMS)
- Visual Studio or Visual Studio Code

### Technologies Used

```text
C#
.NET
ADO.NET
SQL Server
```

---

# 3. Introduction to ADO.NET

**ADO.NET** is a data access technology in the .NET platform that is used to connect applications with databases and perform database operations.

In this practical, the C# application communicates with SQL Server through ADO.NET.

```text
C# Console Application
          ↓
        ADO.NET
          ↓
       SQL Server
          ↓
        Database
```

ADO.NET provides classes that allow an application to:

- Establish a database connection.
- Execute SQL commands.
- Retrieve data.
- Insert, update, and delete data.

---

# 4. CRUD Operations

CRUD represents the four basic operations performed on data.

| Operation | Meaning | SQL Command |
| --------- | ------- | ----------- |
| **C**     | Create  | `INSERT`    |
| **R**     | Read    | `SELECT`    |
| **U**     | Update  | `UPDATE`    |
| **D**     | Delete  | `DELETE`    |

For a student management application:

| CRUD   | Operation               |
| ------ | ----------------------- |
| Create | Add a new student       |
| Read   | Display student records |
| Update | Modify student details  |
| Delete | Remove a student        |

---

# 5. ADO.NET Classes Used

The following ADO.NET classes are used in this practical.

| Class           | Purpose                                  |
| --------------- | ---------------------------------------- |
| `SqlConnection` | Establishes a connection with SQL Server |
| `SqlCommand`    | Executes SQL commands                    |
| `SqlDataReader` | Reads records returned by a query        |

The basic relationship is:

```text
SqlConnection
      ↓
Connects application to database
      ↓
SqlCommand
      ↓
Executes SQL command
      ↓
SQL Server
```

For retrieving records:

```text
SELECT
  ↓
SqlCommand
  ↓
ExecuteReader()
  ↓
SqlDataReader
  ↓
Display records
```

---

# 6. Creating the C# Console Application

Open a terminal or command prompt.

### Step 1: Create a project folder

```bash
mkdir StudentCRUD
```

### Step 2: Move into the folder

```bash
cd StudentCRUD
```

### Step 3: Create a console application

```bash
dotnet new console
```

The project contains the main C# file:

```text
Program.cs
```

### Step 4: Open the project

If Visual Studio Code is being used:

```bash
code .
```

---

# 7. Installing the SQL Server ADO.NET Provider

Install the SQL Server provider using:

```bash
dotnet add package Microsoft.Data.SqlClient
```

After installation, the following namespace is used:

```csharp
using Microsoft.Data.SqlClient;
```

---

# 8. Creating the Database

Open SQL Server Management Studio and connect to SQL Server.

Create a database:

```sql
CREATE DATABASE CollegeDB;
```

Select the database:

```sql
USE CollegeDB;
```

---

# 9. Creating the Student Table

Create the `Student` table:

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

### Table Structure

| Column        | Data Type      | Description       |
| ------------- | -------------- | ----------------- |
| `StudentID`   | `INT`          | Unique student ID |
| `StudentName` | `VARCHAR(100)` | Student name      |
| `Location`    | `VARCHAR(100)` | Student location  |
| `Age`         | `INT`          | Student age       |
| `Gender`      | `VARCHAR(20)`  | Student gender    |

### Primary Key

```sql
StudentID INT PRIMARY KEY
```

`StudentID` uniquely identifies each student.

### Identity

```sql
IDENTITY(1,1)
```

automatically generates the Student ID.

For example:

```text
First student  → 1
Second student → 2
Third student  → 3
```

Therefore, Student ID does not need to be entered manually when adding a student.

---

# 10. Database Connection

A C# application needs a **connection string** to connect to SQL Server.

Example:

```csharp
string connectionString =
    @"Server=.\SQLEXPRESS;
      Database=CollegeDB;
      Trusted_Connection=True;
      TrustServerCertificate=True;";
```

The SQL Server name depends on the SQL Server installation.

For example, the server may be:

```text
.\SQLEXPRESS
```

or:

```text
localhost
```

or:

```text
(localdb)\MSSQLLocalDB
```

The appropriate server name should be used according to the SQL Server environment.

---

# 11. Connection String Components

The connection string contains information required to connect to the database.

```text
Server
   ↓
SQL Server instance

Database
   ↓
Database to use

Trusted_Connection
   ↓
Uses Windows authentication
```

Example:

```csharp
@"Server=.\SQLEXPRESS;
  Database=CollegeDB;
  Trusted_Connection=True;
  TrustServerCertificate=True;"
```

---

# 12. `SqlConnection`

`SqlConnection` represents a connection between the C# application and SQL Server.

```csharp
SqlConnection connection =
    new SqlConnection(connectionString);
```

The connection is opened using:

```csharp
connection.Open();
```

A database operation can then be performed.

The connection is automatically disposed when the `using` block ends.

Example:

```csharp
using SqlConnection connection =
    new SqlConnection(connectionString);

connection.Open();

// Database operation
```

---

# 13. Testing the Database Connection

Before implementing CRUD operations, the database connection can be tested.

```csharp
using Microsoft.Data.SqlClient;

class Program
{
    static string connectionString =
        @"Server=.\SQLEXPRESS;
          Database=CollegeDB;
          Trusted_Connection=True;
          TrustServerCertificate=True;";

    static void Main()
    {
        using SqlConnection connection =
            new SqlConnection(connectionString);

        try
        {
            connection.Open();

            Console.WriteLine(
                "Database connected successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                "Connection failed.");

            Console.WriteLine(ex.Message);
        }
    }
}
```

Run the application using:

```bash
dotnet run
```

Expected output:

```text
Database connected successfully.
```

---

# 14. `SqlCommand`

`SqlCommand` is used to execute an SQL statement against the database.

Example:

```csharp
string query = "SELECT * FROM Student";

using SqlCommand command =
    new SqlCommand(query, connection);
```

The relationship is:

```text
SQL Query
    ↓
SqlCommand
    ↓
SqlConnection
    ↓
SQL Server
```

---

# 15. CREATE Operation — INSERT

The **Create** operation adds a new record to the database.

### SQL Query

```sql
INSERT INTO Student
(StudentName, Location, Age, Gender)
VALUES
(@StudentName, @Location, @Age, @Gender);
```

The values are represented using parameters.

### C# Code

```csharp
static void AddStudent()
{
    Console.Write("Enter Student Name: ");
    string name = Console.ReadLine();

    Console.Write("Enter Location: ");
    string location = Console.ReadLine();

    Console.Write("Enter Age: ");
    int age = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter Gender: ");
    string gender = Console.ReadLine();

    string query = @"INSERT INTO Student
                     (StudentName, Location, Age, Gender)
                     VALUES
                     (@StudentName, @Location, @Age, @Gender)";

    using SqlConnection connection =
        new SqlConnection(connectionString);

    using SqlCommand command =
        new SqlCommand(query, connection);

    command.Parameters.AddWithValue(
        "@StudentName", name);

    command.Parameters.AddWithValue(
        "@Location", location);

    command.Parameters.AddWithValue(
        "@Age", age);

    command.Parameters.AddWithValue(
        "@Gender", gender);

    connection.Open();

    command.ExecuteNonQuery();

    Console.WriteLine(
        "Student added successfully.");
}
```

---

# 16. `ExecuteNonQuery()`

`ExecuteNonQuery()` executes an SQL command that does not return a result set.

It is commonly used for:

```text
INSERT
UPDATE
DELETE
```

Example:

```csharp
command.ExecuteNonQuery();
```

For example:

```text
INSERT
   ↓
ExecuteNonQuery()
   ↓
Record added
```

---

# 17. READ Operation — SELECT

The **Read** operation retrieves records from the database.

### SQL Query

```sql
SELECT * FROM Student;
```

### C# Code

```csharp
static void ViewStudents()
{
    string query = "SELECT * FROM Student";

    using SqlConnection connection =
        new SqlConnection(connectionString);

    using SqlCommand command =
        new SqlCommand(query, connection);

    connection.Open();

    using SqlDataReader reader =
        command.ExecuteReader();

    Console.WriteLine();
    Console.WriteLine(
        "ID\tName\tLocation\tAge\tGender");

    Console.WriteLine(
        "------------------------------------------------");

    while (reader.Read())
    {
        Console.WriteLine(
            $"{reader["StudentID"]}\t" +
            $"{reader["StudentName"]}\t" +
            $"{reader["Location"]}\t" +
            $"{reader["Age"]}\t" +
            $"{reader["Gender"]}");
    }
}
```

---

# 18. `SqlDataReader`

`SqlDataReader` is used to read records returned from the database.

It works with:

```csharp
command.ExecuteReader();
```

Example:

```csharp
using SqlDataReader reader =
    command.ExecuteReader();
```

Records can then be read using:

```csharp
while (reader.Read())
{
    // Read current record
}
```

The flow is:

```text
SELECT
  ↓
SqlCommand
  ↓
ExecuteReader()
  ↓
SqlDataReader
  ↓
Read records
```

---

# 19. Accessing Column Values

A column value can be accessed using its column name.

Example:

```csharp
reader["StudentName"]
```

Other examples:

```csharp
reader["StudentID"]
reader["Location"]
reader["Age"]
reader["Gender"]
```

Example:

```csharp
Console.WriteLine(
    reader["StudentName"]);
```

---

# 20. UPDATE Operation

The **Update** operation modifies an existing record.

### SQL Query

```sql
UPDATE Student
SET StudentName = @StudentName,
    Location = @Location,
    Age = @Age,
    Gender = @Gender
WHERE StudentID = @StudentID;
```

The `WHERE` condition identifies the student whose details need to be modified.

### C# Code

```csharp
static void UpdateStudent()
{
    Console.Write("Enter Student ID: ");
    int id = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter New Name: ");
    string name = Console.ReadLine();

    Console.Write("Enter New Location: ");
    string location = Console.ReadLine();

    Console.Write("Enter New Age: ");
    int age = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter New Gender: ");
    string gender = Console.ReadLine();

    string query = @"UPDATE Student
                     SET StudentName = @StudentName,
                         Location = @Location,
                         Age = @Age,
                         Gender = @Gender
                     WHERE StudentID = @StudentID";

    using SqlConnection connection =
        new SqlConnection(connectionString);

    using SqlCommand command =
        new SqlCommand(query, connection);

    command.Parameters.AddWithValue(
        "@StudentID", id);

    command.Parameters.AddWithValue(
        "@StudentName", name);

    command.Parameters.AddWithValue(
        "@Location", location);

    command.Parameters.AddWithValue(
        "@Age", age);

    command.Parameters.AddWithValue(
        "@Gender", gender);

    connection.Open();

    int rowsAffected =
        command.ExecuteNonQuery();

    if (rowsAffected > 0)
        Console.WriteLine(
            "Student updated successfully.");
    else
        Console.WriteLine(
            "Student not found.");
}
```

---

# 21. DELETE Operation

The **Delete** operation removes a record from the database.

### SQL Query

```sql
DELETE FROM Student
WHERE StudentID = @StudentID;
```

### C# Code

```csharp
static void DeleteStudent()
{
    Console.Write("Enter Student ID: ");
    int id = Convert.ToInt32(Console.ReadLine());

    string query =
        "DELETE FROM Student " +
        "WHERE StudentID = @StudentID";

    using SqlConnection connection =
        new SqlConnection(connectionString);

    using SqlCommand command =
        new SqlCommand(query, connection);

    command.Parameters.AddWithValue(
        "@StudentID", id);

    connection.Open();

    int rowsAffected =
        command.ExecuteNonQuery();

    if (rowsAffected > 0)
        Console.WriteLine(
            "Student deleted successfully.");
    else
        Console.WriteLine(
            "Student not found.");
}
```

---

# 22. Importance of the `WHERE` Clause

The `WHERE` clause identifies the record that should be updated or deleted.

For example:

```sql
UPDATE Student
SET Age = 21
WHERE StudentID = 5;
```

Only student `5` is updated.

Similarly:

```sql
DELETE FROM Student
WHERE StudentID = 5;
```

Only student `5` is deleted.

Without an appropriate `WHERE` condition, an `UPDATE` or `DELETE` statement can affect multiple records.

---

# 23. Parameterized Queries

A **parameterized query** uses parameters instead of directly inserting user input into an SQL statement.

Example:

```sql
DELETE FROM Student
WHERE StudentID = @StudentID;
```

The value is supplied separately:

```csharp
command.Parameters.AddWithValue(
    "@StudentID", id);
```

### Avoid

```csharp
string query =
    "DELETE FROM Student WHERE StudentID = "
    + id;
```

### Use

```csharp
string query =
    "DELETE FROM Student WHERE StudentID = @StudentID";

command.Parameters.AddWithValue(
    "@StudentID", id);
```

Parameterized queries provide safer handling of user input and help protect against **SQL injection**.

---

# 24. Complete Menu-Driven Application

The CRUD operations can be combined into a single application.

```csharp
using Microsoft.Data.SqlClient;

class Program
{
    static string connectionString =
        @"Server=.\SQLEXPRESS;
          Database=CollegeDB;
          Trusted_Connection=True;
          TrustServerCertificate=True;";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("================================");
            Console.WriteLine("       STUDENT MANAGEMENT");
            Console.WriteLine("================================");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View Students");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddStudent();
                    break;

                case "2":
                    ViewStudents();
                    break;

                case "3":
                    UpdateStudent();
                    break;

                case "4":
                    DeleteStudent();
                    break;

                case "5":
                    Console.WriteLine(
                        "Application closed.");
                    return;

                default:
                    Console.WriteLine(
                        "Invalid choice.");
                    break;
            }
        }
    }

    static void AddStudent()
    {
        Console.Write("Enter Student Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Location: ");
        string location = Console.ReadLine();

        Console.Write("Enter Age: ");
        int age = Convert.ToInt32(
            Console.ReadLine());

        Console.Write("Enter Gender: ");
        string gender = Console.ReadLine();

        string query = @"INSERT INTO Student
                         (StudentName, Location, Age, Gender)
                         VALUES
                         (@StudentName, @Location, @Age, @Gender)";

        using SqlConnection connection =
            new SqlConnection(connectionString);

        using SqlCommand command =
            new SqlCommand(query, connection);

        command.Parameters.AddWithValue(
            "@StudentName", name);

        command.Parameters.AddWithValue(
            "@Location", location);

        command.Parameters.AddWithValue(
            "@Age", age);

        command.Parameters.AddWithValue(
            "@Gender", gender);

        connection.Open();

        command.ExecuteNonQuery();

        Console.WriteLine(
            "Student added successfully.");
    }

    static void ViewStudents()
    {
        string query = "SELECT * FROM Student";

        using SqlConnection connection =
            new SqlConnection(connectionString);

        using SqlCommand command =
            new SqlCommand(query, connection);

        connection.Open();

        using SqlDataReader reader =
            command.ExecuteReader();

        Console.WriteLine();
        Console.WriteLine(
            "ID\tName\tLocation\tAge\tGender");

        Console.WriteLine(
            "------------------------------------------------");

        while (reader.Read())
        {
            Console.WriteLine(
                $"{reader["StudentID"]}\t" +
                $"{reader["StudentName"]}\t" +
                $"{reader["Location"]}\t" +
                $"{reader["Age"]}\t" +
                $"{reader["Gender"]}");
        }
    }

    static void UpdateStudent()
    {
        Console.Write("Enter Student ID: ");
        int id = Convert.ToInt32(
            Console.ReadLine());

        Console.Write("Enter New Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter New Location: ");
        string location = Console.ReadLine();

        Console.Write("Enter New Age: ");
        int age = Convert.ToInt32(
            Console.ReadLine());

        Console.Write("Enter New Gender: ");
        string gender = Console.ReadLine();

        string query = @"UPDATE Student
                         SET StudentName = @StudentName,
                             Location = @Location,
                             Age = @Age,
                             Gender = @Gender
                         WHERE StudentID = @StudentID";

        using SqlConnection connection =
            new SqlConnection(connectionString);

        using SqlCommand command =
            new SqlCommand(query, connection);

        command.Parameters.AddWithValue(
            "@StudentID", id);

        command.Parameters.AddWithValue(
            "@StudentName", name);

        command.Parameters.AddWithValue(
            "@Location", location);

        command.Parameters.AddWithValue(
            "@Age", age);

        command.Parameters.AddWithValue(
            "@Gender", gender);

        connection.Open();

        int rowsAffected =
            command.ExecuteNonQuery();

        if (rowsAffected > 0)
            Console.WriteLine(
                "Student updated successfully.");
        else
            Console.WriteLine(
                "Student not found.");
    }

    static void DeleteStudent()
    {
        Console.Write("Enter Student ID: ");
        int id = Convert.ToInt32(
            Console.ReadLine());

        string query =
            "DELETE FROM Student " +
            "WHERE StudentID = @StudentID";

        using SqlConnection connection =
            new SqlConnection(connectionString);

        using SqlCommand command =
            new SqlCommand(query, connection);

        command.Parameters.AddWithValue(
            "@StudentID", id);

        connection.Open();

        int rowsAffected =
            command.ExecuteNonQuery();

        if (rowsAffected > 0)
            Console.WriteLine(
                "Student deleted successfully.");
        else
            Console.WriteLine(
                "Student not found.");
    }
}
```

---

# 25. Running the Application

Open the terminal inside the project folder and execute:

```bash
dotnet run
```

The application displays:

```text
================================
       STUDENT MANAGEMENT
================================
1. Add Student
2. View Students
3. Update Student
4. Delete Student
5. Exit

Enter your choice:
```

---

# 26. Testing the CRUD Operations

## Create

Select:

```text
1
```

Enter:

```text
Student Name: Rahul
Location: Ahmedabad
Age: 20
Gender: Male
```

Output:

```text
Student added successfully.
```

---

## Read

Select:

```text
2
```

Output:

```text
ID      Name    Location    Age     Gender
------------------------------------------------
1       Rahul   Ahmedabad   20      Male
```

---

## Update

Select:

```text
3
```

Enter:

```text
Student ID: 1
New Name: Rahul Patel
New Location: Surat
New Age: 21
New Gender: Male
```

Output:

```text
Student updated successfully.
```

---

## Delete

Select:

```text
4
```

Enter:

```text
Student ID: 1
```

Output:

```text
Student deleted successfully.
```

---

# 27. Complete Application Flow

```text
                C# Console Application
                         │
                         ↓
                    ADO.NET
                         │
                  SqlConnection
                         │
                         ↓
                    SqlCommand
                         │
                         ↓
                     SQL Server
                         │
                         ↓
                    CollegeDB
                         │
                         ↓
                      Student
```

### Insert, Update and Delete

```text
INSERT / UPDATE / DELETE
           ↓
      SqlCommand
           ↓
  ExecuteNonQuery()
           ↓
       Database
```

### Read

```text
SELECT
  ↓
SqlCommand
  ↓
ExecuteReader()
  ↓
SqlDataReader
  ↓
Display Records
```

---

# 28. Important Methods

| Method              | Purpose                                    |
| ------------------- | ------------------------------------------ |
| `Open()`            | Opens the database connection              |
| `ExecuteNonQuery()` | Executes `INSERT`, `UPDATE`, or `DELETE`   |
| `ExecuteReader()`   | Executes a query and returns records       |
| `Read()`            | Reads the next record from `SqlDataReader` |

---

# 29. Summary

The complete CRUD application follows this process:

```text
Create Project
      ↓
Install Microsoft.Data.SqlClient
      ↓
Create Database
      ↓
Create Student Table
      ↓
Create Connection String
      ↓
Create SqlConnection
      ↓
Create SqlCommand
      ↓
Execute SQL
      ↓
Perform CRUD Operations
```

CRUD operations are:

```text
CREATE → INSERT
READ   → SELECT
UPDATE → UPDATE
DELETE → DELETE
```

---

# 30. Practical Exercise

Develop a **Student Management System** using C#, .NET, ADO.NET, and SQL Server.

The application should:

1. Add a student.
2. Display all students.
3. Update student details using Student ID.
4. Delete a student using Student ID.
5. Provide a menu-driven console interface.
6. Use parameterized SQL queries for database operations.

Student table:

```text
StudentID
StudentName
Location
Age
Gender
```

---

# 31. Viva Questions

1. What is ADO.NET?
2. What is CRUD?
3. What does CRUD stand for?
4. Which SQL command is used for Create?
5. Which SQL command is used for Read?
6. Which SQL command is used for Update?
7. Which SQL command is used for Delete?
8. What is the purpose of `SqlConnection`?
9. What is the purpose of `SqlCommand`?
10. What is `SqlDataReader`?
11. What is the purpose of `connection.Open()`?
12. What is `ExecuteNonQuery()`?
13. When is `ExecuteReader()` used?
14. What is a parameterized query?
15. Why is `WHERE` important in `UPDATE` and `DELETE`?
16. What is a primary key?
17. What is the purpose of `IDENTITY(1,1)`?
18. Which NuGet package is used to connect a modern .NET application to SQL Server?
19. What is the purpose of a connection string?
20. What is SQL injection?

---

# 32. Result

> The C# console-based application was successfully developed using ADO.NET to perform Create, Read, Update, and Delete (CRUD) operations on student records stored in SQL Server.
