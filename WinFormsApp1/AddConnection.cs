using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace WinFormsApp1
{
    public class AddConnection
    {
        string ConnectionString = "data source = DESKTOP-IQB4442\\SQLEXPRESS; database = DBLibrary;integrated security =True";
        SqlConnection con;

        public SqlConnection OpenConnection()
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            return con;
        }

        public SqlConnection con1()
        {
            con = new SqlConnection(ConnectionString);
            return con;
        }


        public void CloseConnection()
        {
            con.Close();
        }


        public void ExecuteQueries(string Query_)
        {
            
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.ExecuteNonQuery();
        }


        public SqlDataReader DataReader(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }


        public object ShowDataInGridView(string Query_)
        {
            SqlDataAdapter dr = new SqlDataAdapter(Query_, ConnectionString);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            object dataum = ds.Tables[0];
            return dataum;
        }

        public SqlDataAdapter da(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_);
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            return da;
        }

        

    }
}
