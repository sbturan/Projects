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


public class Urun1Info
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

     
    
    private DateTime _tarih;

    public DateTime TARIH
    {
        get { return _tarih; }
        set { _tarih = value; }
    }

    private int _ktg_id ;

    public int KTG_ID
    {
        get { return _ktg_id;  }
        set { _ktg_id = value; }
    }
    private int _mrk_id;

    public int MRK_ID
    {
        get { return _mrk_id; }
        set { _mrk_id = value; }
    }
    private int _stok_miktar;

    public int STOK_MIKTAR
    {
        get { return _stok_miktar; }
        set { _stok_miktar = value; }
    }
    private int _kritik_stokmiktar;

    public int KRITIK_STOKMIKTAR
    {
        get { return _kritik_stokmiktar; }
        set { _kritik_stokmiktar = value; }
    }

    private int _indirim;

    public int INDIRIM
    {
        get { return _indirim; }
        set { _indirim = value; }
    }
    private bool _yayin_durumu;

    public bool YAYIN_DURUMU
    {
        get { return _yayin_durumu; }
        set { _yayin_durumu = value; }
    }
    private int _para_birimi;

    public int PARA_BIRIMI
    {
        get { return _para_birimi; }
        set { _para_birimi = value; }
    }
    private float _fiyat;

    public float FIYAT
    {
        get { return _fiyat; }
        set { _fiyat = value; }
    }
    private float _kdv_orani;

    public float KDV_ORANI
    {
        get { return _kdv_orani; }
        set { _kdv_orani = value; }
    }

    private string _icon;

    public string ICON
    {
        get { return _icon;  }
        set { _icon = value; }
    }

    private string _marka;

    public string MARKA
    {
        get { return _marka; }
        set { _marka = value; }
    }

    private string _ktg;

    public string KTG
    {
        get { return _ktg; }
        set { _ktg = value; }
    }

    private string _pdf;

    public string PDF
    {
        get { return _pdf; }
        set { _pdf = value; }
    }
    
    
    
    
    
    private string _dil;

    public string DIL
    {
        get { return _dil; }
        set { _dil = value; }
    }



    public Urun1Info()
    {

    }

    public Urun1Info(int id, float fiyat, string ktg,string pdf, string marka, string adi, float kdv_orani, DateTime eklenme_tarih, string dil, int para_birimi, int kritik_stokmiktar, int indirim, int ktg_id, int seviye, bool yayin_durumu, string icon, int mrk_id, int stok_miktar)
    {
        this._ktg = ktg;
        this._marka = marka;
        this._id = id;
        this._pdf = pdf;
        this._indirim = indirim;
        this._para_birimi = para_birimi;
        this._adi = adi;
        this._mrk_id = mrk_id;
        this._tarih = eklenme_tarih;
        this._ktg_id = ktg_id;
        this._yayin_durumu = yayin_durumu;
        this._icon=icon;
        this._stok_miktar = stok_miktar;
        this._kritik_stokmiktar = kritik_stokmiktar;
        this._dil = dil;
        this._fiyat = fiyat;
        this._kdv_orani = kdv_orani;
    }
   
    public Urun1Info(SqlDataReader dr)
    {
        this._id = DataReader.GetInt32(dr["urun_id"]);

        this._adi = DataReader.GetString(dr["adi"]);
     
        this._ktg = DataReader.GetString(dr["kadi"]);
        this._pdf = DataReader.GetString(dr["pdf"]);
   
        this._tarih = DataReader.GetDateTime(dr["eklenme_tarih"]);
        this._icon = DataReader.GetString(dr["icon"]);
        this._dil = DataReader.GetString(dr["dil"]);
        this._yayin_durumu = DataReader.GetBoolean(dr["yayin_durumu"]);
        this._ktg_id = DataReader.GetInt32(dr["ktg_id"]);
       
    }
    
	
	
}
