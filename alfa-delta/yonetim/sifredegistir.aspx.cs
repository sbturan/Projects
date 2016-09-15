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

public partial class yonetim_sifredegistir : System.Web.UI.Page
{
    public int kullanici_id = 0;
   
    protected void Page_Load(object sender, EventArgs e)
    {
       string securitytype = ConfigurationManager.AppSettings.Get("securitytype");

        if (securitytype == "cookie")
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
                Response.Redirect("giris.aspx");

            if (!User.IsInRole("Administrator"))
                Response.Redirect("giris.aspx");

            else
            {
                kullanici_id = Convert.ToInt32(User.Identity.Name);
            }
        }

        else
        {
            if (HttpContext.Current.Session["kullanici"] == null)
                Response.Redirect("giris.aspx");

            if (Kullanici.UserInRole(((Kullanici)HttpContext.Current.Session["kullanici"]).Id, "Administrator") == false)
                Response.Redirect("giris.aspx");

            else
            {
                kullanici_id = ((Kullanici)HttpContext.Current.Session["kullanici"]).Id;
            }

        }

        Kullanici kull = new Kullanici(kullanici_id);

        txtKullaniciAdi.Text = kull.Adi+" "+kull.Soyadi;
        //kull.Sifre = "12qwas";
        //kull.Update();
        kull = null;
   
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string mevcut_sifre = "";
        Kullanici kull = new Kullanici(kullanici_id);
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
