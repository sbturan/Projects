using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Data.SqlClient;

/// <summary>
/// Summary description for usrRelUserIzinInfo
/// </summary>
public class usrRelUserIzinInfo
{
	public usrRelUserIzinInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int _relID;
    private int _kullaniciID;
    private int _refID;
    private int _refTip;

    public int relID { get{return _relID;} set{_relID=value;} }
    public int kullaniciID { get { return _kullaniciID; } set { _kullaniciID = value; } }
    public int refID { get { return _refID; } set { _refID = value; } }
    public int refTip { get { return _refTip; } set { _refTip = value; } }

    public usrRelUserIzinInfo(SqlDataReader dr)
    {
        this._relID = DataReader.GetInt32(dr["relID"]);
        this._kullaniciID = DataReader.GetInt32(dr["kullaniciID"]);
        this._refID = DataReader.GetInt32(dr["refID"]);
        this._refTip = DataReader.GetInt32(dr["refTip"]);
    }
}
