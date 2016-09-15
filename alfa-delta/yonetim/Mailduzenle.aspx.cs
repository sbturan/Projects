using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class yonetim_Mailduzenle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {if (!IsPostBack)
        {
        getir();}
        Label5.Visible = false;
    }

    public void getir(){
        
            MailBLL burak = new MailBLL();
            MailInfo info = burak.Getmail();
            txt_mail.Text = info.EMAIL;
            txt_port.Text = info.PORTNUMBER.ToString();
            txt_sifre.Text = info.SIFRE;
            txt_smtf.Text = info.SMTP;
      
    
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        MailInfo info = new MailInfo();
        info.EMAIL = txt_mail.Text;
        info.PORTNUMBER = Convert.ToInt32(txt_port.Text);
        info.SIFRE = txt_sifre.Text;
        info.SMTP = txt_smtf.Text;
        info.ID = 1;
        new MailBLL().Update(info);
        Label5.Visible = true;
    }
}