using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelefonRehberi
{
    public partial class Duzenle : Form
    {
        Entities db = null;
        int _kisiId;
        public Duzenle(int kisiId)
        {
            _kisiId = kisiId;
            db= new Entities();
            InitializeComponent();

            var kisi =db.Kisi.Find(kisiId);
            txtAd.Text = kisi.Ad;
            txtSoyad.Text = kisi.Soyad;
            txtTelefon.Text = kisi.Telefon;
            txtEmail.Text = kisi.Email;
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            db= new Entities();
            var dKisi = db.Kisi.Find(_kisiId);
            if (dKisi!=null)
            {
                dKisi.Ad = txtAd.Text;
                dKisi.Soyad = txtSoyad.Text;
                dKisi.Telefon = txtTelefon.Text;
                dKisi.Email = txtEmail.Text;

                try
                {
                    db.SaveChanges();
                    MessageBox.Show("Güncelleme işlemi başarılı bir şekilde gerçekleşti");
                    this.Close();
                }
                catch (Exception)
                {

                    MessageBox.Show("Güncelleme işlemi sırasında bir hata meydana geldi");
                }
            }
        }


    }
}
