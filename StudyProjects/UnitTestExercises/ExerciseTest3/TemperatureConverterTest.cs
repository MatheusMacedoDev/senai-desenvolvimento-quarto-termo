using Exercise3;

namespace ExerciseTest3
{
    public class TemperatureConverterTest
    {
        [Fact]
        public void CorrectTemperatureTest()
        {
            // Arrange
            double celciusTemperature = 28;
            double expectedFahrenheitTemperature = 82.4;

            // Act
            double result = TemperatureConverter.CelciusToFahrenheit(celciusTemperature);

            // Assert
            Assert.Equal(expectedFahrenheitTemperature, result);
            
        }
    }
}