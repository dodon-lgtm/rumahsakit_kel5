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
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace rumahsakit_kel5
{
    public partial class SignUp : Form
    {
        string database = "server=127.0.0.1;uid=root;database=db_rumahsakit;pwd=;SslMode=none;";
        public MySqlConnection koneksi;
        public MySqlCommand cmd;
        public MySqlDataAdapter adp;
        public MySqlCommand command;

        public SignUp()
        {
            InitializeComponent();
            koneksi = new MySqlConnection(database);
        }



        public void Konek()
        {
            if (koneksi.State == ConnectionState.Closed)
                koneksi.Open();
        }

        public void Disconek()
        {
            if (koneksi.State == ConnectionState.Open)
                koneksi.Close();
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
            if (txtName.Text != "" &&
                txtEmail.Text != "" &&
                txtPw.Text != "" &&
                txtConfirmPw.Text != "" &&
                checkBox1.Checked == true)
            {
                btnSu.Enabled = true;
            }
            else
            {
                btnSu.Enabled = false;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPw.Text != txtConfirmPw.Text)
                {
                    MessageBox.Show("Password Confirm tidak sesuai!");
                    return;
                }
                string query = "INSERT INTO users (name, email, password) " +
                               "VALUES (@name, @email, @password)";

                using (MySqlCommand cmd = new MySqlCommand(query, koneksi))
                {

                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@password", txtPw.Text);
                    

                    koneksi.Open();
                    cmd.ExecuteNonQuery();
                    koneksi.Close();
                }

                txtName.Text = "";
                txtConfirmPw.Text = "";
                txtEmail.Text = "";
                txtPw.Text = "";
                checkBox1.Checked = false;

                MessageBox.Show("Data berhasil disimpan!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan data: " + ex.Message);
            }


        
    }

        private void button2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            AddForm();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Login L = new Login();
            L.Show();

            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            AddForm();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            AddForm();
        }

        private void txtPw_TextChanged(object sender, EventArgs e)
        {
            AddForm();
        }

        private void txtConfirmPw_TextChanged(object sender, EventArgs e)
        {
            AddForm();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            error p = new error();
            p.Show();

            this.Hide();
        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            error r = new error();
            r.Show();

            this.Hide();
        }
    }
}
