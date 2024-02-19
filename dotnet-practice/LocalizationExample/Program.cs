using System.Globalization;
using System.Resources;

namespace LocalizationExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var culture = args.Length > 1 ? new CultureInfo(args[1]) : CultureInfo.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            ResourceManager rm = new ResourceManager(
              "LocalizationExample.Messages", typeof(Program).Assembly);

            string userName = args.Length > 0 ? args[0] : "User";
            string localizedGreeting = string.Format(
              rm.GetString("Hello"), userName);

            Console.WriteLine(localizedGreeting);
        }
    }
}