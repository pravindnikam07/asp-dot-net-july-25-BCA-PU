# Practical 2 — Application Development with C# and ADO.NET

## Aim

> To develop a menu-driven database application using C# and ADO.NET for managing student records.

---

## 1. Objectives

After completing this practical, students should be able to:

- Create a C# application that communicates with SQL Server.
- Use ADO.NET for database operations.
- Organize database operations into separate methods.
- Accept input from the user.
- Search for a specific record.
- Display database records.
- Handle basic database-related errors.

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

Practical 1 already introduced:

```text
Add
View
Update
Delete
```

In Practical 2, we add a useful application feature:

```text
Search Student
```

and structure the application more clearly.

---

# 3. Technologies Used

```text
C#
.NET
ADO.NET
SQL Server
```

ADO.NET is the database-access technology used by the C# application. The syllabus includes ADO.NET connection, command and data-reading classes as part of Unit 1.

---

# 4. Application Architecture

The application follows:

```text
┌──────────────────────────┐
│     C# Console App       │
├──────────────────────────┤
│ Menu                     │
│ Input                    │
│ Application Methods      │
├──────────────────────────┤
│        ADO.NET           │
│  SqlConnection           │
│  SqlCommand              │
│  SqlDataReader           │
├──────────────────────────┤
│       SQL Server         │
│       CollegeDB          │
│         Student          │
└──────────────────────────┘
```

---

# 5. Database

Use the database created in Practical 1:

```sql
USE CollegeDB;
```

The `Student` table:

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

If the database and table have already been created during Practical 1, they can be reused.

---

# 6. Create the Project

Create a new console application.

```bash
mkdir StudentManagement
```

Move into the directory:

```bash
cd StudentManagement
```

Create the project:

```bash
dotnet new console
```

Install the SQL Server provider:

```bash
dotnet add package Microsoft.Data.SqlClient
```

Open the project:

```bash
code .
```

---

# 7. Add Required Namespace

At the top of `Program.cs`:

```csharp
using Microsoft.Data.SqlClient;
```

---

# 8. Connection String

Define the connection string:

```csharp
static string connectionString =
    @"Server=.\SQLEXPRESS;
      Database=CollegeDB;
      Trusted_Connection=True;
      TrustServerCertificate=True;";
```

The `Server` value should be changed according to the SQL Server instance being used.

---

# 9. Application Structure

Instead of writing everything inside `Main()`, create separate methods.

```text
Main()
 │
 ├── AddStudent()
 ├── ViewStudents()
 ├── SearchStudent()
 ├── UpdateStudent()
 └── DeleteStudent()
```

This makes the application easier to understand and maintain.

---

# 10. Main Menu

```csharp
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
        Console.WriteLine("3. Search Student");
        Console.WriteLine("4. Update Student");
        Console.WriteLine("5. Delete Student");
        Console.WriteLine("6. Exit");

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

---

# 11. CREATE — Add Student

The SQL command:

```sql
INSERT INTO Student
(StudentName, Location, Age, Gender)
VALUES
(@StudentName, @Location, @Age, @Gender);
```

C# method:

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

    command.Parameters.AddWithValue("@StudentName", name);
    command.Parameters.AddWithValue("@Location", location);
    command.Parameters.AddWithValue("@Age", age);
    command.Parameters.AddWithValue("@Gender", gender);

    connection.Open();

    command.ExecuteNonQuery();

    Console.WriteLine(
        "Student added successfully.");
}
```

---

# 12. READ — View Students

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

# 13. SEARCH — Find a Student

This is the main additional operation for Practical 2.

The user enters a Student ID.

### SQL

```sql
SELECT * FROM Student
WHERE StudentID = @StudentID;
```

### C#

```csharp
static void SearchStudent()
{
    Console.Write("Enter Student ID: ");

    int id = Convert.ToInt32(
        Console.ReadLine());

    string query =
        "SELECT * FROM Student " +
        "WHERE StudentID = @StudentID";

    using SqlConnection connection =
        new SqlConnection(connectionString);

    using SqlCommand command =
        new SqlCommand(query, connection);

    command.Parameters.AddWithValue(
        "@StudentID", id);

    connection.Open();

    using SqlDataReader reader =
        command.ExecuteReader();

    if (reader.Read())
    {
        Console.WriteLine();
        Console.WriteLine("Student Found");
        Console.WriteLine("-------------------------");

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
```

---

# 14. Understanding the Search Operation

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
          ↓
Display student
```

The important code is:

```csharp
if (reader.Read())
```

If a record exists:

```text
true → Student found
```

If no record exists:

```text
false → Student not found
```

---

# 15. UPDATE — Modify Student

```csharp
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
```

---

# 16. DELETE — Delete Student

```csharp
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
```

---

# 17. Complete Program

After understanding each method, combine them into `Program.cs`:

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
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Update Student");
            Console.WriteLine("5. Delete Student");
            Console.WriteLine("6. Exit");

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
                    SearchStudent();
                    break;

                case "4":
                    UpdateStudent();
                    break;

                case "5":
                    DeleteStudent();
                    break;

                case "6":
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

    static void SearchStudent()
    {
        Console.Write("Enter Student ID: ");

        int id = Convert.ToInt32(
            Console.ReadLine());

        string query =
            "SELECT * FROM Student " +
            "WHERE StudentID = @StudentID";

        using SqlConnection connection =
            new SqlConnection(connectionString);

        using SqlCommand command =
            new SqlCommand(query, connection);

        command.Parameters.AddWithValue(
            "@StudentID", id);

        connection.Open();

        using SqlDataReader reader =
            command.ExecuteReader();

        if (reader.Read())
        {
            Console.WriteLine();
            Console.WriteLine("Student Found");
            Console.WriteLine("-------------------------");

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

# 18. Run the Application

Use:

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
3. Search Student
4. Update Student
5. Delete Student
6. Exit

Enter your choice:
```

---

# 19. Example Execution

### Add Student

```text
Enter your choice: 1

Enter Student Name: Rahul
Enter Location: Ahmedabad
Enter Age: 20
Enter Gender: Male

Student added successfully.
```

### View Students

```text
Enter your choice: 2

ID      Name    Location    Age     Gender
------------------------------------------------
1       Rahul   Ahmedabad   20      Male
```

### Search Student

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

### Update Student

```text
Enter your choice: 4

Enter Student ID: 1
Enter New Name: Rahul Patel
Enter New Location: Surat
Enter New Age: 21
Enter New Gender: Male

Student updated successfully.
```

### Delete Student

```text
Enter your choice: 5

Enter Student ID: 1

Student deleted successfully.
```

---

# 20. Important ADO.NET Concepts Used

### `SqlConnection`

Used to connect the application to SQL Server.

```csharp
SqlConnection connection =
    new SqlConnection(connectionString);
```

### `SqlCommand`

Used to execute SQL commands.

```csharp
SqlCommand command =
    new SqlCommand(query, connection);
```

### `SqlDataReader`

Used to read records returned by a `SELECT` query.

```csharp
SqlDataReader reader =
    command.ExecuteReader();
```

### `ExecuteNonQuery()`

Used for:

```text
INSERT
UPDATE
DELETE
```

### `ExecuteReader()`

Used for:

```text
SELECT
```

---

# 21. Application Flow

```text
             Main()
               │
               ↓
          Display Menu
               │
       ┌───────┼────────┐
       ↓       ↓        ↓
     Add     View     Search
       │       │        │
       └───────┼────────┘
               ↓
            ADO.NET
               ↓
         SQL Server
               │
       ┌───────┼────────┐
       ↓       ↓        ↓
     Insert   Select   Update/Delete
```

---

# 22. Practical Exercise

Develop a **Student Management Application** using C# and ADO.NET with the following menu:

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

All database operations should use **parameterized queries**.

---

# 23. Viva Questions

1. What is ADO.NET?
2. What is the purpose of `SqlConnection`?
3. What is the purpose of `SqlCommand`?
4. What is `SqlDataReader`?
5. What is the difference between `ExecuteNonQuery()` and `ExecuteReader()`?
6. Which method is used for `INSERT`?
7. Which method is used for `SELECT`?
8. Why are parameterized queries used?
9. What is the purpose of the `WHERE` clause?
10. Why is `StudentID` used while updating or deleting a student?
11. What is a connection string?
12. What does `connection.Open()` do?
13. What does `reader.Read()` do?
14. Why is the database connection placed inside a `using` block?
15. What is the purpose of the `switch` statement in this application?

---

# 24. Result

> The C# console-based Student Management application was successfully developed using ADO.NET to connect with SQL Server and perform database operations including adding, viewing, searching, updating, and deleting student records.

### What changes from Practical 1?

```text
Practical 1
    ↓
Basic CRUD
    ↓
Understand ADO.NET + CRUD

Practical 2
    ↓
Application Development
    ↓
Menu-driven application
    ↓
Separate methods
    ↓
Search functionality
    ↓
Complete Student Management Application
```
