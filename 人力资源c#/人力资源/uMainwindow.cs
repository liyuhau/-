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
    public partial class uMainwindow : Form
    {
        string ENum;
        public uMainwindow()
        {
            InitializeComponent();
        }
        public uMainwindow(string eNum)
        {
            ENum = eNum;
            InitializeComponent();
            
        }
        private void Button1_Click(object sender, EventArgs e)//我的信息窗口
        {
            uEmDetail f1 = new uEmDetail(ENum);
            f1.Show();
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            uSalary f1 = new uSalary(ENum);
            f1.Show();
            this.Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            uAttend f1 = new uAttend(ENum);
            f1.Show();
            this.Hide();
        }     

        private void Button4_Click(object sender, EventArgs e)
        {
            login f1 = new login();
            f1.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            updatePass uu = new updatePass(ENum);
            uu.Show();
            this.Hide();

        }

        private void uMainwindow_Load(object sender, EventArgs e)
        {

        }
    }
}
