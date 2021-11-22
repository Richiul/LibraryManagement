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
            NewConnection.OpenConnection();
            
            DataSet ds1 = new DataSet();
            NewConnection.da("select * from IssueBook where book_return_date IS NULL").Fill(ds1);
            dataGridView1.DataSource = ds1.Tables[0];

            DataSet ds2 = new DataSet();
            NewConnection.da("select * from IssueBook where book_return_date IS NOT NULL").Fill(ds2);

            dataGridView2.DataSource = ds2.Tables[0];
        }
    }
}
