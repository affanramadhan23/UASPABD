using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace testuidoang
{
    public partial class FormAnggota : Form
    {
        private string stringConnection = "data source=LAPTOP-C3M8HP9E\\KURANGTAU;" + "database=Perpustakaan`; user ID=sa;Password=affancool23";
        private SqlConnection koneksi;

        private void refreshform()
        {
            txtid.Text = "";
            txtNama.Text = "";
            txtjk.Text = "";
            txtTelp.Text = "";
            txtAlamat.Text = "";
            txtid.Enabled = false;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
            txtAlamat.Enabled = false;
            txtjk.Enabled = false;
            txtNama.Enabled = false;
            txtTelp.Enabled = false;

        }


        public FormAnggota()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);  
        }

        private void FormAnggota_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string idanggota = txtid.Text;
            string nmanggota = txtNama.Text;
            string jk = txtjk.Text;
            string notelp = txtTelp.Text;
            string Alamat = txtAlamat.Text;

            if (idanggota == "")
            {
                MessageBox.Show("Masukkan Id Anggota", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (nmanggota == "")
            {
                MessageBox.Show("Masukkan Nama Anggota", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (jk == "")
            {
                MessageBox.Show("Masukkan Jenis Kelamin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (notelp == "")
            {
                MessageBox.Show("Masukkan No Telepon", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (Alamat == "")
            {
                MessageBox.Show("Masukkan Alamat", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                koneksi.Open();
                string str = "INSERT INTO Suplier (Id_Anggota, Nama_Anggota, Jenis_Kelamin, No_Telp, Alamat) VALUES (@Id_Anggota, @Nama_Anggota, @Jenis_Kelamin, @No_Telp, @Alamat)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@Id_Anggota", idanggota));
                cmd.Parameters.Add(new SqlParameter("@Nama_Anggota", nmanggota));
                cmd.Parameters.Add(new SqlParameter("@Jenis_Kelamin", jk));
                cmd.Parameters.Add(new SqlParameter("@No_Telp", notelp));
                cmd.Parameters.Add(new SqlParameter("@Alamat", Alamat));
                cmd.ExecuteNonQuery();

                koneksi.Close();
                MessageBox.Show("Data Berhasil Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshform();
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            formUtama fu = new formUtama();
            fu.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            refreshform();
        }
    }
}
