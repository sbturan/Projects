using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for bannerInfo
/// </summary>
public class ParaUrunInfo
{

    private float _fiyat;

    public float FIYAT
    {
        get { return _fiyat; }
        set { _fiyat = value; }
    }

    private string _para_birim;

    public string PARA_BIRIM
    {
        get { return _para_birim; }
        set { _para_birim = value; }
    }
    public int _para_kontrol;
    public int PARA_KONTROL
    {
        get { return _para_kontrol; }
        set { _para_kontrol = value; }
    }


    public ParaUrunInfo()
    {

    }

    public ParaUrunInfo(float fiyat,string para_birim,int para_kontrol)
    {

        this._para_birim = para_birim;
        this._fiyat = fiyat;
        this._para_kontrol = para_kontrol;

    }



    public ParaUrunInfo(SqlDataReader dr)
    {
        this._para_birim= DataReader.GetString(dr["para_birim"]);

        this._fiyat = DataReader.GetFloat(dr["fiyat"]);

     //   this._para_kontrol = DataReader.GetInt32(dr["para_kontrol"]);

  }






	
	
}
