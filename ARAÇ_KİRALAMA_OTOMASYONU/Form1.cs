using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ARAÇ_KİRALAMA_OTOMASYONU
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=ASUS\\SQLEXPRESS;Initial Catalog=Araç_Kiralama_ödev;Integrated Security=True");
    

        private void btnAraçKayıt_Click(object sender, EventArgs e)
        {
            Form3 ekle = new Form3();
            ekle.ShowDialog();
        }


        private void btnAraçSözleşme_Click(object sender, EventArgs e)
        {
            Form4 ekle = new Form4();
            ekle.ShowDialog();
        }

        private void btnÇıkış_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

      

      

        private void btnMüşteriEkleme_Click_1(object sender, EventArgs e)
        {
              Form2 ekle = new Form2();
            ekle.ShowDialog();
        
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {

        }

       
    }
}
