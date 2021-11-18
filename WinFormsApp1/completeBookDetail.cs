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
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = "data source=DESKTOP-IQB4442\\SQLEXPRESS; database = DBLibrary; integrated security = True";
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con1;

            cmd1.CommandText = "select * from IssueBook where book_return_date IS NULL";
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);

            dataGridView1.DataSource = ds1.Tables[0];

            SqlConnection con2 = new SqlConnection();
            con2.ConnectionString = "data source=DESKTOP-IQB4442\\SQLEXPRESS; database = DBLibrary; integrated security = True";
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con2;

            cmd2.CommandText = "select * from IssueBook where book_return_date IS NOT NULL";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);

            dataGridView2.DataSource = ds2.Tables[0];
        }
    }
}
