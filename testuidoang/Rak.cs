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
    public partial class Rak : Form
    {
        private string stringConnection = "data source=LAPTOP-C3M8HP9E\\KURANGTAU;" + "database=Perpustakaan; user ID=sa;Password=affancool23";
        private SqlConnection koneksi;
        public Rak()
        {
            InitializeComponent();
        }
        private void refreshform()
        {
            txtIdRak.Text = "";
            txtNamaRak.Text = "";
            txtLocRak.Text = "";
            txtIdBuku.Text = "";
            txtIdRak.Enabled = false;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
            txtIdRak.Enabled = false;
            txtNamaRak.Enabled = false;
        }
        private void dataGridView()
        {
            koneksi.Open();
            string query = "SELECT Id_Rak, Nama_Rak, Lokasi_Rak, Id_Buku, Alamat FROM dbo.Rak";
            SqlDataAdapter da = new SqlDataAdapter(query, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string idrak = txtIdRak.Text;
            string nmrak = txtNamaRak.Text;
            string lr = txtLocRak.Text;
            string idbuku = txtIdBuku.Text;

            if (idrak == "")
            {
                MessageBox.Show("Masukkan Id Rak", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (nmrak == "")
            {
                MessageBox.Show("Masukkan Nama Rak", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (lr == "")
            {
                MessageBox.Show("Masukkan Lokasi Rak", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (idbuku == "")
            {
                MessageBox.Show("Masukkan Id Buku", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                koneksi.Open();
                string str = "INSERT INTO Rak (Id_Rak, Nama_Rak, Lokasi Rak, Id Buku) VALUES (@Id_Rak, @Nama_Rak, @Lokasi_Rak, @Id_Buku)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@Id_Rak", idrak));
                cmd.Parameters.Add(new SqlParameter("@Nama_Rak", nmrak));
                cmd.Parameters.Add(new SqlParameter("@Lokasi_rak", lr));
                cmd.Parameters.Add(new SqlParameter("@Id_Buku", idbuku));
                cmd.ExecuteNonQuery();

                koneksi.Close();
                MessageBox.Show("Data Berhasil Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            refreshform();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            string queryString = "Update dbo.Rak set Nama_Rak='" + txtNamaRak.Text + "', Lokasi_Rak='" + txtLocRak.Text + "', Id_Buku'" + txtIdBuku.Text + "'where Id_Rak='" + txtIdRak.Text + "'";
            SqlCommand cmd = new SqlCommand(queryString, koneksi);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            koneksi.Close();
            MessageBox.Show("Update Data Berhasil");
            dataGridView();
            refreshform();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih baris data yang akan dihapus", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = dataGridView1.SelectedRows[0].Cells["Id_Rak"].Value.ToString();

            string sql = "DELETE FROM Anggota WHERE Id_Rak = @Id_Rak";
            using (SqlCommand command = new SqlCommand(sql, koneksi))
            {
                command.Parameters.AddWithValue("@ID_Rak", id);

                try
                {
                    koneksi.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data berhasil dihapus", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        koneksi.Close();
                        refreshform();
                        dataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Data tidak ditemukan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            dataGridView();
            btnOpen.Enabled = false;
        }
    }
}
