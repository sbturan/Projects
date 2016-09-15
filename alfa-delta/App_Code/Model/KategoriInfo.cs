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


public class KategoriInfo 
{
			
    private int _id;

	public int ID
	{
		get { return _id;}
		set { _id = value;}
	}
    private int _seviye;

    public int SEVIYE
    {
        get { return _seviye; }
        set { _seviye = value; }
    }

    private int _sayfa;

    public int SAYFA
    {
        get { return _sayfa; }
        set { _sayfa = value; }
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
    
    private DateTime _tarih;

    public DateTime TARIH
    {
        get { return _tarih; }
        set { _tarih = value; }
    }

    private int _ust_id ;

    public int UST_ID
    {
        get { return _ust_id;  }
        set { _ust_id = value; }
    }

    private bool _yayin_durumu;

    public bool YAYIN_DURUMU
    {
        get { return _yayin_durumu; }
        set { _yayin_durumu = value; }
    }
    private bool _liste;

    public bool LISTE
    {
        get { return _liste; }
        set { _liste = value; }
    }

    private string _icon;

    public string ICON
    {
        get { return _icon;  }
        set { _icon = value; }
    }




    public KategoriInfo()
    {

    }

    public KategoriInfo(int id, string adi, string dil, int sayfa, DateTime eklenme_tarih, int ust_id, int seviye,bool liste, bool yayin_durumu, string icon)
    {
        this._id = id;
        this._liste = liste;
        this._sayfa = sayfa;
        this._adi = adi;
        this._seviye = seviye;
        this._tarih = eklenme_tarih;
        this._ust_id = ust_id;
        this._yayin_durumu = yayin_durumu;
        this._icon=icon;
        this._dil = dil;
    }

    public KategoriInfo (SqlDataReader dr)
    {
        this._id = DataReader.GetInt32(dr["urun_kategoriID"]);
        this._seviye = DataReader.GetInt32(dr["seviye"]);
        this._adi = DataReader.GetString(dr["kadi"]);
        this._tarih = DataReader.GetDateTime(dr["eklenme_tarih"]);
        this._icon = DataReader.GetString(dr["icon"]);
        this._yayin_durumu = DataReader.GetBoolean(dr["yayin_durumu"]);
        this._liste = DataReader.GetBoolean(dr["liste"]);
        this._ust_id = DataReader.GetInt32(dr["ust_id"]);
        this._sayfa= DataReader.GetInt32(dr["sayfa"]);
        this._dil = DataReader.GetString(dr["dil"]);
    }
    
	
	
}
