using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

var baseURL = (Environment.GetEnvironmentVariable("BASE_URL") ?? "http://localhost") + ":" + (Environment.GetEnvironmentVariable("DAPR_HTTP_PORT") ?? "3500");

var client = new HttpClient();
client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
// Adding app id as part of the header
client.DefaultRequestHeaders.Add("dapr-app-id", "product-service");

while (true)
{
    for (int i = 1; i <= 20; i++)
    {
        var product = new Product(i);
        var orderJson = JsonSerializer.Serialize<Product>(product);
        var content = new StringContent(orderJson, Encoding.UTF8, "application/json");

        // Invoking a service
        var response = await client.PostAsync($"{baseURL}/products", content);
        Console.WriteLine("Product passed: " + product);

        await Task.Delay(TimeSpan.FromSeconds(1));
    }
    await Task.Delay(TimeSpan.FromSeconds(10));
}

public record Product([property: JsonPropertyName("productId")] int ProductId);
