using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace rumahsakit_kel5
{
    public partial class Profile : Form
    {
        string connectionString = "server=127.0.0.1;uid=root;database=db_rumahsakit;pwd=;SslMode=none;";

        string userId = UserSession.id;
        string userNama = UserSession.name;
        string userPassword = UserSession.password;

        public Profile()
        {
            InitializeComponent();
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            // Isi textbox dengan data session
            txtName.Text = userNama;
            txtPw.Text = userPassword;

            AddForm();
        }

        private void AddForm()
        {
            btnUp.Enabled = (txtName.Text != "" && txtPw.Text != "");
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show(
                "Yakin ingin mengubah Profil?",
                "Konfirmasi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (r == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = GetConnection())
                    {
                        conn.Open();

                        string sql = "UPDATE users SET name = @name, password = @password WHERE id = @id";

                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@name", txtName.Text);
                            cmd.Parameters.AddWithValue("@password", txtPw.Text);
                            cmd.Parameters.AddWithValue("@id", userId);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Update Session
                    UserSession.name = txtName.Text;
                    UserSession.password = txtPw.Text;

                    MessageBox.Show("Profil berhasil diperbarui!", "Sukses");

                    // Kembali ke Home
                    Home h = new Home();
                    h.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Gagal");
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Close();
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
