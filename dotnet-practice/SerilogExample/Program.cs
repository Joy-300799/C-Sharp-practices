using Microsoft.AspNetCore.Mvc;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

[Route("[controller]")]
public class HelloController : ControllerBase
{
    private readonly ILogger<HelloController> _logger;

    public HelloController(ILogger<HelloController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public string Index()
    {
        _logger.LogTrace("This is a Trace log");
        _logger.LogDebug("This is a Debug log");
        _logger.LogInformation("This is an Information log");
        _logger.LogWarning("This is a Warning log");
        _logger.LogError("This is an Error log");
        _logger.LogCritical("This is a Critical log");
        return "Hello world!";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        Log.Logger = new LoggerConfiguration()
          .MinimumLevel.Verbose()
          .MinimumLevel.Override("Microsoft", LogEventLevel.Information) // Override for Microsoft namespace
          .MinimumLevel.Override("System", LogEventLevel.Verbose) // Override for System namespace
          .Enrich.FromLogContext()
          .WriteTo.Console(
            theme: AnsiConsoleTheme.Sixteen,
            outputTemplate:
              "[{Timestamp:HH:mm:ss} {Level:u3}] => {Message:lj}{NewLine}{Exception}"
          )
          .WriteTo.File("logs/myapp.log", rollingInterval: RollingInterval.Day)
          .CreateLogger();
        builder.Host.UseSerilog();
        builder.Services.AddControllers();
        var app = builder.Build();
        app.MapGet("/", () => "Hello World!");
        app.MapControllers();
        app.Run();
    }
}

// dotnet run
// curl localhost:<port>/hello