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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGoster_Click(object sender, EventArgs e)
        {
            txtParola.UseSystemPasswordChar= !txtParola.UseSystemPasswordChar;
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            Entities db = new Entities();


            //try
            //{
                //var user = db.Kullanici.FirstOrDefault(x=> x.KullaniciAdi==txtKullaniciAdi.Text && x.Parola==txtParola.Text);
                //if (user!=null)
                //{
                //    if (user.Durum==true)
                //    {
                //        Program.kullanici = user;
                //        Liste frm= new Liste();
                //        frm.Show();
                //        this.Hide();
                //    }
                //    else
                //    {
                //        MessageBox.Show("Kullanıcı Aktif Değil");
                //    }
                //}
                //else
                //{
                //    MessageBox.Show("Hatalı Giriş"); 
                //}
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.ToString());
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void txtKullaniciAdi_Validating(object sender, CancelEventArgs e)
        {
            var txt = (TextBox)sender;
            if (string.IsNullOrEmpty(txt.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txt,"Boş Bırakılamaz");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.Clear();
            }
        }
    }
}
