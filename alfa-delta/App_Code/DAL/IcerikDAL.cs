using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Collections.Generic;

public class IcerikDAL
{
    #region Select Type Operations
    public static readonly string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["MSSqlConnString"].ToString();
    public IcerikDAL() { }

    public List<IcerikInfo> GetList()
    {
        List<IcerikInfo> list = new List<IcerikInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Get") };
        string spName = "IcerikDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                IcerikInfo info = new IcerikInfo(dr);
                list.Add(info);
            }
        }
        return list;
    }

    public List<IcerikInfo> GetTumList()
    {
        List<IcerikInfo> list = new List<IcerikInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetTumList") };
        string spName = "IcerikDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                IcerikInfo info = new IcerikInfo(dr);
                list.Add(info);
            }
        }
        return list;
    }
    public IcerikInfo GetBilgiByID(int ID,string dil)
    {

        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetBilgiByID"), new SqlParameter("@ID", ID),new SqlParameter("@DIL", dil) };
        string spName = "IcerikDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                IcerikInfo info = new IcerikInfo(dr);
                return info;
            }
            return null;
        }

    }
  
    #endregion

    #region Insert / Update / Delete Type Operations

    public Int32 Insert(IcerikInfo info)
    {
        //int returnID = 0;
        //if (info.DIL == "ru")
        //{
        //    SqlConnection sqlconn = new SqlConnection(CONNECTION_STRING);
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("insert into icerik ");
        //    sb.Append("values ('','','','" + info.TARIH.ToString("yyyy-MM-dd") + "'," + info.TIP_ID + ",'");
        //    sb.Append(info.DIL + "','" + info.FOTO + "','" + info.MASTER_ID + "','");
        //    sb.Append(info.YAYIN_DURUMU + "','" + info.GUNCELLEME.ToString("yyyy-MM-dd") + "',N'" + info.KONU + "',N'" + info.OZET + "',N'" + info.ACIKLAMA + "'," + info.YAYIN_YERI + info.SALON + "',N'" + info.SAAT + "',N'" + ");");
        //    sb.Append("SELECT i.id FROM icerik i WHERE i.id = @@IDENTITY");

        //    string sql = sb.ToString();
        //    SqlCommand sqlcmd = new SqlCommand(sql, sqlconn);
        //    sqlconn.Open();
        //    returnID = Convert.ToInt32(sqlcmd.ExecuteScalar());
        //    sqlconn.Close();

        //    return returnID;
        //}

        //else
        //{
            SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Insert"), 
                                                              new SqlParameter("@ID", info.ID), 
                                                              new SqlParameter("@MENU_ID", info.MENU_ID), 
                                                              new SqlParameter("@KONU", info.KONU), 
                                                              new SqlParameter("@ACIKLAMA", info.ACIKLAMA), 
                                                              new SqlParameter("@DIL", info.DIL), 
                                                              new SqlParameter("@YAYIN_DURUMU", info.YAYIN_DURUMU), 
                                                               };
            string spName = "IcerikDuzenle";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter));
           }

    public void Update(IcerikInfo info)
    {

        ////if (info.DIL == "ru")
        ////{
        //    SqlConnection sqlconn = new SqlConnection(CONNECTION_STRING);

        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("update icerik set ru_konu= N'" + info.KONU + "',");
        //    sb.Append( + "',aciklama=N'" + info.ACIKLAMA + "',");
        //    //sb.Append("tip_id=" + info.TIP_ID + ",dil='" + info.DIL + "',foto='" + info.FOTO + "',");
        //    sb.Append("master_id=" + info.MASTER_ID + ",yayin_durumu=" + info.YAYIN_DURUMU + ",");
        //    sb.Append("tarih='" + info.TARIH.ToString("yyyy-MM-dd") + "',guncelleme='" + info.GUNCELLEME.ToString("yyyy-MM-dd") + "',");
        //    sb.Append("yayin_yeri='" + info.YAYIN_YERI + "', ");
        //    sb.Append("salon='" + info.SALON + "', ");
        //    sb.Append("saat='" + info.SAAT + "', ");
        //    sb.Append("genelmi='" + info.YAYIN_YERI + "' ");
        //    sb.Append("where id=" + info.ID);


        //    string sql = sb.ToString();
        //    SqlCommand sqlcmd = new SqlCommand(sql, sqlconn);
        //    sqlconn.Open();
        //    sqlcmd.ExecuteNonQuery();
        //    sqlconn.Close();

        //}

        //else
        //{

        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Update"), new SqlParameter("@ID", info.ID), new SqlParameter("@MENU_ID", info.MENU_ID), new SqlParameter("@KONU", info.KONU), new SqlParameter("@ACIKLAMA", info.ACIKLAMA), new SqlParameter("@DIL", info.DIL), new SqlParameter("@YAYIN_DURUMU", info.YAYIN_DURUMU) };
            string spName = "IcerikDuzenle";
            SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
        //}

    }

    public void Delete(IcerikInfo info)
    {
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Delete"), new SqlParameter("@ID", info.ID) };
        string spName = "IcerikDuzenle";
        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
    }

    #endregion
}