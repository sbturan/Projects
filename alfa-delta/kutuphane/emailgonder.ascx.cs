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
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using AlfaDeltaLogin;
public partial class kutuphane_emailgonder : System.Web.UI.UserControl
{
    connection Conn = new connection();
    protected void Page_Load(object sender, EventArgs e)
    {
        //string master_durum = ConfigurationManager.AppSettings.Get("cokludil");

        //if (master_durum == "0")
        //{
        //    chklist_dil.Visible = false;

        //}

        //else
        //{
        //    chklist_dil.Visible = true;
        //}

    }

   
   
    protected void btn_Gonder_Click(object sender, EventArgs e)
    {
        MailListeBLL mList = new MailListeBLL();
        List<MailListeInfo> mListInfo = new List<MailListeInfo>();

        //string master_durum = ConfigurationManager.AppSettings.Get("cokludil");

        //int  chksayi = 0;
        int hata = 0;
        
           
                mListInfo = mList.GetList();

               


                if (mListInfo.Count > 0)
                {
                    for (int i = 0; i < mListInfo.Count; i++)
                    {
                        SendMail1(mListInfo[i].EMAIL, txt_Konu.Text, FCKeditor1.Value);

                    }
                }

      }

    public void SendMail1(string to, string subject, string body)
    {
        MailBLL burak = new MailBLL();
        MailInfo info = burak.Getmail();

        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(info.EMAIL);
        mail.To.Add(to);

        mail.Subject = subject;

        mail.Body = body;
        SmtpClient sc = new SmtpClient();
        sc.Port = info.PORTNUMBER;
        sc.Host = info.SMTP;
        sc.EnableSsl = true;
        sc.Credentials = new NetworkCredential(info.EMAIL, info.SIFRE);
        try
        {
            sc.Send(mail);
            lbl_Mesaj.Visible = true;
            lbl_Mesaj.Text = "Mesaj Gönderilmiştir";

        }
        catch(Exception e )
        {
            lbl_Mesaj.Visible = true;
            lbl_Mesaj.Text = "Mesajda hata olustu"+e.ToString();

        }

    }

}
