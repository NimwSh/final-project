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
    public partial class users : Form
    {
        public users()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nimas\OneDrive\Documents\ShoeShop.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "select * from UserTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            UserDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
            private void button1_Click(object sender, EventArgs e)
        {
            if (UnameTb.Text == "" || AddTb.Text == "" || PassTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show(" اطلاعات ناقص");
            }
            else
            {
                try
                {
                    Con.Open();
                    string quary = "insert into UserTbl values('" + UnameTb.Text + "', '" + PhoneTb.Text + "', '" + AddTb.Text + "', " + PassTb.Text + ")";
                    SqlCommand cmd = new SqlCommand(quary, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("کاربر با موفقیت ذخیره شد");
                    Con.Close();
                    populate();
                    reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }


            }
        }
        private void reset()
        {
            UnameTb.Text = "";
            PassTb.Text = "";
            PhoneTb.Text = "";
            AddTb.Text = "";

        }
        private void ResetBtn_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show(" اطلاعات ناقص");
            }
            else
            {
                try
                {
                    Con.Open();
                    string quary = "delete from UserTbl where Uid=" + key + ";";
                    SqlCommand cmd = new SqlCommand(quary, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("با موفقیت پاک شد");
                    Con.Close();
                    populate();
                    reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }


            }
        }
        int key = 0;
        private void UserDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UnameTb.Text = UserDGV.SelectedRows[0].Cells[1].Value.ToString();
            PhoneTb.Text = UserDGV.SelectedRows[0].Cells[2].Value.ToString();
            AddTb.Text = UserDGV.SelectedRows[0].Cells[3].Value.ToString();
            PassTb.Text = UserDGV.SelectedRows[0].Cells[4].Value.ToString();
            
            if (UnameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(UserDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (UnameTb.Text == "" || AddTb.Text == "" || PassTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show(" اطلاعات ناقص");
            }
            else
            {
                try
                {
                    Con.Open();
                    string quary = "update UserTbl set UName='" + UnameTb.Text + "',UPhone='" + PhoneTb.Text + "',UAdd='" + AddTb.Text + "',UPass='" + PassTb.Text + "where Uid=" + key + ";";
                    SqlCommand cmd = new SqlCommand(quary, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("کاربر با موفقیت ویرایش شد");
                    Con.Close();
                    populate();
                    reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }


            }
        }
    }
}
