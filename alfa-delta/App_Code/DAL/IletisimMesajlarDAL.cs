using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Text;


public class IletisimMesajlarDAL : Core.BaseDataObject
{


    public IletisimMesajlarDAL() { }
    public IletisimMesajlarInfo GetByID(int Id)
    {
        IletisimMesajlarInfo myInfo = new IletisimMesajlarInfo();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@ID", Id), new SqlParameter("@OPERATION", "GetByID") };
        string spName = "IletisimMesajlarDuzenle";
        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                IletisimMesajlarInfo info = new IletisimMesajlarInfo(dr);
                return info;
            }
        }
        return null;
    }
    public int Insert(IletisimMesajlarInfo f)
    {
        int sonuc = 0;
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@Ad",f.Ad),
                                                            new SqlParameter("@SoyAd",f.SoyAd),
                                                            new SqlParameter("@Email",f.Email),
                                                            new SqlParameter("@IletimMesaj",f.IletimMesaj),
                                                            new SqlParameter("@EklemeTarihi",f.EklemeTarihi),
                                                            new SqlParameter("@EkleyenIP",f.EkleyenIP)
                                                            ,new SqlParameter("@OPERATION","Insert")
};
        string spName = "IletisimMesajlarDuzenle";
        try
        {
            sonuc = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter));
        }
        catch (Exception ex)
        {
            sonuc = 0;
        }
        return sonuc;
    }
    public void Delete(int silID)
    {
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@ID", silID), new SqlParameter("@OPERATION", "Delete") };
        string spName = "IletisimMesajlarDuzenle";
        try
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
        }
        catch (Exception ex)
        {

        }
    }
    public void Delete(IletisimMesajlarInfo f)
    {
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@ID", f.ID), new SqlParameter("@OPERATION", "Delete") };
        string spName = "IletisimMesajlarDuzenle";
        try
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
        }
        catch (Exception ex)
        {

        }
    }
    public List<IletisimMesajlarInfo> GetAll()
    {
        List<IletisimMesajlarInfo> myList = new List<IletisimMesajlarInfo>();

        string mySpName = "IletisimMesajlarDuzenle";

        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetAll") };
        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, mySpName, spParameter))
        {
            while (dr.Read())
            {
                IletisimMesajlarInfo myEntityInfo = new IletisimMesajlarInfo(dr);
                myList.Add(myEntityInfo);
            }
        }
        return myList;
    }
    public void Update(IletisimMesajlarInfo f)
    {
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@ID",f.ID),
                                                            new SqlParameter("@Ad",f.Ad),
                                                            new SqlParameter("@SoyAd",f.SoyAd),
                                                            new SqlParameter("@Email",f.Email),
                                                            new SqlParameter("@IletimMesaj",f.IletimMesaj),
                                                            new SqlParameter("@EklemeTarihi",f.EklemeTarihi),
                                                            new SqlParameter("@EkleyenIP",f.EkleyenIP)
                                                            ,new SqlParameter("@OPERATION","Update")
};
        string spName = "IletisimMesajlarDuzenle";
        try
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
        }
        catch (Exception ex)
        {

        }
    }
}
