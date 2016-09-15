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
public class UrunAciklamaInfo
{

    private int _urunac_id;

    public int URUNAC_ID
    {
        get { return _urunac_id; }
        set { _urunac_id = value; }
    }

    private int _urun_ID;

    public int URUN_ID
    {
        get { return _urun_ID; }
        set { _urun_ID = value; }
    }
    private string _aciklama;
    public string ACIKLAMA
    {
        get { return _aciklama; }
        set { _aciklama = value; }
    
    }

    private string _dil;
    public string DIL
    {
        get { return _dil; }
        set { _dil = value; }
    }


    public UrunAciklamaInfo()
    {

    }

    public UrunAciklamaInfo(int id,int urun_id,string aciklama,string dil)
    {

        this._urunac_id = id;
        this._urun_ID = urun_id;
        this._aciklama = aciklama;
        this._dil = dil;




    }



    public UrunAciklamaInfo(SqlDataReader dr)
    {
        this._urun_ID = DataReader.GetInt32(dr["urun_ID"]);
        this._dil= DataReader.GetString(dr["dil"]);        
        this._aciklama= DataReader.GetString(dr["aciklama"]);
        this._urunac_id = DataReader.GetInt32(dr["urunac_id"]);
       
}

     




	
	
}
