
using System;
using Microsoft.Data.Sqlite;

namespace CRUD_Application
{
    class Program
    {
        static string connectionString = "Data Source=college.db";

        static void Main(string[] args)
        {
            InitializeDatabase();

            while (true)
            {
                Console.WriteLine("\n--- STUDENT CRUD SYSTEM (SQLite) ---");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View All");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Exit");
                Console.Write("Select option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": InsertStudent(); break;
                    case "2": ReadStudents(); break;
                    case "3": UpdateStudent(); break;
                    case "4": DeleteStudent(); break;
                    case "5": return;
                    default: Console.WriteLine("Invalid choice!"); break;
                }
            }
        }

        static void InitializeDatabase()
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string tableCmd = @"CREATE TABLE IF NOT EXISTS Students (
                                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    Name TEXT,
                                    Email TEXT)";
                SqliteCommand cmd = new SqliteCommand(tableCmd, conn);
                cmd.ExecuteNonQuery();
            }
        }

        // 1. CREATE
        static void InsertStudent()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {

                string query = "INSERT INTO Students (Name, Email) VALUES (@n, @e)";
                SqliteCommand cmd = new SqliteCommand(query, conn);

                cmd.Parameters.AddWithValue("@n", name);
                cmd.Parameters.AddWithValue("@e", email);

                conn.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Student Added Successfully!");
            }
        }

        // 2. READ
        static void ReadStudents()
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                string query = "SELECT * FROM Students";
                SqliteCommand cmd = new SqliteCommand(query, conn);

                conn.Open();
                SqliteDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("\nID | NAME | EMAIL");
                Console.WriteLine("-------------------");
                while (reader.Read())
                {

                    Console.WriteLine($"{reader["Id"]} | {reader["Name"]} | {reader["Email"]}");
                }
            }
        }

        // 3. UPDATE
        static void UpdateStudent()
        {
            Console.Write("Enter ID to Update: ");
            string input = Console.ReadLine();

            Console.Write("Enter New Name: ");
            string newName = Console.ReadLine();

            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                string query = "UPDATE Students SET Name = @n WHERE Id = @id";
                SqliteCommand cmd = new SqliteCommand(query, conn);

                cmd.Parameters.AddWithValue("@n", newName);
                cmd.Parameters.AddWithValue("@id", input);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0) Console.WriteLine("Student Updated!");
                else Console.WriteLine("Student ID not found.");
            }
        }

        // 4. DELETE
        static void DeleteStudent()
        {
            Console.Write("Enter ID to Delete: ");
            string input = Console.ReadLine();

            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                string query = "DELETE FROM Students WHERE Id = @id";
                SqliteCommand cmd = new SqliteCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", input);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0) Console.WriteLine("Student Deleted!");
                else Console.WriteLine("Student ID not found.");
            }
        }
    }
}
