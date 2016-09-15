using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Collections.Generic;

public class IlIlceSemtDAL

{
    #region Select Type Operations
    public static readonly string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["MSSqlConnString"].ToString();
    public IlIlceSemtDAL() { }



    public List<IlInfo> GetIller()
    {
        List<IlInfo> list = new List<IlInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetIller") };
        string spName = "IlIlceSemtDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                IlInfo info = new IlInfo(dr);
                list.Add(info);
            }
        }
        return list;
    }

    public List<IlceInfo> GetIlceler(int ilId)
    {
        List<IlceInfo> list = new List<IlceInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetIlceler"), new SqlParameter("@ILID", ilId) };
        string spName = "IlIlceSemtDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                IlceInfo info = new IlceInfo(dr);
                list.Add(info);
            }
        }
        return list;
    }


    public List<SemtInfo> GetSemtler(int ilceId)
    {
        List<SemtInfo> list = new List<SemtInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetSemtler"), new SqlParameter("@ILCEID", ilceId) };
        string spName = "IlIlceSemtDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                SemtInfo info = new SemtInfo(dr);
                list.Add(info);
            }
        }
        return list;
    }





    #endregion
}