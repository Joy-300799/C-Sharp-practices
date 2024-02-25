# Course Outline
https://jnaapti.com/downloads/csharp-dotnet-for-java-developers.pdf

# Download
https://dotnet.microsoft.com/en-us/download
https://learn.microsoft.com/en-gb/dotnet/core/install/linux-ubuntu

.NET SDK and .NET Runtime

https://learn.microsoft.com/en-gb/dotnet/core/install/linux-ubuntu-2204

# Installing VS Code Extensions
ms-dotnettools.csharp
ms-dotnettools.csdevkit
ms-dotnettools.vscode-dotnet-runtime

# Try C# Online
https://try.dot.net/

# Verification
# From a terminal/command prompt, type
dotnet
dotnet --list-sdks

# A Hello World tutorial
https://dotnet.microsoft.com/en-us/learn/dotnet/hello-world-tutorial/install
https://dotnet.microsoft.com/en-us/learn/dotnet/hello-world-tutorial/create

# Creating a project from the command line
# Open the Terminal in VS Code
dotnet new list

# Create a new console app from the terminal
dotnet new console -o HelloWorld

# Top Level Statements
https://learn.microsoft.com/en-us/dotnet/csharp/tutorials/top-level-statements

# To run the application
cd HelloWorld
dotnet run

# Program class with Main method
public class Program
{
  public static void Main(string[] args)
  {
    Console.WriteLine("Hello, World!");
  }
}

# Run
dotnet run

# Basic data types (Simple Types)
https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/types#835-simple-types

# int is System.Int32
int i = 10;
int j = 20;
Console.WriteLine(i + j);

Console.WriteLine(typeof(int));

bool IsPresent = true;
Console.WriteLine(IsPresent);

# string is System.String
string Name = "John";
Console.WriteLine(typeof(string));
Console.WriteLine(Name);

# var is a convenience to declare a variable (but these are statically typed)
var i = 10;
i = "Hello"; // Compile time error
Console.WriteLine(i);

# There is a dynamic type
dynamic i = 10;
Console.WriteLine(i);
i = "Hello";
Console.WriteLine(i);

# Another example
var map = new Dictionary<string, List<string>>();

# String interpolation
int Age = 10;
string Name = "John";
Console.WriteLine($"{Name}'s age is {Age}");

# Verbatim strings
string s = @"Hello\nWorld";
Console.WriteLine(s);

# System.Collections.Generic namespace
https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic?view=net-8.0

# Lists
// Creation
IList<int> nums = new List<int>();

// Addition (append)
nums.Add(10);
nums.Add(20);
nums.Add(30);

// Get (based on position)
Console.WriteLine(nums[0]);

// Update
nums[0] = 15;

Console.WriteLine(nums[0]);

nums.Remove(15);

Console.WriteLine("nums after remove");
foreach(var num in nums)
{
  Console.WriteLine(num);
}

# Initialization is easy
// Initialization
IList<int> nums = new List<int>()
{
  1, 2, 3
};

foreach(var num in nums)
{
  Console.WriteLine(num);
}

# A full example
public class Contact
{
  private string _name;

  public Contact(string Name)
  {
    _name = Name;
  }

  public override string ToString()
  {
    return $"Contact({_name})";
  }
}

public class Program
{
  public static void Main(string[] args)
  {
    IList<Contact> contacts = new List<Contact>()
    {
      new Contact("John"),
      new Contact("George"),
      new Contact("Alice"),
    };

    foreach (var contact in contacts)
    {
      Console.WriteLine(contact);
    }
  }
}

# Dictionary

// Create/Initialize
var countrywiseParticipants = new Dictionary<string, int>()
{
  { "India", 10},
  { "US", 20},
  { "UK", 30},
};
// Key existence
Console.WriteLine($"Is India present: {countrywiseParticipants.ContainsKey("India")}");
Console.WriteLine($"Participant count from India: {countrywiseParticipants["India"]}");
// Update
countrywiseParticipants["India"] = 15;
// Remove
countrywiseParticipants.Remove("UK");
// Iterate
foreach (var cp in countrywiseParticipants)
{
  Console.WriteLine($"{cp.Key}: {cp.Value}");
}

# HashSet

// Create/Initialize
var nums = new HashSet<int>();
// Addition
nums.Add(10);
nums.Add(10);
nums.Add(20);
nums.Add(30);
// Key existence
Console.WriteLine($"Is 10 present: {nums.Contains(10)}");
// Remove
nums.Remove(10);
// Iterate
foreach (var num in nums)
{
  Console.WriteLine(num);
}

# Fixed size arrays
var nums = new[]
{
  1,
  2,
  3
};

Console.WriteLine(nums[0]);

foreach(var num in nums)
{
  Console.WriteLine(num);
}

# Getters/Setters (the Java way)
public class Contact
{
  private string name;

  public string GetName()
  {
    return name;
  }

  public void SetName(string Name)
  {
    name = Name;
  }
}

public class Program
{
  public static void Main(string[] args)
  {
    var c = new Contact();
    c.SetName("John");
    Console.WriteLine(c.GetName());
  }
}

# The C# way
public class Contact
{
  private string name;

  public string Name
  {
    get { return name; }  // Public getter
    set { name = value; } // Public setter
  }
}

public class Program
{
  public static void Main(string[] args)
  {
    var c = new Contact();
    c.Name = "John";  // Use of the setter
    Console.WriteLine(c.Name);  // Use of the getter
  }
}

# Remove the "set" and now it becomes read only (only get, no set)
# This will throw an error
public class Contact
{
  private string name;

  public string Name
  {
    get { return name; }  // Public getter
  }
}

public class Program
{
  public static void Main(string[] args)
  {
    var c = new Contact();
    c.Name = "John";  // Use of the setter
    Console.WriteLine(c.Name);  // Use of the getter
  }
}

# Allowing the setting of fields during construction and only get later
public class Contact
{
  private string name;

  public Contact(string Name)
  {
    name = Name;
  }

  public string Name
  {
    get { return name; }  // Public getter
  }
}

public class Program
{
  public static void Main(string[] args)
  {
    var c = new Contact("John");
    Console.WriteLine(c.Name);  // Use of the getter
  }
}

# Automatic property
public class Contact
{
  public string Name
  {
    get; 
  }

  public Contact(string Name)
  {
    this.Name = Name;
  }
}

public class Program
{
  public static void Main(string[] args)
  {
    var c = new Contact("John");
    // c.Name = "John Doe"; // This is not allowed
    Console.WriteLine(c.Name);  // Use of the getter
  }
}

# Both getter/setter with automatic property
public class Contact
{
  public string Name { get; set; }

  public Contact(string Name)
  {
    this.Name = Name;
  }
}

public class Program
{
  public static void Main(string[] args)
  {
    var c = new Contact("John");
    c.Name = "John Doe";
    Console.WriteLine(c.Name);
  }
}

# Web project
dotnet new web -o HelloWorldWeb
cd HelloWorldWeb
dotnet run
# Observe where it is running the HTTP Server
curl http://localhost:<port>/

# Kill the server
^C

# Activity
1. FizzBuzz program
2. Duplicate Number - Given a list of numbers, print the numbers that occur more than once

# C# Types Revisited
https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/types

Objects are of 2 types:
> ValueType
> ReferenceType

# Reference Types
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

# Activity
# Build your own "MyFilter" function that takes a list of numbers and a function and filters based on it
# Use of filter - given a list of numbers, get me only the odd numbers
# Odd number function num => num % 2 == 1

# Given a list of numbers that are currently string types, convert them to int
var numsAsStrings = new List<string>
{
  "1", "2", "3"
};
foreach (var num in numsAsStrings.Select(Int32.Parse))
{
  Console.WriteLine(num);
}

# Given a list of names, generate emails for them
var usernames = new List<string>
{
  "bobby", "aanchal", "arti"
};

foreach (var num in usernames.Select(name => name + "@example.com"))
{
  Console.WriteLine(num);
}

# Filter
var nums = new List<int> {1, 2, 3, 4, 5};

foreach (var num in nums.Where(num => num % 2 == 1))
{
  Console.WriteLine(num);
}

OR

var nums = new List<int> {1, 2, 3, 4, 5};

foreach (var num in from num in nums where num % 2 == 1 select num)
{
  Console.WriteLine(num);
}

# Given a list of contacts, get me the contacts from New York
public class Contact
{
  public string Name { get; set; }
  public string Location { get; set; }

  public override string ToString()
  {
    return $"Contact({Name}, {Location})";
  }
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
    var contactsFromNY = contacts.Where(contact => contact.Location == "New York");
    foreach (var contact in contactsFromNY)
    {
      Console.WriteLine(contact);
    }
  }
}

# Using filters and maps in sequence
var nums = new List<int> {1, 2, 3, 4, 5};

var squares = nums
  .Where(num => num % 2 == 1)
  .Select(num => num * num);

foreach (var num in squares)
{
  Console.WriteLine(num);
}

OR

var nums = new List<int> { 1, 2, 3, 4, 5 };

var squares = from num in nums
              where num % 2 == 1
              select num * num;

foreach (var num in squares)
{
  Console.WriteLine(num);
}

# Given a list of contacts, get me the names of the people from New York
public class Contact
{
  public string Name { get; set; }
  public string Location { get; set; }

  public override string ToString()
  {
    return $"Contact({Name}, {Location})";
  }
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
    var contactNamesFromNY = contacts
                          .Where(contact => contact.Location == "New York")
                          .Select(contact => contact.Name);
    foreach (var name in contactNamesFromNY)
    {
      Console.WriteLine(name);
    }
  }
}

OR

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

# Clauses can repeat
# Get the me squares of the numbers that are divisible by 2 and 3
var nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
var squares = from num in nums
              where num % 2 == 0
              where num % 3 == 0
              select num * num;
foreach (var s in squares)
{
  Console.WriteLine(s);
}

# Join
# Given a list of contacts and a list of cities with countries, get me the contact names and their cities
public class Contact
{
  public string? Name { get; set; }
  public string? City { get; set; }
}

public class Country
{
  public string? City { get; set; }
  public string? CountryName { get; set; }
}

public class ContactWithCountry
{
  public string? ContactName { get; set; }
  public string? Country { get; set; }

  public override string ToString()
  {
    return $"Contact: {ContactName}, Country: {Country}";
  }
}

public class Program
{
  public static void Main()
  {
    List<Contact> contacts = new List<Contact>
        {
            new Contact { Name = "Alice", City = "New York" },
            new Contact { Name = "Bob", City = "Paris" },
            new Contact { Name = "Charlie", City = "London" }
        };

    List<Country> countries = new List<Country>
        {
            new Country { City = "New York", CountryName = "USA" },
            new Country { City = "Paris", CountryName = "France" },
            new Country { City = "London", CountryName = "UK" }
        };

    var contactsWithCountries = from contact in contacts
                                join country in countries on contact.City equals country.City
                                select new ContactWithCountry
                                {
                                  ContactName = contact.Name,
                                  Country = country.CountryName
                                };
    foreach (var c in contactsWithCountries)
    {
      Console.WriteLine(c);
    }
  }
}

# Anonymous Type
public class Contact
{
  public string? Name { get; set; }
  public string? City { get; set; }
}

public class Country
{
  public string? City { get; set; }
  public string? CountryName { get; set; }
}

public class Program
{
  public static void Main()
  {
    List<Contact> contacts = new List<Contact>
        {
            new Contact { Name = "Alice", City = "New York" },
            new Contact { Name = "Bob", City = "Paris" },
            new Contact { Name = "Charlie", City = "London" }
        };

    List<Country> countries = new List<Country>
        {
            new Country { City = "New York", CountryName = "USA" },
            new Country { City = "Paris", CountryName = "France" },
            new Country { City = "London", CountryName = "UK" }
        };

    var contactsWithCountries = from contact in contacts
                                join country in countries on contact.City equals country.City
                                select new // Anonymous type
                                {
                                  ContactName = contact.Name,
                                  Country = country.CountryName
                                };
    foreach (var c in contactsWithCountries)
    {
      Console.WriteLine($"{c.ContactName} from {c.Country}");
    }
  }
}

# Value Types
https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/types#83-value-types
https://learn.microsoft.com/en-us/dotnet/api/system.valuetype?view=net-8.0
Value types are either stack-allocated or allocated inline in a structure. Reference types are heap-allocated.

# Numeric types and Booleans are "struct" types

# Structs
# Let us start with a class
class Contact
{
  public string? Name { get; set; }
}

public class Program
{
  public static void Main()
  {
    Contact c = new Contact { Name = "John" };
    Console.WriteLine($"{c.Name}");
  }
}

# The Contact object that c refers to is in heap

# Change the keyword class to struct
struct Contact
{
  public string? Name { get; set; }
}

public class Program
{
  public static void Main()
  {
    Contact c = new Contact { Name = "John" };
    Console.WriteLine($"{c.Name}");
  }
}

https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/structs
Structs are similar to classes in that they represent data structures that can contain data members and function members. However, unlike classes, structs are value types and do not require heap allocation. A variable of a struct type directly contains the data of the struct, whereas a variable of a class type contains a reference to the data, the latter known as an object.

# Structs can also have methods like classes
struct Contact
{
  public string? Name { get; set; }

  public void PrintName()
  {
    Console.WriteLine(Name);
  }
}

public class Program
{
  public static void Main()
  {
    Contact c = new Contact { Name = "John" };
    c.PrintName();
  }
}

# Reference equality v/s Value equality
class Contact
{
  public string? Name { get; set; }
}

public class Program
{
  public static void Main()
  {
    Contact c1 = new Contact { Name = "John" };
    Contact c2 = new Contact { Name = "John" };
    Console.WriteLine(c1 == c2);
  }
}

# Compare the above to
class Contact
{
  public string? Name { get; set; }
}

public class Program
{
  public static void Main()
  {
    Contact c1 = new Contact { Name = "John" };
    Contact c2 = c1;
    Console.WriteLine(c1 == c2);
  }
}

# .Equals is typically used for value equality
# The default .Equals is ==, but we can override it
class Contact
{
  public string? Name { get; set; }
}

public class Program
{
  public static void Main()
  {
    Contact c1 = new Contact { Name = "John" };
    Contact c2 = new Contact { Name = "John" };
    Console.WriteLine(c1.Equals(c2));
  }
}

# But we can override it
class Contact
{
  public string? Name { get; set; }

  public override bool Equals(object? obj)
  {
    if (obj is Contact)
    {
      return Name == ((Contact)obj).Name;
    }
    return this == obj;
  }
}

public class Program
{
  public static void Main()
  {
    Contact c1 = new Contact { Name = "John" };
    Contact c2 = new Contact { Name = "John" };
    Console.WriteLine(c1.Equals(c2));
  }
}

# Hashcodes and the concept of equality
# Hashcodes of class instances
class Contact
{
  public string? Name { get; set; }
}

public class Program
{
  public static void Main()
  {
    Contact c1 = new Contact { Name = "John" };
    Contact c2 = new Contact { Name = "John" };
    Contact c3 = c1; // Copy by reference
    Console.WriteLine($"Hashcode of c1: {c1.GetHashCode()}");
    Console.WriteLine($"Hashcode of c2: {c2.GetHashCode()}");
    Console.WriteLine($"Hashcode of c3: {c3.GetHashCode()}");
    c2.Name = "John Doe";
    Console.WriteLine($"Hashcode of c2 after name change: {c2.GetHashCode()}");
  }
}

# Hashcode of c2 is different from c1 and remains constant even after name change

# Hashcodes of struct instances
struct Contact
{
  public string? Name { get; set; }
}

public class Program
{
  public static void Main()
  {
    Contact c1 = new Contact { Name = "John" };
    Contact c2 = new Contact { Name = "John" };
    Contact c3 = c1; // Copy by value
    Console.WriteLine($"Hashcode of c1: {c1.GetHashCode()}");
    Console.WriteLine($"Hashcode of c2: {c2.GetHashCode()}");
    Console.WriteLine($"Hashcode of c3: {c3.GetHashCode()}");
    c2.Name = "John Doe";
    Console.WriteLine($"Hashcode of c2 after name change: {c2.GetHashCode()}");
  }
}

# Hashcodes clash if the fields have same values
# Hashcode of c2 is same as c1 initially (because the fields match) but changes after name change

# Read-only fields in structs
struct Contact
{
  public readonly string? Name { get; }

  public Contact(string name)
  {
    Name = name;
  }

  public void PrintName()
  {
    Console.WriteLine(Name);
  }
}

public class Program
{
  public static void Main()
  {
    // Contact c1 = new Contact { Name = "John" };
    // c1.Name = "John";
    Contact c2 = new Contact("John");
    c2.PrintName();
  }
}

# We can mix readonly and non-readonly fields
struct Contact
{
  public readonly string? Name { get; }
  public string? Location { get; set;}

  public Contact(string name)
  {
    Name = name;
  }

  public void PrintName()
  {
    Console.WriteLine(Name);
  }
}

# The entire structure can be readonly in which case all fields are readonly
readonly struct Contact
{
  public readonly string? Name { get; }
  public readonly string? Location { get; }

  public Contact(string name)
  {
    Name = name;
  }

  public void PrintName()
  {
    Console.WriteLine(Name);
  }
}

public class Program
{
  public static void Main()
  {
    // Contact c1 = new Contact { Name = "John" };
    // c1.Name = "John";
    Contact c2 = new Contact("John");
    c2.PrintName();
  }
}

# Our primitive numeric data types like numbers are readonly structs
https://learn.microsoft.com/en-us/dotnet/api/system.int32?view=net-8.0
public readonly struct Int32
Object -> ValueType -> Int32

# Enums
enum Color
{
  Red,
  Green,
  Blue
}

public class Program
{
  public static void Main()
  {
    Color color = Color.Blue;
    Console.WriteLine(color);
    Console.WriteLine((int)color);
  }
}

# In the above example, Color.Blue has value 2.
# It's almost like setting int color = 2

# Records are reference types but with value equality
record Contact
{
  public string? Name { get; set; }
}

public class Program
{
  public static void Main()
  {
    Contact c = new Contact { Name = "John" };
    Console.WriteLine(c.Name);
  }
}

# The difference from structs is that structures cannot use ==
struct Contact
{
  public string? Name { get; set; }
}

public class Program
{
  public static void Main()
  {
    Contact c1 = new Contact { Name = "John" };
    Contact c2 = new Contact { Name = "John" };
    Console.WriteLine($"== is: {c1 == c2}"); // This gives a compile time error
  }
}

# But if we change it to a record
# == for records does value equality comparison
record Contact
{
  public string? Name { get; set; }
}

public class Program
{
  public static void Main()
  {
    Contact c1 = new Contact { Name = "John" };
    Contact c2 = new Contact { Name = "John" };
    Console.WriteLine($"== is: {c1 == c2}");
  }
}

# If we change record to class above, this will become False

# What happens when we change an object with one variable and ask the value from another variable referencing the same object
class Contact
{
  public string? Name { get; set; }
}

public class Program
{
  public static void Main()
  {
    Contact c1 = new Contact { Name = "John" };
    Contact c2 = c1;
    c2.Name = "John Doe";
    Console.WriteLine(c1.Name);
  }
}

# In this case c1.Name also prints John Doe

# But when we change class to struct, changes made via c2 don't affect c1, since c2 is a copy of c1
struct Contact
{
  public string? Name { get; set; }
}

public class Program
{
  public static void Main()
  {
    Contact c1 = new Contact { Name = "John" };
    Contact c2 = c1;
    c2.Name = "John Doe";
    Console.WriteLine(c1.Name);
  }
}

# How do records behave?
record Contact
{
  public string? Name { get; set; }
}

public class Program
{
  public static void Main()
  {
    Contact c1 = new Contact { Name = "John" };
    Contact c2 = c1;
    c2.Name = "John Doe";
    Console.WriteLine(c1.Name);
  }
}

# Namespaces and Assemblies
public class Contact
{

}

public class App
{
  public static void Main()
  {
    Console.WriteLine("Hello from App");
  }
}

# 1. There can be multiple public classes in a single .cs file
# 2. The class that has the Main method does not need to be called "Program"
# 3. The string[] args parameter of the Main method is optional

# We should not have more than one Main method or else we get an error when we do dotnet run
public class Program
{
  public static void Main()
  {
    Console.WriteLine("Hello from Program");
  }
}

public class App
{
  public static void Main()
  {
    Console.WriteLine("Hello from App");
  }
}

# While Namespaces are not mandatory, it is recommended that you place your classes in Namespaces
namespace MyNamespace
{
  public class App
  {
    public static void Main()
    {
      Console.WriteLine("Hello from App");
    }
  }
}

# A single Program.cs with multiple Namespaces and use of classes from other namespaces
using Namespace1;

namespace Namespace1
{
  public class Class1
  {
    public void SayHello()
    {
      Console.WriteLine("Hello from Class1");
    }

  }

  public class Class2
  {
    public void SayHello()
    {
      Console.WriteLine("Hello from Class2");
    }
  }
}
namespace MyNamespace
{
  public class App
  {
    public static void Main()
    {
      new Class1().SayHello();
      new Class2().SayHello();
    }
  }
}

# Structuring our code in multiple files
MyUtils.cs:
namespace Namespace1
{
  public class Class1
  {
    public void SayHello()
    {
      Console.WriteLine("Hello from Class1");
    }

  }

  public class Class2
  {
    public void SayHello()
    {
      Console.WriteLine("Hello from Class2");
    }
  }
}

Program.cs:
using Namespace1;

namespace MyNamespace
{
  public class App
  {
    public static void Main()
    {
      new Class1().SayHello();
      new Class2().SayHello();
    }
  }
}

# We can also use full name references instead of "using"
Program.cs:
namespace MyNamespace
{
  public class App
  {
    public static void Main()
    {
      new Namespace1.Class1().SayHello();
      new Namespace1.Class2().SayHello();
    }
  }
}

# Multiple Namespaces with same class
MyUtils.cs:
namespace Namespace1
{
  public class Hello
  {
    public void SayHello()
    {
      Console.WriteLine("Hello from Namespace1");
    }
  }
}

namespace Namespace2
{
  public class Hello
  {
    public void SayHello()
    {
      Console.WriteLine("Hello from Namespace2");
    }
  }
}

Program.cs
namespace MyNamespace
{
  public class App
  {
    public static void Main()
    {
      Namespace1.Hello h1 = new Namespace1.Hello();
      h1.SayHello();
      Namespace2.Hello h2 = new Namespace2.Hello();
      h2.SayHello();
    }
  }
}

# If we want to use "using", we should ensure there is no ambiguity
using Namespace1;

namespace MyNamespace
{
  public class App
  {
    public static void Main()
    {
      Hello h1 = new Hello();
      h1.SayHello();
      Namespace2.Hello h2 = new Namespace2.Hello();
      h2.SayHello();
    }
  }
}

# But this would throw an error:
using Namespace1;
using Namespace2;

namespace MyNamespace
{
  public class App
  {
    public static void Main()
    {
      Hello h1 = new Hello();
      h1.SayHello();
      Namespace2.Hello h2 = new Namespace2.Hello();
      h2.SayHello();
    }
  }
}

# One way to solve this is with aliases
using Hello1 = Namespace1.Hello;
using Hello2 = Namespace2.Hello;

namespace MyNamespace
{
  public class App
  {
    public static void Main()
    {
      Hello1 h1 = new Hello1();
      h1.SayHello();
      Hello2 h2 = new Hello2();
      h2.SayHello();
    }
  }
}

# Namespace hierarchies
MyUtils.cs:
namespace Namespace1
{
  public class Hello
  {
    public void SayHello()
    {
      Console.WriteLine("Hello from Namespace1");
    }
  }

  namespace Namespace2
  {
    public class Hello
    {
      public void SayHello()
      {
        Console.WriteLine("Hello from Namespace2");
      }
    }
  }
}

# And this is how we use it
Program.cs:
using Hello1 = Namespace1.Hello;
using Hello2 = Namespace1.Namespace2.Hello;

namespace MyNamespace
{
  public class App
  {
    public static void Main()
    {
      Hello1 h1 = new Hello1();
      h1.SayHello();
      Hello2 h2 = new Hello2();
      h2.SayHello();
    }
  }
}

# Another way is to describe the hierarchy with "dot"
MyUtils.cs:
namespace Namespace1
{
  public class Hello
  {
    public void SayHello()
    {
      Console.WriteLine("Hello from Namespace1");
    }
  }

  namespace Namespace2
  {
    public class Hello
    {
      public void SayHello()
      {
        Console.WriteLine("Hello from Namespace2");
      }
    }
  }
}

namespace Namespace1.Namespace2
{
  public class AnotherHello
  {
    public void SayHello()
    {
      Console.WriteLine("Hello from AnotherHello");
    }
  }
}

Program.cs:
using Hello1 = Namespace1.Hello;
using Hello2 = Namespace1.Namespace2.Hello;
using AnotherHello = Namespace1.Namespace2.AnotherHello;

namespace MyNamespace
{
  public class App
  {
    public static void Main()
    {
      Hello1 h1 = new Hello1();
      h1.SayHello();
      Hello2 h2 = new Hello2();
      h2.SayHello();
      AnotherHello aH = new AnotherHello();
      aH.SayHello();
    }
  }
}

# Assemblies
# Go to the parent directory (parent of HelloWorld)
dotnet new classlib -o MathLib
# Note that the new project created has similar files (.csproj and .cs)
# But the .csproj does not have an OutputType
# Rename Class1.cs as MathLib.cs
# Add the following code to MathLib.cs
namespace MathLibNamespace
{
  public class MathLibClass
  {
    public int add(int x, int y)
    {
      return x + y;
    }
  }
}

cd MathLib
dotnet build

# Note that dotnet run won't work since this is a Library project
# Go back to the parent (of MathLib)
dotnet new console -o MathLibUser
cd MathLibUser
dotnet add reference ../MathLib/MathLib.csproj
# Edit the Program.cs and add the following contents
using MathLibNamespace;

public class Program
{
  public static void Main()
  {
    var m = new MathLibClass();
    Console.WriteLine(m.Add(2, 3));
  }
}

# Exception Handling
# Let us use the old "HelloWorld" project
# Delete the MyUtils.cs
Program.cs
# If we don't handle exceptions, what happens?
public class Program
{
  public static void Main()
  {
    List<int> list = null;
    list.Add(10);
    Console.WriteLine("And then do this");
  }
}

# We get a runtime error and the program exits abruptly
# Check the exit code after you run
dotnet run
echo $?

# Let us "handle" the exception
public class Program
{
  public static void Main()
  {
    try
    {
      List<int> list = null;
      list.Add(10);
    }
    catch (NullReferenceException)
    {
      Console.WriteLine("An exception occurred and we can't serve you at the moment");
    }
  }
}

dotnet run
echo $?

# Null conditional
public class Program
{
  public static void Main()
  {

    List<int> list = null;
    list?.Add(10);
  }
}

# Activity
# Build a single method called FilterAndMap that takes a list of numbers as input and a filter function and map function, applies the filter first and on the filtered data, applies the map.
# We can use it as follows:
    nums.FilterAndMap(x => x % 2 == 0, x => x * x)

# Throwing an exception
public class Program
{
  public static void Foo()
  {
    throw new Exception("Exception occurred!");
  }
  public static void Main()
  {
    Foo();
  }
}

# The above programs crashes with a non-zero exit code because the caller hasn't handled the exception
# We don't have to necessarily catch an exception (in this case we get a runtime error and not a compile time error)

# Handling exceptions
public class Program
{
  public static void Foo()
  {
    // Callee is supposed to "throw" exceptions when
    // exceptional situations occur (contract cannot be satisfied)
    throw new Exception("Exception occurred!");
  }
  public static void Main()
  {
    try
    {
      // Call the method that could possibly throw exceptions
      Foo();  // Caller is supposed to handle the exception
    }
    catch (Exception e)
    {
      // Handle the exception if it occurs
      Console.WriteLine(e.Message);
    }
  }
}

# Custom exceptions
public class MyException : Exception
{
  public MyException(string message) : base(message)
  {

  }
}
public class Program
{
  public static void Foo()
  {
    throw new MyException("Exception occurred!");
  }
  public static void Main()
  {
    try
    {
      Foo();
    }
    catch (MyException e)
    {
      Console.WriteLine(e.Message);
    }
  }
}

# Multiple catch blocks
public class MyException : Exception
{
  public MyException(string message) : base(message)
  {

  }
}
public class Program
{
  public static void Foo()
  {
    throw new MyException("Exception occurred!");
  }
  public static void Main()
  {
    try
    {
      Foo();
    }
    catch (MyException)
    {
      Console.WriteLine("My exception thrown");
    }
    catch (Exception)
    {
      Console.WriteLine("Generic exception thrown");
    }
  }
}

# Flow of events
public class NegativeNumberException : Exception
{
}
public class Program
{
  public static int Foo(int x)
  {
    if (x < 0)
      throw new NegativeNumberException();
    else if (x == 0)
      throw new Exception("x is 0");
    else
      return x;
  }
  public static void Main()
  {
    try
    {
      var x = Foo(0);
      Console.WriteLine(x);
    }
    catch (NegativeNumberException)
    {
      Console.WriteLine("Negative number exception thrown");
    }
    catch (Exception)
    {
      Console.WriteLine("Generic exception thrown");
    }
    finally
    {
      Console.WriteLine("Always runs");
    }
  }
}

# First try with Foo(5)
# Then try with Foo(0)
# Then try with Foo(-1)

# Why do we need finally? Will the statements after the try/catch not always run?
public class NegativeNumberException : Exception
{
}
public class Program
{
  public static int Foo(int x)
  {
    if (x < 0)
      throw new NegativeNumberException();
    else if (x == 0)
      throw new Exception("x is 0");
    else
      return x;
  }
  public static void Main()
  {
    try
    {
      var x = Foo(-1);
      Console.WriteLine(x);
    }
    catch (NegativeNumberException)
    {
      Console.WriteLine("Negative number exception thrown");
    }
    catch (Exception)
    {
      Console.WriteLine("Generic exception thrown");
    }
    Console.WriteLine("Always runs");
  }
}

# The difference is when we have a throw in the catch
public class NegativeNumberException : Exception
{
}
public class Program
{
  public static int Foo(int x)
  {
    if (x < 0)
      throw new NegativeNumberException();
    else if (x == 0)
      throw new Exception("x is 0");
    else
      return x;
  }
  public static void Main()
  {
    try
    {
      var x = Foo(-1);
      Console.WriteLine(x);
    }
    catch (NegativeNumberException)
    {
      Console.WriteLine("Negative number exception thrown");
      throw;
    }
    catch (Exception)
    {
      Console.WriteLine("Generic exception thrown");
      throw;
    }
    Console.WriteLine("Always runs");
  }
}

# Now we see that "Always runs" is not printed
# finally always runs

public class NegativeNumberException : Exception
{
}
public class Program
{
  public static int Foo(int x)
  {
    if (x < 0)
      throw new NegativeNumberException();
    else if (x == 0)
      throw new Exception("x is 0");
    else
      return x;
  }

  public static void FooCaller()
  {
    try
    {
      var x = Foo(-1);
      Console.WriteLine(x);
    }
    catch (NegativeNumberException e)
    {
      Console.WriteLine("Negative number exception thrown");
      throw e;
    }
    catch (Exception e)
    {
      Console.WriteLine("Generic exception thrown");
      throw e;
    }
    finally
    {
      Console.WriteLine("Always runs");
    }
  }
  public static void Main()
  {
    try
    {
      FooCaller();
    }
    catch (System.Exception)
    {
      // Silence
    }
  }
}

# Exception filters
public class Program
{
  public static void Foo(int num)
  {
    if (num < 10)
      throw new Exception("num < 10");
    else
      throw new Exception("num >= 10");
  }
  public static void Main()
  {
    try
    {
      Foo(50);
    }
    catch (Exception e) when (e.Message.Contains(">"))
    {
      Console.WriteLine($"First block: {e.Message}");
    }
    catch (Exception e)
    {
      Console.WriteLine($"Another block: {e.Message}");
    }
  }
}

# null conditional and null coalescing
public class Person
{
  public string? Name { get; set; }
  public Person? Manager { get; set; }
}

public class Program
{
  public static void Main()
  {
    Person person = new Person();
    Console.WriteLine($"Manager (with null-conditional): {person.Manager?.Name}");
    Console.WriteLine($"Manager is null: {person.Manager?.Name == null}");
    // This is almost like saying
    var name = person.Manager == null ? null : person.Manager.Name;
    Console.WriteLine(name);
    Console.WriteLine("Manager Name with null-coalescing: " + (person.Manager?.Name ?? "No manager"));
    // This is almost like saying
    string manager = person.Manager == null ? "No manager" : person.Manager.Name;
    Console.WriteLine(manager);
  }
}

# Generics
# This gives a compile time error
var l = new List<int>();
l.Add("John");

# How is this class "List" implemented

# A method "Add" that takes either 2 ints or 2 strings as input and performs + on them
public class Program
{
  public static T Add<T>(T x, T y)
  {
    if(typeof(T) == typeof(int))
    {
      return (T)(object)(Convert.ToInt32(x) + Convert.ToInt32(y));
    }
    if(typeof(T) == typeof(string))
    {
      return (T)(object)(Convert.ToString(x) + Convert.ToString(y));
    }
    throw new Exception("Cannot add!");
  }

  public static void Main()
  {
    Console.WriteLine(Add(1, 2));
    Console.WriteLine(Add("Hello", "World"));
  }
}

# Generic implementation of MyMap
public delegate U Func<T, U>(T x);
public class Program
{
  public static IList<U> MyMap<T, U>(IList<T> inputList, Func<T, U> func)
  {
    IList<U> outputList = new List<U>();
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
    foreach (var num in MyMap(nums, x => Convert.ToString(x)))
    {
      Console.WriteLine(num);
    }
  }
}

# There are already "Func" delegates defined in C#
# So remove the first line of the above code and it should still work
// public delegate U Func<T, U>(T x);
https://learn.microsoft.com/en-us/dotnet/api/system.func-2?view=net-8.0

# Generic type constraints
where T : class: Specifies that the generic type parameter T must be a reference type (class).
where T : struct: Specifies that the generic type parameter T must be a value type (struct).
where T : new(): Specifies that the generic type parameter T must have a default parameterless constructor.
where T : someBaseType: Specifies that T must be or derive from someBaseType.
where T : ISomeInterface: Specifies that T must implement the ISomeInterface interface.
where T : U: Specifies that T must be or derive from U, where U is another type parameter.

class Contact
{
    public string? Name { get; set; }

    override public string ToString()
    {
        return Name;
    }
}

public class Program
{
    public static T CreateInstance<T>() where T : new()
    {
        T t = new T();
        return t;
    }
    public static void Main()
    {
        Contact c = CreateInstance<Contact>();
        c.Name = "John";
        Console.WriteLine(c);
    }
}

# Extension methods
# Extending the functionality of classes (even built-in classes)
# Requires the functionality to be a static method in a static class
public static class IntExtension
{
  public static bool IsEven(this int number)
  {
    return number % 2 == 0;
  }
}

public class Program
{
  public static void Main()
  {
    int i = 10;
    Console.WriteLine(i.IsEven());
  }
}

# Reflection
using System.Reflection;

class MyClass
{
  public void Method1()
  {

  }

  void Method2()
  {

  }

  private void Method3()
  {

  }
}

public class Program
{
  public static void Main()
  {
    Type typeInfo = typeof(MyClass);
    Console.WriteLine("Methods in MyClass class:");
    // This prints only public methods
    foreach (var method in typeInfo.GetMethods())
    {
      Console.WriteLine(method.Name);
    }
    // This prints all methods
    foreach (var method in typeInfo.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
    {
      Console.WriteLine(method.Name);
    }
  }
}

# Invoke constructor with one parameter using reflection
using System.Reflection;

class Contact
{
  public string Name { get; set; }

  public Contact(string name)
  {
    Name = name;
  }

  override public string ToString()
  {
    return $"Contact({Name})";
  }
}

public class Program
{
  public static T CreateInstance<T>(string param)
  {
    ConstructorInfo constructor = typeof(T).GetConstructor(new[] { typeof(string) });
    return (T)constructor.Invoke(new object[] { param });   // Generally speaking a Constructor can take variable number of input arguments
  }
  public static void Main()
  {
    Contact c = CreateInstance<Contact>("John");
    Console.WriteLine(c.GetType());
    Console.WriteLine(c);
  }
}

# Choosing between multiple constructors
using System.Reflection;

class Contact
{
  public string? Name { get; set; }
  public int? Age { get; set; }

  public Contact(string name)
  {
    Name = name;
  }

  public Contact(string name, int age)
  {
    Name = name;
  }

  override public string ToString()
  {
    return $"Contact({Name},{Age})";
  }
}

public class Program
{
  // Receiving variable number of arguments via params
  public static T CreateInstance<T>(params object[] args)
  {
    Type[] argTypes = args?.Select(arg => arg.GetType()).ToArray();
    Console.WriteLine($"[{string.Join(", ", (object[])argTypes)}]");
    ConstructorInfo constructor = typeof(T).GetConstructor(argTypes);
    return (T)constructor?.Invoke(args);
  }

  public static void Main()
  {
    var c1 = CreateInstance<Contact>("John");
    var c2 = CreateInstance<Contact>("Jane", 25);

    Console.WriteLine(c1.GetType());
    Console.WriteLine(c1);

    Console.WriteLine(c2.GetType());
    Console.WriteLine(c2);
  }
}

# Attributes
[Serializable]
public class MyClass
{
  // Changing the second argument to true will result in a compilation error instead of just a warning
  [Obsolete("Use NewMethod instead", false)]
  public static void OldMethod()
  {
    Console.WriteLine("Old method called");
  }

  public static void NewMethod()
  {
    Console.WriteLine("New method called");
  }

  public static void Main()
  {
    OldMethod();
  }
}

# Custom attributes
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class DeveloperInfoAttribute : Attribute
{
  public string Developer { get; set; }
  public string Date { get; set; }
}

[DeveloperInfo(Developer = "Jane Doe", Date = "01/14/2024")]
public class FeatureClass
{
  // Class implementation
}

# Asynchronous programming
# async/await
using System;
using System.IO;
using System.Threading.Tasks;

public class Program
{
  public static async Task Main()
  {
    string filePath = "/etc/shadow";

    try
    {
      string fileContent = await ReadFileAsync(filePath);
      Console.WriteLine(fileContent);
    }
    catch (Exception ex)
    {
      Console.WriteLine($"An error occurred: {ex.Message}");
    }
  }

  public static async Task<string> ReadFileAsync(string filePath)
  {
    using (StreamReader reader = new StreamReader(filePath))
    {
      return await reader.ReadToEndAsync();
    }
  }
}

# Also try this
Task<string> readFileTask = ReadFileAsync(filePath);
Console.WriteLine("This line executes before reading the file");
string fileContent = await readFileTask;

# yield return
public class Program
{
  static IEnumerable<int> GetNumbers()
  {
    Console.WriteLine("Beginning of Method");
    yield return 1;
    Console.WriteLine("After yielding 1 but before yielding 2");
    yield return 2;
    Console.WriteLine("After yielding 2 but before yielding 3");
    yield return 3;
  }
  public static void Main()
  {
    foreach (var num in GetNumbers())
    {
      Console.WriteLine(num);
    }
  }
}

# Indexer
public class ShoppingCart
{
  private int[] prices = new int[10];

  public int this[int index]
  {
    get { return this.prices[index]; }
    set { this.prices[index] = value; }
  }
}
class Program
{
  static void Main(string[] args)
  {
    var cart = new ShoppingCart();
    cart[0] = 100;
    Console.WriteLine(cart[0]);
  }
}

# Activity - Implement a LazyFilter and a LazyFilterMap function using yield return

# Activity - Implement the LazyFilter and LazyMap to work with IEnumerable as input and implement them as 2 separate methods and use them in sequence
# List implements an IEnumerable, so we can pass a list to a method that expects IEnumerable as input
# public class List<T> : System.Collections.Generic.ICollection<T>, System.Collections.Generic.IEnumerable<T>

public class Program
{
  public static IEnumerable<int> LazyMap(IEnumerable<int> nums, Func<int, int> mapFunc)
  {
    foreach (var num in nums)
    {
      Console.WriteLine($"In LazyMap: {num}");
      yield return mapFunc(num);
    }
  }

  public static IEnumerable<int> LazyFilter(IEnumerable<int> inputNums, Func<int, bool> filterFunc)
  {
    foreach (var num in inputNums)
    {
      if (filterFunc(num))
      {
        Console.WriteLine($"In LazyFilter: {num}");
        yield return num;
      }
    }
  }
  public static void Main()
  {
    var nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    foreach (var num in LazyMap(LazyFilter(nums, x => x % 2 == 0), x => x * x))
    {
      Console.WriteLine(num);
    }
  }
}

# ASP.NET
https://dotnet.microsoft.com/en-us/learn/aspnet/what-is-aspnet

# ASP.NET Core
dotnet new web -o ContactsService

# Open Program.cs
# var builder = WebApplication.CreateBuilder(args);
# args here are command line arguments
# Builders are what are used to create and configure objects
# Builder pattern
https://en.wikipedia.org/wiki/Builder_pattern

# Response
https://developer.mozilla.org/en-US/docs/Glossary/Response_header

dotnet run
# The port where it runs is mentioned in the output
# Access the application at http://localhost:<port>/
curl localhost:<port>
curl -v localhost:<port>
# Observe the Request and Response headers
^C

dotnet watch run
# Make a modification in / handler - Change to Hello World!!!

# Automatic serialization ability
public class Contact
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Email { get; set; }
}

public class Program
{
  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);
    var app = builder.Build();

    var contacts = new List<Contact>
    {
      new Contact {Id=1, Name="John", Email="john@example.com"},
      new Contact {Id=2, Name="George", Email="george@example.com"},
    };

    app.MapGet("/", () => "Hello World!!!");

    app.MapGet("/contacts", () => contacts);

    app.Run();
  }
}

# We may have to reload the application (in Terminal 1) by pressing Y
# Then do the curl
curl -v localhost:<port>/contacts

# Observe that the content type in the response has been set to Content-Type: application/json
# It has also automatically serialized by Contacts list to a JSON

    app.MapGet("/contact/{id}", (int id) =>
    {
      var contact = contacts.FirstOrDefault(c => c.Id == id);
      return contact != null ? Results.Json(contact) : Results.NotFound();
    });

# Access the path at
curl -v http://localhost:<port>/contact/1
curl -v http://localhost:<port>/contact/3

# Let us add a POST method to create a new contact
var contactIdCounter = 3;
...
app.MapPost("/contacts", (Contact newContact) =>
{
  newContact.Id = contactIdCounter++;
  contacts.Add(newContact);
  return Results.Created($"/contact/{newContact.Id}", newContact);
});

export PORT=5199
curl -v -X POST http://localhost:$PORT/contacts \
-H "Content-Type: application/json" \
-d "{\"Name\": \"John Doe\", \"Email\": \"johndoe@example.com\"}"
# Observe the following Request/Response
# Request
> POST /contacts HTTP/1.1
> Content-Type: application/json

# Response
< HTTP/1.1 201 Created
< Content-Type: application/json; charset=utf-8
< Location: /contact/3

{"id":3,"name":"John Doe","email":"johndoe@example.com"}

# Get the newly constructed resource
curl -v http://localhost:$PORT/contact/3

# Implement PUT and DELETE
    app.MapPut("/contact/{id}", (int id, Contact updatedContact) =>
    {
      var index = contacts.FindIndex(c => c.Id == id);
      if (index == -1) return Results.NotFound();
      contacts[index] = updatedContact;
      return Results.NoContent();
    });

    app.MapDelete("/contact/{id}", (int id) =>
    {
      var index = contacts.FindIndex(c => c.Id == id);
      if (index == -1) return Results.NotFound();
      contacts.RemoveAt(index);
      return Results.Ok();
    });

curl -v -X PUT http://localhost:$PORT/contact/1 \
-H "Content-Type: application/json" \
-d "{\"Id\": 1, \"Name\": \"Jane Doe\", \"Email\": \"janedoe@example.com\"}"

> PUT /contact/1 HTTP/1.1
> Content-Type: application/json

< HTTP/1.1 204 No Content

curl -v http://localhost:$PORT/contact/1

curl -v -X DELETE http://localhost:$PORT/contact/1
> DELETE /contact/1 HTTP/1.1

< HTTP/1.1 200 OK

curl -v http://localhost:$PORT/contact/1

< HTTP/1.1 404 Not Found

# Here is the full code
public class Contact
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Email { get; set; }
}

public class Program
{
  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);
    var app = builder.Build();

    var contacts = new List<Contact>
    {
      new Contact {Id=1, Name="John", Email="john@example.com"},
      new Contact {Id=2, Name="George", Email="george@example.com"},
    };

    var contactIdCounter = 3;

    app.MapGet("/contacts", () => contacts);

    app.MapGet("/contact/{id}", (int id) =>
    {
      var contact = contacts.FirstOrDefault(c => c.Id == id);
      return contact != null ? Results.Json(contact) : Results.NotFound();
    });

    app.MapPost("/contacts", (Contact newContact) =>
    {
      newContact.Id = contactIdCounter++;
      contacts.Add(newContact);
      return Results.Created($"/contact/{newContact.Id}", newContact);
    });

    app.MapPut("/contact/{id}", (int id, Contact updatedContact) =>
    {
      var index = contacts.FindIndex(c => c.Id == id);
      if (index == -1) return Results.NotFound();
      contacts[index] = updatedContact;
      return Results.NoContent();
    });

    app.MapDelete("/contact/{id}", (int id) =>
    {
      var index = contacts.FindIndex(c => c.Id == id);
      if (index == -1) return Results.NotFound();
      contacts.RemoveAt(index);
      return Results.Ok();
    });

    app.Run();
  }
}

# Separate controller classes
dotnet new web -o SeparateControllers

Program.cs
public class Program
{
  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddControllers();
    var app = builder.Build();
    app.MapControllers();
    app.Run();
  }
}

Controllers.cs
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
public class HelloController : ControllerBase
{
  public string Get()
  {
    return "Hello World!";
  }
}

dotnet watch run
# In another terminal
export PORT=
curl http://localhost:$PORT/Hello
curl http://localhost:$PORT/hello
curl http://localhost:$PORT/HELLO

# Supporting custom paths
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
public class HelloController : ControllerBase
{
  [HttpGet("call")]
  public string Get()
  {
    return "Hello World!";
  }
}

# Now this works
curl http://localhost:$PORT/hello/call
# This gives a 404
curl http://localhost:$PORT/hello

# What if we want to support both
  [HttpGet("")]
  [HttpGet("call")]
  public string Get()
  {
    return "Hello World!";
  }

# Supporting absolute paths
  [HttpGet("")]
  [HttpGet("call")]
  [HttpGet("/callagain")]
  public string Get()
  {
    return "Hello World!";
  }

curl http://localhost:$PORT/hello
curl http://localhost:$PORT/hello/call
curl http://localhost:$PORT/callagain

# Routes can be added at method level instead of class
using Microsoft.AspNetCore.Mvc;

public class HelloController : ControllerBase
{
  [Route("hello")]
  [Route("hello/again")]
  public string Get()
  {
    return "Hello World!";
  }
}

curl http://localhost:$PORT/hello
curl http://localhost:$PORT/hello/again

# Receiving params
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]

public class PostController : ControllerBase
{
  [HttpGet("{id}")]
  public string Get(int id)
  {
    return $"Returning post with id: {id}";
  }
}

curl http://localhost:$PORT/post/1
curl http://localhost:$PORT/post/2
curl http://localhost:$PORT/post

# Returning C# objects as response
using Microsoft.AspNetCore.Mvc;

public class Post
{
  public int Id { get; set; }
  public string Text { get; set; }
}

[Route("[controller]")]

public class PostController : ControllerBase
{
  [HttpGet("{id}")]
  public Post Get(int id)
  {
    return new Post { Id = 1, Text = "Hello" };
  }
}

curl http://localhost:$PORT/post/1

# Controlling responses
using Microsoft.AspNetCore.Mvc;

public class Post
{
  public int Id { get; set; }
  public string Text { get; set; }
}

public class Contact
{
  public int Id { get; set; }
  public string Name { get; set; }
}

[Route("[controller]")]

public class CustomResponseController : ControllerBase
{
  [HttpGet("{response}")]
  public IActionResult Get(string response)
  {
    if (response == "post")
    {
      return Ok(new Post { Id = 1, Text = "Hello" }); // Returns a 200 OK response with message
    }
    if (response == "contact")
    {
      return Ok(new Contact { Id = 1, Name = "John" }); // Returns a 200 OK response with message
    }
    else if (response == "tweet")
    {
      return NotFound(); // Returns a 404 Not Found response
    }
    else
    {
      return BadRequest(); // Returns a 400 Bad Request response (or customize as needed)
    }
  }
}

curl -v http://localhost:$PORT/customresponse/contact
curl -v http://localhost:$PORT/customresponse/post
curl -v http://localhost:$PORT/customresponse/tweet
curl -v http://localhost:$PORT/customresponse/company

# Setting specific response headers, the content type
  [HttpGet("withcustomheader")]
  public IActionResult WithCustomHeader()
  {
    Response.Headers["x-custom-key"] = "value";
    return Content("<hello />", "application/xml");
  }

curl -v http://localhost:$PORT/customresponse/withcustomheader

< HTTP/1.1 200 OK
< Content-Type: application/xml
< x-custom-key: value
<hello />

[Route("[controller]")]
public class RequestReaderController : ControllerBase
{
  [HttpGet("")]
  [HttpPost("")]
  public IActionResult Reader()
  {
    return Ok(
      new
      {
        Method = Request.Method,
        Headers = Request.Headers,
        Query = Request.Query,
        Cookies = Request.Cookies,
      }
    );
  }
}

curl -v http://localhost:$PORT/requestreader
curl -v http://localhost:$PORT/requestreader\?a\=b
curl -v -X POST http://localhost:$PORT/requestreader\?a\=b
curl -v -X POST -H "x-a:b" http://localhost:$PORT/requestreader\?a\=b
curl -v -X PUT -H "x-a:b" http://localhost:$PORT/requestreader\?a\=b
< HTTP/1.1 405 Method Not Allowed

# Dependency Injection
# Manual dependency injection management
public interface IDBManager
{
  string GetPasswordFromDB(string username);
}

public class MySQLDBManager : IDBManager
{
  public string GetPasswordFromDB(string username)
  {
    // Dummy implementation
    if (username == "john")
      return "johnpwd";
    return "";
  }
}
public class LoginManager
{
  private IDBManager _dbManager;

  public LoginManager(IDBManager dBManager)
  {
    _dbManager = dBManager;
  }

  public bool Login(string username, string password)
  {
    string passwordFromDB = _dbManager.GetPasswordFromDB(username);
    return passwordFromDB == password;
  }
}

public class Program
{
  public static void Main()
  {
    IDBManager dBManager = new MySQLDBManager();
    LoginManager lManager = new LoginManager(dBManager);
    Console.WriteLine(lManager.Login("john", "johnpwd"));
    Console.WriteLine(lManager.Login("george", "georgepwd"));
  }
}

# Better DI with DI library
dotnet new console -o DIConsole
cd DIConsole
dotnet add package Microsoft.Extensions.DependencyInjection

Program.cs
using Microsoft.Extensions.DependencyInjection;

public interface IDBManager
{
  string GetPasswordFromDB(string username);
}

public class MySQLDBManager : IDBManager
{
  public string GetPasswordFromDB(string username)
  {
    // Dummy implementation
    if (username == "john")
      return "johnpwd";
    return "";
  }
}
public class LoginManager
{
  private IDBManager _dbManager;

  public LoginManager(IDBManager dBManager)
  {
    _dbManager = dBManager;
  }

  public bool Login(string username, string password)
  {
    string passwordFromDB = _dbManager.GetPasswordFromDB(username);
    return passwordFromDB == password;
  }
}

public class Program
{
  public static void Main()
  {
    var services = new ServiceCollection();
    services.AddScoped<IDBManager, MySQLDBManager>();
    services.AddScoped<LoginManager>();

    var serviceProvider = services.BuildServiceProvider();
    var loginManager = serviceProvider.GetService<LoginManager>();

    Console.WriteLine(loginManager?.Login("john", "johnpwd"));
    Console.WriteLine(loginManager?.Login("george", "georgepwd"));
  }
}

# Note how we didn't have to explicitly wire LoginManager with a IDBManager implementation

# Let us now see DI in a Web project
dotnet new web -o DIWeb

# Change Program.cs

public class Program
{
  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);
    // We don't need to explicitly create a ServiceCollection (it is already present in Builder)
    builder.Services.AddScoped<IDBManager, MySQLDBManager>();
    builder.Services.AddScoped<LoginManager>();
    var app = builder.Build();
    // Note how a controller method can 'ask' for a dependency and it will be provided
    app.MapGet("/", (LoginManager loginManager) =>
    {
      return loginManager.Login("john", "johnpwd");
    });
    app.Run();
  }
}

dotnet run
curl localhost:<port>

# Injecting dependencies in controller classes
[ApiController]
[Route("[controller]")]
public class HelloController: ControllerBase
{
  private LoginManager _lManager;
  public HelloController(LoginManager loginManager)
  {
    _lManager = loginManager;
  }

  [HttpGet("")]
  public bool Get()
  {
    return _lManager.Login("john", "johnpwd");
  }
}

public class Program
{
  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddScoped<IDBManager, MySQLDBManager>();
    builder.Services.AddScoped<LoginManager>();
    builder.Services.AddControllers();
    var app = builder.Build();
    app.MapControllers();
    app.Run();
  }
}

dotnet run

curl localhost:<port>/hello

# Middleware
https://docs.djangoproject.com/en/1.8/topics/http/middleware/

# Middleware example
dotnet new web -o MiddlewareExample

Program.cs
public class CustomLoggingMiddleware
{

  // A RequestDelegate is a delegate type that represents a function
  // capable of handling an HTTP request and generating an HTTP response
  private readonly RequestDelegate _next;

  public CustomLoggingMiddleware(RequestDelegate next)
  {
    _next = next;
  }

  // HttpContext represents the HTTP context for a single request-response transaction
  // InvokeAsync is a typical method signature for a middleware component
  public async Task InvokeAsync(HttpContext context)
  {
    // Actions performed before the await _next(context) line typically relate to
    // processing the incoming request and can include tasks like logging request details,
    // authentication, and request modification.
    Console.WriteLine($"CustomLoggingMiddleware called during request processing");

    // Call the next middleware in the pipeline
    //  If this is the last middleware, it will call the
    // actual request handler (basically the controller)
    await _next(context);

    // Actions performed after the await _next(context) line typically relate to processing
    // the response generated by the downstream components.
    Console.WriteLine($"CustomLoggingMiddleware called during response processing");
  }
}

public class Program
{
  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);
    var app = builder.Build();
    app.UseMiddleware<CustomLoggingMiddleware>();
    app.MapGet("/", () => {
      Console.WriteLine("/ controller called");
      return "Hello World!";
    });
    app.MapGet("/hello", () => {
      Console.WriteLine("/hello controller called");
      return "Hello World!";
    });
    app.Run();
  }
}

dotnet run
export PORT=
curl localhost:$PORT
curl localhost:$PORT/hello
# Observe the logs in the console
# We will see this
# CustomLoggingMiddleware called during request processing
# / controller called
# CustomLoggingMiddleware called during response processing

# Having multiple middlewares in sequence
# Keep the class CustomLoggingMiddleware as it is, then change the rest of the code
public class CustomLoggingMiddleware2
{

  // A RequestDelegate is a delegate type that represents a function
  // capable of handling an HTTP request and generating an HTTP response
  private readonly RequestDelegate _next;

  public CustomLoggingMiddleware2(RequestDelegate next)
  {
    _next = next;
  }

  // HttpContext represents the HTTP context for a single request-response transaction
  // InvokeAsync is a typical method signature for a middleware component
  public async Task InvokeAsync(HttpContext context)
  {
    // Actions performed before the await _next(context) line typically relate to
    // processing the incoming request and can include tasks like logging request details,
    // authentication, and request modification.
    Console.WriteLine($"CustomLoggingMiddleware2 called during request processing");

    // Call the next middleware in the pipeline
    //  If this is the last middleware, it will call the
    // actual request handler (basically the controller)
    await _next(context);

    // Actions performed after the await _next(context) line typically relate to processing
    // the response generated by the downstream components.
    Console.WriteLine($"CustomLoggingMiddleware2 called during response processing");
  }
}

public class Program
{
  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);
    var app = builder.Build();
    app.UseMiddleware<CustomLoggingMiddleware>();
    app.UseMiddleware<CustomLoggingMiddleware2>();
    app.MapGet("/", () =>
    {
      Console.WriteLine("/ controller called");
      return "Hello World!";
    });
    app.MapGet("/hello", () =>
    {
      Console.WriteLine("/hello controller called");
      return "Hello World!";
    });
    app.Run();
  }
}

CustomLoggingMiddleware called during request processing
CustomLoggingMiddleware2 called during request processing
/ controller called
CustomLoggingMiddleware2 called during response processing
CustomLoggingMiddleware called during response processing

# Reading requests in the middleware
using System.Diagnostics;

public class CustomLoggingMiddleware
{
  private readonly RequestDelegate _next;

  public CustomLoggingMiddleware(RequestDelegate next)
  {
    _next = next;
  }

  public async Task InvokeAsync(HttpContext context)
  {
    Stopwatch stopwatch = Stopwatch.StartNew();
    await _next(context);
    stopwatch.Stop();
    Console.WriteLine($"{context.Request.Path} took {stopwatch.ElapsedMilliseconds}ms and the response code was {context.Response.StatusCode}");
  }
}

public class Program
{
  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);
    var app = builder.Build();
    app.UseMiddleware<CustomLoggingMiddleware>();
    app.MapGet("/", () => "Hello World!");
    app.MapGet("/hello", () => "Hello World!");
    app.Run();
  }
}

# Note that we have not implemented this logic in the controller methods, rather it is a cross cutting concern implemented in one place and that intercepts all requests to this app

# Configurations
dotnet new console -o ConfigurationExample 
cd ConfigurationExample
dotnet add package Microsoft.Extensions.Configuration.Json

appsettings.json
{
  "API_KEY": "key-123456"
}

Program.cs
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

IConfigurationRoot configuration = builder.Build();

var apiKey = configuration?["API_KEY"];
Console.WriteLine($"API Key: {apiKey}");

# To support environment variables via the configuration object
# Add the following package
dotnet add package Microsoft.Extensions.Configuration.EnvironmentVariables

using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables();

IConfigurationRoot configuration = builder.Build();

var apiKey = configuration?["API_KEY_FROM_ENV"];
Console.WriteLine($"API Key From Env: {apiKey}");

export API_KEY_FROM_ENV=123456
dotnet run

# Object design of LinkedIn Profiles
public class Profile
{
  public string? Name { get; set; }

  public string? Email { get; set; }
  public List<Experience> experiences { get; }
  public List<Skill> skills { get; }

  public Profile()
  {
    this.experiences = new List<Experience>();
    this.skills = new List<Skill>();
  }

  public void addExperience(Experience e)
  {
    experiences.Add(e);
  }
}

public class Experience
{
  public string? Designation { get; set; }

  public string? Company { get; set; }

}

public class Skill
{

}

public class Program
{
  public static void Main()
  {
    Profile p1 = new Profile { Name = "John", Email = "john@example.com" };
    Experience e1 = new Experience
    {
      Designation = "Software Engineer",
      Company = "Google"
    };
    Experience e2 = new Experience
    {
      Designation = "Senior Software Engineer",
      Company = "Tesla"
    };
    p1.addExperience(e1);
    p1.addExperience(e2);
    // Get me all the designations of the person, p
    foreach (var designation in p1.experiences.Select(e => e.Designation))
    {
      Console.WriteLine(designation);
    }
    Profile p2 = new Profile { Name = "George", Email = "george@example.com" };
    p2.addExperience(new Experience
    {
      Designation = "Software Engineer",
      Company = "Tesla"
    });
    p2.addExperience(new Experience
    {
      Designation = "ML Engineer",
      Company = "OpenAI"
    });
    var profileList = new List<Profile> { p1, p2 };
    // Given the profileList, 
    // get me the designations of the person with email "george@example.com"
    foreach (var designation in profileList
    .FirstOrDefault(p => p.Email == "george@example.com")?
    .experiences
    .Select(e => e.Designation))
    {
      Console.WriteLine(designation);
    }
  }
}

# Install Docker and Verify if Docker is available
docker --version
docker ps
docker images | grep mysql
docker pull mysql:8.3
docker run --name mysql -e MYSQL_ROOT_PASSWORD=my-secret-pw -p 3306:3306 -d mysql:8.3
docker ps
docker exec -it mysql mysql -uroot -p
Enter password: 
mysql> 
# Check what databases are currently present
show databases;
# Exit the mysql shell
^D

# Create a new console project
dotnet new console -o EFCoreHelloWorld
cd EFCoreHelloWorld
dotnet new tool-manifest
dotnet tool install dotnet-ef
# Verification
dotnet ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 8.0.0-beta.2
dotnet add package Microsoft.Extensions.Configuration.Json

# DbContext serves as a bridge between your .NET application and the database, allowing you to perform CRUD (Create, Read, Update, Delete) operations, and manage database connections and transactions.
# Equivalent of EntityManager in JPA

Program.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text;

public class Profile
{
  public int Id { get; set; }
  public string Name { get; set; }
}

public class AppDbContext : DbContext
{
  // The DbContext provides properties, typically of type DbSet<TEntity>
  // where TEntity is an entity class mapped to a database table.
  // You use these properties to query and work with the data.
  public DbSet<Profile> Profiles { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

    string server = Environment.GetEnvironmentVariable("DB_SERVER");
    string user = Environment.GetEnvironmentVariable("DB_USER");
    string password = Environment.GetEnvironmentVariable("DB_PASSWORD");

    // https://www.connectionstrings.com/store-and-read-connection-string-in-appsettings-json/
    var connectionString = configuration.GetConnectionString("MyDatabase");

    connectionString = connectionString
            .Replace("{SERVER}", server)
            .Replace("{USER}", user)
            .Replace("{PASSWORD}", password);

    optionsBuilder
      .UseMySql(connectionString,
        ServerVersion.AutoDetect(connectionString))
      .LogTo(Console.WriteLine, LogLevel.Information);  // For logging the queries that EF Core generates
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Profile>(entity =>
    {
      entity.HasKey(e => e.Id);
      entity.Property(e => e.Name).IsRequired();
    });
  }
}

public class Program
{
  public static void Main(string[] args)
  {
    InsertData();
    PrintData();
  }

  private static void InsertData()
  {
    using (var context = new AppDbContext())
    {
      // Creates the database if not exists
      context.Database.EnsureCreated();

      var profile = new Profile
      {
        Name = "John Doe"
      };
      context.Profiles.Add(profile);

      // Saves changes
      context.SaveChanges();
    }
  }

  private static void PrintData()
  {
    using (var context = new AppDbContext())
    {
      var profiles = context.Profiles.ToArray();
      foreach (var profile in profiles)
      {
        var data = new StringBuilder();
        data.AppendLine($"Id: {profile.Id}");
        data.AppendLine($"Name: {profile.Name}");
        Console.WriteLine(data.ToString());
      }
    }
  }
}

appsettings.json
{
  "ConnectionStrings": {
    "MyDatabase": "server={SERVER};database=profilesdb;user={USER};password={PASSWORD}"
  }
}

export DB_SERVER=localhost
export DB_USER=root
export DB_PASSWORD=my-secret-pw
dotnet run

# Note the queries it ran

The LAST_INSERT_ID() is session-specific, which means it returns the last inserted ID for the current database connection session. Each client's connection to the database server has its own separate session.

# Verification from the database
docker exec -it mysql mysql -uroot -p
mysql>
SHOW DATABASES;
USE profilesdb;
SHOW TABLES;
DESC Profiles;
SHOW CREATE TABLE Profiles;
SELECT * FROM Profiles;

# What happens when we change entity definitions?
# Update the Profile class with a Location field
public class Profile
{
  public int Id { get; set; }
  public string? Name { get; set; }
  public string? Location { get; set; }
}

# In the record we are adding, make this change
      var profile = new Profile
      {
        Name = "John Doe",
        Location = "New York",
      };

# PrintData

  private static void PrintData()
  {
    using (var context = new AppDbContext())
    {
      var profiles = context.Profiles.ToArray();
      foreach (var profile in profiles)
      {
        var data = new StringBuilder();
        data.AppendLine($"Id: {profile.Id}");
        data.AppendLine($"Name: {profile.Name}");
        data.AppendLine($"Location: {profile.Location}");
        Console.WriteLine(data.ToString());
      }
    }
  }

# If we run this as it is, we get an error because the schema is not updated
dotnet run
# We can drop and recreate
dotnet ef database drop
dotnet run

# This is ok for development and not for production
# Migrations
dotnet ef database drop
# Think of migrations to be a DDL script that tells us how to reach the current entity design compared to what already exists
dotnet ef migrations list
dotnet ef migrations add NewProfile
# It would have now generated a migration script
dotnet ef migrations list
docker exec -it mysql mysql -uroot -p$DB_PASSWORD -e "SHOW DATABASES"
# The script tells me what the database has to run to reach the current state described in our C# program
dotnet ef migrations script
# Since the database is empty, it is telling me that it will create a table with the 3 fields
# If we are fine with the changes that it describes, we can run ef database update to run the DDLs
dotnet ef database update
dotnet ef migrations list
docker exec -it mysql mysql -uroot -p$DB_PASSWORD -e "SHOW DATABASES"
docker exec -it mysql mysql -uroot -p$DB_PASSWORD profilesdb -e "SHOW TABLES"
docker exec -it mysql mysql -uroot -p$DB_PASSWORD profilesdb -e "DESC Profiles"

# Let us add another new field

public class Profile
{
  public int Id { get; set; }
  public string? Name { get; set; }
  public string? Location { get; set; }
  public string? Email { get; set; }
}

dotnet ef migrations add AddEmailToProfile
dotnet ef migrations list
dotnet ef migrations script
dotnet ef migrations script 20240215092849_NewProfile 20240215093401_AddEmailToProfile
dotnet ef database update

docker exec -it mysql mysql -uroot -p$DB_PASSWORD profilesdb -e "SHOW CREATE TABLE Profiles;"

# One to many relationships
# Let us add support for Experience
public class Profile
{
  public int Id { get; set; }
  public string? Name { get; set; }
  public string? Location { get; set; }
  public string? Email { get; set; }
  public ICollection<Experience>? Experiences { get; set; } // Collection of experiences
}

public class Experience
{
  public int Id { get; set; }
  public string? Designation { get; set; }
  public string? Company { get; set; }
  public int ProfileId { get; set; } // Foreign key to Profile
  public Profile? Profile { get; set; } // Navigation property
}

public class AppDbContext : DbContext
{
  public DbSet<Profile> Profiles { get; set; }
  public DbSet<Experience> Experiences { get; set; }
  ...
    protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Profile>(entity =>
    {
      entity.HasKey(e => e.Id);
      entity.Property(e => e.Name).IsRequired();
    });

    modelBuilder.Entity<Experience>(entity =>
    {
      entity.HasKey(e => e.Id);
      entity.Property(e => e.Designation).IsRequired();
      entity.Property(e => e.Company).IsRequired();
      entity.HasOne(e => e.Profile) // 1 Experience entity is associated with 1 Profile
                .WithMany(p => p.Experiences) // That profile is associated with many Experiences
                .HasForeignKey(e => e.ProfileId);
    });
  }

dotnet ef migrations add AddExperienceEntity
dotnet ef migrations list
dotnet ef migrations script 20240215093401_AddEmailToProfile 20240215094604_AddExperienceEntity
dotnet ef database update
docker exec -it mysql mysql -uroot -p$DB_PASSWORD profilesdb -e "SHOW TABLES;"
docker exec -it mysql mysql -uroot -p$DB_PASSWORD profilesdb -e "SHOW CREATE TABLE Experiences;"

# Let us add Skills next, which has a m..n relationship with Profile
public class Profile
{
  public int Id { get; set; }
  public string? Name { get; set; }
  public string? Location { get; set; }
  public string? Email { get; set; }
  public ICollection<Experience>? Experiences { get; set; } // Collection of experiences
  public ICollection<Skill>? Skills { get; set; }
}

public class Skill
{
  public int Id { get; set; }
  public string? Name { get; set; }
  public ICollection<Profile>? Profiles { get; set; }
}

public class AppDbContext : DbContext
{
  public DbSet<Profile> Profiles { get; set; }
  public DbSet<Experience> Experiences { get; set; }
  public DbSet<Skill> Skills { get; set; }
  ...
    protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
     ...
    modelBuilder.Entity<Profile>()
    .HasMany(p => p.Skills)
    .WithMany(s => s.Profiles);
  }

dotnet ef migrations add AddSkillEntity
dotnet ef migrations list
dotnet ef migrations script 20240215094604_AddExperienceEntity 20240215100934_AddSkillEntity
dotnet ef database update
docker exec -it mysql mysql -uroot -p$DB_PASSWORD profilesdb -e "SHOW TABLES;"
docker exec -it mysql mysql -uroot -p$DB_PASSWORD profilesdb -e "SHOW CREATE TABLE Skills;"
docker exec -it mysql mysql -uroot -p$DB_PASSWORD profilesdb -e "SHOW CREATE TABLE ProfileSkill;"

# Let us now add some records
public class Program
{
  public static void Main(string[] args)
  {
    using (var context = new AppDbContext())
    {
      var profile = new Profile
      {
        Name = "John Doe",
        Location = "New York",
        Email = "john@example.com",
      };
      var experience1 = new Experience
      {
        Designation = "Software Engineer",
        Company = "Google",
      };
      var experience2 = new Experience
      {
        Designation = "Senior Software Engineer",
        Company = "Twitter",
      };
      profile.Experiences = new List<Experience> { experience1, experience2 };
      var skill1 = new Skill { Name = "Java" };
      var skill2 = new Skill { Name = "JavaScript" };
      profile.Skills = new List<Skill> { skill1, skill2 };
      context.Profiles.Add(profile);
      context.Experiences.AddRange(experience1, experience2);
      context.Skills.AddRange(skill1, skill2);
      context.SaveChanges();
    }
  }
}

dotnet run
docker exec -it mysql mysql -uroot -p$DB_PASSWORD profilesdb -e "SELECT * FROM Profiles"
docker exec -it mysql mysql -uroot -p$DB_PASSWORD profilesdb -e "SELECT * FROM Experiences"
docker exec -it mysql mysql -uroot -p$DB_PASSWORD profilesdb -e "SELECT * FROM Skills"
docker exec -it mysql mysql -uroot -p$DB_PASSWORD profilesdb -e "SELECT * FROM ProfileSkill"

# What if we don't add Experience or Skill explicitly to context
public class Program
{
  public static void Main(string[] args)
  {
    using (var context = new AppDbContext())
    {
      var profile = new Profile
      {
        Name = "George",
        Location = "London",
        Email = "george@example.com",
      };
      var experience1 = new Experience
      {
        Designation = "Software Engineer",
        Company = "Tesla",
      };
      var experience2 = new Experience
      {
        Designation = "Senior Software Engineer",
        Company = "OpenAI",
      };
      profile.Experiences = new List<Experience> { experience1, experience2 };
      var skill1 = new Skill { Name = "Machine Learning" };
      var skill2 = new Skill { Name = "Deep Learning" };
      profile.Skills = new List<Skill> { skill1, skill2 };
      context.Profiles.Add(profile);
      context.SaveChanges();
    }
  }
}

# Querying the data back
public class Program
{
  public static async Task Main(string[] args)
  {
    using (var context = new AppDbContext())
    {
      Profile p = await context
      .Profiles
      .Include(p => p.Experiences)
      .Include(p => p.Skills)
      .FirstOrDefaultAsync(p => p.Email == "george@example.com");
      Console.WriteLine(p.Name);
      Console.WriteLine($"Experiences of {p.Name}");
      foreach (var e in p.Experiences)
      {
        Console.WriteLine($"{e.Designation} in {e.Company}");
      }
      Console.WriteLine($"Skills of {p.Name}");
      foreach (var s in p.Skills)
      {
        Console.WriteLine($"{s.Name}");
      }
    }
  }
}

# Querying with LINQ and serializing to JSON
dotnet add package Newtonsoft.Json

public class Program
{
  public static async Task Main(string[] args)
  {
    using (var context = new AppDbContext())
    {
      var query = from profile in context.Profiles
                  select new
                  {
                    Id = profile.Id,
                    Name = profile.Name,
                  };
      string jsonString = JsonConvert.SerializeObject(query.ToList());
      Console.WriteLine(jsonString);
    }
  }
}

dotnet run

public class Program
{
  public static async Task Main(string[] args)
  {
    using (var context = new AppDbContext())
    {
      var query = from profile in context.Profiles
                  select new
                  {
                    Id = profile.Id,
                    Name = profile.Name,
                    Experiences = from experience in profile.Experiences
                                  select new
                                  {
                                    Designation = experience.Designation,
                                    Company = experience.Company,
                                  }
                  };
      string jsonString = JsonConvert.SerializeObject(query.ToList());
      Console.WriteLine(jsonString);
    }
  }
}

dotnet run

public class Program
{
  public static async Task Main(string[] args)
  {
    using (var context = new AppDbContext())
    {
      var query = from profile in context.Profiles
                  select new
                  {
                    Id = profile.Id,
                    Name = profile.Name,
                    Experiences = from experience in profile.Experiences
                                  select new
                                  {
                                    Designation = experience.Designation,
                                    Company = experience.Company,
                                  },
                    Skills = from skill in profile.Skills
                              select skill.Name
                  };
      string jsonString = JsonConvert.SerializeObject(query.ToList());
      Console.WriteLine(jsonString);
    }
  }
}

dotnet run

# Indexing
docker exec -it mysql mysql -uroot -p$DB_PASSWORD profilesdb
EXPLAIN SELECT * FROM Profiles;
EXPLAIN SELECT * FROM Profiles WHERE email = 'john@example.com';
EXPLAIN SELECT * FROM Profiles WHERE id = 2;
SHOW INDEXES FROM Profiles;
SHOW INDEXES FROM Experiences;
SELECT e.Designation
FROM Profiles p, Experiences e
WHERE p.Email = 'john@example.com'
  AND p.Id = e.ProfileId;

# Add additional indexes
https://learn.microsoft.com/en-us/ef/core/modeling/indexes?tabs=data-annotations

# Removing records and related entities
public class Program
{
  public static async Task Main(string[] args)
  {
    using (var context = new AppDbContext())
    {
      var profile = await context.Profiles
          .Include(p => p.Experiences)
          .Include(p => p.Skills)
          .FirstOrDefaultAsync(p => p.Email == "john@example.com");
      if (profile == null)
      {
        Console.WriteLine("Profile not found");
        return;
      }
      foreach (var experience in profile.Experiences)
      {
        // Delete the experience record
        context.Experiences.Remove(experience);
      }
      // Remove the skills from profile and not from context
      // because this skill may be in use with other profiles
      profile.Skills.Clear();
      // Delete the profile record
      context.Profiles.Remove(profile);
      await context.SaveChangesAsync();
    }
  }
}

dotnet run
docker exec -it mysql mysql -uroot -p$DB_PASSWORD profilesdb -e "SELECT * FROM Profiles"
docker exec -it mysql mysql -uroot -p$DB_PASSWORD profilesdb -e "SELECT * FROM Experiences"
docker exec -it mysql mysql -uroot -p$DB_PASSWORD profilesdb -e "SELECT * FROM Skills"
docker exec -it mysql mysql -uroot -p$DB_PASSWORD profilesdb -e "SELECT * FROM ProfileSkill"

# Because of "ON DELETE CASCADE", if we remove the profile, the corresponding experiences and skill mappings will be deleted by the database
public class Program
{
  public static async Task Main(string[] args)
  {
    using (var context = new AppDbContext())
    {
      var profile = await context.Profiles
          .FirstOrDefaultAsync(p => p.Email == "george@example.com");
      if (profile == null)
      {
        Console.WriteLine("Profile not found");
        return;
      }
      // Delete the profile record
      context.Profiles.Remove(profile);
      await context.SaveChangesAsync();
    }
  }
}

dotnet run
docker exec -it mysql mysql -uroot -p$DB_PASSWORD profilesdb -e "SELECT * FROM Profiles"
docker exec -it mysql mysql -uroot -p$DB_PASSWORD profilesdb -e "SELECT * FROM Experiences"
docker exec -it mysql mysql -uroot -p$DB_PASSWORD profilesdb -e "SELECT * FROM ProfileSkill"
docker exec -it mysql mysql -uroot -p$DB_PASSWORD profilesdb -e "SELECT * FROM Skills"

public class Program
{
  public static async Task Main(string[] args)
  {
    using (var context = new AppDbContext())
    {
      using (var transaction = context.Database.BeginTransaction())
      {
        var profile = new Profile
          {
            Name = "John Doe",
            Location = "New York",
            Email = "john@example.com",
          };
        try
        {
          context.Profiles.Add(profile);
          // Added: The entity is tracked by the context but does not yet exist in the database.
          Console.WriteLine(context.Entry(profile).State);
          context.SaveChanges();
          // Unchanged: The entity is tracked and exists in the database, and its properties have not been modified.
          Console.WriteLine(context.Entry(profile).State);
          // Comment this line if you want to commit
          throw new Exception();
          transaction.Commit();
          // Unchanged: The entity is tracked and exists in the database, and its properties have not been modified.
          Console.WriteLine(context.Entry(profile).State);
        }
        catch (Exception)
        {
          Console.WriteLine("Rolling back!");
          transaction.Rollback();
          // We still see this as "Unchanged" because the context is unaware of the state
          // We can query the database if we need to update the profile in memory
          Console.WriteLine($"State: {context.Entry(profile).State}");
          throw;
        }
      }
    }
  }
}

# Localization and Globalization
dotnet new console -o LocalizationExample

# Install the ResX extension in VS Code
Name: ResX Editor
VS Marketplace Link: https://marketplace.visualstudio.com/items?itemName=DominicVonk.vscode-resx-editor

Program.cs
using System.Globalization;
using System.Resources;

namespace LocalizationExample
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var culture = args.Length > 1 ? new CultureInfo(args[1]) : CultureInfo.CurrentCulture;
      Thread.CurrentThread.CurrentCulture = culture;
      Thread.CurrentThread.CurrentUICulture = culture;

      ResourceManager rm = new ResourceManager(
        "LocalizationExample.Messages", typeof(Program).Assembly);

      string userName = args.Length > 0 ? args[0] : "User";
      string localizedGreeting = string.Format(
        rm.GetString("Hello"), userName);

      Console.WriteLine(localizedGreeting);
    }
  }
}

Messages.resx
<?xml version="1.0" encoding="utf-8"?>
<root>
  <data name="Hello" xml:space="preserve">
    <value>Hello {0}</value>
  </data>
</root>

Messages.es.resx
<?xml version="1.0" encoding="utf-8"?>
<root>
  <data name="Hello" xml:space="preserve">
    <value>Hola {0}</value>
    <comment/>
  </data>
</root>

# Use default
dotnet run
# Pass name
dotnet run John
# Use specific locales
dotnet run John es

# Angular i18n
https://angular.io/guide/i18n-example

# Globalization
dotnet new console -o GlobalizationExample

Program.cs:
using System.Globalization;

namespace GlobalizationExample
{
  class Program
  {
    static void Main(string[] args)
    {
      // Set the culture to a specific culture, e.g., "en-US" or "fr-FR"
      // You can also use CultureInfo.CurrentCulture for the system's current culture
      var culture = args.Length > 0 ? new CultureInfo(args[0]) : CultureInfo.CurrentCulture;
      Thread.CurrentThread.CurrentCulture = culture;
      Thread.CurrentThread.CurrentUICulture = culture;

      // Display a date (d means short-date pattern)
      // Try en-IN to see dd/mm/yyyy format
      Console.WriteLine($"Current Date: {DateTime.Now:d}");
      // Try with de-DE or ar-SA to see other variations
      Console.WriteLine($"Current Time: {DateTime.Now.ToString("T")}");
      Console.WriteLine($"Current Date and Time: {DateTime.Now.ToString("yyyy-MM-dd HH:mm")}");

      // Display a number with formatting (N2 means number with 2 decimals)
      double sampleNumber = 1234567890.12;
      Console.WriteLine($"Formatted Number: {sampleNumber:N2}");
    }
  }
}

dotnet run
dotnet run en-IN
dotnet run fr-FR
dotnet run en-US
dotnet run ar-SA

# Logging Concepts
# Log Message - what happened
# Log Level - importance of the message being logged
# Log Format - pattern of the log line
# Log Handler - what should I do with each message, where should I send it?

# Logging
dotnet new web -o LoggingExample

Program.cs
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
public class HelloController : ControllerBase
{
  private readonly ILogger<HelloController> _logger;

  public HelloController(ILogger<HelloController> logger)
  {
    _logger = logger;
  }

  [HttpGet("")]
  public string Index()
  {
    _logger.LogTrace("This is a Trace log");
    _logger.LogDebug("This is a Debug log");
    _logger.LogInformation("This is an Information log");
    _logger.LogWarning("This is a Warning log");
    _logger.LogError("This is an Error log");
    _logger.LogCritical("This is a Critical log");
    return "Hello world!";
  }
}

public class Program
{
  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);
    builder.Logging.AddConsole(options =>
    {
      options.FormatterName = "simple"; // Or use "json" for JSON format
    });
    builder.Services.AddControllers();
    var app = builder.Build();
    app.MapGet("/", () => "Hello World!");
    app.MapControllers();
    app.Run();
  }
}

dotnet run

curl http://localhost:<port>/hello

# Observe that it generates Info level logs and beyond

# Change the Log Level in appsettings.Developer.json
"Default": "Trace"

dotnet run

curl http://localhost:<port>/hello

# Observe that it now generates Trace level logs and beyond

# Logging with Serilog
https://serilog.net/

dotnet new web -o SerilogExample
cd SerilogExample
dotnet add package Serilog.AspNetCore
dotnet add package Serilog.Sinks.Console
dotnet add package Serilog.Sinks.File

Program.cs
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

[Route("[controller]")]
public class HelloController : ControllerBase
{
  private readonly ILogger<HelloController> _logger;

  public HelloController(ILogger<HelloController> logger)
  {
    _logger = logger;
  }

  [HttpGet("")]
  public string Index()
  {
    _logger.LogTrace("This is a Trace log");
    _logger.LogDebug("This is a Debug log");
    _logger.LogInformation("This is an Information log");
    _logger.LogWarning("This is a Warning log");
    _logger.LogError("This is an Error log");
    _logger.LogCritical("This is a Critical log");
    return "Hello world!";
  }
}

public class Program
{
  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);
    Log.Logger = new LoggerConfiguration()
      .MinimumLevel.Verbose()
      .MinimumLevel.Override("Microsoft", LogEventLevel.Information) // Override for Microsoft namespace
      .MinimumLevel.Override("System", LogEventLevel.Verbose) // Override for System namespace
      .Enrich.FromLogContext()
      .WriteTo.Console(
        theme: AnsiConsoleTheme.Sixteen,
        outputTemplate:
          "[{Timestamp:HH:mm:ss} {Level:u3}] => {Message:lj}{NewLine}{Exception}"
      )
      .WriteTo.File("logs/myapp.log", rollingInterval: RollingInterval.Day)
      .CreateLogger();
    builder.Host.UseSerilog();
    builder.Services.AddControllers();
    var app = builder.Build();
    app.MapGet("/", () => "Hello World!");
    app.MapControllers();
    app.Run();
  }
}

dotnet run

curl localhost:<port>/hello

# Observe the logs in the console and the logs directory

# Exploring Docker
https://hub.docker.com/

docker pull nginx
docker images
docker run -d --name webserver -p 80:80 nginx
docker ps
curl localhost:80
docker rm -f webserver

mkdir -p ~/data/mynodejsapp
cd ~/data/mynodejsapp
echo "console.log('Hello');" > app.js 
cat > Dockerfile <<"DELIM"
FROM node:21

RUN mkdir -p /srv
COPY app.js /srv/

CMD ["node", "/srv/app.js"]
DELIM
docker build -t mynodejsapp .
docker images | grep mynodejsapp
docker run mynodejsapp

# Users service application
https://github.com/buzypi/users-service-dotnet

# Run MongoDB with Docker
docker run -d --name users-db -p 27017:27017 mongo:7
# Run the application without Docker
cd ~/data
git clone https://github.com/buzypi/users-service-dotnet
cd users-service-dotnet
export DB_HOST="mongodb://localhost:27017"
dotnet run
export PORT=5100
curl localhost:$PORT/ping
curl localhost:$PORT/users
curl localhost:$PORT/user/1
curl localhost:$PORT/user/2

# Let us now package our application into a Docker image and run the app server also with Docker
docker build -t users-service:v1 .
docker images | grep users-service
docker run -d --name users-service -p 80:8080 -e DB_HOST="mongodb://172.17.0.1:27017/" users-service:v1
docker logs users-service
curl localhost:80/ping
curl localhost:80/users
curl localhost:80/user/1
curl localhost:80/user/2

# To cleanup
docker rm -f users-db users-service

# Running containers with custom networks
docker network create mynet1
docker run -d --name users-db --net mynet1 mongo:7
docker inspect users-db
docker run -d --name users-service --net mynet1 -p 80:8080 -e DB_HOST="mongodb://users-db/" users-service:v1
docker inspect users-service
# This won't work in Windows
curl 172.18.0.3:8080/users # Assuming 172.18.0.3 is the users-service container
curl localhost:80/users

https://github.com/buzypi/payments-service-dotnet

git clone https://github.com/buzypi/payments-service-dotnet
cd payments-service-dotnet
docker build -t payments-service:v1 .
docker images | grep payments-service
docker run -d --name payments-db --net mynet1 mongo:7
docker run -d --name payments-service --net mynet1 -p 8080:8080 -e DB_HOST="mongodb://payments-db/" -e USERS_SERVICE=users-service:8080 payments-service:v1
# Verification (in Linux)
curl 172.18.0.5:8080/payments_from/1
# In all machines
curl localhost:8080/payments_from/1

# JWT
https://jwt.io/

echo "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9" | base64 --decode

dotnet new web -o JWTExample
cd JWTExample
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer

# Update Program.cs to this
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

public class Program
{
  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);
    var Configuration = builder.Configuration;
    builder.Services.AddControllers();

    builder.Services.AddAuthentication(options =>
    {
      options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
      options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
      options.TokenValidationParameters = new TokenValidationParameters
      {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = Configuration["Jwt:Issuer"],
        ValidAudience = Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
      };
    });
    builder.Services.AddAuthorization();
    var app = builder.Build();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();

    app.MapGet("/token", () =>
    {
      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));
      var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(Configuration["Jwt:Issuer"],
        Configuration["Jwt:Audience"],
        expires: DateTime.Now.AddMinutes(1),
        signingCredentials: credentials);

      return new JwtSecurityTokenHandler().WriteToken(token);
    });

    app.Run();
  }
}

# Add the following configuration in appsettings.Development.json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "Jwt": {
    "Key": "my-long-super-secret-key-here-should-be-256-bits",
    "Issuer": "jnaapti.com",
    "Audience": "jnaapti.com"
  }
}

dotnet run

curl localhost:<port>/token

# Verify the token in jwt.io
# Copy the signature and see if it shows "Signature Verified"

# Let us now add a route that does not need auth
# Add this in Program.cs
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

[Route("[controller]")]
public class HelloController : ControllerBase
{
  // Accessible without token
  [HttpGet("")]
  public string Get()
  {
    return "Hello";
  }
}

dotnet watch run
curl localhost:<port>/hello

# Let us now add a route that needs auth
# Add this in Program.cs
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
...
[Authorize]
[Route("[controller]")]
public class HelloWithAuthController : ControllerBase
{
  [HttpGet("")]
  public string Get()
  {
    return "Hello";
  }
}

export PORT=
curl -v localhost:$PORT/hellowithauth
# We get a 401 error
curl -v localhost:$PORT/hellowithauth -H "Authorization: Bearer dummy_token"
# We get a 401 error with < WWW-Authenticate: Bearer error="invalid_token"
curl -v localhost:$PORT/hellowithauth -H "Authorization: Bearer $(curl -s localhost:$PORT/token)"
# Now we get a 200 OK with a Hello response

# Let us now add role support
# First we will build a route that helps us get a token with role information

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

    app.MapGet("/tokenWithRole", (string role) =>
    {
      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));
      var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

      // Add role claim
      var claims = new List<Claim>
      {
          new Claim(ClaimTypes.Role, role)
      };
      
      var token = new JwtSecurityToken(Configuration["Jwt:Issuer"],
          Configuration["Jwt:Audience"],
          claims,
          expires: DateTime.Now.AddMinutes(1),
          signingCredentials: credentials);

      return new JwtSecurityTokenHandler().WriteToken(token);
    });

export PORT=5100
curl localhost:$PORT/tokenWithRole\?role\=user

# Update the HelloWithAuthController this way
[Authorize]
[Route("[controller]")]
public class HelloWithAuthController : ControllerBase
{
  [HttpGet("")]
  public string Get()
  {
    return "Hello";
  }

  // Accessible to both user and admin roles
  [HttpGet("/helloWithUserRole")]
  [Authorize(Roles = "user,admin")]
  public string HelloWithUserRole()
  {
    return "Hello authorized user!";
  }
}

# Access /helloWithUserRole with a valid JWT token but we no role information in it
curl -v localhost:$PORT/helloWithUserRole -H "Authorization: Bearer $(curl -s localhost:$PORT/token)"
# We get 403
# A token with user or admin role works
curl -v localhost:$PORT/helloWithUserRole -H "Authorization: Bearer $(curl -s localhost:$PORT/tokenWithRole\?role\=user)"
curl -v localhost:$PORT/helloWithUserRole -H "Authorization: Bearer $(curl -s localhost:$PORT/tokenWithRole\?role\=admin)"
# The other route works with or without role in the token
curl -v localhost:$PORT/helloWithAuth -H "Authorization: Bearer $(curl -s localhost:$PORT/token)"
curl -v localhost:$PORT/helloWithAuth -H "Authorization: Bearer $(curl -s localhost:$PORT/tokenWithRole\?role\=admin)"

# Finally, add this route which is accessible only to admins
  // Accessible only to admin role
  [HttpGet("/helloWithAdminRole")]
  [Authorize(Roles = "admin")]
  public string HelloWithAdminRole()
  {
    return "Hello admin!";
  }

curl -v localhost:$PORT/helloWithAdminRole -H "Authorization: Bearer $(curl -s localhost:$PORT/token)"
# We get 403
# A token with user role also gives 403
curl -v localhost:$PORT/helloWithAdminRole -H "Authorization: Bearer $(curl -s localhost:$PORT/tokenWithRole\?role\=user)"
# Only admin role works
curl -v localhost:$PORT/helloWithAdminRole -H "Authorization: Bearer $(curl -s localhost:$PORT/tokenWithRole\?role\=admin)"

# Finally, let's add some custom data to the token and read it in the other route

    app.MapGet("/tokenWithUserInfo", (string name, string email) =>
    {
      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));
      var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

      var claims = new List<Claim>
      {
        new Claim(ClaimTypes.Name, name),
        new Claim(ClaimTypes.Email, email),
      };

      var token = new JwtSecurityToken(Configuration["Jwt:Issuer"],
          Configuration["Jwt:Audience"],
          claims,
          expires: DateTime.Now.AddMinutes(1),
          signingCredentials: credentials);

      return new JwtSecurityTokenHandler().WriteToken(token);
    });

# To use it
curl localhost:$PORT/tokenWithUserInfo\?name\=John\&email\=john@example.com
# Verify the token in jwt.io

# Let us now see how to extract the information from the token during request processing
[Authorize]
[Route("[controller]")]
public class UserController : ControllerBase
{
  [HttpGet("/helloUser")]
  public ActionResult<string> HelloUser()
  {
    var identity = HttpContext.User.Identity as ClaimsIdentity;
    if (identity != null)
    {
      var nameClaim = identity.FindFirst(ClaimTypes.Name)?.Value;
      var emailClaim = identity.FindFirst(ClaimTypes.Email)?.Value;

      return $"Hello {nameClaim}, your email is {emailClaim}";
    }
    return "User information not available";
  }
}

curl localhost:$PORT/helloUser -H "Authorization: Bearer $(curl -s localhost:$PORT/tokenWithUserInfo\?name\=John\&email\=john@example.com)"
# Token without Name and Email info
curl localhost:$PORT/helloUser -H "Authorization: Bearer $(curl -s localhost:$PORT/token)"

# Unit Testing
# The need for a test framework
# Test without a framework
public class Calculator
{
  public int Add(int x, int y)
  {
    return 0;
  }
}

public class Program
{
  public static void Main()
  {
    int success = 0, failure = 0;
    // Creating the objects that are required for the tests
    Calculator c = new Calculator();
    // Invoking the functionality that we want to test
    var result = c.Add(1, 2);
    // We are verifying if the results match our expectations
    if (result == 3)
    {
      success++;
    }
    else
    {
      // If something failed, I would like to know what failed
      failure++;
      Console.WriteLine($"Called: Add(1, 2) => Expected result: 3, got: {result}");
    }
    // Printing the results of the test
    Console.WriteLine($"Successes: {success}, Failures: {failure}");
  }
}

# Introduction to xUnit
dotnet new console -o HelloUnitTest
cd HelloUnitTest
dotnet add package xunit
dotnet add package xunit.runner.visualstudio
dotnet add package Microsoft.NET.Test.Sdk

# Add the functionality to test
Program.cs:
public class Calculator
{
  public int Add(int a, int b)
  {
    return a + b;
  }
}

# Add the tests in a separate file:
CalculatorTests.cs
using Xunit;

public class CalculatorTests
{
  [Fact]
  public void Add_ReturnsCorrectSum()
  {
    // Creating the objects (environment) that are required for running our tests
    var calculator = new Calculator();
    // Invoking the functionality and verifying (asserting) whether it matches
    // the expected results
    Assert.Equal(5, calculator.Add(2, 3));
  }
}

dotnet test
# When tests fail, we also see the reasons for the failure in the terminal

# To get more verbose test run details
dotnet test -v n

# Let us now add 2 test methods
using Xunit;

public class CalculatorTests
{
  [Fact]
  public void Add_ReturnsCorrectSumForPositives()
  {
    var calculator = new Calculator();
    Assert.Equal(5, calculator.Add(2, 3));
  }

  [Fact]
  public void Add_ReturnsCorrectSumForZeroes()
  {
    var calculator = new Calculator();
    Assert.Equal(0, calculator.Add(0, 0));
  }
}

dotnet test

# Why shouldn't we combine both into a single method:
# 1. If one assertion fails, the rest will not run (so we need to ensure that each test is about testing one thing - and if any one assertion fails that means the whole test has failed)
# 2. Every test method requires a certain environment on which the test is executed (analogy: testing the lights of the car after you have tested the airbags)

# Parameterized Tests
# Convert Fact to Theory and add "InlineData"
CalculatorTests.cs
using Xunit;

public class CalculatorTests
{
  [Theory]
  [InlineData(2, 3, 5)]
  [InlineData(0, 0, 0)]
  [InlineData(-2, -3, -5)]
  public void Add_ReturnsCorrectSum(int a, int b, int expectedSum)
  {
    var calculator = new Calculator();
    Assert.Equal(expectedSum, calculator.Add(a, b));
  }
}

dotnet test -v n

# The use of constructor to construct new objects before each test
using Xunit;

public class CalculatorTests
{
  private Calculator _calculator;
  public CalculatorTests()
  {
    Console.WriteLine("CalculatorTests constructor called");
    _calculator = new Calculator();
  }
  
  [Fact]
  public void Add_ReturnsCorrectSumForPositives()
  {
    Console.WriteLine("Add_ReturnsCorrectSumForPositives called");
    Assert.Equal(5, _calculator.Add(2, 3));
  }

  [Fact]
  public void Add_ReturnsCorrectSumForZeroes()
  {
    Console.WriteLine("Add_ReturnsCorrectSumForZeroes called");
    Assert.Equal(0, _calculator.Add(0, 0));
  }

}

dotnet test

# Running some code before and after each test method
using Xunit;

public class CalculatorTests : IDisposable
{
  private Calculator _calculator;
  public CalculatorTests()
  {
    Console.WriteLine("CalculatorTests constructor called");
    _calculator = new Calculator();
  }

  [Fact]
  public void Add_ReturnsCorrectSumForPositives()
  {
    Console.WriteLine("Add_ReturnsCorrectSumForPositives called");
    Assert.Equal(5, _calculator.Add(2, 3));
  }

  [Fact]
  public void Add_ReturnsCorrectSumForZeroes()
  {
    Console.WriteLine("Add_ReturnsCorrectSumForZeroes called");
    Assert.Equal(0, _calculator.Add(0, 0));
  }

  public void Dispose()
  {
    Console.WriteLine("Dispose called");
    _calculator = null;
  }
}

# BeforeAll and AfterAll functionality
using Xunit;

class MyFixture : IDisposable
{
  public MyFixture()
  {
    Console.WriteLine("MyFixture Constructor called");
  }

  public void Dispose()
  {
    Console.WriteLine("MyFixture Dispose called");
  }
}

public class CalculatorTests : IClassFixture<MyFixture>, IDisposable
{
    ...
}

# Creating objects in the fixture and accessing it in the test method
using Xunit;

public class MyFixture : IDisposable
{
  public Calculator Calculator { get; set; }

  public MyFixture()
  {
    Console.WriteLine("MyFixture Constructor called");
    Calculator = new Calculator();
  }

  public void Dispose()
  {
    Console.WriteLine("MyFixture Dispose called");
    Calculator = null;
  }
}

public class CalculatorTests : IClassFixture<MyFixture>, IDisposable
{
  private Calculator _calculator;
  public CalculatorTests(MyFixture fixture)
  {
    Console.WriteLine("CalculatorTests constructor called");
    _calculator = fixture.Calculator;
  }

  [Fact]
  public void Add_ReturnsCorrectSumForPositives()
  {
    Console.WriteLine("Add_ReturnsCorrectSumForPositives called");
    Assert.Equal(5, _calculator.Add(2, 3));
  }

  [Fact]
  public void Add_ReturnsCorrectSumForZeroes()
  {
    Console.WriteLine("Add_ReturnsCorrectSumForZeroes called");
    Assert.Equal(0, _calculator.Add(0, 0));
  }

  public void Dispose()
  {
    Console.WriteLine("Dispose called");
    _calculator = null;
  }
}

# Change the Calculator class to
public class Calculator
{
  public Calculator()
  {
    Console.WriteLine("Calculator constructor called");
  }

  public int Add(int a, int b)
  {
    return a + b;
  }
}

dotnet test

# Now observe that we are creating only one Calculator for the whole set of test methods
MyFixture Constructor called
Calculator constructor called
CalculatorTests constructor called
Add_ReturnsCorrectSumForPositives called
Dispose called
CalculatorTests constructor called
Add_ReturnsCorrectSumForZeroes called
Dispose called
MyFixture Dispose called

