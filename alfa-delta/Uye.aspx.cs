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

public partial class Uye : System.Web.UI.Page
{
    public string ad;
    public string sad;


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string securitytype = ConfigurationManager.AppSettings.Get("securitytype");

        SitePrincipal newUser = SitePrincipal.ValidateLoginByEmail(SqlInject.InjectionManager.RejectInjection(txtUsername.Text),
            SqlInject.InjectionManager.RejectInjection(txtPassword.Text));
        string rollerim = "";
        if (newUser == null)
        {
            lblError.Text = "Hatalı giriş yapıldı";
        }
        else
        {
            Context.User = newUser;
            Kullanici usr = new Kullanici(txtUsername.Text, "EMAIL");
            if (usr.Durum == true)
            {

                Session["KullaniciEmail"] = txtUsername.Text;
                Session["KullaniciID"] = usr.Id.ToString();
                Session["Fiyat"] = usr.PARA_KONTROL.ToString();
                ad = usr.Adi;
                sad = usr.Soyadi;
                Panel2.Visible = false;
                lbl_hos.Visible = true;
                BtnSubmit2.Visible = true;
                string IpAdress = Request.ServerVariables["REMOTE_ADDR"];
                string browserName = Request.Browser.Browser.ToString();
                LogInfo log = new LogInfo();
                log.BROWSER = browserName;
                log.IP = IpAdress;
                log.KID = usr.Id;
                log.AKSIYON = 1;
                log.ISLEM_SAATI = DateTime.Now;
                int id = new LogBLL().Insert(log);

                lbl_hi.Text = ad + " " + sad;
                if (usr.RoleId == 1)
                {
                    admin.Visible = true;
                    HyperLink2.Visible = false;
                   
                }
                else if (usr.RoleId == 2 || usr.RoleId == 3)
                {
                    updateusr.Visible = true;
                    adres.Visible = true;
                }
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
                    KontrolInfo infor = new KontrolInfo();
                   
                    infor=new KontrolBLL().GetByID(usr.Id);
                    if (infor.KONTROL == 0)
                    {

                        HttpContext.Current.Session.Add("kullanici", usr);
                        Session["KullaniciID"] = usr.Id.ToString();
                        
                        
                    }
                    else
                    {
                        HttpContext.Current.Session.Add("kullanici", usr);
                        Session["KullaniciID"] = usr.Id.ToString();
                        Response.Write("<script type=\"text/javascript\">top.location=\"sifredegistir.aspx\"; </script>");

                    }

                }

             


            }

            else
            {
                lblError.Visible = true;
                lblError.Text = "Hesabınız aktif değil";
            }

        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["dil"] == "en")
        {
            lbl_Sifre.Text = "Password";
            adres.Text = "Add Address";
            lbl_UyeAdi.Text = "Name";
            lbl_hos.Text = "Welcome";
            hypSifremiUnuttum.Text = "Forgot your password?";
            hypuyeOl.Text = "Sign Up";
          
            HyperLink2.Text = "Edit Password";
            btnSubmit.Text = "Log İn";
            BtnSubmit2.Text = "Log Out";
            HyperLink3.Text = "Activation Code";
            updateusr.Text = "Edit Information";
        }
        
        if (Session["KullaniciEmail"] != null)
        {
            Kullanici usr = new Kullanici(Session["KullaniciEmail"].ToString(), "EMAIL");
           
            ad = usr.Adi;
            sad = usr.Soyadi;
            Panel2.Visible = false;

            lbl_hos.Visible = true;
            BtnSubmit2.Visible = true;

            lbl_hi.Text = ad + " " + sad;
            if (usr.RoleId == 1)
            {
                admin.Visible = true;
                
                HyperLink2.Visible = false;
                HyperLink3.Visible = false;
                updateusr.Visible = false;
                adres.Visible = false;

            }
            else if (usr.RoleId == 2 || usr.RoleId == 3)
            {
                updateusr.Visible = true;
                adres.Visible = true;
             
                HyperLink2.Visible = true;
                HyperLink3.Visible = false;
                admin.Visible = false;
            }

        }

    }

    protected void BtnSubmit2_Click(object sender, EventArgs e)
    {
        Kullanici usr = new Kullanici(txtUsername.Text, "EMAIL");
        string IpAdress = Request.ServerVariables["REMOTE_ADDR"];
        string browserName = Request.Browser.Browser.ToString();
        LogInfo log = new LogInfo();
        log.BROWSER = browserName;
        log.IP = IpAdress;
        log.KID =  Convert.ToInt16( Session["KullaniciID"].ToString());
        log.AKSIYON = 0;
        log.ISLEM_SAATI = DateTime.Now;
        int id = new LogBLL().Insert(log);
        Session["KullaniciEmail"] = null;
        Session["dil"] = null;
        Session["KullaniciID"] = null;
        
        Session["sepet"] = null;
        Response.Write("<script type=\"text/javascript\">top.location=\"Default.aspx\"; </script>");


    }
}
