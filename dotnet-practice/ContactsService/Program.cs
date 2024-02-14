public class Contact
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        var contacts = new List<Contact>
    {
      new Contact { Id = 1, Name = "John", Email = "john@example.com" },
      new Contact { Id = 2, Name = "George", Email = "george@example.com" },
    //   new Contact { Id = 3, Name = "Bob", Email = "bob@example.com" },
    };

        app.MapGet("/", () => "Hello World!!!");

        app.MapGet("/contacts", () => contacts);
        app.MapGet("/contact/{id}", (int id) =>
        {
            var contact = contacts.FirstOrDefault(c => c.Id == id);
            return contact == null ? Results.NotFound() : Results.Json(contact);
        });

        // Let us add a POST method to create a new contact
        var contactIdCounter = 3;
        app.MapPost("/contact", (Contact newContact) =>
        {
            newContact.Id = contactIdCounter++;
            contacts.Add(newContact);
            return Results.Created($"/contact/{newContact.Id}", newContact);
        });

        // Implement PUT and DELETE
        app.MapPut("/contact/{id}", (int id, Contact updatedContact) =>
        {
            var index = contacts.FindIndex(c => c.Id == id);
            if (index == -1) return Results.NotFound();
            updatedContact.Id = id;
            contacts[index] = updatedContact;
            return Results.NoContent();
        });

        app.MapDelete("/contact/{id}", (int id) =>
        {
            var index = contacts.FindIndex(c => c.Id == id);
            if (index == -1) return Results.NotFound();
            contacts.RemoveAt(index);
            return Results.Ok();
        });

        app.Run();
    }
}