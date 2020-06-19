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
    public partial class uSalary : Form
    {
        string NumS;
        public uSalary()
        {
            InitializeComponent();
        }
        public uSalary(string ENum)
        {
            NumS = ENum;
            InitializeComponent();
            textBox11.Text = NumS;
            textBox2.Text = NumS;
           
        }
        private void Button10_Click(object sender, EventArgs e)
        {
            uMainwindow f1 = new uMainwindow(NumS);
            f1.Show();
            this.Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            uMainwindow f1 = new uMainwindow(NumS);
            f1.Show();
            this.Hide();
        }

        private void Button12_Click(object sender, EventArgs e)//工资查询
        {
            dataGridView1.Rows.Clear();
            string sql = "select *from Pay where EmployeeNum='" + textBox11.Text + "'";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                double bs, re, sub,sum;
                string a, b, c, d, f,num;
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
                string[] str = { f, a, b, c, d, num};
                dataGridView1.Rows.Add(str);
                string sql2 = "update Pay set Totalmoney='" + num + "' where EmployeeNum='" + textBox11.Text + "' ";
                Dao dao1 = new Dao();
                dao.Excute(sql2);

            }
            
            dr.Close();
        }

        private void Button4_Click(object sender, EventArgs e)//奖惩查询
        {
            dataGridView4.Rows.Clear();
            string sql = "select *from Reward where EmployeeNum='" + textBox2.Text + "'";
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

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
