using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

/// <summary>
/// Summary description for GorselDAL
/// </summary>
public class GorselDAL : Core.BaseDataObject
{

    public static readonly string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["MSSqlConnString"].ToString();
    #region Select Type Operations
    public GorselDAL(){}

    public List<GorselInfo> GetList(int TUR)
    {
        List<GorselInfo> list = new List<GorselInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Get"), new SqlParameter("@TUR", TUR)};
        string spName = "GorselDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                GorselInfo info = new GorselInfo(dr);
                list.Add(info);
            }
        }
        return list;
    }
    public DataTable GetByYayinYeriDT(int TUR, string DIL, int TIP_ID, string YAYIN_YERI, int UST_ID)
    {
        DataTable dt = new DataTable();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "SayfaGosterimDT"), new SqlParameter("@TUR", TUR), new SqlParameter("@DIL", DIL), new SqlParameter("@TIP_ID", TIP_ID), new SqlParameter("@YAYIN_YERI", YAYIN_YERI), new SqlParameter("@UST_ID", UST_ID) };
        string spName = "GorselDuzenle";

        dt = RunProcedure(spName, spParameter);
        //using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        //{
        //    while (dr.Read())
        //    {
        //        GorselInfo info = new GorselInfo(dr);
        //        list.Add(info);
        //    }
        //}
        return dt;
    }


    public List<GorselInfo> GetListByTip(int TIP_ID,int UST_ID,int TUR,int YAYIN_DURUMU)
    {
        List<GorselInfo> list = new List<GorselInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Get"), new SqlParameter("@TIP_ID",TIP_ID), new SqlParameter("@UST_ID",UST_ID), new SqlParameter("@TUR",TUR), new SqlParameter("@YAYIN_DURUMU",YAYIN_DURUMU) };
        string spName = "GorselDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                GorselInfo info = new GorselInfo(dr);
                list.Add(info);
            }
        }
        return list;
    }


    public List<GorselInfo> GetListByDil(int TUR,string DIL)
    {
        List<GorselInfo> list = new List<GorselInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Get"), new SqlParameter("@TUR", TUR), new SqlParameter("@DIL)", DIL) };
        string spName = "GorselDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                GorselInfo info = new GorselInfo(dr);
                list.Add(info);
            }
        }
        return list;
    }

    public List<GorselInfo> GetListByMasterId(int MASTER_ID, int YAYIN_DURUMU)
    {
        List<GorselInfo> list = new List<GorselInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Get"), new SqlParameter("@MASTER_ID", MASTER_ID), new SqlParameter("@YAYIN_DURUMU",YAYIN_DURUMU) };
        string spName = "GorselDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                GorselInfo info = new GorselInfo(dr);
                list.Add(info);
            }
        }
        return list;
    }

    public List<GorselInfo> GetByID(int ID, int YAYIN_DURUMU)
    {
        List<GorselInfo> list = new List<GorselInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Get"), new SqlParameter("@ID", ID), new SqlParameter("@YAYIN_DURUMU", YAYIN_DURUMU) };
        string spName = "GorselDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                GorselInfo info = new GorselInfo(dr);
                list.Add(info);
            }
        }
        return list;
    }

    public List<GorselInfo> GetByYayinYeri(int TUR,string DIL,int TIP_ID,string YAYIN_YERI,int UST_ID)
    {
        List<GorselInfo> list = new List<GorselInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "SayfaGosterim"), new SqlParameter("@TUR", TUR), new SqlParameter("@DIL", DIL), new SqlParameter("@TIP_ID", TIP_ID), new SqlParameter("@YAYIN_YERI", YAYIN_YERI), new SqlParameter("@UST_ID", UST_ID) };
        string spName = "GorselDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                GorselInfo info = new GorselInfo(dr);
                list.Add(info);
            }
        }
        return list;
    }

    public List<GorselInfo> GetByKullanici(int YAYIN_DURUMU,int EKLEYEN,int TUR)
    {
        List<GorselInfo> list = new List<GorselInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GorselByEkleyen"), 
                                                          new SqlParameter("@YAYIN_DURUMU", YAYIN_DURUMU), 
                                                          new SqlParameter("@EKLEYEN", EKLEYEN), 
                                                          new SqlParameter("@TUR", TUR)   };
        string spName = "GorselDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                GorselInfo info = new GorselInfo(dr);
                list.Add(info);
            }
        }
        return list;
    }

    public List<GorselInfo> GetListByUstID(int UST_ID)
    {
        List<GorselInfo> list = new List<GorselInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetListByUstID"), 
                                                          new SqlParameter("@UST_ID", UST_ID)};
        string spName = "GorselDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                GorselInfo info = new GorselInfo(dr);
                list.Add(info);
            }
        }
        return list;
    }

    public GorselInfo GetBilgiByID(int ID, int YAYIN_DURUMU)
    {

        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Get"), new SqlParameter("@ID", ID), new SqlParameter("@YAYIN_DURUMU", YAYIN_DURUMU) };
        string spName = "GorselDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                GorselInfo info = new GorselInfo(dr);
                return info;
            }
            return null;
        }

    }

    #endregion

    #region Insert / Update / Delete Type Operations

    public Int32 Insert(GorselInfo info)
    {
        int returnID = 0;

        if (info.DIL == "ru")
        {
            SqlConnection sqlconn = new SqlConnection(CONNECTION_STRING);
            StringBuilder sb = new StringBuilder();

            if (info.KONU != "")
            {
                sb.Append("insert into gorsel values ");
                sb.Append("('" + info.DOSYA_ID + "','"+ info.EKLEMETARIHI.ToString("yyyy-MM-dd") + "'," + info.TIP_ID + ",");
                sb.Append(info.UST_ID + "," + info.K_FOTO_ID + ",'',"+info.YAYIN_DURUMU+",'"+info.TUR+"',");
                sb.Append("'" + info.YAYIN_YERI +"','" + info.DIL + "','" +info.MASTER_ID+ "',N'" + info.KONU + "'," +info.EKLEYEN+ ");");
                sb.Append("SELECT g.id FROM gorsel g WHERE g.id = @@IDENTITY");
   

            }
            else
            {
                sb.Append("insert into gorsel (dosya_id,eklemetarihi,tip_id,ust_id,k_foto_id,yayin_durumu,tur,yayin_yeri,dil,master_id,ekleyen) values ");
                sb.Append("('" + info.DOSYA_ID + "','" + info.EKLEMETARIHI.ToString("yyyy-MM-dd") + "'," + info.TIP_ID + ",");
                sb.Append(info.UST_ID + "," + info.K_FOTO_ID + "," + info.YAYIN_DURUMU + ",'" + info.TUR + "',");
                sb.Append("'" + info.YAYIN_YERI + "','" + info.DIL + "','"+info.MASTER_ID+"','"+info.EKLEYEN+"');");
                sb.Append("SELECT g.id FROM gorsel g WHERE g.id = @@IDENTITY");
            }

            string sql = sb.ToString();
            SqlCommand sqlcmd = new SqlCommand(sql, sqlconn);
            sqlconn.Open();
            returnID = Convert.ToInt32(sqlcmd.ExecuteScalar());
            sqlconn.Close();


        }

        else
        {

            SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Insert"), 
                                                              new SqlParameter("@DOSYA_ID", info.DOSYA_ID),
                                                              new SqlParameter("@EKLEMETARIHI", info.EKLEMETARIHI), 
                                                              new SqlParameter("@TIP_ID", info.TIP_ID), 
                                                              new SqlParameter("@UST_ID", info.UST_ID), 
                                                              new SqlParameter("@K_FOTO_ID", info.K_FOTO_ID), 
                                                              new SqlParameter("@KONU", info.KONU), 
                                                              new SqlParameter("@YAYIN_DURUMU", info.YAYIN_DURUMU),
                                                              new SqlParameter("@TUR", info.TUR),
                                                              new SqlParameter("@MASTER_ID", info.MASTER_ID),
                                                              new SqlParameter("@YAYIN_YERI", info.YAYIN_YERI), 
                                                              new SqlParameter("@DIL", info.DIL),
                                                              new SqlParameter("@EKLEYEN",info.EKLEYEN)};
            string spName = "GorselDuzenle";
            returnID = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter));

        }
        
        return returnID;
    }

    public void Update(GorselInfo info)
    {

        if (info.DIL == "ru")
        {
            SqlConnection sqlconn = new SqlConnection(CONNECTION_STRING);
            StringBuilder sb = new StringBuilder();
            
            if (info.KONU != "")
            {
                sb.Append("update gorsel set ru_konu= N'" + info.KONU + "',");
                sb.Append("tip_id=" + info.TIP_ID + ",k_foto_id='"+info.K_FOTO_ID+"',dosya_id='" + info.DOSYA_ID + "',");
                sb.Append("yayin_durumu=" + info.YAYIN_DURUMU + ",");
                sb.Append("eklemetarihi='" + info.EKLEMETARIHI.ToString("yyyy-MM-dd") + "',tur='" + info.TUR + "',");
                sb.Append("ust_id=" + info.UST_ID + ",yayin_yeri=" + info.YAYIN_YERI + ",dil='" + info.DIL + "',master_id='" +info.MASTER_ID+ "',ekleyen='" +info.EKLEYEN+ "'");
                sb.Append("where id=" + info.ID);
            
            }

            else
            {
                sb.Append("update gorsel set ");
                sb.Append("tip_id=" + info.TIP_ID +",k_foto_id='"+info.K_FOTO_ID+"',dosya_id='" + info.DOSYA_ID + "',");
                sb.Append("yayin_durumu=" + info.YAYIN_DURUMU + ",");
                sb.Append("eklemetarihi='" + info.EKLEMETARIHI.ToString("yyyy-MM-dd") + "',tur='" + info.TUR + "',");
                sb.Append("ust_id=" + info.UST_ID + ",yayin_yeri=" + info.YAYIN_YERI + ",dil='" + info.DIL + "',master_id='" +info.MASTER_ID+"',ekleyen='" +info.EKLEYEN+ "'");
                sb.Append("where id=" + info.ID);

            }

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
                                                          new SqlParameter("@DOSYA_ID", info.DOSYA_ID),
                                                          new SqlParameter("@EKLEMETARIHI", info.EKLEMETARIHI), 
                                                          new SqlParameter("@TIP_ID", info.TIP_ID), 
                                                          new SqlParameter("@UST_ID", info.UST_ID), 
                                                          new SqlParameter("@K_FOTO_ID", info.K_FOTO_ID), 
                                                          new SqlParameter("@KONU", info.KONU), 
                                                          new SqlParameter("@YAYIN_DURUMU", info.YAYIN_DURUMU),
                                                          new SqlParameter("@TUR", info.TUR),
                                                          new SqlParameter("@MASTER_ID", info.MASTER_ID),  
                                                          new SqlParameter("@YAYIN_YERI", info.YAYIN_YERI), 
                                                          new SqlParameter("@DIL", info.DIL),
                                                          new SqlParameter("@EKLEYEN",info.EKLEYEN)};
            string spName = "GorselDuzenle";
            SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
        }
    }

    public void Delete(GorselInfo info)
    {
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Delete"), new SqlParameter("@ID", info.ID) };
        string spName = "GorselDuzenle";
        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
    }

    public void UpdateYayinYeri(GorselInfo info)
    {
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "UpdateYayinYeri"), 
                                                          new SqlParameter("@ID", info.ID),
                                                          new SqlParameter("@TIP_ID", info.TIP_ID), 
                                                          new SqlParameter("@TUR", info.TUR),
                                                          new SqlParameter("@DIL", info.DIL) };
        string spName = "GorselDuzenle";
        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
    }
    #endregion


}
