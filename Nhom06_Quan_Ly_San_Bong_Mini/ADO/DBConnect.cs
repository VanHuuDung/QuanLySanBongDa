using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ADO
{
    public class DBConnect
    {
        DataSet ds;
        public DataSet DS
        {
            get { return ds; }
            set { ds = value; }
        }
        SqlConnection connect;
        public SqlConnection Connect
        {
            get { return connect; }
            set { connect = value; }
        }

        public DBConnect()
        {
            connect = new SqlConnection("data source=LAPTOP-TAITHANH\\TAITHANHSQL; initial catalog=QL_SANBONG;user id = sa;password=123456");
            DS = new DataSet();
        }

        public DBConnect(string severname, string databasenname, string id, string pass)
        {
            string connectString = "Data Source=";
            connectString += severname + ";Initial Catalog=";
            connectString += databasenname + ";User ID=";
            connectString += id + "; Password = " + pass;
            connect = new SqlConnection(connectString);
        }

        public void openConnecttion()
        {
            if (connect.State.ToString() == "Closed")
                connect.Open();
        }

        public void closedConnecttion()
        {
            if (connect.State.ToString() == "Open")
                connect.Close();
        }
        public int execute_NonQuery(string sql)
        {
            SqlCommand cmd;
            openConnecttion();
            cmd = new SqlCommand(sql, Connect);
            int kq = cmd.ExecuteNonQuery();
            closedConnecttion();
            return kq;
        }
        public DataTable execute_NonQuery_SP(string sql)
        {
            DataTable table = new DataTable();
            openConnecttion();          
            SqlDataAdapter dap = new SqlDataAdapter(sql,connect);
            dap.Fill(table);
            closedConnecttion();
            return table;
        }
        public int execute_Scalar(string sql)
        {
            SqlCommand cmd;
            openConnecttion();
            cmd = new SqlCommand(sql, Connect);
            int kq = (int)cmd.ExecuteScalar();
            closedConnecttion();
            return kq;
        }

        public SqlDataReader execute_Reader(string sql)
        {
            SqlCommand cmd;
            openConnecttion();
            cmd = new SqlCommand(sql, Connect);
            SqlDataReader rd = cmd.ExecuteReader();
            return rd;
        }
        public DataTable getDatatable(string sql, string tablename)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, connect);
            da.Fill(DS, tablename);
            return DS.Tables[tablename];
        }
        public bool Kt_Email_HoaDon(string pMa)
        {
            openConnecttion();
            string SelectString = "select * from HoaDon Where EmailUser='" + pMa + "'";
            SqlCommand cmd = new SqlCommand(SelectString, Connect);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                rd.Close();
                closedConnecttion();
                return false;
            }
            else
            {
                rd.Close();
                closedConnecttion();
                return true;
            }
        }
    }
}
