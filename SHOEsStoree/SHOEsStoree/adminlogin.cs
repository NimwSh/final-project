using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHOEsStoree
{
    public partial class adminlogin : Form
    {
        public adminlogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UPassTb.Text == "password")
            {
                Shoes obj = new Shoes();
                obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("رمز اشتباه است");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

            login obj = new login();
            obj.Show();
            this.Hide();
        }
    }
}
