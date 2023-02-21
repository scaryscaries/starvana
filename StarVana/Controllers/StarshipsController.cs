using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StarVana.Clients;
using StarVana.Handlers;

namespace StarVana.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class StarshipsController : ControllerBase
    {
        private readonly IStarWarsClient _starWarsClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<StarshipsController> _logger;
        private readonly string? _starWarsApiUrl;

        public StarshipsController(ILogger<StarshipsController> logger, IConfiguration config)
        {
            _logger = logger;
            _configuration = config;
            _starWarsApiUrl = _configuration.GetConnectionString("StarWarsApiUrl");
            _starWarsClient = new StarWarsClient(_logger);
        }

        [HttpGet(Name = "GetStarships")]
        public string Get(string? manufacturer)
        {
            var starshipHandler = new StarshipHandler(_starWarsClient, _starWarsApiUrl);
            var starships = starshipHandler.GetAllStarships(manufacturer);

            return JsonConvert.SerializeObject(starships, Formatting.Indented);
        }
    }
}