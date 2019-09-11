using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;

namespace pcdenprogramacma
{
    public partial class gizlisoru : Form
    {
        public gizlisoru()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=LAB7-4;Initial Catalog=uye;User ID=sa;Password=123456");

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {        
            conn.Open();
            SqlCommand komut = new SqlCommand("Select * FROM gizlisoru WHERE kullaniciadi='" + textBox1.Text.ToString() + "'AND Cevap='" + textBox2.Text.ToString() + "'", conn);

            SqlDataReader okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                if (textBox1.Text.ToString() == okuyucu["kullaniciadi"].ToString())
                {
                    if (textBox2.Text.ToString() == okuyucu["Cevap"].ToString())
                    {
                        MessageBox.Show("Şifreniz : "+okuyucu["sifre"].ToString());
                    }



                    else
                    {
                        MessageBox.Show("Şifre Yanlış");
                    }

                }

            }
        }

        private void gizlisoru_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("SELECT * FROM gizlisoru",conn);
            conn.Open();
            SqlDataReader dr;
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["Soru"].ToString());

            }
            conn.Close();
        }
    }
}
