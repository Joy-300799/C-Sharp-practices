//# null conditional and null coalescing
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