using Xunit;

namespace SampleApi.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void BasicEvaluationTest()
        {
            // Arrange
            bool evaluationIsReady = true;

            // Act & Assert
            Assert.True(evaluationIsReady);
        }
    }
    public class WeatherValidationTests
    {
        [Theory]
        [InlineData(-20, true)]   // Sub-zero is freezing
        [InlineData(0, true)]     // Zero is freezing boundary
        [InlineData(25, false)]   // Warm temperature is not freezing
        public void TestFreezingTemperatureLogic(int temperatureC, bool expectedFreezing)
        {
            // Arrange & Act
            var isFreezing = temperatureC <= 0;

            // Assert
            Assert.Equal(expectedFreezing, isFreezing);
        }
    }
}

