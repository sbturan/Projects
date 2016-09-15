using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using AlfaDeltaLogin;
using System.Configuration;
public partial class yonetim_logbilgi : System.Web.UI.Page
{
    int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        string securitytype = ConfigurationManager.AppSettings.Get("securitytype");
        GridView1.AllowPaging = true;
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
    
     protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedIndex >=0)
        {
            string x = DropDownList1.SelectedItem.Value;
            int y = Convert.ToInt32(x.ToString());


            Session["dsadasssss"] = y;

            
       
        }
    }



     protected void Button2_Click(object sender, EventArgs e)
     {
         bindGridView();
      
     }

     private void bindGridView()
     {
         int id;
         DateTime b = Convert.ToDateTime(Calendar1.SelectedDate);
         DateTime bas = Convert.ToDateTime(Calendar2.SelectedDate);
         // create a SqlCommand object for this connection
         if (Session["dsadasssss"] == null)
         {

             id = 1;
         }
         else
         {
             id = Convert.ToInt32(Session["dsadasssss"].ToString());
         }

         SqlConnection conn = new SqlConnection("Data Source=mssql195.win-servers.com;Initial Catalog=alfadelta;Integrated Security=False;User ID=alfadelta;Password=adx9080");


         conn.Open();
         SqlCommand cmd = new SqlCommand();
         SqlDataAdapter da = new SqlDataAdapter();
         DataTable dt = new DataTable();

         cmd = new SqlCommand("tarih", conn);
         cmd.Parameters.Add(new SqlParameter("@id", id));
         cmd.Parameters.Add(new SqlParameter("@b", b));
         cmd.Parameters.Add(new SqlParameter("@bas", bas));
         cmd.CommandType = CommandType.StoredProcedure;
         da.SelectCommand = cmd;
         da.Fill(dt);
         GridView1.Visible = true;
         GridView1.DataSource = dt;

       

         GridView1.DataBind();
         ExceleAktarLinkButton.Visible = true;
     }

     protected void ExceleAktarLinkButton_Click(object sender, EventArgs e)
     {
         Response.Clear();

         Response.AddHeader("content-disposition", "attachment;filename=FileName.xls");

         Response.Charset = "";

         Response.Cache.SetCacheability(HttpCacheability.NoCache);

         Response.ContentType = "application/vnd.xls";

         System.IO.StringWriter stringWrite = new System.IO.StringWriter();

         System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);



         Controls.Clear();

         Controls.Add(GridView1);

         RenderControl(htmlWrite);

         Response.Write(stringWrite.ToString());

         Response.End();
         //GridViewExportUtil.Export("Maillist.xls", gvMail);
     }
     public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
     {
         /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
            server control at run time. */
     }




     protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
     {

     }
     protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
     {
         GridView1.PageIndex = e.NewPageIndex;
         bindGridView();
     }
}