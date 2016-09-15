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



public partial class yonetim_urunduzenle1 : System.Web.UI.Page
{
    string resim;
    string gorsel;
    DataTable DT;
    List<KategoriInfo> info = new List<KategoriInfo>();
    KategoriBLL bur = new KategoriBLL();
    int id;
    ArrayList aList = new ArrayList();
    public string adi;
    int c = 0;
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
       

     

        if (!Page.IsPostBack)
        {
            id = Convert.ToInt16(Request.QueryString["ID"].ToString());

            UrunInfo aa = new UrunInfo();
            UrunBLL bb = new UrunBLL();
            aa = bb.GetUrunBy1ID(id);
            txt_Adi.Text = aa.ADI;
            txt_Resim.Text = aa.ICON;
            TextBox1.Text = aa.PDF;
            img_Resim.ImageUrl = "~/resize.ashx?adres=" +aa.ICON + "&gen=100&yuk=80&tip=K";
            drp_Dil.SelectedValue = aa.DIL;
            drp_YayinDurumu.SelectedValue = Convert.ToString(aa.YAYIN_DURUMU);

            DDLDoldur();


        }
        if (!IsPostBack)
        {



        }
        
    }
    protected void DDLDoldur()
    {
        
       
        SqlConnection baglanti = new SqlConnection("Data Source=mssql195.win-servers.com;Initial Catalog=alfadelta;User ID=alfadelta;Password=adx9080");
        baglanti.Open();
        DT = new DataTable();
        SqlDataAdapter Adapter = new SqlDataAdapter();
        Adapter = new SqlDataAdapter("select * from urun_kategori where urun_kategoriID not in ( select  ust_id from urun_kategori)", baglanti);
        Adapter.Fill(DT);
        baglanti.Close();

        //  DropDownList drp = ((frm_AltSayfaDuzen.FindControl("Drpustid") as DropDownList));

       
        ListItem list1 = new ListItem();
        list1.Text = "Kategorisi Seçiniz ";
        list1.Value = "-2";

        Drpustid.Items.Add(list1);

        DataRow[] RootRows = DT.Select();

        foreach (DataRow dr in RootRows)
        {
            ListItem li = new ListItem();

            li.Text = dr["kadi"].ToString();

            li.Value = dr["urun_kategoriID"].ToString();
            Drpustid.Items.Add(li);



        }
        ListItem list = new ListItem();
        list.Text = "Kategorisi YOK";
        list.Value = "-1";
        Drpustid.Items.Add(list);
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



    protected void GetImageBrowser(object sender, EventArgs e)
    {
        string url = "";
       


        if (sender.GetType().ToString().Contains("Button"))
        {
            ((Button)sender).OnClientClick = "return openFileBrowser(this, 'fotograflar" + url + "', '" + txt_Resim.ClientID + "');";
        }
        else
        {
            ((FredCK.FCKeditorV2.FCKeditor)sender).ImageBrowserURL = "../filemanager/browser/default/browser.html?Type=fotograflar" + url + "&Connector=connectors/aspx/connector.aspx";
        }
    }
    protected void GetImageBrowser1(object sender, EventArgs e)
    {
        string url = "";
       


        if (sender.GetType().ToString().Contains("Button"))
        {
            ((Button)sender).OnClientClick = "return openFileBrowser(this, 'Pdf" + url + "', '" + TextBox1.ClientID + "');";
        }
        else
        {
            ((FredCK.FCKeditorV2.FCKeditor)sender).ImageBrowserURL = "../filemanager/browser/default/browser.html?Type=fotograflar" + url + "&Connector=connectors/aspx/connector.aspx";
        }
    }




    protected void btn_Guncelle_Click(object sender, EventArgs e)
    {
      
        UrunInfo icinfo = new UrunInfo();
        icinfo.ADI = txt_Adi.Text;
        icinfo.KTG_ID = Convert.ToInt32(Drpustid.SelectedValue);
        icinfo.TARIH = DateTime.Now;
       
        if (txt_Resim.Text != "")
        {
            string foto = txt_Resim.Text;
            int start = foto.IndexOf("/Files/");
            resim = foto.Substring(start + 1);
            lbl_Yuklenen.Text = "Yüklenen resim " + resim;
            icinfo.ICON = resim;
            if (resim != "")
            {
               img_Resim.Visible = true;
             img_Resim.ImageUrl = "~/resize.ashx?adres=" + resim + "&gen=100&yuk=80&tip=K";
            }

        }
        if (TextBox1.Text != "")
        {
            string foto = TextBox1.Text;
            int start = foto.IndexOf("/Files/");
            gorsel = foto.Substring(start + 1);
            icinfo.PDF = gorsel;
            Label2.Text = "Yüklenen : " + gorsel;
        }

       
        icinfo.YAYIN_DURUMU = Convert.ToBoolean(drp_YayinDurumu.SelectedValue);
        icinfo.DIL = "tr";
       
        icinfo.ID = Convert.ToInt16(Request.QueryString["ID"].ToString());

        new UrunBLL().Update(icinfo);
        ShowUpdateMessage();
    }
   
}
