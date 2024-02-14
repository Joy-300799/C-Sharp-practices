// # Dependency Injection
// # Manual dependency injection management

using Microsoft.Extensions.DependencyInjection;

public interface IDBManager
{
    string GetPasswordFromDB(string username);
}

public class MySQLDBManager : IDBManager
{
    public string GetPasswordFromDB(string username)
    {
        // Dummy implementation
        if (username == "john")
            return "johnpwd";
        return "";
    }
}
public class LoginManager
{
    private IDBManager _dbManager;

    public LoginManager(IDBManager dBManager)
    {
        _dbManager = dBManager;
    }

    public bool Login(string username, string password)
    {
        string passwordFromDB = _dbManager.GetPasswordFromDB(username);
        return passwordFromDB == password;
    }
}

public class Program
{
    public static void Main()
    {
        var services = new ServiceCollection();
        services.AddScoped<IDBManager, MySQLDBManager>();
        services.AddScoped<LoginManager>();

        var serviceProvider = services.BuildServiceProvider();
        var loginManager = serviceProvider.GetService<LoginManager>();

        Console.WriteLine(loginManager?.Login("john", "johnpwd"));
        Console.WriteLine(loginManager?.Login("george", "georgepwd"));
    }
}