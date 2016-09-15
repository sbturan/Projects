using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class yonetim_loglar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[1].Visible = false;
            //  e.Row.Cells[3].Visible = false;

            // e.Row.Cells[3].Visible = false;

            //  e.Row.Cells[4].Visible = false;
            // e.Row.Cells[5].Visible = false;
        }
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
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }
}