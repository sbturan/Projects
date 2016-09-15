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

public partial class tr_ikbasvuru : System.Web.UI.Page
{
    public IkInfo ikINFO = new IkInfo();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["dil"] == "en")
        {
            Label1.Text = "Drawing particular product form";
            Sabit.portal("Drawing particular product form");
        }
        else { 
        Sabit.portal("Özel ürün çizim formu");
        }
        string[] bolunmusadres = this.Page.Request.Url.PathAndQuery.Split('/');

        MenuInfo info = new MenuBLL().MenuByLink(bolunmusadres[bolunmusadres.Length - 1]);
        if (info != null)
        {
            Sabit.Navigasyon(info.SIRA.ToString());
        }
        else
        {
            Sabit.Navigasyon("boþ Navigasyon");
        }

        int id = 0;
        if (Request.QueryString["ID"] != null)
        {
            id = Convert.ToInt32(Request.QueryString["ID"]);
            IkBLL ikBLL = new IkBLL();
            ikINFO = ikBLL.GetBilgiByID(id, 1);
            lbl_IkBilgi.Visible = true;
            lbl_IkBilgi.Text = ikINFO.KONU;
            lblAciklama.Visible = true;
            lblAciklama.Text = ikINFO.ACIKLAMA;

        }

        ClientScript.RegisterStartupScript(this.GetType(), "Set Active", @"<Script type=""text/javascript"">document.getElementById(""divMenu1"").className = ""active""</Script>");
        
    }
}
