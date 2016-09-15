using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class MailListeDAL
{
    #region Select Type Operations

    public MailListeDAL() { }

    public List<MailListeInfo> GetList()
    {
        List<MailListeInfo> list = new List<MailListeInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetTum") };
        string spName = "MailListeDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                MailListeInfo info = new MailListeInfo(dr);
                list.Add(info);
            }
        }
        return list;
    }

    public List<MailListeInfo> GetByID(int ID)
    {
        List<MailListeInfo> list = new List<MailListeInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetById"), new SqlParameter("@ID", ID) };
        string spName = "MailListeDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                MailListeInfo info = new MailListeInfo(dr);
                list.Add(info);
            }
        }
        return list;
    }

  
  
    

    #endregion

    //#region Insert / Update / Delete Type Operations

    //public Int32 Insert(MailListeInfo info)
    //{
    //    SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Insert"),
    //                                                      new SqlParameter("@ID", info.ID), 
    //                                                      new SqlParameter("@ADI", info.ADI), 
    //                                                      new SqlParameter("@SOYADI", info.SOYADI), 
    //                                                      new SqlParameter("@EMAIL", info.EMAIL), 
    //                                                      new SqlParameter("@DURUM", info.DURUM), 
    //                                                      new SqlParameter("@TARIH",info.TARIH),
    //                                                      new SqlParameter("@DIL",info.DIL)  
    //                                                     };
    //    string spName = "MailListeDuzenle";
    //    return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter));

    //}

    //public void Update(MailListeInfo info)
    //{
    //    SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Update"), 
    //                                                      new SqlParameter("@ID", info.ID), 
    //                                                      new SqlParameter("@ADI", info.ADI), 
    //                                                      new SqlParameter("@SOYADI", info.SOYADI), 
    //                                                      new SqlParameter("@EMAIL", info.EMAIL), 
    //                                                      new SqlParameter("@DURUM", info.DURUM), 
    //                                                      new SqlParameter("@TARIH",info.TARIH),
    //                                                      new SqlParameter("@DIL",info.DIL) 
    //                                                     };
    //    string spName = "MailListeDuzenle";
    //    SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
    //}

    //public void Delete(MailListeInfo info)
    //{
    //    SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Delete"), 
    //                                                      new SqlParameter("@ID", info.ID) };
    //    string spName = "MailListeDuzenle";
    //    SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
    //}

    //#endregion
}