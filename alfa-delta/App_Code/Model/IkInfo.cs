using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Data.SqlClient;

[Serializable]
public class IkInfo
{
    #region Member Variables
    private int _id;
    private string _konu;
    private string _aciklama;
    private DateTime _tarih;
    private string _dil;
    
    private int _yayin_durumu;
    

    #endregion

    #region Constructors
    public IkInfo() { }

    public IkInfo(int id,
                      string konu,
                      string aciklama,
                      DateTime tarih,
                      string dil,
                      
                      int yayin_durumu
                      )
    {
        this._id = id;
        this._konu = konu;
        this._aciklama = aciklama;
        this._tarih = tarih;
        this._dil = dil;
       
        this._yayin_durumu = yayin_durumu;
        
    }

    public IkInfo(SqlDataReader dr)
    {
        this._id = DataReader.GetInt32(dr["id"]);

        if (DataReader.GetString(dr["dil"]) == "ru")
            this._konu = DataReader.GetString(dr["ru_konu"]);
        else
            this._konu = DataReader.GetString(dr["konu"]);


        if (DataReader.GetString(dr["dil"]) == "ru")
            this._aciklama = DataReader.GetString(dr["ru_aciklama"]);
        else
            this._aciklama = DataReader.GetString(dr["aciklama"]);

        this._tarih = DataReader.GetDateTime(dr["tarih"]);
        this._dil = DataReader.GetString(dr["dil"]);
       
        this._yayin_durumu = DataReader.GetInt32(dr["yayin_durumu"]);
      

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

    public string DIL
    {
        get { return _dil; }
        set { _dil = value; }
    }


   
    public int YAYIN_DURUMU
    {
        get { return _yayin_durumu; }
        set { _yayin_durumu = value; }
    }

    
    #endregion
}
