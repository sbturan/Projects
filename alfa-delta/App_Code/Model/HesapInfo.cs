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
public class HesapInfo
{
			
    private int _id;

	public int ID
	{
		get { return _id;}
		set { _id = value;}
	}

    private string _bank_adi;
    
    public string BANK_ADI
    {
        get { return _bank_adi; }
        set { _bank_adi = value; }
    }

    private string _hesap_no;

    public string HESAP_NO
    {
        get { return _hesap_no; }
        set { _hesap_no = value; }
    }

    private string _sube_adi;

    public string SUBE_ADI
    {
        get { return _sube_adi; }
        set { _sube_adi = value; }
    }
    private string _hesap_tur;

    public string HESAP_TUR
    {
        get { return _hesap_tur; }
        set { _hesap_tur = value; }
    }

    private string _iban_no;
    
    public string IBAN_NO
    {
        get { return _iban_no; }
        set { _iban_no = value; }
    }

    


    public HesapInfo()
    {

    }

    public HesapInfo(int id, string bank_adi, string sube_adi, string hesap_no, string iban_no, string hesap_tur  )
    {
        this._id = id;
        this._bank_adi = bank_adi;
        this._sube_adi =sube_adi;
        this._hesap_no = hesap_no;
        this._hesap_tur = hesap_tur;
        this._iban_no = iban_no;
       
    }



    public HesapInfo(SqlDataReader dr)
    {
        this._id = DataReader.GetInt32(dr["id"]);
        this._bank_adi = DataReader.GetString(dr["bank_adi"]);
        this._sube_adi = DataReader.GetString(dr["sube_adi"]);
        this._hesap_no = DataReader.GetString(dr["hesap_no"]);
        this._hesap_tur = DataReader.GetString(dr["hesap_turu"]);
        this._iban_no = DataReader.GetString(dr["iban_no"]);
       
    }






	
	
}
