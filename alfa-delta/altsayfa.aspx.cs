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

public partial class altsayfa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MenuInfo info = new MenuBLL().MenuByLink(this.Page.Request.Url.PathAndQuery.Split('/')[1]);
        if (info != null)
        {
            Sabit.Navigasyon(info.ID.ToString());
        }
        else
        {
            Sabit.Navigasyon("boþ Navigasyon");
        }
        if(Request.QueryString["id"]!=null)
            if(Request.QueryString["id"]=="2"||Request.QueryString["id"]=="3")
            {
            ClientScript.RegisterStartupScript(this.GetType(), "Set Active", @"<Script type=""text/javascript"">document.getElementById(""divMenu4"").className = ""active""</Script>");
            }
            else if(Request.QueryString["id"]=="170")
                ClientScript.RegisterStartupScript(this.GetType(), "Set Active", @"<Script type=""text/javascript"">document.getElementById(""divMenu6"").className = ""active""</Script>");
            
    }
}
