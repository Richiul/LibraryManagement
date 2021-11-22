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
    public partial class ViewStudent : Form
    {
        AddConnection NewConnection = new AddConnection();
        public ViewStudent()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ViewStudent_Load(object sender, EventArgs e)
        {
            panel3.Visible = false;
            NewConnection.OpenConnection();
            
            DataSet ds = new DataSet();
            NewConnection.da("select * from NewStudent").Fill(ds);


            dataGridView1.DataSource = ds.Tables[0];

            NewConnection.CloseConnection();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            panel3.Visible = false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                Image image = Image.FromFile("C:/Users/Richard/Desktop/LibraryProject/Liberay Management System/search1.gif");
                pictureBox1.Image = image;

                NewConnection.OpenConnection();

                DataSet ds = new DataSet();
                NewConnection.da("select * from NewStudent where enroll LIKE '" + txtSearch.Text + "%'").Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

                NewConnection.CloseConnection();
            }
            else
            {
                Image image = Image.FromFile("C:/Users/Richard/Desktop/LibraryProject/Liberay Management System/search.gif");
                pictureBox1.Image = image;

                NewConnection.OpenConnection();

                DataSet ds = new DataSet();
                NewConnection.da("select * from NewStudent").Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

                NewConnection.CloseConnection();
            }
        }
        int stuid;
        Int64 rowid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                stuid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                
            }
            panel3.Visible = true;

            NewConnection.OpenConnection();

            
            DataSet ds = new DataSet();
            NewConnection.da("select * from NewStudent where stuid = " + stuid + "").Fill(ds);

            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            txtName.Text = ds.Tables[0].Rows[0][1].ToString();
            txtEnroll.Text = ds.Tables[0].Rows[0][2].ToString();
            txtDep.Text = ds.Tables[0].Rows[0][3].ToString();
            txtSem.Text = ds.Tables[0].Rows[0][4].ToString();
            txtContact.Text = ds.Tables[0].Rows[0][5].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0][6].ToString();

            NewConnection.CloseConnection();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to update your data?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {



                String sname = txtName.Text;
                String enroll = txtEnroll.Text;
                String dep = txtDep.Text;
                String ssem = txtSem.Text;
                Int64 contact = Int64.Parse(txtContact.Text);
                String email = txtEmail.Text;

                NewConnection.OpenConnection();

                DataSet ds = new DataSet();

                NewConnection.da("update NewStudent set sName = '" + sname + "', enroll = '" + enroll + "',dep = '" + dep + "',sem = '" + ssem + "',contact = " + contact + ",email = '" + email + "' where stuid = " + rowid + " ").Fill(ds);
                
                MessageBox.Show("Data updated successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                NewConnection.CloseConnection();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete this book?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                NewConnection.OpenConnection();

                DataSet ds = new DataSet();
                NewConnection.da("delete from NewStudent where stuid = " + rowid + "").Fill(ds);

                MessageBox.Show("Book deleted successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                NewConnection.CloseConnection();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
