using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testuidoang
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            formUtama fu = new formUtama();
            fu.Show();
            this.Hide();
        }

        private void btnBuku_Click(object sender, EventArgs e)
        {
            FormPengisianDataBuku fp = new FormPengisianDataBuku();
            fp.Show();
            this.Hide();
        }

        private void btnAnggota_Click(object sender, EventArgs e)
        {
            AdmnAnggota AA = new AdmnAnggota();
            AA.Show();
            this.Hide();
        }

        private void btnPegawai_Click(object sender, EventArgs e)
        {
            FormPegawai fpe = new FormPegawai();
            fpe.Show();
            this.Hide();
        }
    }
}
