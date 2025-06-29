using NUnit.Framework;
using CalcLibrary;
using System;

namespace CalcLibrary.Tests
{
    [TestFixture]
    public class SimpleCalculatorTests
    {
        private SimpleCalculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new SimpleCalculator();
        }

        [TearDown]
        public void Teardown()
        {
            calculator.AllClear();
        }

        [Test]
        [TestCase(10, 5, 15)]
        [TestCase(-1, 1, 0)]
        public void Addition_ValidInputs_ReturnsCorrectResult(double a, double b, double expected)
        {
            var result = calculator.Addition(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(10, 5, 5)]
        [TestCase(2, 8, -6)]
        public void Subtraction_ValidInputs_ReturnsCorrectResult(double a, double b, double expected)
        {
            var result = calculator.Subtraction(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(4, 5, 20)]
        [TestCase(1.5, 2, 3)]
        public void Multiplication_ValidInputs_ReturnsCorrectResult(double a, double b, double expected)
        {
            var result = calculator.Multiplication(a, b);
            Assert.That(result, Is.EqualTo(expected).Within(0.001)); // For floating point precision
        }

        [Test]
        [TestCase(10, 2, 5)]
        [TestCase(7.5, 2.5, 3)]
        public void Division_ValidInputs_ReturnsCorrectResult(double a, double b, double expected)
        {
            var result = calculator.Division(a, b);
            Assert.That(result, Is.EqualTo(expected).Within(0.001));
        }

        [Test]
        public void Division_ByZero_ThrowsException()
        {
            var ex = Assert.Throws<ArgumentException>(() => calculator.Division(10, 0));
            Assert.That(ex.Message, Is.EqualTo("Second Parameter Can't be Zero"));
        }
    }
}
