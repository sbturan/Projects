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
public partial class arackategori : System.Web.UI.Page
{  
    int j;
    
    ArrayList alMenu = new ArrayList();
    ArrayList blMenu = new ArrayList();
    protected void Page_Load(object sender, EventArgs e)
    {

        
       

        if (Request.QueryString.Get("ID") != null)
        {
           
            int al = Convert.ToInt32(Request.QueryString.Get("ID"));
          
           
            string isim;
            KategoriBLL deneme = new KategoriBLL();
            KategoriInfo burak1 = new KategoriInfo();
            KategoriInfo ornek = new KategoriInfo();
            ornek = deneme.GetKategoriByID(al);
            if (ornek.LISTE == false)
            {
                MultiView1.ActiveViewIndex = 0;
                int sayfa = ornek.SAYFA;
                DataList2.RepeatColumns = sayfa;
            }
            else {
                MultiView1.ActiveViewIndex =1;
            }


            burak1 = deneme.GetKategoriByID(al);
            isim = burak1.ADI;

            List<KategoriInfo> list = deneme.GetAltKategoriler(al, "tr");
            if (list.Count == 0)
                Response.Redirect("urunler.aspx?ID=" +al );


            if (burak1 != null)
            {



                KategoriBLL deneme2 = new KategoriBLL();




                int cl = burak1.ID;
                burak1 = deneme.GetKategoriByID(cl);
                getir(cl);







                if (Session["dil"] == "en")
                {

                    alMenu.Add(new NavigasyonNesnesi("Main Page", "Default.aspx", NavigasyonNesnesi.TargetType._self));
                }

                else
                {
                    alMenu.Add(new NavigasyonNesnesi("ANA SAYFA", "Default.aspx", NavigasyonNesnesi.TargetType._self));

                }
                //    alMenu.Add(new NavigasyonNesnesi("arackategori", "arackategori.aspx", NavigasyonNesnesi.TargetType._self));
                for (int j = blMenu.Count - 1; j > -1; j--)
                {
                    KategoriBLL deneme3 = new KategoriBLL();
                    KategoriInfo burak2 = new KategoriInfo();
                    int c = (int)blMenu[j];
                    if (c != 0)
                    {

                        burak2 = deneme3.GetKategoriByID(c);

                        if (burak2.SEVIYE != 1)
                        {
                            string isim1 = burak2.ADI;

                            int al2 = burak2.ID;


                            alMenu.Add(new NavigasyonNesnesi(isim1, "arackategori.aspx?ID=" + al2, NavigasyonNesnesi.TargetType._self));
                        }
                    }
                }





                alMenu.Add(new NavigasyonNesnesi(isim, "arackategori.aspx?ID=" + al, NavigasyonNesnesi.TargetType._self));

                if (MultiView1.ActiveViewIndex != 1)
                {


                    Navigasyon2.Yukle(alMenu, kutuphane_Navigasyon1.StyleTip.Style, "color: #7DA1EE; text-decoration: underline;", "color: #171717; text-decoration: none;", " >> ");
                }
                else
                {


                    Navigasyon1.Yukle(alMenu, kutuphane_Navigasyon1.StyleTip.Style, "color: #7DA1EE;  text-decoration: underline;", "color: #171717; text-decoration: none;", " >> ");
                }
            
            }
        }
        else
        {
            Response.Redirect("default.aspx");
        
        }

        ClientScript.RegisterStartupScript(this.GetType(), "Set Active", @"<Script type=""text/javascript"">document.getElementById(""divMenu1"").className = ""active""</Script>");
    }
    public void getir(int id) {
        KategoriBLL deneme = new KategoriBLL();
        KategoriInfo burak1 = new KategoriInfo();
        burak1 = deneme.GetKategoriByID(id);
       // blMenu.Add(burak1.UST_ID);
        if (burak1.UST_ID != 0) {
            blMenu.Add(burak1.UST_ID);
            getir(burak1.UST_ID);
        }
    
    }


    protected void DataList2_ItemCreated(object sender, DataListItemEventArgs e)
    {
        e.Item.TabIndex = 3;
    }
}