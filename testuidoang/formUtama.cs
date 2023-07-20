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
            string username, password;
            username = Username.Text;
            password = Password.Text;
            SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-C3M8HP9E\KURANGTAU;Initial Catalog=Perpustakaan;Integrated Security=True");
            try
            {
                string strkoneksi = "data source = LAPTOP-C3M8HP9E\\KURANGTAU;initial catalog = Perpustakaan;user ID = {0}; password = {1}";
                conn = new SqlConnection(string.Format(strkoneksi, username, password));
                conn.Open();

                MainMenu MM = new MainMenu();
                MM.Show();
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Invalid Login");
                Username.Clear();
                Password.Clear();
                Username.Focus();
            }
            finally
            {
                conn.Close();
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            Username.Clear();
            Password.Clear();
            Username.Focus();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
