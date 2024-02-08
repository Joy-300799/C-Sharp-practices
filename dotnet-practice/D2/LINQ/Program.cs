// Using LINQ
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

// Better syntax with from/select
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

// Real life application
// Given a list of contacts, print their names
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

// Given a list of contacts, print the names of the people from New York
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