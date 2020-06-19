using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 人力资源
{
    public partial class Attend : Form
    {
        public Attend()
        {
            InitializeComponent();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            mainwindow f1 = new mainwindow();
            f1.Show();
            this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)//出勤单个查询
        {
            dataGridView1.Rows.Clear();
            string sql = "select * from Attend where EmployeeNum='" + textBox1.Text + "'";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c, d, g,h;
                h = dr["Attendance"].ToString();
                a = dr["EmployeeNum"].ToString();
                g = dr["ToDate"].ToString();
                b = dr["WorkTime"].ToString();
                c = dr["TimeWork"].ToString();
                d = dr["Total"].ToString();
               // f = dr["Attenday"].ToString();
                string[] str = { h,a, g, b, c, d };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();
        }

        private void Button2_Click(object sender, EventArgs e)//出勤全部查询
        {
            
                dataGridView1.Rows.Clear();
                string sql = "select * from Attend";
                Dao dao = new Dao();
                IDataReader dr = dao.read(sql);
                while (dr.Read())
                {
                    string a, b, c, d, g, h;
                    h = dr["Attendance"].ToString();
                    a = dr["EmployeeNum"].ToString();
                    g = dr["ToDate"].ToString();
                    b = dr["WorkTime"].ToString();
                    c = dr["TimeWork"].ToString();
                    d = dr["Total"].ToString();
                   // f = dr["Attenday"].ToString();
                    string[] str = {h, a, g, b, c, d };
                    dataGridView1.Rows.Add(str);
                }
                dr.Close();
            
        }

        private void Button4_Click(object sender, EventArgs e)//请假单个查询
        {
            dataGridView2.Rows.Clear();
            string sql = "select * from Leave where EmployeeNum='" + textBox2.Text + "'";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c,  g,  h;
                h = dr["LeaveNum"].ToString();
                a = dr["EmployeeNum"].ToString();
                g = dr["LeaveTime"].ToString();
                b = dr["TermTime"].ToString();
                c = dr["Leaveday"].ToString();
              
                string[] str = { h, a, g, b, c};
                dataGridView2.Rows.Add(str);
            }
            dr.Close();
        }

        private void Button3_Click(object sender, EventArgs e)//请假全部查询
        {

            dataGridView2.Rows.Clear();
            string sql = "select * from Leave";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c,  g,  h;
                h = dr["LeaveNum"].ToString();
                a = dr["EmployeeNum"].ToString();
                g = dr["LeaveTime"].ToString();
                b = dr["TermTime"].ToString();
                c = dr["Leaveday"].ToString();

                string[] str = { h, a, g, b, c };
                dataGridView2.Rows.Add(str);
            }
            dr.Close();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            mainwindow f1 = new mainwindow();
            f1.Show();
            this.Hide();
        }

        private void Attend_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Attend_Load(object sender, EventArgs e)
        {

        }
    }
}
