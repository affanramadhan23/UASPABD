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
    }
}
