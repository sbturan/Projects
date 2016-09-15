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

public partial class kutuphane_urlistatistik : System.Web.UI.UserControl
{

    private string _dil;

    public string DIL
    {
        get { return _dil; }
        set { _dil = value; }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string siteurl = ConfigurationManager.AppSettings.Get("siteurl");
        ltZiyaret.Text = "Aktif ziyaretçi : " + Application["Aktif"].ToString();

        UrlHitBLL urlhitBLL = new UrlHitBLL();
        ltBugunGiris.Text ="Bugün Giriþ : " +  urlhitBLL.GetGunlukZiyaret(DIL, "Default.aspx", siteurl, DateTime.Now).ToString();
        ltToplamZiyaretci.Text = "Toplam Giriþ : " + urlhitBLL.GetToplamZiyaret(DIL, "Default.aspx", siteurl).ToString();
    }
}
