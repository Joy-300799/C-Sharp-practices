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

// # Namespace hierarchies
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


// # Another way is to describe the hierarchy with "dot"
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