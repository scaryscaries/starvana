using StarVana.Controllers;

namespace StarVana.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var starWarsApiController = new StarWarsApiController();

            var starShips = starWarsApiController.GetAllStarships();

            Assert.True(true);
        }
    }
}