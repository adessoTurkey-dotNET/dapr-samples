using BookControlService.Models;
using Dapr.Client;

namespace BookControlService.Repositories;

public class DaprBookStateRepository : IBookStateRepository
{
    private const string DAPR_STORE_NAME = "statestore";
    private readonly DaprClient _daprClient;

    public DaprBookStateRepository(DaprClient daprClient)
    {
        _daprClient = daprClient;
    }

    public async Task SaveBookStateAsync(BookState bookState)
    {
        await _daprClient.SaveStateAsync<BookState>(
            DAPR_STORE_NAME, bookState.LicenseNumber, bookState);
    }

    public async Task<BookState?> GetBookStateAsync(string licenseNumber)
    {
        var stateEntry = await _daprClient.GetStateEntryAsync<BookState>(
            DAPR_STORE_NAME, licenseNumber);
        return stateEntry.Value;
    }
}
