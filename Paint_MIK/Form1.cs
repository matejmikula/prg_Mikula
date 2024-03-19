using System;
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
    { //zadeifonování základních stringů, intů, etc....
        Graphics g; 
        float s; 
        int x = -1, y = -1; 
        bool moving; 
        Pen pen; 
        Brush spray, brush;
        public Random rnd = new Random();
        PictureBox pictureBox = new PictureBox();
        public Form1() 
        {
            InitializeComponent();
            g = panel1.CreateGraphics(); 
            // základní šířka a barva (+ další kosmetické úpravy)
            s = 5;
            pen = new Pen(Color.Black, s); 
            brush = new SolidBrush(Color.Black); 
            spray = new SolidBrush(Color.Black); 
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; 

            // maximální velikost scroll barů
            sizeBar.Maximum = 20; 
            opacityBar.Maximum = 255; 


        }

        
        private void sizeBar_Scroll(object sender, EventArgs e) 
        {
            // napsání čísla na scrollbar do text boxu
            sizeBox.Text = "" + sizeBar.Value; 
            // měnění šířky pera a spreje
            pen.Width = sizeBar.Value; 
            s = pen.Width; 
            spray = new SolidBrush(pen.Color); 
        }

        private void opacityBar_Scroll(object sender, EventArgs e) 
        {
            // napsání čísla na scrollbaru do textboxu
            opacityBox.Text = "" + opacityBar.Value; 
            // funkce, která mění barvu od nejsvětlejšího odstínu k původnímu/nejtmavšímu
            int alpha = opacityBar.Value; 
            Color currentColor = pen.Color; 
            Color newColor = Color.FromArgb(alpha, currentColor.R, currentColor.G, currentColor.B); 
            pen.Color = newColor; 
            spray = new SolidBrush(pen.Color);
            brush = new SolidBrush(pen.Color);
        }
        private void helpButton_Click(object sender, EventArgs e) 
        {
            // zpráva pro zmatené uživatele, kteří nevědí co mají dělat
            string message = "INTRODUCTION " + Environment.NewLine + Environment.NewLine +
                             "COLOR BUTTON: Color window will appear, changes colors of all tools and objects you´ll draw." + Environment.NewLine +
                             "HELP?: ..." + Environment.NewLine + Environment.NewLine +

                             "PEN: Casual pen (can change width, opacity and color)" + Environment.NewLine +
                             "SPRAY: Drawing tool that looks like a spray (same changebility as is with pen)" + Environment.NewLine + Environment.NewLine +

                             "ERASE ALL: Everything on the panel will be deleted after clicking." + Environment.NewLine +
                             "ERASER: For using the currently picked tool as an eraser, After using the eraser new color is needed to be picked else the tools wont draw anything" + Environment.NewLine + Environment.NewLine +
                             
                             "CIRCLE: Draws an unfilled circle" + Environment.NewLine +
                             "CIRCLE FILLED: Draws a filled circle" + Environment.NewLine + Environment.NewLine +

                             "RECTANGLE: Draws an unfilled rectangle" + Environment.NewLine +
                             "RECTANGLE FILLED: Draws a filled rectangle" + Environment.NewLine + Environment.NewLine +

                             "LINE: Draws perfectly straight line" + Environment.NewLine + Environment.NewLine +

                             "LEFT SCROLL BAR: Changes the opacity of the objects you draw" + Environment.NewLine +
                             "RIGHT SCROLL BAR: Changes the width (Thickness) of the objects you draw" + Environment.NewLine + Environment.NewLine +
                             "IMAGE SELECTION: Choose an image you want to insert" + Environment.NewLine +
                             "IMAGE INSERTION: Draws/Inserts the choosen image.";

            MessageBox.Show(message, "HELP?");
        }
        private void imageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.gif;*.png)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG";
            openFileDialog.Title = "Select Image File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // nahraje vybraný obrázek
                try
                {
                    // vybrání obrázku z průzkumníku souborů
                    pictureBox.Image = Image.FromFile(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message, "Error");
                }
            }
        }


        private void colorButton_Click(object sender, EventArgs e)
        {
            // vytvoří colordialog okno
            ColorDialog colorDialog = new ColorDialog(); 
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                //update barvy u všech obrazců/typů stětců
                pen.Color = colorDialog.Color; 
                spray = new SolidBrush(pen.Color); 
                brush = new SolidBrush(pen.Color); 
            }
        }

        private void eraseButton_Click(object sender, EventArgs e)
        {
            // smaže celé plátno, včetně importovaných obrázků
            g.Clear(panel1.BackColor);
            foreach (Control control in panel1.Controls)
            {
                if (control is PictureBox pictureBox)
                {
                    panel1.Controls.Remove(pictureBox);
                    pictureBox.Dispose();
                    break;
                }
            }
        }

        // Event handler for eraserButton click event
        private void eraserButton_Click(object sender, EventArgs e)
        {
            // změní pen color na stejnou barvu jako má pozadí, aby to vypadalo jako že se to maže ať už má pozadí jakoukoliv barvu
            pen.Color = panel1.BackColor; 
            spray = new SolidBrush(pen.Color); 
            brush = new SolidBrush(pen.Color);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            // původní koordinací myše po stiknutí + změna kurzoru po stisknutí 
            moving = true;
            x = e.X; 
            y = e.Y; 
            panel1.Cursor = Cursors.Cross; 
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            // ify na zjištění toho která TOOL je používaná
            if (penButton.Checked) 
            {
                // zajistíse že barví společně s pohybem myšky
                if (moving || x != -1 || y != -1) 
                {
                    //zadefinování startovních a konečných koordinací
                    g.DrawLine(pen, new Point(x, y), e.Location); 
                    x = e.X;
                    y = e.Y;
                }
            }
            else if (sprayButton.Checked) 
            {
                if (moving || x != -1 || y != -1) 
                {
                    // více naťukaných bodů vyvolá efekt spreje (aspoň trochu :D)
                    for (int i = 0; i < 10; i++) 
                    {
                        // vytvoření radiusus ve kterém se vytvoří random vyplněné ellipsy o stejné výšce a šířce
                        int sprayX = e.X + rnd.Next(-8, 8); 
                        int sprayY = e.Y + rnd.Next(-8, 8); 
                        g.FillEllipse(spray, sprayX, sprayY, s, s); 
                    }
                }
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            int width, height;
            width = Math.Abs(e.X - x);
            height = Math.Abs(e.Y - y);
            // podle vybrané TOOL se vytvoří shape jí přiřazené až po puštění myše (během kreslení není daný shape vidět)
            if (ellipseButton.Checked && moving && x != -1 && y != -1)
            {
                g.DrawEllipse(pen, x, y, e.X - x, e.Y - y); // Elipsa
            }
            else if (rectButton.Checked && moving && x != -1 && y != -1)
            {
                g.DrawRectangle(pen, x, y, e.X - x, e.Y - y); // čtverec
            }
            else if (ellipseFillButton.Checked && moving && x != -1 && y != -1)
            {
                g.FillEllipse(brush, x, y, e.X - x, e.Y - y); // vyplněná elipsa
            }
            else if (rectFillButton.Checked && moving && x != -1 && y != -1)
            {
                g.FillRectangle(brush, x, y, e.X - x, e.Y - y); // vyplněný čtverec
            }
            else if (lineButton.Checked && moving && x != -1 && y != -1)
            {
                g.DrawLine(pen, x, y, e.X, e.Y); // úsečka
            }
            else if (imgButton.Checked)
            {
                //zadává velikost, koordinace, apod. pro vložený obrázek
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // Then change to AutoSize
                pictureBox.Size = new Size(width, height);
                pictureBox.Location = new Point(x, y);
                pictureBox.BackColor = Color.Transparent;

                // Add the PictureBox to your form
                panel1.Controls.Add(pictureBox);
            }
            // reset koordinací myše po puštění + změna kurzoru po puštění 
            moving = false; 
            x = -1; 
            y = -1; 
            panel1.Cursor = Cursors.Default; 
        }

        // Další event handlery, metody, elementy, etc., která jsou potřeba pro funkčnost programu
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void penButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void sprayButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rectButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ellipseFillButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void imgButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lineButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ellipseButton_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
