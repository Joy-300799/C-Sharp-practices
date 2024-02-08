// Arrays are basically part of Collections hierarchy
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/arrays#1723-arrays-and-the-generic-collection-interfaces

public class Program
{
    public static void Main()
    {
        int[] nums = new int[5]
        {
      1, 2, 3, 4, 5
        };
        IList<int> numsList = nums;
        numsList[0] = 10;
        Console.WriteLine(numsList[0]);

        //Cannot increase the fixed array's size
        numsList.Add(10);
    }
}

// The last line will give us this exception
// Unhandled exception. System.NotSupportedException: Collection was of a fixed size.
