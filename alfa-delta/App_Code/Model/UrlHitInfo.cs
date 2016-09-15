using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Data.SqlClient;

/// <summary>
/// Summary description for GorselInfo
/// </summary>
public class UrlHitInfo
{
    #region Member Variables
    private int _id;
    private string _sayfa_ismi;
    private string _url;
    private string _remote_ip;
    private string _oturum;
    private DateTime _tarih;
    private string _dil;
    private string _cozunurluk;
    private string _browser;
    
    #endregion
    
      #region Constructors
    public UrlHitInfo() { }

    public UrlHitInfo(int id, 
                      string sayfa_ismi, 
                      string url,
                      string remote_ip,
                      string oturum,
                      DateTime tarih,
                      string dil, 
                      string cozunurluk ,
                      string browser 
                      
                     )
    {
        this._id= id;
        this._url = url;
        this._remote_ip= remote_ip;
        this._oturum=oturum;
        this._tarih=tarih;
        this._dil = dil;
        this._cozunurluk = cozunurluk;
        this._browser = browser;
        
    }
    #endregion Constructors

    public UrlHitInfo(SqlDataReader dr)
    {
        this._id = DataReader.GetInt32(dr["id"]);
        this._url = DataReader.GetString(dr["url"]);
        this._remote_ip = DataReader.GetString(dr["remote_ip"]);
        this._oturum = DataReader.GetString(dr["oturum"]);
        this._tarih = DataReader.GetDateTime(dr["tarih"]);
        this._dil = DataReader.GetString(dr["dil"]);
        this._cozunurluk = DataReader.GetString(dr["cozunurluk"]);
        this._browser = DataReader.GetString(dr["browser"]);
     
    }

    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }

    public string URL
    {
        get { return _url; }
        set { _url = value; }
    }

    public string REMOTE_IP
    {
        get { return _remote_ip; }
        set { _remote_ip = value; }
    }

    public string SAYFA_ISMI
    {
        get { return _sayfa_ismi; }
        set { _sayfa_ismi = value; }
    }

    public string OTURUM
    {
        get { return _oturum; }
        set { _oturum = value; }
    }

    public DateTime TARIH
    {
        get { return _tarih; }
        set { _tarih = value; }
    }

    public string DIL
    {
        get { return _dil; }
        set { _dil = value; }
    }

    public string COZUNURLUK
    {
        get { return _cozunurluk; }
        set { _cozunurluk = value; }
    }

    public string BROWSER
    {
        get { return _browser; }
        set { _browser = value; }
    }

}
