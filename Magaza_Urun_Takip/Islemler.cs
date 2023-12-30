using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Magaza_Urun_Takip
{
    public partial class Islemler : Form
    {
        public Islemler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=MagazaUrunTakip;Integrated Security=True");
        private void Islemler_Load(object sender, EventArgs e)
        {
            
            SqlCommand komut = new SqlCommand("select * from TBLURUNLER", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbUrunler.ValueMember = "ID";
            cmbUrunler.DisplayMember = "AD";
            cmbUrunler.DataSource = dt;

            
            SqlCommand komut2 = new SqlCommand("select * from TBLMUSTERILER", baglanti);
            SqlDataAdapter da2 = new SqlDataAdapter(komut2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            cmbMusteri.ValueMember = "ID";
            cmbMusteri.DisplayMember = "ADSOYAD";
            cmbMusteri.DataSource = dt2;

            
            SqlCommand komut3 = new SqlCommand("select * from TBLPERSONELLER", baglanti);
            SqlDataAdapter da3 = new SqlDataAdapter(komut3);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            cmbPersonel.ValueMember = "ID";
            cmbPersonel.DisplayMember = "AD";
            cmbPersonel.DataSource = dt3;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Satis_Listesi fr = new Satis_Listesi();
            fr.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLHAREKETLER(URUN, MUSTERI, PERSONEL, FIYAT) values (@p1,@p2,@p3,@p4)", baglanti);
            komut.Parameters.AddWithValue("@p1", cmbUrunler.SelectedValue);
            komut.Parameters.AddWithValue("@p2", cmbMusteri.SelectedValue);
            komut.Parameters.AddWithValue("@p3", cmbPersonel.SelectedValue);
            komut.Parameters.AddWithValue("@p4", txtFiyat.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Satış kaydı oluşturuldu");
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cmbMusteri_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtFiyat_TextChanged(object sender, EventArgs e)
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

        private void cmbPersonel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
