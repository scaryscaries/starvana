using StarVana.Clients;
using StarVana.DTOs;

namespace StarVana.Handlers
{
    public class StarshipHandler
    {
        private readonly IStarWarsClient _starWarsClient;
        private readonly string? _starWarsApiUrl;

        public StarshipHandler(IStarWarsClient starWarsClient, string? starWarsApiUrl)
        {
            _starWarsClient = starWarsClient;
            _starWarsApiUrl = starWarsApiUrl;
        }

        public List<Starship> GetAllStarships(string? manufacturer)
        {
            var starshipList = new List<Starship>();

            var starWarsApiUrl = _starWarsApiUrl;
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
