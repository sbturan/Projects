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

public partial class kutuphane_search : System.Web.UI.UserControl
{

    public string girilenPage = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack)
            return;

        girilenPage = Request.ServerVariables["PATH_INFO"].ToString();
        

    }
    public string navigasyon = "";
    public string temiz = "";
    protected void btn_Ara_Click1(object sender, ImageClickEventArgs e)
    {
       temiz = SqlInject.InjectionManager.RejectInjection(txt_Ara.Text);
       if (temiz != "aranacak kelimeyi yazýn...")
        {
            Response.Redirect("Arama.aspx?Text=" + temiz, false);
        }
    }
}
