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


public class ParaalDAL
{
    public ParaalDAL()
    {

    }






    public ParaalInfo GetKur()
    {
        List<ParaalInfo> list = new List<ParaalInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetKur") };
        string spName = "KurDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                ParaalInfo info = new ParaalInfo(dr);
                return info;
            }

            return null;

        }

    }



    public Int32 Insert(ParaalInfo info)
    {
        SqlParameter[] spParametre = new SqlParameter[] 
        {
            new SqlParameter("@OPERATION", "Insert"),
            new SqlParameter("@DOLARA", info.DOLARA),
            new SqlParameter("@DOLARS", info.DOLARS),
            new SqlParameter("@EUROA", info.EUROA),
            new SqlParameter("@EUROS", info.EUROS),
            new SqlParameter("@KONTROL", info.KONTROL)
                       
            
        };
        string spName = "KurDuzenle";

        return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParametre));

    }
    public void Update(ParaalInfo info)
    {
        SqlParameter[] spParametre = new SqlParameter[] 
        {
            new SqlParameter("@OPERATION", "Update"),
           new SqlParameter("@DOLARA", info.DOLARA),
            new SqlParameter("@DOLARS", info.DOLARS),
            new SqlParameter("@EUROA", info.EUROA),
            new SqlParameter("@EUROS", info.EUROS),
            new SqlParameter("@KONTROL", info.KONTROL),

             new SqlParameter("@ID", info.ID)
            
            
        };
        string spName = "KurDuzenle";

        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParametre);

    }
    public void Delete(ParaalInfo info)
    {
        SqlParameter[] spParametre = new SqlParameter[]
        {
            new SqlParameter("@OPERATION","Delete"),
            new SqlParameter("ID",info.ID)

        };
        string spName = "KurDuzenle";
        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParametre);
    }







}
