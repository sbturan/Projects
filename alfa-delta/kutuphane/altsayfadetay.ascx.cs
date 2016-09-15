using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class kutuphane_altsayfadetay : System.Web.UI.UserControl
{
    
    
    public HiddenField _ID
    {
        get { return hdn_ID; }
        set { hdn_ID = value; }
    }
    public string baslik = "";

    public int id=0;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Request.QueryString["ID"] != null)
        {
            if (SqlInject.InjectionManager.HasInjection(Request.QueryString["ID"].ToString()) == false)
            {
                string dil;
                id = Convert.ToInt32(Request.QueryString["ID"]);
                if (Session["dil"] == null)
                {
                    dil = "tr";
                }
                else
                {
                    dil = Session["dil"].ToString();
                }
                IcerikInfo icinfo = new IcerikInfo();
                IcerikBLL icBLL = new IcerikBLL();
                icinfo = icBLL.GetBilgiByID(id,dil);





                try
                {
                    baslik = icinfo.KONU.ToUpper();

                    _ID.Value = icinfo.ID.ToString();
                    ltrl_Aciklama.Text = icinfo.ACIKLAMA;
                    this.Page.Title = ConfigurationManager.AppSettings.Get("title").ToString() + "  " + baslik;
                }
                catch { 
                Response.Redirect("default.aspx");
                
                }
            }
        }
    }


    private string _dil;

    public string dil
    {
        get { return _dil; }
        set { _dil = value; }
    }
}
