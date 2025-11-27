using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

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

        private void AddForm()
        {
            if (txtEmail.Text != "" &&
                txtPw.Text != "")
            {
                btnLogin.Enabled = true;
            }
            else
            {
                btnLogin.Enabled = false;
            }
        }
        private void Login_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            SignUp f = new SignUp();
            f.Show();

            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM users WHERE email = '"
               + txtEmail.Text + "' AND password = '"
               + txtPw.Text + "'";

            MySqlDataAdapter adp = new MySqlDataAdapter(query, koneksi);

            DataTable table = new DataTable();
            adp.Fill(table);

            if (table.Rows.Count > 0)
            {
                UserSession.id = table.Rows[0]["id"].ToString();
                UserSession.email = table.Rows[0]["email"].ToString();
                UserSession.name = table.Rows[0]["name"].ToString();
                UserSession.password = table.Rows[0]["password"].ToString();

                Home fr = new Home();
                fr.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Email atau password salah");
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            AddForm();
        }

        private void txtPw_TextChanged(object sender, EventArgs e)
        {
            AddForm();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void labelLogin_Click(object sender, EventArgs e)
        {
            SignUp f1 = new SignUp();
            f1.Show();

            this.Close();
        }
    }
}
