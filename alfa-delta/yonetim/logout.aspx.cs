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

public partial class yonetim_logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string securitytype = ConfigurationManager.AppSettings.Get("securitytype");

        if (securitytype == "cookie")
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/yonetim/giris.aspx");
        }

        else
        {
            FormsAuthentication.SignOut();
           
            HttpContext.Current.Session["kullanici"] = null;
            Response.Redirect("~/yonetim/giris.aspx");
        }
        
       

    }
}
