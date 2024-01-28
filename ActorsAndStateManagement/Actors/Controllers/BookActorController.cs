
/* 

The code for the basic implementation is in this controller. The actor-model implementation 
resides in the Book actor (./Actors/BookActor.cs).

*/

using BookControlService.Actors;
using BookControlService.DomainServices;
using BookControlService.Events;
using BookControlService.Repositories;
using Dapr.Actors;
using Dapr.Actors.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookControlService.Controllers;

[ApiController]
[Route("")]
public class BookActorController : ControllerBase
{
    private readonly ILogger<BookActorController> _logger;
    private readonly IBookStateRepository _bookStateRepository;
    private readonly ITimingViolationCalculator _timingViolationCalculator;
    private readonly string _libraryId;

    public BookActorController(
        ILogger<BookActorController> logger,
        IBookStateRepository bookStateRepository,
        ITimingViolationCalculator timingViolationCalculator)
    {
        _logger = logger;
        _bookStateRepository = bookStateRepository;
        _timingViolationCalculator = timingViolationCalculator;
        _libraryId = timingViolationCalculator.GetLibraryId();
    }


    [HttpPost("entrycam")]
    public async Task<ActionResult> BookEntryAsync(BookRegistered msg)
    {
        try
        {
            var actorId = new ActorId(msg.LicenseNumber);
            var proxy = ActorProxy.Create<IBookActor>(actorId, nameof(BookActor));
            await proxy.RegisterEntryAsync(msg);
            return Ok();
        }
        catch
        {
            return StatusCode(500);
        }
    }

    [HttpPost("exitcam")]
    public async Task<ActionResult> BookExitAsync(BookRegistered msg)
    {
        try
        {
            var actorId = new ActorId(msg.LicenseNumber);
            var proxy = ActorProxy.Create<IBookActor>(actorId, nameof(BookActor));
            await proxy.RegisterExitAsync(msg);
            return Ok();
        }
        catch
        {
            return StatusCode(500);
        }
    }

}
