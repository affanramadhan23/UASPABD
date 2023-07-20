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
    public partial class AdmnAnggota : Form
    {
        private string stringConnection = "data source=LAPTOP-C3M8HP9E\\KURANGTAU;" + "database=Perpustakaan; user ID=sa;Password=affancool23";
        private SqlConnection koneksi;
        public AdmnAnggota()
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
            string query = "SELECT Id_Anggota, Nama_Anggota, Jenis_Kelamin, No_Telp, Alamat FROM dbo.Anggota";
            SqlDataAdapter da = new SqlDataAdapter(query, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            refreshform();
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
                string str = "INSERT INTO Anggota (Id_Anggota, Nama_Anggota, Jenis_Kelamin, No_Telp, Alamat) VALUES (@Id_Anggota, @Nama_Anggota, @Jenis_Kelamin, @No_Telp, @Alamat)";
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
                dataGridView();
            }
        }

        private void txtAlamat_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtTelp_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtNama_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtjk_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormAdmin fa = new FormAdmin();
            fa.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            string queryString = "Update dbo.Anggota set Nama_Anggota='" + txtNama.Text + "', Jenis_kelamin='" + txtjk.Text + "', No_Telp='" + txtTelp.Text + "',Alamat='" + txtAlamat.Text + "'where Id_Anggota='" + txtid.Text + "'";
            SqlCommand cmd = new SqlCommand(queryString, koneksi);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            koneksi.Close();
            MessageBox.Show("Update Data Berhasil");
            dataGridView();
            refreshform();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih baris data yang akan dihapus", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = dataGridView1.SelectedRows[0].Cells["Id_Anggota"].Value.ToString();

            string sql = "DELETE FROM Anggota WHERE Id_Anggota = @Id_Anggota";
            using (SqlCommand command = new SqlCommand(sql, koneksi))
            {
                command.Parameters.AddWithValue("@ID_Anggota", id);

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

        private void AdmnAnggota_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'perpustakaanDataSet.Anggota' table. You can move, or remove it, as needed.
            this.anggotaTableAdapter.Fill(this.perpustakaanDataSet.Anggota);

        }
    }
}
