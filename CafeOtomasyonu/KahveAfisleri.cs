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
    public partial class KahveAfisleri : UserControl
    {
        public KahveAfisleri()
        {
            InitializeComponent();

            // UserControl yüklendiğinde resmi yuvarlat
            // PictureBox'ının adını kendi tasarımına göre değiştir (Örn: pcbKahveResim)
            this.Load += (s, e) =>
            {


                // Orijinal boyut ve konumu kaydet
                orijinalBoyut = pnlAfis.Size;
                orijinalKonum = pnlAfis.Location;

                // Diğer işlemler (resmi yuvarlatma, hover bağlama vs.)
                ResmiYuvarlat(pcbKahveResim, 20);
                HoverOlaylariniBagla(this);

            };

        }


        public string KahveAdi
        {
            get { return lblKahveAdi.Text; }
            set { lblKahveAdi.Text = value; }

        }

        public string Fiyat
        {
            get { return lblKahveFiyat.Text; }
            set { lblKahveFiyat.Text = value; }

        }

        public string ResimYolu
        {
            get { return pcbKahveResim.ImageLocation; }
            set { pcbKahveResim.ImageLocation = value; }
        }



        private Size orijinalBoyut;
        private Point orijinalKonum;
        private bool isHovered = false;


      

        // Bu metot, kartın içindeki HER ŞEYE (panel, resim, yazı, buton) aynı olayı bağlar
        private void HoverOlaylariniBagla(Control parent)
        {
            parent.MouseEnter += (s, ev) => KartBuyut(true);
            parent.MouseLeave += (s, ev) => KartBuyut(false);

            foreach (Control child in parent.Controls)
            {
                HoverOlaylariniBagla(child);
            }
        }

        // Büyütme ve Kenarlık Değiştirme İşlemi
        private void KartBuyut(bool uzerindeMi)
        {
            if (isHovered == uzerindeMi) return; // Titremeyi önle
            isHovered = uzerindeMi;

            if (uzerindeMi)
            {
                // Hover: Boyutu 8 piksel artır, konumu 4 piksel sola/yukarı kaydır (merkezden büyüme)
                pnlAfis.BorderColor = ColorTranslator.FromHtml("#CDAA7D");
                pnlAfis.BorderThickness = 2;
                pnlAfis.Size = new Size(orijinalBoyut.Width + 4, orijinalBoyut.Height + 4);
                pnlAfis.Location = new Point(orijinalKonum.X +1, orijinalKonum.Y + 1);
            }
            else
            {
                // Normal: Orijinal boyut ve konuma dön
                pnlAfis.BorderColor = ColorTranslator.FromHtml("#4D3D30");
                pnlAfis.BorderThickness = 1;
                pnlAfis.Size = orijinalBoyut;
                pnlAfis.Location = orijinalKonum;
            }
        }




        public void ResmiYuvarlat(PictureBox pic, int radius)
        {

            if (pic.Width == 0 || pic.Height == 0) return; // Boyut 0 ise hata vermesin

            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddArc(0, 0, radius, radius, 180, 90);
            gp.AddArc(pic.Width - radius, 0, radius, radius, 270, 90);
            gp.AddArc(pic.Width - radius, pic.Height - radius, radius, radius, 0, 90);
            gp.AddArc(0, pic.Height - radius, radius, radius, 90, 90);
            gp.CloseFigure();
            pic.Region = new Region(gp);
        }


        private void pnlAfis_Paint(object sender, PaintEventArgs e)
        {
        


        }

        private void pcbKahveResim_Click(object sender, EventArgs e)
        {

        }

        private void btnSepeteEkle_Click(object sender, EventArgs e)
        {

        }
    }
}
