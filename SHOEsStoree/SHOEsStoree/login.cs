using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHOEsStoree
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nimas\OneDrive\Documents\ShoeShop.mdf;Integrated Security=True;Connect Timeout=30");
        private static string UserName = "";
        private void button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from UserTbl where UName='" + UnameTB.Text + "' and UPass='" + UPassTb.Text + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows[0][0].ToString()=="1")
            {
                UserName = UnameTB.Text;
                users obj = new users();
                obj.Show();
                this.Hide();
                Con.Close();
            }
            else
            {
                MessageBox.Show("نام کاربری یا رمز عبور اشتباه است");
            }
            Con.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            adminlogin obj = new adminlogin();
            obj.Show();
            this.Hide();
        }
    }
}
