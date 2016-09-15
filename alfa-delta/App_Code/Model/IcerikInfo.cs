using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Data.SqlClient;

[Serializable]
public class IcerikInfo
{
    #region Member Variables
    private int _id;
    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }


    private string _konu;
    private string _aciklama;
    private string _dil;
    private bool _yayin_durumu;
    private int _menu_id;
   
    #endregion

    #region Constructors
    public IcerikInfo() { }

    public IcerikInfo(int id,
                      int menu_id,
                      string konu,
                      string aciklama,
                      string dil,                      
                      bool yayin_durumu
                      )
    {
        this._id = id;
        this._menu_id = menu_id;
        this._konu = konu;      
        this._aciklama = aciklama;
        this._dil = dil;
        this._yayin_durumu = yayin_durumu;
              
    }

    public IcerikInfo(SqlDataReader dr)
    {
        this._id = DataReader.GetInt32(dr["id"]);
        _aciklama = DataReader.GetString(dr["aciklama"]);

      
        this._dil = DataReader.GetString(dr["dil"]);

        //if (DataReader.GetString(dr["dil"]) == "ru")
        //    this._konu = DataReader.GetString(dr["ru_konu"]);
        //else
            this._konu = DataReader.GetString(dr["konu"]);
            this._menu_id = DataReader.GetInt32(dr["menu_id"]);
            
        this._yayin_durumu = DataReader.GetBoolean(dr["yayin_durumu"]);
       


    }
    #endregion

  
   
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

    public string DIL
    {
        get { return _dil; }
        set { _dil = value; }
    }
   
    public bool YAYIN_DURUMU
    {
        get { return _yayin_durumu; }
        set { _yayin_durumu = value; }
    }
    public int MENU_ID
    {
        get { return _menu_id; }
        set { _menu_id = value; }
    }
 
 
}
