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


public class ParaDAL
{
    public ParaDAL()
	{
		
	}

    public List<ParaInfo> GetTumBirimler()
    {
        List<ParaInfo> list = new List<ParaInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetTumBirimler") };
        string spName = "ParaDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                ParaInfo info = new ParaInfo(dr);
                list.Add(info);
            }

        }

        return list;
    }





    public ParaInfo GetParaByID(int ID)
    {
        List<ParaInfo> list = new List<ParaInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetParaByID"), new SqlParameter("@PARAID", ID) };
        string spName = "ParaDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                ParaInfo info = new ParaInfo(dr);
                return info;
            }

            return null;

        }

    }



    public Int32 Insert(ParaInfo info)
    {
        SqlParameter[] spParametre = new SqlParameter[] 
        {
            new SqlParameter("@OPERATION", "Insert"),
            new SqlParameter("@ADI", info.PARAID),
            new SqlParameter("@DOSYA", info.PARA_BIRIM)
                       
            
        };
        string spName = "ParaDuzenle";

        return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParametre));

    }

    public void Update(ParaInfo info)
    {
        SqlParameter[] spParametre = new SqlParameter[] 
        {
            new SqlParameter("@OPERATION", "Update"),
            new SqlParameter("@PARAID", info.PARAID),
            new SqlParameter("@PARA_BIRIM", info.PARA_BIRIM)
            
            
           
            
        };
        string spName = "ParaDuzenle";

        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParametre);

    }


    public void Delete(ParaInfo info)
    {
        SqlParameter[] spParametre = new SqlParameter[]
        {
            new SqlParameter("@OPERATION","Delete"),
            new SqlParameter("@PARAID",info.PARAID)

        };
        string spName = "ParaDuzenle";
        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParametre);
    }







}
