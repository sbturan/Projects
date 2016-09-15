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

public partial class uyeol1 : System.Web.UI.Page
{
    string yazdır;
    int y = 0;
    int don;
    protected void Page_Load(object sender, EventArgs e)
    {
        Label3.Visible = false;
        if (!IsPostBack)
        {
            Session["abcd"] = RastgeleKelime();
            panpi.Text = Session["abcd"].ToString();
        }
        if (Session["dil"] == "en")
        {
            lbl_Adi.Text = "Name";
            lblEmail.Text = "Email";

            
            lblSoyad.Text = "Surname";
         
            lblTelNo0.Text = "Verify Code";
            lblTelNo1.Text = "Security Code";
            lblHeader.Text = "Membership Form";


        }
        
        
        if (Request.QueryString["ID"] != null)
        {
            if (Request.QueryString["ID"].Equals("1"))
            {
                OnlineUye.Visible = true; lblHeader.Text = "Üyelik Formu";
            }

        }
    }
    
   
    protected void Gonder_Click(object sender, ImageClickEventArgs e)
    {
        //if (Request.QueryString["ID"] == null)
        //{
        if (Session["abcd"].ToString() != txtCaptcha.Text)
        {

            
           
             y = 1;
        }

        if (y == 0)
        {

            SendMail1(Session["abcd"].ToString());
        }
        else {

            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "webformdesigner", "alert('Güvenlik Kodunu Kontrol Ediniz  ');", true);
        
        }
           


      
    }
    public string RastgeleKelime()
    {


        string kelime = "";
        Random rnd = new Random();
        for (int i = 0; i <= 6; i++)
        {

            kelime += ((char)rnd.Next('A', 'Z')).ToString();

        }
        return kelime;
    }

    public void SendMail1(string aktivasyon)
    {
        MailBLL burak = new MailBLL();
        MailInfo info = burak.Getmail();
        
        string mail1 = txt_Email.Text;
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(info.EMAIL);
        mail.To.Add(mail1);
        string ad = txt_Adi.Text;
        string soyad = txt_Soyadi.Text;
        mail.Subject = "Aktivasyon Onayınız";

        mail.Body = "Sayin " + ad +" " + soyad + "\nÜyeliğinizin tamamlanması icin" + " aşağıda belirtilen aktivasyon kodunu aktivasyon alanına giriniz\n" + aktivasyon  + "";
        SmtpClient sc = new SmtpClient();
        sc.Port = info.PORTNUMBER;
        sc.Host = info.SMTP;
        sc.EnableSsl = false;
        sc.Credentials = new NetworkCredential(info.EMAIL, info.SIFRE);
        try
        {
           int donen= SaveData();
           if (donen != 2)
           {
               sc.Send(mail);

               Label3.Visible = true;
               Label3.Text = "Aktivasyon Bilgileri Mailinize Yollanmıştır.Lütfen Kısa Sürede Aktif Ediniz";
               OnlineUye.Visible = false;
               lblHeader.Visible = false;
           }
           else {

               ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "webformdesigner", "alert('Email Bilginizi Kontrol Ediniz  ');", true);
           
           }
        }
        catch
        {
            Label3.Visible = true;
            OnlineUye.Visible = false;
            Label3.Text = "Aktivasyon Bilgileri Yollanamamıştır";

        }

    }


    private int  SaveData()
    {
        UsersInfo info = new UsersInfo();
       
            info.Adi = txt_Adi.Text;
            info.Soyadi = txt_Soyadi.Text;
            info.Email = txt_Email.Text;
            info.AKTIVASYON = Session["abcd"].ToString();
            info.TARIH = DateTime.Now;  
            info.Durum = false;
            info.RoleId = 4;
            

            
                int id = new UsersBLL().Insert(info);


                if (id > 0)
                {
                   
                   txt_Adi.Text = string.Empty;
                    txt_Soyadi.Text = string.Empty;
                    txt_Email.Text = string.Empty;
                  


                }
                else {
                  don=2;  
                }
   
    return don;}
  
}

