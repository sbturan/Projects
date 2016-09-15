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
//using DevExpress.Web.ASPxGridView;
using AlfaDeltaLogin;

public partial class yonetim_altsayfalar : System.Web.UI.Page
{

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

        // Çoklu dile göre grid gösterimi 
        string cokludil = ConfigurationManager.AppSettings.Get("cokludil");
        if (cokludil == "1")
        {
            // mltv_AltSayfalar.ActiveViewIndex = 0;
        }

        else
        {
            // mltv_AltSayfalar.ActiveViewIndex = 1;
        }


    }
    protected void grd_Diller_BeforePerformDataSelect(object sender, EventArgs e)
    {
        // Session["MASTER"] = (sender as ASPxGridView).GetMasterRowKeyValue();

    }
    protected void grd_Icerik_SelectionChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridView1.SelectedRow;
        int id = Convert.ToInt32(row.Cells[1].Text);
        Response.Redirect("altsayfaduzenle.aspx?ID=" + id);
    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[3].Visible = false;

            //  e.Row.Cells[4].Visible = false;
            // e.Row.Cells[5].Visible = false;
        }
    }

}