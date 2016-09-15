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


public class ParaInfo
{
			
    private int _paraId;

	public int PARAID
	{
        get { return _paraId; }
        set { _paraId = value; }
	}

    private string _para_birim;
    
    public string PARA_BIRIM
    {
        get { return _para_birim; }
        set { _para_birim = value; }
    }

    


    public ParaInfo()
    {

    }

    public ParaInfo(int paraId, string para_birim)
    {
        this._paraId = paraId;
        this._para_birim = para_birim;
        
    }



    public ParaInfo(SqlDataReader dr)
    {
        this._paraId = DataReader.GetInt32(dr["paraId"]);
        this._para_birim = DataReader.GetString(dr["para_birim"]);
        
    }






	
	
}
