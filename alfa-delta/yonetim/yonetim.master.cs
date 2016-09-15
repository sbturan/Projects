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

public partial class yonetim_yonetim : System.Web.UI.MasterPage
{
    //public TreeView TvNavigation
    //{
    //    get { return  tvNavigation; }
    //    set { tvNavigation = value; }
    //}

    #region Global Variable Declarations
    public string page = string.Empty;
    public string project = string.Empty;
    public string company = string.Empty;
    public string copyright = string.Empty;
    public string username = string.Empty;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = ConfigurationManager.AppSettings.Get("title") + " Yönetim Konsolü";


        if (GetCurrentPageName() == "giris.aspx") Yonetimmenu1.Visible = false;



    }

    public string GetCurrentPageName()
    {
        string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
        string sRet = oInfo.Name;
        return sRet;
    }

}
