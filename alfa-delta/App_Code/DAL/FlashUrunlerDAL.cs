using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Text;


public class FlashUrunlerDAL : Core.BaseDataObject
{


    public FlashUrunlerDAL() { }
    public FlashUrunlerInfo BulByID(int Id)
    {
        FlashUrunlerInfo myInfo = new FlashUrunlerInfo();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@ID", Id) };
        string spName = "FlashUrunlerBul";
        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                FlashUrunlerInfo info = new FlashUrunlerInfo(dr);
                return info;
            }
        }
        return null;
    }
    public FlashUrunlerInfo BulByID(FlashUrunlerInfo entityInfoID)
    {
        FlashUrunlerInfo myInfo = new FlashUrunlerInfo();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@ID", entityInfoID.ID) };
        string spName = "FlashUrunlerBul";
        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                FlashUrunlerInfo info = new FlashUrunlerInfo(dr);
                return info;
            }
        }
        return null;
    }
    public bool FlashUrunlerEkle(FlashUrunlerInfo f)
    {
        bool sonuc = false;
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@UrunIsim", f.UrunIsim), new SqlParameter("@UrunResim", f.UrunResim), new SqlParameter("@UrunLink", f.UrunLink), new SqlParameter("@Sira", f.Sira), new SqlParameter("@YayinDurumu", f.YayinDurumu), new SqlParameter("@Dil", f.Dil) };
        string spName = "FlashUrunlerEkle";
        try
        {
            SqlHelper.ExecuteScalar(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
            sonuc = true;
        }
        catch (Exception ex)
        {
            sonuc = false;
        }
        return sonuc;
    }
    public int FlashUrunlerEkleReturnID(FlashUrunlerInfo f)
    {
        int sonuc = 0;
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@UrunIsim", f.UrunIsim), new SqlParameter("@UrunResim", f.UrunResim), new SqlParameter("@UrunLink", f.UrunLink), new SqlParameter("@Sira", f.Sira), new SqlParameter("@YayinDurumu", f.YayinDurumu), new SqlParameter("@Dil", f.Dil) };
        string spName = "FlashUrunlerEkle ";
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
    public bool FlashUrunlerSilReturnSonuc(FlashUrunlerInfo f)
    {
        bool sonuc = false;
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@ID", f.ID) };
        string spName = "FlashUrunlerSil";
        try
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
            sonuc = true;
        }
        catch (Exception ex)
        {
            sonuc = false;
        }
        return sonuc;
    }
    public void FlashUrunlerSil(int silID)
    {
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@ID", silID) };
        string spName = "FlashUrunlerSil ";
        try
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
        }
        catch (Exception ex)
        {

        }
    }
    public void FlashUrunlerSil(FlashUrunlerInfo f)
    {
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@ID", f.ID) };
        string spName = "FlashUrunlerSil ";
        try
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
        }
        catch (Exception ex)
        {

        }
    }
    public DataTable FlashUrunlerGetir()
    {
        SqlConnection cn = new SqlConnection(SqlHelper.CONNECTION_STRING);
        SqlCommand cmd = new SqlCommand("FlashUrunlerGetir", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable d = new DataTable();
        da.Fill(d);
        return d;
    }
    public List<FlashUrunlerInfo> GetirList()
    {
        List<FlashUrunlerInfo> myList = new List<FlashUrunlerInfo>();

        string mySpName = "FlashUrunlerGetir";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, mySpName))
        {
            while (dr.Read())
            {
                FlashUrunlerInfo myEntityInfo = new FlashUrunlerInfo(dr);
                myList.Add(myEntityInfo);
            }
        }
        return myList;
    }
    public bool FlashUrunlerGuncelleReturnSonuc(FlashUrunlerInfo f)
    {
        bool sonuc = false;
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@ID", f.ID), new SqlParameter("@UrunIsim", f.UrunIsim), new SqlParameter("@UrunResim", f.UrunResim), new SqlParameter("@UrunLink", f.UrunLink), new SqlParameter("@Sira", f.Sira), new SqlParameter("@YayinDurumu", f.YayinDurumu), new SqlParameter("@Dil", f.Dil) };
        string spName = "FlashUrunlerGuncelle";
        try
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
            sonuc = true;
        }
        catch (Exception ex)
        {
            sonuc = false;
        }
        return sonuc;
    }
    public void FlashUrunlerGuncelle(FlashUrunlerInfo f)
    {
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@ID", f.ID), new SqlParameter("@UrunIsim", f.UrunIsim), new SqlParameter("@UrunResim", f.UrunResim), new SqlParameter("@UrunLink", f.UrunLink), new SqlParameter("@Sira", f.Sira), new SqlParameter("@YayinDurumu", f.YayinDurumu), new SqlParameter("@Dil", f.Dil) };
        string spName = "FlashUrunlerGuncelle ";
        try
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
        }
        catch (Exception ex)
        {

        }
    }


    public List<FlashUrunlerInfo> GetirListBySiraAndDil(string dil,int yayinDurumu)
    {
        List<FlashUrunlerInfo> myList = new List<FlashUrunlerInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@Dil", dil), new SqlParameter("@YayinDurumu", yayinDurumu) };
        string mySpName = "FlashUrunlerGetirBySiraAndDil";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, mySpName,spParameter))
        {
            while (dr.Read())
            {
                FlashUrunlerInfo myEntityInfo = new FlashUrunlerInfo(dr);
                myList.Add(myEntityInfo);
            }
        }
        return myList;
    }
}
