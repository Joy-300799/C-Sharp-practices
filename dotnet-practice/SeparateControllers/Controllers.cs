using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
public class HelloController : ControllerBase
{
    // What if we want to support both
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
}

// Routes can be added at method level instead of class
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

// Receiving params
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

// Returning C# objects as response
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

// Controlling responses
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


// curl -v http://localhost:$PORT/customresponse/contact
// curl -v http://localhost:$PORT/customresponse/post
// curl -v http://localhost:$PORT/customresponse/tweet
// curl -v http://localhost:$PORT/customresponse/company

// Setting specific response headers, the content type
[HttpGet("withcustomheader")]
public IActionResult WithCustomHeader()
{
    Response.Headers["x-custom-key"] = "value";
    return Content("<hello />", "application/xml");
}


// curl -v http://localhost:$PORT/customresponse/withcustomheader

// < HTTP/1.1 200 OK
// < Content-Type: application/xml
// < x-custom-key: value
// <hello />

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