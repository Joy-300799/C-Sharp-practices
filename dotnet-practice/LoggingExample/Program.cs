using Microsoft.AspNetCore.Mvc;

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
        builder.Logging.AddConsole(options =>
        {
            options.FormatterName = "simple"; // Or use "json" for JSON format
        });
        builder.Services.AddControllers();
        var app = builder.Build();
        app.MapGet("/", () => "Hello World!");
        app.MapControllers();
        app.Run();
    }
}

// curl http://localhost:<port>/hello