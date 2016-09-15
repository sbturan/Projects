using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Data.SqlClient;

/// <summary>
/// Summary description for GorselInfo
/// </summary>
public class GaleriInfo
{
    #region Member Variables

    private int _resim_id;
    private string _resim; 
    
    
    private int _urun_id;
   
    private int _yayin_durumu;      
   
    #endregion
    
      #region Constructors
    public GaleriInfo() { }

    public GaleriInfo(int resim_id, 
                      string resim, 
                      int urun_id,
                      int yayin_durumu
        )
    {
        this._resim_id= resim_id;
        this._resim = resim;
        this._urun_id = urun_id;
        
        this._yayin_durumu = yayin_durumu;
    }
    #endregion Constructors

    public GaleriInfo(SqlDataReader dr)
    {
        this._resim_id = DataReader.GetInt32(dr["resim_id"]);
        this._resim = DataReader.GetString(dr["resim"]);
       
        this._urun_id = DataReader.GetInt32(dr["urun_id"]);
        this._yayin_durumu = DataReader.GetInt32(dr["yayin_durumu"]);
     
    }

    #region Properties
    public int RESIMID
    {
        get { return _resim_id; }
        set { _resim_id = value; }
    }

    public string RESIM
    {
        get { return _resim; }
        set { _resim = value; }
    }
    public int URUNID
    {
        get { return _urun_id; }
        set { _urun_id = value; }
    }


    
 public int YAYIN_DURUMU
    {
        get { return _yayin_durumu; }
        set { _yayin_durumu = value; }
    }

  
    #endregion


}
