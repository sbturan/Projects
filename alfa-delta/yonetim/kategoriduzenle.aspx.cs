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



public partial class yonetim_kategoriduzenle : System.Web.UI.Page
{
    DataTable DT;
    List<KategoriInfo> info = new List<KategoriInfo>();
    KategoriBLL bur = new KategoriBLL();

    ArrayList aList = new ArrayList();
    public string adi;
    int c=0;
    protected void Page_Load(object sender, EventArgs e)
    {
      
   
    

        if (!Page.IsPostBack)
        {

         
           
        }
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

           frm_AltSayfaDuzen.ChangeMode(FormViewMode.Edit);

       }

      
      //  DropDownList drp2 = ((frm_AltSayfaDuzen.FindControl("Drpustid") as DropDownList));



       if (!Page.IsPostBack)
       {




           SqlConnection baglanti = new SqlConnection("Data Source=mssql195.win-servers.com;Initial Catalog=alfadelta;User ID=alfadelta;Password=adx9080");
           baglanti.Open();
           DT = new DataTable();
           SqlDataAdapter Adapter = new SqlDataAdapter();
           Adapter = new SqlDataAdapter("SELECT urun_kategoriID, ust_id, kadi FROM urun_kategori", baglanti);
           Adapter.Fill(DT);
           baglanti.Close();


           //DropDownList drp = ((frm_AltSayfaDuzen.FindControl("DropDownList1") as DropDownList));
           //drp.Items.Clear();

           DataRow[] RootRows = DT.Select("ust_id=" + 0);

           DDLDoldur(RootRows, "");
           if (Request.QueryString["ID"] != null)
           {
               DropDownList b = (frm_AltSayfaDuzen.FindControl("Drpustid") as DropDownList);
               KategoriBLL a = new KategoriBLL();
               KategoriInfo c = new KategoriInfo();
               c = a.GetKategoriByID(Convert.ToInt32(Request.QueryString.Get("ID")));

               b.SelectedValue = c.UST_ID.ToString();
           }
       }

    }
    protected void DDLDoldur(DataRow[] drc, string girinti)
    {
      
        DropDownList drp = ((frm_AltSayfaDuzen.FindControl("Drpustid") as DropDownList));
        if (c == 0)
        {
            if (drc[0][1].Equals(0))
            {
                ListItem list = new ListItem();
                list.Text = "Kategori Seçiniz";
                list.Value = "31";
                drp.Items.Add(list);
                c++;
            }
        
        }
        foreach (DataRow dr in drc)
        {
                        ListItem li = new ListItem();
            
            li.Text = girinti + dr["kadi"].ToString();
            
            li.Value = dr["urun_kategoriID"].ToString();
                        drp.Items.Add(li);

                        DataRow[] SubRows = DT.Select("ust_id = " + dr["urun_kategoriID"].ToString());
            
            DDLDoldur(SubRows, girinti + "--");
            
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
        string resim = IsUpdate ? (frm_AltSayfaDuzen.FindControl("hdn_Foto") as HiddenField).Value : "";
        if ((frm_AltSayfaDuzen.FindControl("txt_Resim") as TextBox).Text != "")
        {
            string foto = (frm_AltSayfaDuzen.FindControl("txt_Resim") as TextBox).Text;
            int start = foto.IndexOf("/Files/");
            resim = foto.Substring(start + 1);
            (frm_AltSayfaDuzen.FindControl("lbl_Yuklenen") as Label).Text = "Yüklenen resim " + resim;

            if (resim != null )
            {
                (frm_AltSayfaDuzen.FindControl("img_Resim") as Image).Visible = true;
                (frm_AltSayfaDuzen.FindControl("img_Resim") as Image).ImageUrl = "~/resize.ashx?adres=" + resim + "&gen=100&yuk=80&tip=K";
            }
        }


        KategoriInfo icinfo = new KategoriInfo();
        icinfo.ADI = (frm_AltSayfaDuzen.FindControl("txt_Adi") as TextBox).Text;
        if ((frm_AltSayfaDuzen.FindControl("Drpustid") as DropDownList).SelectedValue != "")
        {
            icinfo.UST_ID = Convert.ToInt32((frm_AltSayfaDuzen.FindControl("Drpustid") as DropDownList).SelectedValue);
        }
        else {
            KategoriInfo infor2  = new KategoriInfo();
            KategoriBLL getir23 = new KategoriBLL();
            infor2 = getir23.GetKategoriByID(Convert.ToInt32((frm_AltSayfaDuzen.FindControl("hdn_ID") as HiddenField).Value));
            icinfo.UST_ID = infor2.UST_ID;
        }

        icinfo.YAYIN_DURUMU = Convert.ToBoolean((frm_AltSayfaDuzen.FindControl("drp_YayinDurumu") as DropDownList).SelectedValue);
        icinfo.LISTE = Convert.ToBoolean((frm_AltSayfaDuzen.FindControl("DropDownList3") as DropDownList).SelectedValue);
       if(icinfo.LISTE == false){
           icinfo.SAYFA = Convert.ToInt32((frm_AltSayfaDuzen.FindControl("DropDownList2") as DropDownList).SelectedValue);
       }
        icinfo.ICON = resim;
      

      
      

        if (IsUpdate)
        {
            icinfo.ID = Convert.ToInt32((frm_AltSayfaDuzen.FindControl("hdn_ID") as HiddenField).Value);
            new KategoriBLL().Update(icinfo);
            ShowUpdateMessage();

        }
        else
        {
            new KategoriBLL().Insert(icinfo);
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

    
    protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
    {

        

        DropDownList drp1 = ((frm_AltSayfaDuzen.FindControl("DropDownList1") as DropDownList));
        DropDownList drp2 = ((frm_AltSayfaDuzen.FindControl("Drpustid") as DropDownList));
        drp2.Visible = true;
        drp1.Visible = false;
        
        int c= Convert.ToInt32(drp1.SelectedValue.ToString());

        SqlConnection baglanti = new SqlConnection("Data Source=mssql195.win-servers.com;Initial Catalog=alfadelta;User ID=alfadelta;Password=adx9080");
        baglanti.Open();
        DT = new DataTable();
        SqlDataAdapter Adapter = new SqlDataAdapter();
        Adapter = new SqlDataAdapter("SELECT urun_kategoriID, ust_id, kadi FROM urun_kategori", baglanti);
        Adapter.Fill(DT);
        baglanti.Close();


        DropDownList drp = ((frm_AltSayfaDuzen.FindControl("Drpustid") as DropDownList));
        drp.Items.Clear();
        DataRow[] RootRows = DT.Select("ust_id="+c);
        DDLDoldur(RootRows, "");
    }

    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList drp5 = ((frm_AltSayfaDuzen.FindControl("DropDownList2") as DropDownList));
        DropDownList drp6 = ((frm_AltSayfaDuzen.FindControl("DropDownList3") as DropDownList));
        if (Convert.ToBoolean(drp6.SelectedValue.ToString()) == true)
   drp5.Visible=false;
        else{
            drp5.Visible=true;
        }

    }

    protected void DropDownList3_SelectedIndexChanged1(object sender, EventArgs e)
    {
        DropDownList drp5 = ((frm_AltSayfaDuzen.FindControl("DropDownList2") as DropDownList));
        DropDownList drp6 = ((frm_AltSayfaDuzen.FindControl("DropDownList3") as DropDownList));
        if (Convert.ToBoolean(drp6.SelectedValue.ToString()) == true)
            drp5.Visible = false;
        else
        {
            drp5.Visible = true;
        }
    }
}
