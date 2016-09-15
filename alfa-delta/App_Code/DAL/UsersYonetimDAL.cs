using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Text;


public class UsersYonetimDAL : Core.BaseDataObject
{


    public UsersYonetimDAL() { }
    public UsersYonetimInfo BulByID(int Id)
    {
        UsersYonetimInfo myInfo = new UsersYonetimInfo();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@UserID", Id) };
        string spName = "Get_UserDetails";
        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                UsersYonetimInfo info = new UsersYonetimInfo(dr);
                return info;
            }
            return null;
        }

    }
    public UsersYonetimInfo BulByEmailID(string email)
    {
        List<UsersYonetimInfo> list = new List<UsersYonetimInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@Email", email) };
        string spName = "Get_UserDetailsFromEmail";
        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                UsersYonetimInfo info = new UsersYonetimInfo(dr);
                return info;
            }
        }
        return null;
    }

    public UsersYonetimInfo BulByID(UsersYonetimInfo entityInfoID)
    {
        UsersYonetimInfo myInfo = new UsersYonetimInfo();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@Id", entityInfoID.Id) };
        string spName = "UsersBul";
        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                UsersYonetimInfo info = new UsersYonetimInfo(dr);
                return info;
            }
        }
        return null;
    }
    public bool UsersYonetimEkle(UsersYonetimInfo f)
    {
        bool sonuc = false;
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@Adi", f.Adi), new SqlParameter("@Soyadi", f.Soyadi), new SqlParameter("@Email", f.Email), new SqlParameter("@Sifre", f.Sifre), new SqlParameter("@Telefon", f.Telefon), new SqlParameter("@Durum", f.Durum), new SqlParameter("@RoleId", f.RoleId) };
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
    public int UsersYonetimEkleReturnID(UsersYonetimInfo f)
    {
        int sonuc = 0;
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@Adi", f.Adi), new SqlParameter("@Soyadi", f.Soyadi), new SqlParameter("@Email", f.Email), new SqlParameter("@Sifre", f.Sifre), new SqlParameter("@TelNo", f.Telefon), new SqlParameter("@Durum", f.Durum), new SqlParameter("@RoleId", f.RoleId) };
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
    public bool UsersYonetimSilReturnSonuc(UsersYonetimInfo f)
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
    public void UsersYonetimSil(int silID)
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
    public void UsersYonetimSil(UsersYonetimInfo f)
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
    public DataTable UsersYonetimGetir()
    {
        SqlConnection cn = new SqlConnection(SqlHelper.CONNECTION_STRING);
        SqlCommand cmd = new SqlCommand("Get_Users", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable d = new DataTable();
        da.Fill(d);
        return d;
    }
    public List<UsersYonetimInfo> GetirList()
    {
        List<UsersYonetimInfo> myList = new List<UsersYonetimInfo>();

        string mySpName = "Get_Users";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, mySpName))
        {
            while (dr.Read())
            {
                UsersYonetimInfo myEntityInfo = new UsersYonetimInfo(dr);
                myList.Add(myEntityInfo);
            }
        }
        return myList;
    }
    public bool UsersYonetimGuncelleReturnSonuc(UsersYonetimInfo f)
    {
        bool sonuc = false;
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@KullaniciID", f.Id), new SqlParameter("@Adi", f.Adi), new SqlParameter("@Soyadi", f.Soyadi), new SqlParameter("@Email", f.Email), new SqlParameter("@Sifre", f.Sifre), new SqlParameter("@TelNo", f.Telefon), new SqlParameter("@Durum", f.Durum), new SqlParameter("@roleID", f.RoleId) };

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
    public void UsersYonetimGuncelle(UsersYonetimInfo f)
    {
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@KullaniciID", f.Id), new SqlParameter("@Adi", f.Adi), new SqlParameter("@Soyadi", f.Soyadi), new SqlParameter("@Email", f.Email), new SqlParameter("@Sifre", f.Sifre), new SqlParameter("@TelNo", f.Telefon), new SqlParameter("@Durum", f.Durum), new SqlParameter("@roleID", f.RoleId) };

        string spName = "Update_User";
        try
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
        }
        catch (Exception ex)
        {

        }
    }
}
