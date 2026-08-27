// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, Pravin!");

using System;

namespace MyApp
{
  internal class Program
  {
    static void Main(string[] args)
    {
      // Student s1 = new Student();
      // s1.Marks = 95;
      // s1.Rollno = 101;
      // Console.WriteLine("Marks: " + s1.Marks);
      // Console.WriteLine("Roll no: " + s1.Rollno);

      // Payment payment = new UPI();
      // payment.Pay();

      // Animal animal = new Dog();
      // animal.Sound();
    }

  }
}

abstract class Payment
{
  public abstract void Pay();
}

class UPI : Payment
{
    public override void Pay()
    {
        Console.WriteLine("Payment through UPI");
    }
}

class Student
{
  private int marks;
  private int rollno;

  public int Rollno
  {
    get
    {
      return rollno;
    }
    set
    {
      if (value < 0)
      {
        Console.WriteLine("Roll number cannot be negative.");
      }
      else
        rollno = value;
    }
  }

  public int Marks { get; set; }
}

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
