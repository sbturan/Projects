using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Data.SqlClient;

[Serializable]
public class SemtInfo
{
    #region Member Variables
    private int _semt_id;
    private string _semt_ad;
    private int _ilce_id;
    
    #endregion

    #region Constructors
    public SemtInfo() { }

    public SemtInfo(int semtid,string semtad,int ilceid)
    {
        this._semt_id = semtid;
        this._semt_ad = semtad;
        this._ilce_id = ilceid;
              
    }

    public SemtInfo(SqlDataReader dr)
    {
        this._semt_id = DataReader.GetInt32(dr["SemtID"]);
        this._semt_ad = DataReader.GetString(dr["Ad"]);
        this._ilce_id = DataReader.GetInt32(dr["IlceID"]);
    }
    #endregion

    #region Properties
    public int SEMTID
    {
        get { return _semt_id; }
        set { _semt_id = value; }
    }
    public int ILCEID
    {
        get { return _ilce_id; }
        set { _ilce_id = value; }
    }
    public string SEMTAD
    {
        get { return _semt_ad; }
        set { _semt_ad = value; }
    }

    #endregion
}
