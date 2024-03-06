using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsIntroduction
{
    public partial class Form1 : Form
    {
        Timer timer;
        int sec;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer = new Timer();
            timer.Interval = 1000; 
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            sec++;
            timeElapsed.Text = "TIME: " + sec.ToString() + " seconds";
        }

        private void startPause_Click(object sender, EventArgs e)
        {
            if (!timer.Enabled)
            {
                timer.Start();
                startPause.Text = "Pause"; 
            }
            else
            {
                timer.Stop();
                startPause.Text = "Start"; 
            }
        }
    }
}

