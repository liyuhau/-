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
    public partial class uEmDetail : Form
    {
        string NumD;
        public uEmDetail()
        {
            InitializeComponent();
        }
        public uEmDetail(string ENum)
        {
            NumD = ENum;
            InitializeComponent();
            textBox1.Text = NumD;
            string sql = "select Einfo.*,Totalmoney from Einfo, Pay where Einfo.EmployeeNum = Pay.EmployeeNum and Pay.EmployeeNum = '" + textBox1.Text + "'";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string b, c, d, e, f,z;

                b = dr["Name"].ToString();
                c = dr["Gender"].ToString();
                f = dr["UnitNum"].ToString();
                d = dr["DataBirth"].ToString();
                e = dr["TheTitle"].ToString();
                z = dr["Totalmoney"].ToString();
               // y= dr["Attenday"].ToString();
                textBox2.Text = b;
                textBox3.Text = c;
                textBox4.Text = d;
                textBox5.Text = f;
                textBox6.Text = e;
                textBox7.Text = z;
               // textBox8.Text = y;

            }
            dr.Close();
          
        }
      
        private void Button2_Click(object sender, EventArgs e)
        {
          
            uMainwindow f1 = new uMainwindow(NumD);
            f1.Show();
            this.Close();


        }    
    }
}
