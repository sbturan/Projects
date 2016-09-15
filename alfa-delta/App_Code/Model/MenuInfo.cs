using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for MenuInfo
/// </summary>
public class MenuInfo
{
    public MenuInfo()
    {

    }

    #region Properties
    private int _id;

    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }

    private string _adi;

    public string ADI
    {
        get { return _adi; }
        set { _adi = value; }
    }
    private string _dil;

    public string DIL
    {
        get { return _dil; }
        set { _dil = value; }
    }
    private string _link;

    public string LINK
    {
        get { return _link; }
        set { _link = value; }
    }

    private string _resim;

    public string RESIM
    {
        get { return _resim; }
        set { _resim = value; }
    }

    private int _sira;

    public int SIRA
    {
        get { return _sira; }
        set { _sira = value; }
    }

    private int _menu_grup;

    public int MENU_GRUP
    {
        get { return _menu_grup; }
        set { _menu_grup = value; }
    }

    private int _ana_menu_grup;

    public int ANA_MENU_GRUP
    {
        get { return _ana_menu_grup; }
        set { _ana_menu_grup = value; }
    }

   
   
    private int _yukseklik;

    public int YUKSEKLIK
    {
        get { return _yukseklik; }
        set { _yukseklik = value; }
    }

    private int _genislik;

    public int GENISLIK
    {
        get { return _genislik; }
        set { _genislik = value; }
    }

   

    private int _yayin_durumu;

    public int YAYIN_DURUMU
    {
        get { return _yayin_durumu; }
        set { _yayin_durumu = value; }
    }
    #endregion

    #region Constructors
    public MenuInfo(int id, string adi,string dil, string link, string resim, int sira, int menu_grup, int ana_menu_grup, int yukseklik, int genislik, int yayin_durumu)
    {
        this._id = id;
        this._dil = dil;
        this._adi = adi;
        this._link = link;
        this._resim = resim;
        this._sira = sira;
        this._menu_grup = menu_grup;
        this._ana_menu_grup = ana_menu_grup;
        this._yukseklik = yukseklik;
        this._genislik = genislik;
        this._yayin_durumu = yayin_durumu;

    }
    #endregion


    public MenuInfo(SqlDataReader dr)
    {
        this._id = DataReader.GetInt32(dr["menu_ID"]);
        this._adi = DataReader.GetString(dr["adi"]);
        this._dil = DataReader.GetString(dr["dil"]);
        this._link = DataReader.GetString(dr["link"]);
        this._resim = DataReader.GetString(dr["icon"]);
        this._sira = DataReader.GetInt32(dr["sira"]);
        this._menu_grup = DataReader.GetInt32(dr["menu_grup"]);
        this._ana_menu_grup = DataReader.GetInt32(dr["ana_menu_grup"]);
        this._yukseklik = DataReader.GetInt32(dr["yukseklik"]);
        this._genislik = DataReader.GetInt32(dr["genislik"]);
        
        this._yayin_durumu = DataReader.GetInt32(dr["yayin_durumu"]);
    }

}
