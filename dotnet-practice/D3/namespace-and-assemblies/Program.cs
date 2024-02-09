// # While Namespaces are not mandatory, it is recommended that you place your classes in Namespaces
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

// A single Program.cs with multiple Namespaces and use of classes from other namespaces
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

// By using the Utils

using Namespace1;

namespace MyNamespace
{
    public class App
    {
        public static void Main()
        {
            new Namespace1.Class1().SayHello();  //!We can also use full name references instead of "using"
            new Namespace1.Class2().SayHello();
        }
    }
}

// # If we want to use "using", we should ensure there is no ambiguity
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

// # But this would throw an error:
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

// # One way to solve this is with aliases
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