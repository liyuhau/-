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
    public partial class insert_class : Form
    {
        public insert_class()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                DAL dal = new DAL();
                DataSet ds1 = new DataSet();
                ds1 = dal.course_Getall();
                listBox1.Items.Clear();//每次事件开始就清空控件
                for (int i = 0; i < ds1.Tables["cour"].Rows.Count; i++)
                {
                    listBox1.Items.Add(ds1.Tables["cour"].Rows[i][1].ToString());
                }
            }
            catch (Exception ee)
            { MessageBox.Show(ee.Message); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Course cour1 = new Course();
                cour1.Course_id = textBox1.Text;
                cour1.Course_name = textBox2.Text;
                cour1.course_year = textBox6.Text;
                cour1.course_period = textBox3.Text;
                cour1.course_cordit = textBox4.Text;
                cour1.course_describe = textBox5.Text;
                DAL dall = new DAL();
                DataSet ds1 = new DataSet();
                ds1 = dall.course_getbyname(textBox2.Text);
                if (ds1.Tables["s1"].Rows.Count > 0)  //如果dataset里第一张table里的数据大于一行（有数据)
                {
                    MessageBox.Show("此课程已存在,请重新输入");
                    textBox1.Text = "";
                }
                else
                {
                    if (dall.insert_course(cour1) > 0)
                    {
                        MessageBox.Show("已成功添加课程");
                    }
                    else
                    {
                        MessageBox.Show("添加课程失败");
                    }
                }
            }
            catch (Exception ee)
            { MessageBox.Show(ee.Message); }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Course cour1 = new Course();
                cour1.Course_id = textBox1.Text;
                cour1.Course_name = textBox2.Text;
                cour1.course_year = textBox6.Text;
                cour1.course_period = textBox3.Text;
                cour1.course_cordit = textBox4.Text;
                cour1.course_describe = textBox5.Text;
                DAL dall = new DAL();
                if (dall.update_course(cour1) > 0)
                {
                    MessageBox.Show("已更新课程信息");
                }
                else
                {
                    MessageBox.Show("修改课程信息失败");
                }
            }
            catch (Exception ee)
            { MessageBox.Show(ee.Message); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DAL dall = new DAL();
                if (dall.delete_course(textBox2.Text) > 0)
                {
                    MessageBox.Show("已成功删除此课程");
                }
                else
                {
                    MessageBox.Show("删除课程失败");
                }
            }
            catch (Exception ee)
            { MessageBox.Show(ee.Message); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            stumanage f2 = new stumanage();
            f2.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int item = comboBox1.SelectedIndex;
                string str = comboBox1.Items[item].ToString();
                DAL dal = new DAL();
                DataSet ds = new DataSet();
                ds = dal.course_getbyyear(str);
                listBox1.Items.Clear();
                for (int i = 0; i < ds.Tables["s"].Rows.Count; i++)
                {
                    listBox1.Items.Add(ds.Tables["s"].Rows[i][0].ToString());
                }
            }
            catch (Exception ee)
            { MessageBox.Show(ee.Message); }
        }
            

        private void insert_class_Load(object sender, EventArgs e)
        {
            skinEngine1.SkinFile = "WaveColor1.ssk";
            try
            {
                int k = 0;
                DAL dal = new DAL();
                DataSet ds1 = new DataSet();
                ds1 = dal.course_Getall();
                listBox1.Items.Clear();//每次事件开始就清空控件
                comboBox1.Items.Clear();
                for (int i = 0; i < ds1.Tables["cour"].Rows.Count; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (ds1.Tables["cour"].Rows[i][2].ToString() == ds1.Tables["cour"].Rows[j][2].ToString())
                        {
                            k++;
                        }

                    }
                    if (k == 0)
                    {
                        comboBox1.Items.Add(ds1.Tables["cour"].Rows[i][2].ToString());
                    
                    }
                    k = 0;
                }
            }
            catch (Exception ee)
            { MessageBox.Show(ee.Message); }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DAL dal = new DAL();
                DataSet ds1 = new DataSet();
                ds1 = dal.course_Getall();
                int item = listBox1.SelectedIndex;//选中listbox的一行
                if (item == -1)
                    item = 0;
                textBox2.Text = listBox1.Items[item].ToString();//把选中的一行给textbox1
                for (int i = 0; i < ds1.Tables["cour"].Rows.Count; i++)
                {
                    if (ds1.Tables["cour"].Rows[i][1].ToString() == textBox2.Text)
                    {
                        textBox1.Text = ds1.Tables["cour"].Rows[i][0].ToString();
                        textBox3.Text = ds1.Tables["cour"].Rows[i][3].ToString();
                        textBox4.Text = ds1.Tables["cour"].Rows[i][4].ToString();
                        textBox5.Text = ds1.Tables["cour"].Rows[i][5].ToString();
                        textBox6.Text = ds1.Tables["cour"].Rows[i][2].ToString();
                        break;
                    }
                }
            }
            catch (Exception ee)
            { MessageBox.Show(ee.Message); }
        }
    }
}
