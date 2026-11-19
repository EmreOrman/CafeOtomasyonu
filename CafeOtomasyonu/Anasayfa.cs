using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CafeOtomasyonu
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        #region Load Ekranı
        private void Anasayfa_Load(object sender, EventArgs e)
        {
            // 4. Üst Panel (Navbar) Ayarları
            pnlAnasayfa.BorderRadius = 25;
            pnlAnasayfa.BorderThickness = 2;
            pnlAnasayfa.BorderColor = ColorTranslator.FromHtml("#CDAA7D");

            // Üst panelin saydamlığını da biraz artıralım
            pnlAnasayfa.BackColor = Color.Transparent;
            pnlAnasayfa.ShadowDecoration.Enabled = true;
            pnlAnasayfa.ShadowDecoration.Depth = 10;
            pnlAnasayfa.ShadowDecoration.Color = Color.Black;

            //Arka Plan Resmi

            pcbArkaPlan.Size = new Size(1510, 375);

            // 1. BÜYÜK BAŞLIK LABEL'I
            Label lblBaslik = new Label();
            lblBaslik.Text = "Kahve, günün en\ngüzel molası."; // \n ile alt satıra geçer
            lblBaslik.Font = new Font("Segoe UI", 30f, FontStyle.Bold);
            lblBaslik.ForeColor = ColorTranslator.FromHtml("#CDAA7D"); // Sütlü kahve rengi
            lblBaslik.BackColor = Color.Transparent;
            lblBaslik.AutoSize = true;
            lblBaslik.Location = new Point(139, 60);
            lblBaslik.Parent = pcbArkaPlan; // Resmin içine hapset
            lblBaslik.BringToFront(); // Öne getir

            // 2. ALT METİN LABEL'I
            Label lblAltMetin = new Label();
            lblAltMetin.Text = "Özenle seçilmiş kahveler, taze tatlar ve kendine ayırdığın güzel\nbir an.";
            lblAltMetin.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            lblAltMetin.ForeColor = Color.White;
            lblAltMetin.BackColor = Color.Transparent;
            lblAltMetin.AutoSize = true;
            lblAltMetin.Location = new Point(144, 190); // Başlığın hemen altına ayarla
            lblAltMetin.Parent = pcbArkaPlan;
            lblAltMetin.BringToFront();

            //FlowLayotPanel Kahveleri Yükleme Metodunu Çağırdık
            KahveleriYukle();

            //FlowLayoutPanel Ayarları
            flowLayoutPanel1.Size = new Size(1240, 800);
            flowLayoutPanel1.Location = new Point(150, 650);

            //Öne Çıkan Kahveler Adlı Label Ayarları
            lblOneCikanlar.Text = "Öne Çıkan Kahveler";

            lblOneCikanlar.Location = new Point(170, 580);
            pnlMenuKesfet.Location = new Point(165, 578);
        }
        #endregion

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-4HIU3RA;Initial Catalog=CafeUygulamasi;Integrated Security=True;");

        #region Kahveleri Yükleme Metodu
        //KAHVELERİ PANELE YÜKLEYEN METOT
        private void KahveleriYukle()
        {
            // Önce panelin içini temizle (eğer daha önce yüklendiyse)
            flowLayoutPanel1.Controls.Clear();

            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }

                //Veritabanından kahveleri çek
                SqlCommand komut = new SqlCommand("SELECT KahveAdi,Fiyat,ResimYolu FROM KahveYonetim", baglanti);

                SqlDataReader reader = komut.ExecuteReader();

                while (reader.Read())
                {
                    //Her veri için yeni bir kart oluşturur
                    KahveAfisleri kart = new KahveAfisleri();

                    // Kartın özelliklerini veritabanından gelen verilerle doldur
                    kart.KahveAdi = reader["KahveAdi"].ToString();
                    kart.Fiyat = Convert.ToDecimal(reader["Fiyat"]).ToString("0.00") + " ₺"; // Fiyatı düzgün formatla
                    kart.ResimYolu = reader["ResimYolu"].ToString();

                    flowLayoutPanel1.Controls.Add(kart);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kahveler yüklenirken hata: " + ex.Message);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
            }
        }
        #endregion

        #region Üst Panel Sayfa Geçiş Olayları
        //ÜST PANEL BUTONLARI
        private void lbliletisim_Click(object sender, EventArgs e)
        {
            Iletisim iletisim = new Iletisim();
            iletisim.Show();
            this.Hide();
        }

        private void lblHakkımızda_Click(object sender, EventArgs e)
        {
            Hakkimizda hakkimizda = new Hakkimizda();
            hakkimizda.Show();
            this.Hide();
        }
        #endregion

        #region Geri Butonu Olayı
        //Geri ve Çıkış Butonları
        private void btnGeri_Click(object sender, EventArgs e)
        {
           Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
        #endregion

        #region Üst Panel Mouse Hover Efektleri
        //ÜST PANEL LABELLARI MOUSE HOVER AYARLARI
        private void lblAnasayfa_MouseEnter(object sender, EventArgs e)
        {
            lblAnasayfa.ForeColor = Color.FromArgb(225, 198, 163);
        }

        private void lblAnasayfa_MouseLeave(object sender, EventArgs e)
        {
            lblAnasayfa.ForeColor = Color.FromArgb(221, 174, 118);
        }

        private void lblHakkımızda_MouseEnter(object sender, EventArgs e)
        {
            lblHakkımızda.ForeColor = Color.FromArgb(225, 198, 163);
        }

        private void lblHakkımızda_MouseLeave(object sender, EventArgs e)
        {
            lblHakkımızda.ForeColor = Color.FromArgb(221, 174, 118);
        }

        private void lbliletisim_MouseEnter(object sender, EventArgs e)
        {
            lbliletisim.ForeColor = Color.FromArgb(225, 198, 163);
        }

        private void lbliletisim_MouseLeave(object sender, EventArgs e)
        {
            lbliletisim.ForeColor = Color.FromArgb(221, 174, 118);
        }

        private void lblSepetim_MouseEnter(object sender, EventArgs e)
        {
            lblSepetim.ForeColor = Color.FromArgb(225, 198, 163);
        }

        private void lblSepetim_MouseLeave(object sender, EventArgs e)
        {
            lblSepetim.ForeColor = Color.FromArgb(221, 174, 118);
        }
        #endregion

        #region Sistemden Çıkış Butonu
        //ÇIKIŞ BUTONU
        private void btnCikis_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        #endregion

     

        #region Menü Keşfet Butonu Olayı
        private void btnMenuKesfet_Click(object sender, EventArgs e)
        {
            KahveMenü kahveMenü = new KahveMenü();
            kahveMenü.Show();
            this.Hide();
        }
        #endregion

       
    }
}