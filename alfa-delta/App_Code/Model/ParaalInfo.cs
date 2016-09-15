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

/// 
public class ParaalInfo
{

    private int  _id;

    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }
    private float _euroA;

    public float EUROA
    {
        get { return _euroA; }
        set { _euroA = value; }
    }
    public float _euroS;
    public float EUROS 
    {
        get { return _euroS; }
        set { _euroS = value; }
    
    }
    public float _dolarA;
    public float DOLARA
    {
        get { return _dolarA; }
        set { _dolarA = value; }

    }



    
    private float _dolarS;

    public float DOLARS
    {
        get { return _dolarS; }
        set { _dolarS = value; }
    }
    private int _kontrol;

    public int KONTROL
    {
        get { return _kontrol; }
        set { _kontrol = value; }
    }


    public ParaalInfo()
    {

    }

    public ParaalInfo(int id,float dolarS,float dolarA,float euroA,float euroS, int kontrol)
    {
        this._id = id;
        this._euroA= euroA;
        this._euroS = euroS;
        this._dolarS = dolarS;
        this._dolarA = dolarA;
        this._kontrol = kontrol;
       
    }



    public ParaalInfo(SqlDataReader dr)
    {
        this._id = DataReader.GetInt32(dr["id"]);
        this._kontrol = DataReader.GetInt32(dr["kontrol"]);
        this._euroA = DataReader.GetFloat(dr["euroA"]);
        this._euroS = DataReader.GetFloat(dr["euroS"]);
        this._dolarA = DataReader.GetFloat(dr["dolarA"]);
        this._dolarS = DataReader.GetFloat(dr["dolarS"]);
    }








}
