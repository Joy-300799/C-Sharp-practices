public class HashSetPrac
{
    public static void Main()
    {
        // Create/Initialize
        var nums = new HashSet<int>();
        // Addition
        nums.Add(10);
        nums.Add(10);
        nums.Add(20);
        nums.Add(30);

        // Key existence
        Console.WriteLine($"Is 10 present: {nums.Contains(10)}");
        // Remove
        nums.Remove(10);
        // Iterate
        foreach (var num in nums)
        {
            Console.WriteLine(num);
        }

        // Fixed size arrays
        var numsArr = new[]
        {
  1,
  2,
  3
};

        Console.WriteLine(numsArr[0]);

        foreach (var num in numsArr)
        {
            Console.WriteLine(num);
        }

    }
}