using System;
using System.Data;
using System.Data.SqlClient;
 
[Serializable]
	public class FlashUrunlerInfo
	{
public FlashUrunlerInfo() { }
private int _ID;
public int ID
{
get {return this._ID;}
set {this._ID=value;}
}
 
private string _UrunIsim;
public string UrunIsim
{
get {return this._UrunIsim;}
set {this._UrunIsim=value;}
}
 
private string _UrunResim;
public string UrunResim
{
get {return this._UrunResim;}
set {this._UrunResim=value;}
}
 
private string _UrunLink;
public string UrunLink
{
get {return this._UrunLink;}
set {this._UrunLink=value;}
}
 
private int _Sira;
public int Sira
{
get {return this._Sira;}
set {this._Sira=value;}
}
 
private int _YayinDurumu;
public int YayinDurumu
{
get {return this._YayinDurumu;}
set {this._YayinDurumu=value;}
}
 
private string _Dil;
public string Dil
{
get {return this._Dil;}
set {this._Dil=value;}
}
 
public FlashUrunlerInfo(int ID,string UrunIsim,string UrunResim,string UrunLink,int Sira,int YayinDurumu,string Dil)
{
this._ID=ID;this._UrunIsim=UrunIsim;this._UrunResim=UrunResim;this._UrunLink=UrunLink;this._Sira=Sira;this._YayinDurumu=YayinDurumu;this._Dil=Dil;
}
 
public FlashUrunlerInfo(SqlDataReader dr)
{
this._ID=DataReader.GetInt32(dr["ID"]);this._UrunIsim=DataReader.GetString(dr["UrunIsim"]);this._UrunResim=DataReader.GetString(dr["UrunResim"]);this._UrunLink=DataReader.GetString(dr["UrunLink"]);this._Sira=DataReader.GetInt32(dr["Sira"]);this._YayinDurumu=DataReader.GetInt32(dr["YayinDurumu"]);this._Dil=DataReader.GetString(dr["Dil"]);
}
 
}
