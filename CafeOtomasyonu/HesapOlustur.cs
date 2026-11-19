using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;  //VERİ TABANI bağlantı kütüphanesi

namespace CafeOtomasyonu
{
    public partial class HesapOlustur : Form
    {
        public HesapOlustur()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-4HIU3RA;Initial Catalog=CafeUygulamasi;Integrated Security=True;");

        #region Load Ekranı
        private void HesapOlustur_Load(object sender, EventArgs e)
        {
            pnlHesapOlustur.BackColor = Color.Transparent;

            // Tasarımda seçtiğin orijinal rengi koruyarak çok hafif (244/255) saydamlık verir
            pnlHesapOlustur.FillColor = Color.FromArgb(244, pnlHesapOlustur.FillColor);
        }
        #endregion

        #region Kayıt Olma İşlemi
        private void btnKayitOl_Click_1(object sender, EventArgs e)
        {
            // 1. Adım: Boş alan kontrolü
            if (string.IsNullOrWhiteSpace(txtAd.Text) ||
                string.IsNullOrWhiteSpace(txtEposta.Text) ||
                string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;   // Kodun devamını çalıştırmaz, metottan çıkar.
            }

            // 2. ADIM: Şifre kriterlerinin kontrolü (Regex ile)
            // Bu desen (pattern): En az bir büyük harf, bir küçük harf, bir rakam ve bir özel karakter olmasını zorunlu kılar.
            // .{6,} kısmı ise şifrenin en az 6 karakter uzunluğunda olması gerektiğini belirtir (isteğe göre değiştirebilirsin).
            string sifreKurali = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$";

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtSifre.Text, sifreKurali))
            {
                MessageBox.Show("Şifreniz belirtilen kriterlere uymuyor!\n\n" +
                                "- En az 1 büyük harf\n" +
                                "- En az 1 küçük harf\n" +
                                "- En az 1 rakam\n" +
                                "- En az 1 özel karakter (! @ # $ % _ * ? . -)\n" +
                                "- En az 8 karakter uzunluğunda olmalıdır.",
                                "Geçersiz Şifre", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return; // Kriterlere uymuyorsa veritabanına kaydetme, metottan çıkar.
            }

            try
            {
                baglanti.Open();  // Bağlantıyı aç

                // SQL Injection'ı önlemek için Parametre (@) kullanıyoruz. 
                string sorgu = "INSERT INTO Kullanicilar (Ad,Sifre,eposta) Values(@ad,@sifre,@eposta)";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@ad", txtAd.Text.Trim());
                komut.Parameters.AddWithValue("@sifre", txtSifre.Text.Trim());
                komut.Parameters.AddWithValue("@eposta", txtEposta.Text.Trim());
                komut.ExecuteNonQuery();

                baglanti.Close();

                MessageBox.Show("Hesabınız Başarıyla Oluşturuldu! Giriş yapabilirsiniz.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtAd.Text = "";
                txtSifre.Text = "";
                txtEposta.Text = "";

                Form1 giris = new Form1();
                giris.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt Sırasında Bir Hata Oluştu!" + ex.Message, "Hata:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ne olursa olsun bağlantının kapalı olduğundan emin ol
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
            }
        }
        #endregion

        #region Şifre Göster / Gizle İşlemi
        //GÖZ İCONU (Şifre Gizleme)
        private void txtSifre_IconRightClick(object sender, EventArgs e)
        {
            // Eğer şifre şu an gizliyse (yıldızlıysa)
            if (txtSifre.PasswordChar == '●')
            {
                // Şifreyi görünür yap
                txtSifre.PasswordChar = '\0';
            }
            // Eğer şifre şu an görünürse
            else
            {
                // Şifreyi tekrar gizle (yıldızlı yap)
                txtSifre.PasswordChar = '●';
            }
        }
        #endregion

        #region Formlar Arası Geçiş ve Çıkış Butonları
        //Giriş Yap butonuna tıklayınca geri gelmesi
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        //GERİ VE ÇIKIŞ BUTONLARI
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