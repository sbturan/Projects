using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Data.SqlClient;

[Serializable]
public class IkDetayInfo
{
    
    #region Member Variables
    private int _id;
    private string _adi;
    private string _soyadi;
    private string _telefon;
    private string _email;
     private string _dosya;
     private string _soru;



    #endregion

    #region Constructors
    public IkDetayInfo() { }

    public IkDetayInfo(int id,
                       string adi,
                       string soyadi,
                       string telefon,
                       string email,
        string soru,
                        string dosya )
    {
        this._id = id;
        this._adi = adi;
        this._soyadi = soyadi;
        this._telefon = telefon;
        this._email = email;
        this._soru = soru;
        this._dosya = dosya;
        
    }

    public IkDetayInfo(SqlDataReader dr)
    {
        
        this._id = DataReader.GetInt32(dr["id"]);
        
       
            this._adi = DataReader.GetString(dr["adi"]);
            this._soyadi = DataReader.GetString(dr["soyadi"]);
            this._soru = DataReader.GetString(dr["soru"]);
        
        this._email = DataReader.GetString(dr["email"]);
        this._telefon = DataReader.GetString(dr["telefon"]);
        
        this._dosya = DataReader.GetString(dr["dosya"]);
       

    }
    #endregion

    #region Properties
    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }
    public string ADI
    {
        get { return _adi; }
        set { _adi = value; }
    }

   
    public string SOYADI
    {
        get { return _soyadi; }
        set { _soyadi = value; }
    }

    public string TELEFON
    {
        get { return _telefon; }
        set { _telefon = value; }
    }

    public string EMAIL
    {
        get { return _email; }
        set { _email = value; }
    }
    public string SORU
    {
        get { return _soru; }
        set { _soru = value; }
    }
    

    public string DOSYA
    {
        get { return _dosya; }
        set { _dosya = value; }
    }

    #endregion
}