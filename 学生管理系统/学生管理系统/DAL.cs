using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace 学生管理系统
{
    class DAL
    {
        SqlConnection conn;  
        SqlCommand comm;   
        public DAL()
        {
            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\MyData\c#\学生管理系统\学生管理系统\stumanage.mdf;Integrated Security=True";
            conn = new SqlConnection(connStr);
        }
        ~DAL() { }
        public DataSet login(Users user1)
        {
            conn.Open();
            comm = new SqlCommand("login", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@userName", user1.userName);
            comm.Parameters.AddWithValue("@userPass", user1.userPass);
            comm.Parameters.AddWithValue("@user_power",user1.user_power);
            SqlDataAdapter sa = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            sa.Fill(ds,"users");
            conn.Close();
            return ds;
        }


        public DataSet Getall()
        {
            conn.Open();
            comm = new SqlCommand("user_getall", conn);
            comm.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sa = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            sa.Fill(ds,"users");//把查询到的表放在一个名叫users的表中，便于使用
            conn.Close();
            return ds;
        }
        public int insert_user(Users user1)
        {
            conn.Open();
            comm = new SqlCommand("user_insert", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@userName", user1.userName);
            comm.Parameters.AddWithValue("@userPass", user1.userPass);
            comm.Parameters.AddWithValue("@user_power", user1.user_power);
            int result= comm.ExecuteNonQuery();
            conn.Close();
            return result;
        }
        public int delete_user(string userName)
        {
            conn.Open();
            comm = new SqlCommand("user_delete", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@userName", userName);
            int result = comm.ExecuteNonQuery();
            conn.Close();
            return result;
        }
        public int update_user(Users user1)
        {
            conn.Open();
            comm = new SqlCommand("user_update", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@userName", user1.userName);
            comm.Parameters.AddWithValue("@userPass", user1.userPass);
            comm.Parameters.AddWithValue("@user_power", user1.user_power);
            int result = comm.ExecuteNonQuery();
            conn.Close();
            return result;
        }
        public DataSet getbyusername_user(string userName)
        {
            conn.Open();
            comm = new SqlCommand("user_getbyusername", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@userName", userName);
            SqlDataAdapter sa = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            sa.Fill(ds,"tt");
            conn.Close();
            return ds;
        }


        public DataSet stu_Getall()
        {
            conn.Open();
            comm = new SqlCommand("stuinfo_getall", conn);
            comm.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sa = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            sa.Fill(ds, "stu");//把查询到的表放在一个名叫users的表中，便于使用
            conn.Close();
            return ds;
        }
        public int insert_stuinfo(Stuinfo stu1)
        {
            conn.Open();
            comm = new SqlCommand("stuinfo_insert", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@stu_id", stu1.Stu_id);
            comm.Parameters.AddWithValue("@stu_name", stu1.stu_name);
            comm.Parameters.AddWithValue("@stu_sex", stu1.stu_sex);
            comm.Parameters.AddWithValue("@stu_nation", stu1.stu_nation);
            comm.Parameters.AddWithValue("@stu_birrhday",stu1. stu_birrhday);
            comm.Parameters.AddWithValue("@stu_rutime", stu1.stu_rutime);
            comm.Parameters.AddWithValue("@stu_class", stu1.stu_class);
            comm.Parameters.AddWithValue("@stu_home", stu1.stu_home);
            comm.Parameters.AddWithValue("@stu_else", stu1.stu_else);
            int result = comm.ExecuteNonQuery();
            conn.Close();
            return result;
        }
        public int delete_stuinfo(string stu_name)
        {
            conn.Open();
            comm = new SqlCommand("stuinfo_delete", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@stu_name", stu_name);
            int result = comm.ExecuteNonQuery();
            conn.Close();
            return result;
        }
        public int update_stuinfo(Stuinfo stu1)
        {
            conn.Open();
            comm = new SqlCommand("stuinfo_update", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@stu_id", stu1.Stu_id);
            comm.Parameters.AddWithValue("@stu_name", stu1.stu_name);
            comm.Parameters.AddWithValue("@stu_sex", stu1.stu_sex);
            comm.Parameters.AddWithValue("@stu_nation", stu1.stu_nation);
            comm.Parameters.AddWithValue("@stu_birrhday", stu1.stu_birrhday);
            comm.Parameters.AddWithValue("@stu_rutime", stu1.stu_rutime);
            comm.Parameters.AddWithValue("@stu_class", stu1.stu_class);
            comm.Parameters.AddWithValue("@stu_home", stu1.stu_home);
            comm.Parameters.AddWithValue("@stu_else", stu1.stu_else);
            int result = comm.ExecuteNonQuery();
            conn.Close();
            return result;
        }
        public DataSet stu_byclass(string stuclass)
        {
            conn.Open();
            comm = new SqlCommand("stuinfo_getbyclass", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@stu_class", stuclass);
            SqlDataAdapter sa = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            sa.Fill(ds, "t");
            conn.Close();
            return ds;
        }
        public DataSet stu_byid(string stu_id)
        {
            conn.Open();
            comm = new SqlCommand("stuinfo_getbyid", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@stu_id", stu_id);
            SqlDataAdapter sa = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            sa.Fill(ds, "t1");
            conn.Close();
            return ds;
        }


        public DataSet course_Getall()
        {
            conn.Open();
            comm = new SqlCommand("course_getall", conn);
            comm.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sa = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            sa.Fill(ds, "cour");
            conn.Close();
            return ds;
        }
        public int insert_course(Course cour1)
        {
            conn.Open();
            comm = new SqlCommand("course_insert", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@course_id", cour1.Course_id);
            comm.Parameters.AddWithValue("@course_name",cour1. Course_name);
            comm.Parameters.AddWithValue("@course_year", cour1.course_year);
            comm.Parameters.AddWithValue("@course_period", cour1.course_period);
            comm.Parameters.AddWithValue("@course_cordit", cour1.course_cordit);
            comm.Parameters.AddWithValue("@course_describe", cour1.course_describe);
            int result = comm.ExecuteNonQuery();
            conn.Close();
            return result;
        }
        public int delete_course(string course_name)
        {
            conn.Open();
            comm = new SqlCommand("course_delete", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@course_name", course_name);
            int result = comm.ExecuteNonQuery();
            conn.Close();
            return result;
        }
        public int update_course(Course cour1)
        {
            conn.Open();
            comm = new SqlCommand("course_update", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@course_id", cour1.Course_id);
            comm.Parameters.AddWithValue("@course_name", cour1.Course_name);
            comm.Parameters.AddWithValue("@course_year", cour1.course_year);
            comm.Parameters.AddWithValue("@course_period", cour1.course_period);
            comm.Parameters.AddWithValue("@course_cordit", cour1.course_cordit);
            comm.Parameters.AddWithValue("@course_describe", cour1.course_describe);
            int result = comm.ExecuteNonQuery();
            conn.Close();
            return result;
        }
        public DataSet course_getbyyear(string course_year)
        {
            conn.Open();
            comm = new SqlCommand("course_getbyyear", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@course_year", course_year );
            SqlDataAdapter sa = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            sa.Fill(ds, "s");
            conn.Close();
            return ds;
        }
        public DataSet course_getbyname(string course_name)
        {
            conn.Open();
            comm = new SqlCommand("course_getbyname", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@course_name", course_name);
            SqlDataAdapter sa = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            sa.Fill(ds, "s1");
            conn.Close();
            return ds;
        }

        public DataSet stu_choose_getbycourse_name(string course_name)
        {
            conn.Open();
            comm = new SqlCommand("stu_choose_getbycourse_name", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@course_name", course_name);
            SqlDataAdapter sa = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            sa.Fill(ds, "s2");
            conn.Close();
            return ds;
        }

        
        public DataSet choose_course_getall()
        {
            conn.Open();
            comm = new SqlCommand("choose_course_getall", conn);
            comm.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sa = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            sa.Fill(ds, "sd");
            conn.Close();
            return ds;
        }
        public int stu_choose_course_update(string grade, string course_name,string id)
        {
            conn.Open();
            comm = new SqlCommand("stu_choose_course_update", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@student_grade", grade);
            comm.Parameters.AddWithValue("@course_name", course_name);
            comm.Parameters.AddWithValue("@student_id", id);
            int result = comm.ExecuteNonQuery();
            conn.Close();
            return result;
        }
        public DataSet stu_choose_getbystu_id(string stu_id)
        {
            conn.Open();
            comm = new SqlCommand("stu_choose_getbystu_id", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@student_id", stu_id);
            SqlDataAdapter sa = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            sa.Fill(ds, "ct");
            conn.Close();
            return ds;
        }
        public int stu_choose_course_insert(choose_course choo1)
        {
            conn.Open();
            comm = new SqlCommand("stu_choose_course_insert", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@course_id", choo1.Course_id);
            comm.Parameters.AddWithValue("@student_id", choo1.Stu_id);
            comm.Parameters.AddWithValue("@stu_name", choo1.stu_name);
            comm.Parameters.AddWithValue("@course_name", choo1.Course_name);
            comm.Parameters.AddWithValue("@student_grade", choo1.Student_grade);
            comm.Parameters.AddWithValue("@course_year", choo1.course_year);
            int result = comm.ExecuteNonQuery();
            conn.Close();
            return result;
        }
        public int stu_update_mima(string userName, string userPass)
        {
            conn.Open();
            comm = new SqlCommand("stu_update_mima", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@userName", userName);
            comm.Parameters.AddWithValue("@userPass", userPass);
            int result = comm.ExecuteNonQuery();
            conn.Close();
            return result;
        }
    }
}
