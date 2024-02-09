namespace MyNamespace
{
    public delegate bool FilterDelegate(int a);
    public delegate int MapDelegate(int a);

    public class FuncHandler
    {
        public static IList<int> FilterAndMap(List<int> nums, FilterDelegate filterFunc, MapDelegate mapFunc)
        {
            List<int> filteredData = new List<int>();
            foreach (var num in nums)
            {
                if (filterFunc(num)) // if the int is even no., then squaring it.
                {
                    filteredData.Add(mapFunc(num));
                }
            }

            return filteredData;
        }
    }
    public class Program
    {
        public static void Main()
        {
            var nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var res = FuncHandler.FilterAndMap(nums, x => x % 2 == 0, x => x * x);

            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }
    }
}

//! Output: [4, 16, 36, 64, 100];
