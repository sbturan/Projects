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
public class KontrolInfo
{

    private int  _id;

    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }
   
   
    private int _kontrol;

    public int KONTROL
    {
        get { return _kontrol; }
        set { _kontrol = value; }
    }


    public KontrolInfo()
    {

    }

    public KontrolInfo(int id,int kontrol)
    {
        this._id = id;
       
        this._kontrol = kontrol;
       
    }



    public KontrolInfo(SqlDataReader dr)
    {
        this._id = DataReader.GetInt32(dr["kid"]);
        this._kontrol = DataReader.GetInt32(dr["kontrol"]);
       
    }








}
