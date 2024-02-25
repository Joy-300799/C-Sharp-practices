using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Color { get; set; }
    public int Price { get; set; }

}

public class CartItem
{
    public int? ProductId { get; set; }
    public Product Product { get; set; }
    public int Qty { get; set; }
}

public class Cart
{
    public int Id { get; set; }
    public List<CartItem> Items { get; set; }
    public int TotalPrice { get; set; }
}
public class Startup
{
    private readonly IMongoCollection<Cart> _cartCollection;
    private readonly HttpClient _httpClient;
    private readonly string _productServiceBaseUrl;

    public Startup()
    {
        var client = new MongoClient(Environment.GetEnvironmentVariable("DB_HOST"));
        var database = client.GetDatabase("cartsdb");
        _cartCollection = database.GetCollection<Cart>("carts");

        _httpClient = new HttpClient();
        _productServiceBaseUrl = Environment.GetEnvironmentVariable("PRODUCTS_SERVICE");
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGet("/ping", async context =>
            {
                await context.Response.WriteAsync("pong");
            });

            // GET Cart
            endpoints.MapGet("/cart", async context =>
            {
                var filter = Builders<Cart>.Filter.Empty;
                var carts = await _cartCollection.Find(filter).ToListAsync();
                context.Response.StatusCode = StatusCodes.Status200OK;
                await context.Response.WriteAsJsonAsync(carts);
            });

            // Add Products to the cart
            endpoints.MapPost("/addtocart", async context =>
            {
                Random random = new Random();
                int cartId = random.Next(1, 1000);

                var newCart = await context.Request.ReadFromJsonAsync<Cart>();
                if (newCart == null || newCart.Items == null || newCart.Items.Count == 0)
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsJsonAsync("Invalid Cart Details!");
                    return;
                }

                newCart.Id = cartId;
                newCart.TotalPrice = 0;

                foreach (var item in newCart.Items)
                {
                    // Fetch product details from product service
                    var productResponse = await _httpClient.GetAsync($"http://{_productServiceBaseUrl}/product/{item.ProductId}");
                    if (!productResponse.IsSuccessStatusCode)
                    {
                        context.Response.StatusCode = StatusCodes.Status404NotFound;
                        await context.Response.WriteAsJsonAsync($"Product with ID {item.ProductId} not found");
                        return;
                    }

                    // Read product details from response
                    var product = await productResponse.Content.ReadFromJsonAsync<Product>();
                    newCart.TotalPrice += product.Price * item.Qty;
                    item.Product = product;
                }

                // Insert new cart into the collection
                await _cartCollection.InsertOneAsync(newCart);

                context.Response.StatusCode = StatusCodes.Status200OK;
                await context.Response.WriteAsJsonAsync(newCart);
            });

        });
    }
}

public class Program
{
    public static Task Main(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
            .Build().RunAsync();
}
