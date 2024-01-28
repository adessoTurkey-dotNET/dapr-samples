using Adesso.Dapr.PubSub.Model;
using Dapr;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace Adesso.Dapr.PubSub.Sample
{
    [ApiController]
    [Route("api/[controller]")]
    public class SampleController : ControllerBase
    {

        [Topic("rabbitmq-pubsub", "sampletopic")]
        [HttpPost("subscribe")]
        public async Task<ActionResult> Subscribe([FromBody] SampleMessage message)
        {
            // Abone olduğunuz mesajlar için işlem yapın
            return Ok($"Received message: {message.Content}");
        }
 
        [HttpPost("publish")]
        public async Task<ActionResult> Publish([FromServices] DaprClient daprClient, [FromBody] SampleMessage message)
        {
            await daprClient.PublishEventAsync("rabbitmq-pubsub", "sampletopic", message);
            return Ok("Message published successfully");
        }
    }
}