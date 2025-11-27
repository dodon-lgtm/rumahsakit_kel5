using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace rumahsakit_kel5
{
    public partial class Home : Form
    {
        string userId = UserSession.id;
        string userNama = UserSession.name;
        string userEmail = UserSession.email;
        string userPassword = UserSession.password;

        string database = "server=127.0.0.1;uid=root;database=db_rumahsakit;pwd=;SslMode=none;";

        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            labelUser.Text = UserSession.name;

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            picLogout.SizeMode = PictureBoxSizeMode.StretchImage;
            picProfil.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(database);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Close();
        }

        private void picProfil_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM users WHERE id = @id AND name = @name";

            DataTable table = new DataTable();

            try
            {
                using (MySqlConnection koneksi = GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, koneksi))
                    {
                        cmd.Parameters.AddWithValue("@id", userId);
                        cmd.Parameters.AddWithValue("@name", userNama);

                        MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

                        koneksi.Open();
                        adp.Fill(table);
                    }
                }

                if (table.Rows.Count > 0)
                {
                    UserSession.id = table.Rows[0]["id"].ToString();
                    UserSession.password = table.Rows[0]["password"].ToString();
                    UserSession.name = table.Rows[0]["name"].ToString();

                    Profile f = new Profile();
                    f.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Data profil tidak ditemukan!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat mengambil profil: " + ex.Message);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Kamar k = new Kamar();
            k.Show();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Kamar k = new Kamar();
            k.Show();
            this.Close();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {
            Kamar k = new Kamar();
            k.Show();
            this.Close();
        }
    }
}
