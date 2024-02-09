// Hashcodes and the concept of equality
// Hashcodes of class instances
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

//! Hashcode of c2 is different from c1 and remains constant even after name change

//? ----------------------------------------------------------------

// # Hashcodes of struct instances
struct Contact
{
    public string? Name { get; set; }
}

public class Program
{
    public static void Main()
    {
        // due to the same content irrespective of the different set of variables it assumes all the objects as ame.
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

//! RECORDS
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