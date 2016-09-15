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
/// Summary description for bannerInfo
/// </summary>
public class BannerInfo
{
			
    private int _id;

	public int ID
	{
		get { return _id;}
		set { _id = value;}
	}

    private string _adi;
    
    public string ADI
    {
        get { return _adi; }
        set { _adi = value; }
    }

    private string _dosya;

    public string DOSYA
    {
        get { return _dosya; }
        set { _dosya = value; }
    }

    private string _url;

    public string URL
    {
        get { return _url; }
        set { _url = value; }
    }

    private string _genislik;
    
    public string GENISLIK
    {
        get { return _genislik; }
        set { _genislik = value; }
    }

    private string _yukseklik;
    
    public string YUKSEKLIK
    {
        get { return _yukseklik; }
        set { _yukseklik = value; }
    }

    private long _relay;

    public long RELAY
    {
        get { return _relay; }
        set { _relay = value; }
    }

    
    private DateTime _tarih;

    public DateTime TARIH
    {
        get { return _tarih; }
        set { _tarih = value; }
    }

    private int _tip;

    public int TIP
    {
        get { return _tip; }
        set { _tip = value; }
    }

    private bool _yayin_durumu;


    public bool YAYIN_DURUMU
    {
        get { return _yayin_durumu; }
        set { _yayin_durumu = value; }
    }

    private int _hit;

    public int HIT
    {
        get { return _hit; }
        set { _hit = value; }
    }


    public BannerInfo()
    {

    }

    public BannerInfo(int id, string adi, string dosya, string url, string genislik, string yukseklik, long relay, DateTime tarih, int tip, bool yayin_durumu, int hit)
    {
        this._id = id;
        this._adi = adi;
        this._dosya =dosya;
        this._url = url;
        this._genislik = genislik;
        this._yukseklik = yukseklik;
        this._relay = relay;
        this._tarih = tarih;
        this._tip = tip;
        this._yayin_durumu = yayin_durumu;
        this._hit = hit;
    }



    public BannerInfo (SqlDataReader dr)
    {
        this._id = DataReader.GetInt32(dr["BannerID"]);
        this._adi = DataReader.GetString(dr["adi"]);
        this._dosya = DataReader.GetString(dr["dosya"]);
        this._url = DataReader.GetString(dr["url"]);
        this._genislik = DataReader.GetString(dr["genislik"]);
        this._yukseklik = DataReader.GetString(dr["yukseklik"]);
        this._relay = DataReader.GetInt64(dr["relay"]);
        this._tarih = DataReader.GetDateTime(dr["eklenme_tarih"]);
        this._tip = DataReader.GetInt32(dr["tip"]);
        this._yayin_durumu = DataReader.GetBoolean(dr["yayin_durumu"]);
        this._hit = DataReader.GetInt32(dr["hit"]);
    }






	
	
}
