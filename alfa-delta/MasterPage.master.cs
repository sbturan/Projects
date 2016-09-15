using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net;
using System.IO;
using System.Data.SqlClient;

public partial class MasterPage : System.Web.UI.MasterPage
{
    DataTable DT;
    int c = 0;
    int a;

    protected void Page_Load(object sender, EventArgs e)
    {
    Page.Title = "ALFA-DELTA";

        if(Session["dil"]== "en"){
          
          Label5.Text = "Euro Sales";
          
            Label7.Text = "Dolar Sales";
            Label9.Text = "Contact";
            Label10.Text = "Home";
        
        }

        if (!Page.IsPostBack)
        {

            SqlConnection baglanti = new SqlConnection("Data Source=mssql195.win-servers.com;Initial Catalog=alfadelta;User ID=alfadelta;Password=adx9080");
            baglanti.Open();
            DT = new DataTable();
            SqlDataAdapter Adapter = new SqlDataAdapter();
            Adapter = new SqlDataAdapter("SELECT distinct urun_kategoriID, ust_id, kadi,seviye FROM urun_kategori", baglanti);
            Adapter.Fill(DT);
            baglanti.Close();


            //DropDownList drp = ((frm_AltSayfaDuzen.FindControl("DropDownList1") as DropDownList));
            //drp.Items.Clear();

            DataRow[] RootRows = DT.Select("ust_id=" + 0);

            DDLDoldur(RootRows, "");

        }
        ParaalBLL dene = new ParaalBLL();
        ParaalInfo info1 = new ParaalInfo();
        info1 = dene.GetKur();
      
        lbl_ds.Text = info1.DOLARS.ToString();
      
        lbl_es.Text = info1.EUROS.ToString();
    }

    protected void DDLDoldur(DataRow[] drc, string girinti)
    {


     
        foreach (DataRow dr in drc)
        {
            if (dr["seviye"].ToString() == "")
            {
                 a = 2;

            }
            else
            {

                a = Convert.ToInt32(dr["seviye"].ToString());

            }
              ListItem li = new ListItem();

                li.Text = girinti + dr["kadi"].ToString();

                li.Value = dr["urun_kategoriID"].ToString();
                if (a != 1)
                {
                  
            ListBox1.Items.Add(li);
                }
                DataRow[] SubRows = DT.Select("ust_id = " + dr["urun_kategoriID"].ToString());

                DDLDoldur(SubRows, girinti + "-");
            }
        

        
    }
   
   
    protected void ImageButton1_Click2(object sender, ImageClickEventArgs e)
    {
        Session["dil"] = "en";
        Response.Redirect(HttpContext.Current.Request.RawUrl);
        
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Session["dil"] = "tr";
        Response.Redirect(HttpContext.Current.Request.RawUrl);
    }









    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32( ListBox1.SelectedValue)!=-100)
        Response.Redirect("arackategori.aspx?ID=" + ListBox1.SelectedValue);
    }
}
