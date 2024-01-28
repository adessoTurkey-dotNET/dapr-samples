using Adesso.Dapr.DistibutedLock.Models;

namespace Adesso.Dapr.DistibutedLock.Services;

public class StockService : IStockService
{
    private readonly Dictionary<string, StockItem> _stockDatabase = new Dictionary<string, StockItem>()
    {
        {"product1",new StockItem{ItemId = "product1", Quantity = 23}}
    };

    public Task UpdateStockAsync(StockItem item)
    {
        _stockDatabase[item.ItemId] = item;
        return Task.CompletedTask;
    }

    public Task<StockItem?> GetStockAsync(string itemId)
    {
        _stockDatabase.TryGetValue(itemId, out var item);
        return Task.FromResult(item);
    }
}