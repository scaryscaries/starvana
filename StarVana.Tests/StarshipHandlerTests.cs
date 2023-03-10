using Moq;
using Xunit;
using StarVana.Clients;
using StarVana.Handlers;
using StarVana.DTOs;

namespace StarVana.Tests
{
    public class StarshipHandlerTests
    {
       
        [Fact]
        public void GetAllStarships_NullManufactuer()
        {
            var starWarsApiUrl = "https://swapi.dev/api/starships";

            var starshipOne = new Starship()
            {
                Name = "Bread",
                Model = "Cat",
                Manufacturer = "Wilderness Inc."
            };
            var starshipTwo = new Starship()
            {
                Name = "Truffle",
                Model = "Cat",
                Manufacturer = "Pony Express"
            };
            var starshipsResponse = new StarshipsResponse
            {
                Count = 2,
                Previous = null,
                Next = null
            };

            starshipsResponse.Results.Add(starshipOne);
            starshipsResponse.Results.Add(starshipTwo);

            var starWarsClientMock = new Mock<IStarWarsClient>();
            starWarsClientMock.Setup(x => x.GetStarships(starWarsApiUrl)).Returns(starshipsResponse);

            var starshipController = new StarshipHandler(starWarsClientMock.Object, starWarsApiUrl);
            var starships = starshipController.GetAllStarships(null);

            Assert.Equal(2, starships.Count);
            Assert.Equal("Bread", starships[0].Name);
            Assert.Equal("Truffle", starships[1].Name);
        }

        [Fact]
        public void GetAllStarships_SpecificManufacturer()
        {
            var starWarsApiUrl = "https://swapi.dev/api/starships";

            var starshipOne = new Starship()
            {
                Name = "Bread",
                Model = "Cat",
                Manufacturer = "Wilderness Inc."
            };
            var starshipTwo = new Starship()
            {
                Name = "Truffle",
                Model = "Cat",
                Manufacturer = "Pony Express"
            };

            var starshipsResponse = new StarshipsResponse
            {
                Count = 2,
                Previous = null,
                Next = null
            };

            starshipsResponse.Results.Add(starshipOne);
            starshipsResponse.Results.Add(starshipTwo);

            var starWarsClientMock = new Mock<IStarWarsClient>();
            starWarsClientMock.Setup(x => x.GetStarships(starWarsApiUrl)).Returns(starshipsResponse);

            var starshipController = new StarshipHandler(starWarsClientMock.Object, starWarsApiUrl);
            var starships = starshipController.GetAllStarships("Pony Express");

            Assert.Single(starships);
            Assert.Equal("Truffle", starships[0].Name);
        }
    }
}