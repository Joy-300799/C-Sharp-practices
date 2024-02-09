// Given a list of numbers that are currently string types, convert them to int
var numsAsStrings = new List<string>
{
  "1", "2", "3"
};
foreach (var num in numsAsStrings.Select(Int32.Parse))
{
    Console.WriteLine(num);
}

// Given a list of names, generate emails for them
var usernames = new List<string>
{
  "John", "Goerge", "Dan"
};

foreach (var num in usernames.Select(name => name + "@example.com"))
{
    Console.WriteLine(num);
}

// Filter
var nums = new List<int> { 1, 2, 3, 4, 5 };
foreach (var num in nums.Where(num => num % 2 == 1))
{
    Console.WriteLine(num);
}

//! OR
var nums = new List<int> { 1, 2, 3, 4, 5 };

foreach (var num in from num in nums where num % 2 == 1 select num)
{
    Console.WriteLine(num);
}

// Given a list of contacts, get me the contacts from New York
public class Contact
{
    public string Name { get; set; }
    public string Location { get; set; }

    public override string ToString()
    {
        return $"Contact({Name}, {Location})";
    }
}
public class Program
{
    public static void Main()
    {
        var contacts = new List<Contact>
    {
      new Contact { Name = "John", Location = "New York"},
      new Contact { Name = "George", Location = "London"},
      new Contact { Name = "Bob", Location = "San Francisco"},
    };
        // Storing the entire contact
        var contactsFromNY = contacts.Where(contact => contact.Location == "New York");

        //! OR 

        // Storing only name
        var contactsFromNY = contacts.Where(contact => contact.Location == "New York").Select(contact => contact.Name);

        foreach (var contact in contactsFromNY)
        {
            Console.WriteLine(contact);
        }
    }
}

// Using filters and maps in sequence
var nums = new List<int> { 1, 2, 3, 4, 5 };

var squares = nums
  .Where(num => num % 2 == 1)
  .Select(num => num * num);

foreach (var num in squares)
{
    Console.WriteLine(num);
}

// Clauses can repeat
// Get the me squares of the numbers that are divisible by 2 and 3
var nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
var squares = from num in nums
              where num % 2 == 0
              where num % 3 == 0
              select num * num;
foreach (var s in squares)
{
    Console.WriteLine(s);
}

// Join
// Given a list of contacts and a list of cities with countries, get me the contact names and their cities
public class Contact
{
    public string? Name { get; set; }
    public string? City { get; set; }
}

public class Country
{
    public string? City { get; set; }
    public string? CountryName { get; set; }
}

public class ContactWithCountry
{
    public string? ContactName { get; set; }
    public string? Country { get; set; }

    public override string ToString()
    {
        return $"Contact: {ContactName}, Country: {Country}";
    }
}

public class Program
{
    public static void Main()
    {
        //Setting up the data

        List<Contact> contacts = new List<Contact>
        {
            new Contact { Name = "Alice", City = "New York" },
            new Contact { Name = "Bob", City = "Paris" },
            new Contact { Name = "Charlie", City = "London" }
        };

        //Setting up the data
        List<Country> countries = new List<Country>
        {
            new Country { City = "New York", CountryName = "USA" },
            new Country { City = "Paris", CountryName = "France" },
            new Country { City = "London", CountryName = "UK" }
        };

        // Querying in the data to get the stuffs matching County's city with Contact's city.
        var contactsWithCountries = from contact in contacts
                                    join country in countries on contact.City equals country.City
                                    select new ContactWithCountry
                                    {
                                        ContactName = contact.Name,
                                        Country = country.CountryName
                                    };

        // Anonymous Type
        var contactsWithCountries = from contact in contacts
                                    join country in countries on contact.City equals country.City
                                    select new // Anonymous type
                                    {
                                        ContactName = contact.Name,
                                        Country = country.CountryName
                                    };
        foreach (var c in contactsWithCountries)
        {
            Console.WriteLine(c);
        }
    }
}

//* Value Types
//? https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/types#83-value-types
//? https://learn.microsoft.com/en-us/dotnet/api/system.valuetype?view=net-8.0

//! Value types are either stack-allocated or allocated inline in a structure. Reference types are heap-allocated.

//? Numeric types and Booleans are "struct" types
