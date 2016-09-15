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

public partial class yonetim_urunduzenle : System.Web.UI.Page
{
     DataTable DT;
    
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        //ObjectDataSource2.DataObjectTypeName = "ContentInfo";
        //ObjectDataSource2.TypeName = "ContentBLL";
        if (!IsPostBack)
        {
            
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



        HesapInfo icinfo = new HesapInfo();
        icinfo.ID = Convert.ToInt32(Request.QueryString["ID"]);

        if (((frm_AltSayfaDuzen.FindControl("txt_Adi") as TextBox).Text) != null)
        {
            icinfo.BANK_ADI = ((frm_AltSayfaDuzen.FindControl("txt_Adi") as TextBox).Text);
        }


        if (((frm_AltSayfaDuzen.FindControl("txt_kdvorani") as TextBox).Text) != null)
        {
            icinfo.HESAP_NO = ((frm_AltSayfaDuzen.FindControl("txt_kdvorani") as TextBox).Text);
        }
        if (((frm_AltSayfaDuzen.FindControl("txt_stok") as TextBox).Text) != null)
        {
            icinfo.SUBE_ADI = ((frm_AltSayfaDuzen.FindControl("txt_stok") as TextBox).Text);
        }
        if (((frm_AltSayfaDuzen.FindControl("txt_kritik") as TextBox).Text) != null)
        {
            icinfo.HESAP_TUR = ((frm_AltSayfaDuzen.FindControl("txt_kritik") as TextBox).Text);
        }
        

        if (((frm_AltSayfaDuzen.FindControl("txt_fiyat") as TextBox).Text) != null)
        {
            icinfo.IBAN_NO = ((frm_AltSayfaDuzen.FindControl("txt_fiyat") as TextBox).Text);
        }


        
        new BankBLL().Update(icinfo);
        ShowUpdateMessage();
        Response.Redirect("bankalar.aspx");

    }

    private void SaveOrUpdate(bool IsUpdate)
    {
        
          


            HesapInfo icinfo = new HesapInfo();
            
            if (((frm_AltSayfaDuzen.FindControl("txt_Adi") as TextBox).Text) != null)
            {
                icinfo.BANK_ADI = ((frm_AltSayfaDuzen.FindControl("txt_Adi") as TextBox).Text);
            }
           
           
            if (((frm_AltSayfaDuzen.FindControl("txt_kdvorani") as TextBox).Text) != null)
            {
                icinfo.IBAN_NO = ((frm_AltSayfaDuzen.FindControl("txt_kdvorani") as TextBox).Text);
            }
            if (((frm_AltSayfaDuzen.FindControl("txt_stok") as TextBox).Text) != null)
            {
                icinfo.SUBE_ADI = ((frm_AltSayfaDuzen.FindControl("txt_stok") as TextBox).Text);
            }
            if (((frm_AltSayfaDuzen.FindControl("txt_kritik") as TextBox).Text) != null)
            {
                icinfo.HESAP_TUR = ((frm_AltSayfaDuzen.FindControl("txt_kritik") as TextBox).Text);
            }
           
           
            if (((frm_AltSayfaDuzen.FindControl("txt_fiyat") as TextBox).Text) != null)
            {
                icinfo.HESAP_NO = ((frm_AltSayfaDuzen.FindControl("txt_fiyat") as TextBox).Text);
            }
          

            if (IsUpdate)
            {
                icinfo.ID = Convert.ToInt32((frm_AltSayfaDuzen.FindControl("hdn_ID") as HiddenField).Value);
                new BankBLL().Update(icinfo);
                ShowUpdateMessage();

            }
            else
            {
                new BankBLL().Insert(icinfo);
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
               int  id = Convert.ToInt32(Request.QueryString["ID"]);
               HesapInfo urun = new HesapInfo();
               BankBLL bur = new BankBLL();
                bur.Delete(id);
            
                ShowDeleteMessage();
                Response.Redirect("bankalar.aspx");
                break;
        }
    }

    protected void frm_AltSayfaDuzen_ItemCreated(object sender, EventArgs e)
    {

    }
    protected void frm_AltSayfaDuzen_ModeChanged(object sender, EventArgs e)
    {


    }
   
    


    protected void Button1_Click(object sender, EventArgs e)
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
