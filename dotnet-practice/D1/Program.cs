//Fizz Buzz
/* Fizz Buzz Problem states that given an integer n,
 for every integer i <= n, the task is to print “FizzBuzz” if i is divisible by 3 and 5,
 “Fizz” if i is divisible by 3, “Buzz”,
 if i is divisible by 5 or i (as a string) if none of the conditions are true.
**/

for (int i = 1; i <= 100; i++)
{
    if (i % 3 == 0 && i % 5 == 0)
    {
        Console.WriteLine("FizzBuzz");
    }
    else if (i % 3 == 0)
    {
        Console.WriteLine("Fizz");
    }
    else if (i % 5 == 0)
    {
        Console.WriteLine("Buzz");
    }
    else
    {
        Console.WriteLine(i);
    }
}


// Identify the duplicate numbers from the List and print them.
IList<int> numbers = [1, 2, 3, 1, 2, 4, 5, 6];

// Creating object to store unique keys and their counts as appearance
Dictionary<int, int> numsOccurance = new Dictionary<int, int>();
foreach (int num in numbers)
{
    if (numsOccurance.ContainsKey(num)) { numsOccurance[num]++; }
    else { numsOccurance[num] = 1; }
}


foreach (var attribute in numsOccurance)
{
    if (attribute.Value > 1)
    {
        Console.WriteLine(attribute.Key);
    }
}