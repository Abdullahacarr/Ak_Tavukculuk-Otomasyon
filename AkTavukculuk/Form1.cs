using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using System.Data.SqlClient;
using MaterialSkin;

namespace AkTavukculuk
{

    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
            txt_kadi.Clear();
            txt_ksifre.Clear();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            MaterialSkinManager msn = MaterialSkinManager.Instance;
            msn.AddFormToManage(this);
            msn.Theme = MaterialSkinManager.Themes.LIGHT;
            msn.ColorScheme = new ColorScheme(Primary.Pink100, Primary.Pink200, Primary.Pink100, Accent.Pink100, TextShade.BLACK);




        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-FJ3HBPC5\SQLEXPRESS;Initial Catalog=Dbo_Aktavuk;Integrated Security=True");

        public object AkTacukculuk { get; private set; }
        public static string name;
        public static int musyet;

        private void button1_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            string sql = "Select * From Tbl_Personel where per_gadi=@adi AND per_gsifre=@sifre";
            SqlParameter prm1 = new SqlParameter("adi", txt_kadi.Text.Trim());
            SqlParameter prm2 = new SqlParameter("sifre", txt_ksifre.Text.Trim());
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.Add(prm1);
            komut.Parameters.Add(prm2);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                SqlCommand kmt2 = new SqlCommand("Select * From Tbl_Personel Where per_gadi='" + txt_kadi.Text.Trim() + "' AND per_gsifre='" + txt_ksifre.Text.Trim() + "' and per_gor like '" + 0 + "' ", baglanti);
                SqlDataReader ok = kmt2.ExecuteReader();
                ok.Read();
                musyet = Convert.ToInt32(ok["per_yetgi"].ToString());
                ok.Close();
                name = txt_kadi.Text.Trim();
                Form2 frm2 = new Form2();
                frm2.Show();
                this.Hide();

            }

            else
            {
                label1.Visible = true;
                linkLabel1.Visible = true;
            }

            baglanti.Close();



        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


            txttc.Visible = true;
            txtyenisif.Visible = true;
            lbltc.Visible = true;
            lblyenisif.Visible = true;
            btndegis.Visible = true;
        }

        private void btndegis_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sql = "Select * From Tbl_Personel where per_tc=@tc and per_gor like '" + 0 + "' ";
            SqlParameter prm1 = new SqlParameter("tc", txttc.Text.Trim());
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.Add(prm1);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);

            SqlCommand kmt1 = new SqlCommand("select * from Tbl_Personel where per_tc= @a1 ", baglanti);
            
            kmt1.Parameters.AddWithValue("@a1", txttc.Text.Trim());
            SqlDataReader oku = kmt1.ExecuteReader();
            oku.Read();
            int fiyat = Convert.ToInt32(oku["per_id"].ToString());
            oku.Close();
            if (dt.Rows.Count > 0)
            {
                
                string sqlg = "update Tbl_Personel set per_gsifre='" + txtyenisif.Text + "' where per_id='"+fiyat+"' ";

                SqlCommand komut1 = new SqlCommand(sqlg, baglanti);
                komut1.ExecuteNonQuery();
                baglanti.Close();
                label2.Text = "Şifreniz başarıyla güncellenmiştir. Tekradan Giriş Yapabilirsiniz";
                label2.Visible = true;
                txtyenisif.Clear();
                txtyenisif.Clear();
                txttc.Visible = false;
                txtyenisif.Visible = false;
                lbltc.Visible = false;
                lblyenisif.Visible = false;
                btndegis.Visible = false;
                label3.Visible = false;
                label1.Visible = false;
                linkLabel1.Visible = false;


            }
            else
            {
                label3.Text = "Tc yanlış girilmiştir.Tekrar Deneyiniz..";
                label3.Visible = true;
            }


        }
    }
}
