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
    public partial class KullaniciYönetim : Form
    {
        public KullaniciYönetim()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-4HIU3RA;Initial Catalog=CafeUygulamasi;Integrated Security=True;");

        // Seçili kullanıcının ID'sini tutacağımız değişken
        int secilenKullaniciID = 0;

        #region Load Ekranı
        private void KullaniciYönetim_Load(object sender, EventArgs e)
        {
            // Form açıldığında ComboBox'ın varsayılan değerini ayarla
            cmbKullaniciAra.SelectedIndex = 0;

            GridRenkAyarlar();

            KullanicilariListele();
        }
        #endregion

        #region DataGrid Renkleri ve Ayarları Metodu
        // --- GRID RENK AYARLARI ---
        void GridRenkAyarlar()
        {
            DataGridKullanicilar.EnableHeadersVisualStyles = false;
            DataGridKullanicilar.BorderStyle = BorderStyle.None;
            DataGridKullanicilar.BackgroundColor = ColorTranslator.FromHtml("#1A1512");
            DataGridKullanicilar.GridColor = ColorTranslator.FromHtml("#3A2C24");
            DataGridKullanicilar.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DataGridKullanicilar.RowHeadersVisible = false;
            DataGridKullanicilar.AllowUserToAddRows = false;

            // Başlık Renkleri
            DataGridKullanicilar.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DataGridKullanicilar.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1A1512");
            DataGridKullanicilar.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#CDAA7D");
            DataGridKullanicilar.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            DataGridKullanicilar.ColumnHeadersHeight = 40;

            // Satır Renkleri
            DataGridKullanicilar.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#221B17");
            DataGridKullanicilar.DefaultCellStyle.ForeColor = Color.White;
            DataGridKullanicilar.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#4D3D30");
            DataGridKullanicilar.DefaultCellStyle.SelectionForeColor = Color.White;
            DataGridKullanicilar.DefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Regular);

            // Zebra Çizgileri
            DataGridKullanicilar.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#2E221C");
            DataGridKullanicilar.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            DataGridKullanicilar.AlternatingRowsDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#4D3D30");

            DataGridKullanicilar.RowTemplate.Height = 40;
            DataGridKullanicilar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // --- GRID DÜZENLEMEYİ KAPAT (YENİ EKLENEN) ---
            DataGridKullanicilar.ReadOnly = true; // Hücreler düzenlenemez
            DataGridKullanicilar.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Tıklayınca tüm satır seçilir

            // --- GRID DÜZENLEMEYİ VE ETKİLEŞİMİ KAPAT ---
            DataGridKullanicilar.ReadOnly = true;
            DataGridKullanicilar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // SÜTUN VE SATIR BOYUTLANDIRMAYI KAPAT (Kocaman büyümesin diye)
            DataGridKullanicilar.AllowUserToResizeColumns = false;
            DataGridKullanicilar.AllowUserToResizeRows = false;
            DataGridKullanicilar.AllowUserToOrderColumns = false; // Sütunların yeri değişmesin
            DataGridKullanicilar.MultiSelect = false;

            // Başlık Renkleri
            DataGridKullanicilar.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DataGridKullanicilar.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1A1512");
            DataGridKullanicilar.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#CDAA7D");
            DataGridKullanicilar.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            DataGridKullanicilar.ColumnHeadersHeight = 40;

            // BAŞLIĞA TIKLAYINCA MAVİ OLMASINI ENGELLE
            DataGridKullanicilar.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#1A1512");
            DataGridKullanicilar.ColumnHeadersDefaultCellStyle.SelectionForeColor = ColorTranslator.FromHtml("#CDAA7D");

            // ... (mevcut satır renkleri ve diğer ayarların kalsın) ...
        }
        #endregion

        #region DataGrid Kullanıcıları Listeleme Metodu
        // --- KULLANICILARI LİSTELEME (Arama ve Sıralama Dahil) ---
        private void KullanicilariListele(string aramaMetni = "", string siralama = "Sırala: Varsayılan")
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                // Temel Sorgu
                string sorgu = "SELECT id, Ad, eposta, Sifre, KayitTarihi FROM Kullanicilar WHERE 1=1";

                // Arama Şartı
                if (!string.IsNullOrEmpty(aramaMetni))
                {
                    sorgu += " AND Ad LIKE @arama";
                }

                // Sıralama Şartı
                if (siralama == "Kayıt: En Yeni")
                {
                    sorgu += " ORDER BY KayitTarihi DESC";
                }
                else if (siralama == "Kayıt: En Eski")
                {
                    sorgu += " ORDER BY KayitTarihi ASC";
                }

                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                if (!string.IsNullOrEmpty(aramaMetni))
                {
                    komut.Parameters.AddWithValue("@arama", "%" + aramaMetni + "%");
                }

                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Eski sütunları temizle (üst üste binmesin)
                DataGridKullanicilar.DataSource = null;
                DataGridKullanicilar.Columns.Clear();

                // Grid'e bağla
                DataGridKullanicilar.DataSource = dt;

                // Sütun Başlıklarını Düzenle
                DataGridKullanicilar.Columns["id"].HeaderText = "ID";

                // ÇÖP KOVASI (SİL) SÜTUNU EKLEME
                if (!DataGridKullanicilar.Columns.Contains("colSil"))
                {
                    DataGridViewImageColumn silSutunu = new DataGridViewImageColumn();
                    silSutunu.Name = "colSil";
                    silSutunu.HeaderText = "İşlem";
                    silSutunu.Image = Properties.Resources.delete;
                    silSutunu.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    silSutunu.Width = 50;
                    silSutunu.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    silSutunu.DefaultCellStyle.Padding = new Padding(8, 5, 8, 5);
                    DataGridKullanicilar.Columns.Add(silSutunu);
                }

                DataGridKullanicilar.Columns["id"].Width = 50;
                DataGridKullanicilar.Columns["Ad"].HeaderText = "Adı";
                DataGridKullanicilar.Columns["eposta"].HeaderText = "E-Posta";
                DataGridKullanicilar.Columns["Sifre"].HeaderText = "Şifre";
                DataGridKullanicilar.Columns["KayitTarihi"].HeaderText = "Kayıt Tarihi";
                DataGridKullanicilar.Columns["KayitTarihi"].DefaultCellStyle.Format = "dd.MM.yyyy"; // Sadece tarih
            }
            catch (Exception ex)
            {
                MessageBox.Show("Listeleme hatası: " + ex.Message);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
            }
        }
        #endregion

        #region DataGrid Hücre Formatlama (CellFormatting)
        // --- GRID'DE ŞİFREYİ YILDIZLI GÖSTERME -
        private void DataGridKullanicilar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DataGridKullanicilar.Columns[e.ColumnIndex].Name == "Sifre" && e.Value != null)
            {
                e.Value = new string('*', e.Value.ToString().Length);
                e.FormattingApplied = true;
            }
        }
        #endregion

        #region Arama ve Sıralama İşlemleri
        //Kullanici Arama
        private void txtKullaniciAra_TextChanged(object sender, EventArgs e)
        {
            KullanicilariListele(txtKullaniciAra.Text, cmbKullaniciAra.Text);
        }

        // --- SIRALAMA COMBOBOX OLAYI ---
        private void cmbKullaniciAra_SelectedIndexChanged(object sender, EventArgs e)
        {
            KullanicilariListele(txtKullaniciAra.Text, cmbKullaniciAra.Text);
        }
        #endregion

        #region Kullanıcı Ekleme İşlemi
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrWhiteSpace(txtEposta.Text) || string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                string sorgu = "INSERT INTO Kullanicilar (Ad, eposta, Sifre, KayitTarihi) VALUES (@ad, @eposta, @sifre, GETDATE())";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@ad", txtAd.Text.Trim());
                komut.Parameters.AddWithValue("@eposta", txtEposta.Text.Trim());
                komut.Parameters.AddWithValue("@sifre", txtSifre.Text.Trim());
                komut.ExecuteNonQuery();

                MessageBox.Show("Kullanıcı başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                KullanicilariListele();
                Temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ekleme hatası: " + ex.Message);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
            }
        }
        #endregion

        #region Kullanıcı Güncelleme İşlemi
        //Güncelle Butonu Olayı
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (secilenKullaniciID == 0)
            {
                MessageBox.Show("Lütfen grid'den güncellenecek kullanıcıyı seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                string sorgu = "UPDATE Kullanicilar SET Ad=@ad, eposta=@eposta WHERE id=@id";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@ad", txtAd.Text.Trim());
                komut.Parameters.AddWithValue("@eposta", txtEposta.Text.Trim());
                komut.Parameters.AddWithValue("@id", secilenKullaniciID);
                komut.ExecuteNonQuery();

                MessageBox.Show("Kullanıcı başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                KullanicilariListele();
                Temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme hatası: " + ex.Message);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
            }
        }
        #endregion

        #region Formu Temizleme İşlemi
        //Temizle Butonu Olayı
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle(); // Sadece textbox'ları ve seçili ID'yi sıfırlar

            //Yönetici "Temizle" butonuna basıp yeni  bir kullanıcı ekleyecekse "şifre" alanını görebilir
            lblSifre.Visible = true;
            txtSifre.Visible = true;
        }
        #endregion

        #region DataGrid Satır Seçimi ve Veri Aktarımı
        //DataGrid de herhangi bir kullanıcıya tıklanınca bilgileri textboxlara aktarır
        private void DataGridKullanicilar_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Satır başlığına veya geçersiz bir yere tıklanmadıysa
            if (e.RowIndex >= 0 && e.RowIndex < DataGridKullanicilar.Rows.Count)
            {
                DataGridViewRow row = DataGridKullanicilar.Rows[e.RowIndex];

                // Hücrelerin boş olmadığından emin olalım
                if (row.Cells["id"].Value != null)
                {
                    secilenKullaniciID = Convert.ToInt32(row.Cells["id"].Value);
                    txtAd.Text = row.Cells["Ad"].Value?.ToString() ?? "";
                    txtEposta.Text = row.Cells["eposta"].Value?.ToString() ?? "";
                    txtSifre.Text = row.Cells["Sifre"].Value?.ToString() ?? "";
                }

                //Yöneticimiz DataGrid de herhangi bie kullanıcıya tıklayınca kullanıcı verileri texboxlara aktarılıyor
                //Ancak kullanıcının şifreleri yönetici tarafından görülmesini istemiyoruz. Bu yüzden yöneciti şifre textboxını göremiyor.
                //Ancak kullanıcı eklerse görebilir
                lblSifre.Visible = false;
                txtSifre.Visible = false;
                txtSifre.Clear();
            }
        }
        #endregion

        #region Form Geçişleri ve Çıkış Butonları
        //Geri Ve Çıkış Butonları
        private void btnCikis_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            YöneticiAnasayfa yöneticiAnasayfa = new YöneticiAnasayfa();
            yöneticiAnasayfa.Show();
            this.Hide();
        }

        private void btnKahveYönetim_Click(object sender, EventArgs e)
        {
            KahveYönetimi kahveyonetimi = new KahveYönetimi();
            kahveyonetimi.Show();
            this.Hide();
        }
        #endregion

        #region Yardımcı Metotlar
        // --- FORMU TEMİZLEME YARDIMCI METODU ---
        private void Temizle()
        {
            txtAd.Clear();
            txtEposta.Clear();
            txtSifre.Clear();
            secilenKullaniciID = 0;
        }
        #endregion

        #region DataGrid Kullanıcı Silme İşlemi
        //Datagridde silme iconu (çöp kovası) tıklanınca kullanıcıları silme işlemi
        private void DataGridKullanicilar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Eğer tıklanan sütun "colSil" ise ve geçerli bir satırsa
            if (e.ColumnIndex == DataGridKullanicilar.Columns["colSil"].Index && e.RowIndex >= 0)
            {
                DialogResult onay = MessageBox.Show("Bu kullanıcıyı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (onay == DialogResult.Yes)
                {
                    // Satırdaki ID değerini al
                    int secilenId = Convert.ToInt32(DataGridKullanicilar.Rows[e.RowIndex].Cells["id"].Value);

                    try
                    {
                        if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                        SqlCommand komut = new SqlCommand("DELETE FROM Kullanicilar WHERE id=@id", baglanti);
                        komut.Parameters.AddWithValue("@id", secilenId);
                        komut.ExecuteNonQuery();

                        MessageBox.Show("Kullanıcı başarıyla silindi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        KullanicilariListele(); // Tabloyu yenile
                        Temizle(); // Formu temizle
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Silme hatası: " + ex.Message);
                    }
                    finally
                    {
                        if (baglanti.State == ConnectionState.Open) baglanti.Close();
                    }
                }
            }
        }
        #endregion

        #region TextBox Giriş Kontrolleri (KeyPress)
        private void txtAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Harf ve boşluk dışındakileri engelle
            }
        }
        #endregion
    }
}