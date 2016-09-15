using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Globalization;
using System.Collections;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Security;
using System.Data;
public partial class yonetim_parabirimi : System.Web.UI.Page
{
    
    string y;
    string d;
    string fa;
    string t;
    int ID;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        try
        {
            DovizKurlari1 dk = new DovizKurlari1();
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.CurrencyDecimalDigits = 4;
            nfi.NumberDecimalSeparator = ".";
            nfi.NumberGroupSeparator = ",";
            nfi.NumberGroupSizes = new int[] { 3 };
          ArrayList aList = new ArrayList();



          double usdAlis = Convert.ToDouble(dk.TlKarsiligi(DovizKurlari1.KurKodu.USD, DovizKurlari1.Tur.ForexBuying), nfi);
          double usdSatis = Convert.ToDouble(dk.TlKarsiligi(DovizKurlari1.KurKodu.USD, DovizKurlari1.Tur.ForexSelling), nfi);
          double euroAlis = Convert.ToDouble(dk.TlKarsiligi(DovizKurlari1.KurKodu.EUR, DovizKurlari1.Tur.ForexBuying), nfi);
          double euroSatis = Convert.ToDouble(dk.TlKarsiligi(DovizKurlari1.KurKodu.EUR, DovizKurlari1.Tur.ForexSelling), nfi);
           
           
       
       txt_doa.Text = string.Format(usdAlis.ToString(nfi));
         
            txt_dos.Text = string.Format(usdSatis.ToString(nfi));
            txt_euoa.Text = string.Format(euroAlis.ToString(nfi));
            txt_euos.Text = string.Format(euroSatis.ToString(nfi));
            y = string.Format(txt_doa.Text.ToString(nfi));
            d = string.Format(txt_dos.Text.ToString(nfi));
            fa = string.Format(txt_euoa.Text.ToString(nfi));
            t = txt_euos.Text = string.Format(txt_euos.Text.ToString(nfi));
            DataTable a = dk.Tarih();
            Label2.Text = a.Rows[0][1].ToString();
               
        }
        catch (Exception ex) {
            Label1.Text = ex.ToString();
            MessageBox.Show(ex.ToString());
        
        }

        
       if (!IsPostBack)
       {
         
            yukle();
        }
        
    


   



    }
    public void yukle() {
        ParaalBLL dene = new ParaalBLL();
        ParaalInfo info1 = new ParaalInfo();
        info1 = dene.GetKur();
        ID=info1.ID;
        txt_1.Text = info1.DOLARA.ToString();
        txt_2.Text = info1.DOLARS.ToString();
        Txt_3.Text = info1.EUROA.ToString();
        Txt_4.Text = info1.EUROS.ToString();
        
    
    }
 
    protected void Button1_Click(object sender, EventArgs e)
    {
       
            ParaalBLL dene = new ParaalBLL();
            ParaalInfo info = new ParaalInfo();
            info.EUROA = (float) Convert.ToDouble( Txt_3.Text);
            info.ID=2;
            info.KONTROL = 1;
            info.EUROS = (float)Convert.ToDouble(Txt_4.Text);
            info.DOLARA = (float)Convert.ToDouble(txt_1.Text);
            info.DOLARS = (float)Convert.ToDouble(txt_2.Text); 
            dene.Update(info);
                    Label1.Visible = true;
                    Label1.Text = "Guncelleme 'islemi tamamlanmistir.Lutfen Anasayfada kontrol ediniz.";
                    Response.Redirect("parabirimi.aspx");  
    }
   
    protected void Button3_Click(object sender, EventArgs e)
    {
        ParaalBLL dene = new ParaalBLL();
            ParaalInfo info = new ParaalInfo();
            info.EUROA = (float.Parse(fa, CultureInfo.InvariantCulture.NumberFormat));
            info.ID =2;
            info.KONTROL = 1;
            info.EUROS = float.Parse(t, CultureInfo.InvariantCulture.NumberFormat);
            info.DOLARA = float.Parse(y, CultureInfo.InvariantCulture.NumberFormat);
            info.DOLARS = float.Parse(d, CultureInfo.InvariantCulture.NumberFormat);
            dene.Update(info);
            Label1.Visible = true;
            Label1.Text = "Guncelleme 'islemi tamamlanmistir.Lutfen Anasayfada kontrol ediniz.";
            Response.Redirect("parabirimi.aspx");  
    }
   
}





