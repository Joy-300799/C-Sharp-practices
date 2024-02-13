# Throwing an exception

```
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
```

# The above programs crashes with a non-zero exit code because the caller hasn't handled the exception

# We don't have to necessarily catch an exception (in this case we get a runtime error and not a compile time error)

# Handling exceptions

```
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
Foo(); // Caller is supposed to handle the exception
}
catch (Exception e)
{
// Handle the exception if it occurs
Console.WriteLine(e.Message);
}
}
}
```

# Custom exceptions

```
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
```

# Multiple catch blocks

```
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
```

# Flow of events

```
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
```

## First try with Foo(5)

## Then try with Foo(0)

## Then try with Foo(-1)

### Why do we need finally? Will the statements after the try/catch not always run?

```
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
```

# The difference is when we have a throw in the catch

```
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
```

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
foreach (var num in MyMap(nums, x => x \* x))
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
return (T)constructor.Invoke(new object[] { param }); // Generally speaking a Constructor can take variable number of input arguments
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
