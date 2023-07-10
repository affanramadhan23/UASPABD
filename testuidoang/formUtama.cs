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
    public partial class formUtama : Form
    {
        public formUtama()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            FormAdmin Admin = new FormAdmin();
            Admin.Show();
            this.Hide();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            FormAnggota Anggota = new FormAnggota(); Anggota.Show();
            this.Hide();
        }
    }
}
