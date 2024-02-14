// Activity - 
// Implement the LazyFilter and LazyMap to work with IEnumerable as input and implement them as 2 separate methods and use them in sequence

namespace LazyFilterAndMapImpl
{

    public class FuncHandler
    {
        // For yield return, need to use an iterator which is IEnumerable instead of general IList
        public static IEnumerable<int> LazyMap(IEnumerable<int> nums, Func<int, int> mapFunc)
        {
            foreach (var num in nums)
            {
                yield return mapFunc(num);
            }
        }

        public static IEnumerable<int> LazyFilter(IEnumerable<int> inputNums, Func<int, bool> filterFunc)
        {
            foreach (var num in inputNums)
            {
                if (filterFunc(num))
                {
                    yield return num;
                }
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            var nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var resOfLazyMap = FuncHandler.LazyMap(FuncHandler.LazyFilter(nums, x => x % 2 == 1), nums, x => x * x);

            Console.WriteLine("Results of LazyMap:");
            foreach (var item in resOfLazyMap)
            {
                Console.WriteLine(item); //Console the nos with squared value.
            }

            // var resOfLazyFilter = FuncHandler.LazyFilter(nums, x => x % 2 == 1); // Filter out the odd nos.
            // Console.WriteLine("Results of LazyFilter:");
            // foreach (var num in resOfLazyFilter)
            // {
            //     Console.WriteLine(num); // Console the odd nos from the input list.
            // }
        }
    }
}