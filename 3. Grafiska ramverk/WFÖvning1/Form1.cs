using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFÖvning1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double tal1;
        double tal2;
        double summa;
        // glömde välja ett namn på textboxarna så det blev textBox1 och textBox2.

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnKör_Click(object sender, EventArgs e)
        {
            tal1 = double.Parse(textBox1.Text);
            tal2 = double.Parse(textBox2.Text);
            // glömde välja ett namn på textboxarna så det blev textBox1 och textBox2.
            summa = tal1 + tal2;
            summa1.Text = summa.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // raderade den här
            // Glömde ge namn till den här också men har lärt mig av mitt misstag och gör det inte igen.
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
