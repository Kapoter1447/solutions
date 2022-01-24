
namespace ultimate_tal_guesser
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
            this.components = new System.ComponentModel.Container();
            this.gbxSpeldata = new System.Windows.Forms.GroupBox();
            this.lblStörstaTalet = new System.Windows.Forms.Label();
            this.lbxStörstaTaet = new System.Windows.Forms.ListBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.gbxSpelet = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLedtråd = new System.Windows.Forms.Label();
            this.lblDatornsTal = new System.Windows.Forms.Label();
            this.lblResultat = new System.Windows.Forms.Label();
            this.lblGissa = new System.Windows.Forms.Label();
            this.lblDator = new System.Windows.Forms.Label();
            this.tbxGissa = new System.Windows.Forms.TextBox();
            this.btnGissa = new System.Windows.Forms.Button();
            this.tbxMinaResultat = new System.Windows.Forms.TextBox();
            this.lblMinaResultat = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbxSpeldata.SuspendLayout();
            this.gbxSpelet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxSpeldata
            // 
            this.gbxSpeldata.Controls.Add(this.lblStörstaTalet);
            this.gbxSpeldata.Controls.Add(this.lbxStörstaTaet);
            this.gbxSpeldata.Controls.Add(this.btnStart);
            this.gbxSpeldata.Location = new System.Drawing.Point(12, 106);
            this.gbxSpeldata.Name = "gbxSpeldata";
            this.gbxSpeldata.Size = new System.Drawing.Size(354, 89);
            this.gbxSpeldata.TabIndex = 1;
            this.gbxSpeldata.TabStop = false;
            this.gbxSpeldata.Text = "Speldata";
            // 
            // lblStörstaTalet
            // 
            this.lblStörstaTalet.AutoSize = true;
            this.lblStörstaTalet.Location = new System.Drawing.Point(6, 26);
            this.lblStörstaTalet.Name = "lblStörstaTalet";
            this.lblStörstaTalet.Size = new System.Drawing.Size(93, 17);
            this.lblStörstaTalet.TabIndex = 5;
            this.lblStörstaTalet.Text = "Största Talet:";
            // 
            // lbxStörstaTaet
            // 
            this.lbxStörstaTaet.FormattingEnabled = true;
            this.lbxStörstaTaet.ItemHeight = 16;
            this.lbxStörstaTaet.Location = new System.Drawing.Point(107, 26);
            this.lbxStörstaTaet.Name = "lbxStörstaTaet";
            this.lbxStörstaTaet.Size = new System.Drawing.Size(120, 36);
            this.lbxStörstaTaet.TabIndex = 4;
            this.lbxStörstaTaet.SelectedIndexChanged += new System.EventHandler(this.lbxStörstaTaet_SelectedIndexChanged);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(273, 20);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 58);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Spela!";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // gbxSpelet
            // 
            this.gbxSpelet.Controls.Add(this.label1);
            this.gbxSpelet.Controls.Add(this.lblLedtråd);
            this.gbxSpelet.Controls.Add(this.lblDatornsTal);
            this.gbxSpelet.Controls.Add(this.lblResultat);
            this.gbxSpelet.Controls.Add(this.lblGissa);
            this.gbxSpelet.Controls.Add(this.lblDator);
            this.gbxSpelet.Controls.Add(this.tbxGissa);
            this.gbxSpelet.Controls.Add(this.btnGissa);
            this.gbxSpelet.Controls.Add(this.tbxMinaResultat);
            this.gbxSpelet.Controls.Add(this.lblMinaResultat);
            this.gbxSpelet.Enabled = false;
            this.gbxSpelet.Location = new System.Drawing.Point(12, 216);
            this.gbxSpelet.Name = "gbxSpelet";
            this.gbxSpelet.Size = new System.Drawing.Size(354, 251);
            this.gbxSpelet.TabIndex = 2;
            this.gbxSpelet.TabStop = false;
            this.gbxSpelet.Text = "Spelet";
            this.gbxSpelet.Enter += new System.EventHandler(this.gbxSpelet_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(205, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Antal Gissningar:";
            // 
            // lblLedtråd
            // 
            this.lblLedtråd.AutoSize = true;
            this.lblLedtråd.Location = new System.Drawing.Point(6, 102);
            this.lblLedtråd.Name = "lblLedtråd";
            this.lblLedtråd.Size = new System.Drawing.Size(57, 17);
            this.lblLedtråd.TabIndex = 11;
            this.lblLedtråd.Text = "Ledtråd";
            // 
            // lblDatornsTal
            // 
            this.lblDatornsTal.AutoSize = true;
            this.lblDatornsTal.Location = new System.Drawing.Point(95, 34);
            this.lblDatornsTal.Name = "lblDatornsTal";
            this.lblDatornsTal.Size = new System.Drawing.Size(32, 17);
            this.lblDatornsTal.TabIndex = 10;
            this.lblDatornsTal.Text = "???";
            // 
            // lblResultat
            // 
            this.lblResultat.AutoSize = true;
            this.lblResultat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblResultat.Location = new System.Drawing.Point(6, 151);
            this.lblResultat.Name = "lblResultat";
            this.lblResultat.Size = new System.Drawing.Size(62, 19);
            this.lblResultat.TabIndex = 9;
            this.lblResultat.Text = "Resultat";
            this.lblResultat.Click += new System.EventHandler(this.lblResultat_Click);
            // 
            // lblGissa
            // 
            this.lblGissa.AutoSize = true;
            this.lblGissa.Location = new System.Drawing.Point(5, 60);
            this.lblGissa.Name = "lblGissa";
            this.lblGissa.Size = new System.Drawing.Size(87, 17);
            this.lblGissa.TabIndex = 8;
            this.lblGissa.Text = "Gissa ett tal:";
            // 
            // lblDator
            // 
            this.lblDator.AutoSize = true;
            this.lblDator.Location = new System.Drawing.Point(6, 34);
            this.lblDator.Name = "lblDator";
            this.lblDator.Size = new System.Drawing.Size(81, 17);
            this.lblDator.TabIndex = 7;
            this.lblDator.Text = "Datorns tal:";
            // 
            // tbxGissa
            // 
            this.tbxGissa.Location = new System.Drawing.Point(98, 60);
            this.tbxGissa.Name = "tbxGissa";
            this.tbxGissa.Size = new System.Drawing.Size(73, 22);
            this.tbxGissa.TabIndex = 6;
            // 
            // btnGissa
            // 
            this.btnGissa.Location = new System.Drawing.Point(6, 186);
            this.btnGissa.Name = "btnGissa";
            this.btnGissa.Size = new System.Drawing.Size(342, 59);
            this.btnGissa.TabIndex = 5;
            this.btnGissa.Text = "Gissa";
            this.btnGissa.UseVisualStyleBackColor = true;
            this.btnGissa.Click += new System.EventHandler(this.btnGissa_Click);
            // 
            // tbxMinaResultat
            // 
            this.tbxMinaResultat.Enabled = false;
            this.tbxMinaResultat.Location = new System.Drawing.Point(208, 54);
            this.tbxMinaResultat.Multiline = true;
            this.tbxMinaResultat.Name = "tbxMinaResultat";
            this.tbxMinaResultat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxMinaResultat.Size = new System.Drawing.Size(140, 89);
            this.tbxMinaResultat.TabIndex = 4;
            // 
            // lblMinaResultat
            // 
            this.lblMinaResultat.AutoSize = true;
            this.lblMinaResultat.Location = new System.Drawing.Point(205, 34);
            this.lblMinaResultat.Name = "lblMinaResultat";
            this.lblMinaResultat.Size = new System.Drawing.Size(128, 17);
            this.lblMinaResultat.TabIndex = 3;
            this.lblMinaResultat.Text = "Historik gissningar:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // pictureBox1
            // 
            this.pictureBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.pictureBox1.BackgroundImage = global::ultimate_tal_guesser.Properties.Resources.talguesser3;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.No;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(394, 101);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(1);
            this.pictureBox1.Size = new System.Drawing.Size(378, 101);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnGissa;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 479);
            this.Controls.Add(this.gbxSpelet);
            this.Controls.Add(this.gbxSpeldata);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gbxSpeldata.ResumeLayout(false);
            this.gbxSpeldata.PerformLayout();
            this.gbxSpelet.ResumeLayout(false);
            this.gbxSpelet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox gbxSpeldata;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox gbxSpelet;
        private System.Windows.Forms.Label lblMinaResultat;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ListBox lbxStörstaTaet;
        private System.Windows.Forms.Label lblStörstaTalet;
        private System.Windows.Forms.Label lblDatornsTal;
        private System.Windows.Forms.Label lblResultat;
        private System.Windows.Forms.Label lblGissa;
        private System.Windows.Forms.Label lblDator;
        private System.Windows.Forms.TextBox tbxGissa;
        private System.Windows.Forms.Button btnGissa;
        public System.Windows.Forms.TextBox tbxMinaResultat;
        private System.Windows.Forms.Label lblLedtråd;
        private System.Windows.Forms.Label label1;
    }
}

