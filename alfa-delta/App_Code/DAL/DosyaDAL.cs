using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DosyaDAL
/// </summary>

/// <summary>
/// Summary description for DosyaDAL
/// </summary>
public class DosyaDAL : Core.BaseDataObject
{
    #region Select Type Operations
    public DosyaDAL(){}

    public List<DosyaInfo> GetList()
    {
        List<DosyaInfo> list = new List<DosyaInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Get")};
        string spName = "DosyaDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                DosyaInfo info = new DosyaInfo(dr);
                list.Add(info);
            }
        }
        return list;
    }

    public DosyaInfo GetBilgiByID(int ID)
    {

        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Get"), new SqlParameter("@ID", ID)};
        string spName = "DosyaDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                DosyaInfo info = new DosyaInfo(dr);
                return info;
            }
            return null;
        }

    }

    public List<DosyaInfo> GetByID(int ID)
    {
        List<DosyaInfo> list = new List<DosyaInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Get"), new SqlParameter("@ID", ID)};
        string spName = "DosyaDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                DosyaInfo info = new DosyaInfo(dr);
                list.Add(info);
            }
        }
        return list;
    }

    public List<DosyaInfo> GetListByTur(int TUR)
    {
        List<DosyaInfo> list = new List<DosyaInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Get"), new SqlParameter("@TUR", TUR) };
        string spName = "DosyaDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                DosyaInfo info = new DosyaInfo(dr);
                list.Add(info);
            }
        }
        return list;
    }


    #endregion

    #region Insert / Update / Delete Type Operations

    public Int32 Insert(DosyaInfo info)
    {
                                         


         SqlParameter[] param = {Parameter("@ID",SqlDbType.Int,ParameterDirection.Output,info.ID),
                                Parameter("@OPERATION",SqlDbType.NVarChar,ParameterDirection.Input,"Insert"),
                                Parameter("@DOSYA",SqlDbType.NVarChar,ParameterDirection.Input,info.DOSYA),
                                Parameter("@TUR",SqlDbType.Int,ParameterDirection.Input,info.TUR),
                                Parameter("@TARIH",SqlDbType.DateTime,ParameterDirection.Input,info.TARIH),
                                Parameter("@ADI",SqlDbType.NVarChar,ParameterDirection.Input,info.ADI)};


        string spName = "DosyaDuzenle";
        int id = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, param));
        return id;
    }

    public void Update(DosyaInfo info)
    {
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Update"), 
                                                          new SqlParameter("@ID", info.ID),
                                                          new SqlParameter("@DOSYA", info.DOSYA),
                                                          new SqlParameter("@TUR", info.TUR),
                                                          new SqlParameter("@TARIH", info.TARIH),
                                                          new SqlParameter("@ADI",info.ADI)   
                                                          };
        string spName = "DosyaDuzenle";
        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
    }


    public void Delete(DosyaInfo info)
    {
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Update"), 
                                                          new SqlParameter("@ID", info.ID)
                                                           
                                                          };
        string spName = "DosyaDuzenle";
        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
    }

    #endregion


}
