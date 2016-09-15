using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Text;


public class UsersDAL : Core.BaseDataObject
{


    public UsersDAL() { }
    public UsersInfo BulByID(int Id)
    {
        UsersInfo myInfo = new UsersInfo();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@UserID", Id) };
        string spName = "Get_UserDetails";
        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                UsersInfo info = new UsersInfo(dr);
                return info;
            }
        }
        return null;
    }
    public UsersInfo BulByEmailID(string email)
    {
        List<UsersInfo> list = new List<UsersInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@Email", email) };
        string spName = "Get_UserDetailsFromEmail";
        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                UsersInfo info = new UsersInfo(dr);
                return info;
            }
        }
        return null;
    }
   
    public UsersInfo BulByID(UsersInfo entityInfoID)
    {
        UsersInfo myInfo = new UsersInfo();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@Id", entityInfoID.Id) };
        string spName = "UsersBul";
        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                UsersInfo info = new UsersInfo(dr);
                return info;
            }
        }
        return null;
    }
    public bool UsersEkle(UsersInfo f)
    {
        bool sonuc = false;
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@Adi", f.Adi), new SqlParameter("@Para_kontrol", f.PARA_KONTROL), new SqlParameter("@Soyadi", f.Soyadi), new SqlParameter("@Email", f.Email), new SqlParameter("@Sifre", f.Sifre), new SqlParameter("@TelNo", f.Telefon), new SqlParameter("@Durum", f.Durum), new SqlParameter("@RoleId", f.RoleId) };
        string spName = "Create_User";
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
    public int UsersEkleReturnID(UsersInfo f)
    {
        int sonuc = 0;
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@Adi", f.Adi), new SqlParameter("@Para_kontrol", f.PARA_KONTROL), new SqlParameter("@Soyadi", f.Soyadi), new SqlParameter("@Email", f.Email), new SqlParameter("@Aktivasyon", f.AKTIVASYON), new SqlParameter("@Tarih", f.TARIH), new SqlParameter("@Durum", f.Durum), new SqlParameter("@RoleId", f.RoleId) };
        string spName = "Create_User";
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
    public bool UsersSilReturnSonuc(UsersInfo f)
    {
        bool sonuc = false;
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@KullaniciId", f.Id) };
        string spName = "Delete_User";
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
    public void UsersSil(int silID)
    {
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@KullanicID", silID) };
        string spName = "Delete_User";
        try
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
        }
        catch (Exception ex)
        {

        }
    }
    public void UsersSil(UsersInfo f)
    {
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@KullaniciId", f.Id) };
        string spName = "Delete_User";
        try
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
        }
        catch (Exception ex)
        {

        }
    }
    public DataTable UsersGetir()
    {
        SqlConnection cn = new SqlConnection(SqlHelper.CONNECTION_STRING);
        SqlCommand cmd = new SqlCommand("Get_Users", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable d = new DataTable();
        da.Fill(d);
        return d;
    }
    public List<UsersInfo> GetirList()
    {
        List<UsersInfo> myList = new List<UsersInfo>();

        string mySpName = "Get_Users";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, mySpName))
        {
            while (dr.Read())
            {
                UsersInfo myEntityInfo = new UsersInfo(dr);
                myList.Add(myEntityInfo);
            }
        }
        return myList;
    }
    public bool UsersGuncelleReturnSonuc(UsersInfo f)
    {
        bool sonuc = false;
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@KullaniciID", f.Id), new SqlParameter("@Para_kontrol", f.PARA_KONTROL), new SqlParameter("@Adi", f.Adi), new SqlParameter("@Soyadi", f.Soyadi), new SqlParameter("@Email", f.Email), new SqlParameter("@Sifre", f.Sifre), new SqlParameter("@Telefon", f.Telefon), new SqlParameter("@Durum", f.Durum), new SqlParameter("@roleID", f.RoleId) };

        string spName = "Update_User";
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
    public void UsersGuncelle(UsersInfo f)
    {
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@Para_kontrol", f.PARA_KONTROL), new SqlParameter("@Adi", f.Adi), new SqlParameter("@Soyadi", f.Soyadi), new SqlParameter("@Email", f.Email), new SqlParameter("@Sifre", f.Sifre), new SqlParameter("@TelNo", f.Telefon), new SqlParameter("@Durum", f.Durum), new SqlParameter("@roleID", f.RoleId) };

        string spName = "Update_User";
        try
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
        }
        catch (Exception ex)
        {

        }
    }
    public void UsersUpdate(UsersInfo f)
    {
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@KullaniciID", f.Id), new SqlParameter("@Para_kontrol", f.PARA_KONTROL), new SqlParameter("@Sifre", f.Sifre), new SqlParameter("@TelNo", f.Telefon), new SqlParameter("@Durum", f.Durum), new SqlParameter("@roleID", f.RoleId) };

        string spName = "Update_User1";
        try
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
        }
        catch (Exception ex)
        {

        }
    }






}
