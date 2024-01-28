
/* 

The code is the basic implementation for state management implementation in this controller.

*/

using BookControlService.DomainServices;
using BookControlService.Events;
using BookControlService.Models;
using BookControlService.Repositories;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookControlService.Controllers;

[ApiController]
[Route("")]
public class BookStateManagementController : ControllerBase
{
    private readonly ILogger<BookActorController> _logger;
    private readonly IBookStateRepository _bookStateRepository;
    private readonly ITimingViolationCalculator _timingViolationCalculator;
    private readonly string _libraryId;

    public BookStateManagementController(
        ILogger<BookActorController> logger,
        IBookStateRepository bookStateRepository,
        ITimingViolationCalculator timingViolationCalculator)
    {
        _logger = logger;
        _bookStateRepository = bookStateRepository;
        _timingViolationCalculator = timingViolationCalculator;
        _libraryId = timingViolationCalculator.GetLibraryId();
    }


    [HttpPost("entrycamstateman")]
    public async Task<ActionResult> BookEntryAsync(BookRegistered msg)
    {
        try
        {
            // log entry
            _logger.LogInformation($"ENTRY detected in Library {msg.Library} at {msg.Timestamp.ToString("hh:mm:ss")} " +
                $"of Book with license-number {msg.LicenseNumber}.");

            // store Book state
            var bookState = new BookState(msg.LicenseNumber, msg.Timestamp, null);
            await _bookStateRepository.SaveBookStateAsync(bookState);

            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while processing ENTRY");
            return StatusCode(500);
        }
    }

    [HttpPost("exitcamstateman")]
    public async Task<ActionResult> BookExitAsync(BookRegistered msg, [FromServices] DaprClient daprClient)
    {
        try
        {
            // get Book state
            var state = await _bookStateRepository.GetBookStateAsync(msg.LicenseNumber);
            if (state == default(BookState))
            {
                return NotFound();
            }

            // log exit
            _logger.LogInformation($"EXIT detected in Library {msg.Library} at {msg.Timestamp.ToString("hh:mm:ss")} " +
                $"of Book with license-number {msg.LicenseNumber}.");

            // update state
            var exitState = state.Value with { ExitTimestamp = msg.Timestamp };
            await _bookStateRepository.SaveBookStateAsync(exitState);

            // handle possible timing violation
            int violation = _timingViolationCalculator.DetermineTimingViolationInMinutes(exitState.EntryTimestamp, exitState.ExitTimestamp.Value);
            if (violation > 0)
            {
                _logger.LogInformation($"Timing violation detected ({violation} KMh) of Book" +
                    $"with license-number {state.Value.LicenseNumber}.");

                var timingViolation = new TimingViolation
                {
                    BookId = msg.LicenseNumber,
                    LibraryId = _libraryId,
                    ViolationInMinutes = violation,
                    Timestamp = msg.Timestamp
                };

                // publish timingviolation (Dapr publish / subscribe)
                await daprClient.PublishEventAsync("pubsub", "timingviolations", timingViolation);
            }

            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while processing EXIT");
            return StatusCode(500);
        }
    }

}
