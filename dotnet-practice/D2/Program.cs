public delegate int FilterFunc(int x);
public class Program
{
    public static IList<int> MyFilter(IList<int> inputList, FilterFunc filter)
    {
        IList<int> outputList = new List<int>();
        foreach (var num in inputList)
        {
            int filteredValue = filter(num);
            if (filteredValue != 0) // Only add to output list if the filter returned a non-zero value
            {
                outputList.Add(filteredValue);
            }
        }
        return outputList;
    }

    public static void Main()
    {
        var nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var oddNums = new List<int>();
        foreach (var num in MyFilter(nums, x =>
        {
            if (x % 2 == 1)
            {
                return x;
            }
            return 0; //Default value returning to fulfill the lambda expression
        }
            ))
        {
            Console.WriteLine(num);
        }
    }
}