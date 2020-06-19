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
    public partial class mainwindow : Form
    {
        public mainwindow()
        {
            InitializeComponent();
        }

        private void Mainwindow_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Employee f1= new Employee();
            f1.Show();
            this.Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Salary f1 = new Salary();
            f1.Show();
            this.Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Attend f1 = new Attend();
            f1.Show();
            this.Hide();
        }

        private void Mainwindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();//结束程序
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            login f1 = new login();
            f1.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            userInfo u1 = new userInfo();
            u1.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Depart d1 = new Depart();
            d1.Show();
            this.Hide();
        }
    }
}
