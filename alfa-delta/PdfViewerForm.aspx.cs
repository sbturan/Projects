using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PdfViewerForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {



        int x = Convert.ToInt16(Request.QueryString["ID"]);

        UrunBLL dener = new UrunBLL();
        Urun1Info denere = new Urun1Info();
        denere = dener.GetUrunByID(x);

        string a = Server.MapPath(denere.PDF);
       
        FileInfo file = new FileInfo(a);

        if (file.Exists)
        {

            Response.ContentType = "application/pdf";



            Response.Clear();


            Response.TransmitFile(file.FullName);

            Response.End();

        } 
    }
}