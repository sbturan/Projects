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
public class BannerDAL
{
	public BannerDAL()
	{
		
	}

    public List<BannerInfo> GetTumBannerlar()
    {
        List<BannerInfo> list = new List<BannerInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetTumBannerlar") };
        string spName = "BannerDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                BannerInfo info = new BannerInfo(dr);
                list.Add(info);
            }

        }

        return list;
    }



    public List<BannerInfo> GetTipveYayinYeri(int Tip, int Yayin_Yeri, bool Durum)
    {
        List<BannerInfo> list = new List<BannerInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetTipveYayinYeri"), new SqlParameter("@TIP", Tip), new SqlParameter("@YAYIN_YERI", Yayin_Yeri), new SqlParameter("@YAYIN_DURUMU", Durum) };
        string spName = "BannerDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                BannerInfo info = new BannerInfo(dr);
                list.Add(info);
            }

        }

        return list;

    }

    public BannerInfo GetBannerByID(int ID)
    {
        List<BannerInfo> list = new List<BannerInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetBannerByID"), new SqlParameter("@BANNERID", ID) };
        string spName = "BannerDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                BannerInfo info = new BannerInfo(dr);
                return info;
            }

            return null;

        }

    }



    public Int32 Insert(BannerInfo info)
    {
        SqlParameter[] spParametre = new SqlParameter[] 
        {
            new SqlParameter("@OPERATION", "Insert"),
            new SqlParameter("@ADI", info.ADI),
            new SqlParameter("@DOSYA", info.DOSYA),
            new SqlParameter("@URL", info.URL),
            new SqlParameter("@GENISLIK", info.GENISLIK),
            new SqlParameter("@YUKSEKLIK", info.YUKSEKLIK),
            new SqlParameter("@RELAY", info.RELAY),
            new SqlParameter("@TIP", info.TIP),
            new SqlParameter("@YAYIN_DURUMU", info.YAYIN_DURUMU),
            new SqlParameter("@HIT", info.HIT),           
            new SqlParameter("@EKLENME_TARIH", info.TARIH)
        };
        string spName = "BannerDuzenle";

        return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParametre));

    }

    public void Update(BannerInfo info)
    {
        SqlParameter[] spParametre = new SqlParameter[] 
        {
            new SqlParameter("@OPERATION", "Update"),
            new SqlParameter("@ADI", info.ADI),
            new SqlParameter("@DOSYA", info.DOSYA),
            new SqlParameter("@URL", info.URL),
            new SqlParameter("@GENISLIK", info.GENISLIK),
            new SqlParameter("@YUKSEKLIK", info.YUKSEKLIK),
            new SqlParameter("@RELAY", info.RELAY),
            new SqlParameter("@TIP", info.TIP),
            new SqlParameter("@YAYIN_DURUMU", info.YAYIN_DURUMU),
            new SqlParameter("@HIT", info.HIT),
            new SqlParameter("@BANNERID", info.ID)
            
        };
        string spName = "BannerDuzenle";

        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParametre);

    }


    public void Delete(BannerInfo info)
    {
        SqlParameter[] spParametre = new SqlParameter[]
        {
            new SqlParameter("@OPERATION","Delete"),
            new SqlParameter("BANNERID",info.ID)

        };
        string spName = "BannerDuzenle";
        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParametre);
    }







}
