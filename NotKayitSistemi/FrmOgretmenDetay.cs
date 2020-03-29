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

namespace NotKayitSistemi
{
    public partial class FrmOgretmenDetay : Form
    {
        public FrmOgretmenDetay()
        {
            InitializeComponent();
            FrmOgrenciDetay frm = new FrmOgrenciDetay();

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-427L4HT;Initial Catalog=DbNotKayıt;Integrated Security=True");
        private void FrmOgretmenDetay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbNotKayıtDataSet.TBLDERS' table. You can move, or remove it, as needed.
            this.tBLDERSTableAdapter.Fill(this.dbNotKayıtDataSet.TBLDERS);
            SınıfDurumu();
            OgrenciSayisi();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("insert into TBLDERS (OGRNUMARA,OGRAD,OGRSOYAD) values(@p1,@p2,@p3)",baglanti);
            cmd.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@p2", txtAd.Text.ToUpper());
            cmd.Parameters.AddWithValue("@p3", txtSoyad.Text.ToUpper());
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Sisteme Eklendi");
            this.tBLDERSTableAdapter.Fill(this.dbNotKayıtDataSet.TBLDERS);
            OgrenciSayisi();
        }

        private void OgrenciSayisi()
        {
            int ogrencisayisi = dataGridView1.Rows.Count;
            lblOgrenciSayisi.Text = ogrencisayisi.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedRows[0].Index;


            maskedTextBox1.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtSınav1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtSınav2.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtSınav3.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int secilen = dataGridView1.SelectedRows[0].Index;
            double s1, s2, s3, ortalama;
            string durum;
            s1 = Convert.ToDouble(txtSınav1.Text);
            s2 = Convert.ToDouble(txtSınav2.Text);
            s3 = Convert.ToDouble(txtSınav3.Text);

            ortalama = (s1 + s2 + s3) / 3;
            lblOrtalama.Text = ortalama.ToString();

            if (ortalama >=50)
            {
                durum = "true";
            }
            else
            {
                durum = "false";
            }
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("update TBLDERS set OGRS1 =@p1,OGRS2= @p2,OGRS3= @p3, ORTALAMA= @p4,DURUM=@p5 where OGRNUMARA= @p6;",baglanti);
            cmd.Parameters.AddWithValue("@p1", txtSınav1.Text);
            cmd.Parameters.AddWithValue("@p2", txtSınav2.Text);
            cmd.Parameters.AddWithValue("@p3", txtSınav3.Text);
            cmd.Parameters.AddWithValue("@p4", decimal.Parse(lblOrtalama.Text));
            cmd.Parameters.AddWithValue("@p5", durum);
            cmd.Parameters.AddWithValue("@p6", maskedTextBox1.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Notları Güncellendi");
            this.tBLDERSTableAdapter.Fill(this.dbNotKayıtDataSet.TBLDERS);
            SınıfDurumu();
        }

        private void SınıfDurumu()
        {
            int toplam = dataGridView1.Rows.Count;
            int kalanSayısı = 0;
            int gecenSayisi = 0;
            for (int i = 0; i < toplam; i++)
            {
                if (dataGridView1.Rows[i].Cells[8].Value.ToString()=="False")
                {
                    kalanSayısı++;
                    
                }
                else
                {
                    gecenSayisi++;
                }
            }
            lblGecenSayisi.Text = gecenSayisi.ToString();
            lblKalanSayisi.Text = kalanSayısı.ToString();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
