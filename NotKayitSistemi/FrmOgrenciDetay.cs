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
    public partial class FrmOgrenciDetay : Form
    {
        public FrmOgrenciDetay()
        {
            InitializeComponent();
        }

        public string numara;

        SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=DbNotKayıt;Integrated Security=True");
        private void FrmOgrenciDetay_Load(object sender, EventArgs e)
        {
            lblNumara.Text = numara;
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Select * from TBLDERS where OGRNUMARA=@p1", baglanti);
            cmd.Parameters.AddWithValue("@p1", numara);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[2].ToString() + " " + dr[3].ToString();
                lblSınav1.Text = dr[4].ToString();
                lblSınav2.Text = dr[5].ToString();
                lblSınav3.Text = dr[6].ToString();
                lblOrtalama.Text = dr[7].ToString();
                if (dr[8].ToString() == "True")
                {
                    lblDurum.Text = "GEÇTİ";
                }

                if (dr[8].ToString() == "False")
                {
                    lblDurum.Text = "KALDI";
                }
            }
            baglanti.Close();
        }
    }
}
