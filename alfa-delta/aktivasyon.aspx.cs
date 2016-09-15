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

public partial class aktivasyon : System.Web.UI.Page
{
    int id;
    protected void Page_Load(object sender, EventArgs e)
    {

        Label1.Visible = false;
        if (Session["dil"] == "en")
        {
            lblEmail0.Text = "activation Code";
            lblHeader.Text = "Activation Confirmation";

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
        UsersBLL al = new UsersBLL();
        UsersInfo bl = new UsersInfo();
        bl = al.BulByEmailID(txt_Email.Text);
        
        if (bl == null)
        {
            Label1.Visible = true;
            Label1.Text = "Mailiniz Hatali";
            lblHeader.Visible = false;
            OnlineUye.Visible = false;
        }
        else
        {
            if (bl.AKTIVASYON == txt_TelNo.Text)
            {
                id = bl.Id;
                SaveData();

            }
            else {

                Label1.Visible = true;
                Label1.Text = "Aktivasyon Kodunuz Hatalı";
                lblHeader.Visible = false;
                OnlineUye.Visible = false;
            
            }
        }

      //}
    }

    private void SaveData()
    {
        UsersInfo info = new UsersInfo();
       
           
          
            info.Durum = true;
            info.RoleId = 3;
           

            
              new UsersBLL().update(info);


              Response.Redirect("uyeol.aspx?ID=" + id);

      }
              
    }
   


