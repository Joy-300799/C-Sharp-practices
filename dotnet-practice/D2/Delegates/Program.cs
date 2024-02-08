// First class functions
// Functional Interfaces in Java
// https://www.baeldung.com/java-8-functional-interfaces

// Delegates are like function pointers

// Assigning functions to variables
public delegate int Add(int x, int y);

public class Program
{
    private static int Sum(int x, int y)
    {
        return x + y;
    }
    public static void Main()
    {
        Add add = Sum;
        Console.WriteLine(add(2, 3));
    }
}

// We assign the "function" Sum to add
// The type of "add" must be a delegate
// The delegate's signature must match the function's signature assigned to it

// Passing functions to functions
public class Calculator
{
    public int Add(int x, int y)
    {
        return x + y;
    }

    public int Subtract(int x, int y)
    {
        return x - y;
    }
}

public delegate int Operation(int x, int y);
public class Program
{
    public static void ExecuteOperation(int x, int y, Operation op)
    {
        Console.WriteLine(op(x, y));
    }

    public static void Main()
    {
        var c = new Calculator();
        ExecuteOperation(2, 3, c.Add);
        ExecuteOperation(2, 3, c.Subtract);
    }
}

// Returning functions from functions
// When returning a function from a function, the return type is the delegate type
public delegate void Bar();

public class Program
{
    public static Bar Foo()
    {
        void BarImpl()
        {
            Console.WriteLine("Bar");
        }
        return BarImpl;
    }
    public static void Main()
    {
        var x = Foo();
        x();
    }
}

// This is also perfectly valid
public class MainHandler
{
    public static void Main()
    {
        Foo()();
    }
}

// Lambda functions
// Assigning functions to variables
public delegate int Add(int x, int y);

public class Program
{
    public static void Main()
    {
        Add add = (int x, int y) => x + y;
        Console.WriteLine(add(2, 3));
    }
}

// Lambda functions can be multiple lines (in which case, put the lines in {})
public delegate int Add(int x, int y);

public class Program
{
    public static void Main()
    {
        Add add = (int x, int y) =>
        {
            var tmp = x + y;
            return tmp;
        };
        Console.WriteLine(add(2, 3));
    }
}

// Passing functions to functions
public delegate int Operation(int x, int y);

public class Program
{
    public static void ExecuteOperation(int a, int b, Operation op)
    {
        var result = op(a, b);
        Console.WriteLine("Result: " + result);
    }
    public static void Main()
    {
        ExecuteOperation(1, 2, (int x, int y) => x + y);
        ExecuteOperation(10, 20, (int x, int y) => x * y);
    }
}

// Returning functions from functions
public delegate void Bar();

public class Program
{
    public static Bar Foo()
    {
        return () =>
        {
            Console.WriteLine("Bar");
        };
    }
    public static void Main()
    {
        Foo()();
    }
}

// Event Handlers with "event" - an implementation of the observer pattern
public class Button // An object
{
    public event EventHandler OnClick;

    public void Click() // Events that occur on this object
    {
        OnClick?.Invoke(this, EventArgs.Empty);
    }
}

public class UserInterface
{
    public static void Main()
    {
        Button button = new Button();
        button.OnClick += EventHandler1;    // When the event occurs, do this
        button.OnClick += EventHandler2;
        button.Click();
    }

    private static void EventHandler1(object sender, EventArgs e)
    {
        Console.WriteLine("Running event handler 1!");
    }

    private static void EventHandler2(object sender, EventArgs e)
    {
        Console.WriteLine("Running event handler 2!");
    }
}


// An implementation of Map using delegates
public delegate int Func(int x);
public class Program
{
    public static IList<int> MyMap(IList<int> inputList, Func func)
    {
        IList<int> outputList = new List<int>();
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
        foreach (var num in MyMap(nums, x => x * x * x))
        {
            Console.WriteLine(num);
        }
    }
}