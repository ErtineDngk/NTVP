using System;
using System.Windows;
using Model;

namespace GUI
{
    /// <summary>
    /// Класс, который генерирует случайные числа, которые реализуют IGeometricFigure.
    /// </summary>
    public class RandomFigure
	{
        /// <summary>
        /// Перечисление, которое содержит все виды фигур, которые могут быть сгенерированы.
        /// </summary>
        public enum possible_figures
        { CIRCLE,
          RECTANGLE,
          ELLIPSE
        };

        /// <summary>
        /// Ограничитель по умолчанию, используемый, когда пользователь не предоставил ничего.
		/// </summary>
		private const double DEFAULT_LIMIT = 5.0d;

        /// <summary>
        /// Генератор случайных чисел используется во всем классе.
        /// </summary>
        private static Random rnd;

        /// <summary>
        /// Конструктор по умолчанию с нулевыми аргументами.
        /// </summary>
        public RandomFigure()
		{
			rnd = new Random();
		}

        /// <summary>
        ///Конструктор со случайным семенем.
        /// </summary>
        /// <param name="seed">Семя к генератору случайных чисел.</param>
        public RandomFigure(int seed)
		{
			rnd = new Random(seed);
		}

        /// <summary>
        /// Основной метод класса, генерация случайных фигур.
        /// </summary>
        /// <param name="limit">Максимальное абсолютное значение параметров фигуры.</param>
        /// <returns>Случайная геометрическая фигура.</returns>
        public IGeometricFigure NextFigure(double limit)
		{
			var type = (possible_figures)rnd.Next(Enum.GetNames(typeof(possible_figures)).Length);
			
			switch (type) {
				case possible_figures.CIRCLE:
					var radius = NextDouble(limit);
					try {
						var circle = new Circle(radius);
						return circle;
					} catch (ArgumentException) {
						return NextFigure(limit);
					}
				case possible_figures.RECTANGLE:
					var width = NextDouble(limit);
					var height = NextDouble(limit);
					try {
						var rect = new Rectangle( width, height);
						return rect;
					} catch (ArgumentException) {
						return NextFigure(limit);
					}
				case possible_figures.ELLIPSE:
                    var smlradius = NextDouble(limit);
                    var lrgradius = NextDouble(limit);
                    try {
						var ellipse = new Ellipse(smlradius, lrgradius);
						return ellipse;
					} catch (ArgumentException) {
						return NextFigure(limit);
					}
				default:
					throw new NotImplementedException("Неизвестный тип в enum possible_figures ");
			}
		}

        /// <summary>
        /// Вызов генератора без определенных пределов значений,
        /// по умолчанию константа DEFAULT_LIMIT.
        /// </summary>
        /// <returns>Случайная геометрическая фигура.</returns>
        public IGeometricFigure NextFigure()
		{
			return NextFigure(DEFAULT_LIMIT);
		}


        /// <summary>
        ///Случайное генерация.
        /// </summary>
        /// <param name="max">Максимальное значение сгенерированного double.</param>
        /// <returns>Случайный double от 0 до макс.</returns>
        private static double NextDouble(double max)
		{
			return Math.Round(max * rnd.NextDouble(), 1);
		}
	}
}
