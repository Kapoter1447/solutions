using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ultimate_tal_guesser
{
    public partial class Form1 : Form
    {

        //int randomTal 

        public Form1()
        {
            InitializeComponent();

            lbxStörstaTaet.Items.Add(10);
            lbxStörstaTaet.Items.Add(20);

            lbxStörstaTaet.SelectedItem = lbxStörstaTaet.Items[0];

        }

        int randomNummer = 0;

        int antalGissningar = 0;

        string föregåendeResultat = "";

      

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lbxStörstaTaet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gbxSpelet_Enter(object sender, EventArgs e)
        {

        }

        private void lblResultat_Click(object sender, EventArgs e)
        {
     
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // skapa en random

            gbxSpeldata.Enabled = false;
            gbxSpelet.Enabled = true;

            int störstaTalet = int.Parse(lbxStörstaTaet.GetItemText(lbxStörstaTaet.SelectedItem));

            Random rnd = new Random();

            randomNummer = rnd.Next(1, störstaTalet+1);
            //    lblDatornsTal.Text = randomNummer.ToString();

            lblDatornsTal.Text = "???";

            lblResultat.Text = "Resultat";

            label1.Text = "Antal Gissningar: ";

            

        }



        private void btnGissa_Click(object sender, EventArgs e)
        {
            int gissatTal = int.Parse(tbxGissa.Text);

            tbxGissa.Text = null;

            antalGissningar++;

            label1.Text = "Antal Gissningar: " + antalGissningar.ToString();

            if (antalGissningar == 2)
            {
            //    label1.Text = "antalgissningar = 1";

                if (randomNummer%3==0)
                {
                    lblLedtråd.Text = "Talet är jämt";
                }
                else
                {
                    lblLedtråd.Text = "Talet är ojämt";
                }
            }
            if (antalGissningar == 1)
            {
                if (randomNummer % 2 == 0)
                {
                    lblLedtråd.Text = "Talet är delbart med 3";
                }
                else
                {
                    lblLedtråd.Text = "Talet är INTE delbart med 3";
                }
            }

            if (antalGissningar == 3)
            {
                if (randomNummer % 5 == 0)
                {
                    lblLedtråd.Text = "Talet är delbart med 5";
                }
                else
                {
                    lblLedtråd.Text = "Talet är INTE delbart med 5";
                }
            }

            if (antalGissningar > 3)
            {
                lblLedtråd.Text = "Nu får du inga mer ledtrådar";
            }

            if (randomNummer == gissatTal)
            {
                lblResultat.Text = "Du hade rätt!";
                gbxSpeldata.Enabled = true;
                gbxSpelet.Enabled = false;
                tbxGissa.Text = " ";
                lblDatornsTal.Text = randomNummer.ToString();

                föregåendeResultat = föregåendeResultat + antalGissningar.ToString() + "\r\n";

                tbxMinaResultat.Text = föregåendeResultat;


                //tbxMinaResultat.AppendText("Rad 1\n");
                //tbxMinaResultat.AppendText("Rad 2\n"); 

                antalGissningar = 0;

                lblLedtråd.Text = "";

            }

            if (randomNummer > gissatTal)
            {
                lblResultat.Text = "Du gissade för lite";
            }

            if (randomNummer < gissatTal)
            {
                lblResultat.Text = "Du gissade för mycket";
            }



        }
    }
}
