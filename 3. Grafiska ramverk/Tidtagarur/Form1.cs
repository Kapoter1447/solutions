using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tidtagarur
{
    public partial class Form1 : Form
    {
        DateTime start;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnTimerStart_Click(object sender, EventArgs e)
        {
            if (btnTimerStart.Text == "Start")
            {
                start = DateTime.Now;
                timer.Start();
                btnTimerStart.Text = "Stop";
            }
            else
            {
                timer.Stop();
                btnTimerStart.Text = "Start";
            }


        }

        private void timer_Tick(object sender, EventArgs e)
        {
            TimeSpan tid = DateTime.Now - start;
            lblTime.Text = tid.Minutes.ToString().PadLeft(2, '0') + ":" + tid.Seconds.ToString().PadLeft(2, '0') + ":" + tid.Milliseconds.ToString().PadLeft(3, '0');

        }
    }
}
