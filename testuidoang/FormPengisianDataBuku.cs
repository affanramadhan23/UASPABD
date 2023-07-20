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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace testuidoang
{
    public partial class FormPengisianDataBuku : Form
    {
        private string stringConnection = "data source=LAPTOP-C3M8HP9E\\KURANGTAU;" + "database=Perpustakaan; user ID=sa;Password=affancool23";
        private SqlConnection koneksi;

        private void refreshform()
        {
            txtid.Text = "";
            txtjudul.Text = "";
            txtpengarang.Text = "";
            txttahun.Text = "";
            txtid.Enabled = false;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
            txtjudul.Enabled = false;
            txtpengarang.Enabled = false;
            txttahun.Enabled = false;

        }

        public FormPengisianDataBuku()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
        }

        private void FormPengisianDataBuku_Load(object sender, EventArgs e)
        {

        }
        private void dataGridView()
        {
            koneksi.Open();
            string query = "SELECT * form dbo.Buku";
            SqlDataAdapter da = new SqlDataAdapter(query, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAdmin fa = new FormAdmin();
            fa.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string idbuku = txtid.Text;
            string judulbuku = txtjudul.Text;
            string pengarang = txtpengarang.Text;
            string tahunterbit = txttahun.Text;

            koneksi.Open();
            string str = "INSERT INTO Buku (Id_Buku, Judul_Buku, Pengarang, Tahun_terbit, Id_Penerbit) VALUES (@Id_Buku, @Judul_Buku, @Pengarang, @Tahun_terbit, @Id_Penerbit)";
            SqlCommand cmd = new SqlCommand(str, koneksi);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@Id_Buku", idbuku));
            cmd.Parameters.Add(new SqlParameter("@Judul_Buku", judulbuku));
            cmd.Parameters.Add(new SqlParameter("@Pengarang", pengarang));
            cmd.Parameters.Add(new SqlParameter("@Tahun_terbit", tahunterbit));
            cmd.ExecuteNonQuery();

            koneksi.Close();
            MessageBox.Show("Data Berhasil Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            string queryString = "Update dbo.Buku set Judul_Buku='" + txtjudul.Text + "', Pengarang='" + txtpengarang.Text + "', Tahun_terbit='" + txttahun.Text +  "' where Id_Buku='" + txtid.Text + "'";
            SqlCommand cmd = new SqlCommand(queryString, koneksi);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            koneksi.Close();
            MessageBox.Show("Update Data Berhasil");
            dataGridView();
            refreshform();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin Ingin Menghapus Data : " + txtid.Text + " ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                koneksi.Open();
                string queryString = "Delete dbo.Buku where Id_Buku='" + txtid.Text + "'";
                SqlCommand cmd = new SqlCommand(queryString, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                koneksi.Close();
                MessageBox.Show("Hapus Data Berhasil");
                dataGridView();
                refreshform();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
