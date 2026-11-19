namespace CafeOtomasyonu
{
    partial class TestFormucs
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
            this.kahveAfisleri1 = new CafeOtomasyonu.KahveAfisleri();
            this.SuspendLayout();
            // 
            // kahveAfisleri1
            // 
            this.kahveAfisleri1.Location = new System.Drawing.Point(21, 12);
            this.kahveAfisleri1.Name = "kahveAfisleri1";
            this.kahveAfisleri1.Size = new System.Drawing.Size(160, 260);
            this.kahveAfisleri1.TabIndex = 0;
            // 
            // TestFormucs
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(704, 551);
            this.Controls.Add(this.kahveAfisleri1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TestFormucs";
            this.Text = "TestFormucs";
            this.ResumeLayout(false);

        }

        #endregion

        private KahveAfisleri kahveAfisleri1;
    }
}