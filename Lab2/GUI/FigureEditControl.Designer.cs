
namespace GUI
{
	partial class FigureEditControl
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ComboBox figureComboBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button rndButton;
		private System.Windows.Forms.Panel CirclePanel;
		private System.Windows.Forms.TextBox RadiusTextBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel RectanglePanel;
		private System.Windows.Forms.Panel EllipsePanel;
		private System.Windows.Forms.TextBox LargerRadiusTextBox;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox SmallerRadiusTextBox;
		private System.Windows.Forms.Label SmallerRadius;
		private System.Windows.Forms.TextBox HeightTextBox;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox WidthTextBox;
		private System.Windows.Forms.Label label8;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.figureComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rndButton = new System.Windows.Forms.Button();
            this.CirclePanel = new System.Windows.Forms.Panel();
            this.RadiusTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RectanglePanel = new System.Windows.Forms.Panel();
            this.HeightTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.WidthTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.EllipsePanel = new System.Windows.Forms.Panel();
            this.LargerRadiusTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.SmallerRadiusTextBox = new System.Windows.Forms.TextBox();
            this.SmallerRadius = new System.Windows.Forms.Label();
            this.CirclePanel.SuspendLayout();
            this.RectanglePanel.SuspendLayout();
            this.EllipsePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // figureComboBox
            // 
            this.figureComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.figureComboBox.FormattingEnabled = true;
            this.figureComboBox.Items.AddRange(new object[] {
            "Circle",
            "Rectangle",
            "Ellipse",
            "Triangle"});
            this.figureComboBox.Location = new System.Drawing.Point(72, 7);
            this.figureComboBox.Name = "figureComboBox";
            this.figureComboBox.Size = new System.Drawing.Size(120, 21);
            this.figureComboBox.TabIndex = 0;
            this.figureComboBox.SelectedValueChanged += new System.EventHandler(this.ComboBox1SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Figure type:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rndButton
            // 
            this.rndButton.Location = new System.Drawing.Point(8, 215);
            this.rndButton.Name = "rndButton";
            this.rndButton.Size = new System.Drawing.Size(184, 21);
            this.rndButton.TabIndex = 4;
            this.rndButton.Text = "Generate random figure";
            this.rndButton.UseVisualStyleBackColor = true;
            this.rndButton.Visible = false;
            this.rndButton.Click += new System.EventHandler(this.RndButtonClick);
            // 
            // CirclePanel
            // 
            this.CirclePanel.Controls.Add(this.RadiusTextBox);
            this.CirclePanel.Controls.Add(this.label4);
            this.CirclePanel.Location = new System.Drawing.Point(8, 34);
            this.CirclePanel.Name = "CirclePanel";
            this.CirclePanel.Size = new System.Drawing.Size(184, 134);
            this.CirclePanel.TabIndex = 5;
            // 
            // RadiusTextBox
            // 
            this.RadiusTextBox.Location = new System.Drawing.Point(64, 0);
            this.RadiusTextBox.MaxLength = 40;
            this.RadiusTextBox.Name = "RadiusTextBox";
            this.RadiusTextBox.Size = new System.Drawing.Size(120, 20);
            this.RadiusTextBox.TabIndex = 11;
            this.RadiusTextBox.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Radius:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RectanglePanel
            // 
            this.RectanglePanel.Controls.Add(this.HeightTextBox);
            this.RectanglePanel.Controls.Add(this.label9);
            this.RectanglePanel.Controls.Add(this.WidthTextBox);
            this.RectanglePanel.Controls.Add(this.label8);
            this.RectanglePanel.Location = new System.Drawing.Point(8, 34);
            this.RectanglePanel.Name = "RectanglePanel";
            this.RectanglePanel.Size = new System.Drawing.Size(184, 134);
            this.RectanglePanel.TabIndex = 12;
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.Location = new System.Drawing.Point(64, 22);
            this.HeightTextBox.MaxLength = 40;
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.Size = new System.Drawing.Size(120, 20);
            this.HeightTextBox.TabIndex = 17;
            this.HeightTextBox.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(0, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 19);
            this.label9.TabIndex = 16;
            this.label9.Text = "Height:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // WidthTextBox
            // 
            this.WidthTextBox.Location = new System.Drawing.Point(64, 0);
            this.WidthTextBox.MaxLength = 40;
            this.WidthTextBox.Name = "WidthTextBox";
            this.WidthTextBox.Size = new System.Drawing.Size(120, 20);
            this.WidthTextBox.TabIndex = 15;
            this.WidthTextBox.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 19);
            this.label8.TabIndex = 14;
            this.label8.Text = "Width:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EllipsePanel
            // 
            this.EllipsePanel.Controls.Add(this.LargerRadiusTextBox);
            this.EllipsePanel.Controls.Add(this.label11);
            this.EllipsePanel.Controls.Add(this.SmallerRadiusTextBox);
            this.EllipsePanel.Controls.Add(this.SmallerRadius);
            this.EllipsePanel.Location = new System.Drawing.Point(8, 34);
            this.EllipsePanel.Name = "EllipsePanel";
            this.EllipsePanel.Size = new System.Drawing.Size(184, 134);
            this.EllipsePanel.TabIndex = 13;
            // 
            // LargerRadiusTextBox
            // 
            this.LargerRadiusTextBox.Location = new System.Drawing.Point(64, 0);
            this.LargerRadiusTextBox.MaxLength = 40;
            this.LargerRadiusTextBox.Name = "LargerRadiusTextBox";
            this.LargerRadiusTextBox.Size = new System.Drawing.Size(120, 20);
            this.LargerRadiusTextBox.TabIndex = 19;
            this.LargerRadiusTextBox.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(0, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 19);
            this.label11.TabIndex = 20;
            this.label11.Text = "Smaller Radius";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SmallerRadiusTextBox
            // 
            this.SmallerRadiusTextBox.Location = new System.Drawing.Point(64, 22);
            this.SmallerRadiusTextBox.MaxLength = 40;
            this.SmallerRadiusTextBox.Name = "SmallerRadiusTextBox";
            this.SmallerRadiusTextBox.Size = new System.Drawing.Size(120, 20);
            this.SmallerRadiusTextBox.TabIndex = 21;
            this.SmallerRadiusTextBox.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            // 
            // SmallerRadius
            // 
            this.SmallerRadius.Location = new System.Drawing.Point(0, 0);
            this.SmallerRadius.Name = "SmallerRadius";
            this.SmallerRadius.Size = new System.Drawing.Size(64, 19);
            this.SmallerRadius.TabIndex = 18;
            this.SmallerRadius.Text = "Larger Radius";
            this.SmallerRadius.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SmallerRadius.Click += new System.EventHandler(this.SmallerRadius_Click);
            // 
            // FigureEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RectanglePanel);
            this.Controls.Add(this.CirclePanel);
            this.Controls.Add(this.rndButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.figureComboBox);
            this.Controls.Add(this.EllipsePanel);
            this.Name = "FigureEditControl";
            this.Size = new System.Drawing.Size(206, 240);
            this.CirclePanel.ResumeLayout(false);
            this.CirclePanel.PerformLayout();
            this.RectanglePanel.ResumeLayout(false);
            this.RectanglePanel.PerformLayout();
            this.EllipsePanel.ResumeLayout(false);
            this.EllipsePanel.PerformLayout();
            this.ResumeLayout(false);

		}
	}
}
