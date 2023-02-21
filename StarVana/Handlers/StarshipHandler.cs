using StarVana.Clients;
using StarVana.DTOs;
using System;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
using System.Text.Json;

namespace StarVana.Handlers
{
    public class StarshipHandler
    {
        private readonly IStarWarsClient _starWarsClient;

        public StarshipHandler(IStarWarsClient starWarsClient)
        {
            _starWarsClient = starWarsClient;
        }
        public List<Starship> GetAllStarships(string? manufacturer)
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
                    {
                        if (manufacturer == null || starship.Manufacturer == manufacturer)
                            starshipList.Add(starship);
                    }

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
