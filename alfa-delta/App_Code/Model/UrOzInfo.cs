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
public class UrOzInfo
{
			
    private int _urunoz_id;

	public int URUNOZ_ID
	{
        get { return _urunoz_id; }
        set { _urunoz_id = value; }
	}

    private string _dil;




    public string DIL
    {
        get { return _dil; }
        set { _dil = value; }
    }

    private string _ozellik_adi;
    public string OZELLIK_ADI
    {
        get { return _ozellik_adi; }
        set { _ozellik_adi = value; }
    }




    public UrOzInfo()
    {

    }

    public UrOzInfo(int urunoz_id, string dil,string ozellik_adi)
    {
        this._urunoz_id =urunoz_id;
        this._dil = dil;
        this._ozellik_adi = ozellik_adi;
       
    }



    public UrOzInfo(SqlDataReader dr)
    {
        this._urunoz_id = DataReader.GetInt32(dr["urunoz_id"]);
        this._dil = DataReader.GetString(dr["dil"]);
        this._ozellik_adi = DataReader.GetString(dr["ozellik_adi"]);
    }






	
	
}
