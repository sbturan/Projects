using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class yonetim_aktifsil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
 

    }
   
     protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
     {
         switch (e.CommandName)
         {
             case "Delete":
                 int index = Convert.ToInt32(e.CommandArgument);

                 Users1BLL a = new Users1BLL();
                 Users1Info b = new Users1Info();
                 b = a.BulByID(index);


                 try
                 {
                     a.Sil(b);
                 }
                 catch (Exception ex)
                 {


                     MessageBox.Show("Bir hata Oluştu\n\nAYRINTILAR\n\n" + ex.Message);
                 }


                 MessageBox.Show("İslem Basarili");
                 Server.Transfer("Aktifsil.aspx");

                 break;
             default:
                 break;
         }
     }
     protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
     {
         GridViewRow row = GridView1.SelectedRow;
         int id = Convert.ToInt32(row.Cells[2].Text);
         Response.Redirect("Kullaniciduzenle.aspx?ID=" + id);
     }
}