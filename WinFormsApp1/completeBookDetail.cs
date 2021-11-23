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
    public partial class completeBookDetail : Form
    {
        
        public completeBookDetail()
        {
            InitializeComponent();
        }

        private void completeBookDetail_Load(object sender, EventArgs e)
        {
            AddConnection NewConnection = new AddConnection();
            SqlCommand cmd1 = new SqlCommand("select * from IssueBook where book_return_date IS NULL",NewConnection.OpenConnection());
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);

            dataGridView1.DataSource = ds1.Tables[0];

            NewConnection.CloseConnection();
            

            SqlCommand cmd2 = new SqlCommand("select * from IssueBook where book_return_date IS NOT NULL", NewConnection.OpenConnection());
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);

            dataGridView2.DataSource = ds2.Tables[0];
            NewConnection.CloseConnection();
        }
    }
}
