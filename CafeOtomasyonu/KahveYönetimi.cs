using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace CafeOtomasyonu
{
    public partial class KahveYönetimi : Form
    {
        public KahveYönetimi()
        {
            InitializeComponent();
        }

        #region Load Ekranı
        private void KahveYönetimi_Load(object sender, EventArgs e)
        {
            //GERİ VE ÇIKIŞ BUTON YERLEŞİMLERİ
            btnCikis.Location = new System.Drawing.Point(1455, 20);
            btnGeri.Location = new System.Drawing.Point(10, 20);

            //Önce renkler gelmesi için metot
            GridRenkAyarlar();

            //Datagridde kahvelerin listelenmesi için oluşturduğumuz metod
            KahveleriListele();
        }
        #endregion

        #region Datarig Renkleri ve Ayarları Metodu
        void GridRenkAyarlar()
        {
            // Başlıkların Windows varsayılanı yerine bizim renklerimizi kullanmasını sağlar (Sütun isimlerinin görünmemesinin sebebi buydu)
            datagridKahveler.EnableHeadersVisualStyles = false;
            datagridKahveler.BorderStyle = BorderStyle.None;
            datagridKahveler.BackgroundColor = ColorTranslator.FromHtml("#1A1512");
            datagridKahveler.GridColor = ColorTranslator.FromHtml("#3A2C24");
            datagridKahveler.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            datagridKahveler.RowHeadersVisible = false; // En soldaki boş sütunu gizle

            // --- BOŞ SATIRI (KIRMIZI X'İ) GİZLE (YENİ EKLENEN) ---
            datagridKahveler.AllowUserToAddRows = false;

            // Başlık Renkleri
            datagridKahveler.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            datagridKahveler.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1A1512");
            datagridKahveler.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#CDAA7D");
            datagridKahveler.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            datagridKahveler.ColumnHeadersHeight = 40;
            datagridKahveler.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("140; 91; 48");

            // Satır Renkleri
            datagridKahveler.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#221B17");
            datagridKahveler.DefaultCellStyle.ForeColor = Color.White;
            datagridKahveler.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#4D3D30");
            datagridKahveler.DefaultCellStyle.SelectionForeColor = Color.White;
            datagridKahveler.DefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Regular);

            // Zebra Çizgileri
            datagridKahveler.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#2E221C");
            datagridKahveler.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            datagridKahveler.AlternatingRowsDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#4D3D30");

            // Resimlerin sıkışmaması için satır yüksekliğini artırıyoruz
            datagridKahveler.RowTemplate.Height = 60; // 60'dan 70'e çıkardım, resimler daha rahat sığsın diye

            // --- HİZALAMA İÇİN EKLENEN YENİ AYAR ---
            datagridKahveler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Sütunları ekrana yay
            // ----------------------------------------

            datagridKahveler.ReadOnly = true; // Hücrelerdeki yazılar değiştirilemez
            datagridKahveler.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Tıklayınca tüm satır seçilsin
            datagridKahveler.MultiSelect = false; // Aynı anda tek satır seçilsin

            datagridKahveler.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        #endregion

        #region Datagrid Kahveleri Listeleme Metodu
        private void KahveleriListele(string aramaMetni = "", string kategori = "")
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }

                string sorgu = "SELECT id, KahveAdi, Fiyat, Stok, ResimYolu, Kategori FROM KahveYonetim WHERE 1=1";

                if (!string.IsNullOrEmpty(aramaMetni))
                {
                    sorgu += " AND KahveAdi LIKE @arama";
                }

                string dbKategori = "";
                if (kategori.Contains("Sıcak")) dbKategori = "Sicak";
                else if (kategori.Contains("Soğuk")) dbKategori = "Soğuk";

                if (!string.IsNullOrEmpty(dbKategori))
                {
                    sorgu += " AND Kategori = @kategori";
                }

                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                if (!string.IsNullOrEmpty(aramaMetni))
                {
                    komut.Parameters.AddWithValue("@arama", "%" + aramaMetni + "%");
                }

                if (!string.IsNullOrEmpty(dbKategori))
                {
                    komut.Parameters.AddWithValue("@kategori", dbKategori);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                datagridKahveler.DataSource = null;

                datagridKahveler.ClearSelection(); // İlk satırın otomatik seçili kalmasını engelle

                datagridKahveler.AutoGenerateColumns = false; // Grid'in otomatik sütun oluşturmasını engelle

                datagridKahveler.Columns.Clear(); //  Sütunları tamamen temizle (Tasarımcıdan kalanlar varsa gitsin)

                // --- HİZALAMA VE SÜTUN EKLEME AYARLARI ---

                // ID Sütunu (Ortalı)
                datagridKahveler.Columns.Add(new DataGridViewTextBoxColumn { Name = "colID", HeaderText = "ID", DataPropertyName = "id", Width = 50, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } });

                // Resim Sütunu (Ortalı)
                DataGridViewImageColumn resimSutunu = new DataGridViewImageColumn { Name = "colResim", HeaderText = "Resim", DataPropertyName = "ResimYolu", Width = 80, ImageLayout = DataGridViewImageCellLayout.Zoom };
                resimSutunu.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                resimSutunu.DefaultCellStyle.NullValue = null;
                datagridKahveler.Columns.Add(resimSutunu);

                // Kahve Adı Sütunu (Sola Yaslı)
                datagridKahveler.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAd", HeaderText = "Kahve Adı", DataPropertyName = "KahveAdi", DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } });

                // Fiyat Sütunu (Ortalı)
                datagridKahveler.Columns.Add(new DataGridViewTextBoxColumn { Name = "colFiyat", HeaderText = "Fiyat", DataPropertyName = "Fiyat", DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } });

                // Stok Sütunu (Ortalı)
                datagridKahveler.Columns.Add(new DataGridViewTextBoxColumn { Name = "colStok", HeaderText = "Stok", DataPropertyName = "Stok", DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } });

                // İşlemler (Çöp Kovası) Sütunu
                DataGridViewImageColumn silSutunu = new DataGridViewImageColumn();
                silSutunu.Name = "colSil";
                silSutunu.HeaderText = "İşlemler";
                silSutunu.Image = Properties.Resources.delete;
                silSutunu.DefaultCellStyle.Padding = new Padding(20, 15, 20, 15);
                silSutunu.ImageLayout = DataGridViewImageCellLayout.Zoom;
                silSutunu.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                datagridKahveler.Columns.Add(silSutunu);

                datagridKahveler.Columns.Add(new DataGridViewTextBoxColumn { Name = "colKategori", DataPropertyName = "Kategori", Visible = false });
                datagridKahveler.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Listeleme Hatası: " + ex.Message);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
            }
        }
        #endregion


        #region Arama ve Kategorilendirme
      
        //Arama Çubugu Olayı
        private void txtKahveAra_TextChanged(object sender, EventArgs e)
        {
            KahveleriListele(txtKahveAra.Text, cmbKategori.Text);
        }

        // Combobax Kategorilendirme
        private void cmbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            KahveleriListele(txtKahveAra.Text, cmbKategori.Text);
        }

        #endregion


        #region DataGrid Hücrelere Veri Girişi (CellFormatting)
        private void datagridKahveler_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //İşlem yapılan sütun "colResim" ise 
            if (datagridKahveler.Columns[e.ColumnIndex].Name == "colResim" && e.Value != null)
            {
                string resimYolu = e.Value.ToString();

                if (!string.IsNullOrEmpty(resimYolu) && System.IO.File.Exists(resimYolu))
                {
                    e.Value = Image.FromFile(resimYolu);
                }
                else
                {
                    // Resim yoksa veya silinmişse varsayılan bir ikon göster (veya boş bırak)
                    // e.Value = Properties.Resources.VarsayilanResim; (Projene bir varsayılan resim eklersen)
                    e.Value = null;
                }
            }
        }
        #endregion



        #region Datagride tıklanınca verilerin texboxlara aktarılması
        int seciliKahveID = 0; // Hangi kahveyi düzenlediğimizi tutacağız
        private void datagridKahveler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Eğer geçerli bir satır ise 
            if (e.RowIndex >= 0 && e.ColumnIndex != datagridKahveler.Columns["colSil"].Index)
            {
                //Seçilen satırdaki verileri al
                seciliKahveID = Convert.ToInt32(datagridKahveler.Rows[e.RowIndex].Cells["colID"].Value);
                txtKahveAdi.Text = datagridKahveler.Rows[e.RowIndex].Cells["colAd"].Value.ToString();
                txtFiyat.Text = datagridKahveler.Rows[e.RowIndex].Cells["colFiyat"].Value.ToString();
                txtStokAdet.Text = datagridKahveler.Rows[e.RowIndex].Cells["colStok"].Value.ToString();

                //Resim yolunu al ve Picturebox'a gönder
                string resimYolu = datagridKahveler.Rows[e.RowIndex].Cells["colResim"].Value.ToString();

                if (!string.IsNullOrEmpty(resimYolu) && System.IO.File.Exists(resimYolu))
                {
                    pcbSecilenResim.ImageLocation = resimYolu;
                    secilenResimYolu = resimYolu;  // Güncelleme sırasında da bu yolu kullanacağız
                }
                else
                {
                    pcbSecilenResim.Image = null;
                    secilenResimYolu = "";
                }

                string gelenKategori = datagridKahveler.Rows[e.RowIndex].Cells["colKategori"].Value?.ToString() ?? "";

                if (gelenKategori.Contains("Sicak") || gelenKategori.Contains("Sıcak"))
                    cmbKategoriSec.SelectedIndex = 0; // ComboBox'ta ilk sırada Sıcak varsa
                else if (gelenKategori.Contains("Soğuk"))
                    cmbKategoriSec.SelectedIndex = 1; // İkinci sırada Soğuk varsa
                else
                    cmbKategoriSec.SelectedIndex = -1;
            }
        }
        #endregion



        #region DataGrid İçindeki Verileri Silme İşlemi
        // Grid'deki "Çöp Kovası" ikonuna tıklandığında çalışacak olay
        private void datagridKahveler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Eğer tıklanan sütun "colSil" ise ve geçerli bir satır seçiliyse
            if (e.ColumnIndex == datagridKahveler.Columns["colSil"].Index && e.RowIndex >= 0)
            {
                DialogResult onay = MessageBox.Show("Bu kahveyi silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (onay == DialogResult.Yes)
                {
                    // Tıklanan satırdaki ID değerini al
                    int secilenId = Convert.ToInt32(datagridKahveler.Rows[e.RowIndex].Cells["colID"].Value);

                    try
                    {
                        if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                        SqlCommand komut = new SqlCommand("DELETE FROM KahveYonetim WHERE id = @id", baglanti);
                        komut.Parameters.AddWithValue("@id", secilenId);
                        komut.ExecuteNonQuery();

                        baglanti.Close();

                        MessageBox.Show("Kahve başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Silme işleminden sonra tabloyu yenile
                        KahveleriListele();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Silme Hatası: " + ex.Message);
                    }
                    finally
                    {
                        if (baglanti.State == ConnectionState.Open) baglanti.Close();
                    }
                }
            }
        }
        #endregion



        #region Resim Ekleme Butonu Bağlantı Yönetimi
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-4HIU3RA;Initial Catalog=CafeUygulamasi;Integrated Security=True;");

        //SEÇİLEN RESİMLERİ SİSTEME EKLEME KODLARI 
        private void btnSistemeEkle_Click(object sender, EventArgs e)
        {
            //Eğer kullanıcı bir satır seçtikten sonra "Güncelle" yerine "Sisteme Ekle"ye basarsa, yeni bir kayıt oluşur.
            //Bunu engelliyoruz
            if (seciliKahveID != 0)
            {
                MessageBox.Show("Şu an bir kahveyi düzenliyorsunuz. Yeni eklemek için lütfen formu temizleyin veya sayfayı yenileyin.");
                return;
            }

            //textboxların boş alan kontrolü
            if (string.IsNullOrWhiteSpace(txtKahveAdi.Text) ||
                string.IsNullOrWhiteSpace(txtFiyat.Text) ||
                string.IsNullOrWhiteSpace(txtStokAdet.Text) ||
                cmbKategoriSec.SelectedIndex == -1 ||
                secilenResimYolu == "")
            {
                MessageBox.Show("Lütfen tüm alanları doldurun ve bir resim seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                string dbKategori = cmbKategoriSec.Text.Contains("Sıcak") ? "Sicak" : "Soğuk";

                string sorgu = "INSERT INTO KahveYonetim(KahveAdi,Fiyat, Stok, ResimYolu, Kategori) Values(@ad,@fiyat,@stok,@resim, @kategori)";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@ad", txtKahveAdi.Text.Trim());
                komut.Parameters.AddWithValue("@fiyat", Convert.ToDecimal(txtFiyat.Text));
                komut.Parameters.AddWithValue("@stok", Convert.ToInt32(txtStokAdet.Text));
                komut.Parameters.AddWithValue("@resim", secilenResimYolu);
                komut.Parameters.AddWithValue("@kategori", dbKategori);
                komut.ExecuteNonQuery();

                baglanti.Close(); // ÖNCE KAPAT (KahveleriListele içinde tekrar açılacak)

                MessageBox.Show("Kahve başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Kahveler sisteme başarıyla eklendiyse , KahveListele() metodunu çağırıyoruz
                //Bu metod sayesinde, sisteme eklenen kahveler yöneticinin datagridinde görünecek

                // Sonra listele
                KahveleriListele();

                // Formu temizle (İstersen bunları da ekleyebilirsin)
                txtKahveAdi.Clear();
                txtFiyat.Clear();
                txtStokAdet.Clear();
                pcbSecilenResim.Image = null;
                secilenResimYolu = "";
                cmbKategoriSec.SelectedIndex = -1; // <-- SADECE BU SATIRI EKLE
                cmbKategoriSec.Text = "Kategori Seçiniz";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
            }
        }
        #endregion


        #region Güncelle Butonu Olayı
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (seciliKahveID == 0)
            {
                MessageBox.Show("Lütfen güncellemek için önce tablodan bir kahve seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtKahveAdi.Text)
                || string.IsNullOrEmpty(txtFiyat.Text)
                || string.IsNullOrEmpty(txtStokAdet.Text)
                || secilenResimYolu == ""
                || cmbKategoriSec.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun ve bir resim seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }

                string dbKategori = cmbKategoriSec.Text.Contains("Sıcak") ? "Sicak" : "Soğuk";

                string sorgu = "UPDATE KahveYonetim SET KahveAdi = @ad,Fiyat = @fiyat, Stok = @stok, ResimYolu =@resim, Kategori = @kategori WHERE id = @id";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@ad", txtKahveAdi.Text.Trim());
                komut.Parameters.AddWithValue("@fiyat", Convert.ToDecimal(txtFiyat.Text));
                komut.Parameters.AddWithValue("@stok", Convert.ToInt32(txtStokAdet.Text));
                komut.Parameters.AddWithValue("@resim", secilenResimYolu);
                komut.Parameters.AddWithValue("@kategori", dbKategori);
                komut.Parameters.AddWithValue("@id", seciliKahveID);
                komut.ExecuteNonQuery();

                baglanti.Close();

                MessageBox.Show("Kahve başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                KahveleriListele(); // Tabloyu yenile

                // Formu temizle ve seçimi sıfırla
                txtKahveAdi.Clear();
                txtFiyat.Clear();
                txtStokAdet.Clear();
                pcbSecilenResim.Image = null;
                secilenResimYolu = "";
                seciliKahveID = 0;
                cmbKategoriSec.SelectedIndex = -1;
                cmbKategoriSec.Text = "Kategori Seçiniz";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme Hatası: " + ex.Message);
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

    

        #region Textboxları Temizle Buton Olayı
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            if (pcbSecilenResim.Image != null)
            {
                pcbSecilenResim.Image.Dispose();
                pcbSecilenResim.Image = null;
            }

            txtKahveAdi.Clear();
            txtFiyat.Clear();
            txtStokAdet.Clear();

            cmbKategoriSec.SelectedIndex = -1;
            cmbKategoriSec.Text = "Kategori Seçiniz";
            secilenResimYolu = ""; // Önceki kahvenin resim yolu hafızada kalmasın
            seciliKahveID = 0;     // Düzenleme modundan tamamen çık

            datagridKahveler.ClearSelection(); // Sağdaki tabloda seçili kalan satır vurgusunu kaldır
        }
        #endregion

        //Formlar Arası Geçiş Olayları
        private void btnKullaniciYönetim_Click(object sender, EventArgs e)
        {
            KullaniciYönetim kullaniciYönetim = new KullaniciYönetim();
            kullaniciYönetim.Show();
            this.Hide();
        }

        //TEXTBOXLARA HARF Mİ,  RAKAM MI GİRİLMESİNİ BELİRLEYEN KODLAR

        // 1. Kahve Adı (Sadece Harf ve Boşluk)
        private void txtKahveAdi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Harf ve boşluk dışındakileri engelle
            }
        }

        // 2. Fiyat (Sadece Rakam, Virgül ve Nokta)
        private void txtFiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true; // Rakam ve ondalık ayırıcı dışındakileri engelle
            }
        }

        // 3. Stok (Sadece Rakam)
        private void txtStokAdet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Sadece rakam girilebilir
            }
        }


        #region Dosya Yönetim Kodları
       
        string secilenResimYolu = "";

        private void btnResimSec_Click(object sender, EventArgs e)
        {
            //Sadece resim dosyalarını seçiyoruz
            OpenFileDialog dosyaSec = new OpenFileDialog();

            dosyaSec.Filter = "Resim Dosyaları| *.jpg;*.jpeg;*.png;*.bmp";
            dosyaSec.Title = "Bir Kahve Resmi Seçiniz";

            if (dosyaSec.ShowDialog() == DialogResult.OK)
            {
                //Seçlen resmi pictureboxa gönder
                pcbSecilenResim.ImageLocation = dosyaSec.FileName;
                pcbSecilenResim.SizeMode = PictureBoxSizeMode.Zoom;

                //Dosya yolunu değişkene kaydet
                secilenResimYolu = dosyaSec.FileName;
            }
        }
        #endregion





        #region Sistemden Çıkıs Butonları
        //GERİ VE ÇIKIŞ BUTONLARI

        //önceki forma gel
        private void btnGeri_Click(object sender, EventArgs e)
        {
            YöneticiAnasayfa yöneticiAnasayfa = new YöneticiAnasayfa();
            yöneticiAnasayfa.Show();
            this.Hide();
        }

        //sistemden çık
        private void btnCikis_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnCıkıs2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        #endregion
    }
}