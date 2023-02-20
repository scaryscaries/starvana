using StarVana.DTOs;
using System.Net.Http.Headers;

namespace StarVana.Controllers
{
    public class StarWarsApiController
    {
        public readonly string STAR_WARS_API_URL = "https://swapi.dev/api/starships";
        public List<Starship> GetAllStarships()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(STAR_WARS_API_URL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var starshipList = new List<Starship>();

            var response = client.GetAsync(STAR_WARS_API_URL).Result;
            if (response.IsSuccessStatusCode)
            {
                var starshipResponse = response.Content.ReadAsStringAsync().Result;
            }

            return starshipList;
        }
    }
}
