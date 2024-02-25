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
public class Startup
{
    private readonly IMongoCollection<Product> _productsCollection;

    public Startup()
    {
        var client = new MongoClient(Environment.GetEnvironmentVariable("DB_HOST"));
        var database = client.GetDatabase("productsdb");
        _productsCollection = database.GetCollection<Product>("products");
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

            // GET All Products
            endpoints.MapGet("/products", async context =>
            {
                var filter = Builders<Product>.Filter.Empty;
                var productsList = await _productsCollection.Find(filter).ToListAsync();
                context.Response.StatusCode = StatusCodes.Status200OK;
                await context.Response.WriteAsJsonAsync(productsList);
            });

            // GET Product by Id
            endpoints.MapGet("/product/{id}", async context =>
            {
                var id = context.Request.RouteValues["id"] as string;
                if (string.IsNullOrEmpty(id) || !int.TryParse(id, out int Id))
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync("Invalid product ID");
                    return;
                }
                var filter = Builders<Product>.Filter.Eq(p => p.Id, Id);
                var queriedProduct = await _productsCollection.Find(filter).FirstOrDefaultAsync();

                if (queriedProduct == null)
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    await context.Response.WriteAsync($"Product with ID {Id} not found");
                    return;
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status200OK;
                    await context.Response.WriteAsJsonAsync(queriedProduct);
                }
            });

            // CREATE Product
            endpoints.MapPost("/product", async context =>
            {
                Random random = new Random();
                int productId = random.Next(1000, 10000);

                var newProduct = await context.Request.ReadFromJsonAsync<Product>();
                if (newProduct == null)
                {
                    await context.Response.WriteAsJsonAsync("Invalid Product Details!");
                }

                newProduct.Id = productId;
                await _productsCollection.InsertOneAsync(newProduct);
                context.Response.StatusCode = StatusCodes.Status200OK;
                await context.Response.WriteAsJsonAsync(newProduct);
            });

            // DELETE product by product id
            endpoints.MapDelete("/product/{id}", async context =>
            {
                var id = context.Request.RouteValues["id"] as string;
                if (string.IsNullOrEmpty(id) || !int.TryParse(id, out int Id))
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync("Invalid product ID");
                    return;
                }
                var filter = Builders<Product>.Filter.Eq(p => p.Id, Id);
                var productToBeDeleted = await _productsCollection.FindOneAndDeleteAsync(filter);

                if (productToBeDeleted == null)
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    await context.Response.WriteAsync($"Product with ID {Id} not found");
                    return;
                }

                context.Response.StatusCode = StatusCodes.Status204NoContent;
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
