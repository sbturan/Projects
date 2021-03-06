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

public partial class yonetim_giris : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string securitytype = ConfigurationManager.AppSettings.Get("securitytype");

        SitePrincipal newUser = SitePrincipal.ValidateLoginByEmail(SqlInject.InjectionManager.RejectInjection(txtUsername.Text),
            SqlInject.InjectionManager.RejectInjection(txtPassword.Text));
        string rollerim = "";
        if (newUser == null)
        {
            lblError.Text = "Kullanıcı Bulunamadı";
        }
        else
        {
            Context.User = newUser;
            Kullanici usr = new Kullanici(txtUsername.Text, "EMAIL");
            if (usr.Durum == true)
            {
                Session["KullaniciEmail"] = txtUsername.Text;
                Session["KullaniciID"] = usr.Id.ToString();
                Session["RoleID"] = usr.RoleId.ToString();
                if (securitytype == "cookie")
                {
                    lblError.Text = "Hesabınız aktif";
                    FormsAuthentication.SetAuthCookie(txtUsername.Text, true);

                    ArrayList roles = ((SitePrincipal)newUser).Roles;

                    //roles = usr.GetUserRoles(usr.UserID);

                    String[] myRoles = new String[roles.Count];

                    for (int i = 0; i < roles.Count; i++)
                    {

                        myRoles[i] = roles[i].ToString();
                        rollerim += myRoles[i] + ",";
                    }

                    rollerim = rollerim.Substring(0, rollerim.LastIndexOf(','));
                    FormsAuthenticationTicket MyTicket = new FormsAuthenticationTicket
                        (1,
                         usr.Id.ToString(),
                         DateTime.Now,
                         DateTime.Now.AddMinutes(30),
                         false,
                         rollerim);

                    String MyEncryptedTicket = FormsAuthentication.Encrypt(MyTicket);
                    HttpCookie MyCookie = new HttpCookie(FormsAuthentication.FormsCookieName, MyEncryptedTicket);

                    MyCookie.Path = FormsAuthentication.FormsCookiePath;
                    MyCookie.Expires = DateTime.Now.AddMinutes(30);
                    Response.Cookies.Add(MyCookie);
                }
                else
                {
                    HttpContext.Current.Session.Add("kullanici", usr);
                    Session["KullaniciID"] = usr.Id.ToString();
                }

                //Response.Redirect(FormsAuthentication.GetRedirectUrl(usr.Id.ToString(), false));

                Response.Redirect("Default.aspx");


            }

            else
            {
                lblError.Visible = true;
                lblError.Text = "Hesabınız aktif değil";
            }

        }

    }
}
