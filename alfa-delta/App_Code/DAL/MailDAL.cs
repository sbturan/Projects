using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Data.SqlClient;


public class MailDAL
{
    public MailDAL()
    {

    }

    




    public MailInfo Getmail()
    {
        List<MailInfo> list = new List<MailInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Getmail") };
        string spName = "MailDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                MailInfo info = new MailInfo(dr);
                return info;
            }

            return null;

        }

    }
   


    public Int32 Insert(MailInfo info)
    {
        SqlParameter[] spParametre = new SqlParameter[] 
        {
            new SqlParameter("@OPERATION", "Insert"),
            new SqlParameter("@EMAIL", info.EMAIL),
            new SqlParameter("@SIFRE", info.SIFRE),
            new SqlParameter("@PORTNUMBER", info.PORTNUMBER),
            
            new SqlParameter("@SMTP", info.SMTP)
                       
            
        };
        string spName = "MailDuzenle";

        return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParametre));

    }
    public void Update(MailInfo info)
    {
        SqlParameter[] spParametre = new SqlParameter[] 
        {
            new SqlParameter("@OPERATION", "Update"),
            new SqlParameter("@EMAIL", info.EMAIL),
            new SqlParameter("@SMTP", info.SMTP),
            new SqlParameter("@PORTNUMBER", info.PORTNUMBER),
             new SqlParameter("@SIFRE", info.SIFRE),

             new SqlParameter("@ID", info.ID)
            
            
        };
        string spName = "MailDuzenle";

        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParametre);

    }







}
