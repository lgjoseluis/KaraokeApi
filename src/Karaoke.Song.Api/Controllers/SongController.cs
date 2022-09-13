using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Karaoke.Song.Api.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ILogger<SongController> _logger;

        public SongController(ILogger<SongController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new[] { "Daddy Cool", "Rasputin", "Rivers of Babylon", "Ma Baker"};
        }

        [MapToApiVersion("1.1")]
        [HttpGet]
        public IEnumerable<string> GetV2()
        {
            return new[] { "D I S C O", "One Way Ticket", "Daddy Cool" };
        }
    }
}
