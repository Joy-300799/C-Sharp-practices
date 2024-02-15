using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables();

IConfigurationRoot configuration = builder.Build();

var apiKey = configuration?["API_KEY_FROM_ENV"];
Console.WriteLine($"API Key From Env: {apiKey}");
