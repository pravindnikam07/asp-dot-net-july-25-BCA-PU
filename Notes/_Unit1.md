# UNIT 1: OVERVIEW OF .NET FRAMEWORK, C# AND ADO.NET

## 1. .NET Framework Architecture and Components

### 1.1 Introduction to .NET Framework

**.NET Framework** is a software development and execution platform developed by Microsoft for building and running applications.

It provides:

- A runtime environment for executing applications
- A large collection of reusable classes and libraries
- Support for multiple programming languages
- Memory management
- Exception handling
- Security
- Database connectivity

Applications developed using the .NET Framework include:

- Console applications
- Windows Forms applications
- Web applications
- Database applications

The basic relationship is:

```text
Application
     ↓
.NET Framework
     ↓
Operating System
     ↓
Hardware
```

---

## 1.2 .NET Framework Architecture

The major components of the .NET Framework are:

```text
┌──────────────────────────────────────┐
│          .NET Applications           │
│ Console | Windows Forms | ASP.NET   │
└──────────────────┬───────────────────┘
                   ↓
┌──────────────────────────────────────┐
│       Framework Class Library         │
│                FCL                   │
└──────────────────┬───────────────────┘
                   ↓
┌──────────────────────────────────────┐
│    Common Language Runtime (CLR)     │
│                                      │
│ JIT | GC | Exception Handling | etc.│
└──────────────────┬───────────────────┘
                   ↓
┌──────────────────────────────────────┐
│          Operating System            │
└──────────────────────────────────────┘
```

The important components are:

1. **CLR — Common Language Runtime**
2. **FCL — Framework Class Library**
3. **CTS — Common Type System**
4. **CLS — Common Language Specification**
5. **Language Compilers**
6. **JIT Compiler**

---

## 1.3 Common Language Runtime (CLR)

**CLR** is the execution environment of the .NET Framework.

It manages the execution of .NET applications and provides services such as:

- Memory management
- Garbage collection
- Exception handling
- Security
- Thread management
- Type safety
- JIT compilation

Therefore:

> **CLR provides the environment in which .NET applications are executed.**

---

## 1.4 Framework Class Library (FCL)

**FCL** is a collection of reusable classes, interfaces and other types provided by the .NET Framework.

It provides ready-made functionality for:

- File handling
- Collections
- Networking
- Database access
- Input/output operations
- Web development
- User interface development

For example:

```csharp
Console.WriteLine("Hello");
```

The `Console` class is provided by the .NET class library.

ADO.NET, which is used for database programming, is also part of the .NET Framework library.

---

## 1.5 Common Type System (CTS)

**CTS** defines the data types supported by the .NET Framework and specifies how these types are represented and used.

For example:

```csharp
int age = 20;
double salary = 25000.50;
char grade = 'A';
bool result = true;
```

CTS provides a common type system that allows different .NET languages to work with compatible data types.

---

## 1.6 Common Language Specification (CLS)

**CLS** defines a set of common rules that .NET languages follow to ensure language interoperability.

Different languages such as C#, Visual Basic and F# can work within the .NET environment because they follow common .NET standards.

The relationship between CTS and CLS can be summarized as:

| CTS                                 | CLS                                      |
| ----------------------------------- | ---------------------------------------- |
| Defines the types supported by .NET | Defines common rules for .NET languages  |
| Broader                             | Subset of CTS                            |
| Concerned with type system          | Concerned with language interoperability |

---

## 1.7 CIL / MSIL

When a C# program is compiled, it is not directly converted into machine code.

The C# compiler converts the source code into **CIL (Common Intermediate Language)**.

CIL was previously called **MSIL (Microsoft Intermediate Language)**.

The execution process is:

```text
C# Source Code
       ↓
C# Compiler
       ↓
CIL / MSIL
       ↓
CLR
       ↓
JIT Compiler
       ↓
Machine Code
       ↓
CPU
```

---

## 1.8 JIT Compiler

**JIT** stands for **Just-In-Time Compiler**.

The JIT compiler is a component of CLR that converts CIL into native machine code required by the operating system and processor.

Therefore:

```text
CIL
 ↓
JIT
 ↓
Machine Code
```

This machine code is then executed by the CPU.

---

## 1.9 Garbage Collection

.NET provides automatic memory management through **Garbage Collection**.

When objects are created, memory is allocated for them. When an object is no longer being used, the **Garbage Collector (GC)** identifies the unused object and reclaims its memory.

```text
Object Created
      ↓
Memory Allocated
      ↓
Object No Longer Used
      ↓
Garbage Collector
      ↓
Memory Reclaimed
```

This reduces the need for manual memory management.

---

## 1.10 Managed and Unmanaged Code

### Managed Code

Code that executes under the management of CLR is called **managed code**.

C# programs running on the .NET Framework are examples of managed code.

CLR manages:

- Memory
- Exceptions
- Security
- Type safety
- Garbage collection

### Unmanaged Code

Code that executes outside CLR is called **unmanaged code**.

Traditional native C/C++ programs and native operating system APIs are examples.

---

## 1.11 Complete .NET Execution Flow

Consider the following C# program:

```csharp
class Program
{
    static void Main()
    {
        Console.WriteLine("Hello World");
    }
}
```

The execution takes place as follows:

```text
Program.cs
    ↓
C# Compiler
    ↓
CIL / MSIL
    ↓
CLR loads the program
    ↓
JIT Compiler
    ↓
Native Machine Code
    ↓
CPU executes the code
```

The important components can be remembered as:

> **CLR → Executes** > **JIT → Converts CIL to machine code** > **CTS → Defines types** > **CLS → Defines common language rules** > **FCL → Provides reusable libraries**

---

# 2. Revising OOP Concepts with C#

The .NET Framework is based heavily on object-oriented programming. C# is an object-oriented programming language, so understanding its OOP concepts is necessary before working with ASP.NET and ADO.NET.

The four major principles of OOP are:

```text
                OOP
                 │
      ┌──────────┼──────────┐
      ↓          ↓          ↓
Encapsulation Abstraction Inheritance
                 │
                 ↓
            Polymorphism
```

---

## 2.1 Class

A **class** is a blueprint or template used to create objects.

```csharp
class Student
{
    public string Name;
    public int Marks;

    public void Display()
    {
        Console.WriteLine(Name);
        Console.WriteLine(Marks);
    }
}
```

The `Student` class defines the data and behaviour of a student.

---

## 2.2 Object

An **object** is an instance of a class.

```csharp
Student s1 = new Student();
```

Here:

- `Student` is the class.
- `s1` is the object/reference.
- `new Student()` creates the object.

Values can be assigned to the object:

```csharp
s1.Name = "Rahul";
s1.Marks = 85;

s1.Display();
```

The relationship is:

```text
Class
  ↓
Object
```

A single class can be used to create multiple objects.

```csharp
Student s1 = new Student();
Student s2 = new Student();
Student s3 = new Student();
```

---

## 2.3 Encapsulation

**Encapsulation** is the process of combining data and methods within a class and controlling access to the data.

For example:

```csharp
class Student
{
    private int marks;

    public int Marks
    {
        get
        {
            return marks;
        }

        set
        {
            if (value >= 0 && value <= 100)
                marks = value;
        }
    }
}
```

Here, `marks` is private and cannot be directly accessed from outside the class. The `Marks` property controls how the value is accessed and modified.

---

## 2.4 Properties

A **property** provides controlled access to the data of a class.

An auto-implemented property can be written as:

```csharp
class Student
{
    public int EnrollmentNo { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}
```

Objects can use these properties:

```csharp
Student s = new Student();

s.EnrollmentNo = 101;
s.Name = "Rahul";
s.Email = "rahul@gmail.com";
```

Properties are widely used in .NET and ASP.NET applications.

---

## 2.5 Abstraction

**Abstraction** means hiding unnecessary implementation details and exposing only the essential functionality.

For example, when using an ATM, the user performs operations such as:

```text
Enter PIN
   ↓
Select Withdrawal
   ↓
Enter Amount
   ↓
Receive Money
```

The internal implementation of bank servers, database operations and transaction processing is hidden.

In C#, abstraction can be implemented using:

- Abstract classes
- Interfaces

Example:

```csharp
abstract class Payment
{
    public abstract void Pay();
}
```

The implementation can be provided by a derived class:

```csharp
class UPI : Payment
{
    public override void Pay()
    {
        Console.WriteLine("Payment through UPI");
    }
}
```

---

## 2.6 Inheritance

**Inheritance** allows a class to acquire properties and methods from another class.

```csharp
class Person
{
    public string Name;

    public void DisplayName()
    {
        Console.WriteLine(Name);
    }
}

class Student : Person
{
    public int Marks;
}
```

`Student` inherits from `Person`.

Therefore:

```text
             Person
           /        \
       Name       DisplayName()
             ↓
           Student
              +
            Marks
```

The main advantage of inheritance is **code reusability**.

Common types of inheritance include:

### Single Inheritance

```text
A
↓
B
```

### Multilevel Inheritance

```text
A
↓
B
↓
C
```

### Hierarchical Inheritance

```text
      A
     / \
    B   C
```

C# does not support multiple inheritance through classes. Multiple interfaces can be implemented by a class instead.

---

## 2.7 Polymorphism

**Polymorphism** means the ability of the same method or interface to have different forms of behaviour.

There are two common types:

1. Compile-time polymorphism
2. Runtime polymorphism

### Compile-Time Polymorphism

Method overloading is an example.

```csharp
class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }
}
```

The method name is the same, but the parameter lists are different.

### Runtime Polymorphism

Method overriding is an example.

```csharp
class Animal
{
    public virtual void Sound()
    {
        Console.WriteLine("Animal Sound");
    }
}

class Dog : Animal
{
    public override void Sound()
    {
        Console.WriteLine("Bark");
    }
}
```

Now:

```csharp
Animal a = new Dog();
a.Sound();
```

Output:

```text
Bark
```

The method executed is determined at runtime.

---

## 2.8 Method Overloading vs Method Overriding

| Method Overloading                  | Method Overriding             |
| ----------------------------------- | ----------------------------- |
| Same method name                    | Same method name              |
| Different parameter list            | Same method signature         |
| Usually within the same class       | Requires inheritance          |
| Compile-time polymorphism           | Runtime polymorphism          |
| No `virtual`/`override` requirement | Uses `virtual` and `override` |

---

## 2.9 Interface

An **interface** defines a contract that implementing classes must follow.

```csharp
interface IPayment
{
    void Pay();
}
```

A class can implement the interface:

```csharp
class UPI : IPayment
{
    public void Pay()
    {
        Console.WriteLine("Payment through UPI");
    }
}
```

Another class can provide a different implementation:

```csharp
class CreditCard : IPayment
{
    public void Pay()
    {
        Console.WriteLine("Payment through Credit Card");
    }
}
```

Thus:

```text
             IPayment
             /      \
            ↓        ↓
          UPI    CreditCard
           ↓          ↓
       Pay using    Pay using
         UPI       Credit Card
```

Interfaces are useful for abstraction and runtime polymorphism.

---

## 2.10 Constructor

A **constructor** is a special member of a class that is automatically called when an object is created.

```csharp
class Student
{
    public string Name;

    public Student()
    {
        Name = "Unknown";
    }
}
```

When:

```csharp
Student s = new Student();
```

the constructor is automatically executed.

A parameterized constructor can initialize an object with specific values:

```csharp
class Student
{
    public string Name;
    public int Marks;

    public Student(string name, int marks)
    {
        Name = name;
        Marks = marks;
    }
}
```

Object creation:

```csharp
Student s = new Student("Rahul", 85);
```

---

# 3. ADO.NET

After understanding .NET and C# OOP concepts, the next requirement is to connect a .NET application with a database.

For this purpose, the .NET Framework provides **ADO.NET**.

## 3.1 What is ADO.NET?

**ADO.NET is a .NET Framework technology used to access and manipulate data from databases and other data sources.**

ADO.NET can be used to:

- Establish database connections
- Execute SQL commands
- Retrieve data
- Insert data
- Update data
- Delete data
- Store data in memory
- Bind database data to application controls

The basic flow is:

```text
.NET Application
       ↓
     C# Code
       ↓
     ADO.NET
       ↓
    Database
```

For SQL Server:

```text
ASP.NET Application
        ↓
       C#
        ↓
     ADO.NET
        ↓
   SQL Server
```

---

# 4. ADO.NET Architecture

ADO.NET provides two approaches for working with databases:

1. **Connected Architecture**
2. **Disconnected Architecture**

```text
                 ADO.NET
                    │
          ┌─────────┴─────────┐
          ↓                   ↓
     Connected           Disconnected
    Architecture          Architecture
          │                   │
     DataReader         DataAdapter
          │                   │
     Connection             DataSet
     Command             DataTable
          │                   │
          └────────┬──────────┘
                   ↓
               Database
```

---

# 5. Connected Architecture

In **connected architecture**, the application maintains an active connection with the database while data is being accessed.

The main objects are:

- `SqlConnection`
- `SqlCommand`
- `SqlDataReader`

The basic flow is:

```text
Application
     ↓
SqlConnection
     ↓
SqlCommand
     ↓
Database
     ↓
SqlDataReader
     ↓
Application
```

---

## 5.1 SqlConnection

`SqlConnection` establishes a connection between the application and SQL Server.

```csharp
SqlConnection con =
    new SqlConnection(connectionString);

con.Open();
```

The connection remains open while the required database operations are performed.

---

## 5.2 SqlCommand

`SqlCommand` is used to execute SQL statements or stored procedures.

```csharp
SqlCommand cmd =
    new SqlCommand(
        "SELECT * FROM Students", con);
```

Here:

- `con` represents the database connection.
- The SQL query specifies the operation to perform.

---

## 5.3 SqlDataReader

`SqlDataReader` is used to read the results returned by a database query.

```csharp
SqlDataReader reader =
    cmd.ExecuteReader();

while (reader.Read())
{
    Console.WriteLine(reader["Name"]);
}
```

A `DataReader` provides:

- Forward-only access
- Read-only access
- Fast data retrieval
- Low memory usage

The complete example is:

```csharp
SqlConnection con =
    new SqlConnection(connectionString);

con.Open();

SqlCommand cmd =
    new SqlCommand(
        "SELECT * FROM Students", con);

SqlDataReader reader =
    cmd.ExecuteReader();

while (reader.Read())
{
    Console.WriteLine(reader["Name"]);
}

reader.Close();
con.Close();
```

The connected architecture can therefore be summarized as:

```text
Connection
     ↓
Command
     ↓
DataReader
     ↓
Database Records
```

---

# 6. Disconnected Architecture

In **disconnected architecture**, data is retrieved from the database and stored in memory. The database connection does not need to remain continuously open while the application works with the retrieved data.

The main objects are:

- `SqlDataAdapter`
- `DataSet`
- `DataTable`

The basic flow is:

```text
Application
     ↓
DataAdapter
     ↓
Database
     ↓
DataSet
     ↓
DataTable
```

---

## 6.1 SqlDataAdapter

`SqlDataAdapter` acts as a bridge between the database and disconnected objects such as `DataSet` and `DataTable`.

Example:

```csharp
SqlDataAdapter da =
    new SqlDataAdapter(
        "SELECT * FROM Students", connectionString);
```

It retrieves data from the database and fills a `DataSet` or `DataTable`.

---

## 6.2 DataSet

A `DataSet` is an **in-memory representation of data**.

It can contain multiple `DataTable` objects.

```text
DataSet
   │
   ├── Students
   ├── Courses
   └── Fees
```

Each table can contain:

```text
DataTable
   │
   ├── DataColumn
   ├── DataRow
   └── Constraints
```

Example:

```csharp
DataSet ds = new DataSet();

SqlDataAdapter da =
    new SqlDataAdapter(
        "SELECT * FROM Students", connectionString);

da.Fill(ds, "Students");
```

After the data is filled into the `DataSet`, the application can work with the data in memory without maintaining a continuous database connection.

---

# 7. Connected vs Disconnected Architecture

| Feature      | Connected Architecture                  | Disconnected Architecture         |
| ------------ | --------------------------------------- | --------------------------------- |
| Main object  | `DataReader`                            | `DataSet` / `DataTable`           |
| Connection   | Remains active during access            | Not continuously required         |
| Data access  | Forward-only, read-only with DataReader | Data can be manipulated in memory |
| Memory usage | Low                                     | Higher                            |
| Speed        | Fast for sequential reading             | Suitable for in-memory operations |
| Main objects | Connection, Command, DataReader         | DataAdapter, DataSet, DataTable   |
| Suitable for | Fast sequential data access             | Working with retrieved data       |

---

# 8. Complete ADO.NET Architecture

The relationship between the main objects can now be understood as:

```text
                       ADO.NET
                          │
             ┌────────────┴────────────┐
             ↓                         ↓
       CONNECTED                 DISCONNECTED
       ARCHITECTURE               ARCHITECTURE
             │                         │
       SqlConnection              DataAdapter
             │                         │
       SqlCommand                  DataSet
             │                         │
       DataReader                 DataTable
             │                         │
             └──────────┬──────────────┘
                        ↓
                    SQL Server
```

The purpose of each major object is:

| Object           | Purpose                                                  |
| ---------------- | -------------------------------------------------------- |
| `SqlConnection`  | Establishes database connection                          |
| `SqlCommand`     | Executes SQL commands                                    |
| `SqlDataReader`  | Reads database records sequentially                      |
| `SqlDataAdapter` | Transfers data between database and disconnected objects |
| `DataSet`        | Stores data in memory                                    |
| `DataTable`      | Represents a table in memory                             |

---

# 9. Relationship With the Next Topics

The concepts introduced here form the foundation for the remaining ADO.NET topics:

```text
.NET Framework
      ↓
C# and OOP
      ↓
ADO.NET
      ↓
ADO.NET Architecture
      ↓
Connection
      ↓
Command
      ↓
DataReader
      ↓
DataAdapter
      ↓
DataSet
      ↓
DataTable
      ↓
DataRow / DataColumn / Constraints
      ↓
DataView
      ↓
Data Binding
      ↓
GridView / Repeater
      ↓
SQLDataSource
```

## 6. ADO.NET Classes and Objects

The previous topic introduced the two ADO.NET architectures. The next step is to understand the objects used to implement these architectures.

For SQL Server, the commonly used ADO.NET classes are:

```text
ADO.NET
   │
   ├── Connected Architecture
   │      ├── SqlConnection
   │      ├── SqlCommand
   │      └── SqlDataReader
   │
   └── Disconnected Architecture
          ├── SqlDataAdapter
          ├── DataSet
          ├── DataTable
          ├── DataRow
          ├── DataColumn
          ├── Constraints
          └── DataView
```

---

# 6.1 SqlConnection

`SqlConnection` represents a connection between a C# application and a SQL Server database.

The connection requires a **connection string**, which contains information required to connect to the database.

Example:

```csharp
string connectionString =
    "Server=localhost;Database=CollegeDB;Trusted_Connection=True;";
```

A connection object can then be created:

```csharp
SqlConnection con =
    new SqlConnection(connectionString);
```

The connection is opened using:

```csharp
con.Open();
```

and closed using:

```csharp
con.Close();
```

The basic flow is:

```text
Application
     ↓
SqlConnection
     ↓
SQL Server
```

### Important Methods

| Method      | Purpose                                   |
| ----------- | ----------------------------------------- |
| `Open()`    | Opens the database connection             |
| `Close()`   | Closes the database connection            |
| `Dispose()` | Releases resources used by the connection |

---

# 6.2 Connection String

A connection string provides the information required to connect to a database.

A typical SQL Server connection string is:

```csharp
string connectionString =
    "Server=localhost;Database=CollegeDB;Trusted_Connection=True;";
```

Common components include:

| Component            | Meaning                     |
| -------------------- | --------------------------- |
| `Server`             | SQL Server instance         |
| `Database`           | Database name               |
| `Trusted_Connection` | Uses Windows authentication |

Another common form using SQL Server authentication is:

```csharp
string connectionString =
    "Server=localhost;Database=CollegeDB;User Id=sa;Password=yourPassword;";
```

Connection strings should be stored securely, especially when applications are deployed.

---

# 6.3 SqlCommand

`SqlCommand` is used to execute SQL statements or stored procedures against the database.

Example:

```csharp
SqlCommand cmd =
    new SqlCommand(
        "SELECT * FROM Students", con);
```

Here:

- SQL query specifies the operation.
- `con` specifies the connection through which the command is executed.

The relationship is:

```text
SqlConnection
      ↓
SqlCommand
      ↓
SQL Server
```

---

## 6.3.1 Types of SQL Commands

Common SQL operations include:

### SELECT

Used to retrieve data.

```sql
SELECT * FROM Students;
```

### INSERT

Used to add data.

```sql
INSERT INTO Students(Name, Course)
VALUES('Rahul', 'IT');
```

### UPDATE

Used to modify existing data.

```sql
UPDATE Students
SET Course = 'CS'
WHERE Id = 101;
```

### DELETE

Used to remove data.

```sql
DELETE FROM Students
WHERE Id = 101;
```

---

# 6.4 Executing a Command

The method used to execute a command depends on the type of result expected.

ADO.NET commonly provides:

```text
ExecuteNonQuery()
ExecuteScalar()
ExecuteReader()
```

---

## 6.4.1 ExecuteNonQuery()

`ExecuteNonQuery()` is used for commands that do not return a result set.

It is commonly used for:

- `INSERT`
- `UPDATE`
- `DELETE`

Example:

```csharp
SqlCommand cmd =
    new SqlCommand(
        "UPDATE Students SET Course='CS' WHERE Id=101",
        con);

int rows = cmd.ExecuteNonQuery();
```

The returned integer represents the number of affected rows.

---

## 6.4.2 ExecuteScalar()

`ExecuteScalar()` returns a single value.

For example:

```sql
SELECT COUNT(*) FROM Students;
```

C#:

```csharp
SqlCommand cmd =
    new SqlCommand(
        "SELECT COUNT(*) FROM Students",
        con);

int count = Convert.ToInt32(
    cmd.ExecuteScalar());
```

This is useful when only one value is required.

Examples:

```text
COUNT(*)
MAX()
MIN()
SUM()
AVG()
```

---

## 6.4.3 ExecuteReader()

`ExecuteReader()` is used when a query returns multiple rows and columns.

Example:

```csharp
SqlCommand cmd =
    new SqlCommand(
        "SELECT * FROM Students",
        con);

SqlDataReader reader =
    cmd.ExecuteReader();
```

The returned `SqlDataReader` is then used to read the records.

---

# 6.5 SqlDataReader

`SqlDataReader` provides a fast, forward-only and read-only way to retrieve data from a database.

It belongs to the **connected architecture**.

The flow is:

```text
SqlConnection
      ↓
SqlCommand
      ↓
SqlDataReader
      ↓
Database Records
```

Example:

```csharp
SqlDataReader reader =
    cmd.ExecuteReader();

while (reader.Read())
{
    Console.WriteLine(reader["Name"]);
}
```

---

# 6.6 Read() Method

The `Read()` method moves the `DataReader` to the next record.

Suppose the table contains:

|  ID | Name  | Course |
| --: | ----- | ------ |
| 101 | Rahul | IT     |
| 102 | Amit  | CS     |
| 103 | Priya | IT     |

Initially, the reader is positioned before the first record.

```text
Position
   ↓
Before 101
```

After:

```csharp
reader.Read();
```

it moves to:

```text
101 Rahul IT
   ↑
Reader
```

Another call:

```csharp
reader.Read();
```

moves to:

```text
102 Amit CS
   ↑
Reader
```

When there are no more records, `Read()` returns `false`.

Therefore:

```csharp
while (reader.Read())
{
    // Process current record
}
```

continues until all records have been processed.

---

# 6.7 Accessing Column Values

A column can be accessed using its name:

```csharp
Console.WriteLine(reader["Name"]);
```

or using its index:

```csharp
Console.WriteLine(reader[1]);
```

For example:

```csharp
while (reader.Read())
{
    Console.WriteLine(reader["Id"]);
    Console.WriteLine(reader["Name"]);
    Console.WriteLine(reader["Course"]);
}
```

---

# 6.8 Complete Connected Architecture Example

The following example demonstrates how `SqlConnection`, `SqlCommand` and `SqlDataReader` work together.

```csharp
using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString =
            "Server=localhost;Database=CollegeDB;Trusted_Connection=True;";

        SqlConnection con =
            new SqlConnection(connectionString);

        con.Open();

        SqlCommand cmd =
            new SqlCommand(
                "SELECT Id, Name, Course FROM Students",
                con);

        SqlDataReader reader =
            cmd.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine(
                reader["Id"] + " " +
                reader["Name"] + " " +
                reader["Course"]);
        }

        reader.Close();
        con.Close();
    }
}
```

The execution flow is:

```text
Create Connection
       ↓
Open Connection
       ↓
Create Command
       ↓
ExecuteReader()
       ↓
DataReader
       ↓
Read Records
       ↓
Close DataReader
       ↓
Close Connection
```

---

# 6.9 Parameterized Queries

SQL queries should not be constructed by directly concatenating user input.

For example, avoid:

```csharp
string query =
    "SELECT * FROM Students WHERE Name='" + name + "'";
```

Instead, use parameters:

```csharp
SqlCommand cmd =
    new SqlCommand(
        "SELECT * FROM Students WHERE Name = @Name",
        con);

cmd.Parameters.AddWithValue("@Name", name);
```

Parameters help prevent **SQL injection** and provide safer database operations.

---

# 6.10 SqlDataAdapter

`SqlDataAdapter` is mainly used in the **disconnected architecture**.

It acts as a bridge between the database and objects such as `DataSet` and `DataTable`.

```text
SQL Server
    ↕
DataAdapter
    ↕
DataSet / DataTable
```

Example:

```csharp
SqlDataAdapter da =
    new SqlDataAdapter(
        "SELECT * FROM Students",
        connectionString);
```

---

# 6.11 DataSet

A `DataSet` is an in-memory collection of data.

It can contain multiple `DataTable` objects.

```text
DataSet
   │
   ├── Students
   ├── Courses
   └── Fees
```

Example:

```csharp
DataSet ds = new DataSet();

SqlDataAdapter da =
    new SqlDataAdapter(
        "SELECT * FROM Students",
        connectionString);

da.Fill(ds, "Students");
```

After `Fill()` executes, the retrieved data is stored inside the `DataSet`.

---

# 6.12 DataTable

A `DataTable` represents a single table of data in memory.

Its structure consists mainly of:

```text
DataTable
    │
    ├── DataColumn
    ├── DataRow
    └── Constraints
```

Example:

```csharp
DataTable table = new DataTable();

SqlDataAdapter da =
    new SqlDataAdapter(
        "SELECT * FROM Students",
        connectionString);

da.Fill(table);
```

A `DataTable` can therefore be used when only one table is required.

---

# 6.13 DataColumn

`DataColumn` represents a column in a `DataTable`.

For example:

```text
Students
-------------------------
Id | Name | Course
```

The columns are:

```text
DataColumn
 ├── Id
 ├── Name
 └── Course
```

Columns can be accessed programmatically:

```csharp
DataColumn column =
    table.Columns["Name"];
```

---

# 6.14 DataRow

`DataRow` represents a single record in a `DataTable`.

For example:

```text
Students
-------------------------
101 | Rahul | IT
102 | Amit  | CS
```

Each record is a `DataRow`.

Example:

```csharp
foreach (DataRow row in table.Rows)
{
    Console.WriteLine(row["Name"]);
}
```

The relationship is:

```text
DataTable
    │
    ├── DataColumn
    │      ├── Id
    │      ├── Name
    │      └── Course
    │
    └── DataRow
           ├── 101 | Rahul | IT
           ├── 102 | Amit  | CS
           └── 103 | Priya | IT
```

---

# 6.15 Data Constraints

Constraints are rules used to maintain the integrity of data in a `DataTable`.

Common constraints include:

- `PrimaryKeyConstraint`
- `UniqueConstraint`
- `ForeignKeyConstraint`

For example, a student ID can be defined as a primary key so that every student has a unique ID.

```text
Student
----------------------
ID ← Primary Key
Name
Course
```

Constraints help prevent invalid or inconsistent data.

---

# 6.16 DataView

`DataView` provides a customized view of the data stored in a `DataTable`.

It can be used for:

- Sorting
- Filtering
- Viewing selected records

Example:

```csharp
DataView view = new DataView(table);

view.RowFilter = "Course = 'IT'";
view.Sort = "Name ASC";
```

The original `DataTable` remains unchanged while the `DataView` provides a filtered or sorted view.

```text
DataTable
     ↓
 DataView
   ├── Filter
   └── Sort
```

---

# 6.17 Complete Relationship of ADO.NET Classes

The ADO.NET objects are connected as follows:

```text
                       ADO.NET
                          │
          ┌───────────────┴───────────────┐
          ↓                               ↓
    CONNECTED                       DISCONNECTED
          │                               │
  SqlConnection                     SqlDataAdapter
          ↓                               ↓
    SqlCommand                         DataSet
          ↓                               │
  SqlDataReader                    DataTable
                                          │
                         ┌────────────────┼─────────────┐
                         ↓                ↓             ↓
                    DataColumn        DataRow      Constraints
                                          │
                                          ↓
                                      DataView
```

---

# 6.18 Comparison of Important ADO.NET Objects

| Object           | Main Purpose                    | Architecture |
| ---------------- | ------------------------------- | ------------ |
| `SqlConnection`  | Connect to SQL Server           | Connected    |
| `SqlCommand`     | Execute SQL commands            | Connected    |
| `SqlDataReader`  | Read records sequentially       | Connected    |
| `SqlDataAdapter` | Transfer data                   | Disconnected |
| `DataSet`        | Store multiple tables in memory | Disconnected |
| `DataTable`      | Store one table in memory       | Disconnected |
| `DataColumn`     | Represents a column             | Disconnected |
| `DataRow`        | Represents a record             | Disconnected |
| `Constraints`    | Maintain data integrity         | Disconnected |
| `DataView`       | Filter and sort data            | Disconnected |

---

# 6.19 Execution Methods of SqlCommand

The three important methods can be remembered as:

```text
SqlCommand
    │
    ├── ExecuteNonQuery()
    │       ↓
    │    INSERT / UPDATE / DELETE
    │
    ├── ExecuteScalar()
    │       ↓
    │    Single Value
    │
    └── ExecuteReader()
            ↓
       Multiple Records
```

| Method              | Used When                 | Example                |
| ------------------- | ------------------------- | ---------------------- |
| `ExecuteNonQuery()` | No result set required    | INSERT, UPDATE, DELETE |
| `ExecuteScalar()`   | One value required        | `COUNT(*)`             |
| `ExecuteReader()`   | Multiple records required | `SELECT`               |

---

# 6.20 Summary

ADO.NET provides a set of classes for communicating with databases.

The connected architecture primarily uses:

```text
SqlConnection
      ↓
SqlCommand
      ↓
SqlDataReader
```

The disconnected architecture primarily uses:

```text
SqlDataAdapter
      ↓
DataSet / DataTable
      ↓
DataRow / DataColumn / Constraints
      ↓
DataView
```

The overall relationship is:

```text
C# Application
      ↓
   ADO.NET
      ↓
Database Access
      ↓
Retrieve / Insert / Update / Delete
      ↓
Application Data
```

## 7. Data Binding and Data-Bound Controls

After retrieving data using ADO.NET, the next requirement is to **display that data in an application**.

For example, a database may contain:

|  Id | Name  | Course |
| --: | ----- | ------ |
| 101 | Rahul | IT     |
| 102 | Amit  | CS     |
| 103 | Priya | IT     |

Instead of manually displaying each record, .NET provides **data binding**, which connects a data source to a control automatically.

The relationship is:

```text
Database
   ↓
ADO.NET
   ↓
DataSet / DataTable
   ↓
Data Binding
   ↓
Data-Bound Control
   ↓
Display Data
```

---

# 7.1 What is Data Binding?

**Data binding is the process of connecting a data source to a control so that the control can display or work with the data automatically.**

A data source can be:

- `DataTable`
- `DataSet`
- `DataView`
- `SqlDataSource`
- Other objects that provide data

A data-bound control can be:

- `GridView`
- `Repeater`
- Other ASP.NET data controls

For example:

```text
DataTable
    ↓
Data Binding
    ↓
GridView
```

The GridView automatically generates its display from the supplied data.

---

# 7.2 Why Data Binding is Used

Without data binding, each database record would have to be processed manually.

With data binding:

```text
Database
   ↓
DataTable
   ↓
GridView
```

The control handles the display of the records.

The major advantages are:

- Less code
- Automatic data display
- Easy database integration
- Easier maintenance
- Supports dynamic data

---

# 7.3 Data-Bound Controls

A **data-bound control** is a control that can display data obtained from a data source.

Two important controls in this syllabus are:

1. `GridView`
2. `Repeater`

---

# 8. GridView Control

`GridView` is an ASP.NET data-bound control used to display data in a tabular format.

For example:

```text
┌─────┬────────┬────────┐
│ ID  │ Name   │ Course │
├─────┼────────┼────────┤
│ 101 │ Rahul  │ IT     │
│ 102 │ Amit   │ CS     │
│ 103 │ Priya  │ IT     │
└─────┴────────┴────────┘
```

It is useful for displaying multiple records in rows and columns.

---

# 8.1 Binding a DataTable to GridView

Suppose a `DataTable` contains student records.

The GridView can be bound as follows:

```csharp
GridView1.DataSource = table;
GridView1.DataBind();
```

Here:

- `DataSource` specifies the source of data.
- `DataBind()` performs the binding operation.

The flow is:

```text
DataTable
    ↓
GridView1.DataSource
    ↓
GridView1.DataBind()
    ↓
HTML Table
```

---

# 8.2 GridView with DataSet

If a `DataSet` contains a table named `Students`:

```csharp
GridView1.DataSource = ds.Tables["Students"];
GridView1.DataBind();
```

The GridView displays the records contained in that table.

---

# 8.3 GridView Features

GridView provides built-in support for several common operations, including:

- Displaying records
- Selecting records
- Editing records
- Deleting records
- Sorting
- Paging

For example, paging can display records as:

```text
Page 1   2   3   4   Next
```

instead of displaying all records on one page.

---

# 9. Repeater Control

`Repeater` is an ASP.NET data-bound control used to display repeated data using a customized layout.

Unlike GridView, Repeater does not automatically create a complete table structure.

The layout is defined using templates.

Example:

```text
Student: Rahul
Course: IT

Student: Amit
Course: CS

Student: Priya
Course: IT
```

---

# 9.1 Repeater Templates

Important Repeater templates include:

| Template                  | Purpose                                    |
| ------------------------- | ------------------------------------------ |
| `HeaderTemplate`          | Defines content displayed at the beginning |
| `ItemTemplate`            | Defines how each record is displayed       |
| `AlternatingItemTemplate` | Defines alternate record layout            |
| `SeparatorTemplate`       | Defines separator between records          |
| `FooterTemplate`          | Defines content displayed at the end       |

The most commonly used template is `ItemTemplate`.

Example:

```aspx
<asp:Repeater ID="Repeater1" runat="server">

    <ItemTemplate>

        <h3><%# Eval("Name") %></h3>
        <p>Course: <%# Eval("Course") %></p>

    </ItemTemplate>

</asp:Repeater>
```

---

# 9.2 Binding Repeater

The Repeater can be connected to a data source:

```csharp
Repeater1.DataSource = table;
Repeater1.DataBind();
```

The flow is:

```text
DataTable
    ↓
Repeater.DataSource
    ↓
Repeater.DataBind()
    ↓
Repeated HTML Content
```

---

# 10. GridView vs Repeater

Both are data-bound controls, but they are designed for different purposes.

| GridView                                      | Repeater                                             |
| --------------------------------------------- | ---------------------------------------------------- |
| Displays data in tabular format               | Displays data in a customized layout                 |
| Provides many built-in features               | Provides greater layout flexibility                  |
| Automatically generates rows and columns      | Uses templates                                       |
| Suitable for tabular data                     | Suitable for customized repeated content             |
| Supports built-in paging and sorting features | Requires additional implementation for such features |

Example:

### GridView

```text
ID     Name      Course
101    Rahul     IT
102    Amit      CS
103    Priya     IT
```

### Repeater

```text
Rahul
Course: IT
----------------
Amit
Course: CS
----------------
Priya
Course: IT
```

---

# 11. Data-Binding Expressions

ASP.NET provides expressions for displaying data inside data-bound controls.

The most commonly used expression is:

```aspx
<%# Eval("ColumnName") %>
```

For example:

```aspx
<%# Eval("Name") %>
```

displays the value of the `Name` column.

Another example:

```aspx
<%# Eval("Course") %>
```

displays the value of the `Course` column.

---

# 11.1 Eval()

`Eval()` is commonly used for **one-way data binding**.

Example:

```aspx
<asp:Label
    ID="lblName"
    runat="server"
    Text='<%# Eval("Name") %>'>
</asp:Label>
```

If the data contains:

```text
Name
-----
Rahul
```

the Label displays:

```text
Rahul
```

---

# 11.2 Bind()

`Bind()` supports two-way data binding and can be used when data needs to be displayed and updated through a bound control.

Example:

```aspx
<asp:TextBox
    ID="txtName"
    runat="server"
    Text='<%# Bind("Name") %>'>
</asp:TextBox>
```

The basic distinction is:

| Expression | Purpose              |
| ---------- | -------------------- |
| `Eval()`   | One-way data binding |
| `Bind()`   | Two-way data binding |

---

# 12. SQLDataSource Control

`SqlDataSource` is an ASP.NET data source control used to connect ASP.NET controls directly to a SQL Server database.

It can be used to:

- Retrieve data
- Insert data
- Update data
- Delete data

The basic relationship is:

```text
SQL Server
    ↓
SqlDataSource
    ↓
GridView / Repeater
```

---

# 12.1 Basic SqlDataSource Example

```aspx
<asp:SqlDataSource
    ID="SqlDataSource1"
    runat="server"
    ConnectionString="<%$ ConnectionStrings:CollegeDB %>"
    SelectCommand="SELECT * FROM Students">
</asp:SqlDataSource>
```

The `ConnectionString` specifies the database connection.

The `SelectCommand` specifies the SQL query.

---

# 12.2 Binding SqlDataSource to GridView

A GridView can use the SqlDataSource as its data source.

```aspx
<asp:GridView
    ID="GridView1"
    runat="server"
    DataSourceID="SqlDataSource1">
</asp:GridView>
```

The complete flow becomes:

```text
SQL Server
    ↓
SqlDataSource
    ↓
GridView
    ↓
Web Page
```

In this approach, the GridView does not require explicit C# code such as:

```csharp
GridView1.DataSource = table;
GridView1.DataBind();
```

The data source control manages the connection between the database and the GridView.

---

# 13. Programmatic vs Declarative Data Binding

There are two common ways to bind data.

## Programmatic Data Binding

The data source is assigned using C# code.

```csharp
GridView1.DataSource = table;
GridView1.DataBind();
```

Flow:

```text
Database
   ↓
ADO.NET
   ↓
DataTable
   ↓
C# Code
   ↓
GridView
```

---

## Declarative Data Binding

The data source is specified in the ASP.NET markup.

```aspx
<asp:GridView
    ID="GridView1"
    runat="server"
    DataSourceID="SqlDataSource1">
</asp:GridView>
```

Flow:

```text
Database
   ↓
SqlDataSource
   ↓
GridView
```

---

# 14. Complete Data-Binding Architecture

The complete relationship between the concepts studied so far is:

```text
                       Database
                          ↓
                    ADO.NET
                          ↓
              ┌───────────┴───────────┐
              ↓                       ↓
         DataReader             DataAdapter
                                      ↓
                                  DataSet
                                      ↓
                                  DataTable
                                      ↓
                                  DataView
                                      ↓
                                Data Binding
                                      ↓
                    ┌─────────────────┴─────────────────┐
                    ↓                                   ↓
                GridView                             Repeater
                    ↓                                   ↓
             Tabular Data                    Customized Layout
```

An alternative approach is:

```text
SQL Server
    ↓
SqlDataSource
    ↓
GridView / Repeater
```

---

# 15. Complete Example Using ADO.NET

The following example retrieves student data and displays it in a GridView.

### ASPX

```aspx
<asp:GridView
    ID="GridView1"
    runat="server">
</asp:GridView>
```

### C#

```csharp
using System;
using System.Data;
using System.Data.SqlClient;

protected void Page_Load(object sender, EventArgs e)
{
    if (!IsPostBack)
    {
        string cs =
            "Server=localhost;Database=CollegeDB;Trusted_Connection=True;";

        SqlDataAdapter da =
            new SqlDataAdapter(
                "SELECT * FROM Students", cs);

        DataTable table = new DataTable();

        da.Fill(table);

        GridView1.DataSource = table;
        GridView1.DataBind();
    }
}
```

The execution flow is:

```text
Page Load
    ↓
SqlDataAdapter
    ↓
SQL Server
    ↓
DataTable
    ↓
GridView.DataSource
    ↓
DataBind()
    ↓
Student Records Displayed
```

---

# 16. Why `IsPostBack` is Used

In ASP.NET Web Forms, a page can be requested for the first time or submitted again.

The property:

```csharp
IsPostBack
```

indicates whether the page is being loaded because of a postback.

```csharp
if (!IsPostBack)
{
    // Initial data loading
}
```

This prevents unnecessary reloading of data during subsequent postbacks.

This concept becomes important later when studying the **ASP.NET Page Architecture and Page Life Cycle**.

---

# 17. Summary

Data binding connects application data with data-bound controls.

The complete sequence is:

```text
Database
   ↓
ADO.NET
   ↓
DataSet / DataTable
   ↓
Data Binding
   ↓
GridView / Repeater
   ↓
Web Page
```

`GridView` is mainly used for **tabular data**, while `Repeater` is used when a **custom repeated layout** is required.

`SqlDataSource` provides another way to connect ASP.NET controls directly to SQL Server.

## 17. DataSet, DataTable, DataColumn, DataRow, DataConstraints and DataView

In the previous topics, ADO.NET disconnected architecture was introduced. The main components of this architecture are `DataSet`, `DataTable`, `DataColumn`, `DataRow`, `DataConstraints` and `DataView`.

Their relationship is:

```text
DataSet
   │
   ├── DataTable
   │      ├── DataColumn
   │      ├── DataRow
   │      └── DataConstraints
   │
   └── DataTable
          ├── DataColumn
          ├── DataRow
          └── DataConstraints
```

A `DataView` can then provide a filtered or sorted view of a `DataTable`.

```text
DataTable
    ↓
 DataView
    ↓
Filtered / Sorted Data
```

---

# 17.1 DataSet

A **DataSet** is an in-memory representation of data that can contain one or more `DataTable` objects.

It does not represent only one database table. It can represent multiple related tables.

For example, a college database may contain:

```text
DataSet
   │
   ├── Students
   ├── Courses
   └── Departments
```

Each of these is represented as a `DataTable`.

### Creating a DataSet

```csharp
DataSet ds = new DataSet();
```

A `SqlDataAdapter` can fill the DataSet:

```csharp
SqlDataAdapter da =
    new SqlDataAdapter(
        "SELECT * FROM Students",
        connectionString);

da.Fill(ds, "Students");
```

The table can then be accessed using:

```csharp
DataTable table = ds.Tables["Students"];
```

---

# 17.2 DataTable

A **DataTable** represents a single table of data in memory.

For example:

```text
Students
--------------------------------
Id     Name       Course
--------------------------------
101    Rahul      IT
102    Amit       CS
103    Priya      IT
```

The DataTable contains:

- Columns
- Rows
- Constraints

Example:

```csharp
DataTable table = new DataTable();

SqlDataAdapter da =
    new SqlDataAdapter(
        "SELECT * FROM Students",
        connectionString);

da.Fill(table);
```

The `Fill()` method retrieves the database records and stores them in the DataTable.

---

# 17.3 DataColumn

A **DataColumn** represents a column of a `DataTable`.

For the following table:

```text
Students
--------------------------------
Id     Name       Course
```

there are three DataColumn objects:

```text
DataColumn
   ├── Id
   ├── Name
   └── Course
```

Columns can be accessed using:

```csharp
DataColumn column =
    table.Columns["Name"];
```

The collection of columns can also be accessed:

```csharp
foreach (DataColumn column in table.Columns)
{
    Console.WriteLine(column.ColumnName);
}
```

Output:

```text
Id
Name
Course
```

---

# 17.4 DataRow

A **DataRow** represents one record in a DataTable.

For example:

```text
101 | Rahul | IT
```

is one DataRow.

Multiple records form multiple DataRow objects:

```text
DataTable
    │
    ├── DataRow → 101 | Rahul | IT
    ├── DataRow → 102 | Amit  | CS
    └── DataRow → 103 | Priya | IT
```

DataRows can be accessed using the `Rows` collection:

```csharp
foreach (DataRow row in table.Rows)
{
    Console.WriteLine(row["Name"]);
}
```

Output:

```text
Rahul
Amit
Priya
```

---

# 17.5 Accessing a Particular DataRow

A specific row can be accessed using its index.

```csharp
DataRow row = table.Rows[0];
```

The first row can then be accessed:

```csharp
Console.WriteLine(row["Name"]);
```

If the first record is:

```text
101 | Rahul | IT
```

the output is:

```text
Rahul
```

---

# 17.6 Adding a DataRow

A new row can be created using:

```csharp
DataRow row = table.NewRow();
```

Values can then be assigned:

```csharp
row["Id"] = 104;
row["Name"] = "Neha";
row["Course"] = "IT";
```

The row is added to the DataTable using:

```csharp
table.Rows.Add(row);
```

The DataTable now contains:

```text
101 | Rahul | IT
102 | Amit  | CS
103 | Priya | IT
104 | Neha  | IT
```

This changes the data in the **in-memory DataTable**. It does not automatically update the database unless the appropriate update operation is performed.

---

# 17.7 Modifying a DataRow

A DataRow can be modified directly.

```csharp
DataRow row = table.Rows[0];

row["Course"] = "CS";
```

The first row changes from:

```text
101 | Rahul | IT
```

to:

```text
101 | Rahul | CS
```

Again, this modification is initially made in the in-memory DataTable.

---

# 17.8 Deleting a DataRow

A row can be deleted using:

```csharp
table.Rows[0].Delete();
```

The row is marked for deletion in the DataTable.

The database is not automatically changed simply by calling `Delete()` on the DataRow.

---

# 17.9 DataConstraints

**DataConstraints** are rules used to maintain data integrity within a DataTable.

Important constraints include:

1. `UniqueConstraint`
2. `PrimaryKey`
3. `ForeignKeyConstraint`

---

## 17.9.1 UniqueConstraint

A `UniqueConstraint` ensures that duplicate values are not allowed in a column or combination of columns.

For example, student enrollment numbers should be unique:

```text
Enrollment No.
----------------
101
102
103
```

The value `101` should not appear twice.

Example:

```csharp
UniqueConstraint constraint =
    new UniqueConstraint(table.Columns["Id"]);

table.Constraints.Add(constraint);
```

---

# 17.9.2 Primary Key

A primary key uniquely identifies each record in a table.

For example:

```text
Students
--------------------------------
Id       Name       Course
--------------------------------
101      Rahul      IT
102      Amit       CS
103      Priya      IT
```

Here, `Id` can be used as the primary key.

A primary key can be assigned using:

```csharp
table.PrimaryKey =
    new DataColumn[] { table.Columns["Id"] };
```

The primary key provides uniqueness and allows a row to be uniquely identified.

---

# 17.9.3 ForeignKeyConstraint

A `ForeignKeyConstraint` establishes a relationship between two DataTables.

For example:

```text
Departments
----------------
DeptId
1
2

Students
----------------
Id    Name    DeptId
101   Rahul   1
102   Amit    2
```

Here, `Students.DeptId` can reference `Departments.DeptId`.

This relationship can be represented as:

```text
Departments
     │
     │ DeptId
     ↓
Students
```

A foreign key helps maintain referential integrity between related tables.

---

# 17.10 DataView

A **DataView** provides a customized view of the data contained in a DataTable.

It can be used to:

- Filter records
- Sort records
- Display selected data

The original DataTable is not modified.

```text
DataTable
    │
    ↓
 DataView
   /   \
Filter  Sort
   \   /
    ↓
Selected View
```

---

# 17.11 Filtering Using DataView

Suppose the DataTable contains:

```text
Id    Name     Course
----------------------
101   Rahul    IT
102   Amit     CS
103   Priya    IT
104   Neha     CS
```

To display only IT students:

```csharp
DataView view = new DataView(table);

view.RowFilter = "Course = 'IT'";
```

The DataView displays:

```text
Id    Name     Course
----------------------
101   Rahul    IT
103   Priya    IT
```

The original DataTable remains unchanged.

---

# 17.12 Sorting Using DataView

Records can be sorted using the `Sort` property.

```csharp
DataView view = new DataView(table);

view.Sort = "Name ASC";
```

The records are displayed alphabetically by name.

For descending order:

```csharp
view.Sort = "Name DESC";
```

---

# 17.13 Filtering and Sorting Together

Both operations can be performed together:

```csharp
DataView view = new DataView(table);

view.RowFilter = "Course = 'IT'";
view.Sort = "Name ASC";
```

The result contains only IT students and sorts them by name.

---

# 17.14 DataSet vs DataTable

| DataSet                                  | DataTable                           |
| ---------------------------------------- | ----------------------------------- |
| Can contain multiple tables              | Represents one table                |
| Can contain relationships between tables | Represents a single table           |
| Contains DataTables                      | Contains DataRows and DataColumns   |
| Suitable for multiple related tables     | Suitable when one table is required |
| Accessed through `Tables` collection     | Accessed directly                   |

Example:

```text
DataSet
   │
   ├── Students
   ├── Courses
   └── Departments
```

while:

```text
DataTable
   ├── Columns
   └── Rows
```

---

# 17.15 DataRow vs DataColumn

| DataRow               | DataColumn               |
| --------------------- | ------------------------ |
| Represents a record   | Represents a column      |
| Contains values       | Defines a field          |
| Accessed using `Rows` | Accessed using `Columns` |
| Example: Rahul, IT    | Example: Name, Course    |

For:

```text
Id    Name    Course
101   Rahul   IT
```

`Id`, `Name` and `Course` are **DataColumns**.

```text
101 | Rahul | IT
```

is a **DataRow**.

---

# 17.16 Complete DataSet Structure

Consider a college database represented in memory:

```text
                         DataSet
                            │
             ┌──────────────┴──────────────┐
             ↓                             ↓
        DataTable                      DataTable
        Students                       Courses
             │                             │
       ┌─────┴─────┐                 ┌─────┴─────┐
       ↓           ↓                 ↓           ↓
   DataColumn   DataRow          DataColumn   DataRow
```

A DataSet can therefore represent an entire group of related data in memory.

---

# 17.17 Complete Disconnected Architecture

The complete process can now be understood:

```text
                         SQL Server
                             ↓
                       SqlDataAdapter
                             ↓
                          DataSet
                             ↓
                        DataTable
                       /    |     \
                      ↓     ↓      ↓
                DataColumn DataRow Constraints
                             ↓
                         DataView
                             ↓
                       Data Binding
                             ↓
                    GridView / Repeater
```

This is the complete flow from the database to the user interface.

---

# 17.18 Example: Retrieve and Display Filtered Data

Suppose the database contains student records.

```csharp
string connectionString =
    "Server=localhost;Database=CollegeDB;Trusted_Connection=True;";

DataTable table = new DataTable();

SqlDataAdapter da =
    new SqlDataAdapter(
        "SELECT * FROM Students",
        connectionString);

da.Fill(table);
```

A DataView can then filter the records:

```csharp
DataView view = new DataView(table);

view.RowFilter = "Course = 'IT'";
view.Sort = "Name ASC";
```

The filtered view can be displayed using a GridView:

```csharp
GridView1.DataSource = view;
GridView1.DataBind();
```

The complete sequence is:

```text
SQL Server
    ↓
SqlDataAdapter
    ↓
DataTable
    ↓
DataView
    ↓
Filter + Sort
    ↓
GridView
```

---

# 18. Important ADO.NET Classes at a Glance

| Class                  | Purpose                                    |
| ---------------------- | ------------------------------------------ |
| `SqlConnection`        | Connects application to SQL Server         |
| `SqlCommand`           | Executes SQL commands                      |
| `SqlDataReader`        | Reads data in connected mode               |
| `SqlDataAdapter`       | Transfers data between database and memory |
| `DataSet`              | Stores multiple tables in memory           |
| `DataTable`            | Stores one table in memory                 |
| `DataColumn`           | Represents a column                        |
| `DataRow`              | Represents a record                        |
| `UniqueConstraint`     | Prevents duplicate values                  |
| `ForeignKeyConstraint` | Maintains relationship between tables      |
| `DataView`             | Provides filtered and sorted view          |

---

# 19. Connection Between ADO.NET and ASP.NET

ADO.NET provides the **data access layer**, while ASP.NET provides the **web application layer**.

```text
                    ASP.NET Application
                           │
                           ↓
                     User Interface
                           │
                           ↓
                     C# / Code-behind
                           │
                           ↓
                         ADO.NET
                           │
                           ↓
                       SQL Server
```

For example:

```text
User
 ↓
ASP.NET Web Page
 ↓
GridView
 ↓
DataTable
 ↓
SqlDataAdapter
 ↓
SQL Server
```

This connection is important because the next major part of the syllabus focuses on **ASP.NET Web Applications and controls**.

---

# 20. Summary

The disconnected architecture allows database data to be stored and manipulated in memory.

The main structure is:

```text
DataSet
   ↓
DataTable
   ├── DataColumn
   ├── DataRow
   └── DataConstraints
          ↓
       DataView
```

The complete database-to-web flow is:

```text
SQL Server
    ↓
ADO.NET
    ↓
DataSet / DataTable
    ↓
DataView
    ↓
Data Binding
    ↓
GridView / Repeater
    ↓
ASP.NET Web Page
```
