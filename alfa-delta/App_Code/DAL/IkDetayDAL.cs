using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

public class IkDetayDAL
{
    public static readonly string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["MSSqlConnString"].ToString();
    #region Select Type Operations

    public IkDetayDAL() { }

    public List<IkDetayInfo> GetList()
    {
        List<IkDetayInfo> list = new List<IkDetayInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Get") };
        string spName = "IKDetayDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                IkDetayInfo info = new IkDetayInfo(dr);
                list.Add(info);
            }
        }
        return list;
    }
    public IkDetayInfo GetBilgiByID(int ID)
    {

        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetByID"), new SqlParameter("@ID", ID) };
        string spName = "IKDetayDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                IkDetayInfo info = new IkDetayInfo(dr);
                return info;
            }
            return null;
        }

    }


    public List<IkDetayInfo> GetByID(int ID)
    {
        List<IkDetayInfo> list = new List<IkDetayInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Get"), new SqlParameter("@ID", ID) };
        string spName = "IKDetayDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                IkDetayInfo info = new IkDetayInfo(dr);
                list.Add(info);
            }
        }
        return list;
    }

    

    #endregion

    #region Insert / Update / Delete Type Operations

    public Int32 Insert(IkDetayInfo info)
    {
        int returnID = 0;

        
            SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Insert"),
                                                          
                                                          new SqlParameter("@ADI", info.ADI), 
                                                          new SqlParameter("@SOYADI", info.SOYADI), 
                                                          new SqlParameter("@TELEFON", info.TELEFON), 
                                                          new SqlParameter("@EMAIL", info.EMAIL), 
                                                          new SqlParameter("@SORU", info.SORU),
                                                          new SqlParameter("@DOSYA",info.DOSYA)};
            string spName = "IKDetayDuzenle";
            returnID = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter));
        
        return returnID;
    }

    public void Update(IkDetayInfo info)
    {
        
            SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Update"), 
                                                          new SqlParameter("@ID", info.ID), 
                                                          new SqlParameter("@SORU", info.SORU),
                                                          new SqlParameter("@ADI", info.ADI), 
                                                          new SqlParameter("@SOYADI", info.SOYADI), 
                                                          new SqlParameter("@TELEFON", info.TELEFON), 
                                                          new SqlParameter("@EMAIL", info.EMAIL), 
                                                          
                                                          new SqlParameter("@DOSYA",info.DOSYA)};
            string spName = "IKDetayDuzenle";
            SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);

        
    }

    public void Delete(int id)
    {
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Delete"), 
                                                          new SqlParameter("@ID", id) };
        string spName = "IKDetayDuzenle";
        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
    }

   

    #endregion
}