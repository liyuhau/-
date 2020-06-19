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
    public partial class Change2 : Form
    {
        private string pp;
        public void aa(string ss)
        {
            pp = ss;
        }
        public Change2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                OrderInfo or1 = new OrderInfo();
                or1.OrderNo = pp;
                or1.CustomerNum = textBox2.Text;
                or1.Data = textBox3.Text;
                or1.Price = textBox4.Text;
                or1.OrderInvoice = textBox5.Text;
                DAL dall = new DAL();
                if (dall.update_orderInfo(or1) > 0)
                {
                    MessageBox.Show("修改订单信息成功");
                    denglu deng = new denglu();
                    this.Hide();
                    deng.Show();
                }
                else
                {
                    MessageBox.Show("修改订单信息失败");
                }

            }
            catch (Exception ee)
            { MessageBox.Show(ee.Message); }
            
        }

        private void Change2_Load(object sender, EventArgs e)
        {
               textBox1.Text=pp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            denglu denglu = new denglu();
            this.Hide();
            denglu.Show();
        }
    }
}
