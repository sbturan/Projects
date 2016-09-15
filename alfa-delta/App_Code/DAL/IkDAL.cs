using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

public class IkDAL
{
    public static readonly string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["MSSqlConnString"].ToString();
    #region Select Type Operations

    public IkDAL() { }

    public List<IkInfo> GetList(int YAYIN_DURUMU)
    {
        List<IkInfo> list = new List<IkInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Get"), new SqlParameter("@YAYIN_DURUMU", YAYIN_DURUMU) };
        string spName = "InsanKaynaklariDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                IkInfo info = new IkInfo(dr);
                list.Add(info);
            }
        }
        return list;
    }

    public List<IkInfo> GetByID(int ID, int YAYIN_DURUMU)
    {
        List<IkInfo> list = new List<IkInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Get"), new SqlParameter("@ID", ID), new SqlParameter("@YAYIN_DURUMU", YAYIN_DURUMU) };
        string spName = "InsanKaynaklariDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                IkInfo info = new IkInfo(dr);
                list.Add(info);
            }
        }
        return list;
    }

    public IkInfo GetBilgiByID(int ID, int YAYIN_DURUMU)
    {

        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Get"), new SqlParameter("@ID", ID), new SqlParameter("@YAYIN_DURUMU", YAYIN_DURUMU) };
        string spName = "InsanKaynaklariDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                IkInfo info = new IkInfo(dr);
                return info;
            }
            return null;
        }

    }

    public List<IkInfo> GetByDil(string DIL, int YAYIN_DURUMU)
    {
        List<IkInfo> list = new List<IkInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Get"), new SqlParameter("@DIL", SqlInject.InjectionManager.RejectInjection(DIL)), 
            new SqlParameter("@YAYIN_DURUMU", SqlInject.InjectionManager.RejectInjection(YAYIN_DURUMU)) };
        string spName = "InsanKaynaklariDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                IkInfo info = new IkInfo(dr);
                list.Add(info);
            }

        }

        return list;
    }


    public List<IkInfo> GetByMasterID(int MASTER_ID, int YAYIN_DURUMU)
    {
        List<IkInfo> list = new List<IkInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Get"), new SqlParameter("@YAYIN_DURUMU", YAYIN_DURUMU) };
        string spName = "InsanKaynaklariDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while(dr.Read())
            {
                IkInfo info = new IkInfo(dr);
                list.Add(info);
            }
           
        }

        return list;
    }


    #endregion

    #region Insert / Update / Delete Type Operations

    public Int32 Insert(IkInfo info)
    {
        int returnID = 0;


        if (info.DIL == "ru")
        {
            SqlConnection sqlconn = new SqlConnection(CONNECTION_STRING);
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into insankaynaklari ");
            sb.Append("values ('','','" + info.DIL + "'," );
            sb.Append("'" + info.YAYIN_DURUMU + "','" + info.TARIH.ToString("yyyy-MM-dd") + "',N'");
            sb.Append( SqlInject.InjectionManager.RejectInjection(info.KONU) + "',N'" + SqlInject.InjectionManager.RejectInjection(info.ACIKLAMA) + "');");
            sb.Append("SELECT i.id FROM insankaynaklari i WHERE i.id = @@IDENTITY");

            string sql = sb.ToString();
            SqlCommand sqlcmd = new SqlCommand(sql, sqlconn);
            sqlconn.Open();
            returnID = Convert.ToInt32(sqlcmd.ExecuteScalar());
            sqlconn.Close();

           
        }

        else
        {
            SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Insert"),
                                                           
                                                          new SqlParameter("@KONU", info.KONU), 
                                                          new SqlParameter("@ACIKLAMA", info.ACIKLAMA), 
                                                          new SqlParameter("@TARIH", info.TARIH), 
                                                          new SqlParameter("@DIL", info.DIL), 
                                                           
                                                          new SqlParameter("@YAYIN_DURUMU", info.YAYIN_DURUMU)
                                                          };

            string spName = "InsanKaynaklariDuzenle";
            returnID = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter));
        }
       return returnID;

    }

    public void Update(IkInfo info)
    {
        if (info.DIL == "ru")
        {
            SqlConnection sqlconn = new SqlConnection(CONNECTION_STRING);
            StringBuilder sb = new StringBuilder();
            sb.Append("update insankaynaklari set dil='"+ info.DIL +  ",");
            sb.Append("yayin_durumu='" + info.YAYIN_DURUMU + "',");
            sb.Append("ru_konu=N'" + info.KONU + "',ru_aciklama=N'" + info.ACIKLAMA + "' where id=" + info.ID);
       

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
                                                          new SqlParameter("@DIL", info.DIL), 
                                                           
                                                          new SqlParameter("@YAYIN_DURUMU", info.YAYIN_DURUMU) };
            string spName = "InsanKaynaklariDuzenle";
            SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
        } 
   }

    public void Delete(IkInfo info)
    {
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Delete"), 
                                                          new SqlParameter("@ID", info.ID) };
        string spName = "InsanKaynaklariDuzenle";
        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
    }

    #endregion
}