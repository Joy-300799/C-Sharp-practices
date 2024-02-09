// # Structs
// # Let us start with a class
class Contact1
{
    public string? Name { get; set; }
}

public class Program1
{
    public static void Main()
    {
        Contact c = new Contact { Name = "John" };
        Console.WriteLine($"{c.Name}");
    }
}

// # The Contact object that c refers to is in heap

// # Change the keyword class to struct
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

//? https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/structs
//* Structs are similar to classes in that they represent data structures that can contain data members and function members.
//* However, unlike classes, structs are value types and do not require heap allocation. A variable of a struct type directly contains the data of the struct,
//* whereas a variable of a class type contains a reference to the data, the latter known as an object.


// Structs can also have methods like classes
struct Contact
{
    public string? Name { get; set; }

    public readonly void PrintName()
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


// Reference equality v/s Value equality
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

// Compare the above to
class Contact2
{
    public string? Name { get; set; }
}

public class Program2
{
    public static void Main()
    {
        Contact2 c1 = new Contact2 { Name = "John" };
        Contact2 c2 = c1;
        Console.WriteLine(c1 == c2);
    }
}

//*----------------------------------------------------------------

// .Equals is typically used for value equality
// The default .Equals is ==, but we can override it
class Cntact5
{
    public string? Name { get; set; }
}

public class Program5
{
    public static void Main()
    {
        Cntact5 c1 = new Cntact5 { Name = "John" };
        Cntact5 c2 = new Cntact5 { Name = "John" };
        Console.WriteLine(c1.Equals(c2));
    }
}

// # But we can override it
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

    public override int GetHashCode()
    {
        throw new NotImplementedException();
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