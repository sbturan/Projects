using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Data.SqlClient;

[Serializable]
public class IlceInfo
{
    #region Member Variables
    private int _ilce_id;
    private int _il_id;
    private string _ilce_ad;

        
    #endregion

    #region Constructors
    public IlceInfo() { }

    public IlceInfo(int id,string ilcead, int ilid)
    {
        this._ilce_id = id;
        this._ilce_ad = ilcead;
        _il_id = ilid;
              
    }

    public IlceInfo(SqlDataReader dr)
    {
        this._ilce_id = DataReader.GetInt32(dr["IlceID"]);
        this._il_id = DataReader.GetInt32(dr["IlID"]);
        this._ilce_ad = DataReader.GetString(dr["Ad"]);
        
    }
    #endregion

    #region Properties
    public int IlceID
    {
        get { return _ilce_id; }
        set { _ilce_id = value; }
    }
    public string ILCEAD
    {
        get { return _ilce_ad; }
        set { _ilce_ad = value; }
    }
    public int IlID
    {
        get { return _il_id; }
        set { _il_id = value; }
    }
    #endregion
}
