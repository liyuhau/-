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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
           // Table();
        }

        private void ToolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void TabPage2_Click(object sender, EventArgs e)
        {

        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            mainwindow f1 = new mainwindow();
            f1.Show();
            this.Hide();
        }
        private void oneSch()
        {
            dataGridView1.Rows.Clear();
            string sql = "select *from Einfo where EmployeeNum='" + textBox1.Text + "'";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c, d, e, f;
                a = dr["EmployeeNum"].ToString();
                b = dr["Name"].ToString();
                c = dr["Gender"].ToString();
                d = dr["UnitNum"].ToString();
                f = dr["DataBirth"].ToString();
                e = dr["TheTitle"].ToString();

                string[] str = { a, b, c, d, f, e };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();
        }
       
        private void Table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select * from Einfo";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c, d, e,f;
                a = dr["EmployeeNum"].ToString();
                b = dr["Name"].ToString();
                c = dr["Gender"].ToString();
                d = dr["UnitNum"].ToString();
                f = dr["DataBirth"].ToString();
                e = dr["TheTitle"].ToString();
               
                string[] str = { a, b, c, d, f ,e};
                dataGridView1.Rows.Add(str);
            }
            dr.Close();
        }

        private void Button3_Click(object sender, EventArgs e)//添加
        {
            if(textBox2.Text==null|| textBox3.Text == null||textBox4.Text == null|| textBox5.Text == null||  textBox7.Text == null)
            {
                MessageBox.Show("输入不完整，请检查","提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string sql = "Insert into Einfo values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "',' 无','" + textBox7.Text + "');Insert into login1 values('" + textBox2.Text + "','123456','0');Insert into Pay values('4000','','','2020-12-30','4000','" + textBox2.Text + "')";
           
          
                Dao dao = new Dao();
                int i = dao.Excute(sql);
                if (i > 0) MessageBox.Show("添加成功");
                textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text =  textBox7.Text = null;
            }
           
        }

        private void Button2_Click(object sender, EventArgs e)//全部查询
        {
            
            Table();
        }


        private void Button4_Click(object sender, EventArgs e)//删除
        {
            DialogResult r = MessageBox.Show("确定要删除吗？","提示",MessageBoxButtons.OKCancel);
            if (r == DialogResult.OK)
            {
                string EmployeeNum, Name;
                EmployeeNum = dataGridView1.SelectedCells[0].Value.ToString();
                Name = dataGridView1.SelectedCells[1].Value.ToString();
                string sql = "delete from Einfo where EmployeeNum='" + EmployeeNum + "';delete from Leave where EmployeeNum = '" + EmployeeNum + "';delete from Pay where EmployeeNum = '" + EmployeeNum + "';delete from Attend where EmployeeNum = '" + EmployeeNum + "';delete from Reward where EmployeeNum = '" + EmployeeNum + "';delete from login1 where EmployeeNum = '" + EmployeeNum + "'; ";
                
                Dao dao = new Dao();
                dao.Excute(sql);
                Table();
            }
                
        }
     
        private void Button5_Click(object sender, EventArgs e)//将数据写入数组，传递到详情页
        {
            string[] str = { dataGridView1.SelectedCells[0].Value.ToString(),
                dataGridView1.SelectedCells[1].Value.ToString(),
                dataGridView1.SelectedCells[2].Value.ToString(),
                dataGridView1.SelectedCells[3].Value.ToString(),
                dataGridView1.SelectedCells[4].Value.ToString(),
                dataGridView1.SelectedCells[5].Value.ToString(),
        };
            EmDetail f1 = new EmDetail(str);
            f1.Show();
        }

        private void Button1_Click(object sender, EventArgs e)//单个查询
        {
            oneSch();
        }

        private void Employee_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
