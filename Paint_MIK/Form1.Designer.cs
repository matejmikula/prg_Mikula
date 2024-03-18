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
            ((System.ComponentModel.ISupportInitialize)(this.sizeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opacityBar)).BeginInit();
            this.SuspendLayout();
            // 
            // colorButton
            // 
            this.colorButton.Location = new System.Drawing.Point(13, 14);
            this.colorButton.Margin = new System.Windows.Forms.Padding(2);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(82, 37);
            this.colorButton.TabIndex = 0;
            this.colorButton.Text = "Color";
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 133);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1078, 511);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // eraseButton
            // 
            this.eraseButton.Location = new System.Drawing.Point(99, 14);
            this.eraseButton.Margin = new System.Windows.Forms.Padding(2);
            this.eraseButton.Name = "eraseButton";
            this.eraseButton.Size = new System.Drawing.Size(82, 36);
            this.eraseButton.TabIndex = 2;
            this.eraseButton.Text = "Erase all";
            this.eraseButton.UseVisualStyleBackColor = true;
            this.eraseButton.Click += new System.EventHandler(this.eraseButton_Click);
            // 
            // sizeBar
            // 
            this.sizeBar.LargeChange = 1;
            this.sizeBar.Location = new System.Drawing.Point(464, 5);
            this.sizeBar.Margin = new System.Windows.Forms.Padding(2);
            this.sizeBar.Name = "sizeBar";
            this.sizeBar.Size = new System.Drawing.Size(114, 69);
            this.sizeBar.TabIndex = 3;
            this.sizeBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.sizeBar.Scroll += new System.EventHandler(this.sizeBar_Scroll);
            // 
            // sizeBox
            // 
            this.sizeBox.Location = new System.Drawing.Point(474, 44);
            this.sizeBox.Margin = new System.Windows.Forms.Padding(2);
            this.sizeBox.Name = "sizeBox";
            this.sizeBox.Size = new System.Drawing.Size(77, 20);
            this.sizeBox.TabIndex = 4;
            // 
            // eraserButton
            // 
            this.eraserButton.Location = new System.Drawing.Point(185, 14);
            this.eraserButton.Margin = new System.Windows.Forms.Padding(2);
            this.eraserButton.Name = "eraserButton";
            this.eraserButton.Size = new System.Drawing.Size(82, 36);
            this.eraserButton.TabIndex = 5;
            this.eraserButton.Text = "Eraser";
            this.eraserButton.UseVisualStyleBackColor = true;
            this.eraserButton.Click += new System.EventHandler(this.eraserButton_Click);
            // 
            // penButton
            // 
            this.penButton.AutoSize = true;
            this.penButton.Location = new System.Drawing.Point(280, 7);
            this.penButton.Margin = new System.Windows.Forms.Padding(2);
            this.penButton.Name = "penButton";
            this.penButton.Size = new System.Drawing.Size(51, 20);
            this.penButton.TabIndex = 6;
            this.penButton.TabStop = true;
            this.penButton.Text = "Pen";
            this.penButton.UseVisualStyleBackColor = true;
            this.penButton.CheckedChanged += new System.EventHandler(this.penButton_CheckedChanged);
            // 
            // sprayButton
            // 
            this.sprayButton.AutoSize = true;
            this.sprayButton.Location = new System.Drawing.Point(280, 27);
            this.sprayButton.Margin = new System.Windows.Forms.Padding(2);
            this.sprayButton.Name = "sprayButton";
            this.sprayButton.Size = new System.Drawing.Size(59, 20);
            this.sprayButton.TabIndex = 7;
            this.sprayButton.TabStop = true;
            this.sprayButton.Text = "Spray";
            this.sprayButton.UseVisualStyleBackColor = true;
            this.sprayButton.CheckedChanged += new System.EventHandler(this.sprayButton_CheckedChanged);
            // 
            // opacityBar
            // 
            this.opacityBar.Location = new System.Drawing.Point(344, 5);
            this.opacityBar.Name = "opacityBar";
            this.opacityBar.Size = new System.Drawing.Size(125, 69);
            this.opacityBar.TabIndex = 8;
            this.opacityBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.opacityBar.Scroll += new System.EventHandler(this.opacityBar_Scroll);
            // 
            // opacityBox
            // 
            this.opacityBox.Location = new System.Drawing.Point(353, 44);
            this.opacityBox.Margin = new System.Windows.Forms.Padding(2);
            this.opacityBox.Name = "opacityBox";
            this.opacityBox.Size = new System.Drawing.Size(77, 20);
            this.opacityBox.TabIndex = 9;
            // 
            // ellipseButton
            // 
            this.ellipseButton.AutoSize = true;
            this.ellipseButton.Location = new System.Drawing.Point(13, 56);
            this.ellipseButton.Name = "ellipseButton";
            this.ellipseButton.Size = new System.Drawing.Size(58, 20);
            this.ellipseButton.TabIndex = 10;
            this.ellipseButton.TabStop = true;
            this.ellipseButton.Text = "Circle";
            this.ellipseButton.UseVisualStyleBackColor = true;
            this.ellipseButton.CheckedChanged += new System.EventHandler(this.ellipseButton_CheckedChanged);
            // 
            // rectButton
            // 
            this.rectButton.AutoSize = true;
            this.rectButton.Location = new System.Drawing.Point(99, 55);
            this.rectButton.Name = "rectButton";
            this.rectButton.Size = new System.Drawing.Size(81, 20);
            this.rectButton.TabIndex = 11;
            this.rectButton.TabStop = true;
            this.rectButton.Text = "Rectangle";
            this.rectButton.UseVisualStyleBackColor = true;
            this.rectButton.CheckedChanged += new System.EventHandler(this.rectButton_CheckedChanged);
            // 
            // ellipseFillButton
            // 
            this.ellipseFillButton.AutoSize = true;
            this.ellipseFillButton.Location = new System.Drawing.Point(13, 82);
            this.ellipseFillButton.Name = "ellipseFillButton";
            this.ellipseFillButton.Size = new System.Drawing.Size(85, 20);
            this.ellipseFillButton.TabIndex = 12;
            this.ellipseFillButton.TabStop = true;
            this.ellipseFillButton.Text = "Circle Filled";
            this.ellipseFillButton.UseVisualStyleBackColor = true;
            this.ellipseFillButton.CheckedChanged += new System.EventHandler(this.ellipseFillButton_CheckedChanged);
            // 
            // rectFillButton
            // 
            this.rectFillButton.AutoSize = true;
            this.rectFillButton.Location = new System.Drawing.Point(99, 81);
            this.rectFillButton.Name = "rectFillButton";
            this.rectFillButton.Size = new System.Drawing.Size(108, 20);
            this.rectFillButton.TabIndex = 13;
            this.rectFillButton.TabStop = true;
            this.rectFillButton.Text = "Rectangle Filled";
            this.rectFillButton.UseVisualStyleBackColor = true;
            // 
            // lineButton
            // 
            this.lineButton.AutoSize = true;
            this.lineButton.Location = new System.Drawing.Point(186, 56);
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(52, 20);
            this.lineButton.TabIndex = 14;
            this.lineButton.TabStop = true;
            this.lineButton.Text = "Line";
            this.lineButton.UseVisualStyleBackColor = true;
            this.lineButton.CheckedChanged += new System.EventHandler(this.lineButton_CheckedChanged);
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(609, 10);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(82, 37);
            this.helpButton.TabIndex = 15;
            this.helpButton.Text = "HELP?";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 644);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.lineButton);
            this.Controls.Add(this.rectFillButton);
            this.Controls.Add(this.ellipseFillButton);
            this.Controls.Add(this.rectButton);
            this.Controls.Add(this.ellipseButton);
            this.Controls.Add(this.opacityBox);
            this.Controls.Add(this.opacityBar);
            this.Controls.Add(this.sprayButton);
            this.Controls.Add(this.penButton);
            this.Controls.Add(this.eraserButton);
            this.Controls.Add(this.sizeBox);
            this.Controls.Add(this.sizeBar);
            this.Controls.Add(this.eraseButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.colorButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
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
    }
}

