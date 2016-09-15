using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Text;


public class Users1DAL : Core.BaseDataObject
{


    public Users1DAL() { }
    public Users1Info BulByID(int Id)
    {
        Users1Info myInfo = new Users1Info();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@UserID", Id) };
        string spName = "Get_UserDetails";
        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                Users1Info info = new Users1Info(dr);
                return info;
            }
        }
        return null;
    }
    public Users1Info BulByEmailID(string email)
    {
        List<Users1Info> list = new List<Users1Info>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@Email", email) };
        string spName = "Get_UserDetailsFromEmail";
        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                Users1Info info = new Users1Info(dr);
                return info;
            }
        }
        return null;
    }
   
    public Users1Info BulByID(Users1Info entityInfoID)
    {
        Users1Info myInfo = new Users1Info();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@Id", entityInfoID.Id) };
        string spName = "UsersBul";
        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                Users1Info info = new Users1Info(dr);
                return info;
            }
        }
        return null;
    }
    public bool UsersEkle(Users1Info f)
    {
        bool sonuc = false;
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@Adi", f.Adi), new SqlParameter("@Para_kontrol", f.PARA_KONTROL), new SqlParameter("@Soyadi", f.Soyadi), new SqlParameter("@Email", f.Email), new SqlParameter("@Sifre", f.Sifre), new SqlParameter("@Telefon", f.Telefon), new SqlParameter("@Durum", f.Durum), new SqlParameter("@RoleId", f.RoleId) };
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
    public int UsersEkleReturnID(Users1Info f)
    {
        int sonuc = 0;
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@Adi", f.Adi), new SqlParameter("@Para_kontrol", f.PARA_KONTROL), new SqlParameter("@Soyadi", f.Soyadi), new SqlParameter("@Email", f.Email), new SqlParameter("@Sifre", f.Sifre), new SqlParameter("@TelNo", f.Telefon), new SqlParameter("@Durum", f.Durum), new SqlParameter("@RoleId", f.RoleId) };
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
    public int UsersEkleReturnID1(Users1Info f)
    {
        int sonuc = 0;
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@Adi", f.Adi), new SqlParameter("@Soyadi", f.Soyadi), new SqlParameter("@Email", f.Email), new SqlParameter("@Sifre", f.Sifre), new SqlParameter("@TelNo", f.Telefon), new SqlParameter("@Durum", f.Durum), new SqlParameter("@RoleId", f.RoleId) };
        string spName = "Create_User1";
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
    public bool UsersSilReturnSonuc(Users1Info f)
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
    public void UsersSil(Users1Info f)
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
    public List<Users1Info> GetirList()
    {
        List<Users1Info> myList = new List<Users1Info>();

        string mySpName = "Get_Users";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, mySpName))
        {
            while (dr.Read())
            {
                Users1Info myEntityInfo = new Users1Info(dr);
                myList.Add(myEntityInfo);
            }
        }
        return myList;
    }
    public bool UsersGuncelleReturnSonuc(Users1Info f)
    {
        bool sonuc = false;
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@KullaniciID", f.Id), new SqlParameter("@Parakontrol", f.PARA_KONTROL), new SqlParameter("@Adi", f.Adi), new SqlParameter("@Soyadi", f.Soyadi), new SqlParameter("@Email", f.Email), new SqlParameter("@Sifre", f.Sifre), new SqlParameter("@Telefon", f.Telefon), new SqlParameter("@Durum", f.Durum), new SqlParameter("@roleID", f.RoleId) };

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
    public void UsersGuncelle(Users1Info f)
    {
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@KullaniciID", f.Id), new SqlParameter("@Para_kontrol", f.PARA_KONTROL), new SqlParameter("@Adi", f.Adi), new SqlParameter("@Soyadi", f.Soyadi), new SqlParameter("@Email", f.Email), new SqlParameter("@Sifre", f.Sifre), new SqlParameter("@TelNo", f.Telefon), new SqlParameter("@Durum", f.Durum), new SqlParameter("@roleID", f.RoleId) };

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
