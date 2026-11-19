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
using System.Diagnostics.Eventing.Reader;  //Veritabanı bağlantı kütüphanesi

namespace CafeOtomasyonu
{
    public partial class SifremiUnuttum : Form
    {
        public SifremiUnuttum()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-4HIU3RA;Initial Catalog=CafeUygulamasi;Integrated Security=True;");

        #region Load Ekranı
        private void SifremiUnuttum_Load(object sender, EventArgs e)
        {
            pnlSifremiUnuttum.BackColor = Color.Transparent;

            // Tasarımda seçtiğin orijinal rengi koruyarak çok hafif (244/255) saydamlık verir
            pnlSifremiUnuttum.FillColor = Color.FromArgb(244, pnlSifremiUnuttum.FillColor);
        }
        #endregion

        #region Doğrulama Kodu Gönderme İşlemi
        private void btnSifremiUnuttum_Click(object sender, EventArgs e)
        {
            // 1. Adım: Boş alan kontrolü
            if (string.IsNullOrWhiteSpace(txtEposta.Text))
            {
                MessageBox.Show("Lütfen E-Posta Adresinizi Giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;   // Kodun devamını çalıştırmaz, metottan çıkar.
            }

            try
            {
                baglanti.Open();

                String sorgu = "SELECT COUNT(*) FROM Kullanicilar WHERE eposta = @eposta";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@eposta", txtEposta.Text.Trim());

                // Sorguyu çalıştır ve sonucu al(1 ise var, 0 ise yok)
                int kullaniciVarMi = Convert.ToInt32(komut.ExecuteScalar());

                if (kullaniciVarMi > 0)
                {
                    // 3. Kullanıcı varsa 6 haneli rastgele bir kod üret (100000 ile 999999 arası)
                    Random rastgele = new Random();
                    string dogrulamaKodu = rastgele.Next(1000, 9999).ToString();

                    // 4. Kodu ekrana göster (Mail simülasyonu)
                    MessageBox.Show($"Şifre sıfırlama kodunuz: {dogrulamaKodu}\n\n(Bu kod normalde e-posta adresinize gönderilir.)",
                                    "Doğrulama Kodu Gönderildi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    KodDogrulamaFormu kodForm = new KodDogrulamaFormu();
                    kodForm.GelenKod = dogrulamaKodu; // Kodu forma gönder
                    kodForm.GelenEposta = txtEposta.Text.Trim(); // Emaili forma gönder
                    kodForm.Show();
                    this.Hide(); // Mevcut formu gizle
                }
                else
                {
                    MessageBox.Show("Bu e-posta adresine ait bir kullanıcı bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region Formlar Arası Geçiş ve Çıkış Butonları
        //Geri Dönme Linki
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        // Geri Ve Çıkış Butonları 
        private void btnGeri_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        #endregion
    }
}