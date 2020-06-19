using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace 人力资源
{
    class Dao
    {
       
        public SqlConnection connection()
        {
            string str = "Data Source=LAPTOP-KFSH7BMT;Initial Catalog=hrm;Integrated Security=True";
            SqlConnection sc = new SqlConnection(str);
            sc.Open();//打开数据库链接
            return sc;
        }
        public SqlCommand command(string sql)
        {
            SqlCommand sc = new SqlCommand(sql, connection());
            return sc;
        }
        //用于delete update insert 返回受影响行数
        public int Excute(string sql)
        {
            return command(sql).ExecuteNonQuery();
        }
        //用于selcet
        public SqlDataReader read(string sql)
        {
            return command(sql).ExecuteReader();
        }


    }
}
