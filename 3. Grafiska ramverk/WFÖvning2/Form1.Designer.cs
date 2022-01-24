
namespace WFÖvning2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTal1 = new System.Windows.Forms.Label();
            this.lblTal2 = new System.Windows.Forms.Label();
            this.lblTal3 = new System.Windows.Forms.Label();
            this.lblSumma = new System.Windows.Forms.Label();
            this.lblMedelvärde = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.btnKör = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTal1
            // 
            this.lblTal1.AutoSize = true;
            this.lblTal1.Location = new System.Drawing.Point(46, 24);
            this.lblTal1.Name = "lblTal1";
            this.lblTal1.Size = new System.Drawing.Size(35, 17);
            this.lblTal1.TabIndex = 0;
            this.lblTal1.Text = "tal a";
            this.lblTal1.Click += new System.EventHandler(this.lblTal1_Click);
            // 
            // lblTal2
            // 
            this.lblTal2.AutoSize = true;
            this.lblTal2.Location = new System.Drawing.Point(46, 52);
            this.lblTal2.Name = "lblTal2";
            this.lblTal2.Size = new System.Drawing.Size(35, 17);
            this.lblTal2.TabIndex = 1;
            this.lblTal2.Text = "tal b";
            // 
            // lblTal3
            // 
            this.lblTal3.AutoSize = true;
            this.lblTal3.Location = new System.Drawing.Point(46, 80);
            this.lblTal3.Name = "lblTal3";
            this.lblTal3.Size = new System.Drawing.Size(34, 17);
            this.lblTal3.TabIndex = 2;
            this.lblTal3.Text = "tal c";
            // 
            // lblSumma
            // 
            this.lblSumma.AutoSize = true;
            this.lblSumma.Location = new System.Drawing.Point(46, 152);
            this.lblSumma.Name = "lblSumma";
            this.lblSumma.Size = new System.Drawing.Size(53, 17);
            this.lblSumma.TabIndex = 3;
            this.lblSumma.Text = "summa";
            // 
            // lblMedelvärde
            // 
            this.lblMedelvärde.AutoSize = true;
            this.lblMedelvärde.Location = new System.Drawing.Point(46, 180);
            this.lblMedelvärde.Name = "lblMedelvärde";
            this.lblMedelvärde.Size = new System.Drawing.Size(82, 17);
            this.lblMedelvärde.TabIndex = 4;
            this.lblMedelvärde.Text = "medelvärde";
            this.lblMedelvärde.Click += new System.EventHandler(this.lblMedelvärde_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(98, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(98, 77);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(98, 21);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 7;
            // 
            // btnKör
            // 
            this.btnKör.Location = new System.Drawing.Point(49, 114);
            this.btnKör.Name = "btnKör";
            this.btnKör.Size = new System.Drawing.Size(75, 23);
            this.btnKör.TabIndex = 8;
            this.btnKör.Text = "kör";
            this.btnKör.UseVisualStyleBackColor = true;
            this.btnKör.Click += new System.EventHandler(this.btnKör_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnKör);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblMedelvärde);
            this.Controls.Add(this.lblSumma);
            this.Controls.Add(this.lblTal3);
            this.Controls.Add(this.lblTal2);
            this.Controls.Add(this.lblTal1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTal1;
        private System.Windows.Forms.Label lblTal2;
        private System.Windows.Forms.Label lblTal3;
        private System.Windows.Forms.Label lblSumma;
        private System.Windows.Forms.Label lblMedelvärde;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button btnKör;
    }
}

