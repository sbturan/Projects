using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Data.SqlClient;

/// <summary>
/// Summary description for GorselInfo
/// </summary>
public class DosyaInfo
{
    #region Member Variables
    private int _id;
    private string _dosya;
    private int _tur;
    private DateTime _tarih;
    private string _adi;
    
    #endregion
    
      #region Constructors
    public DosyaInfo() { }

    public DosyaInfo(int id, 
                     string dosya, 
                     int tur,
                     DateTime tarih,
                     string adi
                     )
    {
        this._id= id;
        this._dosya = dosya;
        this._tur= tur;
        this._tarih = tarih;
        this._adi = adi;
        
    }
    #endregion Constructors

    public DosyaInfo(SqlDataReader dr)
    {
        this._id = DataReader.GetInt32(dr["id"]);
        this._dosya = DataReader.GetString(dr["dosya"]);
        this._tur = DataReader.GetInt32(dr["tur"]);
        this._tarih = DataReader.GetDateTime(dr["tarih"]);
        this._adi = DataReader.GetString(dr["adi"]);

     
    }

    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }

    public string DOSYA
    {
        get { return _dosya; }
        set { _dosya = value; }
    }

    public int TUR
    {
        get { return _tur; }
        set { _tur = value; }
    }

    public DateTime TARIH
    {
        get { return _tarih; }
        set { _tarih = value; }
    }

    public string ADI
    {
        get { return _adi; }
        set { _adi = value; }
    }


}
