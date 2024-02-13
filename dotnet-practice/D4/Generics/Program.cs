// Generics
// This gives a compile time error
var l = new List<int>();
l.Add("John");

// How is this class "List" implemented

// A method "Add" that takes either 2 ints or 2 strings as input and performs + on them
public class Program
{
    public static T Add<T>(T x, T y)
    {
        if (typeof(T) == typeof(int))
        {
            return (T)(object)(Convert.ToInt32(x) + Convert.ToInt32(y));
        }
        if (typeof(T) == typeof(string))
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

// Generic implementation of MyMap
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

// There are already "Func" delegates defined in C//
// So remove the first line of the above code and it should still work
// public delegate U Func<T, U>(T x);
https://learn.microsoft.com/en-us/dotnet/api/system.func-2?view=net-8.0

// Generic type constraints
where T: class: Specifies that the generic type parameter T must be a reference type (class).
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

// Extension methods
// Extending the functionality of classes (even built-in classes)
// Requires the functionality to be a static method in a static class
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