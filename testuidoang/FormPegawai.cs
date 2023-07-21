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
    public partial class FormPegawai : Form
    {
        private string stringConnection = "data source=LAPTOP-C3M8HP9E\\KURANGTAU;" + "database=Perpustakaan; user ID=sa;Password=affancool23";
        private SqlConnection koneksi;
        public FormPegawai()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
        }
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

        private void dataGridView()
        {
            koneksi.Open();
            string query = "SELECT Id_Pegawai, Nama_Pegawai, Jenis_Kelamin, No_Telp FROM dbo.Pegawai";
            SqlDataAdapter da = new SqlDataAdapter(query, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnData_Click(object sender, EventArgs e)
        {
            dataGridView();
            btnData.Enabled = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormAdmin fa = new FormAdmin();
            fa.Show();
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih baris data yang akan dihapus", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = dataGridView1.SelectedRows[0].Cells["Id_Pegawai"].Value.ToString();

            string sql = "DELETE FROM Anggota WHERE Id_Pegawai = @Id_Pegawai";
            using (SqlCommand command = new SqlCommand(sql, koneksi))
            {
                command.Parameters.AddWithValue("@Id_Pegawai", id);

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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            string queryString = "Update dbo.Pegawai set Nama_Pegawai='" + txtNama.Text + "', Jenis_kelamin='" + txtjk.Text + "', No_Telp='" + txtTelp.Text + "'where Id_Pegawai='" + txtid.Text + "'";
            SqlCommand cmd = new SqlCommand(queryString, koneksi);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            koneksi.Close();
            MessageBox.Show("Update Data Berhasil");
            dataGridView();
            refreshform();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string idpegawai = txtid.Text;
            string nmpegawai = txtNama.Text;
            string jk = txtjk.Text;
            string notelp = txtTelp.Text;
            string Alamat = txtAlamat.Text;

            if (idpegawai == "")
            {
                MessageBox.Show("Masukkan Id Pegawai", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (nmpegawai == "")
            {
                MessageBox.Show("Masukkan Nama Pegawai", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (jk == "")
            {
                MessageBox.Show("Masukkan Jenis Kelamin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (notelp == "")
            {
                MessageBox.Show("Masukkan No Telepon", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                koneksi.Open();
                string str = "INSERT INTO Pegawai (Id_Pegawai, Nama_Pegawai, Jenis_Kelamin, No_Telp) VALUES (@Id_Pegawai, @Nama_Anggota, @Jenis_Kelamin, @No_Telp)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@Id_Anggota", idpegawai));
                cmd.Parameters.Add(new SqlParameter("@Nama_Pegawai", nmpegawai));
                cmd.Parameters.Add(new SqlParameter("@Jenis_Kelamin", jk));
                cmd.Parameters.Add(new SqlParameter("@No_Telp", notelp));
                cmd.ExecuteNonQuery();

                koneksi.Close();
                MessageBox.Show("Data Berhasil Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView();
            }
        }
    }
}
