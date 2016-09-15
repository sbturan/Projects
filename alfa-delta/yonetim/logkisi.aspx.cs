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
//.Web.ASPxGridView;
using AlfaDeltaLogin;
using System.Data.SqlClient;

public partial class yonetim_logkisi : System.Web.UI.Page
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        DateTime b = Convert.ToDateTime(Calendar1.SelectedDate);
        SqlParameter[] spParametre = new SqlParameter[]
        {
    
            new SqlParameter("@bas",b)

        };
        string spName = "tarihsil";
        try
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParametre);
            Label1.Visible = true;
        }
        catch {
            MessageBox.Show("Hata Oluştu");
        
        }


    }
}