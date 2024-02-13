// Throwing an exception
public class Program
{
    public static void Foo()
    {
        throw new Exception("Exception occurred!");
    }
    public static void Main()
    {
        Foo();
    }
}

// The above programs crashes with a non-zero exit code because the caller hasn't handled the exception
// We don't have to necessarily catch an exception (in this case we get a runtime error and not a compile time error)

// Handling exceptions
public class Program
{
    public static void Foo()
    {
        // Callee is supposed to "throw" exceptions when
        // exceptional situations occur (contract cannot be satisfied)
        throw new Exception("Exception occurred!");
    }
    public static void Main()
    {
        try
        {
            // Call the method that could possibly throw exceptions
            Foo();  // Caller is supposed to handle the exception
        }
        catch (Exception e)
        {
            // Handle the exception if it occurs
            Console.WriteLine(e.Message);
        }
    }
}

//# Custom exceptions
public class MyException : Exception
{
    public MyException(string message) : base(message)
    {

    }
}
public class Program
{
    public static void Foo()
    {
        throw new MyException("Exception occurred!");
    }
    public static void Main()
    {
        try
        {
            Foo();
        }
        catch (MyException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

//! Multiple catch blocks
public class MyException : Exception
{
    public MyException(string message) : base(message)
    {

    }
}
public class Program
{
    public static void Foo()
    {
        throw new MyException("Exception occurred!");
    }
    public static void Main()
    {
        try
        {
            Foo();
        }
        catch (MyException)
        {
            Console.WriteLine("My exception thrown");
        }
        catch (Exception)
        {
            Console.WriteLine("Generic exception thrown");
        }
    }
}

// Flow of events
public class NegativeNumberException : Exception
{
}
public class Program
{
    public static int Foo(int x)
    {
        if (x < 0)
            throw new NegativeNumberException();
        else if (x == 0)
            throw new Exception("x is 0");
        else
            return x;
    }
    public static void Main()
    {
        try
        {
            var x = Foo(0);
            Console.WriteLine(x);
        }
        catch (NegativeNumberException)
        {
            Console.WriteLine("Negative number exception thrown");
        }
        catch (Exception)
        {
            Console.WriteLine("Generic exception thrown");
        }
        finally
        {
            Console.WriteLine("Always runs");
        }
    }
}

// First try with Foo(5)
// Then try with Foo(0)
// Then try with Foo(-1)

// Why do we need finally? Will the statements after the try/catch not always run?
public class NegativeNumberException : Exception
{
}
public class Program
{
    public static int Foo(int x)
    {
        if (x < 0)
            throw new NegativeNumberException();
        else if (x == 0)
            throw new Exception("x is 0");
        else
            return x;
    }
    public static void Main()
    {
        try
        {
            var x = Foo(-1);
            Console.WriteLine(x);
        }
        catch (NegativeNumberException)
        {
            Console.WriteLine("Negative number exception thrown");
        }
        catch (Exception)
        {
            Console.WriteLine("Generic exception thrown");
        }
        Console.WriteLine("Always runs");
    }
}

// The difference is when we have a throw in the catch
public class NegativeNumberException : Exception
{
}
public class Program
{
    public static int Foo(int x)
    {
        if (x < 0)
            throw new NegativeNumberException();
        else if (x == 0)
            throw new Exception("x is 0");
        else
            return x;
    }
    public static void Main()
    {
        try
        {
            var x = Foo(-1);
            Console.WriteLine(x);
        }
        catch (NegativeNumberException)
        {
            Console.WriteLine("Negative number exception thrown");
            throw;
        }
        catch (Exception)
        {
            Console.WriteLine("Generic exception thrown");
            throw;
        }
        Console.WriteLine("Always runs");
    }
}

// Now we see that "Always runs" is not printed
// finally always runs

public class NegativeNumberException : Exception
{
}
public class Program
{
    public static int Foo(int x)
    {
        if (x < 0)
            throw new NegativeNumberException();
        else if (x == 0)
            throw new Exception("x is 0");
        else
            return x;
    }

    public static void FooCaller()
    {
        try
        {
            var x = Foo(-1);
            Console.WriteLine(x);
        }
        catch (NegativeNumberException e)
        {
            Console.WriteLine("Negative number exception thrown");
            throw e;
        }
        catch (Exception e)
        {
            Console.WriteLine("Generic exception thrown");
            throw e;
        }
        finally
        {
            Console.WriteLine("Always runs");
        }
    }
    public static void Main()
    {
        try
        {
            FooCaller();
        }
        catch (System.Exception)
        {
            // Silence
        }
    }
}

//# Exception filters
public class Program
{
    public static void Foo(int num)
    {
        if (num < 10)
            throw new Exception("num < 10");
        else
            throw new Exception("num >= 10");
    }
    public static void Main()
    {
        try
        {
            Foo(50);
        }
        catch (Exception e) when (e.Message.Contains(">"))
        {
            Console.WriteLine($"First block: {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Another block: {e.Message}");
        }
    }
}