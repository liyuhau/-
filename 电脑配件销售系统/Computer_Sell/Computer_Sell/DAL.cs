using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Computer_Sell
{
    class DAL
    {
        SqlConnection conn;
        SqlCommand comm;
        public DAL()
        {
            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\MyData\c#\电脑配件销售系统\Computer_Sell\Computer_Sell\orderInfo.mdf;Integrated Security=True";
            conn = new SqlConnection(connStr);
        }
        ~DAL() { }
        public int insert_orderInfo(OrderInfo or1)
        {
            conn.Open();
            comm = new SqlCommand("insert_orderInfo", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@orderNo", or1.OrderNo);
            comm.Parameters.AddWithValue("@customerNum",or1.CustomerNum);
            comm.Parameters.AddWithValue("@Data",or1.Data);
            comm.Parameters.AddWithValue("@Price",or1.Price);
            comm.Parameters.AddWithValue("@orderInvoice", or1.OrderInvoice);
            int result = comm.ExecuteNonQuery();
            conn.Close();
            return result;
        }
        public int update_orderInfo(OrderInfo or1)
        {
            conn.Open();
            comm = new SqlCommand("update_orderInfo", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@orderNo", or1.OrderNo);
            comm.Parameters.AddWithValue("@customerNum", or1.CustomerNum);
            comm.Parameters.AddWithValue("@Data", or1.Data);
            comm.Parameters.AddWithValue("@Price", or1.Price);
            comm.Parameters.AddWithValue("@orderInvoice", or1.OrderInvoice);
            int result = comm.ExecuteNonQuery();
            conn.Close();
            return result;
        }
        public int delete_orderInfo(string ss)
        {
            conn.Open();
            comm = new SqlCommand("delete_orderInfo", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@orderNo",ss);
            int result = comm.ExecuteNonQuery();
            conn.Close();
            return result;
        }
        public DataSet select_orderbyNo(string No)
        {
            conn.Open();
            comm = new SqlCommand("select_orderbyNo", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@orderNo", No);
            SqlDataAdapter sa = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            sa.Fill(ds,"No");
            conn.Close();
            return ds;
        }
        public DataSet select_orderbyCN(string CN)
        {
            conn.Open();
            comm = new SqlCommand("select_orderbyCN", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@customerNum", CN);
            SqlDataAdapter sa = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            sa.Fill(ds, "CN");
            conn.Close();
            return ds;
        }
        public DataSet select_orderbyInvoice(string Invoice)
        {
            conn.Open();
            comm = new SqlCommand("select_orderbyInvoice", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@orderInvoice", Invoice);
            SqlDataAdapter sa = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            sa.Fill(ds, "Invoice");
            conn.Close();
            return ds;
        }
        public DataSet order_getall()
        {
            conn.Open();
            comm = new SqlCommand("order_getall", conn);
            comm.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sa = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            sa.Fill(ds, "getall");
            conn.Close();
            return ds;
        }
        public DataSet select_mima(string mima)
        {
            conn.Open();
            comm = new SqlCommand("select_mima", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@userpass", mima);
            SqlDataAdapter sa = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            sa.Fill(ds, "mima");
            conn.Close();
            return ds;
        }
    }
}
