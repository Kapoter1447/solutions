using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region inítiering och deklarering

        float föregåendeTal = 0;
        float nuvarandeTal = 0;
        float minne = 0;
        float siffra;

        bool förstaKlick = true;
        bool harVärde = false;
        bool harKomma = false;
        bool ärNegativ = false;
        bool likaMedFörstaKlick = true;
        bool likaMedKlickad = false;

        string inmat = "";
        string sparadOperator = "";
        string klickadOperator = "";
        string historik = "";
        #endregion

        #region likaMed funktion
        void likaMed()
        {

            if (sparadOperator == "+")
            {
                // Operation som ska utföras när man klickar på knappen. Sätter sedan resultatet till "föregåendeTal" som sedans används i nästa operation.
                föregåendeTal = föregåendeTal + nuvarandeTal;

                // Skriv resultatet i historiken samt i "räknerutan"
                tbxDisplay2.Text = föregåendeTal.ToString();
            }
            else if (sparadOperator == "-")
            {
                föregåendeTal = föregåendeTal - nuvarandeTal;

                tbxDisplay2.Text = föregåendeTal.ToString();
            }
            else if (sparadOperator == "×")
            {
                föregåendeTal = föregåendeTal * nuvarandeTal;

                tbxDisplay2.Text = föregåendeTal.ToString();
            }
            else if (sparadOperator == "/")
            {
                föregåendeTal = föregåendeTal / nuvarandeTal;

                tbxDisplay2.Text = föregåendeTal.ToString();
            }
            else if (sparadOperator == "^")
            {
                föregåendeTal = (float)Math.Pow(föregåendeTal, nuvarandeTal);

                tbxDisplay2.Text = föregåendeTal.ToString();
            }           
            else if (sparadOperator == "√")
            {
                föregåendeTal = (float)Math.Pow(föregåendeTal, 1 / nuvarandeTal);

                tbxDisplay2.Text = föregåendeTal.ToString();
            }
        }
        #endregion

        #region siffror funktion
        void siffror()
        {
            if(likaMedKlickad)
            {
                btnClear.PerformClick();
                likaMedKlickad = false;
            }

            inmat = inmat + siffra;
            tbxDisplay2.Text = inmat;
            harVärde = true;

            tbxDisplay1.Text = inmat + "\r\n" + historik;
        }
        #endregion

        #region operation funktion
        void operation()
        {

            if (likaMedKlickad)
            {
                inmat = föregåendeTal.ToString();
            }
            else
            {
                // Tidiagre har inmat skrivits ovanför historik. NU sparas den i historik.
                historik = inmat + "\r\n" + historik;
                tbxDisplay1.Text = historik;
            }

            if (!harVärde)
            {
                //Ifall inte har ett värde efter en operator. Byt operator.
                sparadOperator = klickadOperator;
                // Tar bort 3 tecken i strängen. "\r", "\n" och sparadOperator.
                historik = historik.Remove(0, 3);
                historik = sparadOperator + historik;   
                tbxDisplay1.Text = inmat + historik;
            }
            else if (förstaKlick)
            {
                föregåendeTal = float.Parse(inmat);
                sparadOperator = klickadOperator;

                inmat = "";
                förstaKlick = false;
                ärNegativ = false;

                historik = sparadOperator + "\r\n" + historik;
                tbxDisplay1.Text = inmat + historik;

            }
            else if (!förstaKlick)
            {
                nuvarandeTal = float.Parse(inmat);
                // likamed ska utföras med den sparade operatorn.
                likaMed();
                sparadOperator = klickadOperator;

                inmat = "";
                ärNegativ = false;

                historik = sparadOperator + "\r\n =" + föregåendeTal + "\r\n" + historik;
                tbxDisplay1.Text = inmat + historik;
            }

            harVärde = false;
            harKomma = false;
            likaMedKlickad = false;
            likaMedFörstaKlick = true;
        }

        #endregion

        #region siffror
        private void btn9_Click(object sender, EventArgs e)
        {
            siffra = 9;
            siffror();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            siffra = 8;
            siffror();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            siffra = 7;
            siffror();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            siffra = 6;
            siffror();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            siffra = 5;
            siffror();
        }


        private void btn4_Click(object sender, EventArgs e)
        {
            siffra = 4;
            siffror();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            siffra = 3;
            siffror();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            siffra = 2;
            siffror();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            siffra = 1;
            siffror();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            siffra = 0;
            siffror();
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            siffra = 2.7182818284f;
            siffror();
        }

        private void btnPi_Click(object sender, EventArgs e)
        {
            siffra = 3.1415926536f;
            siffror();
        }

        #endregion

        #region operationer
        private void btnDivide_Click(object sender, EventArgs e)
        {
            klickadOperator = "/";
            operation();
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            klickadOperator = "×";
            operation();
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            klickadOperator = "-";
            operation();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            klickadOperator = "+";
            operation();
        }

        private void btnKvadrera_Click(object sender, EventArgs e)
        {
            klickadOperator = "^";
            operation();
            btn2.PerformClick();
            btnEqual.PerformClick();
        }
        private void btnUpphöjt_Click(object sender, EventArgs e)
        {
            klickadOperator = "^";
            operation();
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            klickadOperator = "√";
            operation();
            btn2.PerformClick();
            btnEqual.PerformClick();

        }

        private void btnXRot_Click_1(object sender, EventArgs e)
        {
            klickadOperator = "√";
            operation();
        }
        #endregion

        #region övriga operationer
        private void btnComma_Click_1(object sender, EventArgs e)
        {
            if (!harKomma)
            {
                inmat = inmat + ",";
                tbxDisplay2.Text = inmat;

                harKomma = true;

                tbxDisplay1.Text = inmat + "\r\n" + historik;
            }
        }
        private void btnNegative_Click(object sender, EventArgs e)
        {
            if (likaMedKlickad)
            {
                inmat = föregåendeTal.ToString();
                if (föregåendeTal < 0)
                {
                    ärNegativ = true;
                }
                #region clear fast sparar inmat och ärNegativ
                förstaKlick = true;
                harKomma = false;
                likaMedFörstaKlick = true;
                likaMedKlickad = false;
                föregåendeTal = 0;
                nuvarandeTal = 0;
                sparadOperator = "";
                tbxDisplay2.Text = inmat;

                historik = "\r\n clear ------------- \r\n " + historik;
                tbxDisplay1.Text = historik;
                #endregion
                tbxDisplay1.Text = inmat + "\r\n" + historik;
            }
            if (!ärNegativ)
            {
                inmat = "-" + inmat;
                tbxDisplay2.Text = inmat;
                tbxDisplay1.Text = inmat + "\r\n" + historik;
                ärNegativ = true;
            }
            else if (ärNegativ)
            {
                inmat = inmat.Remove(0, 1);
                tbxDisplay2.Text = inmat;
                tbxDisplay1.Text = inmat + "\r\n" + historik;
                ärNegativ = false;
            }

        }
        #endregion

        #region equal
        private void btnEqual_Click(object sender, EventArgs e)
        {
            //Kolla om ett värde finns för att undvika crash
            if (harVärde)
            {
                if (!likaMedFörstaKlick)
                {
                    historik = inmat + "\r\n" + sparadOperator + "\r\n" + historik;
                }
                else if (likaMedFörstaKlick)
                {
                    historik = inmat + "\r\n" + historik;
                }
                tbxDisplay1.Text = historik;

                nuvarandeTal = float.Parse(inmat);
                likaMed();

                historik = "-----\r\n" + "=" + föregåendeTal.ToString() + "\r\n" + historik;
                tbxDisplay1.Text = historik;

                förstaKlick = true;
                likaMedKlickad = true;
                likaMedFörstaKlick = false;
            }
        }
        #endregion

        #region clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            förstaKlick = true;
            harKomma = false;
            ärNegativ = false;
            likaMedFörstaKlick = true;
            likaMedKlickad = false;
            inmat = "";
            föregåendeTal = 0;
            nuvarandeTal = 0;
            sparadOperator = "";
            tbxDisplay2.Text = inmat;

            historik = "\r\n clear ------------- \r\n " + historik;
            tbxDisplay1.Text = historik;
        }
        private void btnCe_Click(object sender, EventArgs e)
        {
            inmat = "";
            tbxDisplay2.Text = inmat;
            tbxDisplay1.Text = historik;
            harKomma = false;
            ärNegativ = false;

        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            // Ska inte ta bort om strängen inmat är tom
            if (!(inmat == ""))
            {
                //Tar bort karaktären längst bort i strängen.
                inmat = inmat.Remove(inmat.Length - 1, 1);
                tbxDisplay2.Text = inmat;
                tbxDisplay1.Text = inmat + "\r\n" + historik;
            }
        }
        private void btnRensa_Click(object sender, EventArgs e)
        {
            historik = "";
            tbxDisplay1.Text = historik;
        }
        #endregion

        #region minne
        private void btnMS_Click(object sender, EventArgs e)
        {
            minne = float.Parse(tbxDisplay2.Text);
            tbxMinne.Text = minne.ToString();
        }
        private void btnMR_Click(object sender, EventArgs e)
        {
            inmat = minne.ToString();
            harVärde = true;

            tbxDisplay2.Text = inmat;
            tbxDisplay1.Text = inmat + "\r\n" + historik + "\r\n";

        }
        private void btnMC_Click(object sender, EventArgs e)
        {
            minne = 0;
            tbxMinne.Text = minne.ToString();
        }


        #endregion

        // Saker jag kunde gjort bättre. 
        // Button handler?
        // Försöka undvika bools och använda funktioner. Glömmer återställa annars.
        

    }
}
