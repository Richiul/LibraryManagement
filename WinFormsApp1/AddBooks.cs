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
    public partial class AddBooks : Form
    {
        public AddBooks()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBookName.Text != "" && txtAuthor.Text != "" && txtPublication.Text != "" && txtBookPrice.Text != "" && txtQuantity.Text != "")
            { 

                AddConnection NewConnection = new AddConnection();
                

                SqlCommand cmd = new SqlCommand("insert into NewBook (bName,bAuthor,bPubl,bPDate,bPrice,bQuan) values (@bName,@bAuthor,@bPubl,@bPDate,@bPrice,@bQuan)",NewConnection.OpenConnection());
                cmd.Parameters.AddWithValue("@bName",txtBookName.Text);
                cmd.Parameters.AddWithValue("@bAuthor",txtAuthor.Text);
                cmd.Parameters.AddWithValue("@bPubl",txtPublication.Text);
                cmd.Parameters.AddWithValue("@bPDate",dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@bPrice",txtBookPrice.Text);
                cmd.Parameters.AddWithValue("@bQuan",txtQuantity.Text);
                cmd.ExecuteNonQuery();


                NewConnection.CloseConnection();



                MessageBox.Show("Data Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBookName.Clear();
                txtAuthor.Clear();
                txtPublication.Clear();
                txtBookPrice.Clear();
                txtQuantity.Clear();
            }
            else
            {
                MessageBox.Show("Empty textbox detected.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                this.Close();
                }
            
        }
    }
}
