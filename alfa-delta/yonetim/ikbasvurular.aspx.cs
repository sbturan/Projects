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
//using DevExpress.Web.ASPxGridView;
using System.Text;
using Microsoft.Office.Interop.Word;
using AlfaDeltaLogin;
using System.IO;
using System.Diagnostics;
using System.Net;

public partial class yonetim_ikbasvurular : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string securitytype = ConfigurationManager.AppSettings.Get("securitytype");

        if (securitytype == "cookie")
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
                Response.Redirect("giris.aspx");

            if (!User.IsInRole("Administrator"))
                Response.Redirect("giris.aspx");
        }

        else
        {
            if (HttpContext.Current.Session["kullanici"] == null)
                Response.Redirect("giris.aspx");

            if (Kullanici.UserInRole(((Kullanici)HttpContext.Current.Session["kullanici"]).Id, "Administrator") == false)
                Response.Redirect("giris.aspx");
        }


        IkInfo info = new IkInfo();
        IkBLL ikBLL = new IkBLL();

        if (Request.QueryString["ID"] != null)
            info = ikBLL.GetBilgiByID(Convert.ToInt32(Request.QueryString["ID"]), 2);

        lbl_IkKonu.Text = info.KONU;


    }
    /* protected void grd_Icerik_RowCommand(object sender, DataListCommandEventArgs e)
     {
         
           string url="";

           if (e.CommandName.ToString() == "oku")
           {
               IkDetayInfo ikdtyinfo = new IkDetayInfo();
               IkDetayBLL ikdtybll = new IkDetayBLL();
               ikdtyinfo = ikdtybll.GetBilgiByID(Convert.ToInt32(e.CommandArgument.ToString()));

               System.Diagnostics.Process proc = new System.Diagnostics.Process();

               proc.StartInfo.FileName = (Server.MapPath( ikdtyinfo.DOSYA.ToString() )).ToString();
               proc.StartInfo.UseShellExecute = true;

               try
               { proc.Start(); }
               catch(Exception ex) {


                   MessageBox.Show("Bir hata Oluştu\n\nAYRINTILAR\n\n" + ex.Message);
               }
             
           }
           else if (e.CommandName.ToString() == "sil")
           {
           }
     }*/
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridView1.SelectedRow;
        int id = Convert.ToInt32(row.Cells[2].Text);
        IkDetayInfo ikdtyinfo = new IkDetayInfo();
        IkDetayBLL ikdtybll = new IkDetayBLL();
        ProcessStartInfo psi = new ProcessStartInfo("cmd.exe", Server.MapPath("/Files/" + ikdtyinfo.DOSYA));
        FtpWebRequest FTP;
try
{
   FileStream SR = new FileStream("C:\\" + ikdtyinfo.DOSYA,FileMode.Create);

FTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://alfa-delta.com:281/alfadelta/wwwroot/Files/"+ ikdtyinfo.DOSYA));

FTP.Credentials =new NetworkCredential("alfadelta", "adx9080");

FTP.Method =WebRequestMethods.Ftp.DownloadFile;

FTP.UseBinary =true;

FtpWebResponse response = (FtpWebResponse)FTP.GetResponse();

Stream ftpStream = response.GetResponseStream();

long cl = response.ContentLength;

int bufferSize = 1024;

int readCount;

byte[] buffer = new byte[bufferSize];

readCount = ftpStream.Read(buffer, 0, bufferSize);

while (readCount > 0)

{

SR.Write(buffer, 0, readCount);

readCount = ftpStream.Read(buffer, 0, bufferSize);

}

ftpStream.Close();

SR.Close();

response.Close();

}
        catch (Exception ex)
        {

          
            MessageBox.Show("Bir hata Oluştu\n\nAYRINTILAR\n\n" + ex.Message);
        }
        


    }


    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {


        switch (e.CommandName)
        {
            case "Delete":
                int index = Convert.ToInt32(e.CommandArgument);
                IkDetayBLL ikdtybll = new IkDetayBLL();
                MessageBox.Show(" İşlem tamamlanmıştır\n\n");

                try
                {
                    ikdtybll.Delete(index);

                    MessageBox.Show(" İşlem tamamlanmıştır\n\n");
                    Response.Redirect("ikbasvurular.aspx");
                }
                catch (Exception ex)
                {


                    MessageBox.Show("Bir hata Oluştu\n\nAYRINTILAR\n\n" + ex.Message);
                }


                MessageBox.Show("İslem Basarili");
                Server.Transfer("urunler.aspx");

                break;
            default:
                break;
        }
    }
}
