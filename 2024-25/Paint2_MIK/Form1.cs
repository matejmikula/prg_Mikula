﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ScrollBar;

namespace Paint_MIK
{
    public partial class Form1 : Form
    {
        // grafický základ pro malování
        Graphics g;
        float s;
        int x = -1, y = -1;
        bool moving;
        Pen pen;
        Brush spray, brush; 
        public Random rnd = new Random(); 
        Image currentImage; 

        // proměnné pro psaní textu
        private bool textMode = false;
        private Font textFont = new Font("Arial", 12); 
        private Point textStartPoint; 
        private List<TextItem> textItems = new List<TextItem>(); 
        private System.Windows.Forms.TextBox textInputBox; 

        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics(); // grafický kontext pro malování
            s = 5;
            pen = new Pen(Color.Black, s); // základ pro pero
            brush = new SolidBrush(Color.Black); // základ pro brush
            spray = new SolidBrush(Color.Black); // základ pro sprej

            colorButton.ForeColor = Color.White; // stanovení barevného základu
            colorButton.BackColor = Color.Black; 

            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round; 
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; 

            sizeBar.Maximum = 20; // Maximální velikost 
            opacityBar.Maximum = 255; // Maximální neprůhlednost

            // vytvoření a konfigurace text boxu
            textInputBox = new System.Windows.Forms.TextBox();
            textInputBox.Visible = false;
            textInputBox.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(textInputBox);
            textInputBox.Leave += TextInputBox_Leave;
            textInputBox.KeyDown += TextInputBox_KeyDown;
        }

        private void sizeBar_Scroll(object sender, EventArgs e)
        {
            // zadefinování scroll baru pro velikost a jeho updatování
            sizeBox.Text = "" + sizeBar.Value;
            pen.Width = sizeBar.Value;
            s = pen.Width;
            spray = new SolidBrush(pen.Color);
        }

        private void opacityBar_Scroll(object sender, EventArgs e)
        {
            // to samé pro neprůhlednost
            opacityBox.Text = "" + opacityBar.Value;
            int alpha = opacityBar.Value;
            Color currentColor = pen.Color;
            Color newColor = Color.FromArgb(alpha, currentColor.R, currentColor.G, currentColor.B);
            pen.Color = newColor;
            spray = new SolidBrush(pen.Color);
            brush = new SolidBrush(pen.Color);
        }

        private void helpButton_Click(object sender, EventArgs e) // vyskakovací okno s nápovědou na použití
        {
            string message = "INTRODUCTION " + Environment.NewLine + Environment.NewLine +
                            "COLOR BUTTON: Color window will appear, changes colors of all tools and objects you´ll draw." + Environment.NewLine +
                            "HELP?: ..." + Environment.NewLine + Environment.NewLine +
                            "PEN: Casual pen (can change width, opacity and color)" + Environment.NewLine +
                            "SPRAY: Drawing tool that looks like a spray (same changebility as is with pen)" + Environment.NewLine + Environment.NewLine +
                            "ERASE ALL: Everything on the panel will be deleted after clicking." + Environment.NewLine +
                            "ERASER: For using the currently picked tool as an eraser" + Environment.NewLine +
                            "After using the eraser new color is needed to be picked else the tools wont draw anything" + Environment.NewLine +
                            "You can see the currently picked color on the color button" + Environment.NewLine + Environment.NewLine +
                            "CIRCLE: Draws an unfilled circle" + Environment.NewLine +
                            "CIRCLE FILLED: Draws a filled circle" + Environment.NewLine + Environment.NewLine +
                            "RECTANGLE: Draws an unfilled rectangle" + Environment.NewLine +
                            "RECTANGLE FILLED: Draws a filled rectangle" + Environment.NewLine + Environment.NewLine +
                            "STAR: Draws a 5-point star" + Environment.NewLine +
                            "STAR FILLED: Draws a filled 5-point star" + Environment.NewLine + Environment.NewLine +
                            "TEXT: Makes a textbox that you can place and write into it" + Environment.NewLine +
                            "TEXT FONT: Text font window will appear, changes font of all text written" + Environment.NewLine + Environment.NewLine +
                            "LINE: Draws perfectly straight line" + Environment.NewLine + Environment.NewLine +
                            "LEFT SCROLL BAR: Changes the opacity of the objects you draw" + Environment.NewLine +
                            "RIGHT SCROLL BAR: Changes the width (Thickness) of the objects you draw" + Environment.NewLine + Environment.NewLine +
                            "IMAGE SELECTION: Choose an image you want to insert" + Environment.NewLine +
                            "IMAGE INSERTION: Draws/Inserts the choosen image.";

            MessageBox.Show(message, "HELP?");
        }

        private void imageButton_Click(object sender, EventArgs e)
        {
            // otevření okna pro výběr obrázku v průzkumníku
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.gif;*.png)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG";
            openFileDialog.Title = "Select Image File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    currentImage = Image.FromFile(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message, "Error");
                }
            }

            imageButton.BackgroundImageLayout = ImageLayout.Stretch;
            imageButton.BackgroundImage = currentImage;
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            // opět okno pro výběr barvy
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pen.Color = colorDialog.Color;
                colorButton.BackColor = colorDialog.Color;

                colorButton.ForeColor = (colorDialog.Color == Color.Black) ? Color.White : Color.Black;

                spray = new SolidBrush(pen.Color);
                brush = new SolidBrush(pen.Color);
            }
        }

        private void eraseButton_Click(object sender, EventArgs e)
        {
            // smazání všeho na ploše
            g.Clear(panel1.BackColor);
            textItems.Clear();
            panel1.Invalidate();
        }

        private void eraserButton_Click(object sender, EventArgs e)
        {
            // změnění barvy štětce na barvu pozadí
            pen.Color = panel1.BackColor;
            spray = new SolidBrush(pen.Color);
            brush = new SolidBrush(pen.Color);
            colorButton.BackColor = pen.Color;
            colorButton.ForeColor = Color.Black;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            // vytvoření malůvky nebo textboxu
            moving = true;
            x = e.X;
            y = e.Y;
            panel1.Cursor = Cursors.Cross;

            if (textMode)
            {
                textInputBox.TextChanged -= ResizeTextBox;
                textInputBox.TextChanged += ResizeTextBox;
                textInputBox.Font = textFont;
                textStartPoint = e.Location;
                textInputBox.Location = textStartPoint;
                textInputBox.Visible = true;
                textInputBox.Text = "";
                textInputBox.Focus();
                textInputBox.WordWrap = true;
                ResizeTextBox(null, null);
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            // funkce pro malování, když se hýbe myš
            if (penButton.Checked && (moving || x != -1 || y != -1))
            {
                g.DrawLine(pen, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
            } // to samé ale pro sprej
            else if (sprayButton.Checked && (moving || x != -1 || y != -1))
            {
                for (int i = 0; i < 10; i++)
                {
                    int sprayX = e.X + rnd.Next(-8, 8);
                    int sprayY = e.Y + rnd.Next(-8, 8);
                    g.FillEllipse(spray, sprayX, sprayY, s, s);
                }
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            // vytvoření tvaru nebo obrázku na základě startujícího bodu (kliknutí myši) a konečného bodu (puštění stisku)
            int width = Math.Abs(e.X - x);
            int height = Math.Abs(e.Y - y);

            if (ellipseButton.Checked) g.DrawEllipse(pen, x, y, e.X - x, e.Y - y);
            else if (rectButton.Checked) g.DrawRectangle(pen, x, y, e.X - x, e.Y - y);
            else if (ellipseFillButton.Checked) g.FillEllipse(brush, x, y, e.X - x, e.Y - y);
            else if (rectFillButton.Checked) g.FillRectangle(brush, x, y, e.X - x, e.Y - y);
            else if (lineButton.Checked) g.DrawLine(pen, x, y, e.X, e.Y);
            else if (imgButton.Checked) g.DrawImage(currentImage, x, y, width, height);
            else if (starButton.Checked) DrawStar(g, pen, x, y, e.X, e.Y);
            else if (starFilledButton.Checked) FillStar(g, brush, x, y, e.X, e.Y);

            moving = false;
            x = -1;
            y = -1;
            panel1.Cursor = Cursors.Default;
        }

        private void ResizeTextBox(object sender, EventArgs e)
        {
            // automatický resize na základě velikosti fontu apod.
            using (Graphics g = textInputBox.CreateGraphics())
            {
                SizeF textSize = g.MeasureString(textInputBox.Text + "W", textFont);
                int minWidth = 50;
                int padding = 10;
                textInputBox.Width = Math.Max(minWidth, (int)textSize.Width + padding);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // přemalování všeho textu
            foreach (var item in textItems)
            {
                e.Graphics.DrawString(item.Text, item.Font, item.Brush, item.Location);
            }
        }

        private void textButton_CheckedChanged(object sender, EventArgs e)
        {
            // změna na psací mód
            textMode = textButton.Checked;
            panel1.Cursor = textMode ? Cursors.IBeam : Cursors.Default;
            if (!textMode && textInputBox.Visible)
            {
                textInputBox.Visible = false;
            }
        }

        private void TextInputBox_KeyDown(object sender, KeyEventArgs e)
        {
            // vložení textu na panel po stisknutí enteru
            if (e.KeyCode == Keys.Enter)
            {
                textItems.Add(new TextItem { Text = textInputBox.Text, Font = textFont, Brush = brush, Location = textStartPoint });
                textInputBox.Visible = false;
            }
        }

        private void TextInputBox_Leave(object sender, EventArgs e)
        {
            textItems.Add(new TextItem { Text = textInputBox.Text, Font = textFont, Brush = brush, Location = textStartPoint });
            textInputBox.Visible = false;
        }

        private void changeFontButton_Click(object sender, EventArgs e)
        {
            // otevření okna pro změnu fontu textu
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                textFont = fontDialog.Font;
            }
        }

        private void DrawStar(Graphics g, Pen pen, int x1, int y1, int x2, int y2)
        {
            // vytvoření obrysu hvězdy (základ od Chata)
            int centerX = (x1 + x2) / 2;
            int centerY = (y1 + y2) / 2;
            int radius = Math.Min(Math.Abs(x2 - x1), Math.Abs(y2 - y1)) / 2;
            int points = 5;
            PointF[] starPoints = new PointF[10];

            for (int i = 0; i < 10; i++)
            {
                double angle = Math.PI / 2 + i * Math.PI / points;
                double r = (i % 2 == 0) ? radius : radius * 0.4;
                starPoints[i] = new PointF(
                    centerX + (float)(Math.Cos(angle) * r),
                    centerY - (float)(Math.Sin(angle) * r));
            }

            g.DrawPolygon(pen, starPoints);
        }

        private void FillStar(Graphics g, Brush fillBrush, int x1, int y1, int x2, int y2)
        {
            // vyvtoření vyplněné hvězdy
            int centerX = (x1 + x2) / 2;
            int centerY = (y1 + y2) / 2;
            int radius = Math.Min(Math.Abs(x2 - x1), Math.Abs(y2 - y1)) / 2;
            int points = 5;
            PointF[] starPoints = new PointF[10];

            for (int i = 0; i < 10; i++)
            {
                double angle = Math.PI / 2 + i * Math.PI / points;
                double r = (i % 2 == 0) ? radius : radius * 0.4;
                starPoints[i] = new PointF(
                    centerX + (float)(Math.Cos(angle) * r),
                    centerY - (float)(Math.Sin(angle) * r));
            }

            g.FillPolygon(fillBrush, starPoints);
        }

        // Event handlery pro ui tlačítka
        private void ellipseButton_CheckedChanged(object sender, EventArgs e) { }
        private void rectButton_CheckedChanged(object sender, EventArgs e) { }
        private void ellipseFillButton_CheckedChanged(object sender, EventArgs e) { }
        private void rectFillButton_CheckedChanged(object sender, EventArgs e) { }
        private void lineButton_CheckedChanged(object sender, EventArgs e) { }
        private void starButton_CheckedChanged(object sender, EventArgs e) { }
        private void starFilledButton_CheckedChanged(object sender, EventArgs e) { }
        private void imgButton_CheckedChanged(object sender, EventArgs e) { }

        private class TextItem
        {
            public string Text { get; set; }
            public Font Font { get; set; }
            public Brush Brush { get; set; }
            public Point Location { get; set; }
        }
    }

}