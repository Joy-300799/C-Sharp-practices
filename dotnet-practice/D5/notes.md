# ASP.NET

https://dotnet.microsoft.com/en-us/learn/aspnet/what-is-aspnet

# ASP.NET Core

```
dotnet new web -o ContactsService
```

## Open Program.cs

### var builder = WebApplication.CreateBuilder(args);

### args here are command line arguments

### Builders are what are used to create and configure objects

### Builder pattern

https://en.wikipedia.org/wiki/Builder_pattern

# Response

https://developer.mozilla.org/en-US/docs/Glossary/Response_header

dotnet run

# The port where it runs is mentioned in the output

# Access the application at http://localhost:<port>/

```
curl localhost:<port>
curl -v localhost:<port>
```

# Observe the Request and Response headers

^C

```
dotnet watch run
```

## Make a modification in / handler - Change to Hello World!!!

### Automatic serialization ability

```
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
      new Contact {Id=1, Name="John", Email="john@example.com"},
      new Contact {Id=2, Name="George", Email="george@example.com"},
    };

    app.MapGet("/", () => "Hello World!!!");

    app.MapGet("/contacts", () => contacts);

    app.Run();
  }
}
```

# We may have to reload the application (in Terminal 1) by pressing Y

# Then do the curl

curl -v localhost:<port>/contacts

# Observe that the content type in the response has been set to Content-Type: application/json

# It has also automatically serialized by Contacts list to a JSON

```
  app.MapGet("/contact/{id}", (int id) =>
 {
   var contact = contacts.FirstOrDefault(c => c.Id == id);
   return contact != null ? Results.Json(contact) : Results.NotFound();
 });
```

# Access the path at

```
curl -v http://localhost:<port>/contact/1
curl -v http://localhost:<port>/contact/3
```

# Let us add a POST method to create a new contact

```
var contactIdCounter = 3;

 app.MapPost("/contacts", (Contact newContact) =>
  {
    newContact.Id = contactIdCounter++;
    contacts.Add(newContact);
    return Results.Created($"/contact/{newContact.Id}", newContact);
  });

export PORT=5199
curl -v -X POST http://localhost:$PORT/contacts \
-H "Content-Type: application/json" \
-d "{\"Name\": \"John Doe\", \"Email\": \"johndoe@example.com\"}"
```

# Observe the following Request/Response

# Request

> POST /contacts HTTP/1.1
> Content-Type: application/json

# Response

< HTTP/1.1 201 Created
< Content-Type: application/json; charset=utf-8
< Location: /contact/3

{"id":3,"name":"John Doe","email":"johndoe@example.com"}

# Get the newly constructed resource

curl -v http://localhost:$PORT/contact/3

## Implement PUT and DELETE

```
    app.MapPut("/contact/{id}", (int id, Contact updatedContact) =>
    {
      var index = contacts.FindIndex(c => c.Id == id);
      if (index == -1) return Results.NotFound();
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
```

curl -v -X PUT http://localhost:$PORT/contact/1 \
-H "Content-Type: application/json" \
-d "{\"Id\": 1, \"Name\": \"Jane Doe\", \"Email\": \"janedoe@example.com\"}"

> PUT /contact/1 HTTP/1.1
> Content-Type: application/json

< HTTP/1.1 204 No Content

curl -v http://localhost:$PORT/contact/1

curl -v -X DELETE http://localhost:$PORT/contact/1

> DELETE /contact/1 HTTP/1.1

< HTTP/1.1 200 OK

curl -v http://localhost:$PORT/contact/1

< HTTP/1.1 404 Not Found

# Here is the full code

```
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
      new Contact {Id=1, Name="John", Email="john@example.com"},
      new Contact {Id=2, Name="George", Email="george@example.com"},
    };

    var contactIdCounter = 3;

    app.MapGet("/contacts", () => contacts);

    app.MapGet("/contact/{id}", (int id) =>
    {
      var contact = contacts.FirstOrDefault(c => c.Id == id);
      return contact != null ? Results.Json(contact) : Results.NotFound();
    });

    app.MapPost("/contacts", (Contact newContact) =>
    {
      newContact.Id = contactIdCounter++;
      contacts.Add(newContact);
      return Results.Created($"/contact/{newContact.Id}", newContact);
    });

    app.MapPut("/contact/{id}", (int id, Contact updatedContact) =>
    {
      var index = contacts.FindIndex(c => c.Id == id);
      if (index == -1) return Results.NotFound();
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
```

# Separate controller classes

dotnet new web -o SeparateControllers

```
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        var app = builder.Build();
        app.MapControllers();
        app.Run();
    }
}

// Controllers.cs
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
public class HelloController : ControllerBase
    {
        public string Get()
        {
        return "Hello World!";
        }
    }
```

dotnet watch run

# In another terminal

export PORT=
curl http://localhost:$PORT/Hello
curl http://localhost:$PORT/hello
curl http://localhost:$PORT/HELLO

# Supporting custom paths

```
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
public class HelloController : ControllerBase
{
[HttpGet("call")]
public string Get()
{
return "Hello World!";
}
}
```

# Now this works

curl http://localhost:$PORT/hello/call

# This gives a 404

curl http://localhost:$PORT/hello

# What if we want to support both
```
    [HttpGet("")]
    [HttpGet("call")]
    public string Get()
    {
    return "Hello World!";
    }

    // Supporting absolute paths
    [HttpGet("")]
    [HttpGet("call")]
    [HttpGet("/callagain")]
    public string Get()
    {
    return "Hello World!";
    }
```

curl http://localhost:$PORT/hello
curl http://localhost:$PORT/hello/call
curl http://localhost:$PORT/callagain

# Routes can be added at method level instead of class

```
using Microsoft.AspNetCore.Mvc;

public class HelloController : ControllerBase
{
[Route("hello")]
[Route("hello/again")]
public string Get()
{
return "Hello World!";
}
}
```

curl http://localhost:$PORT/hello
curl http://localhost:$PORT/hello/again

# Receiving params

```
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]

public class PostController : ControllerBase
{
[HttpGet("{id}")]
public string Get(int id)
{
return $"Returning post with id: {id}";
}
}
```

curl http://localhost:$PORT/post/1
curl http://localhost:$PORT/post/2
curl http://localhost:$PORT/post

# Returning C# objects as response

```
using Microsoft.AspNetCore.Mvc;

public class Post
{
public int Id { get; set; }
public string Text { get; set; }
}

[Route("[controller]")]

public class PostController : ControllerBase
{
[HttpGet("{id}")]
public Post Get(int id)
{
return new Post { Id = 1, Text = "Hello" };
}
}
```

curl http://localhost:$PORT/post/1

# Controlling responses
```
using Microsoft.AspNetCore.Mvc;

public class Post
{
public int Id { get; set; }
public string Text { get; set; }
}

public class Contact
{
public int Id { get; set; }
public string Name { get; set; }
}

[Route("[controller]")]

public class CustomResponseController : ControllerBase
{
[HttpGet("{response}")]
public IActionResult Get(string response)
{
if (response == "post")
{
return Ok(new Post { Id = 1, Text = "Hello" }); // Returns a 200 OK response with message
}
if (response == "contact")
{
return Ok(new Contact { Id = 1, Name = "John" }); // Returns a 200 OK response with message
}
else if (response == "tweet")
{
return NotFound(); // Returns a 404 Not Found response
}
else
{
return BadRequest(); // Returns a 400 Bad Request response (or customize as needed)
}
}
}
```

curl -v http://localhost:$PORT/customresponse/contact
curl -v http://localhost:$PORT/customresponse/post
curl -v http://localhost:$PORT/customresponse/tweet
curl -v http://localhost:$PORT/customresponse/company

# Setting specific response headers, the content type
```
[HttpGet("withcustomheader")]
public IActionResult WithCustomHeader()
{
Response.Headers["x-custom-key"] = "value";
return Content("<hello />", "application/xml");
}
```

curl -v http://localhost:$PORT/customresponse/withcustomheader

< HTTP/1.1 200 OK
< Content-Type: application/xml
< x-custom-key: value
<hello />

```
[Route("[controller]")]
public class RequestReaderController : ControllerBase
{
[HttpGet("")]
[HttpPost("")]
public IActionResult Reader()
{
return Ok(
new
{
Method = Request.Method,
Headers = Request.Headers,
Query = Request.Query,
Cookies = Request.Cookies,
}
);
}
}
```

curl -v http://localhost:$PORT/requestreader
curl -v http://localhost:$PORT/requestreader\?a\=b
curl -v -X POST http://localhost:$PORT/requestreader\?a\=b
curl -v -X POST -H "x-a:b" http://localhost:$PORT/requestreader\?a\=b
curl -v -X PUT -H "x-a:b" http://localhost:$PORT/requestreader\?a\=b
< HTTP/1.1 405 Method Not Allowed

# Dependency Injection

# Manual dependency injection management

```
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
private IDBManager \_dbManager;

public LoginManager(IDBManager dBManager)
{
\_dbManager = dBManager;
}

public bool Login(string username, string password)
{
string passwordFromDB = \_dbManager.GetPasswordFromDB(username);
return passwordFromDB == password;
}
}

public class Program
{
public static void Main()
{
IDBManager dBManager = new MySQLDBManager();
LoginManager lManager = new LoginManager(dBManager);
Console.WriteLine(lManager.Login("john", "johnpwd"));
Console.WriteLine(lManager.Login("george", "georgepwd"));
}
}
```

# Better DI with DI library

### dotnet new console -o DIConsole
cd DIConsole
### dotnet add package Microsoft.Extensions.DependencyInjection

Program.cs
```
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
private IDBManager \_dbManager;

public LoginManager(IDBManager dBManager)
{
\_dbManager = dBManager;
}

public bool Login(string username, string password)
{
string passwordFromDB = \_dbManager.GetPasswordFromDB(username);
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
```

# Note how we didn't have to explicitly wire LoginManager with a IDBManager implementation

# Let us now see DI in a Web project

dotnet new web -o DIWeb

# Change Program.cs
```
public class Program
{
public static void Main(string[] args)
{
var builder = WebApplication.CreateBuilder(args);
// We don't need to explicitly create a ServiceCollection (it is already present in Builder)
builder.Services.AddScoped<IDBManager, MySQLDBManager>();
builder.Services.AddScoped<LoginManager>();
var app = builder.Build();
// Note how a controller method can 'ask' for a dependency and it will be provided
app.MapGet("/", (LoginManager loginManager) =>
{
return loginManager.Login("john", "johnpwd");
});
app.Run();
}
}
```

dotnet run
curl localhost:<port>

# Injecting dependencies in controller classes

```
[ApiController]
[Route("[controller]")]
public class HelloController: ControllerBase
{
private LoginManager \_lManager;
public HelloController(LoginManager loginManager)
{
\_lManager = loginManager;
}

[HttpGet("")]
public bool Get()
{
return \_lManager.Login("john", "johnpwd");
}
}

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
```

dotnet run

curl localhost:<port>/hello
