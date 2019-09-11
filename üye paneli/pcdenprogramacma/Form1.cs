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
using System.Data.OleDb;
using System.Net;
using System.Net.Mail;

namespace pcdenprogramacma
{

    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=LAB7-4;Initial Catalog=uye;User ID=sa;Password=123456");



        public Form1()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            // System.Diagnostics.Process.Start(@"C:\Users\Xigmatek\Desktop\vpn");
        }
        private void bunifuMetroTextbox1_Enter(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox1.Text == "Kullanıcı Adı")
            {
                bunifuMetroTextbox1.Text = "";

            }

        }
        private void bunifuMetroTextbox1_Leave(object sender, EventArgs e)
        {
        }

        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox1_Click(object sender, EventArgs e)
        {
            bunifuMetroTextbox1.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            bunifuMetroTextbox1.Text = "Kullanıcı Adı";

            bunifuMetroTextbox1.ForeColor = System.Drawing.Color.FromArgb(127, 148, 165);
        }

        private void bunifuMetroTextbox1_Leave_1(object sender, EventArgs e)
        {

            if (bunifuMetroTextbox1.Text == "")
            {
                bunifuMetroTextbox1.Text = "Kullanıcı Adı";

            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            bunifuMetroTextbox1.Text = "";
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            bunifuMetroTextbox1.Text = "";
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            bunifuMetroTextbox1.Text = "";
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
           
            SqlCommand komut = new SqlCommand("Select * FROM uyegirisi WHERE kullaniciadi='" + bunifuMetroTextbox1.Text.ToString() + "'", conn);
        conn.Open();
            SqlDataReader okuyucu = komut.ExecuteReader();
           while (okuyucu.Read())
            {
                if (bunifuMetroTextbox1.Text.ToString() == okuyucu["kullaniciadi"].ToString())
                {
                    if (bunifuMetroTextbox2.Text.ToString() == okuyucu["sifre"].ToString())
                    {
                       if (okuyucu["yetki"].ToString() == "Admin")
                        {
                            kullanicipanel admin = new kullanicipanel();
                            admin.Show();
                        }
                      
                            
                        
                       
                    }
                    else
                    {
                        MessageBox.Show("Şifre Yanlış");
                    }
                }
            }
        }

        private void bunifuMetroTextbox2_Enter(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox2.Text == "Sifre")
            {
                bunifuMetroTextbox2.Text = "";

            }
        }
        private void bunifuMetroTextbox2_Leave(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox2.Text == "")
            {
                bunifuMetroTextbox2.Text = "Sifre";

            }
        }

        private void bunifuMetroTextbox2_Click(object sender, EventArgs e)
        {
            bunifuMetroTextbox2.Text = "";
        }

        private void bunifuMetroTextbox2_Leave_1(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox2.Text == "")
            {
                bunifuMetroTextbox2.Text = "Sifre";

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            gizlisoru gizli = new gizlisoru();
            gizli.Show();
            this.Hide();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
       
    }
}
