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
public partial class yonetim_urunKategori : System.Web.UI.Page
{
    DataTable DT;
    List<KategoriInfo> info = new List<KategoriInfo>();
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

            DDLDoldur();


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

        drp.Items.Add(list1);

        DataRow[] RootRows = DT.Select();

        foreach (DataRow dr in RootRows)
        {
            ListItem li = new ListItem();

            li.Text = dr["kadi"].ToString();

            li.Value = dr["urun_kategoriID"].ToString();
            drp.Items.Add(li);



        }
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int sayi = Convert.ToInt32( drp.SelectedValue.ToString());
        try
        {
            UrunBLL a = new UrunBLL();
            a.Updateurunkategori(sayi);
            lbluyarı.Visible = true;
            lbluyarı.Text = "İşleminiz Gerçekleştirildi";
        }
        catch {

            lbluyarı.Visible = true;
            lbluyarı.Text = "Hata oluştu";
        }

    }
}