using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Data.SqlClient;

/// <summary>
/// Summary description for usrRolInfo
/// </summary>
public class usrRolInfo
{
	public usrRolInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private int _rolID;
    private string _rolAd;
    private string _rolTanim;
    private bool _Yonetilebilir;

    public int rolID { get { return _rolID; } set { _rolID = value; } }
    public string rolAd { get { return _rolAd; } set { _rolAd = value; } }
    public string rolTanim { get { return _rolTanim; } set { _rolTanim = value; } }
    public bool Yonetilebilir { get { return _Yonetilebilir; } set { _Yonetilebilir = value; } }

    public usrRolInfo(SqlDataReader dr)
    {
        this._rolID = DataReader.GetInt32(dr["rolID"]);
        this._rolAd = DataReader.GetString(dr["rolAd"]);
        this._rolTanim = DataReader.GetString(dr["rolTanim"]);
        this._Yonetilebilir = DataReader.GetBoolean(dr["Yonetilebilir"]);
    }

    public usrRolInfo(int rolID, string rolAd, string rolTanim, bool Yonetilebilir)
    {
        this._rolID = rolID;
        this._rolAd = rolAd;
        this._rolTanim = rolTanim;
        this._Yonetilebilir = Yonetilebilir;
    }
}
