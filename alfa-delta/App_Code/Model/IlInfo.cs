using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Data.SqlClient;

[Serializable]
public class IlInfo
{
    #region Member Variables
    private int _il_id;
   private string _il_ad;




    
    #endregion

    #region Constructors
    public IlInfo() { }

    public IlInfo(int id,string ilad)
    {
        this._il_id = id;
        this._il_ad = ilad;      
              
    }

    public IlInfo(SqlDataReader dr)
    {
        this._il_id = DataReader.GetInt32(dr["IlID"]);
        this._il_ad = DataReader.GetString(dr["Ad"]);
        
    }
    #endregion

    #region Properties
    public int ILID
    {
        get { return _il_id; }
        set { _il_id = value; }
    }
    public string ILAD
    {
        get { return _il_ad; }
        set { _il_ad = value; }
    }

    #endregion
}
