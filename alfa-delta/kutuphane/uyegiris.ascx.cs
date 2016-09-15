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


public partial class kutuphane_uyegiris : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string securitytype = ConfigurationManager.AppSettings.Get("securitytype");
        if (securitytype == "cookie")
        {
            if ((HttpContext.Current.User.Identity.IsAuthenticated) && (HttpContext.Current.User.IsInRole("Administrator") || HttpContext.Current.User.IsInRole("Uye")))
            {
                MusteriGorunum.ActiveViewIndex = 1;
                Kullanici kull = new Kullanici(Convert.ToInt32(HttpContext.Current.User.Identity.Name));
                
                lbl_Karsilama.Text = "Hoþ Geldiniz " + kull.Adi + " " + kull.Soyadi;
            }
            else

                MusteriGorunum.ActiveViewIndex = 0;
        }

        else
        {
            if ((HttpContext.Current.Session["kullanici"] != null)
                && (Kullanici.UserInRole(((Kullanici)HttpContext.Current.Session["kullanici"]).Id, "Administrator") == true || Kullanici.UserInRole(((Kullanici)HttpContext.Current.Session["kullanici"]).Id, "Uye") == true))
            {
                MusteriGorunum.ActiveViewIndex = 1;
                Kullanici kull=new Kullanici( ((Kullanici)HttpContext.Current.Session["kullanici"]).Id);

                lbl_Karsilama.Text = "Hoþ Geldiniz " + kull.Adi + " " + kull.Soyadi;
            }
            else

                MusteriGorunum.ActiveViewIndex = 0;
       
        }

    }
    protected void btn_Giris_Command(object sender, CommandEventArgs e)
    {
        string securitytype = ConfigurationManager.AppSettings.Get("securitytype");

        SitePrincipal newUser = SitePrincipal.ValidateLoginByKullaniciAdi(txt_KullaniciAdi.Text, txt_Sifre.Text);
        string rollerim = "";
        if (newUser == null)
        {
            lbl_Error.Text = "Kullanýcý Bulunamadý";
        }
        else
        {
            Context.User = newUser;
            Kullanici usr = new Kullanici(txt_KullaniciAdi.Text, "USERNAME");
            if (usr.Durum == true)
            {
                if (securitytype == "cookie")
                {
                    lbl_Error.Text = "Hesabýnýz aktif";
                    FormsAuthentication.SetAuthCookie(txt_KullaniciAdi.Text, true);

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
                    lbl_Karsilama.Visible = true;
                  
                    MusteriGorunum.ActiveViewIndex = 1;
                }
                else
                {
                    HttpContext.Current.Session.Add("kullanici", usr);
                    lbl_Karsilama.Visible = true;
                    lbl_Karsilama.Text = "Hoþ Geldiniz";
                    MusteriGorunum.ActiveViewIndex = 1;
                }

                //Response.Redirect(FormsAuthentication.GetRedirectUrl(usr.Id.ToString(), false));

                Response.Redirect("Default.aspx");


            }

            else
            {
                lbl_Error.Visible = true;
                lbl_Error.Text = "Hesabýnýz aktif deðil";
            }

        }
    }
    protected void lnk_Cikis_Command(object sender, CommandEventArgs e)
    {
        string securitytype = ConfigurationManager.AppSettings.Get("securitytype");

        if (securitytype == "cookie")
        {
            FormsAuthentication.SignOut();
            Response.Redirect("Default.aspx");
        }

        else
        {
            FormsAuthentication.SignOut();

            HttpContext.Current.Session["kullanici"] = null;
            Response.Redirect("Default.aspx");
        }
        
    }
    
}
