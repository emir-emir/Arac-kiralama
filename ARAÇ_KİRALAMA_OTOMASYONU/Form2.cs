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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=ASUS\\SQLEXPRESS;Initial Catalog=Araç_Kiralama_ödev;Integrated Security=True");
       
      

     

        private void btnListele_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from müŞteri", baglantı);

            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            baglantı.Open();

            SqlCommand kayıtekle = new SqlCommand("insert into Müşteri (ID,Tc,Adi,Soyadi,Telefon,Adres) values (@m1,@m2,@m3,@m4,@m5,@m6)", baglantı);
            kayıtekle.Parameters.AddWithValue("@m1",txtId.Text);
            kayıtekle.Parameters.AddWithValue("@m2",  txtTc.Text);
            kayıtekle.Parameters.AddWithValue("@m3", txtAd.Text );
            kayıtekle.Parameters.AddWithValue("@m4", txtSoyad.Text);
            kayıtekle.Parameters.AddWithValue("@m5", txtTelefon.Text);
            kayıtekle.Parameters.AddWithValue("@m6", txtAdres .Text);
            kayıtekle.ExecuteNonQuery();


            baglantı.Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komutsil = new SqlCommand("Delete From  Müşteri  where ID=@ID ", baglantı);
            komutsil.Parameters.AddWithValue("@ID", txtId.Text);
            komutsil.ExecuteNonQuery();
            baglantı.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            string satır = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            string satır1 = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            string satır2 = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            string satır3 = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            string satır4 = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            string satır5 = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtId.Text = satır;
            txtTc.Text = satır1;
            txtAd.Text = satır2;
            txtSoyad.Text = satır3;
            txtTelefon.Text = satır4;
            txtAdres.Text = satır5;
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komutguncellee = new SqlCommand("update Müşteri set ID=@M1,Tc=@M2,Adi=@M3,Soyadi=@M4,Telefon=@M5,Adres=@M6 where ID=@M1", baglantı);
            komutguncellee.Parameters.AddWithValue("@M1",txtId.Text);
            komutguncellee.Parameters.AddWithValue("@M2", txtTc.Text);
            komutguncellee.Parameters.AddWithValue("@M3",txtAd.Text );
            komutguncellee.Parameters.AddWithValue("@M4",txtSoyad.Text );
            komutguncellee.Parameters.AddWithValue("@M5",txtTelefon.Text );
            komutguncellee.Parameters.AddWithValue("@M6",txtAdres.Text);
           
            komutguncellee.ExecuteNonQuery();
            baglantı.Close();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtTc.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtTelefon.Text = "";
            txtAdres.Text = "";


        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

      

       
    }
}
