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

public partial class kutuphane_Email : System.Web.UI.UserControl
{

    public string girilenPage = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack)
            return;

        girilenPage = Request.ServerVariables["PATH_INFO"].ToString();
        
        //if (girilenPage.Contains("Arama.aspx"))
        //{
        //    navigasyon = Sabit.BuradisinizArama(txt_Ara.Text.ToString());
        //}
        //else
        //{

        //    if (Sabit.Navigasyon() != "")
        //    {
        //        navigasyon = Sabit.Buradasiniz(Convert.ToInt32(Sabit.Navigasyon()));
        //    }
        //    else
        //    {

        //        navigasyon = Sabit.BuradasinizBos();
        //    }
        //}

    }
    public string navigasyon = "";
    public string temiz = "";
   
    protected void btn_Email_Click1(object sender, ImageClickEventArgs e)
    {
        MailListeBLL MailListBLL = new MailListeBLL();
        MailListeInfo MailListInfo = new MailListeInfo();
        MailListInfo.ADI = "";
         MailListInfo.DURUM =true;
        MailListInfo.EMAIL = SqlInject.InjectionManager.RejectInjection(txt_mail.Text);
       
    //    MailListBLL.Insert(MailListInfo);

        txt_mail.Text = "E-Posta adresiniz..";

        MessageBox.Show("Mailiniz baþarýyla alýnmýþtýr..");

        
    }
}
