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
    public partial class updatePass : Form
    {
        string haha;
        public updatePass(string eNum)
        {
            haha = eNum;
            InitializeComponent();

        }
        public updatePass()
        {
            InitializeComponent();
        }

        private void updatePass_Load(object sender, EventArgs e)
        {
            textBox1.Text = haha;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("确定要修改吗？", "提示", MessageBoxButtons.OKCancel);
            if (r == DialogResult.OK)
            {
                string sql = "update login1 set UserPass='" + textBox2.Text + " 'where EmployeeNum = '" + textBox1.Text + "' ";
                Dao dao = new Dao();
                int k = dao.Excute(sql);
                if (k > 0&&textBox2.Text==textBox3.Text)
                     MessageBox.Show("修改成功");
                else
                {
                     MessageBox.Show("密码和确认密码不符，请重新输入");
                 }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            login kk = new login();
            kk.Show();
            this.Hide();
        }
    }
}
