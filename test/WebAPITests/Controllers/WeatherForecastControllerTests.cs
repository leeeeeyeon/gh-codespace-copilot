// add namespace for WeatherForecastController
using WebAPI.Controllers;

namespace WebAPITests;

[TestClass]
public class WeatherForecastControllerTests
{
    [TestMethod]
    public void TestMethod1()
    {
    }

    // add a test method that tests the GetWeatherForecastByLength from WeatherForecastController
    // Path: test/WebAPITests/Controllers/WeatherForecastControllerTests.cs
    [TestMethod]
    public void GetWeatherForecastByLength()
    {
        // Arrange
        var controller = new WeatherForecastController(null);

        // Act
        var result = controller.GetRange(new DateRange { Length = 3 });

        // Assert
        Assert.AreEqual(3, result.Count());
    }

}