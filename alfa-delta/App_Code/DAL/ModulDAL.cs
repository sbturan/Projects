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
using System.Collections.Generic;

/// <summary>
/// Summary description for ModulDAL
/// </summary>
public class ModulDAL
{
	public ModulDAL()
	{
		
	}

    #region Select Type Operations
    public ModulInfo GetModuller()
    {

        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetModuller") };
        string spName = "ModulDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                ModulInfo info = new ModulInfo(dr);
                return info;
            }
            return null;
        }

    }


    public List<ModulInfo> GetModulByUstID(int UstID)
    {
        List<ModulInfo> list = new List<ModulInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetModulByUstID"), new SqlParameter("@UST_ID", UstID) };
        string spName = "ModulDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                ModulInfo info = new ModulInfo(dr);
                list.Add(info);
            }
            return null;
        }

    }


    public List<ModulInfo> GetModulByID(int ID)
    {
        List<ModulInfo> list = new List<ModulInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetModulByID"), new SqlParameter("@ID", ID) };
        string spName = "ModulDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                ModulInfo info = new ModulInfo(dr);
                list.Add(info);
            }
            return null;
        }

    }
    
    #endregion


    #region Insert / Update / Delete Type Operations
    public Int32 Insert(ModulInfo info)
    {
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Insert"), 
                                                          new SqlParameter("@UST_ID", info.UST_ID),
                                                          new SqlParameter("@SEVIYE", info.SEVIYE),
                                                          new SqlParameter("@MODUL", info.MODUL),
                                                          new SqlParameter("@MODUL_LINK",info.MODUL_LINK),
                                                          new SqlParameter("@MODUL_ACIKLAMA",info.MODUL_ACIKLAMA),
                                                          new SqlParameter("@SIRA",info.SIRA)
                                                         
                                                         };
        string spName = "ModulDuzenle";
        return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter));

    }

    public void Update(ModulInfo info)
    {
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Update"), 
                                                          new SqlParameter("@UST_ID", info.UST_ID),
                                                          new SqlParameter("@SEVIYE", info.SEVIYE),
                                                          new SqlParameter("@MODUL", info.MODUL),
                                                          new SqlParameter("@MODUL_LINK",info.MODUL_LINK),
                                                          new SqlParameter("@MODUL_ACIKLAMA",info.MODUL_ACIKLAMA),
                                                          new SqlParameter("@SIRA",info.SIRA),
                                                          new SqlParameter("@ID",info.ID)
                                                          };
        string spName = "ModulDuzenle";
        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
    }

    public void Delete(ModulInfo info)
    {
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Delete"), new SqlParameter("@ID", info.ID) };
        string spName = "ModulDuzenle";
        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
    }
    
    #endregion


}
