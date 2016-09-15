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


public class UrunDAL
{
	public UrunDAL()
	{
		
	}

    public List<Urun1Info> GetUrunler()
    {
        List<Urun1Info> list = new List<Urun1Info>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetUrunler") };
        string spName = "UrunDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                Urun1Info info = new Urun1Info(dr);
                list.Add(info);
            }

        }

        return list;
    }
    public List<UrunInfo> GetIndirimdekiler()
    {
        List<UrunInfo> list = new List<UrunInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetIndirimdekiler") };
        string spName = "UrunDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                UrunInfo info = new UrunInfo(dr);
                list.Add(info);
            }

        }

        return list;
    }

    public void Updateurunkategori(int sayi)
    {
        List<UrunInfo> list = new List<UrunInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Updateurunkategori"), new SqlParameter("@KTG_ID", sayi) };
        string spName = "UrunDuzenle";

        SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
     

        
    }



    public UrunInfo GetUrunStok(int ID)
    {
        List<UrunInfo> list = new List<UrunInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetUrunByID"), new SqlParameter("@URUN_ID", ID) };
        string spName = "UrunDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                UrunInfo info = new UrunInfo(dr);
                return info;
            }

            return null;

        }

    }


    public Urun1Info GetUrunByID(int ID)
    {
        List<Urun1Info> list = new List<Urun1Info>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetUrunByID"), new SqlParameter("@URUN_ID", ID) };
        string spName = "UrunDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                Urun1Info info = new Urun1Info(dr);
                return info;
            }

            return null;

        }

    }
    public UrunInfo GetUrunBy1ID(int ID)
    {
        List<UrunInfo> list = new List<UrunInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetUrunBy1ID"), new SqlParameter("@URUN_ID", ID) };
        string spName = "UrunDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                UrunInfo info = new UrunInfo(dr);
                return info;
            }

            return null;

        }

    }

    public ParaUrunInfo GetUrunFiyat(int ID,int para_kontrol)
    {
        List<ParaUrunInfo> list = new List<ParaUrunInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetUrunFiyat"), new SqlParameter("@URUN_ID", ID), new SqlParameter("@PARA_KONTROL",para_kontrol) };
        string spName = "UrunDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                ParaUrunInfo info = new ParaUrunInfo(dr);
                return info;
            }

            return null;

        }

    }

    public List<UrunInfo> GetUrunByKategoriID(int ID, bool yayin_durumu)
    {
        List<UrunInfo> list = new List<UrunInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetUrunByKategoriID"), new SqlParameter("@KTG_ID", ID), new SqlParameter("@YAYIN_DURUMU", yayin_durumu) };
        string spName = "UrunDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                UrunInfo info = new UrunInfo(dr);
                list.Add(info);
            }

        }

        return list;
    }

    public List<UrunInfo> GetUrunByMarkaID(int ID, bool yayin_durumu)
    {
        List<UrunInfo> list = new List<UrunInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetUrunByMarkaID"), new SqlParameter("@MARKA_ID", ID), new SqlParameter("@YAYIN_DURUMU", yayin_durumu) };
        string spName = "UrunDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                UrunInfo info = new UrunInfo(dr);
                list.Add(info);
            }

        }

        return list;
    }

    public List<UrunInfo> GetSonUrunler()
    {
        List<UrunInfo> list = new List<UrunInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetSonUrunler") };
        string spName = "UrunDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                UrunInfo info = new UrunInfo(dr);
                list.Add(info);
            }

        }

        return list;
    }

    
    public Int32 Insert(UrunInfo info)
    {
        SqlParameter[] spParametre = new SqlParameter[] 
        {
            new SqlParameter("@OPERATION", "Insert"),
            new SqlParameter("@ADI", info.ADI),
            
            new SqlParameter("@YAYIN_DURUMU", info.YAYIN_DURUMU),
              new SqlParameter("@ICON",info.ICON),
              new SqlParameter("@PDF",info.PDF),
              new SqlParameter("@DIL",info.DIL),
              new SqlParameter("@KTG_ID",info.KTG_ID),
        
            
        };
        string spName = "UrunDuzenle";

        return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParametre));

    }

    public void Update(UrunInfo info)
    {
        SqlParameter[] spParametre = new SqlParameter[] 
        {
          new SqlParameter("@OPERATION", "Update"),
            new SqlParameter("@ADI", info.ADI),
            new SqlParameter("@URUN_ID", info.ID), 
            new SqlParameter("@YAYIN_DURUMU", info.YAYIN_DURUMU),
              new SqlParameter("@ICON",info.ICON),
              new SqlParameter("@EKLENME_TARIH",info.TARIH),
           new SqlParameter("@PDF",info.PDF),
              new SqlParameter("@DIL",info.DIL),
              new SqlParameter("@KTG_ID",info.KTG_ID),
           
            
        };
        string spName = "UrunDuzenle";

        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParametre);

    }
    public void Update1(int id,int stok)
    {
        SqlParameter[] spParametre = new SqlParameter[] 
        {  new SqlParameter("@OPERATION", "Update1"),
              new SqlParameter("@URUN_ID",id)
            
            
        };
        string spName = "UrunDuzenle";

        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParametre);

    }


    public void Delete(int id)
    {
        SqlParameter[] spParametre = new SqlParameter[]
        {
            new SqlParameter("@OPERATION","Delete"),
            new SqlParameter("@URUN_ID",id)

        };
        string spName = "UrunDuzenle";
        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParametre);
    }

    

}
