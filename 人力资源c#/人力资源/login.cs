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
    public partial class login : Form
    {
        string eNum;
        public login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private bool Login()
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("输入不完整，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                string sql = "select *from Login1 where EmployeeNum='" + textBox1.Text + "'and UserPass='"+ textBox2.Text + "'and level='" + comboBox1.Text + "'";
                Dao dao = new Dao();
                IDataReader dr = dao.read(sql);
                if (dr.Read())
                {
                    if (comboBox1.Text == "0")
                    {
                        eNum = dr["EmployeeNum"].ToString();
                        uMainwindow f1 = new uMainwindow(eNum);
                        f1.Show();
                        this.Hide();
                    }
                    else if (comboBox1.Text == "1")
                    {
                        mainwindow f1 = new mainwindow();
                        f1.Show();
                        this.Hide();
                    }
                }
                else
                {
                       MessageBox.Show("用户名或密码不正确", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                       return false;
                 }
            }
            return true;
        }
        private void Button1_Click(object sender, EventArgs e)//登录按钮
        {
            Login();
        }
        
        private void Button2_Click(object sender, EventArgs e)//取消按钮
        {
            textBox1.Text = "";
            textBox2.Text = null;
            comboBox1.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "0")
            {
                if(textBox1.Text!="")
                {
                    updatePass uu = new updatePass(eNum);
                    uu.Show();
                    this.Hide();
                }
               else
                {
                    MessageBox.Show("请输入用户名和权限！");
                }
            }
            else if (comboBox1.Text == "1")
            {
                userInfo u1 = new userInfo();
                u1.Show();
                this.Hide();
            }
            
            
        }
    }
}
