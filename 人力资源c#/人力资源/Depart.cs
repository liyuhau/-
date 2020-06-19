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
    public partial class Depart : Form
    {
        public Depart()
        {
            InitializeComponent();
        }     
        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.OKCancel);
            if (r == DialogResult.OK)
            {
                int item = dataGridView1.CurrentRow.Index;
                string str = dataGridView1.Rows[item].Cells[0].Value.ToString();
                string sql = "update Einfo set UnitNum='无' where EmployeeNum='" + str + "'";
                Dao dao = new Dao();
                int k = dao.Excute(sql);
                if (k > 0) MessageBox.Show("此人已成功从此部门删除！");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string sql = "select EmployeeNum,Name,Gender,DataBirth,TheTitle from  Einfo where UnitNum='" + textBox1.Text + "'";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c, d,k;
                a = dr["EmployeeNum"].ToString();
                b= dr["Gender"].ToString();
                c= dr["Name"].ToString();
                d = dr["DataBirth"].ToString();
                k = dr["TheTitle"].ToString();

                string[] str = { a, b, c, d, k };
                dataGridView1.Rows.Add(str);
            }
        }

        private void Depart_Load(object sender, EventArgs e)
        {
            string sql = "select DepartName from Depart";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["DepartName"].ToString());
                comboBox2.Items.Add(dr["DepartName"].ToString());
            }
            dr.Close();
            string sql1 = "select *from Depart";
            IDataReader dr1= dao.read(sql1);
            while (dr1.Read())
            {
                string a, b;
                a = dr1["DepartName"].ToString();
                b = dr1["DepartNum"].ToString();
                string[] str = { a, b };
                dataGridView3.Rows.Add(str);
            }
            dr.Close();
        } 

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int item = comboBox1.SelectedIndex;
            string str = comboBox1.Items[item].ToString();
            string sql = "select DepartNum from Depart where DepartName='" + str + "'";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                textBox1.Text = dr["DepartNum"].ToString();
            }
            dr.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainwindow m1 = new mainwindow();
            m1.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            string sql = "select EmployeeNum,Name,UnitNum from Einfo where EmployeeNum='" + textBox2.Text + "'";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {string a, b, c;
                a = dr["EmployeeNum"].ToString();
                b = dr["Name"].ToString();
                c = dr["UnitNum"].ToString();
                string[] str = { a, b, c };
                dataGridView2.Rows.Add(str);
            }
            dr.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int item = comboBox2.SelectedIndex;
            string str = comboBox2.Items[item].ToString();
            string sql = "select DepartNum from Depart where DepartName='" + str + "'";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                textBox3.Text = dr["DepartNum"].ToString();
            }
            dr.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("确定要调动吗？", "提示", MessageBoxButtons.OKCancel);
            if (r == DialogResult.OK)
            {
                int item = dataGridView2.CurrentRow.Index;
                string str = dataGridView2.Rows[item].Cells[0].Value.ToString();
                string sql = "update Einfo set UnitNum='" + textBox3.Text+ "' where EmployeeNum='" + str + "'";
                Dao dao = new Dao();
                int k = dao.Excute(sql);
                if (k > 0) MessageBox.Show("此人已成功调动部门！");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            mainwindow m1 = new mainwindow();
            m1.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            mainwindow m1 = new mainwindow();
            m1.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string sql = "update Depart set DepartName='" + textBox5.Text + " 'where DepartNum = '" + textBox4.Text + "' ";
            Dao dao = new Dao();
            int k = dao.Excute(sql);
            if (k > 0) MessageBox.Show("修改成功");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string sql = "delete from Depart where DepartNum='" + textBox4.Text + "'";
            Dao dao = new Dao();
            int kk = dao.Excute(sql);
            if (kk > 0) MessageBox.Show("删除成功");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "insert into Depart values('" + textBox5.Text + " ','" + textBox4.Text + " ')";
            Dao dao = new Dao();
            int k = dao.Excute(sql);
            if (k > 0) MessageBox.Show("添加成功");
        }
        private void button11_Click(object sender, EventArgs e)//全部查找
        {
            dataGridView2.Rows.Clear();
            string sql = "select EmployeeNum,Name,UnitNum from Einfo ";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c;
                a = dr["EmployeeNum"].ToString();
                b = dr["Name"].ToString();
                c = dr["UnitNum"].ToString();
                string[] str = { a, b, c };
                dataGridView2.Rows.Add(str);
            }
            dr.Close();
        }
    }
}
