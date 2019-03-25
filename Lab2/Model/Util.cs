using System;
using System.Windows;

namespace Model
{
	/// <summary>
	/// Static utility class that enforces value bounds.
	/// </summary>
	public static class Util
	{
		/// <summary>
		/// Maximum allowed value for doubles in model.
		/// </summary>
		public const double MaxValue = 1e9;
		
		/// <summary>
		/// Minimum allowed value for doubles in model.
		/// </summary>
		public const double MinValue = -MaxValue;
		
		/// <summary>
		/// Checks whether number is in bounds.
		/// </summary>
		/// <param name="value">Double to check.</param>
		/// <returns>True if number is in bounds, false otherwise.</returns>
		public static bool IsValid(double value)
		{
			return (!double.IsNaN(value) && value <= MaxValue && value >= MinValue);
		}
		
		/// <summary>
		/// Checks whether number is in bounds and is positive.
		/// </summary>
		/// <param name="value">Double to check.</param>
		/// <returns>True if number is in bounds and positive, false otherwise.</returns>
		public static bool IsValidPositive(double value)
		{
			return (!double.IsNaN(value) && value <= MaxValue && value > 0);
		}
	}
}
