namespace CafeOtomasyonu
{
    partial class KahveAfisleri
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KahveAfisleri));
            this.lblKahveAdi = new System.Windows.Forms.Label();
            this.lblKahveFiyat = new System.Windows.Forms.Label();
            this.btnSepeteEkle = new Guna.UI2.WinForms.Guna2Button();
            this.pnlAfis = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlAfisResimArkaPlan = new Guna.UI2.WinForms.Guna2Panel();
            this.pcbKahveResim = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlAfis.SuspendLayout();
            this.pnlAfisResimArkaPlan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbKahveResim)).BeginInit();
            this.SuspendLayout();
            // 
            // lblKahveAdi
            // 
            this.lblKahveAdi.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKahveAdi.ForeColor = System.Drawing.Color.White;
            this.lblKahveAdi.Location = new System.Drawing.Point(40, 207);
            this.lblKahveAdi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblKahveAdi.Name = "lblKahveAdi";
            this.lblKahveAdi.Size = new System.Drawing.Size(208, 35);
            this.lblKahveAdi.TabIndex = 1;
            this.lblKahveAdi.Text = "Latte";
            this.lblKahveAdi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKahveFiyat
            // 
            this.lblKahveFiyat.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblKahveFiyat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(170)))), ((int)(((byte)(125)))));
            this.lblKahveFiyat.Location = new System.Drawing.Point(94, 240);
            this.lblKahveFiyat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblKahveFiyat.Name = "lblKahveFiyat";
            this.lblKahveFiyat.Size = new System.Drawing.Size(109, 26);
            this.lblKahveFiyat.TabIndex = 2;
            this.lblKahveFiyat.Text = "140.00 ₺";
            this.lblKahveFiyat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSepeteEkle
            // 
            this.btnSepeteEkle.BackColor = System.Drawing.Color.Transparent;
            this.btnSepeteEkle.BorderRadius = 15;
            this.btnSepeteEkle.BorderThickness = 2;
            this.btnSepeteEkle.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSepeteEkle.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSepeteEkle.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSepeteEkle.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSepeteEkle.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(91)))), ((int)(((byte)(48)))));
            this.btnSepeteEkle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSepeteEkle.ForeColor = System.Drawing.Color.White;
            this.btnSepeteEkle.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(170)))), ((int)(((byte)(125)))));
            this.btnSepeteEkle.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnSepeteEkle.Image = ((System.Drawing.Image)(resources.GetObject("btnSepeteEkle.Image")));
            this.btnSepeteEkle.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSepeteEkle.ImageOffset = new System.Drawing.Point(5, 0);
            this.btnSepeteEkle.ImageSize = new System.Drawing.Size(30, 30);
            this.btnSepeteEkle.Location = new System.Drawing.Point(46, 277);
            this.btnSepeteEkle.Margin = new System.Windows.Forms.Padding(2);
            this.btnSepeteEkle.Name = "btnSepeteEkle";
            this.btnSepeteEkle.Size = new System.Drawing.Size(190, 43);
            this.btnSepeteEkle.TabIndex = 3;
            this.btnSepeteEkle.Text = "SEPETE EKLE";
            this.btnSepeteEkle.TextOffset = new System.Drawing.Point(5, 0);
            this.btnSepeteEkle.Click += new System.EventHandler(this.btnSepeteEkle_Click);
            // 
            // pnlAfis
            // 
            this.pnlAfis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(27)))), ((int)(((byte)(23)))));
            this.pnlAfis.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(61)))), ((int)(((byte)(48)))));
            this.pnlAfis.BorderRadius = 15;
            this.pnlAfis.BorderThickness = 1;
            this.pnlAfis.Controls.Add(this.btnSepeteEkle);
            this.pnlAfis.Controls.Add(this.lblKahveFiyat);
            this.pnlAfis.Controls.Add(this.lblKahveAdi);
            this.pnlAfis.Controls.Add(this.pnlAfisResimArkaPlan);
            this.pnlAfis.FillColor = System.Drawing.Color.Transparent;
            this.pnlAfis.Location = new System.Drawing.Point(11, 10);
            this.pnlAfis.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAfis.Name = "pnlAfis";
            this.pnlAfis.Size = new System.Drawing.Size(279, 340);
            this.pnlAfis.TabIndex = 0;
            this.pnlAfis.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlAfis_Paint);
            // 
            // pnlAfisResimArkaPlan
            // 
            this.pnlAfisResimArkaPlan.BackColor = System.Drawing.Color.Transparent;
            this.pnlAfisResimArkaPlan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(80)))), ((int)(((byte)(53)))));
            this.pnlAfisResimArkaPlan.BorderRadius = 15;
            this.pnlAfisResimArkaPlan.BorderThickness = 1;
            this.pnlAfisResimArkaPlan.Controls.Add(this.pcbKahveResim);
            this.pnlAfisResimArkaPlan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(26)))), ((int)(((byte)(23)))));
            this.pnlAfisResimArkaPlan.Location = new System.Drawing.Point(55, 22);
            this.pnlAfisResimArkaPlan.Name = "pnlAfisResimArkaPlan";
            this.pnlAfisResimArkaPlan.Size = new System.Drawing.Size(174, 182);
            this.pnlAfisResimArkaPlan.TabIndex = 4;
            // 
            // pcbKahveResim
            // 
            this.pcbKahveResim.BackColor = System.Drawing.Color.Transparent;
            this.pcbKahveResim.BorderRadius = 25;
            this.pcbKahveResim.FillColor = System.Drawing.Color.Transparent;
            this.pcbKahveResim.Image = ((System.Drawing.Image)(resources.GetObject("pcbKahveResim.Image")));
            this.pcbKahveResim.ImageRotate = 0F;
            this.pcbKahveResim.Location = new System.Drawing.Point(9, 2);
            this.pcbKahveResim.Margin = new System.Windows.Forms.Padding(2);
            this.pcbKahveResim.Name = "pcbKahveResim";
            this.pcbKahveResim.Size = new System.Drawing.Size(154, 173);
            this.pcbKahveResim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbKahveResim.TabIndex = 0;
            this.pcbKahveResim.TabStop = false;
            this.pcbKahveResim.Click += new System.EventHandler(this.pcbKahveResim_Click);
            // 
            // KahveAfisleri
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlAfis);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "KahveAfisleri";
            this.Size = new System.Drawing.Size(300, 362);
            this.pnlAfis.ResumeLayout(false);
            this.pnlAfisResimArkaPlan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbKahveResim)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblKahveAdi;
        private System.Windows.Forms.Label lblKahveFiyat;
        private Guna.UI2.WinForms.Guna2Button btnSepeteEkle;
        private Guna.UI2.WinForms.Guna2Panel pnlAfis;
        private Guna.UI2.WinForms.Guna2PictureBox pcbKahveResim;
        private Guna.UI2.WinForms.Guna2Panel pnlAfisResimArkaPlan;
    }
}
