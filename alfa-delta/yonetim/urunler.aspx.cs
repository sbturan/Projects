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
public partial class yonetim_urunler : System.Web.UI.Page
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

       
       
      
    }
    protected void grd_Diller_BeforePerformDataSelect(object sender, EventArgs e)
    {
        //Session["MASTER"] = (sender as ASPxGridView).GetMasterRowKeyValue();
       
    }
    protected void grd_Icerik_SelectionChanged(object sender, EventArgs e)
    {
      
    }

    protected void ObjectIcerikler_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridView1.SelectedRow;
        int id = Convert.ToInt32(row.Cells[2].Text);
        Response.Redirect("Urunduzenle.aspx?ID=" + id);
    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
           e.Row.Cells[2].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[14].Visible = false;
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[12].Visible = false;
            e.Row.Cells[13].Visible = false;
            e.Row.Cells[15].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[7].Visible = false;
          //  e.Row.Cells[3].Visible = false;
            // e.Row.Cells[3].Visible = false;

            //  e.Row.Cells[4].Visible = false;
            // e.Row.Cells[5].Visible = false;
        }

    }
    protected void grdProducts_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Delete":
                int index = Convert.ToInt32(e.CommandArgument);
                UrunBLL a = new UrunBLL();


                try
                {
                    a.Delete(index);
                }
                catch (Exception ex)
                {


                    MessageBox.Show("Bir hata Oluþtu\n\nAYRINTILAR\n\n" + ex.Message);
                }


              MessageBox.Show("Ýslem Basarili");
              Server.Transfer("urunler.aspx");

                break;
            default:
                break;
        }
    }
}
