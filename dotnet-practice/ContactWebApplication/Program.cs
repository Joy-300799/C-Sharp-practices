using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text;

public class Contact
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Location { get; set; }
    public int Phone { get; set; }
}


public class AppDbContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        string server = Environment.GetEnvironmentVariable("DB_SERVER");
        string user = Environment.GetEnvironmentVariable("DB_USER");
        string password = Environment.GetEnvironmentVariable("DB_PASSWORD");

        var connectionString = configuration.GetConnectionString("MyContactDatabase");
        System.Console.WriteLine(connectionString);

        connectionString = connectionString
                .Replace("{SERVER}", server)
                .Replace("{USER}", user)
                .Replace("{PASSWORD}", password);

        optionsBuilder
          .UseMySql(connectionString,
            ServerVersion.AutoDetect(connectionString))
          .LogTo(Console.WriteLine, LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Location).IsRequired();
        });
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();
        var contactIdCounter = 1;

        app.MapGet("/", () => "Jai Shree Ram");

        // Get All Conatcts
        app.MapGet("/getcontacts", () =>
        {
            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();
                var contacts = context.Contacts.ToArray();
                return contacts;
            }
        });

        // Get Contact by ID - GET
        app.MapGet("/contact/{id}", (int id) =>
        {
            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();
                var contact = context.Contacts.FirstOrDefault(contact => contact.Id == id);
                return contact == null ? Results.NotFound() : Results.Json(contact);
            }
        });

        // Create Contact - POST
        app.MapPost("/contact", (Contact newContact) =>
        {
            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();
                newContact.Id = contactIdCounter++;
                context.Contacts.Add(newContact);

                context.SaveChanges();
                return Results.Created($"/contact/{newContact.Id}", newContact);
            }
        });

        // DELETE Contact by ID
        app.MapDelete("/deletecontact/{id}", (int id) =>
        {
            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();
                var contactToRemove = context.Contacts.FirstOrDefault(contact => contact.Id == id);
                System.Console.WriteLine(contactToRemove);
                if (contactToRemove == null) return Results.NotFound($"Contact with ID {id} Not Found!");
                context.Contacts.Remove(contactToRemove);
                contactIdCounter = context.Contacts.Count();

                context.SaveChanges();
                return Results.Ok($"Contact with ID {id} deleted successfully");
            }
        });

        app.MapGet("/contacts/{name}/{location}", (string name, string location) =>
        {
            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();

                var filteredContacts = context.Contacts
                    .Where(contact => contact.Name == name && contact.Location == location)
                    .ToList();

                if (filteredContacts.Count == 0)
                {
                    return Results.NotFound("No contacts found matching the filter criteria.");
                }

                return Results.Ok(filteredContacts);
            }
        });

        app.Run();
    }
}