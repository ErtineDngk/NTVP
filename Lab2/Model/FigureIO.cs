using System;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;
using Newtonsoft.Json;
using Model;

namespace Model
{
    /// <summary>
    /// Утилита класса, который обрабатывает (Де)сериализации из IGeometricFigure в JSON.
    /// </summary>
    public static class FigureIO
	{
        /// <summary>
        /// Настройка используется для загрузки трех разных классов с разными полями одной строкой кода.
        /// </summary>
        private static readonly JsonSerializerSettings _settings = new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.All};

        /// <summary>
        /// Произвольная строка для различения допустимых файлов
        /// </summary>
        private const string _fileHeader = "GUI_DB_MODEL_FILE_VER_1.1";

        /// <summary>
        /// Метод для сериализации предка IGeometricFigure в строку JSON.
        /// </summary>
        /// <param name="figure">Figure для сериализации.</param>
        /// <returns>представление string JSON.</returns>
        private static string Serialize(IGeometricFigure figure)
		{
			return JsonConvert.SerializeObject(figure, _settings);
		}

        /// <summary>
        /// Метод десериализации IGeometricFigure из строки JSON.
        /// </summary>
        /// <param name="json">JSON для десериализации.</param>
        /// <returns>Десереализация IGeometricFigure.</returns>
        private static IGeometricFigure Deserialize(string json)
		{
			return (IGeometricFigure)JsonConvert.DeserializeObject(json, _settings);
		}

        /// <summary>
        /// Способ сохранения BindingList IGeometricfigure в файл.
        /// </summary>
        /// <param name="figures">Список для сохранения.</param>
        /// <param name="filename">Имя файла для сохранения в.</param>
        public static void SaveToFile(BindingList<IGeometricFigure> figures, string filename)
		{
			var file = new StreamWriter(filename);
			file.WriteLine(_fileHeader);
			foreach (var figure in figures) 
			{
				var jsonString = Serialize(figure);
				file.WriteLine(jsonString);
			}
			file.Close();
		}
		
		public static List<IGeometricFigure> LoadFormFile(string filename)
		{
			var file = new StreamReader(filename);
			var header = file.ReadLine();
			var ret = new List<IGeometricFigure>();
			if (!header.Equals(_fileHeader)) 
			{
				file.Close();
				throw new FileFormatException("Заголовок файла отсутствует или поврежден.");
			}
			while (!file.EndOfStream) 
			{
				try 
				{
					var line = file.ReadLine();
					var figure = Deserialize(line);
					ret.Add(figure);
				} 
				catch
				{
					file.Close();
					throw new FileFormatException("Ошибка при чтении данных в файле.");
				}
			}
			file.Close();
			return ret;
		}
		
	}
}
