using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;

namespace pcdenprogramacma
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=LAB7-4;Initial Catalog=uye;User ID=sa;Password=123456");


        private void button1_Click(object sender, EventArgs e)
        {                        
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            timer1.Start();                                                   
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("SELECT * FROM Sorular", conn);
            conn.Open();
            SqlDataReader dr;
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["Soru"].ToString());

            }
            conn.Close();

            this.KeyPreview = true;
            this.KeyDown += Form2_KeyDown;
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();
            }
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
            if (bunifuMetroTextbox1.Text == "")
            {
                bunifuMetroTextbox1.Text = "Kullanıcı Adı";

            }
        }

        private void bunifuMetroTextbox2_Enter(object sender, EventArgs e)
        {
            
            if (txtgizle.Text == "Şifre")
            {
                txtgizle.Text = "";

            }
        }

        private void bunifuMetroTextbox2_Leave(object sender, EventArgs e)
        {
            if (txtgizle.Text == "")
            {
                txtgizle.Text = "Şifre";

            }
        }

        private void bunifuMetroTextbox3_Enter(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox3.Text == "Mail Adresiniz")
            {
                bunifuMetroTextbox3.Text = "";

            }
        }

        private void bunifuMetroTextbox3_Leave(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox3.Text == "")
            {
                bunifuMetroTextbox3.Text = "Mail Adresiniz";

            }
        }

        private void bunifuMetroTextbox4_Enter(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox4.Text == "Cevabınız")
            {
                bunifuMetroTextbox4.Text = "";

            }
        }

        private void bunifuMetroTextbox4_Leave(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox4.Text == "")
            {
                bunifuMetroTextbox4.Text = "Cevabınız";

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            bunifuCircleProgressbar1.Value++;
            if (bunifuCircleProgressbar1.Value == 100)
            {

                try
                {
                    timer1.Stop();
                    conn.Open();
                    string komut = "INSERT INTO uyegirisi(kullaniciadi,sifre,soru,mail,cevap) VALUES('" + bunifuMetroTextbox1.Text.ToString() + "','" + txtgizle.Text.ToString() + "','" + comboBox1.SelectedItem.ToString() + "','" + bunifuMetroTextbox3.Text.ToString() + "','" + bunifuMetroTextbox4.Text.ToString() + "')";
                    SqlCommand da = new SqlCommand(komut, conn);
                    da.ExecuteNonQuery();
                    Form1 f1 = new Form1();
                    f1.Show();
                    this.Hide();
                }
                catch
                {
                    MessageBox.Show("Hata");
                }
            }
        }

        private void bunifuiOSSwitch1_OnValueChange(object sender, EventArgs e)
        {
            if (bunifuiOSSwitch1.Value == true)
            {
                txtgizle.isPassword = false;
            }
            else
            {
                txtgizle.isPassword = true;
            }
               
        }
        private void bunifuiOSSwitch1_OnValueChange_1(object sender, EventArgs e)
        {

           

        }

        private void bunifuiOSSwitch1_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuiOSSwitch1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
