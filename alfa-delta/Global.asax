<%@ Application Language="C#" %>

<script runat="server">

    string securitytype = ConfigurationManager.AppSettings.Get("securitytype");
    void Application_Start(object sender, EventArgs e) 
    {
        
        int say = 0;
        Application["Aktif"]=say;
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        if (securitytype == "cookie")
        {
            FormsAuthentication.SignOut();
        }

        else
        {
            FormsAuthentication.SignOut();

            HttpContext.Current.Session["kullanici"] = null;
        }
    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started
        Application["Aktif"] = Convert.ToInt32(Application["Aktif"]) + 1;
        Session["MailListesinde"] = false;
        Session["GelenSayfa"] = string.Empty;

    }

    void Session_End(object sender, EventArgs e) 
    {
        if (securitytype == "cookie")
        {
            FormsAuthentication.SignOut();
        }

        else
        {
            FormsAuthentication.SignOut();

            HttpContext.Current.Session["kullanici"] = null;
            Session["GelenSayfa"] = string.Empty;
        }
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

        Application.Lock();
        Application["Aktif"] = Convert.ToInt32(Application["Aktif"]) - 1;

    }

    protected void Application_AuthenticateRequest(Object sender, EventArgs e)
    {
        if (Request.IsAuthenticated)
        {
            FormsAuthenticationTicket MyTicket;
            HttpCookie AuthCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            MyTicket = FormsAuthentication.Decrypt(AuthCookie.Value);
            string[] roles = MyTicket.UserData.Split(',');

            Context.User = new System.Security.Principal.GenericPrincipal(User.Identity, roles);

        }
        
    }
       
</script>
