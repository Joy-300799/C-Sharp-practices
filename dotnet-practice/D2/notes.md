# C# Types Revisited
https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/types

Objects are of 2 types:
> ValueType
> ReferenceType

https://learn.microsoft.com/en-us/dotnet/api/system.valuetype?view=net-8.0
Value types are either stack-allocated or allocated inline in a structure. Reference types are heap-allocated.

# Class
# Class and inheritance, constructor chaining
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

# : Person -> extends Person
# : base(name) -> super(name)

# No multiple inheritance just like in Java

# Interfaces
# We use an "I" prefix for Interfaces
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

# : IHello -> implements

# Class implementing multiple interfaces but with different methods/method signatures

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

# Same method signature in both interfaces
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

# If we want different implementations
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

# Arrays are basically part of Collections hierarchy
https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/arrays#1723-arrays-and-the-generic-collection-interfaces

public class Program
{
  public static void Main()
  {
    int[] nums = new int[5]
    {
      1, 2, 3, 4, 5
    };
    IList<int> numsList = nums;
    numsList[0] = 10;
    Console.WriteLine(numsList[0]);
    numsList.Add(10);
  }
}

# The last line will give us this exception
# Unhandled exception. System.NotSupportedException: Collection was of a fixed size.

# First class functions
# Functional Interfaces in Java
https://www.baeldung.com/java-8-functional-interfaces

# Delegates are like function pointers

# Assigning functions to variables
public delegate int Add(int x, int y);

public class Program
{
  private static int Sum(int x, int y)
  {
    return x + y;
  }
  public static void Main()
  {
    Add add = Sum;
    Console.WriteLine(add(2, 3));
  }
}

# We assign the "function" Sum to add
# The type of "add" must be a delegate
# The delegate's signature must match the function's signature assigned to it

# Passing functions to functions
public class Calculator
{
  public int Add(int x, int y)
  {
    return x + y;
  }

  public int Subtract(int x, int y)
  {
    return x - y;
  }
}

public delegate int Operation(int x, int y);
public class Program
{
  public static void ExecuteOperation(int x, int y, Operation op)
  {
    Console.WriteLine(op(x, y));
  }

  public static void Main()
  {
    var c = new Calculator();
    ExecuteOperation(2, 3, c.Add);
    ExecuteOperation(2, 3, c.Subtract);
  }
}

# Returning functions from functions
# When returning a function from a function, the return type is the delegate type
public delegate void Bar();

public class Program
{
  public static Bar Foo()
  {
    void BarImpl()
    {
      Console.WriteLine("Bar");
    }
    return BarImpl;
  }
  public static void Main()
  {
    var x = Foo();
    x();
  }
}

# This is also perfectly valid
public static void Main()
{
  Foo()();
}

# Lambda functions
# Assigning functions to variables
public delegate int Add(int x, int y);

public class Program
{
  public static void Main()
  {
    Add add = (int x, int y) => x + y;
    Console.WriteLine(add(2, 3));
  }
}

# Lambda functions can be multiple lines (in which case, put the lines in {})
public delegate int Add(int x, int y);

public class Program
{
  public static void Main()
  {
    Add add = (int x, int y) => 
    {
      var tmp = x + y;
      return tmp;
    };
    Console.WriteLine(add(2, 3));
  }
}

# Passing functions to functions
public delegate int Operation(int x, int y);

public class Program
{
  public static void ExecuteOperation(int a, int b, Operation op)
  {
    var result = op(a, b);
    Console.WriteLine("Result: " + result);
  }
  public static void Main()
  {
    ExecuteOperation(1, 2, (int x, int y) => x + y);
    ExecuteOperation(10, 20, (int x, int y) => x * y);
  }
}

# Returning functions from functions
public delegate void Bar();

public class Program
{
  public static Bar Foo()
  {
    return () =>
    {
      Console.WriteLine("Bar");
    };
  }
  public static void Main()
  {
    Foo()();
  }
}

# Event Handlers with "event" - an implementation of the observer pattern
public class Button // An object
{
  public event EventHandler OnClick;

  public void Click() // Events that occur on this object
  {
    OnClick?.Invoke(this, EventArgs.Empty);
  }
}

public class UserInterface
{
  public static void Main()
  {
    Button button = new Button();
    button.OnClick += EventHandler1;    // When the event occurs, do this
    button.OnClick += EventHandler2;
    button.Click();
  }

  private static void EventHandler1(object sender, EventArgs e)
  {
    Console.WriteLine("Running event handler 1!");
  }

  private static void EventHandler2(object sender, EventArgs e)
  {
    Console.WriteLine("Running event handler 2!");
  }
}

# Data and Data Transforms
cat > people <<DELIM
Ramesh,Hyderabad
Ganesh,Mumbai
Jyothi,Bangalore
Harish,Mumbai
DELIM
# Get me the names of the people from Mumbai
cat people | grep Mumbai | awk -F, '{print $1}'
# Get me the count of the people from Mumbai
cat people | grep Mumbai | wc -l
# Get me the count of the people from each city in descending order of count
cat people | awk -F, '{print $2}' | sort | uniq -c | sort -nr

# An implementation of Map using delegates
public delegate int Func(int x);
public class Program
{
  public static IList<int> MyMap(IList<int> inputList, Func func)
  {
    IList<int> outputList = new List<int>();
    foreach (var num in inputList)
    {
      outputList.Add(func(num));
    }
    return outputList;
  }

  public static void Main()
  {
    var nums = new List<int> { 1, 2, 3, 4, 5 };
    foreach (var num in MyMap(nums, x => x * x))
    {
      Console.WriteLine(num);
    }
    foreach (var num in MyMap(nums, x => x * x * x))
    {
      Console.WriteLine(num);
    }
  }
}

# Using LINQ
public class Program
{
  public static void Main()
  {
    var nums = new List<int> { 1, 2, 3, 4, 5 };
    foreach (var num in nums.Select(num => num * num))
    {
      Console.WriteLine(num);
    }
    foreach (var num in nums.Select(num => num * num * num))
    {
      Console.WriteLine(num);
    }
  }
}

# Better syntax with from/select
public class Program
{
  public static void Main()
  {
    var nums = new List<int> { 1, 2, 3, 4, 5 };
    foreach (var num in from num in nums select num * num)
    {
      Console.WriteLine(num);
    }
    foreach (var num in from num in nums select num * num * num)
    {
      Console.WriteLine(num);
    }
  }
}

# Real life application
# Given a list of contacts, print their names
public class Contact
{
  public string Name { get; set; }
  public string Location { get; set; }
}
public class Program
{
  public static void Main()
  {
    var contacts = new List<Contact>
    {
      new Contact { Name = "John", Location = "New York"},
      new Contact { Name = "George", Location = "London"},
      new Contact { Name = "Bob", Location = "San Francisco"},
    };
    foreach (var name in from contact in contacts select contact.Name)
    {
      Console.WriteLine(name);
    }
  }
}

# Given a list of contacts, print the names of the people from New York
public class Contact
{
  public string Name { get; set; }
  public string Location { get; set; }
}
public class Program
{
  public static void Main()
  {
    var contacts = new List<Contact>
    {
      new Contact { Name = "John", Location = "New York"},
      new Contact { Name = "George", Location = "London"},
      new Contact { Name = "Bob", Location = "San Francisco"},
    };
    foreach (var name in from contact in contacts where contact.Location == "New York" select contact.Name)
    {
      Console.WriteLine(name);
    }
  }
}

# Activity
# Build your own "MyFilter" function that takes a list of numbers and a function and filters based on it
# Use of filter - given a list of numbers, get me only the odd numbers
# Odd number function num => num % 2 == 1
