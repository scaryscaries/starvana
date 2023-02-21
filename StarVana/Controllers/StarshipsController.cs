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
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private static readonly IStarWarsClient _starWarsClient = new StarWarsClient();

        private readonly ILogger<StarshipsController> _logger;

        public StarshipsController(ILogger<StarshipsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetStarships")]
        public string Get(string? manufacturer)
        {
            var starshipHandler = new StarshipHandler(_starWarsClient);
            var starships = starshipHandler.GetAllStarships(manufacturer);

            return JsonConvert.SerializeObject(starships, Formatting.Indented);
        }
    }
}