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
