using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;
using Model;

namespace GUI
{
    /// <summary>
    /// Основная форма приложения.DataGridView с данными, меню и кнопками управления.
    /// </summary>
    public partial class MainForm : Form
	{
        /// <summary>
        /// Список для хранения всех значений.
        /// </summary>
        private BindingList<IGeometricFigure> _figures = new BindingList<IGeometricFigure>();

        /// <summary>
        /// Строка, которая содержит текущий открытый файл.
        /// </summary>
        private string _fileName;

        /// <summary>
        /// Был ли текущий файл изменен с момента последнего сохранения.
        /// </summary>
        private bool _modified;

        /// <summary>
        /// Название приложения отображается в строке заголовка после имени файла.
        /// </summary>
        public const String APP_NAME = "GRAPHICAL USER INTERFACE";

        /// <summary>
        /// Конструктор главной формы, привязка данных из списка к DataGridView.
        /// </summary>
        public MainForm()
		{
            //
            // Вызов InitializeComponent () необходим для поддержки дизайнера Windows Forms.
            //
            InitializeComponent();
			
			#if DEBUG
			RndButton.Visible = true;
			#endif
			BindData();

            // у нас есть пустой безымянный файл в начале
            _fileName = "";
			_modified = false;
			
			_figures.ListChanged += (object sender, ListChangedEventArgs e) => {_modified = true; UpdateCaption(); DataGridViewRowsModified(sender, null); };
			UpdateCaption();
		}

        /// <summary>
        /// Привязывает данные из (своего рода) списка к нашему DataGridView на пользовательском интерфейсе
        /// see https://stackoverflow.com/questions/1228539/
        /// </summary>
        private void BindData()
		{
			dataGridView.AutoGenerateColumns = false;
			
			DataGridViewCell cell = new DataGridViewTextBoxCell();
			var columnType = new DataGridViewTextBoxColumn() 
			{
				CellTemplate = cell,
				Name = "Type column",
				HeaderText = "Type",
				DataPropertyName = "Type"
			};
			
			
			var columnArea = new DataGridViewTextBoxColumn() 
			{
				CellTemplate = cell,
				Name = "Area column",
				HeaderText = "Area",
				DataPropertyName = "Area"
			};
			
			var columnPerimeter = new DataGridViewTextBoxColumn() 
			{
				CellTemplate = cell,
				Name = "Perimeter column",
				HeaderText = "Perimeter",
				DataPropertyName = "Perimeter"
			};
			
			dataGridView.Columns.Add(columnType);
			dataGridView.Columns.Add(columnArea);
			dataGridView.Columns.Add(columnPerimeter);
			
			dataGridView.DataSource = _figures;
		}

        /// <summary>
        /// Добавляет случайные значения в «базу данных».
        /// </summary>
        /// <param name="count">Количество значений для добавления.</param>
        private void AddRandomFigures(int count)
		{
			var rnd = new RandomFigure();
			for (int i = 0; i < count; i++) 
			{
				_figures.Add(rnd.NextFigure());
			}
		}

        /// <summary>
        /// Обрабатывает клик « Add random data». Добавляет 10 случайных чисел в список.
        /// </summary>
        /// <param name="sender">Event sender, RndButton.</param>
        /// <param name="e">Event arguments.</param>
        private void RndButtonClick(object sender, EventArgs e)
		{
			AddRandomFigures(10);
		}

        /// <summary>
        /// Обрабатывает «Remove current» клик
        /// </summary>
        /// <param name="sender">событие sender, RemoveButton.</param>
        /// <param name="e">событие arguments.</param>
        private void RemoveButtonClick(object sender, EventArgs e)
		{
			DeleteSelection();
		}

        /// <summary>
        /// Удаляет текущую выбранную строку в DataGridView и в списке,
        /// если выбран какой-либо. В противном случае ничего не делает.
        /// </summary>
        private void DeleteSelection()
		{
			if (dataGridView.SelectedRows.Count > 0) 
			{
				var index = dataGridView.SelectedRows[0].Index;
				_figures.RemoveAt(index);
			}
		}

        /// <summary>
        /// Handles File->Quit, Alt-F4. Quits the program.
        /// </summary>
        /// <param name="sender">Событие sender, QuitToolStripMenuItem.</param>
        /// <param name="e">Событие arguments.</param>
        private void QuitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Close();
		}

        /// <summary>
        /// Включает / отключает кнопки «Удалить» и «Редактировать» на основе выбора в DataGridView.
        /// Также загружает текущую фигуру в FigureEditControl
        /// </summary>
        /// <param name="sender">Событие sender, dataGridView.</param>
        /// <param name="e">Событие arguments.</param>
        private void DataGridViewRowsModified(object sender, EventArgs e)
		{
			removeButton.Enabled = dataGridView.SelectedRows.Count > 0;
			editButton.Enabled = dataGridView.SelectedRows.Count > 0;
			if (dataGridView.SelectedRows.Count > 0)
			{
				var index = dataGridView.SelectedRows[0].Index;
				figureEditControl1.Figure = _figures[index];
			}
		}

        /// <summary>
        /// Handles Help->About. Открывает AboutForm как модальное окно.
        /// </summary>
        /// <param name="sender">Событие sender, AboutToolstripMenuItem.</param>
        /// <param name="e">Событие arguments.</param>
        private void AboutToolStripMenuItemClick(object sender, EventArgs e)
		{
			var af = new AboutForm();
            // ShowDialog вместо Show для модальности

            af.ShowDialog();
		}

        /// <summary>
        /// Обрабатывает нажатие кнопки «Add». Открывается пустой FigureForm.
        /// </summary>
        /// <param name="sender">Event sender, AddButton.</param>
        /// <param name="e">Event arguments.</param>
        private void AddButtonClick(object sender, EventArgs e)
		{
			var ff = new FigureForm();
			if (ff.ShowDialog() == DialogResult.OK)
			{
				_figures.Add(ff.Result);
			}
		}

        /// <summary>
        /// Обрабатывает нажатие кнопки «Редактировать». 
        /// Открывает FigureForm с выбранной предварительно загруженной фигурой.
        /// </summary>
        /// <param name="sender">Event sender, EditButton.</param>
        /// <param name="e">Event arguments.</param>
        private void EditButtonClick(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count > 0) 
			{
				var index = dataGridView.SelectedRows[0].Index;
				var ff = new FigureForm(_figures[index]);
				if (ff.ShowDialog() == DialogResult.OK) 
				{
					_figures[index] = ff.Result;
					_modified = true;
				}
			}
			
		}

        /// <summary>
        ///Обновляет заголовок формы с текущим именем файла, измененным статусом и названием приложения.
        /// </summary>
        private void UpdateCaption()
		{
			var unsaved_char = _modified ? "*" : "";
			Text = String.Format("{0}{1} — {2}", _fileName, unsaved_char, APP_NAME);
		}

        /// <summary>
        ///Сохраняет текущие данные в _fileName, если это необходимо. Вызывает SaveAs (), чтобы получить действительное имя, когда оно пустое.
        /// </summary>
        private void Save()
		{
			if (_fileName.Equals("")) 
			{
				SaveAs();
			} 
			else 
			{
				if (_modified) 
				{
					FigureIO.SaveToFile(_figures, _fileName);
					_modified = false;
					UpdateCaption();
				}
			}
		}

        /// <summary>
        /// Устанавливает _fileName для выбранного пользователем файла, затем вызывает Save() для записи в него.
		/// </summary>
		private void SaveAs()
		{
			if (saveFileDialog.ShowDialog() == DialogResult.OK) 
			{
				_fileName = saveFileDialog.FileName;
				Save();
			}
		}

        /// <summary>
        /// Загружает выбранный файл как новые данные.
        /// </summary>
        /// <param name="filename">Путь к файлу для открытия.</param>
        private void Open(String filename)
		{
			try
			{
                // мы не можем напрямую заменить _figures новым BindingList, есть
                // много настроек, которые идут прямо через окно и ломаются
                // материал на замену
                _figures.Clear();
				foreach (var elem in FigureIO.LoadFormFile(filename))
				{
					_figures.Add(elem);
				}
				
			}
			catch (FileFormatException e)
			{
				MessageBox.Show(e.Message, "DATA ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				_figures.Clear();
				_fileName = "";
			}
			_modified = false;
			UpdateCaption();
		}

        /// <summary>
        /// Очищает данные до пустого состояния.
        /// </summary>
        private void New()
		{
			_figures.Clear();
			_fileName = "";
			_modified = false;
			UpdateCaption();
		}

        /// <summary>
        /// Обрабатывает File-> New click. Оболочка New (), которая запрашивает у пользователя подтверждение при необходимости
        /// </summary>
        /// <param name="sender">Event sender, NewToolStripMenuItem.</param>
        /// <param name="e">Event arguments.</param>
        private void NewToolStripMenuItemClick(object sender, EventArgs e)
		{
            // Запрос подтверждения при изменении файла
            // когда он не модифицирован, также продолжается
            if (!_modified || (_modified && AskForConfirmation()))
			{
				New();
			}
		}

        /// <summary>
        /// Handles File->Save click.
        /// </summary>
        /// <param name="sender">Событие sender, saveToolStripMenuItem.</param>
        /// <param name="e">Событие arguments.</param>
        private void SaveToolStripMenuItemClick(object sender, EventArgs e)
		{
			Save();
		}

        /// <summary>
        /// Handles File->Сохранить все.
        /// </summary>
        /// <param name="sender">Событие sender, saveAsToolStripMenuItem.</param>
        /// <param name="e">Событие arguments.</param>
        private void SaveAsToolStripMenuItemClick(object sender, EventArgs e)
		{
			SaveAs();
		}

        /// <summary>
        /// Обрабатывает File-> Открыть. При необходимости просит сохранить несохраненные изменения,
        /// затем открывает файл, если предоставляется через openFileDialog.
        /// </summary>
        /// <param name="sender">Событие sender, OpenToolStripMenuItem.</param>
        /// <param name="e">Событие arguments.</param>
        private void OpenToolStripMenuItemClick(object sender, EventArgs e)
		{
            //Должен, вероятно, рефакторинг, чтобы быть совместимым с другими обработчиками, которые имеют гораздо меньше кода

            // запрос подтверждения при необходимости
            if (!_modified || (_modified && AskForConfirmation()))
			{
				if (openFileDialog.ShowDialog() == DialogResult.OK) 
				{
					var newFileName = openFileDialog.FileName;
                    // не перезагружать файл, если он не изменен
                    if (!newFileName.Equals(_fileName) || _modified) 
					{
						_fileName = newFileName;
						Open(_fileName);
					}
				}
			}
		}

        /// <summary>
        /// Предупреждает пользователя о том, что текущий файл не сохранен, спрашивает, нужно ли нам сначала сохранить его.
        /// Возвращает bool, указывающий, можем ли мы продолжить нашу задачу.
        /// </summary>
        /// <returns>Истинно, когда пользователь выбрал «Да» или «Нет», ложно, если был выбран «Отмена».</returns>
        private bool AskForConfirmation()
		{
			var result = MessageBox.Show("It appears that currently opened file has some unsaved changes in it. Would you like to save it before proceeding?", "Here's a question!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
			switch (result) 
			{
				case DialogResult.Yes:
                    //сохранить и продолжить
                    Save();
					return true;
				case DialogResult.No:
                    // не сохранять, продолжить
                    return true;
				default:
                    // не продолжать
                    return false;
			}
		}

        /// <summary>
        /// Обрабатывает закрытие окна, если есть какие-либо сохраненные изменения,
        /// спрашивает пользователя, хочет ли он продолжить.
        /// </summary>
        /// <param name="sender">Событие sender, MainForm.</param>
        /// <param name="e">Событие arguments.</param>
        void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if (!_modified || (_modified && AskForConfirmation())) 
			{
				return;
			}
			e.Cancel = true;
		}

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void figureEditControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
