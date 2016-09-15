using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Data.SqlClient;

/// <summary>
/// Summary description for GorselInfo
/// </summary>
public class GorselInfo
{
    #region Member Variables
    private int _id;
    private string _dosya;
    private string _k_foto;
    private string _konu;
    private int _dosya_id;
    private DateTime _eklemetarihi;
    private int _tip_id;
    private int _ust_id;
    private int _k_foto_id;
    private int _yayin_durumu;
    private int _tur;
    private string _yayin_yeri;
    private string _dil;
    private int _master_id;
    private int _ekleyen;
    #endregion
    
      #region Constructors
    public GorselInfo() { }

    public GorselInfo(int id, 
                      string dosya, 
                      string k_foto,
                      string konu,  
                      int dosya_id, 
                      DateTime eklemetarihi, 
                      int tip_id, 
                      int ust_id, 
                      int k_foto_id, 
                      int yayin_durumu, 
                      int tur,
                      string yayin_yeri,
                      string dil,
                      int master_id,
                      int ekleyen)
    {
        this._id= id;
        this._dosya = dosya;
        this._k_foto = k_foto;
        this._konu = konu;
        this._dosya_id=dosya_id;
        this._eklemetarihi = eklemetarihi;
        this._tip_id = tip_id;
        this._ust_id = ust_id;
        this._k_foto_id = k_foto_id;
        this._yayin_durumu = yayin_durumu;
        this._tur= tur;
        this._yayin_yeri=yayin_yeri;
        this._dil = dil;
        this._master_id = master_id;
        this._ekleyen = ekleyen;
    }
    #endregion Constructors

    public GorselInfo(SqlDataReader dr)
    {
        this._id = DataReader.GetInt32(dr["id"]);
        this._dosya = DataReader.GetString(dr["dosya"]);
        this._k_foto = DataReader.GetString(dr["k_foto"]);

        if( DataReader.GetString(dr["dil"]) =="ru")
        this._konu = DataReader.GetString(dr["ru_konu"]);
        
        else
        this._konu = DataReader.GetString(dr["konu"]);

        this._dosya_id = DataReader.GetInt32(dr["dosya_id"]);
        this._eklemetarihi= DataReader.GetDateTime(dr["eklemetarihi"]);
        this._tip_id = DataReader.GetInt32(dr["tip_id"]);
        this._ust_id = DataReader.GetInt32(dr["ust_id"]);
        this._k_foto_id = DataReader.GetInt32(dr["k_foto_id"]);
        this._yayin_durumu = DataReader.GetInt32(dr["yayin_durumu"]);
        this._tur = DataReader.GetInt32(dr["tur"]);
        this._yayin_yeri = DataReader.GetString(dr["yayin_yeri"]);
        this._dil = DataReader.GetString(dr["dil"]);
        this._master_id = DataReader.GetInt32(dr["master_id"]);
        this._ekleyen = DataReader.GetInt32(dr["ekleyen"]);
     
    }

    #region Properties
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

    public string K_FOTO
    {
        get { return _k_foto; }
        set { _k_foto = value; }
    }

    public string KONU
    {
        get { return _konu; }
        set { _konu = value; }
    }

    public int DOSYA_ID
    {
        get { return _dosya_id; }
        set { _dosya_id = value; }
    }

    public int MASTER_ID
    {
        get { return _master_id; }
        set { _master_id = value; }
    }


    public DateTime EKLEMETARIHI
    {
        get { return _eklemetarihi; }
        set { _eklemetarihi = value; }
    }
    
    public int TIP_ID
    {
        get { return _tip_id; }
        set { _tip_id = value; }
    }

    public int UST_ID
    {
        get { return _ust_id; }
        set { _ust_id = value; }
    }

    public int K_FOTO_ID
    {
        get { return _k_foto_id; }
        set { _k_foto_id = value; }
    }   

    public int YAYIN_DURUMU
    {
        get { return _yayin_durumu; }
        set { _yayin_durumu = value; }
    }

    public int TUR
    {
        get { return _tur; }
        set { _tur = value; }
    }

    public string YAYIN_YERI
    {
        get { return _yayin_yeri; }
        set { _yayin_yeri = value; }
    }

    public string DIL
    {
        get { return _dil; }
        set { _dil = value; }
    }

    public int EKLEYEN
    {
        get { return _ekleyen; }
        set { _ekleyen = value; }
    }
  
    #endregion


}
