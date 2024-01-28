using Adesso.Dapr.Crypt.Service;
using Microsoft.AspNetCore.Mvc;

namespace Adesso.Dapr.Crypt.Sample
{
    [ApiController]
    [Route("api/[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly EncryptionService _encryptionService;

        public SampleController(EncryptionService encryptionService)
        {
            _encryptionService = encryptionService;
        }

        [HttpPost("encrypt")]
        public ActionResult<string> Encrypt([FromBody] string plainText)
        {
            var encryptedText = _encryptionService.Encrypt(plainText);
            return encryptedText;
        }

        [HttpPost("decrypt")]
        public ActionResult<string> Decrypt([FromBody] string cipherText)
        {
            var plainText = _encryptionService.Decrypt(cipherText);
            return plainText;
        }
    }
}