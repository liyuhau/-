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
    public partial class choose_class : Form
    {
        string bb,ss;
        public choose_class()
        {
            InitializeComponent();
        }
        public void usernamebb(string pp,string dd)
        {
            bb = pp;
            ss = dd;
        }
        private void choose_class_Load(object sender, EventArgs e)
        {
            skinEngine1.SkinFile = "WaveColor1.ssk";
            try
            {
                DAL dal = new DAL();
                DataSet ds1 = new DataSet();
                ds1 = dal.course_Getall();
                dataGridView1.DataSource = ds1.Tables["cour"]; 
            }
            catch (Exception ee)
            { MessageBox.Show(ee.Message); }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            choose_list f9 = new choose_list();
            f9.usernamebb(bb,ss);
            f9.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            stuinfo f8 = new stuinfo();
            f8.usernamebb(bb);
            f8.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            choose_list f9 = new choose_list();
            f9.usernamebb(bb, ss);
            f9.Show();
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
            try
            {
                int flag = 0;
                int item = dataGridView1.CurrentRow.Index;
                string str1 = dataGridView1.Rows[item].Cells[0].Value.ToString();
                string str2 = dataGridView1.Rows[item].Cells[1].Value.ToString();
                string str3 = dataGridView1.Rows[item].Cells[2].Value.ToString();
                choose_course choo1 = new choose_course();
                choo1.Course_id = str1;
                choo1.Stu_id = bb;
                choo1.stu_name = ss;
                choo1.Course_name = str2;
                choo1.Student_grade = "-1";
                choo1.course_year = str3;
                DAL dal = new DAL();
                DataSet ds1 = new DataSet();
                ds1 = dal.stu_choose_getbystu_id(bb);
                for (int i = 0; i < ds1.Tables["ct"].Rows.Count; i++)
                {
                    if(ds1.Tables["ct"].Rows[i][0].ToString()==str2)
                    {
                        MessageBox.Show("此课程已在您需要学习的课程中，请添加其他课程");
                        flag = 1;
                        break;
                    }
                }
                if(flag==0)
                {
                    if (dal.stu_choose_course_insert(choo1)>0)
                    {
                        MessageBox.Show("此课程已成功添加到您要学习的课程中，请进入课程信息查看");
                    }
                    else
                    {
                        MessageBox.Show("添加课程失败，请重新选中添加");
                    }
                }

            }
            catch (Exception ee)
            { MessageBox.Show(ee.Message); }

        }
    }
}
