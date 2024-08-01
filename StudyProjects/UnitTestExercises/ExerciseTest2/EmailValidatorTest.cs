using Exercise2;

namespace ExerciseTest2
{
    public class EmailValidatorTest
    {
        [Theory]
        [InlineData("matheus.macedomail.com")]
        [InlineData("@mail")]
        [InlineData("matheus.macedo@.com")]
        public void GiveInvalidEmailsTest(string testedEmail)
        {
            // Act
            bool result = EmailValidator.Validate(testedEmail);

            // Assert
            Assert.False(result);
        }
    }
}