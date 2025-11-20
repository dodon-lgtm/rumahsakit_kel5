using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace rumahsakit_kel5
{
    public partial class Login : Form
    {

        string database = "server=127.0.0.1;uid=root;database=db_rumahsakit;pwd=;SslMode=none;";
        public MySqlConnection koneksi;
        public MySqlCommand cmd;
        public MySqlDataAdapter adp;
        public MySqlCommand command;
        public Login()
        {
            InitializeComponent();
            koneksi = new MySqlConnection(database);
        }


        public void fQuery(string sQuery)
        {
            try
            {
                koneksi.Open();
                cmd = new MySqlCommand(sQuery, koneksi);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                koneksi.Close();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {               
                string query = "SELECT * FROM users WHERE email = '" 
                + txtEmail.Text + "' AND password = '" 
                + txtPw.Text + "'";

            MySqlDataAdapter adp = new MySqlDataAdapter(query, koneksi);
            
            DataTable table = new DataTable();
            adp.Fill(table);

            if(table.Rows.Count > 0)
            {
                MessageBox.Show("Login Berhasil");
            }
            else
            {
                MessageBox.Show("Email atau password salah");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();

            this.Close();
        }
    }
}
