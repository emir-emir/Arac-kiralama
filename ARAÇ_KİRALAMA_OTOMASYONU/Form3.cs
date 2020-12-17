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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=ASUS\\SQLEXPRESS;Initial Catalog=Araç_Kiralama_ödev;Integrated Security=True");

        private void btnEkle_Click(object sender, EventArgs e)
        {
            baglantı.Open();

            SqlCommand kayıtekle = new SqlCommand("insert into Arac_bilgileri (ID,Marka,Model,Renk,Plaka,Km) values (@A1,@A2,@A3,@A4,@A5,@A6)", baglantı);
            kayıtekle.Parameters.AddWithValue("@A1", txtId.Text);
            kayıtekle.Parameters.AddWithValue("@A2", txtMarka.Text);
            kayıtekle.Parameters.AddWithValue("@A3", txtModel.Text);
            kayıtekle.Parameters.AddWithValue("@A4", txtRenk.Text);
            kayıtekle.Parameters.AddWithValue("@A5", txtPlaka.Text);
            kayıtekle.Parameters.AddWithValue("@A6", txtKm.Text);
            kayıtekle.ExecuteNonQuery();
            baglantı.Close();
           
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
         
            SqlDataAdapter da = new SqlDataAdapter("select * from Arac_bilgileri", baglantı);

            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtMarka.Text = "";
            txtModel.Text="";
            txtRenk.Text="";
            txtPlaka.Text = "";
            txtKm.Text = "";

        }

        private void btnSilme_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komutsil = new SqlCommand("Delete From  Arac_bilgileri  where ID=@ID ", baglantı);
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
            txtMarka.Text = satır1;
            txtModel.Text = satır2;
            txtRenk.Text = satır3;
            txtPlaka.Text = satır4;
            txtKm.Text = satır5;
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
             baglantı.Open();
             SqlCommand komutguncellee = new SqlCommand("update Arac_bilgileri set ID=@A1,Marka=@A2,Model=@A3,Renk=@A4,Plaka=@A5,Km=@A6 where ID=@A1", baglantı);
            komutguncellee.Parameters.AddWithValue("@A1",txtId.Text);
            komutguncellee.Parameters.AddWithValue("@A2", txtMarka.Text );
            komutguncellee.Parameters.AddWithValue("@A3", txtModel.Text);
            komutguncellee.Parameters.AddWithValue("@A4", txtRenk.Text);
            komutguncellee.Parameters.AddWithValue("@A5", txtPlaka.Text);
            komutguncellee.Parameters.AddWithValue("@A6",txtKm.Text );
           
            komutguncellee.ExecuteNonQuery();
            baglantı.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
       
    }
}

 