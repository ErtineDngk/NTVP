using System;
using System.Windows;
using Newtonsoft.Json;

namespace Model
{
	/// <summary>
	/// An interface to geometric figures that holds center point and
	/// area and perimeter calculations, as per variant 1 of the labs.
	/// </summary>
	[JsonObject(MemberSerialization.Fields)]
	public interface IGeometricFigure
	{
		/// <summary>
		/// A property to hold figure's type to DataGridView in GUI
		/// </summary>
		String Type { get; }
		
		/// <summary>
		/// Area as a property, since DataGridView works with properties only,
		/// as far as I can tell
		/// </summary>
		double Area { get; }

		/// <summary>
		/// Perimeter as a property, since DataGridView works with properties only,
		/// as far as I can tell
		/// </summary>
		double Perimeter { get; }
	}
}
