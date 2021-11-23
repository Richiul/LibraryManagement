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
    public partial class ReturnBook : Form
    {
        AddConnection NewConnection = new AddConnection();
        public ReturnBook()
        {
            InitializeComponent();
        }

        private void ReturnBook_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            txtSearch.Clear();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {


                

                NewConnection.OpenConnection();
                SqlCommand cmd = new SqlCommand("select * from IssueBook where std_enroll = @std_enroll and book_return_date IS NULL", NewConnection.OpenConnection());
                cmd.Parameters.AddWithValue("@std_enroll", txtSearch.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                NewConnection.CloseConnection();

                if (ds.Tables[0].Rows.Count != 0)
                {
                    dataGridView.DataSource = ds.Tables[0];
                }
                else
                {
                    MessageBox.Show("Invalid ID or No Book Issued", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        String bname;
        String bdate;
        Int64 rowid;

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Visible = true;
            if (dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                rowid = int.Parse(dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
                bname = dataGridView.Rows[e.RowIndex].Cells[7].Value.ToString();
                bdate = dataGridView.Rows[e.RowIndex].Cells[8].Value.ToString();
              
            }
            txtBookName.Text = bname;
            txtIssueDate.Text = bdate;

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                panel2.Visible = false;
                dataGridView.DataSource = null;
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {

            NewConnection.OpenConnection();

            SqlCommand cmd = new SqlCommand("update IssueBook set book_return_date = @book_return_date where std_enroll = @std_enroll and id = @rowid", NewConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@book_return_date", dateTimePicker.Text);
            cmd.Parameters.AddWithValue("@std_enroll", txtSearch.Text);
            cmd.Parameters.AddWithValue("@rowid", rowid);
            cmd.ExecuteNonQuery();

            NewConnection.CloseConnection();

            MessageBox.Show("Returned successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


            ReturnBook_Load(this, null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }
    }
}
