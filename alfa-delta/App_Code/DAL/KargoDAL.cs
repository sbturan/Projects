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


public class KargoDAL
{
    public KargoDAL()
	{
		
	}

 public KargoInfo GetByID(int ID)
    {
        List<KargoInfo> list = new List<KargoInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetKargoByDetayId"), new SqlParameter("@DETAY_ID", ID) };
        string spName = "KargoDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                KargoInfo info = new KargoInfo(dr);
                return info;
            }

            return null;

        }

    }



    public void Insert(KargoInfo info)
    {
        SqlParameter[] spParametre = new SqlParameter[] 
        {
            new SqlParameter("@OPERATION", "Insert"),
            new SqlParameter("@DETAY_ID", info.ID),
            new SqlParameter("@KARGO_ADI", info.KARGO),
             new SqlParameter("@TAKIP_NO", info.TAKIP),
                       
            
        };
        string spName = "KargoDuzenle";

        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParametre);

    }



 







}
