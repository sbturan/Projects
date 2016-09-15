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

/// 
public class LogInfo
{

    private int _id;

    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }
    private int _kid;

    public int KID
    {
        get { return _kid; }
        set { _kid = value; }
    }
    public string _ad;
    public string AD 
    {
        get { return _ad; }
        set { _ad = value; }
    
    }
    public string _soyad;
    public string SOYAD
    {
        get { return _soyad; }
        set { _soyad = value; }

    }



    private string _browser;

    public string BROWSER
    {
        get { return _browser; }
        set { _browser = value; }
    }


    private string _ip;

    public string IP
    {
        get { return _ip; }
        set { _ip = value; }
    }




    private DateTime _islem_saati;

    public DateTime ISLEM_SAATI
    {
        get { return _islem_saati; }
        set { _islem_saati = value; }
    }

    private int _aksiyon;

    public int AKSIYON
    {
        get { return _aksiyon; }
        set { _aksiyon = value; }
    }



    public LogInfo()
    {

    }

    public LogInfo(int id,string ad,string soyad, int kid, string browser, string ip, DateTime islem_saati, int aksiyon)
    {
        this._id = id;
        this._kid = kid;
        this._browser = browser;
        this._ip = ip;
        this._islem_saati = islem_saati;
        this._aksiyon = aksiyon;
        this._ad = ad;
        this._soyad = soyad;
    }



    public LogInfo(SqlDataReader dr)
    {
        this._id = DataReader.GetInt32(dr["log_id"]);
        this._kid = DataReader.GetInt32(dr["kullaniciID"]);
        this._browser = DataReader.GetString(dr["Browser"]);
        this._ip = DataReader.GetString(dr["IP"]);
        this._soyad = DataReader.GetString(dr["KullaniciSoyad"]);
        this._ad = DataReader.GetString(dr["KullaniciAdi"]);
        this._islem_saati = DataReader.GetDateTime(dr["islem_saati"]);
        this._aksiyon = DataReader.GetInt32(dr["aksiyon"]);
       
    }








}
