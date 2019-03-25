using System;
using System.Windows;

namespace Model
{
    /// <summary>
    ///Класс для представления эллипса. Реализует IGeometricFigure.
    ///Содержит больший и меньший радиусы.
    /// </summary>
    public class Ellipse : IGeometricFigure
    {
        /// <summary>
		/// Внутреннее представление большего радиуса. Больше нуля. Меньше, чем Util.MaxValue.
		/// </summary>
		private double _largerRadius;

        /// <summary>
		/// Внутреннее представление меньшего радиуса. Больше нуля. Меньше, чем Util.MaxValue.
		/// </summary>
        private double _smallerRadius;

        /// <summary>
        /// свойство SmallerRadius. Формирует правило «больше нуля» для радиуса.
        /// Вызывает ArgumentException для неположительных значений в установщике.
        /// </summary>
        public double SmallerRadius
        {
            get { return _smallerRadius; }
            set
            {
                if (!Util.IsValidPositive(value))
                {
                    throw new ArgumentException(String.Format("Меньший радиус эллипса должен быть больше нуля, и не больше максимального значения", Util.MaxValue));
                }
                _smallerRadius = value;
            }
        }

        /// <summary>
        /// свойство LargerRadius. Формирует правило «больше нуля» для Меньшего радиуса.
        /// Вызывает ArgumentException для неположительных значений в установщике.
        /// </summary>
        public double LargerRadius
        {
            get { return _largerRadius; }
            set
            {
                if (!Util.IsValidPositive(value))
                {
                    throw new ArgumentException(String.Format("Больший радиус эллипса должен быть меньше нуля,и не больше максимального значения", Util.MaxValue));
                }
                _largerRadius = value;
            }
        }


        /// <summary>
        /// свойство Type: string "Ellipse"
        /// </summary>
        public String Type
        {
            get { return "Ellipse"; }
        }

        /// <summary>
        /// Area property
        /// </summary>
        public double Area
        {
            get { return Math.PI * LargerRadius * SmallerRadius; }
        }

        /// <summary>
        /// свойство Perimter
        /// </summary>
        public double Perimeter
    
        {
            get { return 2 * Math.PI * Math.Sqrt(((Math.Pow(SmallerRadius,2)* Math.Pow(LargerRadius,2))/2)); }
        }

        /// <summary>
        /// Конструктор Ellipse с положительным большим и меньшим радиусами.
        /// </summary>
        /// <param name = "smlradius"> меньший радиус . Должно быть больше нуля, и не больше максимального значения.
        /// в противном случае его установщик сгенерирует исключение ArgumentException. </ param>
        /// /// <param name = "lrgradius"> больший радиус . Должно быть больше нуля, и не больше максимального значения.
        /// в противном случае его установщик сгенерирует исключение ArgumentException. </ param>
        public Ellipse(double smlradius, double lrgradius)
        {
            SmallerRadius = smlradius;
            LargerRadius = lrgradius;
        }
    }

}
