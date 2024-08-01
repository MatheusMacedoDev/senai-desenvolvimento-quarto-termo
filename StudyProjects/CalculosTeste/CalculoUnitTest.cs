using Calculos;

namespace CalculosTeste
{
    public class CalculoUnitTest
    {
        [Fact]
        public void SomarDoisNumerosTest()
        {
            double numberA = 3.3;
            double numberB = 2.2;

            double expected = 5.5;

            double result = Calculo.Somar(numberA, numberB);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SubtrairDoisNumerosTest()
        {
            double numberA = 3.3;
            double numberB = 2.2;

            double expected = 1.1;

            double result = Calculo.Subtrair(numberA, numberB);

            Assert.Equal(expected, result, 0.1);
        }

        [Fact]
        public void DividirDoisNumerosTest()
        {
            double numberA = 8;
            double numberB = 2;

            double expected = 4;

            double result = Calculo.Dividir(numberA, numberB);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void RestoDividirDoisNumerosTest()
        {
            double numberA = 3;
            double numberB = 2;

            double expected = 1;

            double result = Calculo.RestoDividir(numberA, numberB);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void MultiplicarDoisNumerosTest()
        {
            double numberA = 3;
            double numberB = 2;

            double expected = 6;

            double result = Calculo.Multiplicar(numberA, numberB);

            Assert.Equal(expected, result);
        }
    }
}