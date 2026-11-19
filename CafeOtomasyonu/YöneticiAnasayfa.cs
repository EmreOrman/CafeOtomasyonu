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
using System.Data.SqlClient;

namespace CafeOtomasyonu
{
    public partial class YöneticiAnasayfa : Form
    {
        public YöneticiAnasayfa()
        {
            InitializeComponent();
        }

        #region DataGrid Renkleri ve Ayarları Metodu
        void GridRenkAyarlar()
        {
            // Tablonun genel renk ayarları
            KullaniciYönGrid.EnableHeadersVisualStyles = false;
            KullaniciYönGrid.BorderStyle = BorderStyle.None;
            KullaniciYönGrid.BackgroundColor = ColorTranslator.FromHtml("#221B17");
            KullaniciYönGrid.GridColor = ColorTranslator.FromHtml("#3A2C24");
            KullaniciYönGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            KullaniciYönGrid.RowHeadersVisible = false;

            // Başlık (Header) Ayarları
            KullaniciYönGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            KullaniciYönGrid.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1A1512");
            KullaniciYönGrid.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#CDAA7D");
            KullaniciYönGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            KullaniciYönGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#1A1512");
            KullaniciYönGrid.ColumnHeadersHeight = 40;
            KullaniciYönGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Satır (Row) Ayarları
            KullaniciYönGrid.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#221B17");
            KullaniciYönGrid.DefaultCellStyle.ForeColor = Color.White;
            KullaniciYönGrid.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#4D3D30");
            KullaniciYönGrid.DefaultCellStyle.SelectionForeColor = Color.White;
            KullaniciYönGrid.DefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Regular);

            KullaniciYönGrid.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#2E221C");
            KullaniciYönGrid.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            KullaniciYönGrid.AlternatingRowsDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#4D3D30");

            KullaniciYönGrid.RowTemplate.Height = 35;
            KullaniciYönGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        #endregion

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-4HIU3RA;Initial Catalog=CafeUygulamasi;Integrated Security=True;");

        #region Load Ekranı
        private void YöneticiAnasayfa_Load(object sender, EventArgs e)
        {
            GridRenkAyarlar();

            try
            {
                string sorgu = "Select id, Ad,Sifre,eposta from Kullanicilar";

                SqlDataAdapter adapter = new SqlDataAdapter(sorgu, baglanti);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                KullaniciYönGrid.DataSource = dt;

                // --- SÜTUN AYARLARINI BURAYA TAŞIDIK ---
                // Veri bağlandıktan sonra sütunlar oluştuğu için artık hata vermez
                KullaniciYönGrid.Columns["id"].HeaderText = "ID";
                KullaniciYönGrid.Columns["id"].Width = 50;
                KullaniciYönGrid.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                KullaniciYönGrid.Columns["Ad"].HeaderText = "Adı";
                KullaniciYönGrid.Columns["Sifre"].HeaderText = "Şifre";
                KullaniciYönGrid.Columns["eposta"].HeaderText = "E-Posta";

                // Şifre sütununun görünür olduğundan emin ol
                KullaniciYönGrid.Columns["Sifre"].Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcılar yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
            }

            //BUTON VE LABEL YERLEŞİMLERİ
            btnCikis.Location = new System.Drawing.Point(1465, 5);
            btnGeri.Location = new System.Drawing.Point(0, 5);

            lblİsim1.Location = new System.Drawing.Point(277, 67);
            lblİsim2.Location = new System.Drawing.Point(52, 188);
        }
        #endregion

        #region Sistemden Çıkış Butonu
        private void btnCikis_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        #endregion

        #region DataGrid Hücre Formatlama (CellFormatting)
        private void KullaniciYönGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Eğer işlem gören sütun "Sifre" sütunuysa ve hücrede bir değer varsa
            if (KullaniciYönGrid.Columns[e.ColumnIndex].Name == "Sifre" && e.Value != null)
            {
                // Değerin uzunluğu kadar yıldız (*) koy
                e.Value = new string('*', e.Value.ToString().Length);
                e.FormattingApplied = true; // Biçimlendirmenin uygulandığını bildir
            }
        }
        #endregion

        private void pnlButonlar_Paint(object sender, PaintEventArgs e)
        {

        }

        #region Formlar Arası Geçiş Olayları
        //SOL PANEL BUTONLARI
        private void btnKahveYönetim_Click(object sender, EventArgs e)
        {
            KahveYönetimi kahveYönetimi = new KahveYönetimi();
            kahveYönetimi.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            KullaniciYönetim kullaniciYönetim = new KullaniciYönetim();
            kullaniciYönetim.Show();
            this.Hide();
        }
        #endregion
    }
}