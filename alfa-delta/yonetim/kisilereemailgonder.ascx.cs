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
public partial class kutuphane_kisilereemailgonder : System.Web.UI.UserControl
{
    connection Conn = new connection();
    protected void Page_Load(object sender, EventArgs e)
    {
        lbl_Mesaj.Visible = false;
          lstsecilen.SelectionMode = ListSelectionMode.Multiple;
          lstsecimlik.SelectionMode = ListSelectionMode.Multiple;
        
                
    }

   

   
    protected void btn_Gonder_Click(object sender, EventArgs e)
    {
        
             List<string> mListInfo = new List<string>();
        for (int sayac = 0; sayac < lstsecilen.Items.Count; sayac++)
                {   
                mListInfo.Add(lstsecilen.Items[sayac].Text);

            }
           
            
                for (int sayac = 0; sayac < lstsecilen.Items.Count; sayac++)
                {
                    SendMail1(mListInfo[sayac].ToString(), txt_Konu.Text, FCKeditor1.Value);

                }

               
            

            

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ///lstsecilen.Items.Add(lstsecimlik.SelectedItem);
     //   lstsecimlik.Items.Remove(lstsecimlik.SelectedItem);
        int b = lstsecimlik.Items.Count;
        for (int i = 0; i < b; i++)
        {
            if (lstsecimlik.Items[i].Selected == true)
            {
                lstsecilen.Items.Add(lstsecimlik.Items[i].Value);
                // lstsecimlik.Items.Remove(lstsecimlik.Items[i].Value);
            }
        }
        int j=0;
        while(j<lstsecimlik.Items.Count){
            if (lstsecimlik.Items[j].Selected == true)
            {
                //  lstsecilen.Items.Add(lstsecimlik.Items[i].Value);
                lstsecimlik.Items.Remove(lstsecimlik.Items[j].Value);
                j = 0;
            }
            else {

                j++;
            }
            
        }
     

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        int b = lstsecilen.Items.Count;
        for (int i = 0; i < b; i++)
        {
            if (lstsecilen.Items[i].Selected == true)
            {
                lstsecimlik.Items.Add(lstsecilen.Items[i].Value);
                // lstsecimlik.Items.Remove(lstsecimlik.Items[i].Value);
            }
        }
        int j = 0;
        while (j < lstsecilen.Items.Count)
        {
            if (lstsecilen.Items[j].Selected == true)
            {
                //  lstsecilen.Items.Add(lstsecimlik.Items[i].Value);
                lstsecilen.Items.Remove(lstsecilen.Items[j].Value);
                j = 0;
            }
            else
            {

                j++;
            }
        }
     

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        lstsecilen.Items.Clear();
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
        sc.EnableSsl = false;
        sc.Credentials = new NetworkCredential(info.EMAIL, info.SIFRE);
        try
        {
            sc.Send(mail);
            lbl_Mesaj.Visible = true;
            lbl_Mesaj.Text = "Mesaj Gönderilmiştir";
            
        }
        catch(Exception e)
        {
            string a = e.ToString();
            lbl_Mesaj.Visible = true;
            lbl_Mesaj.Text = a.ToString();

        }

    }
   
  
}
