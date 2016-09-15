<%@ WebHandler Language="C#" Class="Urunler" %>

using System;
using System.Web;

[System.Web.Services.WebServiceBinding(ConformsTo = System.Web.Services.WsiProfiles.BasicProfile1_1), System.Web.Services.WebService(Namespace = "http://tempuri.org/")]
public class Urunler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) 
    {
        System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(context.Response.OutputStream, System.Text.Encoding.UTF8);
        writer.Formatting = System.Xml.Formatting.Indented;
        FlashUrunlerDAL myDAL = new FlashUrunlerDAL();
        System.Collections.Generic.List<FlashUrunlerInfo> myListInfo = new System.Collections.Generic.List<FlashUrunlerInfo>();
        myListInfo = myDAL.GetirListBySiraAndDil("tr",1);

        writer.WriteStartElement("urunler");
        foreach (FlashUrunlerInfo var in myListInfo)
        {
            writer.WriteStartElement("urun");
            writer.WriteStartElement("resim");
            writer.WriteString(var.UrunResim.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("link");
            writer.WriteString(var.UrunLink.ToString());
            writer.WriteEndElement();
            
            writer.WriteEndElement();
        }
        writer.WriteEndElement();
        writer.Close();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}