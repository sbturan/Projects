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
/// Summary description for usrRolDAL
/// </summary>
public class usrRolDAL
{
    public usrRolDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }



    public List<usrRolInfo> GetAllRols()
    {
        List<usrRolInfo> list = new List<usrRolInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetAll") };
        string spName = "sp_UsrRol";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                usrRolInfo info = new usrRolInfo(dr);
                list.Add(info);
            }

        }
        return list;
    }
    public List<usrRolInfo> GetRolsByYonetilebilinir(bool yonetileBilinir)
    {
        List<usrRolInfo> list = new List<usrRolInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetItemByYonetilebilirlik"), 
                                                        new SqlParameter("@Yonetilebilir",yonetileBilinir)
        };
        string spName = "sp_UsrRol";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                usrRolInfo info = new usrRolInfo(dr);
                list.Add(info);
            }

        }
        return list;
    }
    public List<usrRolInfo> GetRolsByYonetilebilinir(usrRolInfo yonetileBilinir)
    {
        List<usrRolInfo> list = new List<usrRolInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetItemByYonetilebilirlik"), 
                                                        new SqlParameter("@Yonetilebilir",yonetileBilinir.Yonetilebilir)
        };
        string spName = "sp_UsrRol";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                usrRolInfo info = new usrRolInfo(dr);
                list.Add(info);
            }

        }
        return list;
    }
    public usrRolInfo GetRolsByRolID(int rolID)
    {
        List<usrRolInfo> list = new List<usrRolInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetItemByRolID"), 
                                                        new SqlParameter("@rolID",rolID)
        };
        string spName = "sp_UsrRol";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                usrRolInfo info = new usrRolInfo(dr);
                return info;
            }

        }
        return null;
    }
    public usrRolInfo GetRolsByRolID(usrRolInfo rolID)
    {
        List<usrRolInfo> list = new List<usrRolInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetItemByRolID"), 
                                                        new SqlParameter("@rolID",rolID.rolID)
        };
        string spName = "sp_UsrRol";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                usrRolInfo info = new usrRolInfo(dr);
                return info;
            }

        }
        return null;
    }
    public Int32 Insert(usrRolInfo refInfo)
    {
        int DonenKayitID = 0;
        string spName = "sp_UsrRol";
        SqlParameter[] spMyParameters = new SqlParameter[]{new SqlParameter("@OPERATION","Insert"),
                                                            new SqlParameter("@rolAd",refInfo.rolAd),
                                                            new SqlParameter("@rolTanim",refInfo.rolTanim),
                                                            new SqlParameter("@Yonetilebilir",refInfo.Yonetilebilir)
                                                           
        };

        DonenKayitID = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spMyParameters));


        return DonenKayitID;
    }
    public void Update(usrRolInfo refInfo)
    {
        string spName = "sp_UsrRol";
        SqlParameter[] spMyParameters = new SqlParameter[] {new SqlParameter("@OPERATION","Update"),
                                                            new SqlParameter("@rolAd",refInfo.rolAd),
                                                            new SqlParameter("@rolTanim",refInfo.rolTanim),
                                                            new SqlParameter("@Yonetilebilir",refInfo.Yonetilebilir),
                                                            new SqlParameter("@rolID",refInfo.rolID)
                                                           
        };

        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spMyParameters);

    }
    public void Delete(usrRolInfo refInfo)
    {
        SqlParameter[] spMyParameter = new SqlParameter[] {new SqlParameter("@OPERATION","Delete"),
                                                           new SqlParameter("@rolID",refInfo.rolID)
        };

        string spName = "sp_UsrRol";
        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spMyParameter);
    }
    public void Delete(int refInfoID)
    {
        SqlParameter[] spMyParameter = new SqlParameter[] {new SqlParameter("@OPERATION","Delete"),
                                                           new SqlParameter("@rolID",refInfoID)
        };
        string spName = "sp_UsrRol";

        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spMyParameter);
    }






}
