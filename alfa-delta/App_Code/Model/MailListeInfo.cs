using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Data.SqlClient;

[Serializable]
public class MailListeInfo
{
    #region Member Variables
    private int _id;
    private string _adi;
    private string _soyadi;
    private string _email;
    private string _telefon;

    private bool _durum;
    private int _roleid;



    #endregion

    #region Constructors
    public MailListeInfo() { }

    public MailListeInfo(int id,
                       string adi,
                       string soyadi,
                       string email,
                       string telefon,              
                       bool durum,
                      int roleid
        
                       )
    {
        this._id = id;
        this._adi = adi;
        this._soyadi = soyadi;
        this._email = email;
        this._telefon = telefon;
        this._durum = durum;
        this._roleid = roleid;
       
    }

    public MailListeInfo(SqlDataReader dr)
    {
        this._id = DataReader.GetInt32(dr["KullaniciID"]);
        this._adi = DataReader.GetString(dr["KullaniciAdi"]);
        this._soyadi = DataReader.GetString(dr["KullaniciSoyad"]);
        this._email = DataReader.GetString(dr["Email"]);
        this._telefon = DataReader.GetString(dr["TelNo"]);
        this._durum = DataReader.GetBoolean(dr["Durum"]);
        this._roleid = DataReader.GetInt32(dr["roleID"]);
      
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

   

    public string EMAIL
    {
        get { return _email; }
        set { _email = value; }
    }

   

   

    public bool DURUM
    {
        get { return _durum; }
        set { _durum = value; }
    }
    public int ROLEID
    {
        get { return _roleid; }
        set { _roleid = value; }
    }

    
    
    #endregion
}