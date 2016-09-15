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
public class UrunAciklamaDAL
{
    public UrunAciklamaDAL()
	{
		
	}

    public List<UrunAciklamaInfo> GetTumUA(string dil)
    {
        List<UrunAciklamaInfo> list = new List<UrunAciklamaInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetTumUA"), new SqlParameter("@DIL", dil) };
        string spName = "urunaciklama";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                UrunAciklamaInfo info = new UrunAciklamaInfo(dr);
                list.Add(info);
            }

        }

        return list;
    }





    public List<UrunAciklamaInfo> GetUAbyUrunID(int ID, string dil)
    {
        List<UrunAciklamaInfo> list = new List<UrunAciklamaInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetUAbyUrunID"), new SqlParameter("@URUN_ID", ID), new SqlParameter("@DIL", dil) };
        string spName = "urunaciklama";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                UrunAciklamaInfo info = new UrunAciklamaInfo(dr);
                list.Add(info);
            }

            return list;

        }

    }



    public Int32 Insert(UrunAciklamaInfo info)
    {
        SqlParameter[] spParametre = new SqlParameter[] 
        {
            new SqlParameter("@OPERATION", "Insert"),
            new SqlParameter("@DIL", info.DIL),
            new SqlParameter("@ACIKLAMA", info.ACIKLAMA),
            new SqlParameter("@URUN_ID", info.URUN_ID)
                       
            
        };
        string spName = "UrunAciklama";

        return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParametre));

    }

    public void Update(UrunAciklamaInfo info)
    {
        SqlParameter[] spParametre = new SqlParameter[] 
        {
            new SqlParameter("@OPERATION", "Update"),
            new SqlParameter("@DIL", info.DIL),
            new SqlParameter("@ACIKLAMA", info.ACIKLAMA),
            new SqlParameter("@URUN_ID", info.URUN_ID)
           
            
        };
        string spName = "UrunAciklama";

        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParametre);

    }


    public void Delete(UrunAciklamaInfo info)
    {
        SqlParameter[] spParametre = new SqlParameter[]
        {
            new SqlParameter("@OPERATION","Delete"),
            new SqlParameter("@URUN_ID", info.URUN_ID)

        };
        string spName = "UrunAciklama";
        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParametre);
    }







}
