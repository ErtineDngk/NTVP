using System;
using System.Windows.Forms;
using Model;
using System.Linq;

namespace GUI
{
    /// <summary>
    /// Форма, позволяющая редактировать данные предков IGeometricFigure.
    /// </summary>
    public partial class FigureForm : Form
	{
        /// <summary>
        /// Поле для хранения фигуры, сгенерированной из данных формы.
        /// </summary>
        private IGeometricFigure _figure;

        /// <summary>
        /// Свойство для доступа к фигуре.
        /// </summary>
        public IGeometricFigure Result 
		{
			get { return _figure; }
		}

        /// <summary>
        /// Конструктор без аргументов, чтобы использовать эту форму как создатель новой фигуры
        /// </summary>
        public FigureForm()
		{
            //
            // Вызов InitializeComponent () необходим для поддержки дизайнера Windows Forms.
            //
            InitializeComponent();
			
			Text = "Add figure";
			DialogResult = DialogResult.Cancel;
			figureEditControl1.MyValidatedEvent += new EventHandler(this.FigureEditControlValidation);
		}

        /// <summary>
        /// Конструктор, который загружает данные фигуры в форму.
        /// </summary>
        /// <param name="figureToEdit">Figure to get data from.</param>
        public FigureForm(IGeometricFigure figureToEdit)
		{
			InitializeComponent();
			
			Text = "Edit figure";
			figureEditControl1.Figure = figureToEdit;
			
			DialogResult = DialogResult.Cancel;
		}

        /// <summary>
        /// Вызывается при щелчке ОК, устанавливает _figure на построенную фигуру и DialogResult на OK.
        /// </summary>
        /// <param name="sender">Event sender, OKButton.</param>
        /// <param name="e">Event arguments.</param>
        private void OKButtonClick(object sender, EventArgs e)
		{
			try 
			{
				_figure = figureEditControl1.Figure;
				DialogResult = DialogResult.OK;
				return;
			} 
			catch (ArgumentException ex) 
			{
				MessageBox.Show(String.Format("Извините, но не удалось создать фигуру, пожалуйста, проверьте ваши данные.\n{0}", ex.Message), "DATA ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        /// <summary>
        /// Вызывается при нажатии кнопки «Cancel», закрывает форму.
        /// </summary>
        /// <param name="sender">Event sender, CancelButton.</param>
        /// <param name="e">Event arguments.</param>
        private void CancelButtonClick(object sender, EventArgs e)
		{
			Close();
		}

        /// <summary>
        /// Обновляет состояние кнопки «ОК» при изменении элемента управления.
        /// </summary>
        /// <param name="sender">Event sender, figureEditControl1.</param>
        /// <param name="e">Event arguments, null.</param>
        private void FigureEditControlValidation(object sender, EventArgs e)
		{
			OKButton.Enabled = figureEditControl1.IsValid;
		}

        private void figureEditControl1_Load(object sender, EventArgs e)
        {

        }

        private void FigureForm_Load(object sender, EventArgs e)
        {

        }
    }
}
