// Getters/Setters (the Java way)
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

// The C# way
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

// Remove the "set" and now it becomes read only (only get, no set)
// This will throw an error
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
        c.Name = "John";  // Use of the setter -> throw error
        Console.WriteLine(c.Name);  // Use of the getter
    }
}

// Allowing the setting of fields during construction and only get later
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

// Automatic property
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

// Both getter/setter with automatic property
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