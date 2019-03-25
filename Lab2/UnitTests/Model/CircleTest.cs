using System;
using Model;
using System.Windows;
using NUnit.Framework;

namespace UnitTests.Model
{
    /// <summary>
    ///Класс для проверки методов и / или свойств Circle.
    /// </summary>
    [TestFixture]
	public class CircleTest
	{

        /// <summary>
        /// Тест конструктора Circle. Также проверяет свойство Radius.
        /// </summary>
        /// <param name="radius">Радиус, чтобы перейти в конструктор.</param>
        [Test]
        [TestCase(1, TestName = "Test construction of circle with radius 1.")]
        [TestCase(23.4, TestName = "Non-integer radius test.")]
        [TestCase(double.Epsilon, TestName = "Epsilon radius test.")]
        [TestCase(1e9, TestName = "Maximum allowed radius test.")]
        [TestCase(1e9 - 1, TestName = "Almost maximum allowed radius test.")]
        [TestCase(double.MaxValue, ExpectedException = typeof(ArgumentException), TestName = "Maximum possible radius test.")]
        [TestCase(double.PositiveInfinity, ExpectedException = typeof(ArgumentException), TestName = "Infinity radius test.")]
        [TestCase(-1, ExpectedException = typeof(ArgumentException), TestName = "Negative radius test.")]
        [TestCase(1e9 + 1, ExpectedException = typeof(ArgumentException), TestName = "Slightly bigger than maximum allowed radius test.")]
        [TestCase(0, ExpectedException = typeof(ArgumentException), TestName = "Zero radius test.")]
        [TestCase(double.MinValue, ExpectedException = typeof(ArgumentException), TestName = "Minimum possible radius test.")]
        [TestCase(double.NegativeInfinity, ExpectedException = typeof(ArgumentException), TestName = "Negative infinity radius test.")]
        [TestCase(double.NaN, ExpectedException = typeof(ArgumentException), TestName = "NaN test.")]
        public void EllipseInitTest(double radius)
        {
            var circle = new Circle(radius);
        }


        /// <summary>
        /// Проверяет расчет площади круга.
        /// </summary>
        /// <param name="radius">Радиус для перехода в круг.</param>
        /// <returns>Расчетная площадь.</returns>
        [Test]
        [TestCase(1, ExpectedResult = Math.PI, TestName = "Area with radius 1 test.")]
        [TestCase(28.06, ExpectedResult = Math.PI * 28.06 * 28.06, TestName = "28.06 radius area test.")]
        [TestCase(1e9, ExpectedResult = Math.PI * 1e18, TestName = "Maximum allowed radius test.")]
        [TestCase(1e9 - 1, ExpectedResult = Math.PI * (1e9 - 1) * (1e9 - 1), TestName = "Almost maximum allowed radius test.")]
        // тестовые сбои начинаются здесь
        [TestCase(double.PositiveInfinity, ExpectedException = typeof(ArgumentException), TestName = "Infinity radius test.")]
        [TestCase(-1, ExpectedException = typeof(ArgumentException), TestName = "Negative radius test.")]
        [TestCase(1e9 + 1, ExpectedException = typeof(ArgumentException), TestName = "Slightly bigger than maximum allowed radius test.")]
        [TestCase(0, ExpectedException = typeof(ArgumentException), TestName = "Zero radius test.")]
        [TestCase(double.MinValue, ExpectedException = typeof(ArgumentException), TestName = "Minimum possible radius test.")]
        [TestCase(double.NegativeInfinity, ExpectedException = typeof(ArgumentException), TestName = "Negative infinity radius test.")]
        [TestCase(double.NaN, ExpectedException = typeof(ArgumentException), TestName = "NaN test.")]
        public double CircleAreaTest(double radius)
        {
            return new Circle(radius).Area;
        }

        /// <summary>
        /// Испытания по расчету периметра круга.
        /// </summary>
        /// <param name="radius"> Радиус для перехода в Circle.</param>
        /// <returns> Расчетный периметр.</returns>
        [Test]
        [TestCase(1, ExpectedResult = 2 * Math.PI, TestName = "Radius 1 perimeter test.")]
        [TestCase(476.456, ExpectedResult = 2 * Math.PI * 476.456, TestName = "Perimeter test.")]
        [TestCase(1e9, ExpectedResult = 2e9 * Math.PI, TestName = "Maximum allowed perimeter test.")]
        [TestCase(1e9 - 2, ExpectedResult = 2 * Math.PI * (1e9 - 2), TestName = "Slightly smaller than maximum radius test.")]
        // тестовые сбои начинаются здесь
        [TestCase(double.PositiveInfinity, ExpectedException = typeof(ArgumentException), TestName = "Infinity radius test.")]
        [TestCase(-1, ExpectedException = typeof(ArgumentException), TestName = "Negative radius test.")]
        [TestCase(1e9 + 1, ExpectedException = typeof(ArgumentException), TestName = "Slightly bigger than maximum allowed radius test.")]
        [TestCase(0, ExpectedException = typeof(ArgumentException), TestName = "Zero radius test.")]
        [TestCase(double.MinValue, ExpectedException = typeof(ArgumentException), TestName = "Minimum possible radius test.")]
        [TestCase(double.NegativeInfinity, ExpectedException = typeof(ArgumentException), TestName = "Negative infinity radius test.")]
        [TestCase(double.NaN, ExpectedException = typeof(ArgumentException), TestName = "NaN test.")]
        public double CirclePerimeterTest(double radius)
        {
            return new Circle(radius).Perimeter;
        }
     }
}
