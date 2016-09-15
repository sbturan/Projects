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
using System.Collections;

public class MenuDoldurDAL
{
    #region Select Type Operations
    Dictionary<int, string> _menu = new Dictionary<int, string>();
    ArrayList menu_ad = new ArrayList();
    ArrayList menu_id = new ArrayList();
    string tire = "";
    int sayac, yedek, diziBoyut = 0, depth=0;
    DataTable dt = new DataTable();

    public static readonly string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["MSSqlConnString"].ToString();
    public MenuDoldurDAL()
    { }
    public List<MenuDoldurInfo> GetList()
    {
        List<MenuDoldurInfo> list = new List<MenuDoldurInfo>();
        DiziDoldur();
        //for (int i = 0; i < diziBoyut; i++)
        //{

        //    MenuDoldurInfo inf = new MenuDoldurInfo();
        //    inf.ID = Convert.ToInt32(menu_id[i].ToString());
        //    inf.AD = menu_ad[i].ToString();
        //    list.Add(inf);
        //}
        foreach (KeyValuePair<int, string> item in _menu)
        {
            list.Add(new MenuDoldurInfo(item.Key, item.Value));
        }
        return list;
    }

    MenuDoldurInfo inf1 = new MenuDoldurInfo();
    public void DiziDoldur()
    {
        MenuDAL bll = new MenuDAL();
        List<MenuInfo> info = new List<MenuInfo>();
        dt = bll.GetAllForYonetim();
        diziBoyut = dt.Rows.Count;
        // drp_menu.Items.Clear();

        List<MenuDoldurInfo> list = new List<MenuDoldurInfo>();
        _menu.Add(0, "Lütfen Seçiniz");
        //inf1.AD = "Lütfen Seçiniz";
        //inf1.ID = 0;
        //menu_ad.Add(Convert.ToString("Lütfen Seçiniz"));
        //menu_id.Add(Convert.ToInt32("0"));
        //list.Add(inf1);
        depth += 1;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Convert.ToInt32(dt.Rows[i]["ana_menu_grup"].ToString()) == 0)
            {
                _menu.Add(Convert.ToInt32(dt.Rows[i]["menu_ID"]), Convert.ToString(dt.Rows[i]["adi"]));
                //menu_ad.Add(Convert.ToString(dt.Rows[i]["adi"]));
                //menu_id.Add(Convert.ToString(dt.Rows[i]["id"].ToString()));
                //list.Add(inf1);
                depth += 1;
                sayac += 0;
                yazdir(Convert.ToInt32(dt.Rows[i]["menu_ID"]), "");
                //dt.Clear();
                //dt = bll.GetAllForYonetim();
                sayac = 0;
            }
        }
        foreach (KeyValuePair<int,string> item in _menu)
        {
            list.Add(new MenuDoldurInfo(item.Key,item.Value));
        }
        //return list;
    }

    public void yazdir(int ID, string prmNode)
    {
        DataTable dtAltKategori = new DataTable();
        MenuDAL dal = new MenuDAL();
        dtAltKategori = dal.GetByAnaMenuGrup(ID);
        if (dtAltKategori.Rows.Count > 0)
        {
            yedek += 1;
            sayac += 1;
            for (int t = 0; t <= sayac; t++)
                tire += "-";
            for (int j = 0; j < dtAltKategori.Rows.Count; j++)
            {
                _menu.Add(Convert.ToInt32(dtAltKategori.Rows[j]["menu_ID"]), tire + Convert.ToString(dtAltKategori.Rows[j]["adi"]));
                //menu_ad.Add(tire + Convert.ToString(dtAltKategori.Rows[j]["adi"]));
                //menu_id.Add(Convert.ToString(dtAltKategori.Rows[j]["id"]));
                depth += 1;
                yazdir(Convert.ToInt32(dtAltKategori.Rows[j]["menu_ID"]), "");
                dtAltKategori.Clear();
                dtAltKategori = dal.GetByAnaMenuGrup(ID);
            }
            tire = "";
            sayac = sayac - yedek;
            yedek = 0;
        }
    }
    #endregion



}
