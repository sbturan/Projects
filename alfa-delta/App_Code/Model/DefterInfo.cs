using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Data.SqlClient;

[Serializable]
public class DefterInfo
{
    #region Member Variables
    private int       _id;
    private string    _konu;
    private string    _aciklama;
    private DateTime  _tarih;
    private string    _email;
    private int       _kullanici_id;
    private string    _dil;
    private string    _adi;
    private string    _soyadi;
    private int       _yayin_durumu;
      
    
    #endregion

    #region Constructors
    public DefterInfo() { }

    public DefterInfo(int id, 
                      string konu, 
                      string aciklama, 
                      DateTime tarih, 
                      string email,   
                      int kullanici_id, 
                      string dil, 
                      string adi, 
                      string soyadi, 
                      int yayin_durumu)
    {
        this._id = id;
        this._konu = konu;
        this._aciklama =aciklama;
        this._tarih = tarih;
        this._email = email;
        this._kullanici_id = kullanici_id;
        this._dil = dil;
        this._adi = adi;
        this._soyadi = soyadi;
        this._yayin_durumu = yayin_durumu;
      
    }

    public DefterInfo(SqlDataReader dr)
    {
        this._id = DataReader.GetInt32(dr["id"]);
        
        if (DataReader.GetString(dr["dil"]) == "ru") 
        this._aciklama = DataReader.GetString(dr["ru_aciklama"]);
        else
        this._aciklama = DataReader.GetString(dr["aciklama"]);

        if (DataReader.GetString(dr["dil"]) == "ru")
        this._konu = DataReader.GetString(dr["ru_konu"]);
        else
        this._konu = DataReader.GetString(dr["konu"]);

        this._tarih = DataReader.GetDateTime(dr["tarih"]);
        this._dil = DataReader.GetString(dr["dil"]);
        

        this._adi = DataReader.GetString(dr["adi"]);
        this._soyadi = DataReader.GetString(dr["soyadi"]);
        this._kullanici_id = DataReader.GetInt32(dr["kullanici_id"]);
        this._yayin_durumu = DataReader.GetInt32(dr["yayin_durumu"]);
        this._email = DataReader.GetString(dr["email"]);

     
    }
    #endregion

    #region Properties
    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }
    public string KONU
    {
        get { return _konu; }
        set { _konu = value; }
    }

    public string EMAIL
    {
        get { return _email; }
        set { _email = value; }
    }

    public string ACIKLAMA
    {
        get { return _aciklama; }
        set { _aciklama = value; }
    }

    public DateTime TARIH
    {
        get { return _tarih; }
        set { _tarih = value; }
    }
    public int KULLANICI_ID
    {
        get { return _kullanici_id; }
        set { _kullanici_id = value; }
    }
    
    public string DIL
    {
        get { return _dil; }
        set { _dil = value; }
    }
    public string ADI
    {
        get { return _adi; }
        set { _adi = value; }
    }
    
    public string SOYADI
    {
        get { return _soyadi; }
        set { _soyadi = value; }
    }

    public int YAYIN_DURUMU
    {
        get { return _yayin_durumu; }
        set { _yayin_durumu = value; }
    }

   
    #endregion
}
