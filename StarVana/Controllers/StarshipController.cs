using StarVana.Clients;
using StarVana.DTOs;
using System;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
using System.Text.Json;

namespace StarVana.Controllers
{
    public interface IStarWarsApiController
    {
        List<Starship> GetAllStarships();
    }

    public class StarshipController : IStarWarsApiController
    {
        private readonly IStarWarsClient _starWarsClient;

        public StarshipController(IStarWarsClient starWarsClient)
        {
            _starWarsClient = starWarsClient;
        }
        public List<Starship> GetAllStarships()
        {
            var starshipList = new List<Starship>();

            var starWarsApiUrl = "https://swapi.dev/api/starships";
            var isNextPage = true;

            while (isNextPage)
            {
                var starshipResponse = _starWarsClient.GetStarships(starWarsApiUrl);

                if (starshipResponse != null)
                {
                    foreach (var starship in starshipResponse.Results)
                        starshipList.Add(starship);

                    if (starshipResponse.Next != null)
                        starWarsApiUrl = starshipResponse.Next;
                    else
                        isNextPage = false;
                }
            }

            return starshipList;
        }


    }
}
