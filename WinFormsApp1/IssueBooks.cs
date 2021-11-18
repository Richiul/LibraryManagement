﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class IssueBooks : Form
    {
        public IssueBooks()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void IssueBooks_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-IQB4442\\SQLEXPRESS; database = DBLibrary; integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            cmd = new SqlCommand("select bName from NewBook", con);
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                for(int i = 0; i < sdr.FieldCount; i++)
                {
                    cmbBookName.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
            con.Close();
            txtEnroll.Clear();

        }

        int count;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtEnroll.Text != "")
            {
                String eid = txtEnroll.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-IQB4442\\SQLEXPRESS; database = DBLibrary; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewStudent where enroll = '" + eid + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                //******************************************* Number of books issued to a student

                cmd.CommandText = "select count(std_enroll) from IssueBook where std_enroll = '" + eid + "' and book_return_date is null";
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);

                count = int.Parse(ds1.Tables[0].Rows[0][0].ToString());

                //*******************************************

                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtStudentName.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtDep.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtSem.Text = ds.Tables[0].Rows[0][4].ToString();
                    txtContact.Text = ds.Tables[0].Rows[0][5].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0][6].ToString();

                }
                else
                {
                    txtStudentName.Clear();
                    txtDep.Clear();
                    txtSem.Clear();
                    txtContact.Clear();
                    txtEmail.Clear();
                    MessageBox.Show("Invalid enrollment number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if(txtStudentName.Text != "")
            {
                if(cmbBookName.SelectedIndex != -1 && count <= 2)
                {
                    String enroll = txtEnroll.Text;
                    String sname = txtStudentName.Text;
                    String sdep = txtDep.Text;
                    String sem = txtSem.Text;
                    Int64 contact = Int64.Parse(txtContact.Text);
                    String email = txtEmail.Text;
                    String bookname = cmbBookName.Text;
                    String bookIssueDate = dateTimePicker1.Text;

                    String eid = txtEnroll.Text;

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "data source = DESKTOP-IQB4442\\SQLEXPRESS; database = DBLibrary; integrated security=True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();

                    cmd.CommandText = cmd.CommandText = "insert into IssueBook (std_enroll,std_name,std_dep,std_sem,std_contact,std_email,book_name,book_issue_date) values ('"+enroll+"','"+sname+"','"+sdep+"','"+sem+"',"+contact+",'"+email+"','"+bookname+"','"+bookIssueDate+"')";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Book is Issued.","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    
                    IssueBooks_Load(this, null);
                }
                else
                {
                    MessageBox.Show("Select Book or Maximum amount of issued books.", "Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            else
            {
                MessageBox.Show("Enter valid Enrollment no", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void txtEnroll_TextChanged(object sender, EventArgs e)
        {
            if(txtEnroll.Text == "")
            {
                txtStudentName.Clear();
                txtDep.Clear();
                txtSem.Clear();
                txtContact.Clear();
                txtEmail.Clear();
                
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtEnroll.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to quit?", "Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}