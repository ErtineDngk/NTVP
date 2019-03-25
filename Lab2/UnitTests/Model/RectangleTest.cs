using System;
using Model;
using NUnit.Framework;
using System.Windows;

namespace UnitTests.Model
{
    /// <summary>
    /// Класс для проверки методов и / или свойств Rectangle.
    /// </summary>
    [TestFixture]
	public class RectangleTest
	{


        /// <summary>
        /// Проверяет конструктор прямоугольника с шириной, высотой.
        /// </summary>
        /// <param name="width">Ширина прямоугольника.</param>
        /// <param name="height">Высота прямоугольника.</param>
        [Test]
		[TestCase(0, 0, 23, 45.67, TestName = "Regular test.")]
		[TestCase(0, 0, 0, 12.45, ExpectedException = typeof(ArgumentException), TestName = "Zero width test.")]
		[TestCase(0, 0, -12, 123, ExpectedException = typeof(ArgumentException), TestName = "Negative width test.")]
		[TestCase(0, 0, 1e10, 67, ExpectedException = typeof(ArgumentException), TestName = "Too big width test.")]
		[TestCase(0, 0, double.NaN, 23, ExpectedException = typeof(ArgumentException), TestName = "NaN width test.")]
		[TestCase(0, 0, 0.9e9, 0.4, TestName = "Near limit width test.")]
		[TestCase(0, 0, 234.4, 0, ExpectedException = typeof(ArgumentException), TestName = "Zero height test.")]
		[TestCase(0, 0, 56, double.MinValue, ExpectedException = typeof(ArgumentException), TestName = "Negative height test.")]
		[TestCase(0, 0, 342, double.MaxValue, ExpectedException = typeof(ArgumentException), TestName = "Too big height test.")]
		[TestCase(0, 0, 34, double.NaN, ExpectedException = typeof(ArgumentException), TestName = "NaN height test.")]
		[TestCase(0, 0, 34, 0.99e9, TestName = "Near limit height test.")]

		public void CenterWidthHeightConstructorTest( double width, double height)
		{
			var rectangle = new Rectangle(width, height);
		}

        /// <summary>
        /// Проверяет расчет площади по заданной ширине и высоте. 
        /// </summary>
        /// <param name="width">Ширина прямоугольника.</param>
        /// <param name="height">Высота прямоугольника.</param>
        /// <returns>Расчетная площадь.</returns>
        [Test]
		[TestCase(4, 5, ExpectedResult = 20, TestName = "Trivial case.")]
		[TestCase(3, 1e9, ExpectedResult = 3e9, TestName = "Limit test.")]
		[TestCase(0, 5, ExpectedException = typeof(ArgumentException), TestName = "Zero width test.")]
		[TestCase(double.PositiveInfinity, 5, ExpectedException = typeof(ArgumentException), TestName = "Infinite width test.")]
		[TestCase(4, -8, ExpectedException = typeof(ArgumentException), TestName = "Negative height test.")]
		[TestCase(4, double.NaN, ExpectedException = typeof(ArgumentException), TestName = "NaN height test.")]
		public double RectangleAreaTest(double width, double height)
		{
			var rectangle = new Rectangle(width, height);
			return rectangle.Area;
		}

        /// <summary>
        /// Проверяет расчет периметра по заданной ширине и высоте. 
        /// </summary>
        /// <param name="width">Ширина прямоугольника.</param>
        /// <param name="height">Высота прямоугольника.</param>
        /// <returns>Расчетный периметр.</returns>
        [Test]
		[TestCase(4, 5, ExpectedResult = 18, TestName = "Trivial case.")]
		[TestCase(1e9 - 2, 4, ExpectedResult = 2 * (1e9 + 2), TestName = "Near limit test.")]
		[TestCase(0, 5, ExpectedException = typeof(ArgumentException), TestName = "Zero width test.")]
		[TestCase(double.PositiveInfinity, 5, ExpectedException = typeof(ArgumentException), TestName = "Infinite width test.")]
		[TestCase(4, -8, ExpectedException = typeof(ArgumentException), TestName = "Negative height test.")]
		[TestCase(4, double.NaN, ExpectedException = typeof(ArgumentException), TestName = "NaN height test.")]
		public double RectanglePerimeterTest(double width, double height)
		{
			var center = new Point(0, 0);
			var rectangle = new Rectangle(width, height);
			return rectangle.Perimeter;
		}
	}
}
