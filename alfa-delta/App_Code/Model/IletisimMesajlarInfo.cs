using System;
using System.Data;
using System.Data.SqlClient;
 
[Serializable]
	public class IletisimMesajlarInfo
	{
public IletisimMesajlarInfo() { }
private int _ID;
public int ID
{
get {return this._ID;}
set {this._ID=value;}
}
 
private string _Ad;
public string Ad
{
get {return this._Ad;}
set {this._Ad=value;}
}
 
private string _SoyAd;
public string SoyAd
{
get {return this._SoyAd;}
set {this._SoyAd=value;}
}
 
private string _Email;
public string Email
{
get {return this._Email;}
set {this._Email=value;}
}
 
private string _IletimMesaj;
public string IletimMesaj
{
get {return this._IletimMesaj;}
set {this._IletimMesaj=value;}
}
 
private DateTime _EklemeTarihi;
public DateTime EklemeTarihi
{
get {return this._EklemeTarihi;}
set {this._EklemeTarihi=value;}
}
 
private string _EkleyenIP;
public string EkleyenIP
{
get {return this._EkleyenIP;}
set {this._EkleyenIP=value;}
}
 
public IletisimMesajlarInfo(int ID,string Ad,string SoyAd,string Email,string IletimMesaj,DateTime EklemeTarihi,string EkleyenIP)
{
this._ID=ID;
this._Ad=Ad;
this._SoyAd=SoyAd;
this._Email=Email;
this._IletimMesaj=IletimMesaj;
this._EklemeTarihi=EklemeTarihi;
this._EkleyenIP=EkleyenIP;

}
 
public IletisimMesajlarInfo(SqlDataReader dr)
{
this._ID=DataReader.GetInt32(dr["ID"]);
this._Ad=DataReader.GetString(dr["Ad"]);
this._SoyAd=DataReader.GetString(dr["SoyAd"]);
this._Email=DataReader.GetString(dr["Email"]);
this._IletimMesaj=DataReader.GetString(dr["IletimMesaj"]);
this._EklemeTarihi=DataReader.GetDateTime(dr["EklemeTarihi"]);
this._EkleyenIP=DataReader.GetString(dr["EkleyenIP"]);

}
 
}
