// Class
// Class and inheritance, constructor chaining
using System;

public class Person
{
    public string Name { get; set; }
    public Person(string name)
    {
        Console.WriteLine("In the Person constructor");
        Name = name;
    }
}

public class Employee : Person
{
    public Employee(string name) : base(name)
    {
        Console.WriteLine("The rest of the Employee constructor");
    }
}

public class Program
{
    public static void Main()
    {
        var e = new Employee("John");
    }
}

// : Person -> extends Person
// : base(name) -> super(name)

// No multiple inheritance just like in Java

// Interfaces
// We use an "I" prefix for Interfaces
interface IHello
{
    void SayHello();
}

public class Hello : IHello
{
    public void SayHello()
    {
        Console.WriteLine("Hello");
    }
}

public class Program
{
    public static void Main()
    {
        var h = new Hello();
        h.SayHello();
    }
}

// : IHello -> implements
// Class implementing multiple interfaces but with different methods/method signatures

interface IHello
{
    void SayHello();
}

interface IHello2
{
    void SayHello(string name);
}

public class Hello : IHello, IHello2
{
    public void SayHello()
    {
        Console.WriteLine("Hello");
    }

    public void SayHello(string name)
    {
        Console.WriteLine($"Hello {name}");
    }
}

public class Program
{
    public static void Main()
    {
        var h = new Hello();
        h.SayHello();
        h.SayHello("John");
    }
}

// Same method signature in both interfaces
interface IHello
{
    void SayHello();
}

interface IHello2
{
    void SayHello();
}

public class Hello : IHello, IHello2
{
    public void SayHello()
    {
        Console.WriteLine("Hello");
    }
}

public class Program
{
    public static void Main()
    {
        var h = new Hello();
        h.SayHello();
    }
}

// If we want different implementations
interface IHello
{
    void SayHello();
}

interface IHello2
{
    void SayHello();
}

public class Hello : IHello, IHello2
{
    void IHello.SayHello()
    {
        Console.WriteLine("IHello's Hello");
    }

    void IHello2.SayHello()
    {
        Console.WriteLine("IHello2's Hello");
    }
}

public class Program
{
    public static void Main()
    {
        var h = new Hello();
        ((IHello)h).SayHello();
        ((IHello2)h).SayHello();
    }
}
