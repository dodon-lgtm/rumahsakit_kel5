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

namespace rumahsakit_kel5
{
    public partial class periksaKesehatan : Form
    {
        string database = "server=127.0.0.1;uid=root;database=db_rumahsakit;pwd=;SslMode=none;";
        public MySqlConnection koneksi;
        public MySqlCommand cmd;
        public MySqlDataAdapter adp;
        public MySqlCommand command;
        public periksaKesehatan()
        {
            InitializeComponent();
            koneksi = new MySqlConnection(database);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void periksaKesehatan_Load(object sender, EventArgs e)
        {
            
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            
            var picked = clbGejala.CheckedItems.Cast<string>().ToList();
            string penyakit = "";
            string obat = "";

           
            if (picked.Contains("Demam") && picked.Contains("Pusing"))
            {
                penyakit = "Demam + Pusing";
                obat = " Paracetamol";
            }
            else if (picked.Contains("Batuk") && picked.Contains("Pilek"))
            {
                penyakit = "Batuk + Pilek";
                obat = "Antihistamin";
            }
            else if (picked.Contains("Demam") && picked.Contains("Batuk"))
            {
                penyakit = "Demam + Batuk";
                    obat = "OBH";
            }
            else
            {
                penyakit = "Tidak ada gejala";
            }

            string query = "INSERT INTO hasilPeriksas (users_name, penyakit, users_id) VALUES (@uname, @penyakit, @uid)";

            try
            {
                koneksi.Open();
                MySqlCommand cmd = new MySqlCommand(query, koneksi);

                cmd.Parameters.AddWithValue("@uname", UserSession.name);
                cmd.Parameters.AddWithValue("@penyakit", penyakit);
                cmd.Parameters.AddWithValue("@uid", UserSession.id);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                koneksi.Close();
            }

            // hasil
            richTextBox1.Text =
                "===== HASIL PEMERIKSAAN =====\n" +
                "Nama Pasien : " + UserSession.name + "\n" +              
                "\n" +
                "Gejala yang dipilih:\n" +
                string.Join(", ", picked) + "\n\n" +
                "Diagnosa :" +
                penyakit + "Lama Sakit :" + "\nObat :" + obat + "\n\n" +
                "Mohon untuk foto hasilperiksa ini !" +"\n"+
                "==============================";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();this.Close();



        }
    }
}
