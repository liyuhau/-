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
    public partial class uAttend : Form
    {
        string Numa;

        public uAttend()
        {
            InitializeComponent();
        }
        public uAttend(string ENum)
        {
            Numa = ENum;
            InitializeComponent();
            textBox1.Text = Numa;
            textBox2.Text = Numa;
            textBox6.Text = null;
            textBox7.Text = null;
            DateTime dt = DateTime.Now;
            textBox3.Text= dt.ToShortDateString().ToString();//签到日期
            textBox4.Text= dt.ToLongTimeString().ToString();//上班时间
    

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            uMainwindow f1 = new uMainwindow(Numa);
            f1.Show();
            this.Hide();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            uMainwindow f1 = new uMainwindow(Numa);
            f1.Show();
            this.Hide();
        }

        private void Button4_Click(object sender, EventArgs e)//请假显示
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
                string[] str = { h, a, g, b, c };
                dataGridView2.Rows.Add(str);
            }
            dr.Close();
        }
        public void ATotal()
        {
            int iCount;
            String a;
            iCount = dataGridView1.Rows.Count-1;
            a=Convert.ToString(iCount);
            string sql2 = "update Attend set Total = '"+ a + "' where EmployeeNum = '" + textBox1.Text + "'";
            Dao dao1 = new Dao();
            dao1.Excute(sql2);
            label9.Text = a;

        }
        private void Button1_Click(object sender, EventArgs e)//出勤显示
        {
            dataGridView1.Rows.Clear();
            string sql = "select * from Attend where EmployeeNum='" + textBox2.Text + "'";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                
                string a, b, c, g, h;
                h = dr["Attendance"].ToString();
                a = dr["EmployeeNum"].ToString();
                g = dr["ToDate"].ToString();
                b = dr["WorkTime"].ToString();
                c = dr["TimeWork"].ToString();
                string[] str = { h, a, g, b, c };
                dataGridView1.Rows.Add(str);
                ATotal();
            }
            dr.Close();
        }

        private void Button2_Click(object sender, EventArgs e)//请假
        {
            
            if (textBox6.Text == null || textBox7.Text == null)
            {
                MessageBox.Show("输入不完整，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string sql = "Insert into Leave(EmployeeNum,LeaveTime,TermTime,Leaveday) values('"+ textBox2.Text + "', '"+ textBox6.Text + "', '"+ textBox7.Text + "', '1')";

                MessageBox.Show(sql);
                Dao dao = new Dao();
                int i = dao.Excute(sql);
                if (i > 0) MessageBox.Show("添加成功");
            }
        }
      
        private void Button7_Click(object sender, EventArgs e)//上班签到
        {
            int z=1;
            string se1 = "select WorkTime from Attend where EmployeeNum='" + textBox1.Text + "' and ToDate='" + textBox3.Text + "' ";
            Dao dao1 = new Dao();
            IDataReader dr = dao1.read(se1);

            if (dr.Read())
            {
                z = z + 2;
            }
            if (z == 1)
            {
                string sql = "Insert into Attend(EmployeeNum, ToDate, WorkTime, TimeWork, Total) values('" + textBox1.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '1')";
                Dao dao = new Dao();
                int i = dao.Excute(sql);
                if (i > 0) MessageBox.Show("上班打卡成功");
            }
            else
            {
                MessageBox.Show("今日已签到！");
            }         
        }
        private void Button3_Click(object sender, EventArgs e)//下班签到
        {
            DateTime dt = DateTime.Now;
            textBox5.Text = dt.ToLongTimeString().ToString();
            string sql = "update Attend set TimeWork='" + textBox5.Text + "'where EmployeeNum='" + textBox1.Text + "'and ToDate='" + textBox3.Text + "'";
            Dao dao = new Dao();
            dao.Excute(sql);
            int i = dao.Excute(sql);
            if (i > 0) MessageBox.Show("下班打卡成功");
        }

        private void uAttend_Load(object sender, EventArgs e)
        {

        }
    }
}
