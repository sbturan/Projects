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
public class KargoInfo
{

    private int  _id;

    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }
   
   private string _kargo_adi;
       public string KARGO
       {
        get { return _kargo_adi; }
        set { _kargo_adi = value; }
       
       
       }
    private string _takip_no;
       public string TAKIP
       {
        get { return _takip_no; }
        set { _takip_no = value; }
       
       
       }
   


    public KargoInfo()
    {

    }

    public KargoInfo(int id,string kargo_adi,string takip_no)
    {
        this._id = id;
       
        this._kargo_adi=kargo_adi;
        this._takip_no=takip_no;
       
    }



    public KargoInfo(SqlDataReader dr)
    {
        this._id = DataReader.GetInt32(dr["detay_id"]);
        this._kargo_adi = DataReader.GetString(dr["kargo_ad"]);
        this._takip_no = DataReader.GetString(dr["takip_no"]);
    }








}
