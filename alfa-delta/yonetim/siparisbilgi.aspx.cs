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

public partial class yonetim_siparisbilgi : System.Web.UI.Page
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

    }
    
     protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedIndex >=0)
        {
            string x = DropDownList1.SelectedItem.Value;
            int y = Convert.ToInt32(x.ToString());
           

            
        Response.Redirect("siparislerdurum.aspx?ID="+y);
        }
    }



}