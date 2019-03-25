using System;
using System.Windows;

namespace Model
{
    /// <summary>
    /// Класс для представления прямоугольников. Реализует IGeometricFigure.
    /// Содержит верхнюю ширину и высоту.
    /// </summary>
    public class Rectangle : IGeometricFigure
	{
        /// <summary>
        /// Ширина прямоугольника. Больше нуля. Меньше, чем Util.MaxValue.
        /// </summary>
        private double _width;

        /// <summary>
        /// Высота of the rectangle. Greater than zero. Less than Util.MaxValue.
        /// </summary>
        private double _height;

        /// <summary>
        /// Свойство Width, в основном, используется для обеспечения того, что ширина больше нуля.
        /// Создает исключение ArgumentException для неположительных значений в установщике.
        /// </summary>
        public double Width 
		{
			get { return _width; }
			set {
				if (!Util.IsValidPositive(value))
				{
					throw new ArgumentException(String.Format("Rectangle width must be greater than zero, but lesser than {0}.", Util.MaxValue));
				}
				_width = value;
			}
		}

        /// <summary>
        /// Свойство высоты, в основном, для обеспечения того, что высота больше нуля.
        /// Создает исключение ArgumentException для неположительных значений в установщике.
        /// </summary>
        public double Height 
		{
			get { return _height; }
			set {
				if (!Util.IsValidPositive(value))
				{
					throw new ArgumentException(String.Format("Rectangle height must be greater than zero, but lesser than {0}.", Util.MaxValue));
				}
				_height = value;
			}
		}
		
		/// <summary>
		/// Свойство Type: string "Rectangle"
		/// </summary>
		public String Type 
		{
			get { return "Rectangle"; }
		}
		
		/// <summary>
		/// Свойство Area
		/// </summary>
		public double Area 
		{
			get { return Width * Height; }
		}
		
		/// <summary>
		/// Свойство Perimeter
		/// </summary>
		public double Perimeter 
		{
			get { return 2 * (Width + Height); }
		}


        /// Конструктор Rectangle с использованием ширины и высоты.
        /// </summary>
        /// <param name="width">Положительная ширина прямоугольника. Установщик свойства генерирует ArgumentException, когда ширина равна нулю и ниже.</param>
        /// <param name="height">Положительная высота прямоугольника. Установщик свойства генерирует ArgumentException, когда высота равна нулю и ниже.</param>

        public Rectangle(double width, double height)
		{
			Width = width;
			Height = height;
		}
	}
}
