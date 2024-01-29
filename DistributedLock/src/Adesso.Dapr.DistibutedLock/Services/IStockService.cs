using Adesso.Dapr.DistibutedLock.Models;

namespace Adesso.Dapr.DistibutedLock.Services;

public interface IStockService
{
    Task UpdateStockAsync(StockItem item);
    Task<StockItem?> GetStockAsync(string itemId);
}