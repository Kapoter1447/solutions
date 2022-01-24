using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        int sekunder;
        int hours = 0;
        int minutes = 0;

        string hoursString;
        string minutesString;
        string secondsString;

        private void txtSekunder_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnVisa_Click(object sender, EventArgs e)
        {
             sekunder = int.Parse(txtSekunder.Text);

      //      TimeSpan time = TimeSpan.FromSeconds(sekunder);
      //      string utmat = string.Format(time.Hours + ":" + time.Minutes + ":" + time.Seconds);
      //      lblUtmat.Text = utmat;

            //timmar
           
            //while(sekunder > 3600)
            //{
            //    sekunder = sekunder - 3600;
            //    hours++;

            //}

            ////minuter
            //while(sekunder > 60)
            //{
            //    sekunder = sekunder - 60;
            //    minutes++;
            //}
            hours = sekunder / 3600;
            sekunder = sekunder % 3600;
            minutes = sekunder / 60;
            sekunder = sekunder % 60;

            hoursString = hours.ToString();
            minutesString = minutes.ToString();
            secondsString = sekunder.ToString();

            lblUtmat.Text = hoursString + ":" + minutesString + ":" + secondsString;


        }
    }
}
