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
using System.Collections.Generic;
public partial class kutuphane_ziyaretciekle : System.Web.UI.UserControl
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
        int mevcutziyaret = 0;
        //Response.Redirect("~/tr/");
        UrlHitInfo urlhitINFO = new UrlHitInfo();
        urlhitINFO.DIL = DIL;
        urlhitINFO.OTURUM = HttpContext.Current.Session.SessionID;
        urlhitINFO.REMOTE_IP = Request.ServerVariables["REMOTE_ADDR"].ToString();
        urlhitINFO.SAYFA_ISMI = GetCurrentPageName();
        urlhitINFO.TARIH = DateTime.Now;
        urlhitINFO.URL = siteurl;

        UrlHitBLL urlhitBLL = new UrlHitBLL();

        mevcutziyaret = urlhitBLL.GetMevcutZiyaret(urlhitINFO.DIL, urlhitINFO.URL, urlhitINFO.REMOTE_IP, urlhitINFO.OTURUM, urlhitINFO.SAYFA_ISMI);

        if (mevcutziyaret == 0)
        {
            urlhitBLL.Insert(urlhitINFO);
        }
       
    }

    public string GetCurrentPageName()
    {
        string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
        string sRet = oInfo.Name;
        return sRet;
    } 
}
