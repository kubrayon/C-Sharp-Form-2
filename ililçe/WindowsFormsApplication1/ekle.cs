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
    public partial class ekle : Form
    {
        internal static ekle frm2;

        public ekle()
        {
            InitializeComponent();
        }

        private void ekle_Load(object sender, EventArgs e)
        {
            dgwilyukle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ilekle();
            dgwilyukle();

        }
        public void ilekle()
        {
            SqlConnection bag = new SqlConnection("server=PC-BILGISAYAR\\SQLEXPRESS; initial catalog=iller; integrated security=true;");
            SqlCommand komut = new SqlCommand("insert into iller (iller) values ('" + textBox1.Text + "');", bag);
            bag.Open();
            komut.ExecuteNonQuery();
            bag.Close();
        }
        public void dgwilyukle()
        {
            SqlConnection bag = new SqlConnection("server=PC-BILGISAYAR\\SQLEXPRESS; initial catalog=iller; integrated security=true;");
            SqlDataAdapter da = new SqlDataAdapter("select*from iller order by iller asc;", bag);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int secilenid = (int)(dataGridView1.CurrentRow.Cells[0].Value);
            SqlConnection bag = new SqlConnection("server=PC-BILGISAYAR\\SQLEXPRESS; initial catalog=iller; integrated security=true;");
            SqlCommand komut = new SqlCommand("delete from iller where id=@numara", bag);
            komut.Parameters.AddWithValue("@numara", secilenid);
            bag.Open();
            komut.ExecuteNonQuery();
            bag.Close();
            dgwilyukle();

        }
    }
}
