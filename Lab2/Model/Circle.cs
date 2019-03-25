using System;
using System.Windows;

namespace Model
{
    /// <summary>
    /// Класс для представления кругов.Реализует IGeometricFigure.
    /// Содержит радиус.
    /// </summary>
    public class Circle : IGeometricFigure
	{
        /// <summary>
        /// Внутреннее представление радиуса. Больше нуля. Меньше, чем Util.MaxValue.
        /// </summary>
        private double _radius;


        /// <summary>
        /// Cвойство Radius. Формирует правило «больше нуля» для радиуса.
        /// Создает исключение ArgumentException для неположительных значений в установщике.
        /// </summary>
        /// рврвапрварвар
        /// плопрлопрлпрлопрлопрролпло
        public double Radius 
		{
			get { return _radius; }
			set {
				if (!Util.IsValidPositive(value))
				{
					throw new ArgumentException(String.Format("Радиус круга должен быть больше нуля, но не больше максимального значения.", Util.MaxValue));
				} 
				_radius = value;
			}
		}
		
		/// <summary>
		/// Cвойство Type: string "Circle"
		/// </summary>
		public String Type 
		{
			get { return "Circle"; }
		}
		
		/// <summary>
		/// Свойство Area
		/// </summary>
		public double Area 
		{
			get { return Math.PI * Radius * Radius; }
		}

        /// <summary>
        /// Свойство Perimter
        /// </summary>
        public double Perimeter 
		{
			get { return 2 * Math.PI * Radius; }
		}

        /// <summary>
        /// Круг конструктор с переменным положительным радиусом.
        /// </summary>
        ///<param name = "radius"> Радиус круга. Должно быть больше нуля, но не меньше максимального значения
        /// в противном случае его установщик сгенерирует исключение ArgumentException. </ param>
        public Circle(double radius)
		{
			Radius = radius;
		}
	}
}
