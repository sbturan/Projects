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
using System.Xml;

public partial class kutuphane_Navigasyon1 : System.Web.UI.UserControl
{
    public string temp;
   
    public enum StyleTip
    {
        Style,
        Class
    }

    public void Yukle(ArrayList alMenu, StyleTip StyleTipi, string LinkCSS, string TextCSS, string Ayrac)
    {
        //alMenu arraylistine eklediğimiz NavigasyonNesneleri içinde dönüyoruz...
        for (int i = 0; i < alMenu.Count; i++)
        {
           
             NavigasyonNesnesi nn =  (NavigasyonNesnesi)alMenu[i];
           
           
                if (String.IsNullOrEmpty(nn.Url))
            {
                //Bu kısma düşen nesnenin text tipinde olduğunu anlıyoruz...
                //StyleTipi.ToString() ile girilen CSS bilgilerinin style ya da class mı? olduğunu belirtiyoruz...
                //TextCSS normal text yazılar için kullanacağımız CSS biçimi...
                //nn.Baslik eklediğimiz NavigasyonNesnesi'nin başlğı...
                //Ayrac bölümler arasında kullanılacak text değer... Bu kısımda isterseniz HTML değerde gönderebilirsiniz...
                //Ör: "<b> >> </b>" gibi...
                temp += "<span " + StyleTipi.ToString() + "=\"" + TextCSS + "\">" + nn.Baslik + "</span>" + Ayrac;
            }
            else
            {
                //Bu kımda düşenlerin ise link şeklinde olacağını anlıyoruz...
                //nn.Target.ToString() linkin açılma tipi...
                //.nn.Url sayfa adresi...
                //StyleTipi, LinkCSS, nn.Baslik ve Ayrac yukarıdaki gibi aynı işlevlere sahip...
                temp += "<a target=" + nn.Target.ToString() + " href=\"" + nn.Url + "\" " + StyleTipi.ToString() + "=\"" + LinkCSS + "\">" + nn.Baslik + "</a>" + Ayrac;
            }
        }
        //Bu kısımda en son eklenen fazlalık olan ayracı kaldırıyoruz...
        temp = temp.Remove(temp.Length - Ayrac.Length);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //XmlDocument doc = new XmlDocument();
        //doc.Load(Server.MapPath("~/XML/Links.xml"));
        //text1 = Sabit.OzelNav(doc, 0);
    }
}
