// DbContext serves as a bridge between your .NET application and the database,
// allowing you to perform CRUD (Create, Read, Update, Delete) operations, and manage database connections and transactions.
// Equivalent of EntityManager in JPA

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text;

public class Profile
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class AppDbContext : DbContext
{
    // The DbContext provides properties, typically of type DbSet<TEntity>
    // where TEntity is an entity class mapped to a database table.
    // You use these properties to query and work with the data.
    public DbSet<Profile> Profiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        string server = Environment.GetEnvironmentVariable("DB_SERVER");
        string user = Environment.GetEnvironmentVariable("DB_USER");
        string password = Environment.GetEnvironmentVariable("DB_PASSWORD");

        // https://www.connectionstrings.com/store-and-read-connection-string-in-appsettings-json/
        var connectionString = configuration.GetConnectionString("MyDatabase");

        connectionString = connectionString
                .Replace("{SERVER}", server)
                .Replace("{USER}", user)
                .Replace("{PASSWORD}", password);

        optionsBuilder
          .UseMySql(connectionString,
            ServerVersion.AutoDetect(connectionString))
          .LogTo(Console.WriteLine, LogLevel.Information);  // For logging the queries that EF Core generates
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
        });
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        InsertData();
        PrintData();
    }

    private static void InsertData()
    {
        using (var context = new AppDbContext())
        {
            // Creates the database if not exists
            context.Database.EnsureCreated();

            var profile = new Profile
            {
                Name = "John Doe"
            };
            context.Profiles.Add(profile);

            // Saves changes
            context.SaveChanges();
        }
    }

    private static void PrintData()
    {
        using (var context = new AppDbContext())
        {
            var profiles = context.Profiles.ToArray();
            foreach (var profile in profiles)
            {
                var data = new StringBuilder();
                data.AppendLine($"Id: {profile.Id}");
                data.AppendLine($"Name: {profile.Name}");
                Console.WriteLine(data.ToString());
            }
        }
    }
}
