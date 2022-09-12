using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Karaoke.Song.Api.Controllers
{
    [ApiVersion("1.0")]
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
    }
}
