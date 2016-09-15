using System;
using System.Data;
using System.Data.SqlClient;
 
[Serializable]
	public class UserRolesInfo
	{
public UserRolesInfo() { }
private int _UserID;
public int UserID
{
get {return this._UserID;}
set {this._UserID=value;}
}
 
private int _RoleID;
public int RoleID
{
get {return this._RoleID;}
set {this._RoleID=value;}
}
 
private int _tabloID;
public int tabloID
{
get {return this._tabloID;}
set {this._tabloID=value;}
}
 
public UserRolesInfo(int UserID,int RoleID,int tabloID)
{
this._UserID=UserID;this._RoleID=RoleID;this._tabloID=tabloID;
}
 
public UserRolesInfo(SqlDataReader dr)
{
this._UserID=DataReader.GetInt32(dr["UserID"]);this._RoleID=DataReader.GetInt32(dr["RoleID"]);this._tabloID=DataReader.GetInt32(dr["tabloID"]);
}
 
}
