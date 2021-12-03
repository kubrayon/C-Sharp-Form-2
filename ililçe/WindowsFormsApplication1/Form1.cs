using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private object frm2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.Text = "İller V1.0";
            this.BackColor = Color.Aquamarine;
            this.Font = new Font("Tahoma", 12, FontStyle.Bold);

            sehiryukle();
        
        }

        public void sehiryukle ()
        {
            SqlConnection bag = new SqlConnection("server=PC-BILGISAYAR\\SQLEXPRESS; initial catalog=iller; integrated security=true;");
            SqlDataAdapter da = new SqlDataAdapter("select*from iller order by iller asc;", bag);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            comboBox1.DataSource = tablo;
            comboBox1.DisplayMember = "iller";
            comboBox1.ValueMember = "id";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection bag = new SqlConnection("server=PC-BILGISAYAR\\SQLEXPRESS; initial catalog=iller; integrated security=true;");
            SqlDataAdapter da = new SqlDataAdapter("select*from ilceler where sehir='"+ comboBox1.SelectedValue+"'", bag);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            comboBox2.DataSource = tablo;
            comboBox2.DisplayMember = "ilceler";
            comboBox2.ValueMember = "id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ekle frm2 = new ekle();
            frm2.Show();
        }
    }
}
