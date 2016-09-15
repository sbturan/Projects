using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Text;


public class UserRolesDAL : Core.BaseDataObject
{


    public UserRolesDAL() { }
    public UserRolesInfo BulByID(int Id)
    {
        UserRolesInfo myInfo = new UserRolesInfo();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@UserID", Id) };
        string spName = "UserRolesBul ";
        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                UserRolesInfo info = new UserRolesInfo(dr);
                return info;
            }
        }
        return null;
    }
    public UserRolesInfo BulByID(UserRolesInfo entityInfoID)
    {
        UserRolesInfo myInfo = new UserRolesInfo();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@UserID", entityInfoID.UserID) };
        string spName = "UserRolesBul ";
        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                UserRolesInfo info = new UserRolesInfo(dr);
                return info;
            }
        }
        return null;
    }
    public bool UserRolesEkle(UserRolesInfo f)
    {
        bool sonuc = false;
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@UserID", f.UserID), new SqlParameter("@RoleID", f.RoleID), };
        string spName = "UserRolesEkle ";
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
    public int UserRolesEkleReturnID(UserRolesInfo f)
    {
        int sonuc = 0;
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@UserID", f.UserID), new SqlParameter("@RoleID", f.RoleID), };
        string spName = "UserRolesEkle ";
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
    public bool UserRolesSilReturnSonuc(UserRolesInfo f)
    {
        bool sonuc = false;
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@tabloID", f.tabloID) };
        string spName = "UserRolesSil ";
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
    public void UserRolesSil(int silID)
    {
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@tabloID", silID) };
        string spName = "UserRolesSil ";
        try
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
        }
        catch (Exception ex)
        {

        }
    }
    public void UserRolesSil(UserRolesInfo f)
    {
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@tabloID", f.tabloID) };
        string spName = "UserRolesSil ";
        try
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
        }
        catch (Exception ex)
        {

        }
    }
    public DataTable UserRolesGetir()
    {
        SqlConnection cn = new SqlConnection(SqlHelper.CONNECTION_STRING);
        SqlCommand cmd = new SqlCommand("UserRolesGetir", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable d = new DataTable();
        da.Fill(d);
        return d;
    }
    public List<UserRolesInfo> GetirList()
    {
        List<UserRolesInfo> myList = new List<UserRolesInfo>();

        string mySpName = "UserRolesGetir";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, mySpName))
        {
            while (dr.Read())
            {
                UserRolesInfo myEntityInfo = new UserRolesInfo(dr);
                myList.Add(myEntityInfo);
            }
        }
        return myList;
    }
    public bool UserRolesGuncelleReturnSonuc(UserRolesInfo f)
    {
        bool sonuc = false;
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@UserID", f.UserID), new SqlParameter("@RoleID", f.RoleID), new SqlParameter("@tabloID", f.tabloID) };
        string spName = "UserRolesGuncelle ";
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
    public void UserRolesGuncelle(UserRolesInfo f)
    {
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@UserID", f.UserID), new SqlParameter("@RoleID", f.RoleID), new SqlParameter("@tabloID", f.tabloID) };
        string spName = "UserRolesGuncelle ";
        try
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
        }
        catch (Exception ex)
        {

        }
    }
    public UserRolesInfo BulByUserID(int Id)
    {
        UserRolesInfo myInfo = new UserRolesInfo();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@UserID", Id) };
        string spName = "UserRolesBulByUserID";
        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                UserRolesInfo info = new UserRolesInfo(dr);
                return info;
            }
        }
        return null;
    }
}
