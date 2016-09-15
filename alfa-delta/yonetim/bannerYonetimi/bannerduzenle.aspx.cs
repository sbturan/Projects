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
using System.IO;
using System.Collections.Generic;
using System.Xml;
using AlfaDeltaLogin;

public partial class yonetim_bannerYonetimi_bannerduzenle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string securitytype = ConfigurationManager.AppSettings.Get("securitytype");

        if (securitytype == "cookie")
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
                Response.Redirect("~/yonetim/giris.aspx");

            if (!User.IsInRole("Administrator"))
                Response.Redirect("~/yonetim/giris.aspx");
        }

        else
        {
            if (HttpContext.Current.Session["kullanici"] == null)
                Response.Redirect("~/yonetim/giris.aspx");

            if (Kullanici.UserInRole(((Kullanici)HttpContext.Current.Session["kullanici"]).Id, "Administrator") == false)
                Response.Redirect("~/yonetim/giris.aspx");
        }
        

        if (Request.QueryString["BANNER_ID"] == null)

             frm_Banner.ChangeMode(FormViewMode.Insert);

        else
             frm_Banner.ChangeMode(FormViewMode.ReadOnly);

    }
    protected void frm_Banner_ModeChanged(object sender, EventArgs e)
    {

    }
    protected void frm_Banner_ItemCommand(object sender, FormViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "_delete":
                frm_Banner.DeleteItem();
                frm_Banner.Visible = false;
                ShowDeleteMessage();
                break;
        }

    }
    protected void frm_Banner_ItemCreated(object sender, EventArgs e)
    {

    }

    protected void btn_Vazgec_Click(object sender, EventArgs e)
    {
        frm_Banner.ChangeMode(FormViewMode.ReadOnly);

    }
   
    protected void GetImageBrowser(object sender, EventArgs e)
    {
        string url = "";
        TextBox txt_Flp = frm_Banner.FindControl("txt_Banner") as TextBox;


        if (sender.GetType().ToString().Contains("Button"))
        {
            ((Button)sender).OnClientClick = "return openResimTarayici(this, 'Banner" + url + "', '" + txt_Flp.ClientID + "');";
        }
        else
        {
            ((FredCK.FCKeditorV2.FCKeditor)sender).ImageBrowserURL = "../../filemanager/browser/default/browser.html?Type=Banner" + url + "&Connector=connectors/aspx/connector.aspx";
        }

    }


    protected void btn_BannerEkle_Click(object sender, EventArgs e)
    {
        string gorsel = "";
        TextBox txt_Adi = frm_Banner.FindControl("txt_Adi") as TextBox;
        TextBox txt_Banner = frm_Banner.FindControl("txt_Banner") as TextBox;
        TextBox txt_URL = frm_Banner.FindControl("txt_URL") as TextBox;
        TextBox txt_genislik = frm_Banner.FindControl("txt_genislik") as TextBox;
        TextBox txt_yukseklik = frm_Banner.FindControl("txt_yukseklik") as TextBox;
        TextBox txt_relay = frm_Banner.FindControl("txt_relay") as TextBox;
        Label lbl_Yuklenen = frm_Banner.FindControl("lbl_Yuklenen") as Label;
        RadioButton rdGeri = frm_Banner.FindControl("rdGeri") as RadioButton;
        RadioButton rdList = frm_Banner.FindControl("rdList") as RadioButton;

        DropDownList drp_durum = frm_Banner.FindControl("drp_durum") as DropDownList;
        DropDownList drp_yayinyeri = frm_Banner.FindControl("drp_yayinyeri") as DropDownList;
        DropDownList drp_yayintipi = frm_Banner.FindControl("drp_yayintipi") as DropDownList;

        if (txt_Banner.Text != "")
        {
            string foto = txt_Banner.Text;
            int start = foto.IndexOf("/Files/");
            gorsel = foto.Substring(start + 1);
            lbl_Yuklenen.Text = "Yüklenen : " + gorsel;            
        }

        BannerInfo bannerINFO = new BannerInfo();
        BannerBLL bannerBLL = new BannerBLL();

        bannerINFO.ADI = txt_Adi.Text;
        bannerINFO.DOSYA = gorsel;
       
        bannerINFO.TIP = Convert.ToInt32(drp_yayintipi.SelectedValue);
        bannerINFO.URL = txt_URL.Text;
        bannerINFO.RELAY = Convert.ToInt64(txt_relay.Text);
        bannerINFO.GENISLIK = txt_genislik.Text;
        bannerINFO.YUKSEKLIK = txt_yukseklik.Text;
        bannerINFO.HIT = 0;
        bannerINFO.TARIH = DateTime.Now;
        bannerINFO.YAYIN_DURUMU=Convert.ToBoolean(drp_durum.SelectedValue);
        bannerBLL.Insert(bannerINFO);      


        if (rdGeri.Checked)
            Response.Redirect("bannerduzenle.aspx");


        else
            Response.Redirect("bannerlar.aspx");
    }
    protected void btn_Guncelle_Click(object sender, EventArgs e)
    {

        string gorsel = "";
        TextBox txt_Adi = frm_Banner.FindControl("txt_Adi") as TextBox;
        TextBox txt_Banner = frm_Banner.FindControl("txt_Banner") as TextBox;
        TextBox txt_URL = frm_Banner.FindControl("txt_URL") as TextBox;
        TextBox txt_genislik = frm_Banner.FindControl("txt_genislik") as TextBox;
        TextBox txt_yukseklik = frm_Banner.FindControl("txt_yukseklik") as TextBox;
        TextBox txt_relay = frm_Banner.FindControl("txt_relay") as TextBox;
        Label lbl_Yuklenen = frm_Banner.FindControl("lbl_Yuklenen") as Label;
        RadioButton rdGeri = frm_Banner.FindControl("rdGeri") as RadioButton;
        RadioButton rdList = frm_Banner.FindControl("rdList") as RadioButton;

        DropDownList drp_durum = frm_Banner.FindControl("drp_durum") as DropDownList;
        DropDownList drp_yayinyeri = frm_Banner.FindControl("drp_yayinyeri") as DropDownList;
        DropDownList drp_yayintipi = frm_Banner.FindControl("drp_yayintipi") as DropDownList;

        HiddenField hdn_ID = frm_Banner.FindControl("hdn_ID") as HiddenField;
        HiddenField hdn_Dosya = frm_Banner.FindControl("hdn_Dosya") as HiddenField;

        gorsel = hdn_Dosya.Value;

        if (txt_Banner.Text != "")
        {
            string foto = txt_Banner.Text;
            int start = foto.IndexOf("/Files/");
            gorsel = foto.Substring(start + 1);
            lbl_Yuklenen.Text = "Yüklenen : " + gorsel;
        }

        BannerInfo bannerINFO = new BannerInfo();
        BannerBLL bannerBLL = new BannerBLL();

        bannerINFO.ADI = txt_Adi.Text;
        bannerINFO.DOSYA = gorsel;
        
        bannerINFO.TIP = Convert.ToInt32(drp_yayintipi.SelectedValue);
        bannerINFO.URL = txt_URL.Text;
        bannerINFO.RELAY = Convert.ToInt64(txt_relay.Text);
        bannerINFO.GENISLIK = txt_genislik.Text;
        bannerINFO.YUKSEKLIK = txt_yukseklik.Text;
        bannerINFO.ID = Convert.ToInt32(hdn_ID.Value);
        bannerINFO.TARIH = DateTime.Now;
        bannerINFO.YAYIN_DURUMU = Convert.ToBoolean(drp_durum.SelectedValue);
        bannerBLL.Update(bannerINFO);
              

        if (rdGeri.Checked)
            Response.Redirect("bannerduzenle.aspx?BANNER_ID=" + bannerINFO.ID.ToString());

        else
            Response.Redirect("bannerlar.aspx");


    }

    private void ShowDeleteMessage()
    {
        lbl_Mesaj.Text = "<div style=\"border: solid 1px #d4dce6; color: #cc0000; font-size: 11px; font-weight: bold; padding: 3px; background-color: #f5f5ff\">Silme iþlemi baþarýlý</div>";
        lbl_Mesaj.Visible = true;
    }

    private void ShowInsertMessage(int banner_id)
    {
        lbl_Mesaj.Text = "<div style=\"border: solid 1px #d4dce6; color: #cc0000; font-size: 11px; font-weight: bold; padding: 3px; background-color: #f5f5ff\"> " + banner_id.ToString() + " Nolu Galeri Eklenmiþtir.</div>";
        lbl_Mesaj.Visible = true;
    }

    private void ShowUpdateMessage()
    {
        lbl_Mesaj.Text = "<div style=\"border: solid 1px #d4dce6; color: #cc0000; font-size: 11px; font-weight: bold; padding: 3px; background-color: #f5f5ff\">Güncelleme iþlemi baþarýlý</div>";
        lbl_Mesaj.Visible = true;
    }

    protected void btn_Yeni_Click(object sender, EventArgs e)
    {
        frm_Banner.ChangeMode(FormViewMode.Insert);
    }
    protected void btn_Duzenle_Click(object sender, EventArgs e)
    {
        frm_Banner.ChangeMode(FormViewMode.Edit);
    }
    protected void btn_xmlat_Click(object sender, EventArgs e)
    {
        
    }

    
    protected void frm_Banner_PageIndexChanging(object sender, FormViewPageEventArgs e)
    {

    }
}
