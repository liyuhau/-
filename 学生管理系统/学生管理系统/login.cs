using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 学生管理系统
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void 登录界面_Load(object sender, EventArgs e)
        {
            skinEngine1.SkinFile = "WaveColor1.ssk";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                if(String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("用户名或者密码不能为空！");
                }
                else
                {
                    if (radioButton1.Checked == true)
                    {
                    
                            Users user1 = new Users(); 
                            DataSet ds = new DataSet();
                            DAL dall = new DAL();//实例化
                            user1.userName = textBox1.Text;
                            user1.userPass = textBox2.Text;
                            user1.user_power = "1";
                            ds = dall.login(user1);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                this.Hide();
                                stumanage f2 = new stumanage();
                                f2.Show();
                            }
                            else
                            {
                                MessageBox.Show("管理员中不存在此用户或者用户名密码输入错误，请重新输入");
                            }
                   
                    }
                    if (radioButton2.Checked == true)
                    {
                    
                            Users user1 = new Users();
                            DataSet ds = new DataSet();
                            DAL dall = new DAL();
                            user1.userName = textBox1.Text;
                            user1.userPass = textBox2.Text;
                            user1.user_power = "0";
                            ds = dall.login(user1);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                this.Hide();
                                stuinfo f8 = new stuinfo();
                                f8.usernamebb(textBox1.Text);
                                f8.Show();
                            }
                            else
                            {
                                MessageBox.Show("学生中不存在此用户或者用户名密码输入错误，请重新输入");
                            } 
                    }
                
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Focus();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
    }
}
