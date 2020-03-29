using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotKayitSistemi
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            FrmOgrenciDetay frm = new FrmOgrenciDetay();
            frm.numara = txtNo.Text;
            frm.Show();
        }

        private void txtNo_TextChanged(object sender, EventArgs e)
        {
            if (txtNo.Text == "1111")
            {
                FrmOgretmenDetay frm = new FrmOgretmenDetay();
                frm.Show();
            }
        }
    }
}
