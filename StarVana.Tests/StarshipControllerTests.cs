using Moq;
using Newtonsoft.Json.Linq;
using StarVana.Clients;
using StarVana.Controllers;
using StarVana.DTOs;
using System;

namespace StarVana.Tests
{
    public class StarshipControllerTests
    {
       
        [Fact]
        public void GetAllStarships_NotNull()
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
                Manufacturer = null
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

            var starshipController = new StarshipController(starWarsClientMock.Object);
            var starships = starshipController.GetAllStarships();

            Assert.Equal(2, starships.Count);
            Assert.Equal("Bread", starships[0].Name);
            Assert.Equal("Truffle", starships[0].Name);
        }
    }
}