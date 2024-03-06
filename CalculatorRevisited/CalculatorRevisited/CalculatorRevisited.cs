using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Dnes bude vasim ukolem vytvorit formularovou reprezentaci kalkulacky. Priblizny vzhled si nakreslime na tabuli
 * (Pokud jsem to nenakreslil, pripomente mi to prosim!)
 * Inspirujte se kalkulackou ve Windows.
 * Pozadovane prvky/funkcionality:
 * - Tlacitka pro kazde z cisel 0-9
 * - Tlacitka pro operace +, -, *, a /
 * - Tlacitko pro = (vypsani vysledku)
 * - Textbox, do ktereho se propisou cisla/operace pri stisku jejich tlacitek
 * - Textbox s vysledkem operace (mozne sloucit s predeslym, nechavam na vas)
 * - Tlacitko pro vymazani textu v textboxu s cisly a operaci
 * 
 * Volitelne prvky/funkcionality:
 * - Tlacitko pro mazani cisel a operaci v textboxu zprava vzdy po jednom znaku
 * - Pokud mam vypsany vysledek a hned po tom stisknu tlacitko nejake operace, vysledek se vezme jako prvni cislo a
 *   rovnou mohu po zadani operace zadat druhe cislo
 * - Moznost ulozeni vysledku do nekolika preddefinovanych labelu/neinteraktivnich textboxu (treba kombinaci comboboxu a tlacitka, kde
 *   v comboboxu vyberu do ktereho labelu/textboxu se mi to ulozi a tlacitkem provedu ulozeni)
 *   + pridat tlacitko pro kazdy label/neint. textbox, kterym ulozeny vysledek pouziju jako cislo do vypoctu
 * - Pridani mocnin/odmocnin atd. (napr. pomoci dalsich tlacitek, ktere rovnou misto daneho cisla daji jeho (popr. zaokrouhlenou) odmocninu apod.)
 * - Cokoliv dalsiho vas napadne! :)
 * 
 * Snazte se o to, aby byla kalkulacka v ramci moznosti hezka, a aby bylo jeji ovladani intuitivni a aby mel kazdy prvek v okne dobre vyuziti
 */

namespace CalculatorRevisited
{
    public partial class CalculatorRevisited : Form
    {
        private double firstOperand = 0;
        private double secondOperand = 0;
        public CalculatorRevisited()
        {
            InitializeComponent();
        }

        public void ResultBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Num1_Click(object sender, EventArgs e)
        {
            ResultBox.Text += "1";
        }

        private void Num2_Click(object sender, EventArgs e)
        {
            ResultBox.Text += "2";
        }

        private void Num3_Click(object sender, EventArgs e)
        {
            ResultBox.Text += "3";
        }

        private void Num4_Click(object sender, EventArgs e)
        {
            ResultBox.Text += "4";
        }

        private void Num5_Click(object sender, EventArgs e)
        {
            ResultBox.Text += "5";
        }

        private void Num6_Click(object sender, EventArgs e)
        {
            ResultBox.Text += "6";
        }

        private void Num7_Click(object sender, EventArgs e)
        {
            ResultBox.Text += "7";
        }

        private void Num8_Click(object sender, EventArgs e)
        {
            ResultBox.Text += "8";
        }

        private void Num9_Click(object sender, EventArgs e)
        {
            ResultBox.Text += "9";
        }

        private void Num0_Click(object sender, EventArgs e)
        {
            ResultBox.Text += "0";
        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            if (double.TryParse(ResultBox.Text, out double currentValue))
            {
                firstOperand = currentValue;
                ResultBox.Text = $"{currentValue} + ";
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ResultBox.Clear();
        }

        private void resultButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ResultBox.Text))
            {
                ResultBox.Clear();
                
            }
            else if (double.TryParse(ResultBox.Text, out double currentValue))
            {
                if (double.TryParse(ResultBox.Text, out double pastValue))
                {
                    firstOperand = currentValue;
                    secondOperand = pastValue;
                    double result = pastValue + currentValue;
                    ResultBox.Text = $"{result}";
                }
            }
            else
            {
                ResultBox.Text = "Error";
            }
        }
    }
}