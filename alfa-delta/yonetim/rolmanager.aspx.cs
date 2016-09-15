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

public partial class yonetim_rolmanager : System.Web.UI.Page
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
        
        
        if (!Page.IsPostBack)
            BindGrid();
    }
    private void BindGrid()
    {
        RolesGrid.DataSource = Role.GetRoles();
        RolesGrid.DataBind();
    }

    private void RolesGrid_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
        RolesGrid.EditItemIndex = e.Item.ItemIndex;
        BindGrid();
    }

    private void RolesGrid_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
        RolesGrid.EditItemIndex = -1;
        BindGrid();
    }

    private void RolesGrid_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
        Role role = new Role(int.Parse(((Label)e.Item.Cells[3].FindControl("RoleID")).Text));
        role.RoleName = ((TextBox)e.Item.Cells[3].FindControl("RoleNameEdit")).Text;
        role.Update();

        RolesGrid.EditItemIndex = -1;
        BindGrid();
    }
  
    protected void Delete_Click(object sender, EventArgs e)
    {

    }
    protected void AddRole_Click(object sender, EventArgs e)
    {

    }
}
