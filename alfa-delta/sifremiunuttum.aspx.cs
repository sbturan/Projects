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
using System.Net.Mail;
using System.Net;
using System.Collections.Generic;

public partial class sifremiunuttum : System.Web.UI.Page
{
    public int id;
    public string ad;
    public string Sifre;
    public string email;
    protected void Page_Load(object sender, EventArgs e)
    {


    }

    public void SendMail()
    {
        MailBLL burak = new MailBLL();
        MailInfo info = burak.Getmail();

        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(info.EMAIL);
        mail.To.Add(email);
        mail.Subject = "Alfa-Delta";
      
        mail.Body = "Sifreniz:"+Sifre;
        SmtpClient sc = new SmtpClient();
        sc.Port = info.PORTNUMBER;
        
        sc.Host = info.SMTP;
        sc.EnableSsl = true;
        sc.Credentials = new NetworkCredential(info.EMAIL,info.SIFRE );
        try
        {
            sc.Send(mail);
            Label1.Text = "Sifreniz mailinize basariyla gonderilmistir.Gereksiz(Junk) kutusunu kontrol ediniz";

        }
        catch{
            Label1.Text = "Sifreniz gonderilemedi";
        
        }
    
    }





    protected void Button1_Click(object sender, EventArgs e)
    {
        email = YourEmail.Text;
        if (email != null || email != "")
        {


            UsersInfo usr = new UsersBLL().BulByEmailID(email);
            if (usr != null)
            {
                ad = usr.Adi;
                Sifre = usr.Sifre;
               
                SendMail();
                KontrolInfo infor = new KontrolInfo();
                infor.ID = usr.Id;
                infor.KONTROL = 1;
                new KontrolBLL().Update(infor);

            }else {

            Label1.Text = "Mailiniz hatali tekrar deneyiniz";
        
        
        }
        
        }
            
        
        
    }

    
}