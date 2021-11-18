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
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtStudentName.Text != "" && txtEnroll.Text != "" && txtDep.Text != "" && txtSem.Text != "" && txtContact.Text != "" && txtEmail.Text != "")
            {


                String sname = txtStudentName.Text;
                String senroll = txtEnroll.Text;
                String dep = txtDep.Text;
                String ssem = txtSem.Text;
                Int64 scontact = Int64.Parse(txtContact.Text);
                String semail = txtEmail.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-IQB4442\\SQLEXPRESS; database = DBLibrary;integrated security =True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into NewStudent (sName,enroll,dep,sem,contact,email) values ('" + sname + "','" + senroll + "','" + dep + "','" + ssem + "'," + scontact + ",'" + semail + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtStudentName.Clear();
                txtEnroll.Clear();
                txtDep.Clear();
                txtSem.Clear();
                txtContact.Clear();
                txtEmail.Clear();
            }
            else
            {
                MessageBox.Show("Empty textbox detected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtStudentName.Clear();
            txtEnroll.Clear();
            txtDep.Clear();
            txtSem.Clear();
            txtContact.Clear();
            txtEmail.Clear();
        }
    }
}
