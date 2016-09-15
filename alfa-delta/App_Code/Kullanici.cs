using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

namespace AlfaDeltaLogin
{
	public class Kullanici
	{
		private int id;
		private string adi;
		private string soyadi;
        private int para_kontrol;
		private string email;
        private string sifre;
        private string telefon;
        private bool durum;
       
        private int roleId;
		private string connectionStr;

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings
                ["MSSqlConnString"].ConnectionString;
        }

		public Kullanici()
		{
            connectionStr = GetConnectionString();
		}

		public Kullanici(int userID)
		{
            connectionStr = GetConnectionString();
			SqlConnection connection = new SqlConnection(connectionStr);
			DataTable dataTB = new DataTable();

			connection.Open();

			SqlDataAdapter adapter = new SqlDataAdapter();
			SqlCommand command = new SqlCommand("Get_UserDetails", connection);
			command.Parameters.AddWithValue("@UserID", userID);
			command.CommandType = CommandType.StoredProcedure;

			adapter.SelectCommand = command;
			adapter.Fill(dataTB);

			command.Dispose();
			adapter.Dispose();
			connection.Close();

            if (dataTB.Rows.Count > 0)
            {
                LoadDetails(dataTB.Rows[0]);
            }
			dataTB.Dispose();
		}

		public Kullanici(string loginname,string logintype)
		{
            connectionStr= GetConnectionString();
			SqlConnection connection = new SqlConnection(connectionStr);
			DataTable dataTB = new DataTable();

			connection.Open();

           
            SqlDataAdapter adapter = new SqlDataAdapter();
            if (logintype == "EMAIL")
            {
                SqlCommand command = new SqlCommand("Get_UserDetailsFromEmail", connection);
                command.Parameters.AddWithValue("@Email", loginname);
                command.CommandType = CommandType.StoredProcedure;

                adapter.SelectCommand = command;
                adapter.Fill(dataTB);

                command.Dispose();
                adapter.Dispose();
                connection.Close();
            }
            else
            {
                SqlCommand command = new SqlCommand("Get_UserDetailsFromUserName", connection);
                command.Parameters.AddWithValue("@USERNAME", loginname);
                command.CommandType = CommandType.StoredProcedure;

                adapter.SelectCommand = command;
                adapter.Fill(dataTB);

                command.Dispose();
                adapter.Dispose();
                connection.Close();
            }
            if (dataTB.Rows.Count > 0)
            {
                LoadDetails(dataTB.Rows[0]);
            }
			dataTB.Dispose();
		}

		private void LoadDetails (DataRow user)
		{
            
			Id = (int)user["KullaniciID"];
			Adi=(string)user["KullaniciAdi"];
            Soyadi=(string)user["KullaniciSoyad"];
		    Email=(string)user["Email"];
            Sifre=(string)user["Sifre"];
            Telefon=(string)user["TelNo"];
            PARA_KONTROL = (int)user["para_kontrol"];
            Durum=(bool)user["Durum"];
           
            roleId = (int)user["roleId"];
            
		}

		// static method that returns all the users in database
		public static DataSet GetUsers()
		{
            string connectionStr = GetConnectionString();
			SqlConnection connection = new SqlConnection(connectionStr);
			DataSet dataSet = new DataSet();

			connection.Open();

			SqlDataAdapter adapter = new SqlDataAdapter();
			SqlCommand command = new SqlCommand("Get_Users", connection);
			
			adapter.SelectCommand = command;
			adapter.Fill(dataSet, "kullanicilar");

			command.Dispose();
			adapter.Dispose();
			connection.Close();

			return dataSet;
		}


  

        public static bool UserInRole(int userID,string role)
        {
            bool status = false;
            ArrayList roles = new ArrayList();

            string connectionStr = GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionStr);

            connection.Open();

            SqlCommand command = new SqlCommand("Get_UserRoles", connection);
            command.Parameters.AddWithValue("@UserID", userID);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
                roles.Add(reader.GetString(1));
            
            reader.Close();

            if (roles.Count > 0)
            {

                for (int r = 0; r < roles.Count; r++)
                {
                    if (roles[r].ToString() == role)
                    {
                        status = true;
                        break;

                    }
                }
            }

                connection.Close();
            return status;
        }


		public static ArrayList GetUserRoles(int userID)
		{
			ArrayList roles = new ArrayList();

            string connectionStr = GetConnectionString();
			SqlConnection connection = new SqlConnection(connectionStr);

			connection.Open();

			SqlCommand command = new SqlCommand("Get_UserRoles", connection);
			command.Parameters.AddWithValue("@UserID", userID);
			command.CommandType = CommandType.StoredProcedure;
			SqlDataReader reader = command.ExecuteReader();

			while (reader.Read())
				roles.Add(reader.GetString(1));

			reader.Close();
			connection.Close();
			return roles;
		}

        public static DataTable GetRoleUsers(string RoleNAME)
        {
            DataTable dtb_Role = new DataTable();

            string connectionStr = GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionStr);

            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("Get_RoleUsers", connection);
            command.Parameters.AddWithValue("@RoleNAME",RoleNAME);
            command.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand = command;
            adapter.Fill(dtb_Role);

            command.Dispose();
            adapter.Dispose();
            connection.Close();
            return dtb_Role;
        }

		public DataSet GetRoles()
		{
            connectionStr = GetConnectionString();
			SqlConnection connection = new SqlConnection(connectionStr);
			DataSet dataSet = new DataSet();

			connection.Open();

			SqlDataAdapter adapter = new SqlDataAdapter();
			SqlCommand command = new SqlCommand("Get_UserRoles", connection);
			command.Parameters.AddWithValue("@UserID",id);
			command.CommandType = CommandType.StoredProcedure;
			
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
			SqlCommand command = new SqlCommand("Create_User", connection);

            command.Parameters.AddWithValue("@Adi",adi);
            command.Parameters.AddWithValue("@Soyadi", soyadi);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Sifre", sifre);
            command.Parameters.AddWithValue("@TelNo",telefon);
            command.Parameters.AddWithValue("@Durum", durum);
            command.Parameters.AddWithValue("@Para_kontrol", para_kontrol);
            command.Parameters.AddWithValue("@RoleId", roleId);
			command.CommandType = CommandType.StoredProcedure;

			connection.Open();
			
			try 
            {
            //    command.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4,
            //    ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
            //    command.CommandType = CommandType.StoredProcedure;

                rowsAffected = Convert.ToInt32(command.ExecuteScalar());//(int)command.Parameters["ReturnValue"].Value;
			}
			catch (SqlException sqle)
			{
				// exception returns 2627 means that the email address 
				// has already been registerd
                if (sqle.Number == 2601)
                    return -1;
                else
                    throw sqle;
			}
			finally
			{
				command.Dispose();
				connection.Close();
			}

			return rowsAffected;
		}

		public bool Update()
		{
			int rowsAffected;
			SqlConnection connection = new SqlConnection(connectionStr);
			SqlCommand command = new SqlCommand("Update_User", connection);
            command.Parameters.AddWithValue("@Adi", adi);
            command.Parameters.AddWithValue("@Soyadi", soyadi);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Sifre", sifre);
            command.Parameters.AddWithValue("@TelNo", telefon);
            command.Parameters.AddWithValue("@Durum", durum);
            command.Parameters.AddWithValue("@KullaniciID", id);
            command.Parameters.AddWithValue("@Para_kontrol", para_kontrol);
            command.Parameters.AddWithValue("@RoleId", roleId); 
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
			SqlCommand command = new SqlCommand("Delete_User", connection);
			command.Parameters.AddWithValue("@UserID", id);
			command.CommandType = CommandType.StoredProcedure;

			connection.Open();
			rowsAffected = command.ExecuteNonQuery();
			command.Dispose();
			connection.Close();

			return (rowsAffected == 1);
		}

		public bool AddToRole(int roleID)
		{
			int rowsAffected;
			SqlConnection connection = new SqlConnection(connectionStr);
			SqlCommand command = new SqlCommand("AddUserToRole", connection);
			command.Parameters.AddWithValue("@UserID", id);
			command.Parameters.AddWithValue("@RoleID", roleID);
			command.CommandType = CommandType.StoredProcedure;

			connection.Open();
			rowsAffected = command.ExecuteNonQuery();
			command.Dispose();
			connection.Close();

			return (rowsAffected == 1);
		}

		public bool RemoveFromRole(int roleID)
		{
			int rowsAffected;
			SqlConnection connection = new SqlConnection(connectionStr);
			SqlCommand command = new SqlCommand("RemoveUserFromRole", connection);
			command.Parameters.AddWithValue("@UserID", id);
			command.Parameters.AddWithValue("@RoleID", roleID);
			command.CommandType = CommandType.StoredProcedure;

			connection.Open();
			rowsAffected = command.ExecuteNonQuery();
			command.Dispose();
			connection.Close();

			return (rowsAffected == 1);	
		}

		// Properties
		public int Id
		{
			get { return id; }
			set { id= value; }
		}
        public int PARA_KONTROL
        {
            get { return para_kontrol; }
            set { para_kontrol = value; }
        }

		public string Adi
		{
			get { return adi; }
			set { adi= value; }
		}

		public string Soyadi
		{
			get { return soyadi; }
			set { soyadi = value; }
		}

        
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

		public string Sifre
		{
			get { return sifre; }
			set { sifre = value; }
		}

		public string Telefon
		{
			get { return telefon; }
			set { telefon = value; }
		}

        public bool Durum
        {
            get { return durum; }
            set { durum = value; }
        }

       
        public int RoleId
        {
            get { return roleId; }
            set { roleId = value; }
        }


	}
}
