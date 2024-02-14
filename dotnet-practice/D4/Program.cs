//! Implement a LazyFilter and a LazyFilterMap function using yield return

namespace LazyFilterImplNonGeneric
{
    public delegate bool FilterDelegate(int a);
    public delegate int MapDelegate(int a);

    public class FuncHandler
    {
        // For yield return, need to use an iterator which is IEnumerable instead of general IList
        public static IEnumerable<int> LazyFilterMap(List<int> nums, FilterDelegate filterFunc, MapDelegate mapFunc)
        {
            foreach (var num in nums)
            {
                if (filterFunc(num))
                {
                    yield return mapFunc(num);
                }
            }
        }

        public static IEnumerable<int> LazyFilter(List<int> inputNums, FilterDelegate filterFunc)
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
            var resOfLazyFilterMap = FuncHandler.LazyFilterMap(nums, x => x % 2 == 0, x => x * x);

            Console.WriteLine("Results of LazyFilterAndMap:");
            foreach (var item in resOfLazyFilterMap)
            {
                Console.WriteLine(item); //Console the even no with squared value.
            }

            var resOfLazyFilter = FuncHandler.LazyFilter(nums, x => x % 2 == 1); // Filter out the odd nos.
            Console.WriteLine("Results of LazyFilter:");
            foreach (var num in resOfLazyFilter)
            {
                Console.WriteLine(num); // Console the odd nos from the input list.
            }
        }
    }
}


namespace LazyFiltersImplGeneric
{
    public delegate bool FilterDelegate<T>(T a);
    public delegate U MapDelegate<T, U>(T a);

    public class FuncHandler
    {
        // For yield return, need to use an iterator which is IEnumerable instead of general IList
        public static IEnumerable<U> LazyFilterMap<T, U>(IList<T> nums, FilterDelegate<T> filterFunc, MapDelegate<T, U> mapFunc)
        {
            foreach (var num in nums)
            {
                if (filterFunc(num))
                {
                    yield return mapFunc(num);
                }
            }
        }

        public static IEnumerable<T> LazyFilter<T>(IList<T> inputNums, FilterDelegate<T> filterFunc)
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

            Console.WriteLine("Results of LazyFilterAndMap:");
            foreach (var item in FuncHandler.LazyFilterMap(nums, x => x % 2 == 0, x => x * x))
            {
                Console.WriteLine(item); // Console the even numbers with squared value.
            }

            Console.WriteLine("Results of LazyFilter:");
            foreach (var num in FuncHandler.LazyFilter(nums, x => x % 2 == 1))
            {
                Console.WriteLine(num); // Console the odd numbers from the input list.
            }
        }
    }
}


// Activity - 
// Implement the LazyFilter and LazyMap to work with IEnumerable as input and implement them as 2 separate methods and use them in sequence
// Call the two funtion in chain

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
            var resOfLazyMap = FuncHandler.LazyMap(FuncHandler.LazyFilter(nums, x => x % 2 == 1), x => x * x);

            Console.WriteLine("Results of LazyMap:");
            foreach (var item in resOfLazyMap)
            {
                Console.WriteLine(item); //Console the nos with squared value.
            }
        }
    }
}