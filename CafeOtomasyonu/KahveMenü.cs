using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeOtomasyonu
{
    public partial class KahveMenü : Form
    {
        public KahveMenü()
        {
            InitializeComponent();
        }

        #region Load Ekranı
        private void KahveMenü_Load(object sender, EventArgs e)
        {
            // Form yüklenirken ComboBox'ların seçili olmasını sağla
            cmbSırala.SelectedIndex = 0; // Varsayılan
            cmbKategori.SelectedIndex = 0; // Tüm Kahveler

            KahveleriYukle(txtKahveAra.Text, cmbSırala.Text, cmbKategori.Text);

            //FlowPanel Ayarları
            flowLayoutPanel1.Size = new Size(1240, 800);
            flowLayoutPanel1.Location = new Point(150, 400);

            // Üst Panel (Navbar) Ayarları
            pnlKahveMenu.BorderRadius = 25;
            pnlKahveMenu.BorderThickness = 2;
            pnlKahveMenu.BorderColor = ColorTranslator.FromHtml("#CDAA7D");

            // Üst panelin saydamlığını da biraz artıralım
            pnlKahveMenu.BackColor = Color.Transparent;
            pnlKahveMenu.ShadowDecoration.Enabled = true;
            pnlKahveMenu.ShadowDecoration.Depth = 10;
            pnlKahveMenu.ShadowDecoration.Color = Color.Black;

            //Öne Çıkan Kahveler Adlı Label Ayarları
            lblMenuKesfet.Text = "Menüyü Keşfet";
            lblMenuKesfet.Location = new Point(225, 130);
            pnlOneCıkan.Location = new Point(214, 140);

            pnlKahveAra.Size = new Size(1190, 87);
            pnlKahveAra.Location = new Point(160, 260);

            txtKahveAra.Size = new Size(755, 49);

            //Combobaxların Ayarları
            cmbKategori.Location = new Point(798, 20);
            cmbKategori.Size = new Size(175, 80);

            cmbSırala.Location = new Point(990, 20);
            cmbSırala.Size = new Size(175, 80);

            //Kahve Logosu Ayarları
            pcbKahveLogo.Location = new Point(154, 132);
            pcbKahveLogo.Size = new Size(55, 55);

            //Metin Ayarları
            lblKahveMetin.Text = "Damak zevkinize uygun, özenle hazırlanmış kahvelerimizi keşfedin.";
            lblKahveMetin.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblKahveMetin.ForeColor = Color.DarkGray;
            lblKahveMetin.Location = new Point(231, 180);
        }
        #endregion

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-4HIU3RA;Initial Catalog=CafeUygulamasi;Integrated Security=True;");

        #region Kahveleri Yükleme Metodu
        //KAHVELERİ PANELE YÜKLEYEN METOT
        private void KahveleriYukle(string aramaMetni = "", string siralama = "", string kategori = "")
        {
            // Önce panelin içini temizle (eğer daha önce yüklendiyse)
            flowLayoutPanel1.Controls.Clear();

            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }

                //ARAMA (LİKE) SORGUSU İÇİN GÜNCELLENMİŞ KODLAR

                // KOMBOBOXDAN GELEN METNİ VERİTABANI DEĞERİNE ÇEVİR
                string dbKategori = "";
                if (kategori == "Sıcak Kahveler") dbKategori = "Sicak";
                else if (kategori == "Soğuk Kahveler") dbKategori = "Soğuk";

                string sorgu = "SELECT KahveAdi,Fiyat,ResimYolu FROM KahveYonetim WHERE 1=1";

                if (!string.IsNullOrEmpty(aramaMetni))
                {
                    sorgu += " AND KahveAdi LIKE @arama";
                }

                if (!string.IsNullOrEmpty(kategori) && kategori != "Tüm Kahveler")
                {
                    sorgu += " AND Kategori = @kategori";
                }

                if (siralama == "Fiyat: Artan")
                {
                    sorgu += " ORDER BY Fiyat ASC";
                }
                else if (siralama == "Fiyat: Azalan")
                {
                    sorgu += " ORDER BY Fiyat DESC";
                }

                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                if (!string.IsNullOrEmpty(aramaMetni))
                {
                    komut.Parameters.AddWithValue("@arama", "%" + aramaMetni + "%");
                }

                if (!string.IsNullOrEmpty(kategori) && kategori != "Tüm Kahveler")
                {
                    komut.Parameters.AddWithValue("@kategori", dbKategori);
                }

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

        #region Arama, Sıralama ve Filtreleme İşlemleri
        //Kullanıcının textbox üzerinden yazarak kahve araması .
        private void txtKahveAra_TextChanged(object sender, EventArgs e)
        {
            KahveleriYukle(txtKahveAra.Text, cmbSırala.Text, cmbKategori.Text);
        }

        //Kullanıcının combobax üzerine tıklayıp kategori seçmesi.
        private void cmbSırala_SelectedIndexChanged(object sender, EventArgs e)
        {
            KahveleriYukle(txtKahveAra.Text, cmbSırala.Text, cmbKategori.Text);
        }

        private void cmbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbKategori.BorderColor = Color.FromArgb(221, 174, 118);

            KahveleriYukle(txtKahveAra.Text, cmbSırala.Text, cmbKategori.Text);
        }
        #endregion

        #region Formlar Arası Geçiş ve Çıkış Butonları
        //Formla Arası Geçiş Butonları
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
            Iletisim ıletisim = new Iletisim();
            ıletisim.Show();
            this.Hide();
        }

        //Geri ve Çıkış Butonları
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
    }
}