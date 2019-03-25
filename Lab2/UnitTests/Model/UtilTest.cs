using System;
using Model;
using NUnit.Framework;
using System.Windows;

namespace UnitTests.Model
{
    /// <summary>
    /// Модульные тесты для служебного класса.
    /// </summary>
    [TestFixture]
	public class UtilTest
	{
        /// <summary>
        /// Тест для метода Util.IsValid(double)
        /// </summary>
        /// <param name="value">value для перехода к проверенному методу.</param>
        /// <returns>Util.IsValid(value).</returns>
        [Test]
		[TestCase(234, ExpectedResult = true, TestName = "Regular test.")]
		[TestCase(1e9 - 1, ExpectedResult = true, TestName = "Near limit test.")]
		[TestCase(1e9, ExpectedResult = true, TestName = "Limit test.")]
		[TestCase(1e9 + 1, ExpectedResult = false, TestName = "Out of the limit test.")]
		[TestCase(-1e9 + 1, ExpectedResult = true, TestName = "Near negative limit test.")]
		[TestCase(-1e9, ExpectedResult = true, TestName = "Negative limit test.")]
		[TestCase(-1e9 - 1, ExpectedResult = false, TestName = "Out of the negative limit test.")]
		[TestCase(double.NaN, ExpectedResult = false, TestName = "Nan test.")]
		[TestCase(double.MaxValue, ExpectedResult = false, TestName = "MaxValue test.")]
		[TestCase(double.NegativeInfinity, ExpectedResult = false, TestName = "Infinity test.")]
		public bool IsValidDoubleTest(double value)
		{
			return Util.IsValid(value);
		}

        /// <summary>
        /// Тест для метода Util.IsValidPositive
        /// </summary>
        /// <param name="value">Value перейти к проверенному методу.</param>
        /// <returns>Util.IsValidPositive(value).</returns>
        [Test]
		[TestCase(234, ExpectedResult = true, TestName = "Regular test.")]
		[TestCase(-456, ExpectedResult = false, TestName = "Negative test.")]
		[TestCase(1e9 - 1, ExpectedResult = true, TestName = "Near limit test.")]
		[TestCase(1e9, ExpectedResult = true, TestName = "Limit test.")]
		[TestCase(1e9 + 1, ExpectedResult = false, TestName = "Out of the limit test.")]
		[TestCase(-1e9 + 1, ExpectedResult = false, TestName = "Near negative limit test.")]
		[TestCase(-1e9, ExpectedResult = false, TestName = "Negative limit test.")]
		[TestCase(-1e9 - 1, ExpectedResult = false, TestName = "Out of the negative limit test.")]
		[TestCase(double.NaN, ExpectedResult = false, TestName = "Nan test.")]
		[TestCase(double.MaxValue, ExpectedResult = false, TestName = "MaxValue test.")]
		[TestCase(double.NegativeInfinity, ExpectedResult = false, TestName = "Infinity test.")]
		public bool IsValidPositiveTest(double value)
		{
			return Util.IsValidPositive(value);
		}
		
	}
}
