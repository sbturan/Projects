using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Data.SqlClient;

[Serializable]
public class MenuDoldurInfo
{
    #region Member Variables
    private int _id;
    private string _ad;
    #endregion
    public MenuDoldurInfo()
	{	}
      #region Constructors
    public MenuDoldurInfo(int id, string ad)
    {
        this._id = id;
        this._ad = ad;
    
    }
    public MenuDoldurInfo(SqlDataReader dr)
    {
        this._id = DataReader.GetInt32(dr["menu_ID"]);
        this._ad = DataReader.GetString(dr["adi"]);
       
     
    }
    #endregion
    #region Properties
    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }
    public string AD
    {
        get { return _ad; }
        set { _ad = value; }
    }
    

 #endregion
}
