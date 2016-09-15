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

public partial class uyeol : System.Web.UI.Page
{
    int roleid;
    int userid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["KullaniciID"] == null)
        {
            Response.Redirect("default.aspx");
        }
        else {

            if (Session["dil"] == "en")
            {
                lbl_Adi.Text = "Name";
                lblEmail.Text = "Email";
                lblSoyad.Text = "Surname";
                lblTelNo.Text = "Phone Number";
                lblHeader.Text = "Member of Editing Form";
            }
            if (!IsPostBack)
            {
                getir();
            }


            
        }


    }
    public void getir() {

        userid = Convert.ToInt32(Session["KullaniciID"].ToString());
        UsersBLL burak = new UsersBLL();
        UsersInfo info = burak.BulByID(userid);
        txt_Adi.Text = info.Adi;
        txt_Email.Text = info.Email;
        txt_Soyadi.Text = info.Soyadi;
        txt_TelNo.Text = info.Telefon;

    }

    protected void Gonder_Click(object sender, ImageClickEventArgs e)
    {
       int useridd = Convert.ToInt32(Session["KullaniciID"].ToString());
       UsersBLL burak1 = new UsersBLL();
       UsersInfo info1 = burak1.BulByID(useridd);
       string x = info1.Sifre;
        UpdateData(useridd,x);

    }

    private void UpdateData(int id,string y)
    {
        UsersBLL usbll = new UsersBLL();
        
        UsersInfo info = new UsersInfo();
        info.Sifre = y;
        info.Adi = txt_Adi.Text;
        info.Soyadi = txt_Soyadi.Text;
        info.Email = txt_Email.Text;
        info.Telefon = txt_TelNo.Text;
        info.Durum = true;
        
        info.RoleId = 3;
        
        info.Id = id;

        new UsersBLL().Guncelle(info);


        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "webformdesigner", "alert('Bilgileriniz Basariyla Güncellenmistir.');", true);

        txt_Adi.Text = string.Empty;
        txt_Soyadi.Text = string.Empty;
        txt_Email.Text = string.Empty;
        txt_TelNo.Text = string.Empty;
       


    }
}

