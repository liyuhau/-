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
    public partial class userInfo : Form
    {
        public userInfo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select EmployeeNum from login1";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            listBox1.Items.Clear();
            while (dr.Read())
            {
                listBox1.Items.Add(dr["EmployeeNum"].ToString());
            }
            dr.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select * from login1 ";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            int item = listBox1.SelectedIndex;//选中listbox的一行
            if (item == -1)
                item = 0;
            textBox1.Text = listBox1.Items[item].ToString();
            while(dr.Read())
            {
                if(textBox1.Text== dr["EmployeeNum"].ToString())
                {
                    textBox2.Text = dr["UserPass"].ToString();
                    textBox3.Text = dr["level"].ToString();
                }
            }
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            string sql = "update login1 set UserPass='" + textBox2.Text + " 'where EmployeeNum = '" + textBox1.Text + "'update login1 set level='" + textBox3.Text + " 'where EmployeeNum = '" + textBox1.Text + "' ";
            Dao dao = new Dao();
            int k = dao.Excute(sql);
            if (k > 0) MessageBox.Show("修改成功");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mainwindow  m1 = new mainwindow();
            m1.Show();
            this.Hide();
        }

        private void userInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
