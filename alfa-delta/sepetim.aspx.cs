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
using OboutInc.Show;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using AlfaDeltaLogin;
using System.Net.Mail;
using System.Net;
public partial class sepetim : System.Web.UI.Page
{
    double indirimtoplam = 0;
    double toplam = 0;
    double aratoplam = 0;
    double geneltoplam = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        

        if (Session["KullaniciID"] != null)
        {
            string id = (string)Session["KullaniciID"];
            int tu = Convert.ToInt32(id);
            UsersBLL al = new UsersBLL();
            UsersInfo kinfo = new UsersInfo();
            kinfo = al.BulByID(tu);
            if (kinfo.PARA_KONTROL != 1) {
                lblfiyat.Visible = false;
                
                lbliskonto.Visible = false;
                lblkdv.Visible = false;
                lblodenecek.Visible = false;
                DataList1.Visible = false;
            
            }
            
            SepetGetir();
           
        }
        else
        {

            Response.Write("<script language='JavaScript'>alert(' Üye Girişi Yapın ');window.location = ' Default.aspx ';</script>");
        }
        
    }

    private void SepetGetir()
    {
        if (Session["sepet"] != null)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["sepet"];
            DataList1.DataSource = dt.DefaultView;
            DataList1.DataBind();
            SepetToplam();

            lblfiyat.Text = toplam.ToString("0.##") +" TL";
            lbliskonto.Text = indirimtoplam.ToString("0.##") +"TL";
            lblkdv.Text = aratoplam.ToString("0.##") +"TL";
            lblodenecek.Text = geneltoplam.ToString("0.##") +"TL";



        }
        else {
            Label2.Text = "Sepetinize Ürün Ekleyiniz";
            lblfiyat.Text = " 0 TL";
            lbliskonto.Text =   " 0 TL";
            lblkdv.Text =  " 0 TL";
            lblodenecek.Text =  " 0 TL";

            LinkButton5.Visible = false;
           
        }

    }
    private void SepettGetir()
    {
        if (Session["sepet"] != null)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["sepet"];
            DataList1.DataSource = dt.DefaultView;
            DataList1.DataBind();
            SepettToplam();

            lblfiyat.Text = toplam.ToString("0.##") + " TL";
            lbliskonto.Text = indirimtoplam.ToString("0.##") + "TL";
            lblkdv.Text = aratoplam.ToString("0.##") + "TL";
            lblodenecek.Text = geneltoplam.ToString("0.##") + "TL";



        }
        else
        {
            Label2.Text = "Sepetinize Ürün Ekleyiniz";
            lblfiyat.Text = " 0 TL";
            lbliskonto.Text = " 0 TL";
            lblkdv.Text = " 0 TL";
            lblodenecek.Text = " 0 TL";

            LinkButton5.Visible = false;

        }

    }

     
    
    
   



    
    public void Sil(string id)//silinecek olan ürünün id değeri alınıyor
    {
        DataTable dt = new DataTable();//tablo örneği oluşturuluyor
        if (HttpContext.Current.Session["sepet"] != null)//sessin  kontrolü yapılıyor
        {
            dt = (DataTable)HttpContext.Current.Session["sepet"];//sessiondaki tablo alınıyor
            for (int i = 0; i < dt.Rows.Count; i++)//tablonun satır sayısı kadar yine bir döngü oluşturuluyor
            {
                if (dt.Rows[i]["id"].ToString() == id)//o naki satırın id alanı ile gelen id alanı eşit ise
                {
                   
                    
                    dt.Rows[i].Delete();//tablonun o satırı siliniyor. 
                    HttpContext.Current.Session["sepet"] = dt;//tablonun son hali sessiona aktarılıyor
                    break;//dögüden çıkılıyor
                }
            }
        }
    }
    public double SepetToplam()
    {
        
        if (HttpContext.Current.Session["sepet"] != null)//sessiomn kontolü yapılıyor
        {
            DataTable dt = new DataTable();//tablo oluşturuluyor
            dt = (DataTable)HttpContext.Current.Session["sepet"];//sessiondaki sepet alınıyor tabloya aktarılıyor
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)//yine tablonun tüm alanlarında dönecek döngü başlatılıyor
                {
                    indirimtoplam += Convert.ToDouble(dt.Rows[i]["tutar"].ToString()) * Convert.ToDouble(dt.Rows[i]["indiri"].ToString()) / 100;
                    aratoplam += Convert.ToDouble(dt.Rows[i]["tutar"].ToString()) * Convert.ToDouble(dt.Rows[i]["kd"].ToString()) / 100;
                    toplam += Convert.ToDouble(dt.Rows[i]["tutar"].ToString());//her satırdaki tutar miktarı toplam değişkenine aktarılıyor
                    geneltoplam = toplam + aratoplam - indirimtoplam;
                }
            }
            else {
                indirimtoplam = 0;
                aratoplam = 0;
                toplam = 0;
                geneltoplam = 0;
            
            }

        }
        return geneltoplam; //toplam değeri döndürülüyor.

    }
    public void SendMail()
    {
        MailBLL burak = new MailBLL();
        MailInfo info = burak.Getmail();
        DataTable dt = new DataTable();
        dt = (DataTable)Session["sepet"];
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(info.EMAIL);
        mail.To.Add(info.EMAIL);
        mail.Subject = "Alfa-Delta";
        string id = (string)Session["KullaniciID"];
        int tu = Convert.ToInt32(id);
        UsersBLL al = new UsersBLL();
        UsersInfo kinfo = new UsersInfo();
        kinfo = al.BulByID(tu);
        mail.Body = "Sayın " + kinfo.Adi + " " + kinfo.Soyadi+" Bilgi Almak istiyor";
      mail.Body += "\nÜrün Bilgileri Aşağıdadır\n\n";
        for (int i = 0; i < dt.Rows.Count; i++)//yine tablonun tüm alanlarında dönecek döngü başlatılıyor
       {
            mail.Body += (i + 1) + ") Ürün: " + dt.Rows[i]["isim"]+"\n";
        }
       mail.Body += "\n\n\n" + "İletişim Bilgileri aşağıdadır\n" + "Telefon: " + kinfo.Telefon + "\n" + "Email: " + kinfo.Email;
        SmtpClient sc = new SmtpClient();
        sc.Port = info.PORTNUMBER;

        sc.Host = info.SMTP;
        sc.EnableSsl = true;
        sc.Credentials = new NetworkCredential(info.EMAIL, info.SIFRE);
        try
        {
            sc.Send(mail);
            Label2.Visible = true;
            Label2.Text = "İsteğiniz Bize Ulaşmıştır. En kısa sürede size döneceğiz";

        }
        catch
        {
            Label2.Visible = true;
            Label2.Text = "Bir Hata Oluştu Tekrar Deneyiniz";

        }

    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        SendMail();
        Response.Write("<script language='JavaScript'>alert(' İsteğiniz Bize Ulaşmıştır. En kısa sürede size döneceğiz ');window.location = ' Default.aspx ';</script>");
       // Response.Redirect("adresonayla.aspx");
    }
    public double SepettToplam()
    {

        if (HttpContext.Current.Session["sepet"] != null)//sessiomn kontolü yapılıyor
        {
            indirimtoplam = 0;
            aratoplam = 0;
            toplam = 0;
            geneltoplam = 0;
            DataTable dt = new DataTable();//tablo oluşturuluyor
            dt = (DataTable)HttpContext.Current.Session["sepet"];//sessiondaki sepet alınıyor tabloya aktarılıyor
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)//yine tablonun tüm alanlarında dönecek döngü başlatılıyor
                {
                    indirimtoplam += Convert.ToDouble(dt.Rows[i]["tutar"].ToString()) * Convert.ToDouble(dt.Rows[i]["indiri"].ToString()) / 100;
                    aratoplam += Convert.ToDouble(dt.Rows[i]["tutar"].ToString()) * Convert.ToDouble(dt.Rows[i]["kd"].ToString()) / 100;
                    toplam += Convert.ToDouble(dt.Rows[i]["tutar"].ToString());//her satırdaki tutar miktarı toplam değişkenine aktarılıyor
                    geneltoplam = toplam + aratoplam - indirimtoplam;
                }
            }
            else
            {
                indirimtoplam = 0;
                aratoplam = 0;
                toplam = 0;
                geneltoplam = 0;

            }

        }
        return geneltoplam; //toplam değeri döndürülüyor.

    }
   



    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "silme")//command name sil ise
        {
            Sil(e.CommandArgument.ToString());//yazdığımız sil methoduna o anki ürünün id değerini gönderiyoruz
           
            SepettGetir(); 
        }
    }

}