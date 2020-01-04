using DevExpress.XtraTab;
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
using DevExpress.XtraNavBar;

namespace AkTavukculuk
{
    public partial class Form2 : MaterialForm
    {
        int ab = 0;
        public Form2()
        {
            InitializeComponent();

        }
        private void Form2_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Program Kapatılsın mı ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void xtanatab_CloseButtonClick(object sender, EventArgs e)
        {
            if (xtanatab.SelectedTabPage != anasayfa)
            {
                xtanatab.SelectedTabPage.PageVisible = false;
            }


        }
        private void Form2_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            string sqll = "select sip_müsteriad,sip_müsteridad,sip_urun,sip_kilo,sip_tarih  from Tbl_Siparis where sip_tarih='" + DateTime.Today.ToString("yyyy-MM-dd") + "' and sip_gorunum like '" + 0 + "' and sip_durum like '" + 1 + "' and sip_durdep like '" + 1 + "'  and sip_duryol='"+0+"'";
            SqlDataAdapter daa = new SqlDataAdapter(sqll, baglanti);
            DataSet ds = new DataSet();
            daa.Fill(ds);
            data_anasayfa.DataSource = ds.Tables[0];
            data_anasayfa.Columns[1].HeaderText = "Müşteri Adı";
            data_anasayfa.Columns[2].HeaderText = "Dükkan İsim";
            data_anasayfa.Columns[3].HeaderText = "Ürün";
            data_anasayfa.Columns[4].HeaderText = "Miktar";
            data_anasayfa.Columns[5].HeaderText = "Tarih";
            baglanti.Close();

            string ay = DateTime.Now.Month.ToString();

            foreach (XtraTabPage item in xtanatab.TabPages)
            {
                if (item.Name != "anasayfa" || item.Name == "gelirgide")
                {
                    item.PageVisible = false;
                }
            }
            xtraTabControl1.TabPages[0].Text = Form1.name;

            
            switch (Form1.musyet)
            {
                case 0:
                    NavBarGroup group20 = navBarControl2.Groups[7];
                    group20.Visible = true;
                    break;
                case 1:
                    NavBarGroup group = navBarControl2.Groups[4];
                    group.Visible = false;
                    NavBarGroup group18 = navBarControl2.Groups[7];
                    group18.Visible = false;
                    break;
                case 2:
                    NavBarGroup group1 = navBarControl2.Groups[0];
                    group1.Visible = false;
                    NavBarGroup group2 = navBarControl2.Groups[2];
                    group2.Visible = false;
                    NavBarGroup group3 = navBarControl2.Groups[3];
                    group3.Visible = false;
                    NavBarGroup group4 = navBarControl2.Groups[4];
                    group4.Visible = false;
                    NavBarGroup group5 = navBarControl2.Groups[5];
                    group5.Visible = false;
                    NavBarGroup group17 = navBarControl2.Groups[7];
                    group17.Visible = false;

                    break;
                case 3:
                    ab = 1;
                    NavBarGroup group6 = navBarControl2.Groups[3];
                    group6.Visible = false;
                    NavBarGroup group7 = navBarControl2.Groups[4];
                    group7.Visible = false;
                    NavBarGroup group8 = navBarControl2.Groups[5];
                    group8.Visible = false;
                    NavBarGroup group11 = navBarControl2.Groups[7];
                    group11.Visible = false;
                    break;
                case 4:
                    ab = 1;
                    NavBarGroup group9 = navBarControl2.Groups[0];
                    group9.Visible = false;
                    NavBarGroup group10 = navBarControl2.Groups[1];
                    group10.Visible = false;
                    NavBarGroup group12 = navBarControl2.Groups[2];
                    group12.Visible = false;
                    NavBarGroup group13 = navBarControl2.Groups[3];
                    group13.Visible = false;
                    NavBarGroup group14 = navBarControl2.Groups[4];
                    group14.Visible = false;
                    NavBarGroup group15 = navBarControl2.Groups[5];
                    group15.Visible = false;
                    NavBarGroup group16 = navBarControl2.Groups[7];
                    group16.Visible = false;
                    break;

                default:
                    Form2 frm2 = new Form2();
                    frm2.Show();
                    this.Hide();
                    break;
            }

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-FJ3HBPC5\SQLEXPRESS;Initial Catalog=Dbo_Aktavuk;Integrated Security=True");
        int sayi = 1;
        int a;
        private void xtanatab_CustomHeaderButtonClick(object sender, DevExpress.XtraTab.ViewInfo.CustomHeaderButtonEventArgs e)
        {
            if (xtanatab.SelectedTabPage != anasayfa)
            {
                xtanatab.SelectedTabPage.PageVisible = false;
            }
        }
        #region
        private void formac(XtraTabPage xt)
        {
            xt.PageVisible = true;
            xtanatab.SelectedTabPage = xt;
        }
        private void siparisekle_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            formac(siparisek);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Tbl_Urun ", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmb_sipurun.ValueMember = "urun_id";
            cmb_sipurun.DisplayMember = "urun_adi";
            cmb_sipurun.DataSource = dt;
            baglanti.Close();

            baglanti.Open();
            SqlCommand kmt = new SqlCommand("select * from Tbl_Musteri ", baglanti);
            SqlDataAdapter data = new SqlDataAdapter(kmt);
            DataTable tab = new DataTable();
            data.Fill(tab);
            cmb_sipmus.ValueMember = "mus_id";
            cmb_sipmus.DisplayMember = "mus_dadi";
            cmb_sipmus.DataSource = tab;
            baglanti.Close();
        }
        private void siparissil_LinkClicked_1(object sender, NavBarLinkEventArgs e)
        {
            formac(sipariss);
            verilerigöstersiparis("Select sip_id,sip_müsteriad,sip_müsteridad,sip_mustel,sip_adres,sip_urun,sip_kilo,sip_ucret,sip_tarih from Tbl_Siparis where sip_gorunum like '" + 0 + "'");

        }
        private void stokguncel_LinkClicked_1(object sender, NavBarLinkEventArgs e)
        {
            formac(stokg);
            verilerigösterstok("Select stok_urunad,stok_urunkilo from Tbl_Stok ");
            baglanti.Open();
            string sqll = "select sip_müsteriad,sip_müsteridad,sip_urun,sip_kilo,sip_tarih  from Tbl_Siparis where sip_tarih='" + DateTime.Today.ToString("yyyy-MM-dd") + "' and sip_gorunum like '" + 0 + "' and sip_durum like '" + 1 + "' and sip_durdep like '" + 0 + "' and sip_duryol like '" + 0 + "' ";
            SqlDataAdapter daa = new SqlDataAdapter(sqll, baglanti);
            DataSet ds = new DataSet();
            daa.Fill(ds);
            data_stokcik.DataSource = ds.Tables[0];
            data_stokcik.Columns[1].HeaderText = "Müşteri Adı";
            data_stokcik.Columns[2].HeaderText = "Dükkan İsi5m";
            data_stokcik.Columns[3].HeaderText = "Ürün";
            data_stokcik.Columns[4].HeaderText = "Miktar";
            data_stokcik.Columns[5].HeaderText = "Tarih";
            baglanti.Close();
        }
        private void musteriekle_LinkClicked_1(object sender, NavBarLinkEventArgs e)
        {
            formac(musterie);
        }
        private void musterisil_LinkClicked_1(object sender, NavBarLinkEventArgs e)
        {
            formac(musteris);
            verilerigöstermus("Select mus_id,mus_ad,mus_soyad,mus_adres,mus_tel,mus_eposta,mus_dadi from Tbl_Musteri where mus_gorunum like '" + 0 + "'");

        }
        private void anasiparisekle_LinkClicked_1(object sender, NavBarLinkEventArgs e)
        {
            formac(senpilicek);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Tbl_Urun ", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmb_bayiurekle.DisplayMember = "urun_adi +' '+ urun_fiyat";
            cmb_bayiurekle.ValueMember = "urun_id";
            cmb_bayiurekle.DataSource = dt;
            baglanti.Close();

            baglanti.Open();
            string sqll = "select sip_urun, sum(sip_kilo)  from Tbl_Siparis where sip_tarih='" + DateTime.Today.ToString("yyyy-MM-dd") + "' and sip_gorunum like '" + 0 + "' GROUP BY sip_urun ";
            SqlDataAdapter daa = new SqlDataAdapter(sqll, baglanti);
            DataSet ds = new DataSet();
            daa.Fill(ds);
            dataanabayigös.DataSource = ds.Tables[0];
            dataanabayigös.Columns[0].HeaderText = "Ürün Adi";

            dataanabayigös.Columns[1].HeaderText = "Toplam Miktar";
            baglanti.Close();
        }
        private void anasiparissil_LinkClicked_1(object sender, NavBarLinkEventArgs e)
        {
            formac(senpilics);
            verilerigösterbayi("Select bayi_id,bayi_urun,bayi_kilo,bayi_tarih from Tbl_Bayi where bayi_gorunum like '" + 0 + "'");


        }
        private void personelekle_LinkClicked_1(object sender, NavBarLinkEventArgs e)
        {
            formac(personelek);
            cmb_perbol.Items.Add("Patron");
            cmb_perbol.Items.Add("Yönetici");
            cmb_perbol.Items.Add("Depo");
            cmb_perbol.Items.Add("Şöför");
            cmb_perbol.Items.Add("Kesimhane");
            cmb_perbol.Items.Add("Aşçı");
            cmb_perbol.Items.Add("Temizlik");
        }
        private void personelsil_LinkClicked_1(object sender, NavBarLinkEventArgs e)
        {
            formac(personels);
            verilerigöster("Select per_id,per_ad,per_soyad,per_tc,per_tel,per_cinsiyet,per_eposta,per_dtarih,per_gtarih,per_adres,per_bolum,per_gadi,per_gsifre,per_maas from Tbl_Personel where per_gor like '" + 0 + "'");
            cmb_pergbol.Items.Add("Patron");
            cmb_pergbol.Items.Add("Yönetici");
            cmb_pergbol.Items.Add("Depo");
            cmb_pergbol.Items.Add("Şöför");
            cmb_pergbol.Items.Add("Kesimhane");
            cmb_pergbol.Items.Add("Aşçı");
            cmb_pergbol.Items.Add("Temizlik");
        }
        private void urunekle_LinkClicked_1(object sender, NavBarLinkEventArgs e)
        {

            formac(urunek);
            lbl_urunekle.Visible = false;
        }
        private void urunsil_LinkClicked_1(object sender, NavBarLinkEventArgs e)
        {
            formac(urunc);
            verilerigösterurun("Select urun_id,urun_adi,urun_fiyat,urun_afiyat from Tbl_Urun where urun_gorunum like '" + 0 + "'");
            lblurung.Visible = false;
        }
        public void  depo_ItemChanged(object sender, EventArgs e)
        {
            formac(stok);
        }
        private void kesimhane_ItemChanged(object sender, EventArgs e)
        {
            formac(kesim);
            lbl_kesim.Text = DateTime.Today.ToString("yyyy-MM-dd") + " Tarihli Kesilecek Siparişler";
            baglanti.Open();
            string sqll = "select sip_urun, sum(sip_kilo)  from Tbl_Siparis where sip_tarih='" + DateTime.Today.ToString("yyyy-MM-dd") + "' and sip_gorunum like '" + 0 + "' and sip_durum like '" + 0 + "' GROUP BY sip_urun ";
            SqlDataAdapter daa = new SqlDataAdapter(sqll, baglanti);
            DataSet ds = new DataSet();
            daa.Fill(ds);
            datakesim.DataSource = ds.Tables[0];
            datakesim.Columns[1].HeaderText = "Ürün Adi";
            datakesim.Columns[2].HeaderText = "Toplam Miktar";
            baglanti.Close();
        }
        private void gelirgider_ItemChanged(object sender, EventArgs e)
        {


        }
        private void gelir_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            formac(gelirgide);
            { }

        }
        #endregion

        public void verilerigöster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dtper.DataSource = ds.Tables[0];
            dtper.DataSource = ds.Tables[0];
            dtper.Columns[2].HeaderText = "Personel Adı";
            dtper.Columns[3].HeaderText = "Personel Soyadı";
            dtper.Columns[4].HeaderText = "Personel Tc";
            dtper.Columns[5].HeaderText = "Personel Telefon";
            dtper.Columns[6].HeaderText = "Personel Cinsiyet";
            dtper.Columns[7].HeaderText = "Personel E-Posta";
            dtper.Columns[8].HeaderText = "Personel Dogum Tar.";
            dtper.Columns[9].HeaderText = "Personel İşe Baş. Tar.";
            dtper.Columns[10].HeaderText = "Personel Adres";
            dtper.Columns[11].HeaderText = "Personel Bölüm";
            dtper.Columns[12].HeaderText = "Personel Kullanıcı Adı";
            dtper.Columns[13].HeaderText = "Personel Kullanıcı Şifre";
            dtper.Columns[14].HeaderText = "Personel Maaş";

        }
        public void verilerigösterurun(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dturun.DataSource = ds.Tables[0];
            dturun.Columns[2].HeaderText = "Urun İd";
            dturun.Columns[3].HeaderText = "Urun Adi";
            dturun.Columns[4].HeaderText = "Satış Fiyatı";
            dturun.Columns[5].HeaderText = "Alış Fiyati";
        }
        public void verilerigöstermus(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dtmus.DataSource = ds.Tables[0];
            dtmus.Columns[2].HeaderText = "Müşteri İd";
            dtmus.Columns[3].HeaderText = "Müşteri Adi";
            dtmus.Columns[4].HeaderText = "Müşteri Soyadı";
            dtmus.Columns[5].HeaderText = "Müşteri Adres";
            dtmus.Columns[6].HeaderText = "Müşteri Telefon";
            dtmus.Columns[7].HeaderText = "Müşteri E-posta";
            dtmus.Columns[8].HeaderText = "Müşteri Dükkan Adı";
        }
        public void verilerigösterbayi(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            databayi.DataSource = ds.Tables[0];
            databayi.Columns[2].HeaderText = "Ürün İd";
            databayi.Columns[3].HeaderText = "Ürün Adi";
            databayi.Columns[4].HeaderText = "Ürün Kilo";
            databayi.Columns[5].HeaderText = "Ürün Tarih";

        }
        public void verilerigösterstok(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            datastok.DataSource = ds.Tables[0];
            datastok.Columns[1].HeaderText = "Ürün Adi";
            datastok.Columns[2].HeaderText = "Ürün Kilo";


        }
        public void verilerigöstersiparis(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            data_sip.DataSource = ds.Tables[0];
            data_sip.Columns[2].HeaderText = "Müşteri İd";
            data_sip.Columns[3].HeaderText = "Müşteri Adi";
            data_sip.Columns[4].HeaderText = "Müşteri Dükkan Adı";
            data_sip.Columns[5].HeaderText = "Müşteri Telefon";
            data_sip.Columns[6].HeaderText = "Müşteri Adres";
            data_sip.Columns[7].HeaderText = "Urun Adı";
            data_sip.Columns[8].HeaderText = "Ürün Kilo";
            data_sip.Columns[9].HeaderText = "Toplam Fiyat";
            data_sip.Columns[10].HeaderText = "Sipariş Tarihi";
        }

        #region
        private void dtper_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

                string sql = "update Tbl_Personel set per_gor='" + sayi + "' where per_id='" + dtper.CurrentRow.Cells["per_id"].Value.ToString() + "'";

                baglanti.Open();
                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.ExecuteNonQuery();
                verilerigöster("Select per_ad,per_soyad,per_tc,per_tel,per_cinsiyet,per_eposta,per_dtarih,per_gtarih,per_adres,per_bolum,per_gadi,per_gsifre,per_maas from Tbl_Personel where per_gor like '" + 0 + "'");

                baglanti.Close();
            }
            else if (e.ColumnIndex == 1)
            {
                int secilen = dtper.SelectedCells[0].RowIndex;
                string ad = dtper.Rows[secilen].Cells[3].Value.ToString();
                string soyad = dtper.Rows[secilen].Cells[4].Value.ToString();
                string tc = dtper.Rows[secilen].Cells[5].Value.ToString();
                string tel = dtper.Rows[secilen].Cells[6].Value.ToString();
                string cins = dtper.Rows[secilen].Cells[7].Value.ToString();
                string posta = dtper.Rows[secilen].Cells[8].Value.ToString();


                string adres = dtper.Rows[secilen].Cells[11].Value.ToString();
                string bolum = dtper.Rows[secilen].Cells[12].Value.ToString();
                string gadi = dtper.Rows[secilen].Cells[13].Value.ToString();
                string gsifre = dtper.Rows[secilen].Cells[14].Value.ToString();
                string maas = dtper.Rows[secilen].Cells[15].Value.ToString();






                txt_pergad.Text = ad;
                txt_pergsoyad.Text = soyad;
                txt_pergtc.Text = tc;
                txt_pergtel.Text = tel;

                if (cins == "0")
                {
                    radioger.Checked = true;
                }
                else
                {
                    radiogkadın.Checked = true;
                }

                txt_pergposta.Text = posta;


                dategdog.Value = Convert.ToDateTime(dtper.Rows[secilen].Cells[9].Value);
                dategbas.Value = Convert.ToDateTime(dtper.Rows[secilen].Cells[10].Value);
                txt_pergadres.Text = adres;

                txt_pergkad.Text = gadi;
                txt_pergksif.Text = gsifre;
                txt_pergmaas.Text = maas;

            }

        }

        private void btn_pergun_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked == true)
            {
                a = 0;
            }
            else
            {
                a = 1;
            }
            string donustur = dategdog.Value.ToString("yyyy-MM-dd");
            string donustur2 = dategbas.Value.ToString("yyyy-MM-dd");
            string sqlg = "update Tbl_Personel set per_ad='" + txt_pergad.Text + "',per_soyad='" + txt_pergsoyad.Text + "',per_tc='" + txt_pergtc.Text + "',per_tel='" + txt_pergtel.Text + "', per_cinsiyet='" + a + "',per_eposta='" + txt_pergposta.Text + "',per_dtarih='" + donustur + "',per_gtarih='" + donustur2 + "',per_adres='" + txt_pergadres.Text + "',per_bolum='" + cmb_pergbol.Text + "',per_gadi='" + txt_pergkad.Text + "',per_gsifre='" + txt_pergksif.Text + "',per_maas='" + Convert.ToInt32(txt_pergmaas.Text) + "' where per_id='" + dtper.CurrentRow.Cells["per_id"].Value.ToString() + "',per_yetgi='" + Convert.ToInt32(cmb_pergbol.SelectedValue) + "'";
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sqlg, baglanti);
            komut.ExecuteNonQuery();
            verilerigöster("Select per_ad,per_soyad,per_tc,per_tel,per_cinsiyet,per_eposta,per_dtarih,per_gtarih,per_adres,per_bolum,per_gadi,per_gsifre,per_maas from Tbl_Personel where per_gor like '" + 0 + "'");
            lblgmsj.Visible = true;
            txt_pergad.Clear();
            txt_pergadres.Clear();
            txt_pergkad.Clear();
            txt_pergksif.Clear();
            txt_pergmaas.Clear();
            txt_pergposta.Clear();
            txt_pergsoyad.Clear();
            txt_pergtc.Clear();
            txt_pergtel.Clear();
            
            baglanti.Close();
        }
        private void btn_perekle_Click(object sender, EventArgs e)
        {
            
            if (radioButton1.Checked == true)
            {
                a = 0;
            }
            else
            {
                a = 1;
            }
            
            baglanti.Open();
            int gor = 0;
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel (per_ad,per_soyad,per_tc,per_tel,per_cinsiyet,per_eposta,per_dtarih,per_gtarih,per_adres,per_bolum,per_gadi,per_gsifre,per_maas,per_gor,per_yetgi) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15)", baglanti);
            komut.Parameters.AddWithValue("@p1", txt_perad.Text);
            komut.Parameters.AddWithValue("@p2", txt_persoyad.Text);
            komut.Parameters.AddWithValue("@p3", txt_pertc.Text);
            komut.Parameters.AddWithValue("@p4", txt_pertel.Text);
            komut.Parameters.AddWithValue("@p5", a);
            komut.Parameters.AddWithValue("@p6", txt_perposta.Text);
            komut.Parameters.AddWithValue("@p7", date_perd.Value);
            komut.Parameters.AddWithValue("@p8", date_perbas.Value);
            komut.Parameters.AddWithValue("@p9", txt_peradres.Text);
            komut.Parameters.AddWithValue("@p10", cmb_perbol.Text);
            komut.Parameters.AddWithValue("@p11", txt_perkulad.Text);
            komut.Parameters.AddWithValue("@p12", txt_perkulsif.Text);
            komut.Parameters.AddWithValue("@p13", Convert.ToInt32(txt_permaas.Text));
            komut.Parameters.AddWithValue("@p14", gor);
            komut.Parameters.AddWithValue("@p15", Convert.ToInt32(cmb_perbol.SelectedValue));
            komut.ExecuteNonQuery();
            baglanti.Close();
            lbl_perkmsj.Visible = true;
            txt_perad.Clear(); txt_perposta.Clear();
            txt_persoyad.Clear(); txt_peradres.Clear();
            txt_pertc.Clear(); txt_perkulad.Clear();
            txt_pertel.Clear(); txt_perkulsif.Clear();
            txt_permaas.Clear();
        }


        private void btn_perara_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("Select per_ad,per_soyad,per_tc,per_tel,per_cinsiyet,per_eposta,per_dtarih,per_gtarih,per_adres,per_bolum,per_gadi,per_gsifre,per_maas from Tbl_Personel where per_ad like'%" + txt_perara.Text + "%'", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dtper.DataSource = ds.Tables[0];
            baglanti.Close();

        }
        #endregion
        private void btn_urunekle_Click(object sender, EventArgs e)
        {
            int gor = 0;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Urun (urun_adi,urun_fiyat,urun_afiyat,urun_gorunum) values (@p1,@p2,@p3,@p4)", baglanti);
            komut.Parameters.AddWithValue("@p1", txt_urunad.Text);
            komut.Parameters.AddWithValue("@p2", txt_urunfiyat.Text);
            komut.Parameters.AddWithValue("@p3", txt_urunafiyat.Text);
            komut.Parameters.AddWithValue("@p4", gor);

            komut.ExecuteNonQuery();
            baglanti.Close();
            lbl_urunekle.Visible = true;
            txt_urunad.Clear();
            txt_urunfiyat.Clear();
            txt_urunafiyat.Clear();

        }
        private void dturun_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

                string sql = "update Tbl_Urun set urun_gorunum='" + sayi + "' where urun_id='" + dturun.CurrentRow.Cells["urun_id"].Value.ToString() + "'";
                baglanti.Open();
                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.ExecuteNonQuery();
                verilerigösterurun("Select urun_id,urun_adi,urun_afiyat,urun_fiyat from Tbl_Urun where urun_gorunum like '" + 0 + "'");
                baglanti.Close();
            }
            else if (e.ColumnIndex == 1)
            {
                int secilenurun = dturun.SelectedCells[0].RowIndex;
                string urunad = dturun.Rows[secilenurun].Cells[3].Value.ToString();
                string urunfiyat = dturun.Rows[secilenurun].Cells[4].Value.ToString();
                string urunafiyat = dturun.Rows[secilenurun].Cells[5].Value.ToString();
                txt_urungadi.Text = urunad;
                txt_urungfi.Text = urunfiyat;
                txt_urungafi.Text = urunafiyat;


            }
        }
        private void btn_urungun_Click(object sender, EventArgs e)
        {
            string sqlg = "update Tbl_Urun set urun_adi='" + txt_urungadi.Text + "',urun_fiyat='" + txt_urungfi.Text + "',urun_afiyat='" + txt_urungafi.Text + "' where urun_id='" + dturun.CurrentRow.Cells["urun_id"].Value.ToString() + "'";
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sqlg, baglanti);
            komut.ExecuteNonQuery();
            verilerigösterurun("Select urun_id,urun_adi,urun_fiyat,urun_afiyat from Tbl_Urun where urun_gorunum like '" + 0 + "'");
            lblurung.Visible = true;
            txt_urungadi.Clear();
            txt_urungafi.Clear();
            txt_urungfi.Clear();
            baglanti.Close();
        }
        private void btn_urunara_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Tbl_Urun where urun_adi like'%" + txt_urunara.Text + "%'", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dturun.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void btn_musekle_Click(object sender, EventArgs e)
        {
            int gor = 0;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Musteri (mus_ad,mus_soyad,mus_adres,mus_tel,mus_eposta,mus_dadi,mus_gorunum) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", baglanti);
            komut.Parameters.AddWithValue("@p1", txt_musad.Text);
            komut.Parameters.AddWithValue("@p2", txt_mussoyad.Text);
            komut.Parameters.AddWithValue("@p3", txt_musadr.Text);
            komut.Parameters.AddWithValue("@p4", txt_mustel.Text);
            komut.Parameters.AddWithValue("@p5", txt_musposta.Text);
            komut.Parameters.AddWithValue("@p6", txt_musdukad.Text);
            komut.Parameters.AddWithValue("@p7", gor);
            komut.ExecuteNonQuery();
            baglanti.Close();
            lbl_muska.Visible = true;
            txt_musad.Clear();
            txt_mussoyad.Clear();
            txt_musadr.Clear();
            txt_mustel.Clear();
            txt_musposta.Clear();
            txt_musdukad.Clear();
        }
        private void dtmus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

                string sql = "update Tbl_Musteri set mus_gorunum='" + sayi + "' where mus_id='" + dtmus.CurrentRow.Cells["mus_id"].Value.ToString() + "'";
                baglanti.Open();
                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.ExecuteNonQuery();
                verilerigöstermus("Select * from Tbl_Musteri where mus_gorunum like '" + 0 + "'");
                baglanti.Close();
            }
            else if (e.ColumnIndex == 1)
            {
                int secilenurun = dtmus.SelectedCells[0].RowIndex;
                string musad = dtmus.Rows[secilenurun].Cells[3].Value.ToString();
                string mussoyad = dtmus.Rows[secilenurun].Cells[4].Value.ToString();
                string musadres = dtmus.Rows[secilenurun].Cells[5].Value.ToString();
                string mustel = dtmus.Rows[secilenurun].Cells[6].Value.ToString();
                string musposta = dtmus.Rows[secilenurun].Cells[7].Value.ToString();
                string musdadi = dtmus.Rows[secilenurun].Cells[8].Value.ToString();
                txt_musgad.Text = musad;
                txt_musgsoy.Text = mussoyad;
                txt_musgadr.Text = musadres;
                txt_musgtel.Text = mustel;
                txt_musgposta.Text = musposta;
                txt_musgdad.Text = musdadi;


            }
        }
        private void btn_musgun_Click(object sender, EventArgs e)
        {
            string sqlg = "update Tbl_Musteri set mus_ad='" + txt_musgad.Text + "',mus_soyad='" + txt_musgsoy.Text + "',mus_adres='" + txt_musgadr.Text + "',mus_tel='" + txt_musgtel.Text + "',mus_eposta='" + txt_musgposta.Text + "',mus_dadi='" + txt_musgdad.Text + "' where mus_id='" + dtmus.CurrentRow.Cells["mus_id"].Value.ToString() + "'";
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sqlg, baglanti);
            komut.ExecuteNonQuery();
            verilerigöstermus("Select mus_id,mus_ad,mus_soyad,mus_adres,mus_tel,mus_eposta,mus_dadi from Tbl_Musteri where mus_gorunum like '" + 0 + "'");

            lbl_musgun.Visible = true;
            txt_musgad.Clear();
            txt_musgadr.Clear();
            txt_musgdad.Clear();
            txt_musgposta.Clear();
            txt_musgsoy.Clear();
            txt_musgtel.Clear();
            baglanti.Close();
        }
        private void btn_musara_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select mus_id,mus_ad,mus_soyad,mus_adres,mus_tel,mus_eposta,mus_dadi from Tbl_Musteri where mus_dadi like'%" + txt_musara.Text + "%'", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dtmus.DataSource = ds.Tables[0];
            baglanti.Close();

        }
        private void btn_bayiekle_Click(object sender, EventArgs e)
        {
            int gor = 0;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Bayi (bayi_urun,bayi_kilo,bayi_tarih,bayi_gorunum) values (@a1,@a2,@a3,@a4)", baglanti);

            komut.Parameters.AddWithValue("@a1", cmb_bayiurekle.GetItemText(cmb_bayiurekle.SelectedItem));
            komut.Parameters.AddWithValue("@a2", txt_bayikiloek.Text);
            komut.Parameters.AddWithValue("@a3", date_bayitarih.Value);
            komut.Parameters.AddWithValue("@a4", gor);
            komut.ExecuteNonQuery();
            baglanti.Close();
            lbl_bayiekle.Visible = true;
            txt_bayikiloek.Clear();

        }
        private void databayi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

                string sql = "update Tbl_Bayi set bayi_gorunum='" + sayi + "' where bayi_id='" + databayi.CurrentRow.Cells["bayi_id"].Value.ToString() + "'";
                baglanti.Open();
                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.ExecuteNonQuery();
                verilerigösterbayi("Select bayi_id,bayi_urun,bayi_kilo,bayi_tarih from Tbl_Bayi where bayi_gorunum like '" + 0 + "'");
                baglanti.Close();
            }
            else if (e.ColumnIndex == 1)
            {
                int secilenurun = databayi.SelectedCells[0].RowIndex;

                string bayiurunmik = databayi.Rows[secilenurun].Cells[4].Value.ToString();
                txt_bayigkilo.Text = bayiurunmik;

                databayig.Value = Convert.ToDateTime(databayi.Rows[secilenurun].Cells[5].Value);

                baglanti.Open();
                SqlCommand komut = new SqlCommand("select * from Tbl_Urun ", baglanti);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmb_bayigurun.ValueMember = "urun_id";
                cmb_bayigurun.DisplayMember = "urun_adi";
                cmb_bayigurun.DataSource = dt;
                baglanti.Close();
                cmb_bayigurun.SelectedIndex = secilenurun;




            }
        }
        private void btn_bayigun_Click(object sender, EventArgs e)
        {
            string donustur = databayig.Value.ToString("yyyy-MM-dd");

            string sqlg = "update Tbl_Bayi set bayi_urun='" + cmb_bayigurun.GetItemText(cmb_bayigurun.SelectedItem) + "',bayi_kilo='" + txt_bayigkilo.Text + "',bayi_tarih='" + donustur + "'  where bayi_id='" + databayi.CurrentRow.Cells["bayi_id"].Value.ToString() + "' ";
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sqlg, baglanti);
            komut.ExecuteNonQuery();
            verilerigösterbayi("Select bayi_id,bayi_urun,bayi_kilo,bayi_tarih from Tbl_Bayi where bayi_gorunum like '" + 0 + "'");
            lbl_bayigun.Visible = true;
            txt_bayigkilo.Clear();
            baglanti.Close();

        }
        private void btn_bayiara_Click(object sender, EventArgs e)
        {

            string donustur = datebayiara.Value.ToString("yyyy-MM-dd");
            baglanti.Open();

            SqlCommand komut = new SqlCommand("Select bayi_urun,bayi_kilo,bayi_tarih from Tbl_Bayi where bayi_tarih=@tarih and bayi_gorunum like '" + 0 + "' ", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.SelectCommand.Parameters.AddWithValue("@tarih", donustur);
            DataSet ds = new DataSet();
            da.Fill(ds);
            databayi.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void datastok_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int secilenurun = datastok.SelectedCells[0].RowIndex;
                string stokmik = datastok.Rows[secilenurun].Cells[2].Value.ToString();
                txt_stokg.Text = stokmik;
            }
        }
        private void btn_stokgun_Click(object sender, EventArgs e)
        {
            string sqlg = "update Tbl_Stok set stok_urunkilo='" + txt_stokg.Text + "' where stok_urunad='" + datastok.CurrentRow.Cells["stok_urunad"].Value.ToString() + "' ";
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sqlg, baglanti);
            komut.ExecuteNonQuery();
            verilerigösterstok("Select stok_urunad,stok_urunkilo from Tbl_Stok ");
            lbl_stokg.Visible = true;
            txt_stokg.Clear();
            baglanti.Close();
        }
        private void btn_stokara_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select stok_urunad,stok_urunkilo from Tbl_Stok where stok_urunad like'%" + txt_stokara.Text + "%'", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            datastok.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void btn_sipekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmt2 = new SqlCommand("select * from Tbl_Musteri where mus_id = @a1", baglanti);
            kmt2.Parameters.AddWithValue("@a1", Convert.ToInt32(cmb_sipmus.SelectedValue));
            SqlDataReader ok = kmt2.ExecuteReader();
            ok.Read();
            string musad = ok["mus_ad"].ToString();
            string musadres = ok["mus_adres"].ToString();
            string mustel = ok["mus_tel"].ToString();
            ok.Close();
            int gor = 0;
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Siparis (sip_müsteriad,sip_müsteridad,sip_mustel,sip_adres,sip_urun,sip_kilo,sip_ucret,sip_tarih,sip_gorunum,sip_durum,sip_durdep,sip_duryol) values (@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8,@a9,@a10,@a11,@a12)", baglanti);
            komut.Parameters.AddWithValue("@a1", musad);
            komut.Parameters.AddWithValue("@a2", cmb_sipmus.GetItemText(cmb_sipmus.SelectedItem));
            komut.Parameters.AddWithValue("@a3", mustel);
            komut.Parameters.AddWithValue("@a4", musadres);
            komut.Parameters.AddWithValue("@a5", cmb_sipurun.GetItemText(cmb_sipurun.SelectedItem));
            komut.Parameters.AddWithValue("@a6", Convert.ToInt32(txt_sipkilo.Text));
            komut.Parameters.AddWithValue("@a7", Convert.ToInt32(txt_sipucret.Text));
            komut.Parameters.AddWithValue("@a8", date_siptarih.Value);
            komut.Parameters.AddWithValue("@a9", gor);
            komut.Parameters.AddWithValue("@a10", 0);
            komut.Parameters.AddWithValue("@a11", 0);
            komut.Parameters.AddWithValue("@a12", 0);
            komut.ExecuteNonQuery();
            baglanti.Close();

            lbl_sipkayd.Visible = true;
            txt_sipkilo.Clear();
            txt_sipucret.Clear();
        }
        private void txt_sipucret_MouseClick(object sender, MouseEventArgs e)
        {


            SqlCommand kmt1 = new SqlCommand("select * from Tbl_Urun where urun_id= @a1 ", baglanti);
            baglanti.Open();
            kmt1.Parameters.AddWithValue("@a1", Convert.ToInt32(cmb_sipurun.SelectedValue));
            SqlDataReader oku = kmt1.ExecuteReader();
            oku.Read();
            int fiyat = Convert.ToInt32(oku["urun_fiyat"].ToString());
            int kilo = Convert.ToInt32(txt_sipkilo.Text);
            txt_sipucret.Text = Convert.ToString(fiyat * kilo);
            baglanti.Close();
            oku.Close();
        }
        private void data_sip_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

                string sql = "update Tbl_Siparis set sip_gorunum='" + sayi + "' where sip_id='" + data_sip.CurrentRow.Cells["sip_id"].Value.ToString() + "'";
                baglanti.Open();
                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.ExecuteNonQuery();
                verilerigöstersiparis("Select sip_id,sip_müsteriad,sip_müsteridad,sip_mustel,sip_adres,sip_urun,sip_kilo,sip_ucret,sip_tarih from Tbl_Siparis where sip_gorunum like '" + 0 + "'");
                baglanti.Close();
            }
            else if (e.ColumnIndex == 1)
            {
                int secilenurun = data_sip.SelectedCells[0].RowIndex;

                string gkilo = data_sip.Rows[secilenurun].Cells[8].Value.ToString();
                txt_gsipkilo.Text = gkilo;
                string gucret = data_sip.Rows[secilenurun].Cells[9].Value.ToString();
                txt_gsipucret.Text = gucret;

                date_gsiptar.Value = Convert.ToDateTime(data_sip.Rows[secilenurun].Cells[10].Value);

                baglanti.Open();
                SqlCommand komut = new SqlCommand("select * from Tbl_Musteri ", baglanti);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmb_gsipmus.ValueMember = "mus_id";
                cmb_gsipmus.DisplayMember = "mus_ad";
                cmb_gsipmus.DataSource = dt;
                // cmb_gsipmus.SelectedIndex = secilenurun;
                baglanti.Close();
                baglanti.Open();
                SqlCommand kmt = new SqlCommand("select * from Tbl_Urun ", baglanti);
                SqlDataAdapter daa = new SqlDataAdapter(kmt);
                DataTable dtt = new DataTable();
                daa.Fill(dtt);
                cmb_gsipurun.ValueMember = "urun_id";
                cmb_gsipurun.DisplayMember = "urun_adi";
                cmb_gsipurun.DataSource = dtt;
                baglanti.Close();
                // cmb_gsipurun.SelectedIndex = secilenurun;
            }
        }
        private void btn_gsip_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmt2 = new SqlCommand("select * from Tbl_Musteri where mus_id = @a1", baglanti);
            kmt2.Parameters.AddWithValue("@a1", Convert.ToInt32(cmb_gsipmus.SelectedValue));
            SqlDataReader ok = kmt2.ExecuteReader();
            ok.Read();
            string musad = ok["mus_ad"].ToString();
            string musadres = ok["mus_adres"].ToString();
            string mustel = ok["mus_tel"].ToString();
            ok.Close();
            int gor = 0;
            baglanti.Close();
            string donustur = date_gsiptar.Value.ToString("yyyy-MM-dd");
            string sqlg = "update Tbl_Siparis set  sip_müsteriad=@a1, sip_müsteridad=@a2, sip_mustel=@a3, sip_adres=@a4, sip_urun=@a5, sip_kilo=@a6, sip_ucret=@a7, sip_tarih=@a8  where sip_id ='" + data_sip.CurrentRow.Cells["sip_id"].Value.ToString() + "' ";

            baglanti.Open();
            SqlCommand komut = new SqlCommand(sqlg, baglanti);
            komut.Parameters.AddWithValue("@a1", musad);
            komut.Parameters.AddWithValue("@a2", cmb_gsipmus.GetItemText(cmb_gsipmus.SelectedItem));
            komut.Parameters.AddWithValue("@a3", mustel);
            komut.Parameters.AddWithValue("@a4", musadres);
            komut.Parameters.AddWithValue("@a5", cmb_gsipurun.GetItemText(cmb_gsipurun.SelectedItem));
            komut.Parameters.AddWithValue("@a6", Convert.ToInt32(txt_gsipkilo.Text));
            komut.Parameters.AddWithValue("@a7", Convert.ToInt32(txt_gsipucret.Text));
            komut.Parameters.AddWithValue("@a8", donustur);
            komut.Parameters.AddWithValue("@a9", gor);
            komut.ExecuteNonQuery();



            verilerigöstersiparis("Select sip_id,sip_müsteriad,sip_müsteridad,sip_mustel,sip_adres,sip_urun,sip_kilo,sip_ucret,sip_tarih from Tbl_Siparis where sip_gorunum like '" + 0 + "'");
            lbl_gsip.Visible = true;
            txt_gsipkilo.Clear();
            txt_gsipucret.Clear();
            baglanti.Close();
        }
        private void txt_gsipucret_MouseClick(object sender, MouseEventArgs e)
        {
            SqlCommand kmt1 = new SqlCommand("select * from Tbl_Urun where urun_id= @a1 ", baglanti);
            baglanti.Open();
            kmt1.Parameters.AddWithValue("@a1", Convert.ToInt32(cmb_gsipurun.SelectedValue));
            SqlDataReader oku = kmt1.ExecuteReader();
            oku.Read();
            int fiyat = Convert.ToInt32(oku["urun_fiyat"].ToString());
            int kilo = Convert.ToInt32(txt_gsipkilo.Text);
            txt_gsipucret.Text = Convert.ToString(fiyat * kilo);
            baglanti.Close();
            oku.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            string donustur = datasipara.Value.ToString("yyyy-MM-dd");
            baglanti.Open();

            SqlCommand komut = new SqlCommand("Select sip_id,sip_müsteriad,sip_müsteridad,sip_mustel,sip_adres,sip_urun,sip_kilo,sip_ucret,sip_tarih from Tbl_Siparis where sip_tarih='" + donustur + "' and sip_gorunum like '" + 0 + "' ", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);

            DataSet ds = new DataSet();
            da.Fill(ds);
            data_sip.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void btn_getir_Click(object sender, EventArgs e)
        {
            

            string donustur = date_ilktar.Value.ToString("yyyy-MM-dd");
            string donustur2 = date_ikitar.Value.ToString("yyyy-MM-dd");
            baglanti.Open();
            SqlCommand kmt3 = new SqlCommand("select  sum(sip_ucret) from Tbl_Siparis  where (sip_gorunum='"+ 0 +"') and (sip_tarih BETWEEN '" + donustur + "' and '" + donustur2 + "') ", baglanti);
            SqlDataReader okk = kmt3.ExecuteReader();
            okk.Read();
            string gelir = okk[0].ToString();
            okk.Close();
            baglanti.Close();
            int glr = Convert.ToInt32(gelir);

            baglanti.Open();
            SqlCommand kmt2 = new SqlCommand("select sum(per_maas) from Tbl_Personel where (per_gor='"+ 0 +"') and (per_gtarih BETWEEN '" + donustur + "' and '" + donustur2 + "') ", baglanti);
            SqlDataReader ok = kmt2.ExecuteReader();
            ok.Read();
            string gider = ok[0].ToString();
            ok.Close();
            baglanti.Close();
           
            if (gider.Length!=0)
            {
                int gdr = Convert.ToInt32(gider);
                int kar = glr - gdr;
                chart1.Series["Grafik"].Points.AddXY("Gider", gdr);
                chart1.Series["Grafik"].Points.AddXY("Kar", kar);
                label5.Text = "Gider :" + Convert.ToString(gdr);
                label6.Text = "Kar :" + Convert.ToString(kar);
                label5.Visible = true;
                label6.Visible = true;
            }
           
            

            
            chart1.Series["Grafik"].Points.AddXY("Gelir", glr);
            label4.Text = "Gelir :"+ Convert.ToString(glr) ;
            label4.Visible = true;
            chart1.Visible = true;
        }
        private void cmb_perbol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmb_perbol.SelectedIndex) == 0 || Convert.ToInt32(cmb_perbol.SelectedIndex) == 1 || Convert.ToInt32(cmb_perbol.SelectedIndex) == 2 || Convert.ToInt32(cmb_perbol.SelectedIndex) == 3)
            {
                materialLabel3.Visible = true;
                txt_perkulad.Visible = true;
                txt_perkulsif.Visible = true;
                materialLabel2.Visible = true;
            }
            else
            {
                materialLabel3.Visible = false;
                txt_perkulad.Visible = false;
                txt_perkulsif.Visible = false;
                materialLabel2.Visible = false;
            }
        }
        private void cmb_pergbol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmb_perbol.SelectedValue) == 0 || Convert.ToInt32(cmb_perbol.SelectedValue) == 1 || Convert.ToInt32(cmb_perbol.SelectedValue) == 2 || Convert.ToInt32(cmb_perbol.SelectedValue) == 3)
            {
                materialLabel42.Visible = true;
                txt_pergkad.Visible = true;
                txt_pergksif.Visible = true;
                materialLabel43.Visible = true;
            }
            else
            {
                materialLabel42.Visible = false;
                txt_pergkad.Visible = false;
                txt_pergksif.Visible = false;
                materialLabel43.Visible = false;
            }
        }
        private void datakesim_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {


                baglanti.Close();
                DataGridViewCellStyle renk = new DataGridViewCellStyle();
                int secilenurun = datakesim.SelectedCells[0].RowIndex;
                renk.BackColor = Color.DarkGreen;
                renk.ForeColor = Color.WhiteSmoke;
                datakesim.Rows[secilenurun].DefaultCellStyle = renk;
                int stokadet = Convert.ToInt32(datakesim.Rows[secilenurun].Cells[2].Value.ToString());
                string stokisim = datakesim.Rows[secilenurun].Cells[1].Value.ToString();
                baglanti.Open();
                SqlCommand kmt2 = new SqlCommand("select * from Tbl_Stok where stok_urunad = '" + stokisim + "'", baglanti);
                SqlDataReader ok = kmt2.ExecuteReader();
                ok.Read();
                int adet = Convert.ToInt32(ok["stok_urunkilo"].ToString());
                ok.Close();
                baglanti.Close();
                adet += stokadet;
                string sqlg = "update Tbl_Stok set stok_urunkilo =  '" + Convert.ToString(adet) + "'  where stok_urunad='" + stokisim + "' ";
                baglanti.Open();
                SqlCommand komut = new SqlCommand(sqlg, baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                string sql = "update Tbl_Siparis set sip_durum='" + sayi + "' where sip_urun='" + stokisim + "' and sip_tarih='"+ DateTime.Today.ToString("yyyy-MM-dd")+"' ";
                baglanti.Open();
                SqlCommand komut2 = new SqlCommand(sql, baglanti);
                komut2.ExecuteNonQuery();
                baglanti.Close();

            }
        }
        private void data_stokcik_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DataGridViewCellStyle renk = new DataGridViewCellStyle();
                int secilenurun = data_stokcik.SelectedCells[0].RowIndex;
                renk.BackColor = Color.DarkGreen;
                renk.ForeColor = Color.WhiteSmoke;
                data_stokcik.Rows[secilenurun].DefaultCellStyle = renk;
                string stokisim = data_stokcik.Rows[secilenurun].Cells[3].Value.ToString();
                int stokadet = Convert.ToInt32(data_stokcik.Rows[secilenurun].Cells[4].Value.ToString());
                
                baglanti.Open();
                SqlCommand kmt2 = new SqlCommand("select * from Tbl_Stok where stok_urunad = '" + stokisim + "'", baglanti);
                SqlDataReader ok = kmt2.ExecuteReader();
                ok.Read();
                int adet = Convert.ToInt32(ok["stok_urunkilo"].ToString());
                ok.Close();
                baglanti.Close();
                adet -= stokadet;
                string sqlg = "update Tbl_Stok set stok_urunkilo =  '" + Convert.ToString(adet) + "'  where stok_urunad='" + stokisim + "' ";
                baglanti.Open();
                SqlCommand komut = new SqlCommand(sqlg, baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                string sql = "update Tbl_Siparis set sip_durdep='" + sayi + "' where sip_urun='" + stokisim + "' and sip_tarih='" + DateTime.Today.ToString("yyyy-MM-dd") + "'";
                baglanti.Open();
                SqlCommand komut2 = new SqlCommand(sql, baglanti);
                komut2.ExecuteNonQuery();
                baglanti.Close();
            }
        }
        private void data_anasayfa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (ab!=1)
                {
                    int secilenurun = data_anasayfa.SelectedCells[0].RowIndex;
                    DataGridViewCellStyle renkk = new DataGridViewCellStyle();

                    renkk.BackColor = Color.DarkGreen;
                    renkk.ForeColor = Color.WhiteSmoke;
                    data_anasayfa.Rows[secilenurun].DefaultCellStyle = renkk;

                    string stokisim = data_anasayfa.Rows[secilenurun].Cells[2].Value.ToString();
                    int stok = Convert.ToInt32(data_anasayfa.Rows[secilenurun].Cells[4].Value.ToString());

                    string sql = "update Tbl_Siparis set sip_duryol='" + sayi + "' where sip_müsteridad='" + stokisim + "'  and sip_kilo='" + stok + "'";

                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(sql, baglanti);
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();
                    string sqll = "select sip_müsteriad,sip_müsteridad,sip_urun,sip_kilo,sip_tarih  from Tbl_Siparis where sip_tarih='" + DateTime.Today.ToString("yyyy-MM-dd") + "' and sip_gorunum like '" + 0 + "' and sip_durum like '" + 1 + "' and sip_durdep like '" + 1 + "' and sip_duryol='" + 0 + "' ";
                    SqlDataAdapter daa = new SqlDataAdapter(sqll, baglanti);
                    DataSet ds = new DataSet();
                    daa.Fill(ds);
                    data_anasayfa.DataSource = ds.Tables[0];
                    data_anasayfa.Columns[1].HeaderText = "Müşteri Adı";
                    data_anasayfa.Columns[2].HeaderText = "Dükkan İsim";
                    data_anasayfa.Columns[3].HeaderText = "Ürün";
                    data_anasayfa.Columns[4].HeaderText = "Miktar";
                    data_anasayfa.Columns[5].HeaderText = "Tarih";
                    baglanti.Close();
                }
                else
                {
                    label7.Text = "Yetginiz bulunmamaktadır";
                    label7.Visible = true;
                }
                

            }
        }
        private void xtanatab_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sqll = "select sip_müsteriad,sip_müsteridad,sip_urun,sip_kilo,sip_tarih  from Tbl_Siparis where sip_tarih='" + DateTime.Today.ToString("yyyy-MM-dd") + "' and sip_gorunum like '" + 0 + "' and sip_durum like '" + 1 + "' and sip_durdep like '" + 1 + "'  and sip_duryol='" + 0 + "'";
            SqlDataAdapter daa = new SqlDataAdapter(sqll, baglanti);
            DataSet ds = new DataSet();
            daa.Fill(ds);
            data_anasayfa.DataSource = ds.Tables[0];
            data_anasayfa.Columns[1].HeaderText = "Müşteri Adı";
            data_anasayfa.Columns[2].HeaderText = "Dükkan İsim";
            data_anasayfa.Columns[3].HeaderText = "Ürün";
            data_anasayfa.Columns[4].HeaderText = "Miktar";
            data_anasayfa.Columns[5].HeaderText = "Tarih";
            baglanti.Close();
        }
#region
        private void txt_pertc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_pertel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        

        private void txt_pergtc_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txt_pergtel_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txt_musgtel_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txt_sipkilo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_gsipkilo_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txt_bayikiloek_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_bayigkilo_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txt_stokg_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txt_urunfiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_urunafiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_urungfi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_urungafi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_mustel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
#endregion
    }
}
