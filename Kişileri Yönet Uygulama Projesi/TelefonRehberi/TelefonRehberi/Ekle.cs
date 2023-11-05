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
    public partial class Ekle : Form
    {
        public Ekle()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Kisi kisi = new Kisi();
            kisi.Ad=txtAd.Text;
            kisi.Soyad=txtSoyad.Text;
            kisi.Telefon = txtTelefon.Text;
            kisi.Email= txtEmail.Text;
            kisi.KullaniciID = Program.kullanici.Id;

            try
            {
                Entities db = new Entities();
                db.Kisi.Add(kisi);
                db.SaveChanges();
                this.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Kayıt İşlemi SIrasında bir hata meydana geldi.Lütfen bilgilerin doğruluğunu kontrol edip tekrar deneyiniz", "Hata !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



          

        }

        private void Ekle_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }
    }
}
