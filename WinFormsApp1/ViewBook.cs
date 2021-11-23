using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class ViewBook : Form
    {
        AddConnection newConnection = new AddConnection();
        public ViewBook()
        {
            InitializeComponent();
        }

        private void ViewBook_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            SqlCommand cmd = new SqlCommand("select * from NewBook",newConnection.OpenConnection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtBookName.Clear();
            panel2.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtBookName.Text != "")
            {

                SqlCommand cmd = new SqlCommand("select * from NewBook where bName LIKE '%'+@bName+'%'",newConnection.OpenConnection());
                cmd.Parameters.AddWithValue("@bName", txtBookName.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

                newConnection.CloseConnection();
            }
            else
            {
               SqlCommand cmd = new SqlCommand("select * from NewBook",newConnection.OpenConnection());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

                newConnection.CloseConnection();
            }
        }
        int bid;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                // MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible = true;

            


            SqlCommand cmd = new SqlCommand("select * from NewBook where bid = @bid",newConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@bid",bid);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            txtBName.Text = ds.Tables[0].Rows[0][1].ToString();
            txtAuthor.Text = ds.Tables[0].Rows[0][2].ToString();
            txtPublication.Text = ds.Tables[0].Rows[0][3].ToString();
            txtPDate.Text = ds.Tables[0].Rows[0][4].ToString();
            txtPrice.Text = ds.Tables[0].Rows[0][5].ToString();
            txtQuantity.Text = ds.Tables[0].Rows[0][6].ToString();
            newConnection.CloseConnection();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to update your data?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                SqlCommand cmd = new SqlCommand("update NewBook set bName = @bName, bAuthor = @bAuthor, bPubl = @bPubl, bPDate = @bPDate, bPrice = @bPrice, bQuan = @bQuan where bid = @rowid ", newConnection.OpenConnection());
                cmd.Parameters.AddWithValue("@bName", txtBName.Text);
                cmd.Parameters.AddWithValue("@bAuthor",txtAuthor.Text);
                cmd.Parameters.AddWithValue("@bPubl",txtPublication.Text);
                cmd.Parameters.AddWithValue("@bPDate",txtPDate.Text);
                cmd.Parameters.AddWithValue("@bPrice",txtPrice.Text);
                cmd.Parameters.AddWithValue("@bQuan",txtQuantity.Text);
                cmd.Parameters.AddWithValue("@rowid", rowid);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                MessageBox.Show("Data updated successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                newConnection.CloseConnection();
                ViewBook_Load(this, null);
            }


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete this book?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                SqlCommand cmd = new SqlCommand("delete from NewBook where bid = @rowid",newConnection.OpenConnection());
                cmd.Parameters.AddWithValue("@rowid", rowid);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                MessageBox.Show("Book deleted successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                newConnection.CloseConnection();
                ViewBook_Load(this, null);
            }
        }
    }
}
