
namespace WindowsFormsApp2
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
            this.btnVisa = new System.Windows.Forms.Button();
            this.lblUtmat = new System.Windows.Forms.Label();
            this.lblTidISekunder = new System.Windows.Forms.Label();
            this.txtSekunder = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnVisa
            // 
            this.btnVisa.Location = new System.Drawing.Point(15, 39);
            this.btnVisa.Name = "btnVisa";
            this.btnVisa.Size = new System.Drawing.Size(75, 54);
            this.btnVisa.TabIndex = 0;
            this.btnVisa.Text = "Visa";
            this.btnVisa.UseVisualStyleBackColor = true;
            this.btnVisa.Click += new System.EventHandler(this.btnVisa_Click);
            // 
            // lblUtmat
            // 
            this.lblUtmat.AutoSize = true;
            this.lblUtmat.Location = new System.Drawing.Point(96, 39);
            this.lblUtmat.Name = "lblUtmat";
            this.lblUtmat.Size = new System.Drawing.Size(136, 17);
            this.lblUtmat.TabIndex = 1;
            this.lblUtmat.Text = "bla bla bla sekunder";
            // 
            // lblTidISekunder
            // 
            this.lblTidISekunder.AutoSize = true;
            this.lblTidISekunder.Location = new System.Drawing.Point(12, 9);
            this.lblTidISekunder.Name = "lblTidISekunder";
            this.lblTidISekunder.Size = new System.Drawing.Size(102, 17);
            this.lblTidISekunder.TabIndex = 2;
            this.lblTidISekunder.Text = "Tid i sekunder:";
            // 
            // txtSekunder
            // 
            this.txtSekunder.Location = new System.Drawing.Point(120, 9);
            this.txtSekunder.Name = "txtSekunder";
            this.txtSekunder.Size = new System.Drawing.Size(100, 22);
            this.txtSekunder.TabIndex = 3;
            this.txtSekunder.TextChanged += new System.EventHandler(this.txtSekunder_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 104);
            this.Controls.Add(this.txtSekunder);
            this.Controls.Add(this.lblTidISekunder);
            this.Controls.Add(this.lblUtmat);
            this.Controls.Add(this.btnVisa);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVisa;
        private System.Windows.Forms.Label lblUtmat;
        private System.Windows.Forms.Label lblTidISekunder;
        private System.Windows.Forms.TextBox txtSekunder;
    }
}

