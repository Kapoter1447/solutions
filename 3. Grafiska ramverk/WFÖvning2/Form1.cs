using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFÖvning2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double talA;

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void lblMedelvärde_Click(object sender, EventArgs e)
        {

        }

        private void btnKör_Click(object sender, EventArgs e)
        {
            talA = double.Parse(textBox3.Text);
            double talB = double.Parse(textBox2.Text);
            double talC = double.Parse(textBox1.Text);

            double summa = talA + talB + talC;

            lblSumma.Text = "Summa: " + summa.ToString();

            double medelvärde = (talA + talB + talC) / 3;

            lblMedelvärde.Text = "Medelvärde: " + medelvärde.ToString();

                // double tal = double.Parse(TextBox.Text);
        }

        private void lblTal1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
