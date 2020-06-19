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
    public partial class Salary : Form
    {
        string gongzi;
        string butie;
        public Salary()
        {
            InitializeComponent();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            mainwindow f1 = new mainwindow();
            f1.Show();
            this.Hide();
        }
        //全部查询
        private void Table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select * from Pay";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c, d, e, f;
                a = dr["EmployeeNum"].ToString();
                e = dr["BasicSal"].ToString();
                b = dr["RewardMoney1"].ToString();
                c = dr["sub"].ToString();
                d = dr["PayData"].ToString();
                f = dr["Totalmoney"].ToString();     
                string[] str = { a, e, b, c, d,f  };
                dataGridView1.Rows.Add(str);               
            }
            dr.Close();
        }
        //单个查询
        private void oneSch()
        {
            dataGridView1.Rows.Clear();
            string sql = "select *from Pay where EmployeeNum='" + textBox1.Text + "'";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c, d, e, f;
                f=dr["EmployeeNum"].ToString();
                a = dr["BasicSal"].ToString();
                b = dr["RewardMoney1"].ToString();
                c = dr["sub"].ToString();
                d = dr["PayData"].ToString(); 
                e = dr["Totalmoney"].ToString();
                string[] str = { f,a, b, c, d, e };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();
        }
        private void Button2_Click(object sender, EventArgs e)//全部查询
        {
            Table();
        }

        private void Button1_Click(object sender, EventArgs e)//单个查询
        {
            oneSch();
        }

        private void Button11_Click(object sender, EventArgs e)//修改工资时的查询
        {
            dataGridView3.Rows.Clear();
            string sql = "select *from Pay where EmployeeNum='" + textBox11.Text + "'";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c, d, g, f;
                f = dr["EmployeeNum"].ToString();
                a = dr["BasicSal"].ToString();
                b = dr["RewardMoney1"].ToString();
                c = dr["sub"].ToString();
                d = dr["PayData"].ToString();
                g = dr["Totalmoney"].ToString();
                string[] str = { f, a, b, c, d, g };
                dataGridView3.Rows.Add(str);
                textBox3.Text = a;
                textBox4.Text = c;
                gongzi = textBox3.Text;
                butie = textBox4.Text;
            }
            dr.Close();
        }
        public void total()
        {
            string sql = "select *from Pay where EmployeeNum='" + textBox11.Text + "'";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                double bs, re, sub, sum;
                string a, b, c, d, f, num;
                f = dr["EmployeeNum"].ToString();
                a = dr["BasicSal"].ToString();
                b = dr["RewardMoney1"].ToString();
                c = dr["sub"].ToString();
                d = dr["PayData"].ToString();
                //g = dr["Totalmoney"].ToString();
                bs = Convert.ToDouble(a);
                re = Convert.ToDouble(b);
                sub = Convert.ToDouble(c);
                sum = bs + re + sub;
                num = Convert.ToString(sum);
                
                string sql2 = "update Pay set Totalmoney='" + num + "' where EmployeeNum='" + textBox11.Text + "' ";
                Dao dao1 = new Dao();
                dao.Excute(sql2);

            }
        }
        public void Button3_Click(object sender, EventArgs e)//修改工资确定按钮
        {
            total();
            DialogResult r = MessageBox.Show("确定要修改吗？", "提示", MessageBoxButtons.OKCancel);
            if (r == DialogResult.OK)
            {              
                if(gongzi!= textBox3.Text|| butie != textBox4.Text)
                {
                    string sql1 = "update Pay set BasicSal='" + textBox3.Text + "',sub='" + textBox4.Text + "' where EmployeeNum ='" + textBox11.Text + "'";
                    Dao dao1 = new Dao();
                    dao1.Excute(sql1);

                    int i = dao1.Excute(sql1);
                    if (i > 0) MessageBox.Show("修改成功");
                    total();
                }
               
                else
                {
                    MessageBox.Show("修改前后相同，不做修改");
                }
            }
        }

        private void reOne()
        {
            dataGridView2.Rows.Clear();
            string sql = "select *from Reward where EmployeeNum='" + textBox5.Text + "'";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c, d, g, f;
                a = dr["RewardNum"].ToString();
                g = dr["EmployeeNum"].ToString();
                b = dr["RewardType"].ToString();
                c = dr["RewardMoney"].ToString();
                d = dr["RewardDate"].ToString();
                f = dr["RewardRes"].ToString();
                string[] str = { a, g, b, c, d, f };
                dataGridView2.Rows.Add(str);
            }
            dr.Close();
        }
        private void Button6_Click(object sender, EventArgs e)//奖惩单个查询
        {
            reOne();
        }

        private void Button8_Click(object sender, EventArgs e)//添加奖惩
        {
            if (textBox10.Text == null || textBox8.Text == null || textBox7.Text == null || textBox9.Text == null)
            {
                MessageBox.Show("输入不完整，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string sql = "insert into Reward (EmployeeNum,RewardType,RewardMoney,RewardDate,RewardRes) values('"+ textBox12.Text + "','"+ textBox10.Text + "','"+ textBox8.Text + "','"+ textBox7.Text + "','"+ textBox9.Text + "');";

                MessageBox.Show(sql);
                Dao dao = new Dao();
                int i = dao.Excute(sql);
                if (i > 0) MessageBox.Show("添加成功");
            }
            textBox10.Text = null;
            textBox8.Text = null;
            textBox7.Text = null;
            textBox9.Text = null;
        }

        private void Button5_Click(object sender, EventArgs e)//奖惩全部查询
        {
            dataGridView2.Rows.Clear();
            string sql = "select * from Reward";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c, d, g, f;
                a = dr["RewardNum"].ToString();
                g = dr["EmployeeNum"].ToString();
                b = dr["RewardType"].ToString();
                c = dr["RewardMoney"].ToString();
                d = dr["RewardDate"].ToString();
                f = dr["RewardRes"].ToString();
                string[] str = { a, g, b, c, d, f };
                dataGridView2.Rows.Add(str);
            }
            dr.Close();
        }      
        private void Button12_Click(object sender, EventArgs e)//添加奖惩时的查询
        {
            dataGridView4.Rows.Clear();
            string sql = "select *from Reward where EmployeeNum='" + textBox12.Text + "'";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c, d, g, f;
                a = dr["RewardNum"].ToString();
                g = dr["EmployeeNum"].ToString();
                b = dr["RewardType"].ToString();
                c = dr["RewardMoney"].ToString();
                d = dr["RewardDate"].ToString();
                f = dr["RewardRes"].ToString();
                string[] str = { a, g, b, c, d, f };
                dataGridView4.Rows.Add(str);
            }
            dr.Close();
        
        }
        private void Button10_Click(object sender, EventArgs e)
        {
            mainwindow f1 = new mainwindow();
            f1.Show();
            this.Hide();
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            mainwindow f1 = new mainwindow();
            f1.Show();
            this.Hide();
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            mainwindow f1 = new mainwindow();
            f1.Show();
            this.Hide();
        }
    }
}
