using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net;
using System.Collections;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

using System.Security;
public class DovizKurlari1
{
    XmlDocument xml = null;
    const string adres = "http://www.tcmb.gov.tr/kurlar/today.xml";
      XmlTextReader xreader;
      DataTable a;
      DataTable da;
    public enum KurKodu : byte
    {
        USD, CAD, DKK, SEK, NOK, CHF, JPY, SAR, KWD, AUD, EUR, GBP, IRR, SYP, JOG, BGL, ROL, ILS,
    }

    public enum Tur : byte
    {
        ForexBuying, //Döviz alış
        ForexSelling, //Döviz satış
        BanknoteBuying, //Efektif  alış
        BanknoteSelling,  //Efektif satış
    }


    public DovizKurlari1()
    {
        System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
       xml = new XmlDocument();
        xml.Load(new XmlTextReader(adres));
    
        DataSet myDoviz = new DataSet();
      
    }

    public string TlKarsiligi(KurKodu kodu, Tur turu)
    {
        string kod = kodu.ToString();
        string tur = turu.ToString();

        XmlNodeList MyNode = xml.SelectNodes("/Tarih_Date/Currency[@Kod ='" + kod + "']/" + tur);
    //    DateTime exchangeDate = Convert.ToDateTime(xml.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);
        return MyNode.Item(0).InnerText;
    }

    public DataTable Tarih()
    {


        xreader = new XmlTextReader("http://www.tcmb.gov.tr/kurlar/today.xml");
        DataSet dset = new DataSet();
        dset.ReadXml(xreader);
        
        a = dset.Tables[0];
        return a;
    }

    public class TrustAllCertificatePolicy : System.Net.ICertificatePolicy
    {
        public TrustAllCertificatePolicy()
        { }

        public bool CheckValidationResult(ServicePoint sp,
         X509Certificate cert, WebRequest req, int problem)
        {
            return true;
        }
    }
}
