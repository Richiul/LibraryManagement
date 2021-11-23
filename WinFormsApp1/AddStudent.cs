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

                

                AddConnection NewConnection = new AddConnection();
                

                
                SqlCommand cmd = new SqlCommand("insert into NewStudent (sName,enroll,dep,sem,contact,email) values (@sName,@enroll,@dep,@sem,@contact,@email)",NewConnection.OpenConnection());
                cmd.Parameters.AddWithValue("@sName", txtStudentName.Text);
                cmd.Parameters.AddWithValue("@enroll", txtEnroll.Text);
                cmd.Parameters.AddWithValue("@dep", txtDep.Text);
                cmd.Parameters.AddWithValue("@sem", txtSem.Text);
                cmd.Parameters.AddWithValue("@contact", txtContact.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.ExecuteNonQuery();



                NewConnection.CloseConnection();

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
