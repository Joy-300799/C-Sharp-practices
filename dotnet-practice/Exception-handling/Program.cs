public class Program1
{
    public static void Main()
    {
        List<int> list = null;
        list.Add(10);
        Console.WriteLine("And then do this");
    }
}

// # We get a runtime error and the program exits abruptly
// # Check the exit code after you run
// dotnet run
// echo $? -> to get the last executed line and some details of the error occured.

// # Let us "handle" the exception
public class Program2
{
    public static void Main()
    {
        try
        {
            List<int> list = null;
            list.Add(10);
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("An exception occurred and we can't serve you at the moment");
        }
    }
}


// # Null conditional
public class Program
{
    public static void Main()
    {
        List<int> list = null;
        list?.Add(10);
    }
}