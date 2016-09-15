using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using AlfaDeltaLogin;

public partial class sifredegistir : System.Web.UI.Page
{
    public int kullanici_id = 0;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["KullaniciID"] != null)
            {


                kullanici_id = Convert.ToInt32(Session["KullaniciID"]);


            }
            else
            {

                Response.Redirect("default.aspx");
            }



            Kullanici kull = new Kullanici(kullanici_id);

            txtKullaniciAdi.Text = kull.Adi + " " + kull.Soyadi;

            kull = null;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string mevcut_sifre = "";
        Kullanici kull = new Kullanici(Convert.ToInt32(Session["KullaniciID"]));
        mevcut_sifre = kull.Sifre;

        if (txtSifre.Text != mevcut_sifre)
        {
            lblError.Text = "Mevcut şifreniz yanlış";
        }

        else
        {
            if (sifrekontol(txtYeniSifre.Text, txtYeniSifreTekrar.Text))
            {
                kull.Sifre = txtYeniSifre.Text;
                kull.Update();
                kull = null;
                KontrolInfo infor = new KontrolInfo();
                infor.ID = Convert.ToInt32(Session["KullaniciID"]);
                infor.KONTROL = 0;
                new KontrolBLL().Update(infor);



                lblError.Text = "Şifreniz Değişmiştir";
            }
            else
            {
                lblError.Text += lblError.Text + "<br> Şifreler Birbirini Tutmuyor";
            }
        }

    }

    bool sifrekontol(string sifre, string sifretekrar)
    {
        bool sifretamam = false;
        if (sifre == sifretekrar)
            sifretamam = true;
        else
            sifretamam = false;

        return sifretamam;

    }
}
