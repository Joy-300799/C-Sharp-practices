using MathLibNamespace;

public class Program
{
    public static void Main()
    {
        var m = new MathLibClass();
        Console.WriteLine(m.Add(2, 3));
    }
}

// dotnet add reference ../MathLib/MathLib.csproj  --> to add the reference in csproj file