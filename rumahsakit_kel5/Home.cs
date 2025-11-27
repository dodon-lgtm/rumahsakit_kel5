using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rumahsakit_kel5
{
    public partial class Home : Form
    {
        string userId = UserSession.id;
        string userNama = UserSession.name;
        string userEmail = UserSession.email;
        public Home()
        {
            InitializeComponent();            
        }

        private void labelUser_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Login L = new Login();
            L.Show();

            this.Close();
        }

        private void picProfil_Click(object sender, EventArgs e)
        {
            Profile f = new Profile();
            f.Show();
            this.Close();
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
