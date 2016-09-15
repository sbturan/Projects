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


public class KontrolDAL
{
    public KontrolDAL()
	{
		
	}

 public KontrolInfo GetByID(int ID)
    {
        List<KontrolInfo> list = new List<KontrolInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetByID"), new SqlParameter("@KID", ID) };
        string spName = "KontrolDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                KontrolInfo info = new KontrolInfo(dr);
                return info;
            }

            return null;

        }

    }



    public void Insert(KontrolInfo info)
    {
        SqlParameter[] spParametre = new SqlParameter[] 
        {
            new SqlParameter("@OPERATION", "Insert"),
            new SqlParameter("@KID", info.ID),
            new SqlParameter("@KONTROL", info.KONTROL)
                       
            
        };
        string spName = "KontrolDuzenle";

        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParametre);

    }

    public void Update(KontrolInfo info)
    {
        SqlParameter[] spParametre = new SqlParameter[] 
        {
            new SqlParameter("@OPERATION", "Update"),
            new SqlParameter("@KID", info.ID),
            new SqlParameter("@KONTROL", info.KONTROL)
            
            
           
            
        };
        string spName = "KontrolDuzenle";

        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParametre);

    }


 







}
