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
    public partial class insert_stu : Form
    {
        public insert_stu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DAL dall = new DAL();
                if (dall.delete_stuinfo(textBox2.Text) > 0)
                {
                    MessageBox.Show("已成功删除此学生");
                }
                else
                {
                    MessageBox.Show("删除学生失败");
                }
            }
            catch (Exception ee)
            { MessageBox.Show(ee.Message); }
        }

        private void insert_stu_Load(object sender, EventArgs e)
        {
            skinEngine1.SkinFile = "WaveColor1.ssk";
            try
            {
                int k=0;
                DAL dal = new DAL();
                DataSet ds1 = new DataSet();
                ds1 = dal.stu_Getall();
                listBox1.Items.Clear();//每次事件开始就清空控件
                comboBox1.Items.Clear();
                for (int i = 0; i < ds1.Tables["stu"].Rows.Count; i++)
                {
                    for (int j =0; j < i; j++)
                    {
                        if (ds1.Tables["stu"].Rows[i][6].ToString() == ds1.Tables["stu"].Rows[j][6].ToString())
                        {
                            k++;
                        }
                        
                    }
                    if(k==0)
                    {
                          comboBox1.Items.Add(ds1.Tables["stu"].Rows[i][6].ToString());
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
                DAL dal = new DAL();//要使用这个类里面的查找数据库的方法，所以先实例化
                DataSet ds1 = new DataSet();//查找代码以后查找到的表放在dataset里面，并且返回ds，所以这个也要实例化
                ds1 = dal.stu_Getall();//调用数据访问层的stu_Grtall（）这个方法，也是函数
                int item = listBox1.SelectedIndex;//选中listbox的一行
                if (item == -1)
                    item = 0;
                textBox2.Text = listBox1.Items[item].ToString();//把选中的一行给textbox1
                for (int i = 0; i < ds1.Tables["stu"].Rows.Count; i++)//ds1里面有个查找到的表，表名叫stu,在这个表里面i小于总行数，依次增加i
                {
                    if (ds1.Tables["stu"].Rows[i][1].ToString() == textBox2.Text)
                    {
                        textBox1.Text = ds1.Tables["stu"].Rows[i][0].ToString();//假如i=0，这行就是把查询到的名叫stu的表的第一行第一列的数据给textbox1.Text这个文本框
                        textBox3.Text = ds1.Tables["stu"].Rows[i][2].ToString();//和上面同理，
                        textBox4.Text = ds1.Tables["stu"].Rows[i][3].ToString();
                        textBox5.Text = ds1.Tables["stu"].Rows[i][4].ToString();
                        textBox6.Text = ds1.Tables["stu"].Rows[i][5].ToString();
                        textBox7.Text = ds1.Tables["stu"].Rows[i][6].ToString();
                        textBox8.Text = ds1.Tables["stu"].Rows[i][7].ToString();
                        textBox9.Text = ds1.Tables["stu"].Rows[i][8].ToString();
                        break;
                    }
                }
            }
            catch (Exception ee)
            { MessageBox.Show(ee.Message); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                DAL dal = new DAL();
                DataSet ds1 = new DataSet();
                ds1 = dal.stu_Getall();
                listBox1.Items.Clear();//每次事件开始就清空控件
                for (int i = 0; i < ds1.Tables["stu"].Rows.Count; i++)
                {
                    listBox1.Items.Add(ds1.Tables["stu"].Rows[i][1].ToString());
                }
            }
            catch (Exception ee)
            { MessageBox.Show(ee.Message); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Stuinfo stu1 = new Stuinfo();
                stu1.Stu_id = textBox1.Text;
                stu1.stu_name = textBox2.Text;
                stu1.stu_sex = textBox3.Text;
                stu1.stu_nation = textBox4.Text;
                stu1.stu_birrhday = textBox5.Text;
                stu1.stu_rutime = textBox6.Text;
                stu1.stu_class = textBox7.Text;
                stu1.stu_home = textBox8.Text;
                stu1.stu_else = textBox9.Text;
                DataSet ds1 = new DataSet();
                DAL dall = new DAL();
                ds1 = dall.stu_byid(textBox1.Text);
                if (ds1.Tables["t1"].Rows.Count > 0)  //如果dataset里第一张table里的数据大于一行（有数据)
                {
                    MessageBox.Show("此学号已被使用,请重新输入");
                    textBox1.Text = "";
                }
                else
                {
                    if (dall.insert_stuinfo(stu1) > 0)
                    {
                        MessageBox.Show("已成功添加学生信息");
                    }
                    else
                    {
                        MessageBox.Show("添加学生信息失败");
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
                Stuinfo stu1 = new Stuinfo();
                stu1.Stu_id = textBox1.Text;
                stu1.stu_name = textBox2.Text;
                stu1.stu_sex = textBox3.Text;
                stu1.stu_nation = textBox4.Text;
                stu1.stu_birrhday = textBox5.Text;
                stu1.stu_rutime = textBox6.Text;
                stu1.stu_class = textBox7.Text;
                stu1.stu_home = textBox8.Text;
                stu1.stu_else = textBox9.Text;
                DAL dall = new DAL();
                if (dall.update_stuinfo(stu1) > 0)
                {
                    MessageBox.Show("已更新学生信息");
                }
                else
                {
                    MessageBox.Show("修改学生信息失败");
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
                DataSet ds= new DataSet();
                ds = dal.stu_byclass(str);
                listBox1.Items.Clear();
                for (int i = 0; i < ds.Tables["t"].Rows.Count; i++)
                {
                    listBox1.Items.Add(ds.Tables["t"].Rows[i][0].ToString());
                }
            }
            catch (Exception ee)
            { MessageBox.Show(ee.Message); }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                DAL dal = new DAL();
                DataSet ds = new DataSet();
                ds = dal.stu_byid(textBox10.Text);
                listBox1.Items.Clear();
                listBox1.Items.Add(ds.Tables["t1"].Rows[0][1].ToString());
            }
            catch (Exception ee)
            { MessageBox.Show(ee.Message); }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
