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

public partial class bilgi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Visible = false;
        if (!IsPostBack)
        {
            Session["abcde"] = RastgeleKelime();
            panpi.Text = Session["abcde"].ToString();
        }
        int idd = Convert.ToInt32(Request.QueryString["ID"]);
        Urun1Info urun = new Urun1Info();
        UrunBLL getir = new UrunBLL();
        urun = getir.GetUrunByID(idd);
        TextBox1.Text = urun.ADI;
        if (Session["dil"] == "en")
        {
            lbl_Adi.Text = "Name";
            lbl_Soyadi.Text = "Surname";
            lbl_Telefon.Text = "Phone Number";
            lbl_Email.Text = "Email";
            lbl_Dosya.Text = "Upload File";
            lbl_Dosya0.Text = "Security Code";
            Label2.Text = "What is your quetions?";
            lbl_Dosya1.Text = "Verify Code";
            btn_Gonder.Text = "Send";
            btn_Vazgec.Text = "Cancel";
        }



        if (Session["KullaniciID"] != null)
        {
            int userid = Convert.ToInt32(Session["KullaniciID"].ToString());
            UsersInfo info = new UsersBLL().BulByID(userid);
            txt_Adi.Text = info.Adi;
            txt_Soyadi.Text = info.Soyadi;
            txt_Email.Text = info.Email;
            if (info.Telefon != null)
            {
                txt_Telefon.Text = info.Telefon;
            }

        }




      
        rqf_Adi.ErrorMessage = "Adı alanı zorunlu";

        rqf_Soyadi.ErrorMessage = "Soyadı alanı zorunlu";
        rqf_Telefon.ErrorMessage = "Telefon alanı zorunlu";
        rqf_Email.ErrorMessage = "Email alanı zorunlu";
        rge_Email.ErrorMessage = "Email formatı hatalı";
       
        lbl_Bilgi.Text = "Tüm alanlar zorunludur.";


        

        
    }
    
    protected void btn_Vazgec_Click(object sender, EventArgs e)
    {

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
    protected void btn_Gonder_Click(object sender, EventArgs e)
    {
        int aharar=3;
        if (Session["abcde"].ToString() != txtCaptcha.Text)
        {



            aharar = 1;
        }
        else {

            aharar = 0;
        }

        if (aharar == 0)
        {

            SendMail();
        }
        else
        {

            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "webformdesigner", "alert('Güvenlik Kodunu Kontrol Ediniz  ');", true);

        }   
    }
    public void SendMail()
    {
        MailBLL burak = new MailBLL();
        MailInfo info = burak.Getmail();

        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(info.EMAIL);
        mail.To.Add(info.EMAIL);
        mail.Subject = "Alfa-Delta";

        mail.Body = "Sayın " + txt_Adi.Text + " " + txt_Soyadi.Text + " \n(" + TextBox1.Text +") "+ " Ürünü hakkında bilgi almak istiyor" + "\n\n\n"+"\n\n"+ TextBox2.Text +"\n\n\n" + "İletişim Bilgileri aşağıdadır\n" + "Telefon: "+txt_Telefon.Text+"\n"+"Email: "+txt_Email.Text ;
        SmtpClient sc = new SmtpClient();
        sc.Port = info.PORTNUMBER;

        sc.Host = info.SMTP;
        sc.EnableSsl = false;
        sc.Credentials = new NetworkCredential(info.EMAIL, info.SIFRE);
        try
        {
            sc.Send(mail);
            Label1.Visible = true;
            Label1.Text = "İsteğiniz Bize Ulaşmıştır. En kısa sürede size döneceğiz";
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "webformdesigner", "alert(' İsteğiniz Bize Ulaşmıştır. En kısa sürede size döneceğiz  ');", true);
            Response.Write("<script>window.close();</script>");
        }
        catch
        {
            Label1.Text = "Bir Hata Oluştu Tekrar Deneyiniz";

        }

    }

}