// Asynchronous programming
// async/await
using System;
using System.IO;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main()
    {
        string filePath = "/etc/shadow";

        try
        {
            string fileContent = await ReadFileAsync(filePath);
            Console.WriteLine(fileContent);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    public static async Task<string> ReadFileAsync(string filePath)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            return await reader.ReadToEndAsync();
        }
    }
}

// Also try this
Task<string> readFileTask = ReadFileAsync(filePath);
Console.WriteLine("This line executes before reading the file");
string fileContent = await readFileTask;

// yield return
public class Program
{
    static IEnumerable<int> GetNumbers()
    {
        Console.WriteLine("Beginning of Method");
        yield return 1;
        Console.WriteLine("After yielding 1 but before yielding 2");
        yield return 2;
        Console.WriteLine("After yielding 2 but before yielding 3");
        yield return 3;
    }
    public static void Main()
    {
        foreach (var num in GetNumbers())
        {
            Console.WriteLine(num);
        }
    }
}

// Indexer
namespace MyIndexer
{
    public class ShoppingCart
    {
        private int[] prices = new int[10];

        public int this[int index]
        {
            get { return this.prices[index]; }
            set { this.prices[index] = value; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var cart = new ShoppingCart();
            cart[0] = 100;
            Console.WriteLine(cart[0]);
        }
    }
}