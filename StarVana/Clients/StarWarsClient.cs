using StarVana.Controllers;
using StarVana.DTOs;
using System.Net.Http.Headers;

namespace StarVana.Clients
{
    public interface IStarWarsClient
    {
        StarshipsResponse? GetStarships(string url);
    }

    public class StarWarsClient : IStarWarsClient
    {
        private readonly ILogger<StarshipsController> _logger;

        public StarWarsClient(ILogger<StarshipsController> logger)
        {
            _logger = logger;
        }

        public StarshipsResponse? GetStarships(string? url)
        {
            if (url != null)
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var starshipResponseString = response.Content.ReadAsStringAsync().Result.Replace("_", "");
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<StarshipsResponse>(starshipResponseString);
                }
            }
            else
            {
                _logger.LogError("StarWarsApi URL is null.");
            }

            return null;
        }
    }
}
