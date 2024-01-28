using BookControlService.DomainServices;
using BookControlService.Events;
using BookControlService.Models;
using Dapr.Actors.Runtime;
using Dapr.Client;
using Microsoft.Extensions.Logging;

namespace BookControlService.Actors;

public class BookActor : Actor, IBookActor, IRemindable
{
    public readonly ITimingViolationCalculator _timingViolationCalculator;
    private readonly string _libraryId;
    private readonly DaprClient _daprClient;

    public BookActor(ActorHost host, DaprClient daprClient, ITimingViolationCalculator timingViolationCalculator) : base(host)
    {
        _daprClient = daprClient;
        _timingViolationCalculator = timingViolationCalculator;
        _libraryId = _timingViolationCalculator.GetLibraryId();
    }

    public async Task RegisterEntryAsync(BookRegistered msg)
    {
        try
        {
            Logger.LogInformation($"ENTRY detected in Library {msg.Library} at " +
                $"{msg.Timestamp.ToString("hh:mm:ss")} " +
                $"of Book with license-number {msg.LicenseNumber}.");

            // store Book state
            var bookState = new BookState(msg.LicenseNumber, msg.Timestamp);
            await this.StateManager.SetStateAsync("BookState", bookState);

            // register a reminder for cars that enter but don't exit within 20 seconds
            // (they might have broken down and need road assistence)
            await RegisterReminderAsync("BookLost", null,
                TimeSpan.FromSeconds(20), TimeSpan.FromSeconds(20));
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error in RegisterEntry");
        }
    }

    public async Task RegisterExitAsync(BookRegistered msg)
    {
        try
        {
            Logger.LogInformation($"EXIT detected in Library {msg.Library} at " +
                $"{msg.Timestamp.ToString("hh:mm:ss")} " +
                $"of Book with license-number {msg.LicenseNumber}.");

            // remove lost Book timer
            await UnregisterReminderAsync("BookLost");

            // get Book state
            var bookState = await this.StateManager.GetStateAsync<BookState>("BookState");
            bookState = bookState with { ExitTimestamp = msg.Timestamp };
            await this.StateManager.SetStateAsync("BookState", bookState);

            // handle possible timing violation
            int violation = _timingViolationCalculator.DetermineTimingViolationInMinutes(
                bookState.EntryTimestamp, bookState.ExitTimestamp.Value);
            if (violation > 0)
            {
                Logger.LogInformation($"violation detected ({violation}) of Book " +
                    $"with license-number {bookState.LicenseNumber}.");

                var timingViolation = new TimingViolation
                {
                    BookId = msg.LicenseNumber,
                    LibraryId = _libraryId,
                    ViolationInMinutes = violation,
                    Timestamp = msg.Timestamp
                };

                await _daprClient.PublishEventAsync("pubsub", "timingviolations", timingViolation);
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error in RegisterExit");
        }
    }

    public async Task ReceiveReminderAsync(string reminderName, byte[] state, TimeSpan dueTime, TimeSpan period)
    {
        if (reminderName == "BookLost")
        {
            // remove lost Book timer
            await UnregisterReminderAsync("BookLost");

            var bookState = await this.StateManager.GetStateAsync<BookState>("BookState");

            Logger.LogInformation($"Lost track of Book with license-number {bookState.LicenseNumber}. ");
        }
    }
}
