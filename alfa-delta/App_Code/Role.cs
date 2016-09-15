using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AlfaDeltaLogin
{
    public class Role
    {
        private int roleID;
        private string roleName;
        private string connectionStr;

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings
                ["MSSqlConnString"].ConnectionString;
        }

        public Role()
        {
            connectionStr = GetConnectionString();
        }

        public Role(int roleID)
        {
            connectionStr = GetConnectionString();

            SqlConnection connection = new SqlConnection(connectionStr);
            DataSet dataSet = new DataSet();

            connection.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("Get_RoleDetails", connection);
            command.Parameters.AddWithValue("@RoleID", roleID);
            command.CommandType = CommandType.StoredProcedure;

            adapter.SelectCommand = command;
            adapter.Fill(dataSet, "Roles");

            command.Dispose();
            adapter.Dispose();
            connection.Close();

            DataRow role = dataSet.Tables["Roles"].Rows[0];
            this.roleID = (int)role["RoleID"];
            this.roleName = (string)role["RoleName"];

            dataSet.Dispose();
        }

        public static DataSet GetRoles()
        {
            string connectionStr = GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionStr);
            DataSet dataSet = new DataSet();

            connection.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("Get_Roles", connection);

            adapter.SelectCommand = command;
            adapter.Fill(dataSet, "Roles");

            command.Dispose();
            adapter.Dispose();
            connection.Close();

            return dataSet;
        }

        public int Add()
        {
            int rowsAffected;
            SqlConnection connection = new SqlConnection(connectionStr);
            SqlCommand command = new SqlCommand("Create_Role", connection);

            command.Parameters.AddWithValue("@RoleName", roleName);
            command.CommandType = CommandType.StoredProcedure;

            connection.Open();

            rowsAffected = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();

            return rowsAffected;
        }

        public bool Update()
        {
            int rowsAffected;
            SqlConnection connection = new SqlConnection(connectionStr);
            SqlCommand command = new SqlCommand("Update_Role", connection);

            command.Parameters.AddWithValue("@RoleID", roleID);
            command.Parameters.AddWithValue("@RoleName", roleName);
            command.CommandType = CommandType.StoredProcedure;

            connection.Open();
            rowsAffected = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();

            return (rowsAffected == 1);
        }

        public bool Delete()
        {
            int rowsAffected;
            SqlConnection connection = new SqlConnection(connectionStr);
            SqlCommand command = new SqlCommand("Delete_Role", connection);
            command.Parameters.AddWithValue("@RoleID", roleID);
            command.CommandType = CommandType.StoredProcedure;

            connection.Open();
            rowsAffected = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();

            return (rowsAffected == 1);
        }

        // Properties
        public int RoleID
        {
            get { return roleID; }
            set { roleID = value; }
        }

        public string RoleName
        {
            get { return roleName; }
            set { roleName = value; }
        }
    }

}