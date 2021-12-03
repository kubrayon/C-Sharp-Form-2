using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kubrayon2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("TC Kimlik No", 150);
            listView1.Columns.Add("Ad Soyad", 200);
            listView1.Columns.Add("Mezuniyeti", 150);
            listView1.Columns.Add("Diller", 150);

            string[] mezuniyet = { "İlköğretim", "Ortaöğretim", "Lise", "ÖnLisans", "Lisans", "Doktora" };
            comboBox1.Items.AddRange(mezuniyet);


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_kaydet(object sender, EventArgs e)
        {
            string tc = "", adsoyad = "", mezuniyet = "", diller = "";
            tc = textBox1.Text; adsoyad = textBox2.Text; mezuniyet = comboBox1.Text;
            if (checkBox1.Checked == true)
                diller += checkBox1.Text +" ";
          if (checkBox2.Checked == true)
                diller += checkBox2.Text +" ";
          if (checkBox3.Checked == true)
                diller += checkBox3.Text +" ";
            string[] bilgiler = {tc,adsoyad,mezuniyet,diller };
            bool kayitkontrol = false;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[0].Text == textBox1.Text)
                {
                    kayitkontrol = true;
                }
            }
            if (kayitkontrol == true)
            {
                MessageBox.Show("Girilen Tc kimlik numarası kayıtlarda mevcut.");
            }
            else
            {
                ListViewItem liste = new ListViewItem(bilgiler);
                listView1.Items.Add(liste);
            }
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void sil_Click(object sender, EventArgs e)
        {
            int secilen = listView1.CheckedItems.Count;
            foreach (ListViewItem secilenkayit in listView1.CheckedItems)
            {
                secilenkayit.Remove();
            }
        }

        private void tum_sil_Click(object sender, EventArgs e)
        {
            listView1.Clear();
        }

        private void yenikayit_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;  textBox2.Text = null;
            checkBox1.CheckState = CheckState.Unchecked;
            checkBox2.CheckState = CheckState.Unchecked;
            checkBox3.CheckState = CheckState.Unchecked;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[0].Text == textBox1.Text)
                {
                    textBox2.Text = listView1.Items[i].SubItems[1].Text;
                    comboBox1.Text = listView1.Items[i].SubItems[2].Text;
                    string dil = "";
                    string[] diller = { "İngilizce", "Arapça", "Rusça" };
                    foreach (var item in listView1.Items[i].SubItems[3].Text)
                    {
                        if (item.ToString() != " ")
                        {
                            dil += item.ToString();
                        }
                        else
                        {
                            switch (dil)
                            {
                                case "İngilizce":
                                    checkBox1.CheckState = CheckState.Checked;
                                    break;
                                case "Arapça":
                                    checkBox2.CheckState = CheckState.Checked;
                                    break;
                                case "Rusça":
                                    checkBox3.CheckState = CheckState.Checked;
                                    break;
                            }
                            dil = "";
                        }
                    }
                    MessageBox.Show("Mevcut kayıt getirildi.");
                }
            }
        }
    }
}
