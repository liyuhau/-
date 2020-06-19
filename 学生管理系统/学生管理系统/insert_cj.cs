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
    public partial class insert_cj : Form
    {
        public insert_cj()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int item = comboBox1.SelectedIndex;
                string str = comboBox1.Items[item].ToString();
                DAL dal = new DAL();
                DataSet ds = new DataSet();
                ds = dal.stu_choose_getbycourse_name(str);
                listBox1.Items.Clear();
                for (int i = 0; i < ds.Tables["s2"].Rows.Count; i++)
                {
                    listBox1.Items.Add(ds.Tables["s2"].Rows[i][1].ToString());
                }
            }
            catch (Exception ee)
            { MessageBox.Show(ee.Message); }
        }

        private void insert_cj_Load(object sender, EventArgs e)
        {
            skinEngine1.SkinFile = "WaveColor1.ssk";
            try
            {
                DAL dal = new DAL();
                DataSet ds1 = new DataSet();
                ds1 = dal.course_Getall();
                listBox1.Items.Clear();//每次事件开始就清空控件
                comboBox1.Items.Clear();
                for (int i = 0; i < ds1.Tables["cour"].Rows.Count; i++)
                {
                       comboBox1.Items.Add(ds1.Tables["cour"].Rows[i][1].ToString());
                
                }
            }
            catch (Exception ee)
            { MessageBox.Show(ee.Message); }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
                textBox2.Text = listBox1.Items[item].ToString();//把选中的一行给textbox2
                int item1 = comboBox1.SelectedIndex;
                textBox3.Text = comboBox1.Items[item1].ToString();
                ds1 = dal.choose_course_getall();
                for (int i = 0; i < ds1.Tables["sd"].Rows.Count; i++)
                {
                    if (ds1.Tables["sd"].Rows[i][1].ToString() == textBox2.Text&& ds1.Tables["sd"].Rows[i][3].ToString() == textBox3.Text)
                    {
                        textBox1.Text = ds1.Tables["sd"].Rows[i][0].ToString();
                        textBox6.Text = ds1.Tables["sd"].Rows[i][2].ToString();                       
                        textBox4.Text = ds1.Tables["sd"].Rows[i][4].ToString();
                        textBox5.Text = ds1.Tables["sd"].Rows[i][5].ToString();
                        break;
                    }
                }
            }
            catch (Exception ee)
            { MessageBox.Show(ee.Message); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DAL dall = new DAL();
                if (dall.stu_choose_course_update(textBox4.Text, textBox3.Text,textBox2.Text) > 0)
                {
                    MessageBox.Show("已成功添加成绩");
                }
                else
                {
                    MessageBox.Show("添加成绩失败");
                }
            }
            catch (Exception ee)
            { MessageBox.Show(ee.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            stumanage f2 = new stumanage();
            f2.Show();
        }
    }
}
