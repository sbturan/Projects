using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

/// <summary>
/// Summary description for DosyaDAL
/// </summary>
public class GaleriDAL
{
   
    public GaleriDAL() { }

   



    public GaleriInfo GetResimByUrunId(int ID,int yayin_durum)
    {

        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetResimByUrunId"), new SqlParameter("@URUN_ID", ID), new SqlParameter("@YAYIN_DURUMU", yayin_durum) };
        string spName = "GaleriDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                GaleriInfo info = new GaleriInfo(dr);
                return info;
            }
            return null;
        }

    }
    public GaleriInfo GetResimByResimId(int ID)
    {

        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetResimByResimId"), new SqlParameter("@RESIM_ID", ID) };
        string spName = "GaleriDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                GaleriInfo info = new GaleriInfo(dr);
                return info;
            }
            return null;
        }

    }

    public List<GaleriInfo> GetTumResimler()
    {
        List<GaleriInfo> list = new List<GaleriInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetTumResimler") };
        string spName = "GaleriDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                GaleriInfo info = new GaleriInfo(dr);
                list.Add(info);
            }
        }
        return list;
    }








    public Int32 Insert(GaleriInfo info)
    {
        SqlParameter[] spParametre = new SqlParameter[] 
        {
            new SqlParameter("@OPERATION", "Insert"),
            new SqlParameter("@RESIM_ID", info.RESIMID),
            new SqlParameter("@URUN_ID", info.URUNID),
           
            
            new SqlParameter("@RESIM", info.RESIM),
            new SqlParameter("@YAYIN_DURUMU", info.YAYIN_DURUMU)       
            
        };
        string spName = "GaleriDuzenle";

        return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParametre));

    }

    public void Update(GaleriInfo info)
    {
        SqlParameter[] spParametre = new SqlParameter[] 
        {
            new SqlParameter("@OPERATION", "Update"),
                 new SqlParameter("@RESIM_ID", info.RESIMID),
            new SqlParameter("@URUN_ID", info.URUNID),
           
            
            new SqlParameter("@RESIM", info.RESIM),
            new SqlParameter("@YAYIN_DURUMU", info.YAYIN_DURUMU) 
            
        };
        string spName = "GaleriDuzenle";

        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParametre);

    }


    public void Delete(GaleriInfo info)
    {
        SqlParameter[] spParametre = new SqlParameter[]
        {
            new SqlParameter("@OPERATION","Delete"),
            new SqlParameter("@RESIM_ID",info.RESIMID)

        };
        string spName = "GaleriDuzenle";
        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParametre);
    }


}

