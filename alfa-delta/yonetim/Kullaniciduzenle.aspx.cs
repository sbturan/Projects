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

public partial class yonetim_kullaniciduzenle : System.Web.UI.Page
{
    public string roleid = "";
    public int roleidim = 3;
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
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


        if (Request.QueryString["ID"] == null)
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
        lbl_Mesaj.Text = "<div style=\"border: solid 1px #d4dce6; color: #cc0000; font-size: 11px; font-weight: bold; padding: 3px; background-color: #f5f5ff\">Silme islemi basarılı</div>";
        lbl_Mesaj.Visible = true;
    }

    private void ShowInsertMessage()
    {
        lbl_Mesaj.Text = "<div style=\"border: solid 1px #d4dce6; color: #cc0000; font-size: 11px; font-weight: bold; padding: 3px; background-color: #f5f5ff\">Kaydetme islemi basarılı</div>";
        lbl_Mesaj.Visible = true;
    }

    private void ShowUpdateMessage()
    {
        lbl_Mesaj.Text = "<div style=\"border: solid 1px #d4dce6; color: #cc0000; font-size: 11px; font-weight: bold; padding: 3px; background-color: #f5f5ff\">Güncelleme islemi basarılı</div>";
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
         
         Users1Info icinfo = new  Users1Info();
       
        if (((frm_AltSayfaDuzen.FindControl("txt_Adi") as TextBox).Text) != null)
        {
            icinfo.Adi = ((frm_AltSayfaDuzen.FindControl("txt_Adi") as TextBox).Text);
        }
        if (((frm_AltSayfaDuzen.FindControl("txt_Email") as TextBox).Text) != null)
        {
            icinfo.Email = ((frm_AltSayfaDuzen.FindControl("txt_Email") as TextBox).Text);
        }
        if (((frm_AltSayfaDuzen.FindControl("txt_TelNo") as TextBox).Text) != null)
        {
            icinfo.Telefon = ((frm_AltSayfaDuzen.FindControl("txt_TelNo") as TextBox).Text);
        }
        if (((frm_AltSayfaDuzen.FindControl("TextBox2") as TextBox).Text) != null)
        {
            icinfo.Sifre = ((frm_AltSayfaDuzen.FindControl("TextBox2") as TextBox).Text);
        }



        if (((frm_AltSayfaDuzen.FindControl("txt_Soyadi") as TextBox).Text) != null)
        {
            icinfo.Soyadi = ((frm_AltSayfaDuzen.FindControl("txt_Soyadi") as TextBox).Text);
        }
      
        if (((frm_AltSayfaDuzen.FindControl("drpdurum") as DropDownList).SelectedValue) != null)
        {
            icinfo.Durum = Convert.ToBoolean((frm_AltSayfaDuzen.FindControl("drpdurum") as DropDownList).SelectedValue);
        }
      

        
      
      
       
        
          
        if (IsUpdate)
        {
            icinfo.Id = Convert.ToInt32((frm_AltSayfaDuzen.FindControl("hdn_ID") as HiddenField).Value);
           UsersBLL getir=new UsersBLL();
            UsersInfo lan=new UsersInfo();
            lan=getir.BulByID(Convert.ToInt32((frm_AltSayfaDuzen.FindControl("hdn_ID") as HiddenField).Value));
       
            if (icinfo.Id == 1)
                icinfo.RoleId = 1;
            else
                icinfo.RoleId = 3;
            new Users1BLL().Guncelle(icinfo);
            UserRolesInfo info2 = new UserRolesInfo();
            info2.UserID = icinfo.Id;
           
            
            new UserRolesBLL().Guncelle(info2);

            ShowUpdateMessage();

        }
        else
        {
            icinfo.RoleId = 3;
            int id=new Users1BLL().Insert1(icinfo);
            frm_AltSayfaDuzen.Visible = false;
            UserRolesInfo info2 = new UserRolesInfo();
            info2.UserID = id;
            info2.RoleID = 3;
            new UserRolesBLL().Insert(info2);
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
                try
                {
                    frm_AltSayfaDuzen.DeleteItem();
                }
                catch
                {

                    Response.Write("<script language='JavaScript'>alert(' Kullanici Bilgileri Kullanıldığı İçin Silinemez ');window.location = ' kullanicilar.aspx ';</script>");

                }
                    frm_AltSayfaDuzen.Visible = false;
                    ShowDeleteMessage();
                    break;
                
               
        }
    }

    protected void frm_AltSayfaDuzen_ItemCreated(object sender, EventArgs e)
    {

    }
    protected void frm_AltSayfaDuzen_ModeChanged(object sender, EventArgs e)
    {


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


    protected void Button1_Click(object sender, EventArgs e)
    {



    }

    protected void btn_Videolar_Click(object sender, EventArgs e)
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
