using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_Sell
{
    public partial class Change : Form
    {
        public Change()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DAL dal = new DAL();
            DataSet ds = new DataSet();
            ds = dal.select_orderbyNo(textBox1.Text);
            if(ds.Tables["No"].Rows.Count>0)
            {
                Change2 change = new Change2();
                change.aa(textBox1.Text);
                this.Hide();
                change.Show();
            }
            else
            {
                MessageBox.Show("没有此订单，请确认订单编号是否输入正确！");
            }
        }

        private void Change_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            denglu denglu = new denglu();
            this.Hide();
            denglu.Show();
        }
    }
}
