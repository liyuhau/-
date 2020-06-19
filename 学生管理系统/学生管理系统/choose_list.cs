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
    public partial class choose_list : Form
    {
        private string bb,ss;
        public choose_list()
        {
            InitializeComponent();
        }
        public void usernamebb(string pp,string dd)
        {
            bb = pp;
            ss = dd;
        }
        private void choose_list_Load(object sender, EventArgs e)
        {
            skinEngine1.SkinFile = "WaveColor1.ssk";
            try
            {
                DAL dal = new DAL();
                DataSet ds1 = new DataSet();
                ds1 = dal.stu_choose_getbystu_id(bb);
                listBox1.Items.Clear();//每次事件开始就清空控件
                for (int i = 0; i < ds1.Tables["ct"].Rows.Count; i++)
                {
                     listBox1.Items.Add(ds1.Tables["ct"].Rows[i][0].ToString());
                }
            }
            catch (Exception ee)
            { MessageBox.Show(ee.Message); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            choose_class f11 = new choose_class();
            f11.usernamebb(bb,ss);
            f11.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DAL dal = new DAL();
                DataSet ds1 = new DataSet();
                int item = listBox1.SelectedIndex;//选中listbox的一行
                if (item == -1)
                    item = 0;
                textBox2.Text = listBox1.Items[item].ToString();//把选中的一行数据给textbox1
                ds1 = dal.course_Getall();
                for (int i = 0; i < ds1.Tables["cour"].Rows.Count; i++)
                {
                    if (ds1.Tables["cour"].Rows[i][1].ToString() == textBox2.Text)
                    {
                        textBox1.Text = ds1.Tables["cour"].Rows[i][0].ToString();
                        textBox3.Text = ds1.Tables["cour"].Rows[i][2].ToString();
                        textBox4.Text = ds1.Tables["cour"].Rows[i][3].ToString();
                        textBox5.Text = ds1.Tables["cour"].Rows[i][4].ToString();
                        textBox6.Text = ds1.Tables["cour"].Rows[i][5].ToString();
                        break;
                    }
                }
            }
            catch (Exception ee)
            { MessageBox.Show(ee.Message); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            stuinfo f8 = new stuinfo();
            f8.usernamebb(bb);
            f8.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            select_grade f10 = new select_grade();
            f10.usernamebb(bb);
            f10.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            update_pass f12 = new update_pass();
            f12.usernamebb(bb,ss);
            f12.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
