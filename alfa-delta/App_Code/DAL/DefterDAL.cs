using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

public class DefterDAL
{
    #region Select Type Operations
    public static readonly string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["MSSqlConnString"].ToString();
    public DefterDAL() { }

    public List<DefterInfo> GetList(int YAYIN_DURUMU)
    {
        List<DefterInfo> list = new List<DefterInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Get"), new SqlParameter("@YAYIN_DURUMU", YAYIN_DURUMU) };
        string spName = "DefterDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                DefterInfo info = new DefterInfo(dr);
                list.Add(info);
            }
        }
        return list;
    }

    public List<DefterInfo> GetByID(int ID, int YAYIN_DURUMU)
    {
        List<DefterInfo> list = new List<DefterInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Get"), new SqlParameter("@ID", ID), new SqlParameter("@YAYIN_DURUMU", YAYIN_DURUMU) };
        string spName = "DefterDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                DefterInfo info = new DefterInfo(dr);
                list.Add(info);
            }
        }
        return list;
    }

    public DefterInfo GetBilgiByID(int ID, int YAYIN_DURUMU)
    {

        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Get"), new SqlParameter("@ID", ID), new SqlParameter("@YAYIN_DURUMU", YAYIN_DURUMU) };
        string spName = "DefterDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                DefterInfo info = new DefterInfo(dr);
                return info;
            }
            return null;
        }

    }

   
    public List<DefterInfo> GetListByDil(string DIL,int YAYIN_DURUMU)
    {
        List<DefterInfo> list = new List<DefterInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Get"), new SqlParameter("@DIL", DIL), new SqlParameter("@YAYIN_DURUMU", YAYIN_DURUMU) };
        string spName = "DefterDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                DefterInfo info = new DefterInfo(dr);
                list.Add(info);
            }

        }

        return list;
    }

    public List<DefterInfo> GetListByDil2(string DIL, int YAYIN_DURUMU)
    {
        List<DefterInfo> list = new List<DefterInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Get2"), new SqlParameter("@DIL", DIL), new SqlParameter("@YAYIN_DURUMU", YAYIN_DURUMU) };
        string spName = "DefterDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                DefterInfo info = new DefterInfo(dr);
                list.Add(info);
            }

        }

        return list;
    }

    public List<DefterInfo> GetListByKullaniciId(int KULLANICI_ID, int YAYIN_DURUMU)
    {
        List<DefterInfo> list = new List<DefterInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Get"), new SqlParameter("@KULLANICI_ID",KULLANICI_ID), new SqlParameter("@YAYIN_DURUMU", YAYIN_DURUMU) };
        string spName = "DefterDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                DefterInfo info = new DefterInfo(dr);
                list.Add(info);
            }

        }

        return list;
    }

    public List<DefterInfo> GetListByAnaSayfa(string DIL)
    {
        List<DefterInfo> list = new List<DefterInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "SayfaGosterim"), new SqlParameter("@DIL", DIL) };
        string spName = "DefterDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                DefterInfo info = new DefterInfo(dr);
                list.Add(info);
            }

        }

        return list;
    }



    #endregion

    #region Insert / Update / Delete Type Operations

    public Int32 Insert(DefterInfo info)
    {
        int returnID = 0;
        if (info.DIL == "ru")
        {
            SqlConnection sqlconn = new SqlConnection(CONNECTION_STRING);
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into ziyaretci_defteri ");
            sb.Append("values ('','','"+ info.TARIH.ToString("yyyy-MM-dd") +"'," + info.KULLANICI_ID + ",'");
            sb.Append(info.YAYIN_DURUMU + "','" + info.ADI + "','" + info.SOYADI + "','");
            sb.Append(info.EMAIL + "','" + info.DIL + "',N'" + info.KONU + "',N'" + info.ACIKLAMA + "');");
            sb.Append("SELECT zd.id FROM ziyaretci_defteri zd WHERE zd.id = @@IDENTITY");
            
            string sql = sb.ToString();
            SqlCommand sqlcmd = new SqlCommand(sql, sqlconn);
            sqlconn.Open();
            returnID = Convert.ToInt32(sqlcmd.ExecuteScalar());
            sqlconn.Close();

            return returnID;
        }

        else
        {
            SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Insert"), 
                                                              new SqlParameter("@ID", info.ID), 
                                                              new SqlParameter("@KONU", info.KONU), 
                                                              new SqlParameter("@ACIKLAMA", info.ACIKLAMA), 
                                                              new SqlParameter("@TARIH", info.TARIH), 
                                                              new SqlParameter("@KULLANICI_ID", info.KULLANICI_ID), 
                                                              new SqlParameter("@YAYIN_DURUMU", info.YAYIN_DURUMU), 
                                                              new SqlParameter("@ADI", info.ADI), 
                                                              new SqlParameter("@SOYADI", info.SOYADI), 
                                                              new SqlParameter("@EMAIL", info.EMAIL), 
                                                              new SqlParameter("@DIL", info.DIL)};
 
            string spName = "DefterDuzenle";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter));
        }
       

    }

    public void Update(DefterInfo info)
    {

        if (info.DIL == "ru")
        {
            SqlConnection sqlconn=new SqlConnection(CONNECTION_STRING);

            StringBuilder sb = new StringBuilder();
            sb.Append("update ziyaretci_defteri set ru_konu= N'" + info.KONU + "',");
            sb.Append("ru_aciklama=N'" + info.ACIKLAMA + "',");
            sb.Append("tarih="+ info.TARIH +",kullanici_id='"+info.KULLANICI_ID+"',yayin_durumu='" + info.YAYIN_DURUMU + "',");
            sb.Append("adi="+info.ADI+",soyadi="+info.SOYADI+",");
            sb.Append("email='" + info.EMAIL+ "',dil='" +info.DIL+"' ");
            
            sb.Append("where id=" + info.ID);


            string sql = sb.ToString();
            SqlCommand sqlcmd = new SqlCommand(sql, sqlconn);
            sqlconn.Open();
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();

        }

        else
        {

            SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Update"), 
                                                              new SqlParameter("@ID", info.ID), 
                                                              new SqlParameter("@KONU", info.KONU), 
                                                              new SqlParameter("@ACIKLAMA", info.ACIKLAMA), 
                                                              new SqlParameter("@TARIH", info.TARIH), 
                                                              new SqlParameter("@KULLANICI_ID", info.KULLANICI_ID), 
                                                              new SqlParameter("@YAYIN_DURUMU", info.YAYIN_DURUMU), 
                                                              new SqlParameter("@ADI", info.ADI), 
                                                              new SqlParameter("@SOYADI", info.SOYADI), 
                                                              new SqlParameter("@EMAIL", info.EMAIL), 
                                                              new SqlParameter("@DIL", info.DIL)};
            string spName = "DefterDuzenle";
            SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
        }
    
    }

    public void Delete(DefterInfo info)
    {
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Delete"), new SqlParameter("@ID", info.ID) };
        string spName = "DefterDuzenle";
        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
    }

    #endregion
}