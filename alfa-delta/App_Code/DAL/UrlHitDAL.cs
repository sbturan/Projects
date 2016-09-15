using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DosyaDAL
/// </summary>
public class UrlHitDAL : Core.BaseDataObject
{
    #region Select Type Operations
    public UrlHitDAL(){}

    public Int32 GetMevcutZiyaret(string DIL,string URL,string REMOTE_IP,string OTURUM,string SAYFA_ISMI)
    {
        int mevcutziyaret = 0;
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Get"),
                                                          new SqlParameter("@DIL",DIL),
                                                          new SqlParameter("@URL",URL),
                                                          new SqlParameter("@REMOTE_IP",REMOTE_IP),
                                                          new SqlParameter("@OTURUM",OTURUM),
                                                          new SqlParameter("@SAYFA_ISMI",SAYFA_ISMI)};
        string spName = "UrlHitDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if(dr.Read())
            {
                mevcutziyaret = Convert.ToInt32(dr[0]);
                
            }
        }
        return mevcutziyaret;
    }


    public Int32 GetToplamZiyaret(string DIL, string SAYFA_ISMI, string URL)
    {
        int toplamziyaret=0;
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "ToplamZiyaretci"),
                                                          new SqlParameter("@DIL",DIL),
                                                          new SqlParameter("@URL",URL),
                                                          new SqlParameter("@SAYFA_ISMI",SAYFA_ISMI)};
        string spName = "UrlHitDuzenle";

        SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
       
            if (dr.Read())
            {
                toplamziyaret = Convert.ToInt32(dr[0]);
            }

            return toplamziyaret;
    }


    public Int32 GetGunlukZiyaret(string DIL, string SAYFA_ISMI, string URL,DateTime TARIH)
    {
        int gunlukziyaret = 0;
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GunlukZiyaret"),
                                                          new SqlParameter("@DIL",DIL),
                                                          new SqlParameter("@URL",URL),
                                                          new SqlParameter("@SAYFA_ISMI",SAYFA_ISMI),
                                                          new SqlParameter("@TARIH",TARIH)};
        string spName = "UrlHitDuzenle";

        SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);

        if (dr.Read())
        {
            gunlukziyaret = Convert.ToInt32(dr[0]);
        }

        return gunlukziyaret;
    }
    
    #endregion

    #region Insert / Update / Delete Type Operations

    public Int32 Insert(UrlHitInfo info)
    {
        SqlParameter[] spParameter = new SqlParameter[] {Parameter("@ID",SqlDbType.BigInt,ParameterDirection.Output,info.ID),
                                                            Parameter("@OPERATION",SqlDbType.NVarChar,ParameterDirection.Input,"Insert"),
                                                           Parameter("@SAYFA_ISMI",SqlDbType.NVarChar,ParameterDirection.Input,info.SAYFA_ISMI),
                                                           Parameter("@URL",SqlDbType.NVarChar,ParameterDirection.Input,info.URL),
                                                           Parameter("@REMOTE_IP",SqlDbType.NVarChar,ParameterDirection.Input,info.REMOTE_IP),
                                                           Parameter("@OTURUM",SqlDbType.NVarChar,ParameterDirection.Input,info.OTURUM),
                                                           Parameter("@TARIH",SqlDbType.DateTime,ParameterDirection.Input,info.TARIH),
                                                           Parameter("@DIL",SqlDbType.NVarChar,ParameterDirection.Input,info.DIL),
                                                           Parameter("@COZUNURLUK",SqlDbType.NVarChar,ParameterDirection.Input,info.COZUNURLUK),
                                                           Parameter("@BROWSER",SqlDbType.NVarChar,ParameterDirection.Input,info.BROWSER)};
        string spName = "UrlHitDuzenle";
        int id = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter));
        return Convert.ToInt32(spParameter[0].Value);

    }

   
    #endregion


}
