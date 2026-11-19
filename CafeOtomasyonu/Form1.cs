using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //Veritabanı bağlantı kütüphanesi

namespace CafeOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-4HIU3RA;Initial Catalog=CafeUygulamasi;Integrated Security=True;");

        #region Kullanıcı Giriş Kontrol Metodu
        //Kullanıcının giriş butonuna bastıktan sonra, textboxa yazdığı bilgilerini
        //veritabanındaki bilgileri ile karşılaştıran metot
        void bilgiler()
        {
            try
            {
                baglanti.Open();

                string sorgu = "Select * from Kullanicilar Where eposta= @p2 and Sifre = @p3";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@p2", txtEposta.Text.Trim());
                komut.Parameters.AddWithValue("@p3", txtSifre.Text.Trim());

                SqlDataReader dr = komut.ExecuteReader();

                if (dr.Read())
                {
                    MessageBox.Show("Giriş Başarılı! Hoş Geşdiniz " + dr["eposta"].ToString() + " " + dr["Sifre"].ToString(), "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Anasayfa anasayfa = new Anasayfa();
                    anasayfa.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("E Postanız veya Şifreniz hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı Bağlantı Hatası" + ex.Message, "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                if (baglanti.State == System.Data.ConnectionState.Open)
                {
                    baglanti.Close();
                }
            }
        }
        #endregion

        #region Load Ekranı
        private void Form1_Load(object sender, EventArgs e)
        {
            pnlKullaniciGiris.BackColor = Color.Transparent;

            // Tasarımda seçtiğin orijinal rengi koruyarak çok hafif (244/255) saydamlık verir
            pnlKullaniciGiris.FillColor = Color.FromArgb(244, pnlKullaniciGiris.FillColor);
        }
        #endregion

        #region Formlar Arası Geçiş Olayları
        //Hesap Oluştur ve Şifremi Unuttum adlı linkler
        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HesapOlustur hesapOlustur = new HesapOlustur();
            hesapOlustur.Show();
            this.Hide();
        }

        private void linkSifreUnuttum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SifremiUnuttum sifremiUnuttum = new SifremiUnuttum();
            sifremiUnuttum.Show();
            this.Hide();
        }
        #endregion

        #region Giriş Butonu Olayı
        //Kullanıcı giriş butonuna bastığı zaman. "Bilgiler()" metodu sayesinde veritabanındaki veriler kontrol edilir.  
        private void btnGiris_Click(object sender, EventArgs e)
        {
            bilgiler();
        }
        #endregion

        #region Şifre Göster / Gizle İşlemi
        //TEXTBOX da bulunan göz iconuna tıklayınca şifre gizlenir
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

        #region Sistemden Çıkış Butonu
        //Programdan Çıkış
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        #endregion
    }
}