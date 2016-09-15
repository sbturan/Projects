using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using AlfaDeltaLogin;
using System.Net.Mail;
using System.Net;
using System.Collections.Generic;

public partial class urundetay1 : System.Web.UI.Page
{
    string isim;
    int stok;
    float dol;
    int indirim;
    float kdv;
    float euo;
    int birim;
    ArrayList alMenu = new ArrayList();
    ArrayList blMenu = new ArrayList();

    protected void Page_Load(object sender, EventArgs e)
    {

      
       
        int x = Convert.ToInt16(Request.QueryString["ID"]);
     
        
        UrunBLL dener = new UrunBLL();
        Urun1Info denere = new Urun1Info();
        denere = dener.GetUrunByID(x);
        int t = denere.KTG_ID;

        string a = Server.MapPath(denere.PDF);
        FileInfo file = new FileInfo(a);
        if (file.Exists)
        {


            Response.ContentType = "application/pdf";



            Response.Clear();


            Response.TransmitFile(a);

            Response.End();


        }
       
        

    }


   
   



    protected void Button1_Click(object sender, EventArgs e)
    {

        Response.Redirect("bilgial.aspx?ID=" + Convert.ToInt32(Request.QueryString["ID"]));
    }
}