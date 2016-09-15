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

public partial class uyeol : System.Web.UI.Page
{
    int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        
        if (Session["dil"] == "en")
        {
           
            lblSifre.Text = "Password";
            lblSifreTerkar.Text="Re-enter Password";
           
            lblTelNo.Text = "Phone Number";
          
            lblHeader.Text = "Membership Form";


        }
        
        
        if (Request.QueryString["ID"] != null)
        {
             id = Convert.ToInt32(Request.QueryString["ID"]);
                OnlineUye.Visible = true; 
            lblHeader.Text = "Üyelik Formu";
           

        }
    }
    
   
    protected void Gonder_Click(object sender, ImageClickEventArgs e)
    {
        
        
            SaveData();

            


      //}
    }

    private void SaveData()
    {
        UsersInfo info = new UsersInfo();
       
           
            info.Durum = true;
            info.RoleId = 3;
            info.Sifre = txt_Sifre.Text;
            info.Id = id;
            info.Telefon = txt_TelNo.Text;
            info.PARA_KONTROL = 0;
             new UsersBLL().update(info);
        KontrolInfo infor =new KontrolInfo();
        infor.ID=id;
        infor.KONTROL=0;
        new KontrolBLL().Insert(infor);
               
    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "webformdesigner", "alert('Bilgileriniz Başarıyla Gönderilmiştir.');", true);




                   


                
              
    }
   
}

