using System;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using Model;

namespace GUI
{
    /// <summary>
    /// Описание FigureEditControl.
    /// </summary>
    public partial class FigureEditControl : UserControl
	{
        /// <summary>
        /// Обработчик событий, используемый для обновления «OK», «Generate» и любых других кнопок
        /// без ссылки на них.
        /// </summary>
        public event EventHandler MyValidatedEvent;

        /// <summary>
        /// Используется для перечисления TextBox, которые проверяют содержимое> 0 в качестве дополнительной проверки
        /// </summary>
        readonly TextBox[] CheckForPositiveTextBoxList;

        /// <summary>
        ///Свойство Figure, используемое для загрузки IGeometricFigure в этот элемент управления и из него.
        /// </summary>
        public IGeometricFigure Figure
		{
			get { return ConstructFigure(); }
			set { LoadFigure(value); }
		}

        /// <summary>
        /// Внутренний флаг только для чтения.
        /// </summary>
        private bool _readonly;

        /// <summary>
        /// Свойство только для чтения, отключите редактирование.
        /// </summary>
        public bool ReadOnly
		{
			get { return _readonly; }
			set
			{
				#if DEBUG 
				rndButton.Visible = !value;
				#endif
				RadiusTextBox.ReadOnly = value;
				WidthTextBox.ReadOnly = value;
				HeightTextBox.ReadOnly = value;
                SmallerRadiusTextBox.ReadOnly = value;
                LargerRadiusTextBox.ReadOnly = value;
				figureComboBox.Enabled = !value;
				_readonly = value;
			}
		}

        /// <summary>
        /// Свойство, указывающее, допустим ли ввод в этом элементе управления. Только для чтения.
        /// </summary>
        public bool IsValid
		{
			get { return ValidateData() && !ReadOnly;}
		}

        /// <summary>
        /// Конструктор контроля.
        /// </summary>
        public FigureEditControl()
		{
			
			InitializeComponent();
			
			#if DEBUG
			if (!ReadOnly)
			{
				rndButton.Visible = true;
			}
			#endif
			CheckForPositiveTextBoxList = new [] {RadiusTextBox, WidthTextBox, HeightTextBox, SmallerRadiusTextBox, LargerRadiusTextBox };
			figureComboBox.SelectedIndex = 0;
		}

        /// <summary>
        /// Фактический метод, который загружает данные фигуры в элементы управления формы.
        /// </summary>
        /// <param name="figure">Для получения данных Figure.</param>
        private void LoadFigure(IGeometricFigure figure)
		{
			if (figure is Circle) {
				figureComboBox.SelectedIndex = 0;
				RadiusTextBox.Text = ((Circle)figure).Radius.ToString();
			} else if (figure is Rectangle) {
				figureComboBox.SelectedIndex = 1;
				WidthTextBox.Text = ((Rectangle)figure).Width.ToString();
				HeightTextBox.Text = ((Rectangle)figure).Height.ToString();
			} else if (figure is Ellipse) {
                figureComboBox.SelectedIndex = 2;
                SmallerRadiusTextBox.Text = ((Ellipse)figure).SmallerRadius.ToString();
                LargerRadiusTextBox.Text = ((Ellipse)figure).LargerRadius.ToString();
			}
		}

        /// <summary>
        /// Управляет видимостью фигурных панелей.
        /// </summary>
        /// <param name="sender">Элемент управления, который запустил событие, comboBox1.</param>
        /// <param name="e">Событие аргумент arguments.</param>
        private void ComboBox1SelectedValueChanged(object sender, EventArgs e)
		{
			CirclePanel.Visible = figureComboBox.SelectedIndex == 0;
			RectanglePanel.Visible = figureComboBox.SelectedIndex == 1;
			EllipsePanel.Visible = figureComboBox.SelectedIndex == 2;
			RaiseMyValidatedEvent(this, null);
		}

        /// <summary>
        /// Нажмите «Generate random figure». Изменяет данные формы на случайную действительную цифру.
        /// </summary>
        /// <param name="sender">Cобытия sender, RndButton.</param>
        /// <param name="e">Событие arguments.</param>
        private void RndButtonClick(object sender, EventArgs e)
		{
			var rnd = new RandomFigure();
			LoadFigure(rnd.NextFigure());
		}

        /// <summary>
        /// Устанавливает состояние кнопки «ОК» на основе целостности данных при изменениях TextBox.
        /// </summary>
        /// <param name="sender">События sender, все текстовые поля формы.</param>
        /// <param name="e">Событие arguments.</param>
        private void TextBoxTextChanged(object sender, EventArgs e)
		{
			RaiseMyValidatedEvent(this, null);
		}

        /// <summary>
        /// Проверяет, действительны ли данные TextBox: можно преобразовать в double,
        /// и, в некоторых случаях, больше нуля (как радиус круга).
        /// Также устанавливает шрифт на основе результата этой проверки.
        /// </summary>
        /// <param name="tb">Проверка TextBox.</param>
        /// <returns> True, когда данные действительны, false, если нет.</returns>
        private bool DataCheck(TextBox tb)
		{
			bool success = true;
			try 
			{
				double d = Convert.ToDouble(tb.Text);
				success = CheckForPositiveTextBoxList.Contains(tb) ? Util.IsValidPositive(d) : Util.IsValid(d);
			} 
			catch (FormatException)
			{
				success = false;
			} 
			catch (OverflowException)
			{
				success = false;
			}
			var fontStyle = success ? System.Drawing.FontStyle.Regular : System.Drawing.FontStyle.Bold;
			if (tb.Font.Style != fontStyle) {
				tb.Font = new System.Drawing.Font(tb.Font, fontStyle);
			}
			return success;
		}

        /// <summary>
        ///Проверяет все текстовые поля, связанные с выбранным типом фигуры.
        /// </summary>
        /// <returns> True, когда данные действительны и фигура может быть построена, False, если данные неправильные</returns>
        private bool ValidateData()
		{
			Panel panelToCheck;
			switch (figureComboBox.SelectedIndex) 
			{
				case 0:
					panelToCheck = CirclePanel;
					break;
				case 1:
					panelToCheck = RectanglePanel;
					break;
				case 2:
					panelToCheck = EllipsePanel;
					break;
				default:
					throw new NotImplementedException();
			}
			foreach (var control in panelToCheck.Controls) 
			{
				if (control is TextBox) 
				{
					if (!DataCheck((TextBox)control)) 
					{
						return false;
					}
				}
			}
			return true;
		}

        /// <summary>
        /// Создает предка IGeometricFigure на основе текущих данных формы.
        /// </summary>
        /// <returns>Новая геометрическая фигура.</returns>
        private IGeometricFigure ConstructFigure()
		{
			switch (figureComboBox.SelectedIndex) 
			{
				case 0:
					return GetCircle();
				case 1:
					return GetRectangle();
				case 2:
                    return GetEllipse();
				default:
					throw new IndexOutOfRangeException("Неизвестный показатель индекса");
			}
		}

        /// <summary>
        /// Создает Круг из данных формы. Выдает ArgumentException, когда не удается загрузить радиус.
        /// </summary>
        /// <returns>Новый круг из данных формы.</returns>
        private Circle GetCircle()
		{
			try 
			{
				var radius = Convert.ToDouble(RadiusTextBox.Text);
				return new Circle(radius);
			}
			catch (FormatException) 
			{
				throw new ArgumentException("Неверные данные в текстовом поле радиуса.");
			}
		}

        /// <summary>
        /// Создает прямоугольник из данных формы. Выдает исключение ArgumentException, когда не удается загрузить ширину и / или высоту.
        /// </summary>
        /// <returns>Новый прямоугольник из данных формы.</returns>
        private Rectangle GetRectangle()
		{
			try 
			{
				var width = Convert.ToDouble(WidthTextBox.Text);
				var height = Convert.ToDouble(HeightTextBox.Text);
				return new Rectangle(width, height);
			} 
			catch (FormatException) 
			{
				throw new ArgumentException("Неверные данные в текстовых полях размеров прямоугольника.");
			}
		}

        /// <summary>
        /// Создает Эллипс из данных формы. Выдает исключение ArgumentException, когда не неверно указаны большой и/или малый радиусы.
        /// </summary>
        /// <returns>Новый Эллипс из данных формы.</returns>
        private Ellipse GetEllipse()
		{
            try
            {
                var smallradius = Convert.ToDouble(SmallerRadiusTextBox.Text);
                var lrgradius = Convert.ToDouble(LargerRadiusTextBox.Text);
                return new Ellipse(smallradius, lrgradius);
            }
            catch (FormatException)
            {
                throw new ArgumentException("Неверные данные в текстовых полях размеров эллипса.");
            }
        }

        /// <summary>
        /// Вызывает пользовательское событие с проверкой null.
        /// </summary>
        /// <param name="sender">Cобытия sender, скорее всего это.</param>
        /// <param name="e">Cобытия argument, null.</param>
        private void RaiseMyValidatedEvent(object sender, EventArgs e)
		{
			if (this.MyValidatedEvent != null)
				this.MyValidatedEvent(sender, e);
		}

        private void figureComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SmallerRadius_Click(object sender, EventArgs e)
        {

        }
    }
}
