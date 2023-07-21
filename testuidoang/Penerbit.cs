﻿using System;
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
    public partial class Penerbit : Form
    {
        private string stringConnection = "data source=LAPTOP-C3M8HP9E\\KURANGTAU;" + "database=Perpustakaan; user ID=sa;Password=affancool23";
        private SqlConnection koneksi;
        public Penerbit()
        {
            InitializeComponent();
        }
        private void refreshform()
        {
            txtidpnbt.Text = "";
            txtnmpnbt.Text = "";
            txtAlamat.Text = "";
            txtidpnbt.Enabled = false;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
            txtAlamat.Enabled = false;
            txtnmpnbt.Enabled = false;

        }
        private void dataGridView()
        {
            koneksi.Open();
            string query = "SELECT Id_Penerbit, Nama_Penerbit, Alamat FROM dbo.Penerbit";
            SqlDataAdapter da = new SqlDataAdapter(query, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }
        private void Penerbit_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormAdmin fa = new FormAdmin();
            fa.Show();
            this.Hide();
        }

        private void txtNamaPenerbit_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            string idpenerbit = txtidpnbt.Text;
            string nmpenerbit = txtnmpnbt.Text;
            string Alamat = txtAlamat.Text;

            if (idpenerbit == "")
            {
                MessageBox.Show("Masukkan Id Penerbit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (nmpenerbit == "")
            {
                MessageBox.Show("Masukkan Nama Anggota", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (Alamat == "")
            {
                MessageBox.Show("Masukkan Alamat", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                koneksi.Open();
                string str = "INSERT INTO Penerbit (Id_Penerbit, Nama_Penerbit, Alamat) VALUES (@Id_Penerbit, @Nama_Anggota, @Jenis_Kelamin, @No_Telp, @Alamat)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@Id_Anggota", idpenerbit));
                cmd.Parameters.Add(new SqlParameter("@Nama_Anggota", nmpenerbit));
                cmd.Parameters.Add(new SqlParameter("@Alamat", Alamat));
                cmd.ExecuteNonQuery();

                koneksi.Close();
                MessageBox.Show("Data Berhasil Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            string queryString = "Update dbo.Penerbit set Nama_Penerbit='" + txtnmpnbt.Text + "',Alamat='" + txtAlamat.Text + "'where Id_Penerbit='" + txtidpnbt.Text + "'";
            SqlCommand cmd = new SqlCommand(queryString, koneksi);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            koneksi.Close();
            MessageBox.Show("Update Data Berhasil");
            dataGridView();
            refreshform();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            refreshform();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih baris data yang akan dihapus", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = dataGridView1.SelectedRows[0].Cells["Id_Penerbit"].Value.ToString();

            string sql = "DELETE FROM Anggota WHERE Id_Penerbit = @Id_Penerbit";
            using (SqlCommand command = new SqlCommand(sql, koneksi))
            {
                command.Parameters.AddWithValue("@ID_Penerbit", id);

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
