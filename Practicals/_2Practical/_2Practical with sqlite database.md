# Practical 2 — Application Development with C# and ADO.NET using SQLite

## Aim

To develop a menu-driven database application using **C#, ADO.NET, and SQLite** for managing student records.

---

# 1. Objectives

After completing this practical, students should be able to:

- Create a C# application that communicates with a SQLite database.
- Use ADO.NET for database operations.
- Organize database operations into separate methods.
- Accept input from the user.
- Search for a specific record.
- Display database records.
- Update existing records.
- Delete records.
- Handle basic database-related errors.
- Use parameterized SQL queries.

---

# 2. Application to Be Developed

We will develop a **Student Management Application**.

The application menu will be:

```text
================================
       STUDENT MANAGEMENT
================================

1. Add Student
2. View Students
3. Search Student
4. Update Student
5. Delete Student
6. Exit

Enter your choice:
```

The application performs the following database operations:

```text
CREATE  → Add Student
READ    → View/Search Student
UPDATE  → Update Student
DELETE  → Delete Student
```

Practical 2 extends the basic CRUD operations by adding a **Search Student** feature and organizing the application into separate methods.

---

# 3. Technologies Used

```text
C#
.NET
ADO.NET
SQLite
Microsoft.Data.Sqlite
```

ADO.NET is used by the C# application to communicate with the SQLite database.

The SQLite provider used in this practical is:

```text
Microsoft.Data.Sqlite
```

---

# 4. Application Architecture

The application follows the structure:

```text
┌──────────────────────────┐
│     C# Console App       │
├──────────────────────────┤
│ Menu                     │
│ Input                    │
│ Application Methods      │
├──────────────────────────┤
│        ADO.NET           │
│  SqliteConnection        │
│  SqliteCommand           │
│  SqliteDataReader        │
├──────────────────────────┤
│          SQLite          │
│      CollegeDB.db        │
│        Student           │
└──────────────────────────┘
```

### Main components

| Component          | Purpose                            |
| ------------------ | ---------------------------------- |
| `SqliteConnection` | Establishes connection with SQLite |
| `SqliteCommand`    | Executes SQL commands              |
| `SqliteDataReader` | Reads records returned by `SELECT` |
| SQLite database    | Stores student information         |
| C# methods         | Organize application operations    |

---

# 5. Database

SQLite stores the database in a file.

For this practical, the database file will be:

```text
CollegeDB.db
```

The database contains a table named:

```text
Student
```

## Student Table

The table contains:

```text
StudentID
StudentName
Location
Age
Gender
```

## Create Student Table

Use the following SQLite query:

```sql
CREATE TABLE IF NOT EXISTS Student
(
    StudentID INTEGER PRIMARY KEY AUTOINCREMENT,
    StudentName TEXT NOT NULL,
    Location TEXT,
    Age INTEGER,
    Gender TEXT
);
```

### Explanation

#### StudentID

```sql
StudentID INTEGER PRIMARY KEY AUTOINCREMENT
```

`StudentID` is the primary key.

SQLite automatically generates a new ID for every student.

For example:

```text
1
2
3
4
5
```

The important SQLite syntax is:

```sql
INTEGER PRIMARY KEY AUTOINCREMENT
```

Do not use SQL Server syntax such as:

```sql
INT IDENTITY(1,1)
```

because `IDENTITY` is not supported by SQLite.

---

# 6. SQLite Data Types

The table uses SQLite-compatible data types.

| Field       | SQLite Data Type | Description                   |
| ----------- | ---------------- | ----------------------------- |
| StudentID   | INTEGER          | Student identification number |
| StudentName | TEXT             | Student name                  |
| Location    | TEXT             | Student location              |
| Age         | INTEGER          | Student age                   |
| Gender      | TEXT             | Student gender                |

SQLite commonly uses:

```text
INTEGER
REAL
TEXT
BLOB
NULL
```

---

# 7. Create the Project

Open Terminal.

Create a project directory:

```bash
mkdir StudentManagement
```

Move into the directory:

```bash
cd StudentManagement
```

Create a .NET console application:

```bash
dotnet new console
```

---

# 8. Install SQLite Provider

Install the SQLite provider:

```bash
dotnet add package Microsoft.Data.Sqlite
```

Verify the project:

```bash
dotnet restore
```

Run the application:

```bash
dotnet run
```

---

# 9. Add Required Namespace

At the top of `Program.cs`, add:

```csharp
using Microsoft.Data.Sqlite;
```

---

# 10. Connection String

SQLite does not require a server name, username, password, or SQL Server instance.

Use:

```csharp
static string connectionString = "Data Source=CollegeDB.db";
```

The complete connection string is:

```text
Data Source=CollegeDB.db
```

This means the application will use the SQLite database file:

```text
CollegeDB.db
```

If the database file does not exist, SQLite can create it when the connection is opened.

---

# 11. Initialize the Database

Before displaying the menu, the application should create the `Student` table if it does not already exist.

Use:

```csharp
static void InitializeDatabase()
{
    using var connection = new SqliteConnection(connectionString);

    connection.Open();

    string query = @"
        CREATE TABLE IF NOT EXISTS Student
        (
            StudentID INTEGER PRIMARY KEY AUTOINCREMENT,
            StudentName TEXT NOT NULL,
            Location TEXT,
            Age INTEGER,
            Gender TEXT
        );";

    using var command = new SqliteCommand(query, connection);

    command.ExecuteNonQuery();
}
```

### Explanation

```csharp
SqliteConnection
```

creates a connection to SQLite.

```csharp
connection.Open();
```

opens the database connection.

```sql
CREATE TABLE IF NOT EXISTS
```

creates the table only when it does not already exist.

```csharp
command.ExecuteNonQuery();
```

executes the table creation command.

---

# 12. Application Structure

Instead of writing everything inside `Main()`, create separate methods.

```text
Main()
 │
 ├── InitializeDatabase()
 │
 ├── AddStudent()
 │
 ├── ViewStudents()
 │
 ├── SearchStudent()
 │
 ├── UpdateStudent()
 │
 └── DeleteStudent()
```

This makes the application easier to understand, test, maintain, and modify.

---

# 13. Main Menu

The `Main()` method displays the menu and calls the appropriate method.

```csharp
static void Main()
{
    InitializeDatabase();

    while (true)
    {
        Console.WriteLine();
        Console.WriteLine("================================");
        Console.WriteLine("       STUDENT MANAGEMENT");
        Console.WriteLine("================================");
        Console.WriteLine("1. Add Student");
        Console.WriteLine("2. View Students");
        Console.WriteLine("3. Search Student");
        Console.WriteLine("4. Update Student");
        Console.WriteLine("5. Delete Student");
        Console.WriteLine("6. Exit");

        Console.Write("Enter your choice: ");

        string choice = Console.ReadLine() ?? "";

        switch (choice)
        {
            case "1":
                AddStudent();
                break;

            case "2":
                ViewStudents();
                break;

            case "3":
                SearchStudent();
                break;

            case "4":
                UpdateStudent();
                break;

            case "5":
                DeleteStudent();
                break;

            case "6":
                Console.WriteLine("Application closed.");
                return;

            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }
}
```

The following statement prevents nullable warnings:

```csharp
string choice = Console.ReadLine() ?? "";
```

---

# 14. CREATE — Add Student

The Add Student operation inserts a new student into the database.

## SQL Query

```sql
INSERT INTO Student
(StudentName, Location, Age, Gender)
VALUES
(@StudentName, @Location, @Age, @Gender);
```

The `StudentID` is not included because SQLite automatically generates it.

## C# Method

```csharp
static void AddStudent()
{
    Console.Write("Enter Student Name: ");
    string name = Console.ReadLine() ?? "";

    Console.Write("Enter Location: ");
    string location = Console.ReadLine() ?? "";

    Console.Write("Enter Age: ");
    if (!int.TryParse(Console.ReadLine(), out int age))
    {
        Console.WriteLine("Invalid age.");
        return;
    }

    Console.Write("Enter Gender: ");
    string gender = Console.ReadLine() ?? "";

    string query = @"
        INSERT INTO Student
        (StudentName, Location, Age, Gender)
        VALUES
        (@StudentName, @Location, @Age, @Gender);";

    using var connection = new SqliteConnection(connectionString);
    using var command = new SqliteCommand(query, connection);

    command.Parameters.AddWithValue("@StudentName", name);
    command.Parameters.AddWithValue("@Location", location);
    command.Parameters.AddWithValue("@Age", age);
    command.Parameters.AddWithValue("@Gender", gender);

    connection.Open();

    command.ExecuteNonQuery();

    Console.WriteLine("Student added successfully.");
}
```

---

# 15. Understanding Add Student

The process is:

```text
User enters student details
          ↓
Create INSERT query
          ↓
Add parameters
          ↓
Open SQLite connection
          ↓
ExecuteNonQuery()
          ↓
Student inserted
```

The ID is automatically generated.

For example:

```text
Student 1 → StudentID = 1
Student 2 → StudentID = 2
Student 3 → StudentID = 3
```

---

# 16. READ — View Students

The View Students operation displays all student records.

## SQL Query

```sql
SELECT * FROM Student;
```

## C# Method

```csharp
static void ViewStudents()
{
    string query = "SELECT * FROM Student;";

    using var connection = new SqliteConnection(connectionString);
    using var command = new SqliteCommand(query, connection);

    connection.Open();

    using var reader = command.ExecuteReader();

    Console.WriteLine();
    Console.WriteLine("ID\tName\tLocation\tAge\tGender");
    Console.WriteLine("------------------------------------------------");

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

# 17. Understanding View Students

The process is:

```text
Execute SELECT query
        ↓
Open database connection
        ↓
ExecuteReader()
        ↓
Read records
        ↓
Display records
```

The important statement is:

```csharp
while (reader.Read())
```

`Read()` moves the reader to the next record.

---

# 18. SEARCH — Find a Student

Search allows the user to find a student using the `StudentID`.

## SQL Query

```sql
SELECT *
FROM Student
WHERE StudentID = @StudentID;
```

## C# Method

```csharp
static void SearchStudent()
{
    Console.Write("Enter Student ID: ");

    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("Invalid Student ID.");
        return;
    }

    string query = @"
        SELECT *
        FROM Student
        WHERE StudentID = @StudentID;";

    using var connection = new SqliteConnection(connectionString);
    using var command = new SqliteCommand(query, connection);

    command.Parameters.AddWithValue("@StudentID", id);

    connection.Open();

    using var reader = command.ExecuteReader();

    if (reader.Read())
    {
        Console.WriteLine();
        Console.WriteLine("Student Found");
        Console.WriteLine("-------------------------");

        Console.WriteLine(
            "Student ID: " + reader["StudentID"]);

        Console.WriteLine(
            "Student Name: " + reader["StudentName"]);

        Console.WriteLine(
            "Location: " + reader["Location"]);

        Console.WriteLine(
            "Age: " + reader["Age"]);

        Console.WriteLine(
            "Gender: " + reader["Gender"]);
    }
    else
    {
        Console.WriteLine("Student not found.");
    }
}
```

---

# 19. Understanding the Search Operation

The process is:

```text
User enters Student ID
          ↓
Create SELECT query
          ↓
Add StudentID parameter
          ↓
Open connection
          ↓
ExecuteReader()
          ↓
Check Read()
       ↙     ↘
     Yes       No
      ↓         ↓
Student found  Student not found
```

The important statement is:

```csharp
if (reader.Read())
```

If a matching record exists:

```text
true → Student found
```

If no matching record exists:

```text
false → Student not found
```

---

# 20. UPDATE — Modify Student

The Update operation modifies an existing student's information.

The user provides the `StudentID` and the new values.

## SQL Query

```sql
UPDATE Student
SET
    StudentName = @StudentName,
    Location = @Location,
    Age = @Age,
    Gender = @Gender
WHERE StudentID = @StudentID;
```

## C# Method

```csharp
static void UpdateStudent()
{
    Console.Write("Enter Student ID: ");

    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("Invalid Student ID.");
        return;
    }

    Console.Write("Enter New Name: ");
    string name = Console.ReadLine() ?? "";

    Console.Write("Enter New Location: ");
    string location = Console.ReadLine() ?? "";

    Console.Write("Enter New Age: ");

    if (!int.TryParse(Console.ReadLine(), out int age))
    {
        Console.WriteLine("Invalid age.");
        return;
    }

    Console.Write("Enter New Gender: ");
    string gender = Console.ReadLine() ?? "";

    string query = @"
        UPDATE Student
        SET
            StudentName = @StudentName,
            Location = @Location,
            Age = @Age,
            Gender = @Gender
        WHERE StudentID = @StudentID;";

    using var connection = new SqliteConnection(connectionString);
    using var command = new SqliteCommand(query, connection);

    command.Parameters.AddWithValue("@StudentID", id);
    command.Parameters.AddWithValue("@StudentName", name);
    command.Parameters.AddWithValue("@Location", location);
    command.Parameters.AddWithValue("@Age", age);
    command.Parameters.AddWithValue("@Gender", gender);

    connection.Open();

    int rowsAffected = command.ExecuteNonQuery();

    if (rowsAffected > 0)
    {
        Console.WriteLine("Student updated successfully.");
    }
    else
    {
        Console.WriteLine("Student not found.");
    }
}
```

---

# 21. Understanding Update

The process is:

```text
Enter Student ID
        ↓
Enter new student details
        ↓
Create UPDATE query
        ↓
Add parameters
        ↓
Open connection
        ↓
ExecuteNonQuery()
        ↓
Check rows affected
```

If:

```text
rowsAffected > 0
```

the student was updated.

Otherwise:

```text
Student not found.
```

---

# 22. DELETE — Delete Student

The Delete operation removes a student from the database.

## SQL Query

```sql
DELETE FROM Student
WHERE StudentID = @StudentID;
```

## C# Method

```csharp
static void DeleteStudent()
{
    Console.Write("Enter Student ID: ");

    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("Invalid Student ID.");
        return;
    }

    string query = @"
        DELETE FROM Student
        WHERE StudentID = @StudentID;";

    using var connection = new SqliteConnection(connectionString);
    using var command = new SqliteCommand(query, connection);

    command.Parameters.AddWithValue("@StudentID", id);

    connection.Open();

    int rowsAffected = command.ExecuteNonQuery();

    if (rowsAffected > 0)
    {
        Console.WriteLine("Student deleted successfully.");
    }
    else
    {
        Console.WriteLine("Student not found.");
    }
}
```

---

# 23. Understanding Delete

The process is:

```text
Enter Student ID
        ↓
Create DELETE query
        ↓
Add StudentID parameter
        ↓
Open connection
        ↓
ExecuteNonQuery()
        ↓
Check rows affected
        ↓
Delete successful / Student not found
```

---

# 24. Parameterized Queries

All operations that accept user input use parameters.

Example:

```sql
WHERE StudentID = @StudentID
```

and:

```csharp
command.Parameters.AddWithValue("@StudentID", id);
```

Similarly:

```sql
StudentName = @StudentName
```

and:

```csharp
command.Parameters.AddWithValue("@StudentName", name);
```

### Why use parameters?

Parameterized queries:

- Separate SQL code from user input.
- Reduce the risk of SQL injection.
- Make queries safer.
- Make database operations easier to manage.

---

# 25. Complete Program

The following is the complete SQLite version of the Student Management Application.

```csharp
using Microsoft.Data.Sqlite;

class Program
{
    static string connectionString =
        "Data Source=CollegeDB.db";

    static void Main()
    {
        InitializeDatabase();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("================================");
            Console.WriteLine("       STUDENT MANAGEMENT");
            Console.WriteLine("================================");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View Students");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Update Student");
            Console.WriteLine("5. Delete Student");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    AddStudent();
                    break;

                case "2":
                    ViewStudents();
                    break;

                case "3":
                    SearchStudent();
                    break;

                case "4":
                    UpdateStudent();
                    break;

                case "5":
                    DeleteStudent();
                    break;

                case "6":
                    Console.WriteLine("Application closed.");
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static void InitializeDatabase()
    {
        using var connection =
            new SqliteConnection(connectionString);

        connection.Open();

        string query = @"
            CREATE TABLE IF NOT EXISTS Student
            (
                StudentID INTEGER PRIMARY KEY AUTOINCREMENT,
                StudentName TEXT NOT NULL,
                Location TEXT,
                Age INTEGER,
                Gender TEXT
            );";

        using var command =
            new SqliteCommand(query, connection);

        command.ExecuteNonQuery();
    }

    static void AddStudent()
    {
        Console.Write("Enter Student Name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Enter Location: ");
        string location = Console.ReadLine() ?? "";

        Console.Write("Enter Age: ");

        if (!int.TryParse(
                Console.ReadLine(),
                out int age))
        {
            Console.WriteLine("Invalid age.");
            return;
        }

        Console.Write("Enter Gender: ");
        string gender = Console.ReadLine() ?? "";

        string query = @"
            INSERT INTO Student
            (StudentName, Location, Age, Gender)
            VALUES
            (@StudentName, @Location, @Age, @Gender);";

        using var connection =
            new SqliteConnection(connectionString);

        using var command =
            new SqliteCommand(query, connection);

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
        string query =
            "SELECT * FROM Student;";

        using var connection =
            new SqliteConnection(connectionString);

        using var command =
            new SqliteCommand(query, connection);

        connection.Open();

        using var reader =
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

    static void SearchStudent()
    {
        Console.Write("Enter Student ID: ");

        if (!int.TryParse(
                Console.ReadLine(),
                out int id))
        {
            Console.WriteLine(
                "Invalid Student ID.");

            return;
        }

        string query = @"
            SELECT *
            FROM Student
            WHERE StudentID = @StudentID;";

        using var connection =
            new SqliteConnection(connectionString);

        using var command =
            new SqliteCommand(query, connection);

        command.Parameters.AddWithValue(
            "@StudentID", id);

        connection.Open();

        using var reader =
            command.ExecuteReader();

        if (reader.Read())
        {
            Console.WriteLine();
            Console.WriteLine("Student Found");
            Console.WriteLine(
                "-------------------------");

            Console.WriteLine(
                "Student ID: " +
                reader["StudentID"]);

            Console.WriteLine(
                "Student Name: " +
                reader["StudentName"]);

            Console.WriteLine(
                "Location: " +
                reader["Location"]);

            Console.WriteLine(
                "Age: " +
                reader["Age"]);

            Console.WriteLine(
                "Gender: " +
                reader["Gender"]);
        }
        else
        {
            Console.WriteLine(
                "Student not found.");
        }
    }

    static void UpdateStudent()
    {
        Console.Write("Enter Student ID: ");

        if (!int.TryParse(
                Console.ReadLine(),
                out int id))
        {
            Console.WriteLine(
                "Invalid Student ID.");

            return;
        }

        Console.Write("Enter New Name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Enter New Location: ");
        string location =
            Console.ReadLine() ?? "";

        Console.Write("Enter New Age: ");

        if (!int.TryParse(
                Console.ReadLine(),
                out int age))
        {
            Console.WriteLine("Invalid age.");
            return;
        }

        Console.Write("Enter New Gender: ");
        string gender =
            Console.ReadLine() ?? "";

        string query = @"
            UPDATE Student
            SET
                StudentName = @StudentName,
                Location = @Location,
                Age = @Age,
                Gender = @Gender
            WHERE StudentID = @StudentID;";

        using var connection =
            new SqliteConnection(connectionString);

        using var command =
            new SqliteCommand(query, connection);

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
        {
            Console.WriteLine(
                "Student updated successfully.");
        }
        else
        {
            Console.WriteLine(
                "Student not found.");
        }
    }

    static void DeleteStudent()
    {
        Console.Write("Enter Student ID: ");

        if (!int.TryParse(
                Console.ReadLine(),
                out int id))
        {
            Console.WriteLine(
                "Invalid Student ID.");

            return;
        }

        string query = @"
            DELETE FROM Student
            WHERE StudentID = @StudentID;";

        using var connection =
            new SqliteConnection(connectionString);

        using var command =
            new SqliteCommand(query, connection);

        command.Parameters.AddWithValue(
            "@StudentID", id);

        connection.Open();

        int rowsAffected =
            command.ExecuteNonQuery();

        if (rowsAffected > 0)
        {
            Console.WriteLine(
                "Student deleted successfully.");
        }
        else
        {
            Console.WriteLine(
                "Student not found.");
        }
    }
}
```

---

# 26. Running the Application

Open Terminal inside the project directory.

Install the required package:

```bash
dotnet add package Microsoft.Data.Sqlite
```

Restore packages:

```bash
dotnet restore
```

Run the application:

```bash
dotnet run
```

The application will automatically create:

```text
CollegeDB.db
```

and the `Student` table.

---

# 27. Example Execution

## Add Student

```text
================================
       STUDENT MANAGEMENT
================================
1. Add Student
2. View Students
3. Search Student
4. Update Student
5. Delete Student
6. Exit

Enter your choice: 1

Enter Student Name: Rahul
Enter Location: Ahmedabad
Enter Age: 20
Enter Gender: Male

Student added successfully.
```

---

## Add Another Student

```text
Enter your choice: 1

Enter Student Name: Priya
Enter Location: Surat
Enter Age: 21
Enter Gender: Female

Student added successfully.
```

---

# 28. View Students

```text
Enter your choice: 2

ID      Name    Location    Age     Gender
------------------------------------------------
1       Rahul   Ahmedabad   20      Male
2       Priya   Surat       21      Female
```

---

# 29. Search Student

```text
Enter your choice: 3

Enter Student ID: 1

Student Found
-------------------------
Student ID: 1
Student Name: Rahul
Location: Ahmedabad
Age: 20
Gender: Male
```

If the ID does not exist:

```text
Enter your choice: 3

Enter Student ID: 10

Student not found.
```

---

# 30. Update Student

```text
Enter your choice: 4

Enter Student ID: 1
Enter New Name: Rahul Patel
Enter New Location: Vadodara
Enter New Age: 21
Enter New Gender: Male

Student updated successfully.
```

---

# 31. Delete Student

```text
Enter your choice: 5

Enter Student ID: 2

Student deleted successfully.
```

If the student does not exist:

```text
Enter Student ID: 20

Student not found.
```

---

# 32. Application Flow

```text
                    START
                      │
                      ↓
             Initialize Database
                      │
                      ↓
                Display Menu
                      │
        ┌─────────────┼─────────────┐
        ↓             ↓             ↓
      Add           View          Search
        │             │             │
        └─────────────┼─────────────┘
                      ↓
                   Update
                      │
                      ↓
                   Delete
                      │
                      ↓
                 Return Menu
                      │
                      ↓
                    Exit
```

---

# 33. CRUD Operation Summary

| Operation | SQL Command        | C# Method           |
| --------- | ------------------ | ------------------- |
| Create    | `INSERT`           | `ExecuteNonQuery()` |
| Read      | `SELECT`           | `ExecuteReader()`   |
| Update    | `UPDATE`           | `ExecuteNonQuery()` |
| Delete    | `DELETE`           | `ExecuteNonQuery()` |
| Search    | `SELECT ... WHERE` | `ExecuteReader()`   |

---

# 34. Important ADO.NET Classes

## `SqliteConnection`

Used to establish a connection with the SQLite database.

Example:

```csharp
using var connection =
    new SqliteConnection(connectionString);
```

Open the connection:

```csharp
connection.Open();
```

---

## `SqliteCommand`

Used to execute SQL statements.

Example:

```csharp
using var command =
    new SqliteCommand(query, connection);
```

---

## `SqliteDataReader`

Used to read records returned by a `SELECT` query.

Example:

```csharp
using var reader =
    command.ExecuteReader();
```

Read records using:

```csharp
while (reader.Read())
{
    // process record
}
```

---

# 35. ExecuteNonQuery()

`ExecuteNonQuery()` is used for SQL operations that modify database records.

It is commonly used for:

```text
INSERT
UPDATE
DELETE
CREATE TABLE
```

Example:

```csharp
command.ExecuteNonQuery();
```

For `UPDATE` and `DELETE`, it can return the number of affected rows:

```csharp
int rowsAffected =
    command.ExecuteNonQuery();
```

---

# 36. ExecuteReader()

`ExecuteReader()` is used to retrieve records from the database.

It is generally used with:

```sql
SELECT
```

Example:

```csharp
using var reader =
    command.ExecuteReader();
```

Then:

```csharp
while (reader.Read())
{
    Console.WriteLine(
        reader["StudentName"]);
}
```

---

# 37. Using Blocks

The program uses:

```csharp
using var connection =
    new SqliteConnection(connectionString);
```

and:

```csharp
using var command =
    new SqliteCommand(query, connection);
```

The `using` statement ensures that database resources are properly disposed of after use.

This helps avoid unnecessary resource usage and connection-related problems.

---

# 38. Error Handling

The application validates numeric input using:

```csharp
int.TryParse()
```

For example:

```csharp
if (!int.TryParse(
        Console.ReadLine(),
        out int age))
{
    Console.WriteLine("Invalid age.");
    return;
}
```

This prevents the application from terminating when the user enters invalid numeric input.

---

# 39. Difference Between SQL Server and SQLite

The original version of this practical uses SQL Server. The SQLite version uses different provider classes and connection syntax.

| SQL Server                 | SQLite                     |
| -------------------------- | -------------------------- |
| `Microsoft.Data.SqlClient` | `Microsoft.Data.Sqlite`    |
| `SqlConnection`            | `SqliteConnection`         |
| `SqlCommand`               | `SqliteCommand`            |
| `SqlDataReader`            | `SqliteDataReader`         |
| SQL Server database        | `.db` file                 |
| `Server=.\SQLEXPRESS`      | `Data Source=CollegeDB.db` |
| `IDENTITY(1,1)`            | `AUTOINCREMENT`            |
| `VARCHAR`                  | `TEXT`                     |
| `INT`                      | `INTEGER`                  |

### SQL Server

```sql
StudentID INT PRIMARY KEY IDENTITY(1,1)
```

### SQLite

```sql
StudentID INTEGER PRIMARY KEY AUTOINCREMENT
```

---

# 40. Important SQLite Query

The complete table creation query is:

```sql
CREATE TABLE IF NOT EXISTS Student
(
    StudentID INTEGER PRIMARY KEY AUTOINCREMENT,
    StudentName TEXT NOT NULL,
    Location TEXT,
    Age INTEGER,
    Gender TEXT
);
```

This is the query that should be used for this SQLite practical.

---

# 41. Practical Exercise

Develop a **Student Management Application** using:

```text
C#
.NET
ADO.NET
SQLite
Microsoft.Data.Sqlite
```

The application should contain the following menu:

```text
1. Add Student
2. View Students
3. Search Student
4. Update Student
5. Delete Student
6. Exit
```

The application should use the `Student` table containing:

```text
StudentID
StudentName
Location
Age
Gender
```

The application should:

1. Add student records.
2. Display all student records.
3. Search for a student using Student ID.
4. Update student details.
5. Delete a student.
6. Use parameterized queries.
7. Validate numeric input.
8. Store the database in a SQLite `.db` file.

---

# 42. Viva Questions

1. What is ADO.NET?
2. What is SQLite?
3. What is `Microsoft.Data.Sqlite`?
4. What is the purpose of `SqliteConnection`?
5. What is the purpose of `SqliteCommand`?
6. What is `SqliteDataReader`?
7. What is the difference between `ExecuteNonQuery()` and `ExecuteReader()`?
8. Which method is used for `INSERT`?
9. Which method is used for `SELECT`?
10. Which method is used for `UPDATE`?
11. Which method is used for `DELETE`?
12. Why are parameterized queries used?
13. What is the purpose of the `WHERE` clause?
14. Why is `StudentID` used while updating or deleting a student?
15. What is a connection string?
16. What does `connection.Open()` do?
17. What does `reader.Read()` do?
18. What is the purpose of `using` in database programming?
19. What is `INTEGER PRIMARY KEY AUTOINCREMENT` in SQLite?
20. What is the difference between SQL Server `IDENTITY` and SQLite `AUTOINCREMENT`?
21. Why is `Console.ReadLine() ?? ""` used?
22. What is the purpose of `int.TryParse()`?
23. What is CRUD?
24. What is the difference between `INSERT` and `UPDATE`?
25. Why is a separate method created for each database operation?

---

# 43. Result

The **C# console-based Student Management Application** was successfully developed using **ADO.NET and SQLite** to perform database operations including:

```text
Adding students
Viewing students
Searching students
Updating students
Deleting students
```

The application uses a SQLite database file and parameterized SQL queries for database operations.

---

# 44. Final Application Structure

The complete practical follows this structure:

```text
StudentManagement
│
├── StudentManagement.csproj
├── Program.cs
└── CollegeDB.db
```

After running:

```bash
dotnet run
```

the SQLite database file:

```text
CollegeDB.db
```

will be created automatically if it does not already exist.

The application then provides:

```text
                    STUDENT MANAGEMENT
                           │
             ┌─────────────┼─────────────┐
             │             │             │
            ADD           VIEW         SEARCH
             │             │             │
             └─────────────┼─────────────┘
                           │
                         UPDATE
                           │
                         DELETE
                           │
                           ↓
                          EXIT
```

# 45. Key Points to Remember

- Use **`Microsoft.Data.Sqlite`** for SQLite.
- Use **`SqliteConnection`** to connect to SQLite.
- Use **`SqliteCommand`** to execute SQL commands.
- Use **`SqliteDataReader`** to read records.
- SQLite database is stored in a `.db` file.
- Use `Data Source=CollegeDB.db` as the connection string.
- Use `INTEGER PRIMARY KEY AUTOINCREMENT` for an automatically generated ID.
- Do not use SQL Server's `IDENTITY` syntax with SQLite.
- Use `ExecuteNonQuery()` for `INSERT`, `UPDATE`, and `DELETE`.
- Use `ExecuteReader()` for `SELECT`.
- Use parameterized queries for user-supplied values.
- Use `int.TryParse()` to safely validate numeric input.
- Use `using` statements to properly dispose of database resources.
