using System;
using System.Data;
using System.Data.SqlClient;

[Serializable]
public class Users1Info
{
    public Users1Info() { }
    private int _Id;
    public int Id
    {
        get { return this._Id; }
        set { this._Id = value; }
    }

    private string _Adi;
    public string Adi
    {
        get { return this._Adi; }
        set { this._Adi = value; }
    }

    private string _Soyadi;
    public string Soyadi
    {
        get { return this._Soyadi; }
        set { this._Soyadi = value; }
    }

    
    private string _Email;
    public string Email
    {
        get { return this._Email; }
        set { this._Email = value; }
    }

    private string _Sifre;
    public string Sifre
    {
        get { return this._Sifre; }
        set { this._Sifre = value; }
    }

    private string _Telefon;
    public string Telefon
    {
        get { return this._Telefon; }
        set { this._Telefon = value; }
    }

    private bool _Durum;
    public bool Durum
    {
        get { return this._Durum; }
        set { this._Durum = value; }
    }

    private int _RoleId;
    public int RoleId 
    {
        get { return this._RoleId; }
        set { this._RoleId = value; }
    }
    private int _para_kontrol;
    public int PARA_KONTROL
    {
        get { return this._para_kontrol; }
        set { this._para_kontrol = value; }
    }
   
    
    public Users1Info(int Id, string Adi, string Soyadi,int para_kontrol, string Email, string Sifre, string Telefon, bool Durum, int RoleId)
    {
        this._Id = Id; this._Adi = Adi; this._Soyadi = Soyadi; this._para_kontrol = para_kontrol; this._Email = Email; this._Sifre = Sifre; this._Telefon = Telefon; this._Durum = Durum; this._RoleId = RoleId; 
    }

    public Users1Info(SqlDataReader dr)
    {
        this._Id = DataReader.GetInt32(dr["KullaniciID"]); this._para_kontrol = DataReader.GetInt32(dr["para_kontrol"]); this._Adi = DataReader.GetString(dr["KullaniciAdi"]); this._Soyadi = DataReader.GetString(dr["KullaniciSoyad"]); this._Email = DataReader.GetString(dr["Email"]); this._Sifre = DataReader.GetString(dr["Sifre"]); this._Telefon = DataReader.GetString(dr["TelNo"]); this._Durum = DataReader.GetBoolean(dr["Durum"]);
    }

}
