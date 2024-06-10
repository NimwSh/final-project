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
    public partial class billing : Form
    {
        public billing()
        {
            InitializeComponent();
            populate();
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
            string query = "select * from ShoeTbl where SSize= '";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ShoeDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {

        }
        int key = 0,stock=0;
        private void ShoeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            STitleTB.Text = ShoeDGV.SelectedRows[0].Cells[1].Value.ToString();
            QtyTb.Text = ShoeDGV.SelectedRows[0].Cells[4].Value.ToString();
            PriceTb.Text = ShoeDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (STitleTB.Text == "")
            {
                key = 0;
                stock = 0;
            }
            else
            {
                key = Convert.ToInt32(ShoeDGV.SelectedRows[0].Cells[0].Value.ToString());
                stock = Convert.ToInt32(ShoeDGV.SelectedRows[0].Cells[4].Value.ToString());
            }
        }
        private void reset()
        {
            AtitleTb.Text = "";
            WtyTB.Text = "";
            MriceTB.Text = "";
            XlientNameTb.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        int n = 0;

        private void billing_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(WtyTB.Text == "" || Convert.ToInt32(WtyTB.Text)>stock)
            {
                MessageBox.Show("موجودی کافی نیست");
            }
            else
            {
                int total = Convert.ToInt32(WtyTB.Text) * Convert.ToInt32(MriceTB.Text);
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(BillDGV);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = AtitleTb.Text;
                newRow.Cells[2].Value = WtyTB.Text;
                newRow.Cells[3].Value = MriceTB.Text;
                newRow.Cells[4].Value = total;
                BillDGV.Rows.Add(newRow);
                n++;
            }
        }
    }
}
