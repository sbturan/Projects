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

public partial class yonetim_UserRoleEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["GelenSayfa"] = Page.Request.Url.ToString();
        string securitytype = ConfigurationManager.AppSettings.Get("securitytype");

        if (securitytype == "cookie")
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
                Response.Redirect("giris.aspx");

            if (!User.IsInRole("Administrator"))
                Response.Redirect("giris.aspx");
        }

        else
        {
            if (HttpContext.Current.Session["kullanici"] == null)
                Response.Redirect("giris.aspx");

            if (Kullanici.UserInRole(((Kullanici)HttpContext.Current.Session["kullanici"]).Id, "Administrator") == false)
                Response.Redirect("giris.aspx");
        }


        if (Request.QueryString["ID"] == null)
            frw_Roller.ChangeMode(FormViewMode.Insert);
        else
        {
            frw_Roller.ChangeMode(FormViewMode.ReadOnly);
        }
    }
    protected void btnYeni_Click(object sender, EventArgs e)
    {
        frw_Roller.ChangeMode(FormViewMode.Insert);
    }
    protected void btnGuncelle_Click(object sender, EventArgs e)
    {
        frw_Roller.ChangeMode(FormViewMode.Edit);
    }

    #region Show Messages Metods
    private void ShowDeleteMessage()
    {
        lbl_Mesaj.Text = "<div style=\"border: solid 1px #d4dce6; color: #cc0000; font-size: 11px; font-weight: bold; padding: 3px; background-color: #f5f5ff\">Silme işlemi başarılı </div>";
        lbl_Mesaj.Visible = true;
    }
    private void ShowInsertMessage()
    {
        lbl_Mesaj.Text = "<div style=\"border: solid 1px #d4dce6; color: #cc0000; font-size: 11px; font-weight: bold; padding: 3px; background-color: #f5f5ff\">Kayıt işlemi başarılı</div>";
        lbl_Mesaj.Visible = true;
    }
    private void ShowUpdateMessage()
    {
        lbl_Mesaj.Text = "<div style=\"border: solid 1px #d4dce6; color: #cc0000; font-size: 11px; font-weight: bold; padding: 3px; background-color: #f5f5ff\">Güncelleme işlemi başarılı</div>";
        lbl_Mesaj.Visible = true;
    }
    #endregion Show Mesah Metods
    protected void btnSil_Click(object sender, EventArgs e)
    {
        //SİL 
        if (Request.QueryString["ID"] != null)
        {
            usrRolDAL myRolDAL = new usrRolDAL();
            myRolDAL.Delete(Convert.ToInt32(Request.QueryString["ID"]));
            ShowDeleteMessage();
        }
    }
    protected void btnVazgec_Click(object sender, EventArgs e)
    {
        //vazgeç 
        frw_Roller.ChangeMode(FormViewMode.ReadOnly);
    }
    protected void btnDuzenle_Click(object sender, EventArgs e)
    {
        //GÜNCELLEM 

        TextBox rolAd = frw_Roller.FindControl("rolAdTextBox") as TextBox;
        TextBox rolTanim= frw_Roller.FindControl("rolTanimTextBox") as TextBox;
        CheckBox rolYonetilir = frw_Roller.FindControl("YonetilebilirCheckBox") as CheckBox;

        usrRolDAL myRolDAL = new usrRolDAL();
        usrRolInfo myRolInfo = new usrRolInfo();
        myRolInfo.rolAd = rolAd.Text;
        myRolInfo.rolTanim = rolTanim.Text;

        if (rolYonetilir.Checked)
            myRolInfo.Yonetilebilir = true;
        else
            myRolInfo.Yonetilebilir = false;

        //myRolInfo.Yonetilebilir = Convert.ToBoolean(rolYonetilir.Checked);

        if (Request.QueryString["ID"] != null)
        {
            myRolInfo.rolID = Convert.ToInt32(Request.QueryString["ID"]);
        }
        myRolDAL.Update(myRolInfo);

    }
    protected void btnYeniKayit_Click(object sender, EventArgs e)
    {
        //YENİ KAYIT 

        TextBox rolAd = frw_Roller.FindControl("rolAdTextBox") as TextBox;
        TextBox rolTanim = frw_Roller.FindControl("rolTanimTextBox") as TextBox;
        CheckBox rolYonetilir = frw_Roller.FindControl("YonetilebilirCheckBox") as CheckBox;

        usrRolDAL myRolDAL = new usrRolDAL();
        usrRolInfo myRolInfo = new usrRolInfo();
        myRolInfo.rolAd = rolAd.Text;
        myRolInfo.rolTanim = rolTanim.Text;
        if (rolYonetilir.Checked)
            myRolInfo.Yonetilebilir = true;
        else
            myRolInfo.Yonetilebilir = false;

        if (Request.QueryString["ID"] != null)
        {
            myRolInfo.rolID = Convert.ToInt32(Request.QueryString["ID"]);
        }
        myRolDAL.Insert(myRolInfo);
    }
}
