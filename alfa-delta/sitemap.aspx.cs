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
using AlfaDeltaLogin;
using System.Net.Mail;
using System.Net;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

public partial class sitemap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SiteHaritasiniDondur();
    }

    private void SiteHaritasiniDondur()
    {
        StringBuilder strBuilder = new StringBuilder();
        strBuilder.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
        strBuilder.AppendLine("<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">");

        #region AnaSayfa
        //AnaSayfamızı manuel olarak  Ekliyoruz.
        //veritabanından çekerek oluşturamayacağınız değişken olmayan linkleri bu şeklide ekleyin.
        strBuilder.AppendLine("<url>");

        strBuilder.AppendLine("<loc>");
        string makaleLink = String.Format("http://www.alfa-delta.com");
        strBuilder.AppendLine(makaleLink);
        strBuilder.AppendLine("</loc>");

        strBuilder.AppendLine("<changefreq>");
        strBuilder.AppendLine("always");
        strBuilder.AppendLine("</changefreq>");

        strBuilder.AppendLine("<priority>");
        strBuilder.AppendLine("1");
        strBuilder.AppendLine("</priority>");

        strBuilder.AppendLine("</url>");
        #endregion

        //kategorilere gore sayfaları ekle
        #region Kategoriler

        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=alfa-delta ;Integrated Security=SSPI;Pooling=false");
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter("Select * from urun_kategori", conn);
        DataTable dt = new DataTable();
        da.SelectCommand.ExecuteNonQuery();
        da.Fill(dt);

        foreach (DataRow row in dt.Rows)
        {
            strBuilder.AppendLine("<url>");
            strBuilder.AppendLine("<loc>");
            string kAd = row["kadi"].ToString();
            string kID = row["urun_kategoriID"].ToString();
           
                kAd = kAd.Substring(0, kAd.IndexOf('('));
            

            //linki oluşturuken & yerine &amp; kullanıyoruz. aksi takdirde hata verir.
            makaleLink = String.Format("http://www.alfa-delta.com/Default.aspx?arackategori={0}&amp;Kategori={1}", kID, kAd);

            strBuilder.AppendLine(makaleLink);
            strBuilder.AppendLine("</loc>");

            strBuilder.AppendLine("<changefreq>");
            strBuilder.AppendLine("weekly");
            strBuilder.AppendLine("</changefreq>");

            strBuilder.AppendLine("<priority>");
            strBuilder.AppendLine("0.5");
            strBuilder.AppendLine("</priority>");

            strBuilder.AppendLine("</url>");
        }
        #endregion

        strBuilder.AppendLine("</urlset>");

        Response.ContentType = "text/xml";
        Response.Write(strBuilder.ToString());
        Response.End();
    }
}