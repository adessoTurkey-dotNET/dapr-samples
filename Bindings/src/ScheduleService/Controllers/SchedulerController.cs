using Dapr.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScheduleService.Models;
using System.Text.Json;

namespace ScheduleService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly ILogger<ScheduleController> _logger;
        private readonly DaprClient _daprClient;

        public ScheduleController(ILogger<ScheduleController> logger, DaprClient daprClient)
        {
            _logger = logger;
            _daprClient = daprClient;
        }

        [HttpPost]
        public async Task HttpBinding()
        {
            _logger.LogInformation($"{nameof(ScheduleController)} called!");

            var response = await _daprClient.InvokeBindingAsync(new BindingRequest("httpJob", "get"));
            var timeModel = JsonSerializer.Deserialize<TimeModel>(response.Data.Span);

            _logger.LogInformation($"Time in Istanbul {timeModel?.DateTimeUTC}");
        }
    }
}
