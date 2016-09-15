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

public partial class kutuphane_yonetimmenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string yonetimmenu = ConfigurationManager.AppSettings.Get("iceriktipi");
        if (Session["KullaniciID"] != null)
        {
            if (Session["KullaniciID"].ToString() == "1")
                mvw_Yonetim.ActiveViewIndex = 0;
        }
      


    }
}
