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
public class MailInfo
{

    private int _id;

    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }
    private int _portnumber;

    public int PORTNUMBER
    {
        get { return _portnumber; }
        set { _portnumber = value; }
    }
    public string _smtp;
    public string SMTP 
    {
        get { return _smtp; }
        set { _smtp = value; }
    
    }
    public string _email;
    public string EMAIL
    {
        get { return _email; }
        set { _email = value; }

    }



    private string _sifre;

    public string SIFRE
    {
        get { return _sifre; }
        set { _sifre = value; }
    }
   


    public MailInfo()
    {

    }

    public MailInfo(int id,string sifre,string email, int portnumber, string smtp)
    {
        this._id = id;
        this._email = email;
        this._sifre = sifre;
        this._portnumber = portnumber;
        this._smtp = smtp;
       
       
    }



    public MailInfo(SqlDataReader dr)
    {
        this._id = DataReader.GetInt32(dr["id"]);
        this._portnumber = DataReader.GetInt32(dr["portnumber"]);
        this._email = DataReader.GetString(dr["email"]);
        this._sifre = DataReader.GetString(dr["sifre"]);
        this._smtp = DataReader.GetString(dr["smtp"]);
        
    }








}
