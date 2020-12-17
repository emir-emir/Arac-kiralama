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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection(" Data Source=ASUS\\SQLEXPRESS;Initial Catalog=Araç_Kiralama_ödev;Integrated Security=True");
      

       

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komutsil = new SqlCommand("Delete From  Sözleşme  where ID=@ID ", baglantı);
            komutsil.Parameters.AddWithValue("@ID", txtId.Text);
            komutsil.ExecuteNonQuery();
            baglantı.Close();
          
           
        }

        private void btnListele_Click(object sender, EventArgs e)
        {

            SqlDataAdapter da = new SqlDataAdapter("select * from Sözleşme", baglantı);

            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            baglantı.Open();

            SqlCommand kayıtekle = new SqlCommand("insert into Sözleşme (ID,Ad,Soyad,Ehliyet_sınıfı,Kira_ücreti,kullanım_süresi) values (@S1,@S2,@S3,@S4,@S5,@S6)", baglantı);
            kayıtekle.Parameters.AddWithValue("@S1", txtId.Text);
            kayıtekle.Parameters.AddWithValue("@S2", txtAd.Text);
            kayıtekle.Parameters.AddWithValue("@S3", txtSoyad.Text);
            kayıtekle.Parameters.AddWithValue("@S4", txtEhliyet.Text);
            kayıtekle.Parameters.AddWithValue("@S5", txtKira.Text);
            kayıtekle.Parameters.AddWithValue("@S6", txtKullanımSüresi.Text);
            kayıtekle.ExecuteNonQuery();


            baglantı.Close();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtEhliyet.Text = "";
            txtKira.Text = "";
            txtKullanımSüresi.Text = "";

           
          
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komutguncellee = new SqlCommand("update Sözleşme set ID=@S1,Ad=@S2,Soyad=@S3,Ehliyet_Sınıfı=@S4,Kira_ücreti=@S5,kullanım_süresi=@S6 where ID=@S1", baglantı);
            komutguncellee.Parameters.AddWithValue("@S1", txtId.Text);
            komutguncellee.Parameters.AddWithValue("@S2", txtAd.Text);
            komutguncellee.Parameters.AddWithValue("@S3", txtSoyad.Text );
            komutguncellee.Parameters.AddWithValue("@S4", txtEhliyet.Text );
            komutguncellee.Parameters.AddWithValue("@S5", txtKira.Text );
            komutguncellee.Parameters.AddWithValue("@S6", txtKullanımSüresi.Text );

            komutguncellee.ExecuteNonQuery();
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
            txtAd.Text = satır1;
            txtSoyad.Text = satır2;
            txtEhliyet.Text = satır3;
            txtKira.Text = satır4;
            txtKullanımSüresi.Text = satır5;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sayi1, sayı2, toplam = 0;
            sayi1 = Convert.ToInt32(txtKira.Text);
            sayı2 = Convert.ToInt32(txtKullanımSüresi.Text);
            toplam = sayi1 * sayı2;
            MessageBox.Show("TOPLAM ÜCRET ="+ toplam);


        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
