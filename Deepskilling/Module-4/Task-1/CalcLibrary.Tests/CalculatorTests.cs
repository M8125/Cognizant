using CalcLibrary;
using NUnit.Framework;

namespace CalcLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private SimpleCalculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new SimpleCalculator();
        }

        [TearDown]
        public void TearDown()
        {
            calculator.AllClear();
        }

        [TestCase(2, 3, 5)]
        [TestCase(-1, 1, 0)]
        [TestCase(0, 0, 0)]
        [TestCase(10.5, 4.5, 15)]
        [TestCase(-5, -7, -12)]
        public void Addition_ReturnsCorrectSum(double a, double b, double expected)
        {
            double actual = calculator.Addition(a, b);

            Assert.That(actual, Is.EqualTo(expected));
            Assert.That(calculator.GetResult, Is.EqualTo(expected));
        }

        [TestCase(10, 4, 6)]
        [TestCase(0, 5, -5)]
        [TestCase(-3, -3, 0)]
        public void Subtraction_ReturnsCorrectDifference(double a, double b, double expected)
        {
            double actual = calculator.Subtraction(a, b);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(3, 4, 12)]
        [TestCase(-2, 5, -10)]
        [TestCase(0, 100, 0)]
        public void Multiplication_ReturnsCorrectProduct(double a, double b, double expected)
        {
            double actual = calculator.Multiplication(a, b);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(10, 2, 5)]
        [TestCase(9, 3, 3)]
        [TestCase(-12, 4, -3)]
        public void Division_ReturnsCorrectQuotient(double a, double b, double expected)
        {
            double actual = calculator.Division(a, b);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Division_ByZero_ThrowsArgumentException()
        {
            Assert.That(() => calculator.Division(10, 0), Throws.ArgumentException);
        }

        [Test]
        public void AllClear_ResetsResultToZero()
        {
            calculator.Addition(5, 5);
            calculator.AllClear();

            Assert.That(calculator.GetResult, Is.EqualTo(0));
        }
    }
}
