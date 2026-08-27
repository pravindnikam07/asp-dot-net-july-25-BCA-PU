// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;

namespace oopdemo
{
  class Program
  {
    static void Main(string[] args)
    {
      // student
      // string name = "John";
      // int roll = 2;
      // double marks = 90.4;

      // Console.WriteLine("Name: " + name);
      // Console.WriteLine("Roll: " + roll);
      // Console.WriteLine("Marks: " + marks);

      // string name1 = "Joseph";
      // int roll1 = 5;
      // string mobile = "9876543210";
      // double marks1 = 95.4;

      // Console.WriteLine("Name: " + name1);
      // Console.WriteLine("Roll: " + roll1);
      // Console.WriteLine("Marks: " + marks1);


      // Student s1 = new Student();
      // s1.name = "Ravi";
      // s1.roll = 2;
      // s1.marks = 90.4;
      // s1.printDetails();

      // Student s1 = new Student("Abhay", 2, 90.8);
      // s1.printDetails();

      // Student s2 = new Student("Ravi", 3, 96.8);
      // s2.printDetails();


      Animal dog = new Dog();
      dog.sound();
      dog.eat();

    }
  }
}

public abstract class Animal
{

  // concrete method => Is having body/ with implemenation
  public virtual void sound()
  {
    Console.WriteLine("Animal makes sound.");
  }
  // abstract method => is does not have body / without implementation
  public abstract void eat();
}

public class Dog : Animal
{

  public override void sound()
  {
    Console.WriteLine("Dog barks.");
  }

  public override void eat()
  {
    Console.WriteLine("Dog eats meat.");
  }
}


class Student
{
  public string name;
  public int roll;
  public double marks;

  public Student(string name, int roll, double marks)
  {
    this.name = name;
    this.roll = roll;
    this.marks = marks;
  }

  public void printDetails()
  {
    Console.WriteLine("Name: " + name);
    Console.WriteLine("Roll: " + roll);
    Console.WriteLine("Marks: " + marks);
  }
}




