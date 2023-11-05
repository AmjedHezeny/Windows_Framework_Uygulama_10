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
    public partial class Liste : Form
    {
        int seciliId = 0;
        string ad, soyad;

        private void Liste_Activated(object sender, EventArgs e)
        {
            KisileriListele();
        }

        private void KisileriListele()
        {
            //Entities db = new Entities();
            //var kisiler = db.Kisi.Where(x=> x.KullaniciID==Program.kullanici.Id).ToList();
            //dataGridView1.DataSource = kisiler;

        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            var dialog = MessageBox.Show("Oturumunuzu kapatmak istediğinize emin misiniz?","Uyarı !",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();
            }
            else
            {
                return;
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Ekle ekle = new Ekle();
            ekle.ShowDialog();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            Duzenle dzn= new Duzenle(seciliId);
            dzn.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int seciliIndex = e.RowIndex;
            string deger = dataGridView1.Rows[seciliIndex].Cells["Id"].Value.ToString();
            ad = dataGridView1.Rows[seciliIndex].Cells["Ad"].Value.ToString();
            soyad = dataGridView1.Rows[seciliIndex].Cells["Soyad"].Value.ToString();
            seciliId = int.Parse(deger);

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show(ad+ " "+soyad+" Kişisini Silmek İstedğinize Emin Misiniz ?","Uyarı",MessageBoxButtons.YesNo);
            if (dlg==DialogResult.Yes)
            {
                Entities db=new Entities();
                var kisi = db.Kisi.Find(seciliId);
                if (kisi!=null)
                {
                    try
                    {
                        db.Kisi.Remove(kisi);
                        db.SaveChanges();
                        MessageBox.Show(ad + " " + soyad + " Kişisi Listenizden Silindi");

                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Silme işlemi sırasında bir hata meydana geldi\nLütfen daha sonra tekrar deneyiniz");
                    }
                }
            }
        }

        public Liste()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

     
    }
}
