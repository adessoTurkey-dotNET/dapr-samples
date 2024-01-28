using BookControlService.Events;
using Dapr.Actors;

namespace BookControlService.Actors;

public interface IBookActor : IActor
{
    public Task RegisterEntryAsync(BookRegistered msg);
    public Task RegisterExitAsync(BookRegistered msg);
}
