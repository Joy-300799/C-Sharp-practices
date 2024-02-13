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
.Select(num => num \* num);

foreach (var num in squares)
{
Console.WriteLine(num);
}

OR

var nums = new List<int> { 1, 2, 3, 4, 5 };

var squares = from num in nums
where num % 2 == 1
select num \* num;

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
select num \* num;
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
