using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Data.OleDb;
/// <summary>
/// Summary description for Class1
/// </summary>
public class connection
{

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void SendMailMessage(string to, string subject, string body, string dil)
    {
        MailMessage mMailMessage = new MailMessage();
       

        MailBLL burak = new MailBLL();
        MailInfo info = burak.Getmail();


        string mail_host = info.SMTP;
        string mail_usermail = info.EMAIL;
        string mail_password = info.SIFRE;

        mMailMessage.From = new MailAddress(mail_usermail);
        mMailMessage.To.Add(new MailAddress(to));

        mMailMessage.Subject = subject;
        mMailMessage.Body = body;
        mMailMessage.IsBodyHtml = true;
        mMailMessage.Priority = MailPriority.Normal;

        if (dil == "tr")
        {
            mMailMessage.SubjectEncoding = System.Text.Encoding.GetEncoding(1254);
            mMailMessage.BodyEncoding = System.Text.Encoding.GetEncoding(1254);
        }

        else
        {
            mMailMessage.SubjectEncoding = System.Text.Encoding.Unicode;
            mMailMessage.BodyEncoding = System.Text.Encoding.Unicode;
        }

        SmtpClient mSmtpClient = new SmtpClient();
        mSmtpClient.Credentials = new System.Net.NetworkCredential(mail_usermail, mail_password);

        mSmtpClient.Host = mail_host;
        mSmtpClient.Port = info.PORTNUMBER;
        mSmtpClient.Send(mMailMessage);


    }

    

   

 }
