using System.Globalization;

namespace GlobalizationExample
{
  class Program
  {
    static void Main(string[] args)
    {
      // Set the culture to a specific culture, e.g., "en-US" or "fr-FR"
      // You can also use CultureInfo.CurrentCulture for the system's current culture
      var culture = args.Length > 0 ? new CultureInfo(args[0]) : CultureInfo.CurrentCulture;
      Thread.CurrentThread.CurrentCulture = culture;
      Thread.CurrentThread.CurrentUICulture = culture;

      // Display a date (d means short-date pattern)
      // Try en-IN to see dd/mm/yyyy format
      Console.WriteLine($"Current Date: {DateTime.Now:d}");
      // Try with de-DE or ar-SA to see other variations
      Console.WriteLine($"Current Time: {DateTime.Now.ToString("T")}");
      Console.WriteLine($"Current Date and Time: {DateTime.Now.ToString("yyyy-MM-dd HH:mm")}");

      // Display a number with formatting (N2 means number with 2 decimals)
      double sampleNumber = 1234567890.12;
      Console.WriteLine($"Formatted Number: {sampleNumber:N2}");
    }
  }
}