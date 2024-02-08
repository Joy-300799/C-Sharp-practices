// int is System.Int32
int i = 10;
int j = 20;
Console.WriteLine(i + j);

Console.WriteLine(typeof(int));

bool IsPresent = true;
Console.WriteLine(IsPresent);

// string is System.String
string Name = "John";
Console.WriteLine(typeof(string));
Console.WriteLine(Name);

// var is a convenience to declare a variable (but these are statically typed) & can't be overriden
var a = 10;
// a = "Hello"; // Compile time error
Console.WriteLine(a);

// There is a dynamic type
dynamic b = 10;
Console.WriteLine(i);
b = "Hello";
Console.WriteLine(b);

// Another example
var map = new Dictionary<string, List<string>>();

// String interpolation
int Age = 10;
string nameNew = "John";
Console.WriteLine($"{nameNew}'s age is {Age}");

// Verbatim strings
string s = @"Hello\nWorld";
Console.WriteLine(s);