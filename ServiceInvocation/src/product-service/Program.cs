var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapPost("/products", (Product product) =>
{
    Console.WriteLine("Product received : " + product);
    return product.ToString();
});

await app.RunAsync();

public record Product(int productId);
