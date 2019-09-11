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

namespace pcdenprogramacma
{
    public partial class kullanicipanel : Form
    {
        public kullanicipanel()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=LAB7-4;Initial Catalog=uye;User ID=sa;Password=123456");

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            panel1.Visible = true;
           
            

        }

        private void gösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            conn.Open();
            SqlDataAdapter cmd = new SqlDataAdapter("SELECT * FROM uyegirisi",conn);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
             
            
            
        }

        private void kullanicipanel_Load(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("SELECT kullaniciadi FROM uyegirisi", conn);
            conn.Open();
            SqlDataReader dr2;
            dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                silToolStripMenuItem.DropDownItems.Add(dr2["kullaniciadi"].ToString());
                
            }

            dr2.Close();
            SqlCommand benfero = new SqlCommand("SELECT * from Sorular", conn);
            SqlDataReader dr;
            dr = benfero.ExecuteReader();
            while (dr.Read())
            {               
                    comboBox1.Items.Add(dr["Soru"].ToString());  
                              
            }
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string komut = "INSERT INTO uyegirisi(kullaniciadi,sifre,soru,mail,cevap) VALUES('" + bunifuMetroTextbox1.Text.ToString() + "','" + bunifuMetroTextbox2.Text.ToString() + "','" + comboBox1.SelectedItem.ToString() + "','" + bunifuMetroTextbox4.Text.ToString() + "','" + bunifuMetroTextbox5.Text.ToString() + "')";
            SqlCommand cmd = new SqlCommand(komut,conn);
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
                             
        }

        private void asdasdasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
         
           
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.Open();
           if (e.KeyCode == Keys.NumPad0)
            {
                string komut = "DELETE  from uyegirisi WHERE kullaniciadi='" + toolStripTextBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(komut, conn);
                cmd.ExecuteNonQuery();                
            }
            conn.Close();
        }

        private void üyelerToolStripMenuItem_Click(object sender, EventArgs e)
        {
          

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
