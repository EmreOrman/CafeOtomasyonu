using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeOtomasyonu
{
    public partial class Hakkimizda : Form
    {
        public Hakkimizda()
        {
            InitializeComponent();
        }

        #region Load Ekranı
        private void Hakkimizda_Load_1(object sender, EventArgs e)
        {
            // 1. Formun arka plan resminin düzgün kapladığından emin olalım
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // 2. Yazı Paneli (pnlYazi) Ayarları
            pnlYazi.AutoScroll = true;
            pnlYazi.Padding = new Padding(25, 25, 25, 25); // Yazıların kenarlara yapışmasını engeller
            pnlYazi.BorderRadius = 25;
            pnlYazi.BorderThickness = 2;
            pnlYazi.BorderColor = ColorTranslator.FromHtml("#CDAA7D");
            pnlYazi.FillColor = Color.FromArgb(235, 25, 18, 14);
            pnlYazi.BackColor = Color.Transparent;
            pnlYazi.ShadowDecoration.Enabled = true;
            pnlYazi.ShadowDecoration.Depth = 10;
            pnlYazi.ShadowDecoration.Color = Color.Black;

            pnlYazi.Controls.Add(lblYazi);

            // 4. Üst Panel (Navbar) Ayarları
            pnlHakkında.BorderRadius = 25;
            pnlHakkında.BorderThickness = 2;
            pnlHakkında.BorderColor = ColorTranslator.FromHtml("#CDAA7D");

            // Üst panelin saydamlığını da biraz artıralım
            pnlHakkında.FillColor = Color.FromArgb(235, 25, 18, 14); // Daha koyu, tok bir cam efekti
            pnlHakkında.BackColor = Color.Transparent;
            pnlHakkında.ShadowDecoration.Enabled = true;
            pnlHakkında.ShadowDecoration.Depth = 10;
            pnlHakkında.ShadowDecoration.Color = Color.Black;

            //PROFİL FOTOSUNUN ALTINDAKİ PANELLERİN LOKASYONU
            lblİsim.Location = new System.Drawing.Point(708, 260);
            lblYönetici.Location = new System.Drawing.Point(726, 290);

            //PROFİL FOTOSUNUN ALTINDAKİ PANELLERİN YAPISI

            // 1. Köşe Yuvarlaklığı
            pnlProfilAlt.BorderRadius = 15;

            // 2. Kenarlık (Sütlü Kahve)
            pnlProfilAlt.BorderThickness = 1;
            pnlProfilAlt.BorderColor = ColorTranslator.FromHtml("#CDAA7D");

            // 3. ARKA PLAN RENGİ (Gri değil, sıcak koyu kahve)
            pnlProfilAlt.FillColor = Color.FromArgb(255, 45, 30, 22); ;

            pnlProfilAlt.BackColor = Color.Transparent;

            // 4. Gölge
            pnlProfilAlt.ShadowDecoration.Enabled = true;
            pnlProfilAlt.ShadowDecoration.Depth = 5;
            pnlProfilAlt.ShadowDecoration.Color = Color.Black;

            pnlProfilAlt2.BorderRadius = 15;
            pnlProfilAlt2.BorderThickness = 1;
            pnlProfilAlt2.BorderColor = ColorTranslator.FromHtml("#CDAA7D");
            pnlProfilAlt2.FillColor = Color.FromArgb(255, 45, 30, 22); ;
            pnlProfilAlt2.BackColor = Color.Transparent;
            pnlProfilAlt2.ShadowDecoration.Enabled = true;
            pnlProfilAlt2.ShadowDecoration.Depth = 5;
            pnlProfilAlt2.ShadowDecoration.Color = Color.Black;
        }
        #endregion

        #region Formlar Arası Geçiş ve Çıkış Butonları
        //ÜST PANEL LİNKLERİ
        private void lblAnasayfa_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
        }

        private void lblHakkımızda_Click(object sender, EventArgs e)
        {
            Hakkimizda hakkimizda = new Hakkimizda();
            hakkimizda.Show();
            this.Hide();
        }

        private void lbliletisim_Click(object sender, EventArgs e)
        {
            Iletisim iletisim = new Iletisim();
            iletisim.Show();
            this.Hide();
        }

        //GERİ VE ÇIKIŞ BUTONLARI
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
        }
        #endregion

     
    }
}