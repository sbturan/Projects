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
using System.Collections.Generic;

using System.Xml;
using System.Data.SqlClient;
using System.Text;

public partial class yonetim_acıklamaduzenle : System.Web.UI.Page
{
    int id;
    string kont;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Convert.ToInt32(Request.QueryString["URUN_ID"].ToString());
        //ObjectDataSource2.DataObjectTypeName = "ContentInfo";
        //ObjectDataSource2.TypeName = "ContentBLL";
        if (!IsPostBack)
        {
            //hdn_Deger.Value = "";
        }

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
        //MenuBLL bl = new MenuBLL();
        //MenuInfo inf = new MenuInfo();

        //inf = bl.MenuByID(Convert.ToInt32(hdn_Deger.Value));

        //if (bl.Asagi(inf.ANA_MENU_GRUP, inf.ID))
        //{
        //    lbl_hata.Visible = true;
        //    lbl_hata.Text = "Ýþleminiz Yapýlmýþtýr.";
        //    Bind();
        //}

        UrunAciklamaBLL uracbl=new UrunAciklamaBLL();
        
        List<UrunAciklamaInfo> list = uracbl.GetUAbyUrunID(Convert.ToInt32(Request.QueryString["URUN_ID"].ToString()), "tr");
        for (int ix = 0; ix < list.Count; ix++)
        {
            kont = list[ix].URUNAC_ID.ToString();
        }
        if (kont==null)
        {

            frm_AltSayfaDuzen.ChangeMode(FormViewMode.Insert);
        }
        else
        {
            frm_AltSayfaDuzen.ChangeMode(FormViewMode.ReadOnly);
        }
    }

   

    private void ShowDeleteMessage()
    {
        lbl_Mesaj.Text = "<div style=\"border: solid 1px #d4dce6; color: #cc0000; font-size: 11px; font-weight: bold; padding: 3px; background-color: #f5f5ff\">Silme işlemi başarılı</div>";
        lbl_Mesaj.Visible = true;
    }

    private void ShowInsertMessage()
    {
        lbl_Mesaj.Text = "<div style=\"border: solid 1px #d4dce6; color: #cc0000; font-size: 11px; font-weight: bold; padding: 3px; background-color: #f5f5ff\">Kaydetme işlemi başarılı</div>";
        lbl_Mesaj.Visible = true;
    }

    private void ShowUpdateMessage()
    {
        lbl_Mesaj.Text = "<div style=\"border: solid 1px #d4dce6; color: #cc0000; font-size: 11px; font-weight: bold; padding: 3px; background-color: #f5f5ff\">Güncelleme işlemi başarılı</div>";
        lbl_Mesaj.Visible = true;
    }
    protected void btn_Kaydet_Click(object sender, EventArgs e)
    {
        SaveOrUpdate(false);

       

    }

    public string htmltotext(string icerik)
    {

        
        string stripped = System.Text.RegularExpressions.Regex.Replace(icerik, @"<(.|\n)*?>", string.Empty);
        stripped = stripped.Replace("&Uuml;", "Ü");
        stripped = stripped.Replace("&ccedil;", "ç");
        stripped = stripped.Replace("&uuml;", "ü");
        stripped = stripped.Replace("&Ccedil;", "Ç");
        stripped = stripped.Replace("&rsquo;", "'");
        stripped = stripped.Replace("&ouml;", "ö");
        stripped = stripped.Replace("&Ouml;", "Ö");
        stripped = stripped.Replace("&nbsp;", " ");
        stripped = stripped.Replace("&ldquo;", " ");
        stripped = stripped.Replace("'", "`");


        return stripped;


    }

    protected void btn_Guncelle_Click(object sender, EventArgs e)
    {
        SaveOrUpdate(true);
        
    }

    private void SaveOrUpdate(bool IsUpdate)
    {
        UrunAciklamaInfo icinfo = new UrunAciklamaInfo();
        icinfo.URUN_ID = id;
        
        icinfo.ACIKLAMA = (frm_AltSayfaDuzen.FindControl("FCKeditor1") as FredCK.FCKeditorV2.FCKeditor).Value;

        if (((frm_AltSayfaDuzen.FindControl("drp_Dil") as DropDownList).SelectedValue) != null)
        {
            icinfo.DIL = ((frm_AltSayfaDuzen.FindControl("drp_Dil") as DropDownList).SelectedValue);
        }
        

        if (IsUpdate)
        {
            
            new UrunAciklamaBLL().Update(icinfo);
            ShowUpdateMessage();
            
        }
        else
        {
            new UrunAciklamaBLL().Insert(icinfo);
            frm_AltSayfaDuzen.Visible = false;
            ShowInsertMessage();
         
        }
        frm_AltSayfaDuzen.ChangeMode(FormViewMode.ReadOnly);
    }

    protected void btn_Yeni_Click(object sender, EventArgs e)
    {
        frm_AltSayfaDuzen.ChangeMode(FormViewMode.Insert);
    }
    protected void btn_Vazgec_Click(object sender, EventArgs e)
    {
        frm_AltSayfaDuzen.ChangeMode(FormViewMode.ReadOnly);
    }
    protected void btn_Sil_Click(object sender, EventArgs e)
    {

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
            ((Button)sender).OnClientClick = "return openFileBrowser(this, 'fotograflar" + url + "', '" + txt_Resim.ClientID + "');";
        }
        else
        {
            ((FredCK.FCKeditorV2.FCKeditor)sender).ImageBrowserURL = "../filemanager/browser/default/browser.html?Type=fotograflar" + url + "&Connector=connectors/aspx/connector.aspx";
        }
    }
    protected void btn_Sil_Click1(object sender, EventArgs e)
    {

    }


   

    protected void btn_Duzenle_Click(object sender, EventArgs e)
    {

        frm_AltSayfaDuzen.ChangeMode(FormViewMode.Edit);
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        //hdn_menu.Value = this.TreeView1.SelectedNode.Value;
        frm_AltSayfaDuzen.ChangeMode(FormViewMode.Edit);
    }
    protected void TreeView1_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
    {
        frm_AltSayfaDuzen.ChangeMode(FormViewMode.Edit);

    }
}
