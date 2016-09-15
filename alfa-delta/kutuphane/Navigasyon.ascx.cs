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

public partial class kutuphane_Navigasyon : System.Web.UI.UserControl
{
    public string text1 = "";
    private void ProcessNodes(XmlNodeList nodes, int deger)
    {
        foreach (XmlNode node in nodes)
        {
            text1 += "<li>";
            if (node.HasChildNodes)
            {
                text1 += "<ul>";
                ProcessNodes(node.ChildNodes, 1);
                text1 += "</ul>";
            }
            if (node.HasChildNodes)
            {
                text1 += "<a href=\"#\">" + node.Attributes["adi"].Value + "</a></li>";
            }
            else
            {
                text1 += "<a href=\"" + node.Attributes["id"].Value + "\">" + node.Attributes["adi"].Value + "</a></li>";
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //XmlDocument doc = new XmlDocument();
        //doc.Load(Server.MapPath("~/XML/Links.xml"));
        //text1 = Sabit.OzelNav(doc, 0);
    }
}
