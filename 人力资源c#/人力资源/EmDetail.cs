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
    public partial class EmDetail : Form
    {       
        string[] str=new string[6];//接收到传递过来的数组
        public EmDetail()
        {
            InitializeComponent();
           
        }     
        public EmDetail(string[] a)//重写构造方法
        {

            InitializeComponent();    
            for (int i = 0; i < 6; i++)
            {
                str[i] = a[i];
            }
            textBox1.Text = str[0];
            textBox2.Text = str[1];
            textBox3.Text = str[2];
            textBox5.Text = str[3];
            textBox4.Text = str[4];
            textBox6.Text = str[5];
            ESalary();
        }
        public void ESalary()
        {
          
            string sql = "select Totalmoney from Pay where Pay.EmployeeNum='" + str[0] + "'";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a;
                a = dr["Totalmoney"].ToString();
                textBox7.Text = a;
            }
            dr.Close();
        }      
        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        //修改
        private void Button1_Click(object sender, EventArgs e)///修改
        {
            DialogResult r = MessageBox.Show("确定要修改吗？", "提示", MessageBoxButtons.OKCancel);
            if (r == DialogResult.OK)
            {
                if (textBox1.Text == null || textBox3.Text == null || textBox4.Text == null || textBox5.Text == null || textBox6.Text == null || textBox2.Text == null)
                {
                    MessageBox.Show("输入不完整，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (textBox1.Text != str[0]) //编号
                    {
                        // string sql = "update Einfo set EmployeeNum='" + textBox1.Text + " 'where EmployeeNum = '" + str[0] + "' and Name='" + str[1] + "'";
                        string sql = "update Einfo set EmployeeNum='" + textBox1.Text + " 'where EmployeeNum = '" + str[0] + "';update Leave set EmployeeNum='" + textBox1.Text + " 'where EmployeeNum = '" + str[0] + "';update Pay set EmployeeNum='" + textBox1.Text + " 'where EmployeeNum = '" + str[0] + "' ;update Attend set EmployeeNum='" + textBox1.Text + " 'where EmployeeNum = '" + str[0] + "';update Reward set EmployeeNum='" + textBox1.Text + " 'where EmployeeNum = '" + str[0] + "';update login1 set EmployeeNum='" + textBox1.Text + " 'where EmployeeNum = '" + str[0] + "' ";
                        Dao dao = new Dao();
                        dao.Excute(sql);
                        str[0] = textBox1.Text;
                        int i = dao.Excute(sql);
                        if (i > 0) MessageBox.Show("修改成功");
                    }
                    if (textBox2.Text != str[1])//姓名
                    {
                        string sql = "update Einfo set Name='" + textBox2.Text + " 'where EmployeeNum = '" + str[0] + "' and Name='" + str[1] + "'";
                        Dao dao = new Dao();
                        dao.Excute(sql);
                        str[1] = textBox2.Text;
                        int i = dao.Excute(sql);
                        if (i > 0) MessageBox.Show("修改成功");
                    }
                    if (textBox3.Text != str[2])//性别
                    {
                        string sql = "update Einfo set Gender='" + textBox3.Text + " 'where EmployeeNum = '" + str[0] + "' and Name='" + str[1] + "'";
                        Dao dao = new Dao();
                        dao.Excute(sql);
                        str[2] = textBox3.Text;
                        int i = dao.Excute(sql);
                        if (i > 0) MessageBox.Show("修改成功");
                    }
                    if (textBox4.Text != str[3])//出生日期
                    {
                        string sql = "update Einfo set DataBirth='" + textBox4.Text + " 'where EmployeeNum = '" + str[0] + "' and Name='" + str[1] + "'";
                        Dao dao = new Dao();
                        dao.Excute(sql);
                        str[3] = textBox4.Text;
                        int i = dao.Excute(sql);
                        if (i > 0) MessageBox.Show("修改成功");
                    }
                    if (textBox5.Text != str[4])//部门编号
                    {
                        string sql = "update Einfo set UnitNum='" + textBox5.Text + " 'where EmployeeNum = '" + str[0] + "' and Name='" + str[1] + "'";
                        Dao dao = new Dao();
                        dao.Excute(sql);
                        str[4] = textBox5.Text;
                        int i = dao.Excute(sql);
                        if (i > 0) MessageBox.Show("修改成功");
                    }
                    if (textBox6.Text != str[5])//职称
                    {
                        string sql = "update Einfo set TheTitle='" + textBox6.Text + " 'where EmployeeNum = '" + str[0] + "' and Name='" + str[1] + "'";
                        Dao dao = new Dao();
                        dao.Excute(sql);
                        str[5] = textBox6.Text;
                        int i = dao.Excute(sql);
                        if (i > 0) MessageBox.Show("修改成功");
                    }

                }
            }
               
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void EmDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
