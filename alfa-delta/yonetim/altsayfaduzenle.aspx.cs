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
public partial class yonetim_altsayfaduzenle : System.Web.UI.Page
{
    public string dil = "";
    protected void Page_Load(object sender, EventArgs e)
    {
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
        
        if(Request.QueryString["ID"] ==null)
        
        frm_AltSayfaDuzen.ChangeMode(FormViewMode.Insert);

        else

        frm_AltSayfaDuzen.ChangeMode(FormViewMode.ReadOnly);
        

    }

    private void ShowDeleteMessage()
    {
        lbl_Mesaj.Text = "<div style=\"border: solid 1px #d4dce6; color: #cc0000; font-size: 11px; font-weight: bold; padding: 3px; background-color: #f5f5ff\">Silme iþlemi baþarýlý</div>";
        lbl_Mesaj.Visible = true;
    }

    private void ShowInsertMessage()
    {
        lbl_Mesaj.Text = "<div style=\"border: solid 1px #d4dce6; color: #cc0000; font-size: 11px; font-weight: bold; padding: 3px; background-color: #f5f5ff\">Kaydetme iþlemi baþarýlý</div>";
        lbl_Mesaj.Visible = true;
    }

    private void ShowUpdateMessage()
    {
        lbl_Mesaj.Text = "<div style=\"border: solid 1px #d4dce6; color: #cc0000; font-size: 11px; font-weight: bold; padding: 3px; background-color: #f5f5ff\">Güncelleme iþlemi baþarýlý</div>";
        lbl_Mesaj.Visible = true;
    }
    protected void btn_Kaydet_Click(object sender, EventArgs e)
    {
        int last_id = 0;
        TextBox txt_Konu = frm_AltSayfaDuzen.FindControl("txt_Konu") as TextBox;
     
        FredCK.FCKeditorV2.FCKeditor FCKeditor1 = frm_AltSayfaDuzen.FindControl("FCKeditor1") as FredCK.FCKeditorV2.FCKeditor;
        DropDownList drp_YayinDurumu = frm_AltSayfaDuzen.FindControl("drp_YayinDurumu") as DropDownList;
        DropDownList drp_Dil = frm_AltSayfaDuzen.FindControl("drp_Dil") as DropDownList;
              
        string master_durum = ConfigurationManager.AppSettings.Get("cokludil");
     
        IcerikInfo icinfo = new IcerikInfo();
        icinfo.KONU = txt_Konu.Text;
        icinfo.MENU_ID = 0;
        icinfo.YAYIN_DURUMU = Convert.ToBoolean(drp_YayinDurumu.SelectedValue);
        icinfo.DIL = Convert.ToString(drp_Dil.SelectedValue);
        icinfo.ACIKLAMA = FCKeditor1.Value;
        IcerikBLL icbll = new IcerikBLL();
        last_id=icbll.Insert(icinfo);
        frm_AltSayfaDuzen.ChangeMode(FormViewMode.ReadOnly);
        frm_AltSayfaDuzen.Visible = false;
        ShowInsertMessage();
       

    }
    protected void btn_Guncelle_Click(object sender, EventArgs e)
    {
        
        TextBox txt_Konu = frm_AltSayfaDuzen.FindControl("txt_Konu") as TextBox;
      
        FredCK.FCKeditorV2.FCKeditor FCKeditor1 = frm_AltSayfaDuzen.FindControl("FCKeditor1") as FredCK.FCKeditorV2.FCKeditor;
        DropDownList drp_YayinDurumu = frm_AltSayfaDuzen.FindControl("drp_YayinDurumu") as DropDownList;
        DropDownList drp_Dil = frm_AltSayfaDuzen.FindControl("drp_Dil") as DropDownList;
        HiddenField hdn_ID = frm_AltSayfaDuzen.FindControl("hdn_ID") as HiddenField;
       
        string master_durum = ConfigurationManager.AppSettings.Get("cokludil");

        IcerikInfo icinfo = new IcerikInfo();
        icinfo.ID = Convert.ToInt32(hdn_ID.Value);
        icinfo.KONU = txt_Konu.Text;
        icinfo.MENU_ID = 0;
        icinfo.YAYIN_DURUMU = Convert.ToBoolean(drp_YayinDurumu.SelectedValue);
       
           // icinfo.MASTER_ID = 0;
        icinfo.DIL = Convert.ToString(drp_Dil.SelectedValue);
            icinfo.ACIKLAMA = FCKeditor1.Value;
        IcerikBLL icbll = new IcerikBLL();
        icbll.Update(icinfo);

        frm_AltSayfaDuzen.ChangeMode(FormViewMode.ReadOnly);
        ShowUpdateMessage();
    }
    protected void btn_Sil_Click(object sender, EventArgs e)
    {

    }
    protected void btn_Duzenle_Click(object sender, EventArgs e)
    {
        frm_AltSayfaDuzen.ChangeMode(FormViewMode.Edit);
    }
    protected void btn_Yeni_Click(object sender, EventArgs e)
    {
        frm_AltSayfaDuzen.ChangeMode(FormViewMode.Insert);
    }
    protected void btn_Vazgec_Click(object sender, EventArgs e)
    {
        frm_AltSayfaDuzen.ChangeMode(FormViewMode.ReadOnly);
    }
    protected void frm_AltSayfaDuzen_ItemCommand(object sender, FormViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "_delete":
                frm_AltSayfaDuzen.DeleteItem();
                frm_AltSayfaDuzen.Visible = false;
                ShowDeleteMessage();
                break;
        }

    }
    protected void frm_AltSayfaDuzen_ItemCreated(object sender, EventArgs e)
    {
        //Panel pnl_Master = frm_AltSayfaDuzen.FindControl("pnl_Master") as Panel;
        //string master_durum = ConfigurationManager.AppSettings.Get("cokludil");
        //if (master_durum == "1")
        //    pnl_Master.Visible = true;
        //else
        //    pnl_Master.Visible = false;
    }
    protected void frm_AltSayfaDuzen_ModeChanged(object sender, EventArgs e)
    {

        //Panel pnl_Master = frm_AltSayfaDuzen.FindControl("pnl_Master") as Panel;
        //string master_durum = ConfigurationManager.AppSettings.Get("cokludil");
        //if (master_durum == "1")
        //    pnl_Master.Visible = true;
        //else
        //    pnl_Master.Visible = false;

    }
  
    protected void GetImageBrowser(object sender, EventArgs e)
    {
        string url = "";
        TextBox txt_Resim = frm_AltSayfaDuzen.FindControl("txt_Resim") as TextBox;


        if (sender.GetType().ToString().Contains("Button"))
        {
            ((Button)sender).OnClientClick = "return openFileBrowser(this, 'fotograflar" + url + "', '"+txt_Resim.ClientID+"');";
        }
        else
        {
            ((FredCK.FCKeditorV2.FCKeditor)sender).ImageBrowserURL = "../filemanager/browser/default/browser.html?Type=fotograflar" + url + "&Connector=connectors/aspx/connector.aspx";
        }

    }
    protected void frm_AltSayfaDuzen_PageIndexChanging(object sender, FormViewPageEventArgs e)
    {

    }
}
