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

/// <summary>
/// Summary description for Sabit
/// </summary>
public class Sabit
{
    public Sabit()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region

    static string idd = string.Empty;
    static string no = string.Empty;
    static string arama = "0";
    static string arama1 = "0";
    static string konu = "1";
    static string resim = "iletisim.jpg";
    static string lang = "111";

    public static bool ThumbnailImageAbort()
    {
        return false;
    }
    public static string Navigasyon()
    {
        return idd;
    }
    public static void Navigasyon(string al)
    {
        idd = al;
    }
    public static string seri()
    {
        return resim;
    }
    public static void seri(string al)
    {
        resim = al;
    }
    public static string ara()
    {
        return arama;
    }
    public static void ara(string al)
    {
        arama = al;
    }
    public static string portal()
    {
        return arama1;
    }
    public static void portal(string al)
    {
        arama1 = al;
    }
    public static string baski()
    {
        return konu;
    }
    public static void baski(string al)
    {
        konu = al;
    }
    public static string id()
    {
        return no;
    }
    public static void id(string al)
    {
        no = al;
    }
    public static string dil()
    {
        return lang;
    }
    public static void dil(string al)
    {
        lang = al;
    }
    #endregion

    public static string text1 = "";
    public static XmlDocument doc = new XmlDocument();

    public static string UstNav()
    {
        DataTable dt = new DataTable();
        MenuDAL bll = new MenuDAL();
        dt = bll.GetAll2();
        text1 = "<div id=\"smoothmenu1\" style=\"width:830px;\" class=\"ddsmoothmenu\"><ul>";

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Convert.ToInt32(dt.Rows[i]["ana_menu_grup"].ToString()) == 0)
            {
                if ((dt.Rows[i]["link"].ToString() == "") || (dt.Rows[i]["link"].ToString() == null))
                    text1 += "<li><a href=\"#\">" + dt.Rows[i]["adi"].ToString() + "</a>";
                else
                    text1 += "<li><a href=\"" + dt.Rows[i]["link"].ToString() + "\">" + dt.Rows[i]["adi"].ToString() + "</a>";
                if (HasChild(Convert.ToInt32(dt.Rows[i]["id"])))
                {
                    text1 += "<ul>";
                    yazdir(Convert.ToInt32(dt.Rows[i]["menu_ID"]));
                    text1 += "</ul>";
                }
                if (HasChild(Convert.ToInt32(dt.Rows[i]["menu_ID"])))
                {
                    text1 += "</li>";
                }
                else
                {
                    text1 += "</li>";
                    //text1 += "<a href=\"" + dt.Rows[i]["id"].ToString() + "\">" + dt.Rows[i]["adi"].ToString() + "</a></li>";
                }
            }
        }
        text1 += "</ul></div>";

        return text1;
    }

    public static string YanNav()
    {
        DataTable dt = new DataTable();
        MenuDAL bll = new MenuDAL();
        dt = bll.GetAll2();
        text1 = "<div id=\"smoothmenu2\" style=\"width:253px;\" class=\"ddsmoothmenu-v\"><ul>";

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Convert.ToInt32(dt.Rows[i]["ana_menu_grup"].ToString()) == 0)
            {
                if ((dt.Rows[i]["link"].ToString() == "") || (dt.Rows[i]["link"].ToString() == null))
                    if (HasChild(Convert.ToInt32(dt.Rows[i]["menu_ID"].ToString())))
                        text1 += "<li><a style=\"background-image:url(images/bot.png); background-repeat:no-repeat; background-position:right;\" href=\"#\">" + dt.Rows[i]["adi"].ToString() + "</a>";
                    else
                        text1 += "<li><a href=\"#\">" + dt.Rows[i]["adi"].ToString() + "</a>";

                else
                    if (HasChild(Convert.ToInt32(dt.Rows[i]["menu_ID"].ToString())))
                        text1 += "<li><a style=\"background-image:url(images/bot.png); background-repeat:no-repeat; background-position:right;\" href=\"" + dt.Rows[i]["link"].ToString() + "\">" + dt.Rows[i]["adi"].ToString() + "</a>";
                    else
                        text1 += "<li><a href=\"" + dt.Rows[i]["link"].ToString() + "\">" + dt.Rows[i]["adi"].ToString() + "</a>";
                if (HasChild(Convert.ToInt32(dt.Rows[i]["menu_ID"])))
                {
                    text1 += "<ul>";
                    yazdir(Convert.ToInt32(dt.Rows[i]["menu_ID"]));
                    text1 += "</ul>";
                }
                if (HasChild(Convert.ToInt32(dt.Rows[i]["menu_ID"])))
                {
                    text1 += "</li>";
                }
                else
                {
                    text1 += "</li>";
                    //text1 += "<a href=\"" + dt.Rows[i]["id"].ToString() + "\">" + dt.Rows[i]["adi"].ToString() + "</a></li>";
                }
            }
        }
        text1 += "</ul></div>";

        return text1;
    }

    public static void yazdir(int ID)
    {
        DataTable dt = new DataTable();
        MenuDAL bll = new MenuDAL();
        dt = bll.GetByAnaMenuGrup(ID);
        //style=\"background-image:url(images/bot.png); background-repeat:no-repeat; backgroun-position:left;\"
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if ((dt.Rows[i]["link"].ToString() == "") || (dt.Rows[i]["link"].ToString() == null))
                if (HasChild(Convert.ToInt32(dt.Rows[i]["menu_ID"].ToString())))
                    text1 += "<li><a style=\"background-image:url(images/bot.png); background-repeat:no-repeat; backgroun-position:left;\" href=\"#\">" + dt.Rows[i]["adi"].ToString() + "</a>";
                else
                    text1 += "<li><a href=\"#\">" + dt.Rows[i]["adi"].ToString() + "</a>";

            else
                if (HasChild(Convert.ToInt32(dt.Rows[i]["menu_ID"].ToString())))
                    text1 += "<li><a style=\"background-image:url(images/bot.png); background-repeat:no-repeat; backgroun-position:left;\" href=\"" + dt.Rows[i]["link"].ToString() + "\">" + dt.Rows[i]["adi"].ToString() + "</a>";
                else
                    text1 += "<li><a href=\"" + dt.Rows[i]["link"].ToString() + "\">" + dt.Rows[i]["adi"].ToString() + "</a>";
            //text1 += "<li><a href=\"" + dt.Rows[i]["link"].ToString() + "\">" + dt.Rows[i]["adi"].ToString() + "</a>";
            if (HasChild(Convert.ToInt32(dt.Rows[i]["menu_ID"])))
            {
                text1 += "<ul>";
                yazdir(Convert.ToInt32(dt.Rows[i]["menu_ID"]));
                text1 += "</ul>";
            }
            if (HasChild(Convert.ToInt32(dt.Rows[i]["menu_ID"])))
            {
                text1 += "</li>";
            }
            else
            {
                text1 += "</li>";
                //text1 += "<a href=\"" + dt.Rows[i]["id"].ToString() + "\">" + dt.Rows[i]["adi"].ToString() + "</a></li>";
            }
        }
    }

    public static bool HasChild(int ID)
    {
        DataTable dt = new DataTable();
        MenuDAL bll = new MenuDAL();
        dt = bll.GetByAnaMenuGrup(ID);
        if (dt.Rows.Count > 0)
            return true;
        else
            return false;
    }

    private static void ProcessNodes()
    {
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        MenuDAL bll = new MenuDAL();
        dt = bll.GetAll2();


        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Convert.ToInt32(dt.Rows[i]["ana_menu_grup"].ToString()) == 0)
            {
                text1 += "<li>";
                if (HasChild(Convert.ToInt32(dt.Rows[i]["menu_ID"])))
                {
                    text1 += "<ul>";
                    yazdir(Convert.ToInt32(dt.Rows[i]["menu_ID"]));
                    text1 += "</ul>";
                }
                if (HasChild(Convert.ToInt32(dt.Rows[i]["menu_ID"])))
                {
                    text1 += "<a href=\"#\">" + dt.Rows[i]["adi"].ToString() + "</a></li>";
                }
                else
                {
                    text1 += "<a href=\"" + dt.Rows[i]["menu_ID"].ToString() + "\">" + dt.Rows[i]["adi"].ToString() + "</a></li>";
                }
            }
        }

    }
    public static string SolNav(int ID)
    {
        DataTable dt = new DataTable();
        MenuDAL bll = new MenuDAL();
        MenuInfo inf = new MenuInfo();
        inf = bll.MenuByID(ID);
        if (inf.ANA_MENU_GRUP == 0)
            dt = bll.GetByAnaMenuGrup(ID);
        else
            dt = bll.GetByAnaMenuGrup(inf.ANA_MENU_GRUP);
        text1 = "<div id=\"smoothmenu2\" style=\"width:253px;\" class=\"ddsmoothmenu-v\"><ul>";

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if ((dt.Rows[i]["link"].ToString() == "") || (dt.Rows[i]["link"].ToString() == null))
                if (HasChild(Convert.ToInt32(dt.Rows[i]["menu_ID"].ToString())))
                    text1 += "<li><a style=\"background-image:url(images/bot.png); background-repeat:no-repeat; background-position:right;\" href=\"#\">" + dt.Rows[i]["adi"].ToString() + "</a>";
                else
                    text1 += "<li><a href=\"#\">" + dt.Rows[i]["adi"].ToString() + "</a>";

            else
                if (HasChild(Convert.ToInt32(dt.Rows[i]["menu_ID"].ToString())))
                    text1 += "<li><a style=\"background-image:url(images/bot.png); background-repeat:no-repeat; background-position:right;\" href=\"" + dt.Rows[i]["link"].ToString() + "\">" + dt.Rows[i]["adi"].ToString() + "</a>";
                else
                    text1 += "<li><a href=\"" + dt.Rows[i]["link"].ToString() + "\">" + dt.Rows[i]["adi"].ToString() + "</a>";

            if (HasChild(Convert.ToInt32(dt.Rows[i]["menu_ID"])))
            {
                text1 += "<ul>";
                yazdir(Convert.ToInt32(dt.Rows[i]["menu_ID"]));
                text1 += "</ul>";
            }
            if (HasChild(Convert.ToInt32(dt.Rows[i]["menu_ID"])))
            {
                text1 += "</li>";
            }
            else
            {
                text1 += "</li>";
                //text1 += "<a href=\"" + dt.Rows[i]["id"].ToString() + "\">" + dt.Rows[i]["adi"].ToString() + "</a></li>";
            }
        }
        text1 += "</ul></div>";

        return text1;
    }

    public static string Buradasiniz(int ID)
    {
        string yazi = "Bulunduðunuz Yer:&nbsp;";
        yazi += "<a href=\"Default.aspx\" >Ana Sayfa</a>&nbsp;&nbsp;>>&nbsp;&nbsp;";
        MenuDAL dal = new MenuDAL();
        MenuInfo inf = new MenuInfo();
        MenuInfo inf2 = new MenuInfo();
        MenuInfo inf3 = new MenuInfo();
        inf = dal.MenuByID(ID);
        if (inf.ANA_MENU_GRUP != 0)
        {
            inf2 = dal.MenuByID(inf.ANA_MENU_GRUP);
            yazi += "<a href=\"" + inf2.LINK + "\" >" + inf2.ADI + "</a>&nbsp;&nbsp;>>&nbsp;&nbsp;";
        }
        yazi += "<a href=\"" + inf.LINK + "\" >" + inf.ADI + "</a>";
        return yazi;
    }

    public static string BuradasinizBos()
    {
        string yazi = "Bulunduðunuz Yer:&nbsp;";
        yazi += "<a href=\"Default.aspx\" >Ana Sayfa</a>";

        return yazi;
    }

    private static void ProcessNodesOzel(XmlNodeList nodes, int deger, string note)
    {

        foreach (XmlNode node in nodes)
        {
            if (node.Attributes["adi"].Value == note)
            {
                text1 += "<li>";
                if (node.HasChildNodes)
                {
                    //text1 += "<ul>";
                    //ProcessNodes(node.ChildNodes, 1);
                    //text1 += "</ul>";
                }
                if (node.HasChildNodes)
                {
                    //text1 += "<a href=\"#\">" + node.Attributes["adi"].Value + "</a></li>";
                }
                else
                {
                    text1 += "<a href=\"" + node.Attributes["id"].Value + "\">" + node.Attributes["adi"].Value + "</a></li>";
                }
            }
        }
    }

}
