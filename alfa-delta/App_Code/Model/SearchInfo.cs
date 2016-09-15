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
/// Summary description for SearchInfo
/// </summary>
public class SearchInfo
{

    #region Member Variables
    private int _PageID;

    public int PAGE_ID
    {
        get { return _PageID; }
        set { _PageID = value; }
    }

    private string _PageAdi;

    public string PAGE_ADI
    {
        get { return _PageAdi; }
        set { _PageAdi = value; }
    }

    private string _PageAciklama;

    public string PAGE_ACIKLAMA
    {
        get { return _PageAciklama; }
        set { _PageAciklama = value; }
    }

    private int _BolumID;

    public int BOLUM_ID
    {
        get { return _BolumID; }
        set { _BolumID = value; }
    }
    #endregion

    #region Constructors
    public SearchInfo(int PageID, string PageAdi, string PageAciklama, int BolumID)
    {
        this._PageID = PageID;
        this._PageAdi = PageAdi;
        this._PageAciklama = PageAciklama;
        this._BolumID = BolumID;
    }

    public SearchInfo()
    {

    }  
    #endregion

    public SearchInfo(SqlDataReader dr)
    {
        this._PageID = DataReader.GetInt32(dr["id"]);
        this._PageAdi = DataReader.GetString(dr["konu"]);
        this._PageAciklama = DataReader.GetString(dr["aciklama"]);
        this._BolumID = DataReader.GetInt32(dr["tip_id"]);
    }	

	
}
