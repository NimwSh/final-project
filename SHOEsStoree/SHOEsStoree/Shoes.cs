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

namespace SHOEsStoree
{
    public partial class Shoes : Form
    {
        public Shoes()
        {
            InitializeComponent();
            populate();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nimas\OneDrive\Documents\ShoeShop.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "select * from ShoeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ShoeDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void filter()
        {
            Con.Open();
            string query = "select * from ShoeTbl where SSize= '"+SCbserachCb.SelectedItem.ToString()+"' ";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ShoeDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(STitleTB.Text =="" || SColTB.Text == "" || QtyTb.Text == "" || PriceTb.Text == "" || SSCb.SelectedIndex == -1)
            {
                MessageBox.Show(" اطلاعات ناقص");
            }
            else
            {
                try
                {
                    Con.Open();
                    string quary = "insert into ShoeTbl values('" + STitleTB.Text + "', '" + SColTB.Text + "', '" + SSCb.SelectedItem.ToString() + "', " + QtyTb.Text + "," + PriceTb.Text + ")";
                    SqlCommand cmd = new SqlCommand(quary, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("با موفقیت ذخیره شد");
                    Con.Close();
                    populate();
                    reset();
                }catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
             

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (STitleTB.Text == "" || SColTB.Text == "" || QtyTb.Text == "" || PriceTb.Text == "" || SSCb.SelectedIndex == -1)
            {
                MessageBox.Show(" اطلاعات ناقص");
            }
            else
            {
                try
                {
                    Con.Open();
                    string quary = "update ShoeTbl set STitle='"+STitleTB.Text+"',SColor='"+SColTB.Text+"',SSize='"+SSCb.SelectedItem.ToString()+"',SQty='"+QtyTb.Text+",Sprice="+PriceTb.Text+"where Sid="+key+";";
                    SqlCommand cmd = new SqlCommand(quary, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("با موفقیت ویرایش شد");
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

        private void button3_Click(object sender, EventArgs e)
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
                    string quary = "delete from ShoeTbl where Sid=" + key + ";";
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
        private void reset()
        {
            STitleTB.Text = "";
            SColTB.Text = "";
            SSCb.SelectedIndex = -1;
            PriceTb.Text = "";
            QtyTb.Text = "";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SCbserachCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            filter();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            populate();
            SSCb.SelectedIndex = -1;
        }
        int key = 0;
        private void ShoeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            STitleTB.Text = ShoeDGV.SelectedRows[0].Cells[1].Value.ToString();
            SColTB.Text = ShoeDGV.SelectedRows[0].Cells[2].Value.ToString();
            SSCb.SelectedItem = ShoeDGV.SelectedRows[0].Cells[3].Value.ToString();
            QtyTb.Text = ShoeDGV.SelectedRows[0].Cells[4].Value.ToString();
            PriceTb.Text = ShoeDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (STitleTB.Text == "")
            {
                key = 0;
            }else
            {
                key = Convert.ToInt32(ShoeDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void Shoes_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
