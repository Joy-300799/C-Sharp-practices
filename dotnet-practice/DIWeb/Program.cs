public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddScoped<IDBManager, MySQLDBManager>();
        builder.Services.AddScoped<LoginManager>();
        builder.Services.AddControllers();
        var app = builder.Build();
        app.MapControllers();
        app.Run();
    }
}