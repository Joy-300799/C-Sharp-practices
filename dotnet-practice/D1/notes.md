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
