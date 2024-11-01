namespace FormsIntroduction
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
            this.startPause = new System.Windows.Forms.Button();
            this.timeElapsed = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // startPause
            // 
            this.startPause.Location = new System.Drawing.Point(152, 257);
            this.startPause.Name = "startPause";
            this.startPause.Size = new System.Drawing.Size(176, 96);
            this.startPause.TabIndex = 0;
            this.startPause.Text = "Start/pause";
            this.startPause.UseVisualStyleBackColor = true;
            this.startPause.Click += new System.EventHandler(this.startPause_Click);
            // 
            // timeElapsed
            // 
            this.timeElapsed.Location = new System.Drawing.Point(154, 43);
            this.timeElapsed.Name = "timeElapsed";
            this.timeElapsed.Size = new System.Drawing.Size(173, 26);
            this.timeElapsed.TabIndex = 1;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(478, 444);
            this.Controls.Add(this.timeElapsed);
            this.Controls.Add(this.startPause);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button startPause;
        private System.Windows.Forms.TextBox timeElapsed;
    }
}

