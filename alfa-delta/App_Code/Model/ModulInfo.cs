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
/// Summary description for ModulInfo
/// </summary>
public class ModulInfo
{
    

    #region Properties
    private int _id;

    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }

    private int _ust_id;

    public int UST_ID
    {
        get { return _ust_id; }
        set { _ust_id = value; }
    }

    private int _seviye;

    public int SEVIYE
    {
        get { return _seviye; }
        set { _seviye = value; }
    }

    private string _modul;

    public string MODUL
    {
        get { return _modul; }
        set { _modul = value; }
    }

    private string _modul_link;

    public string MODUL_LINK
    {
        get { return _modul_link; }
        set { _modul_link = value; }
    }

    private string _modul_aciklama;

    public string MODUL_ACIKLAMA
    {
        get { return _modul_aciklama; }
        set { _modul_aciklama = value; }
    }

    private int _sira;

    public int SIRA
    {
        get { return _sira; }
        set { _sira = value; }
    } 
    #endregion

    #region Constructors
    public ModulInfo()
    {

    }

    public ModulInfo(int id,
                        int ust_id,
                        int seviye,
                        string modul,
                        string modul_link,
                        string modul_aciklama,
                        int sira)
    {
        this._id = id;
        this._ust_id = ust_id;
        this._seviye = seviye;
        this._modul = modul;
        this._modul_link = modul_link;
        this._modul_aciklama = modul_aciklama;
        this._sira = sira;

    } 
    #endregion


    public ModulInfo(SqlDataReader dr)
    {
        this._id = DataReader.GetInt32(dr["id"]);
        this._ust_id = DataReader.GetInt32(dr["ust_id"]);
        this._seviye = DataReader.GetInt32(dr["seviye"]);
        this._modul_link = DataReader.GetString(dr["modul_link"]);
        this._modul_aciklama = DataReader.GetString(dr["modul_aciklama"]);
        this._sira = DataReader.GetInt32(dr["sira"]);

    }


}
