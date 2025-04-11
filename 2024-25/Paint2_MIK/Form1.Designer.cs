namespace Paint_MIK
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.colorButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.eraseButton = new System.Windows.Forms.Button();
            this.sizeBar = new System.Windows.Forms.TrackBar();
            this.sizeBox = new System.Windows.Forms.TextBox();
            this.eraserButton = new System.Windows.Forms.Button();
            this.penButton = new System.Windows.Forms.RadioButton();
            this.sprayButton = new System.Windows.Forms.RadioButton();
            this.opacityBar = new System.Windows.Forms.TrackBar();
            this.opacityBox = new System.Windows.Forms.TextBox();
            this.ellipseButton = new System.Windows.Forms.RadioButton();
            this.rectButton = new System.Windows.Forms.RadioButton();
            this.ellipseFillButton = new System.Windows.Forms.RadioButton();
            this.rectFillButton = new System.Windows.Forms.RadioButton();
            this.lineButton = new System.Windows.Forms.RadioButton();
            this.helpButton = new System.Windows.Forms.Button();
            this.imageButton = new System.Windows.Forms.Button();
            this.imgButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textButton = new System.Windows.Forms.RadioButton();
            this.changeFontButton = new System.Windows.Forms.Button();
            this.starButton = new System.Windows.Forms.RadioButton();
            this.starFilledButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.sizeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opacityBar)).BeginInit();
            this.SuspendLayout();
            // 
            // colorButton
            // 
            this.colorButton.Location = new System.Drawing.Point(214, 18);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(123, 57);
            this.colorButton.TabIndex = 0;
            this.colorButton.Text = "Color";
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 277);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1628, 467);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // eraseButton
            // 
            this.eraseButton.Location = new System.Drawing.Point(1157, 18);
            this.eraseButton.Name = "eraseButton";
            this.eraseButton.Size = new System.Drawing.Size(123, 55);
            this.eraseButton.TabIndex = 2;
            this.eraseButton.Text = "Erase all";
            this.eraseButton.UseVisualStyleBackColor = true;
            this.eraseButton.Click += new System.EventHandler(this.eraseButton_Click);
            // 
            // sizeBar
            // 
            this.sizeBar.LargeChange = 1;
            this.sizeBar.Location = new System.Drawing.Point(1308, 8);
            this.sizeBar.Name = "sizeBar";
            this.sizeBar.Size = new System.Drawing.Size(171, 69);
            this.sizeBar.TabIndex = 3;
            this.sizeBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.sizeBar.Scroll += new System.EventHandler(this.sizeBar_Scroll);
            // 
            // sizeBox
            // 
            this.sizeBox.Location = new System.Drawing.Point(1308, 85);
            this.sizeBox.Name = "sizeBox";
            this.sizeBox.Size = new System.Drawing.Size(114, 26);
            this.sizeBox.TabIndex = 4;
            // 
            // eraserButton
            // 
            this.eraserButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("eraserButton.BackgroundImage")));
            this.eraserButton.Location = new System.Drawing.Point(1157, 106);
            this.eraserButton.Name = "eraserButton";
            this.eraserButton.Size = new System.Drawing.Size(123, 55);
            this.eraserButton.TabIndex = 5;
            this.eraserButton.Text = "Eraser";
            this.eraserButton.UseVisualStyleBackColor = true;
            this.eraserButton.Click += new System.EventHandler(this.eraserButton_Click);
            // 
            // penButton
            // 
            this.penButton.AutoSize = true;
            this.penButton.Location = new System.Drawing.Point(379, 33);
            this.penButton.Name = "penButton";
            this.penButton.Size = new System.Drawing.Size(62, 24);
            this.penButton.TabIndex = 6;
            this.penButton.TabStop = true;
            this.penButton.Text = "Pen";
            this.penButton.UseVisualStyleBackColor = true;
            // 
            // sprayButton
            // 
            this.sprayButton.AutoSize = true;
            this.sprayButton.Location = new System.Drawing.Point(379, 63);
            this.sprayButton.Name = "sprayButton";
            this.sprayButton.Size = new System.Drawing.Size(75, 24);
            this.sprayButton.TabIndex = 7;
            this.sprayButton.TabStop = true;
            this.sprayButton.Text = "Spray";
            this.sprayButton.UseVisualStyleBackColor = true;
            // 
            // opacityBar
            // 
            this.opacityBar.Location = new System.Drawing.Point(18, 8);
            this.opacityBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.opacityBar.Name = "opacityBar";
            this.opacityBar.Size = new System.Drawing.Size(188, 69);
            this.opacityBar.TabIndex = 8;
            this.opacityBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.opacityBar.Scroll += new System.EventHandler(this.opacityBar_Scroll);
            // 
            // opacityBox
            // 
            this.opacityBox.Location = new System.Drawing.Point(18, 106);
            this.opacityBox.Name = "opacityBox";
            this.opacityBox.Size = new System.Drawing.Size(114, 26);
            this.opacityBox.TabIndex = 9;
            // 
            // ellipseButton
            // 
            this.ellipseButton.AutoSize = true;
            this.ellipseButton.Location = new System.Drawing.Point(479, 69);
            this.ellipseButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ellipseButton.Name = "ellipseButton";
            this.ellipseButton.Size = new System.Drawing.Size(73, 24);
            this.ellipseButton.TabIndex = 10;
            this.ellipseButton.TabStop = true;
            this.ellipseButton.Text = "Circle";
            this.ellipseButton.UseVisualStyleBackColor = true;
            this.ellipseButton.CheckedChanged += new System.EventHandler(this.ellipseButton_CheckedChanged);
            // 
            // rectButton
            // 
            this.rectButton.AutoSize = true;
            this.rectButton.Location = new System.Drawing.Point(479, 35);
            this.rectButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rectButton.Name = "rectButton";
            this.rectButton.Size = new System.Drawing.Size(107, 24);
            this.rectButton.TabIndex = 11;
            this.rectButton.TabStop = true;
            this.rectButton.Text = "Rectangle";
            this.rectButton.UseVisualStyleBackColor = true;
            // 
            // ellipseFillButton
            // 
            this.ellipseFillButton.AutoSize = true;
            this.ellipseFillButton.Location = new System.Drawing.Point(613, 69);
            this.ellipseFillButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ellipseFillButton.Name = "ellipseFillButton";
            this.ellipseFillButton.Size = new System.Drawing.Size(114, 24);
            this.ellipseFillButton.TabIndex = 12;
            this.ellipseFillButton.TabStop = true;
            this.ellipseFillButton.Text = "Circle Filled";
            this.ellipseFillButton.UseVisualStyleBackColor = true;
            this.ellipseFillButton.CheckedChanged += new System.EventHandler(this.ellipseFillButton_CheckedChanged);
            // 
            // rectFillButton
            // 
            this.rectFillButton.AutoSize = true;
            this.rectFillButton.Location = new System.Drawing.Point(613, 35);
            this.rectFillButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rectFillButton.Name = "rectFillButton";
            this.rectFillButton.Size = new System.Drawing.Size(148, 24);
            this.rectFillButton.TabIndex = 13;
            this.rectFillButton.TabStop = true;
            this.rectFillButton.Text = "Rectangle Filled";
            this.rectFillButton.UseVisualStyleBackColor = true;
            // 
            // lineButton
            // 
            this.lineButton.AutoSize = true;
            this.lineButton.Location = new System.Drawing.Point(1049, 51);
            this.lineButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(64, 24);
            this.lineButton.TabIndex = 14;
            this.lineButton.TabStop = true;
            this.lineButton.Text = "Line";
            this.lineButton.UseVisualStyleBackColor = true;
            this.lineButton.CheckedChanged += new System.EventHandler(this.lineButton_CheckedChanged);
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(214, 144);
            this.helpButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(123, 57);
            this.helpButton.TabIndex = 15;
            this.helpButton.Text = "HELP?";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // imageButton
            // 
            this.imageButton.Location = new System.Drawing.Point(811, 35);
            this.imageButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.imageButton.Name = "imageButton";
            this.imageButton.Size = new System.Drawing.Size(230, 141);
            this.imageButton.TabIndex = 16;
            this.imageButton.UseVisualStyleBackColor = true;
            this.imageButton.Click += new System.EventHandler(this.imageButton_Click);
            // 
            // imgButton
            // 
            this.imgButton.AutoSize = true;
            this.imgButton.Location = new System.Drawing.Point(863, 184);
            this.imgButton.Name = "imgButton";
            this.imgButton.Size = new System.Drawing.Size(143, 24);
            this.imgButton.TabIndex = 17;
            this.imgButton.TabStop = true;
            this.imgButton.Text = "Image insertion";
            this.imgButton.UseVisualStyleBackColor = true;
            this.imgButton.CheckedChanged += new System.EventHandler(this.imgButton_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(859, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Image Selection";
            // 
            // textButton
            // 
            this.textButton.AutoSize = true;
            this.textButton.Location = new System.Drawing.Point(379, 93);
            this.textButton.Name = "textButton";
            this.textButton.Size = new System.Drawing.Size(64, 24);
            this.textButton.TabIndex = 19;
            this.textButton.TabStop = true;
            this.textButton.Text = "Text";
            this.textButton.UseVisualStyleBackColor = true;
            this.textButton.CheckedChanged += new System.EventHandler(this.textButton_CheckedChanged);
            // 
            // changeFontButton
            // 
            this.changeFontButton.Location = new System.Drawing.Point(214, 81);
            this.changeFontButton.Name = "changeFontButton";
            this.changeFontButton.Size = new System.Drawing.Size(123, 55);
            this.changeFontButton.TabIndex = 20;
            this.changeFontButton.Text = "Text Font";
            this.changeFontButton.UseVisualStyleBackColor = true;
            this.changeFontButton.Click += new System.EventHandler(this.changeFontButton_Click);
            // 
            // starButton
            // 
            this.starButton.AutoSize = true;
            this.starButton.Location = new System.Drawing.Point(479, 101);
            this.starButton.Name = "starButton";
            this.starButton.Size = new System.Drawing.Size(64, 24);
            this.starButton.TabIndex = 21;
            this.starButton.TabStop = true;
            this.starButton.Text = "Star";
            this.starButton.UseVisualStyleBackColor = true;
            this.starButton.CheckedChanged += new System.EventHandler(this.starButton_CheckedChanged);
            // 
            // starFilledButton
            // 
            this.starFilledButton.AutoSize = true;
            this.starFilledButton.Location = new System.Drawing.Point(613, 101);
            this.starFilledButton.Name = "starFilledButton";
            this.starFilledButton.Size = new System.Drawing.Size(105, 24);
            this.starFilledButton.TabIndex = 22;
            this.starFilledButton.TabStop = true;
            this.starFilledButton.Text = "Star Filled";
            this.starFilledButton.UseVisualStyleBackColor = true;
            this.starFilledButton.CheckedChanged += new System.EventHandler(this.starFilledButton_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1628, 744);
            this.Controls.Add(this.starFilledButton);
            this.Controls.Add(this.starButton);
            this.Controls.Add(this.changeFontButton);
            this.Controls.Add(this.textButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imgButton);
            this.Controls.Add(this.imageButton);
            this.Controls.Add(this.lineButton);
            this.Controls.Add(this.sprayButton);
            this.Controls.Add(this.ellipseButton);
            this.Controls.Add(this.ellipseFillButton);
            this.Controls.Add(this.rectFillButton);
            this.Controls.Add(this.penButton);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.rectButton);
            this.Controls.Add(this.eraserButton);
            this.Controls.Add(this.sizeBox);
            this.Controls.Add(this.opacityBar);
            this.Controls.Add(this.opacityBox);
            this.Controls.Add(this.sizeBar);
            this.Controls.Add(this.eraseButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.colorButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.sizeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opacityBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button eraseButton;
        private System.Windows.Forms.TrackBar sizeBar;
        private System.Windows.Forms.TextBox sizeBox;
        private System.Windows.Forms.Button eraserButton;
        private System.Windows.Forms.RadioButton penButton;
        private System.Windows.Forms.RadioButton sprayButton;
        private System.Windows.Forms.TrackBar opacityBar;
        private System.Windows.Forms.TextBox opacityBox;
        private System.Windows.Forms.RadioButton ellipseButton;
        private System.Windows.Forms.RadioButton rectButton;
        private System.Windows.Forms.RadioButton ellipseFillButton;
        private System.Windows.Forms.RadioButton rectFillButton;
        private System.Windows.Forms.RadioButton lineButton;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Button imageButton;
        private System.Windows.Forms.RadioButton imgButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton textButton;
        private System.Windows.Forms.Button changeFontButton;
        private System.Windows.Forms.RadioButton starButton;
        private System.Windows.Forms.RadioButton starFilledButton;
    }
}

