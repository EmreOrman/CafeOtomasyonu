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
    public partial class KodDogrulamaFormu : Form
    {
        // SifremiUnuttum formundan gelecek verileri tutacağımız değişkenler
        public string GelenKod { get; set; }
        public string GelenEposta { get; set; }

        public KodDogrulamaFormu()
        {
            InitializeComponent();
        }

        #region Load Ekranı
        private void KodDogrulamaFormu_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Kod Doğrulama İşlemi
        private void btnSifreYenile_Click(object sender, EventArgs e)
        {
            // 1. Kutulardaki rakamları tek bir string'de birleştir
            string girilenKod = txtKod1.Text + txtKod2.Text + txtKod3.Text + txtKod4.Text;

            if (girilenKod.Length < 4)
            {
                MessageBox.Show("Lütfen 4 haneli kodu eksiksiz giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Girilen kod, gönderilen kod ile eşleşiyor mu?
            if (girilenKod == GelenKod)
            {
                MessageBox.Show("Kod doğrulandı! Yeni şifrenizi belirleyebilirsiniz.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                //BURAYA DAHA SONRA ŞİFRE YENİLEME FORMU OLUŞTURULUP EKLENECEKTİR

                // SifreYenilemeFormu sifreForm = new SifreYenilemeFormu();
                // sifreForm.GelenEposta = GelenEposta;
                // sifreForm.Show();
                // this.Hide();
            }
            else
            {
                MessageBox.Show("Girdiğiniz kod hatalı! Lütfen tekrar deneyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtKod1.Clear();
                txtKod2.Clear();
                txtKod3.Clear();
                txtKod4.Clear();
            }
        }
        #endregion

        #region Formlar Arası Geçiş ve Çıkış Butonları
        //ÇIKIŞ VE GERİ BUTONLARI
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

        private void pnlKodDogrulaArkaPlan_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}