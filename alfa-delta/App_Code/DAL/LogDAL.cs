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


public class LogDAL
{
    public LogDAL()
    {

    }

    public List<LogInfo> GetTumLoglar()
    {
        List<LogInfo> list = new List<LogInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetTumLoglar") };
        string spName = "LogTakip";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                LogInfo info = new LogInfo(dr);
                list.Add(info);
            }

        }

        return list;
    }





    public LogInfo GetLogByID(int ID)
    {
        List<LogInfo> list = new List<LogInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetLogByID"), new SqlParameter("@LOG_ID", ID) };
        string spName = "LogTakip";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                LogInfo info = new LogInfo(dr);
                return info;
            }

            return null;

        }

    }
    public List<LogInfo> GetLogByKullaniciID(int ID)
    {
        List<LogInfo> list = new List<LogInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetLogByKullaniciID"), new SqlParameter("@KULLANICIID" , ID) };
        string spName = "LogTakip";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
           
                while (dr.Read())
                {
                    LogInfo info = new LogInfo(dr);
                    list.Add(info);
                }

            }

            return list;
        }

    


    public Int32 Insert(LogInfo info)
    {
        SqlParameter[] spParametre = new SqlParameter[] 
        {
            new SqlParameter("@OPERATION", "Insert"),
            new SqlParameter("@KULLANICIID", info.KID),
            new SqlParameter("@BROWSER", info.BROWSER),
            new SqlParameter("@IP", info.IP),
             new SqlParameter("@ISLEM_SAATI", info.ISLEM_SAATI),
            new SqlParameter("@AKSIYON", info.AKSIYON)
                       
            
        };
        string spName = "LogTakip";

        return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParametre));

    }








}
