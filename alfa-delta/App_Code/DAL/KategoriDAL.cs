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

/// <summary>
/// Summary description for bannerDAL
/// </summary>
public class KategoriDAL
{
	public KategoriDAL()
	{
		
	}

    public List<KategoriInfo> GetKategoriler()
    {
        List<KategoriInfo> list = new List<KategoriInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetKategoriler") };
        string spName = "UrunKategoriDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                KategoriInfo info = new KategoriInfo(dr);
                list.Add(info);
            }

        }

        return list;
    }
    public List<KategoriInfo> GetAltKategoriler(int ID,string dil)
    {
        List<KategoriInfo> list = new List<KategoriInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetAltKategoriler"), new SqlParameter("@UST_ID", ID), new SqlParameter("@DIL", dil) };
        string spName = "UrunKategoriDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                KategoriInfo info = new KategoriInfo(dr);
                list.Add(info);
            }

        }
        
        return list;
    }





    public KategoriInfo GetKategoriByID(int ID)
    {
        List<KategoriInfo> list = new List<KategoriInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetKategoriByID"), new SqlParameter("@URUN_KATEGORIID", ID) };
        string spName = "UrunKategoriDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                KategoriInfo info = new KategoriInfo(dr);
                return info;
            }

            return null;

        }

    }



    public Int32 Insert(KategoriInfo info)
    {
        SqlParameter[] spParametre = new SqlParameter[] 
        {
            new SqlParameter("@OPERATION", "Insert"),
            new SqlParameter("@ADI", info.ADI),
            new SqlParameter("@SAYFA", info.SAYFA),
             new SqlParameter("@DIL", info.DIL),
            new SqlParameter("@YAYIN_DURUMU", info.YAYIN_DURUMU),
              new SqlParameter("@LISTE", info.LISTE),
              new SqlParameter("@ICON",info.ICON),
              new SqlParameter("@UST_ID",info.UST_ID)
                  
            
        };
        string spName = "UrunKategoriDuzenle";

        return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParametre));

    }

    public void Update(KategoriInfo info)
    {
        SqlParameter[] spParametre = new SqlParameter[] 
        {
          new SqlParameter("@OPERATION", "Update"),
            new SqlParameter("@ADI", info.ADI),
           new SqlParameter("@LISTE", info.LISTE),
             new SqlParameter("@DIL", info.DIL),
            new SqlParameter("@URUN_KATEGORIID",info.ID),
            new SqlParameter("@YAYIN_DURUMU", info.YAYIN_DURUMU),
              new SqlParameter("@ICON",info.ICON),
              new SqlParameter("@SAYFA",info.SAYFA),
              new SqlParameter("@UST_ID",info.UST_ID)
            
        };
        string spName = "UrunKategoriDuzenle";

        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParametre);

    }


    public void Delete(KategoriInfo info)
    {
        SqlParameter[] spParametre = new SqlParameter[]
        {
            new SqlParameter("@OPERATION","Delete"),
            new SqlParameter("@URUN_KATEGORIID",info.ID)

        };
        string spName = "UrunKategoriDuzenle";
        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParametre);
    }

    

}
