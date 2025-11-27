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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace rumahsakit_kel5
{
    public partial class Profile : Form
    {
        string sql = "server=127.0.0.1;uid=root;database=db_rumahsakit;pwd=;SslMode=none;";
        public MySqlConnection conn;
        public MySqlCommand cmd;

        public Profile()
        {
            InitializeComponent();
        }
        private void koneksi()
        {

            conn = new MySqlConnection(sql);
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        private void AddForm()
        {
            if (txtName.Text != "" &&
                txtPw.Text != "")
            {
                btnUp.Enabled = true;
            }
            else
            {
                btnUp.Enabled = false;
            }
        }

        private void Profile_Load(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Yakin ingin mengubah Profil?",
                "Komfirmasi",
                MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
                //koneksi();
                //conn.Open();
                //string sql = " INSERT users SET "
                //cmd = new MySqlCommand(sql, conn);
                //cmd.Parameters.AddWithValue("@kelas", comboBox1.Text);
                //cmd.ExecuteNonQuery();


                MessageBox.Show("save berhasil");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            AddForm();
        }

        private void txtPw_TextChanged(object sender, EventArgs e)
        {
            AddForm();
        }
    }
}
