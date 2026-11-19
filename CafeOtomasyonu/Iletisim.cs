using System;
using System.Drawing;
using System.Windows.Forms;

namespace CafeOtomasyonu
{
    public partial class Iletisim : Form
    {
        public Iletisim()
        {
            InitializeComponent();
        }

        #region Load Ekranı
        private void Iletisim_Load(object sender, EventArgs e)
        {
            //ÜST PANEL AYARLARI
            pnlİletisim.BorderRadius = 25;
            pnlİletisim.BorderThickness = 2;
            pnlİletisim.BorderColor = ColorTranslator.FromHtml("#CDAA7D");
            pnlİletisim.FillColor = Color.FromArgb(235, 25, 18, 14); // Daha koyu, tok bir cam efekti
            pnlİletisim.BackColor = Color.Transparent;
            pnlİletisim.ShadowDecoration.Enabled = true;
            pnlİletisim.ShadowDecoration.Depth = 10;
            pnlİletisim.ShadowDecoration.Color = Color.Black;

            //MESAJ PANELİ AYARLARI
            pnlMesaj.BorderRadius = 25;
            pnlMesaj.BorderThickness = 2;
            pnlMesaj.BorderColor = ColorTranslator.FromHtml("#CDAA7D");
            pnlMesaj.FillColor = Color.FromArgb(235, 25, 18, 14); // Daha koyu, tok bir cam efekti
            pnlMesaj.BackColor = Color.Transparent;
            pnlMesaj.ShadowDecoration.Enabled = true;
            pnlMesaj.ShadowDecoration.Depth = 10;
            pnlMesaj.ShadowDecoration.Color = Color.Black;

            // txtAd için doğru renk ve stil ayarları
            txtAd.ForeColor = Color.White;
            txtAd.FocusedState.BorderColor = ColorTranslator.FromHtml("#CDAA7D");
            txtAd.HoverState.BorderColor = ColorTranslator.FromHtml("#CDAA7D");
            txtAd.BorderRadius = 12;
            txtAd.BorderThickness = 1;

            // Diğer textbox'ların da (txtEposta, txtMesaj) renklerini buraya ekleyebilirsin.
        }
        #endregion

        #region Formlar Arası Geçiş ve Çıkış Butonları
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

     

        //GERİ VE ÇIKIŞ BUTONLARI
        private void btnGeri_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        #endregion



        //TÜM Buton Ve Textbox Olayları Gelecek Güncelleme İle Birlikte Çalışır ve Veri Tabanına Eklebilir Durumda Olacak
        
        private void btnGönder_Click(object sender, EventArgs e)
        {

        }

        private void txtAd_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblSepetim_Click(object sender, EventArgs e)
        {

        }

    }
}