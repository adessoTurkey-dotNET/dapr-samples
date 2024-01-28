using Adesso.Dapr.DistibutedLock.Models;
using Adesso.Dapr.DistibutedLock.Services;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace Adesso.Dapr.DistibutedLock.Controllers;

public class StockController : ControllerBase
{
    private readonly IStockService _stockService;
    private readonly DaprClient _daprClient;

    public StockController(IStockService stockService, DaprClient daprClient)
    {
        _stockService = stockService;
        _daprClient = daprClient;
    }

    [HttpPost("update-stock")]
    public async Task<IActionResult> UpdateStock([FromBody] StockItem stockItem)
    {
        await using (var lockResponse = await _daprClient.Lock("lockstore","stockdata","lockOwner",1))
        {
            if (!lockResponse.Success)
                return BadRequest("Not locked");
            await _stockService.UpdateStockAsync(stockItem);
            
        }
        return Ok();
    }
    
    [HttpGet("get-stock/{itemId}")]
    public async Task<IActionResult> GetStock(string itemId)
    {
        var stockItem = await _stockService.GetStockAsync(itemId);
        return Ok(stockItem); 
    }
}