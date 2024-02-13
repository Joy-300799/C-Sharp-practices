// Reflection
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

// Invoke constructor with one parameter using reflection
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

// Choosing between multiple constructors
namespace MultipleConstructors
{
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
}
