using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using System.Security.Principal;

namespace AlfaDeltaLogin
{
    public class SitePrincipal: IPrincipal
    {
        protected IIdentity identity;
        protected ArrayList roleList;
        private int id;
        private string adi;
        private string soyadi;
        private int cinsiyet;
        private string email;
        private string sifre;
        private string telefon;
        private bool durum;
        private DateTime tarih;
        private string adres;
        private int il;
        private string ilce;
        private int postakodu;
        private string kullanici_adi;
        private int islem_yapan;
       
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings
                 ["MSSqlConnString"].ConnectionString;
        }

        public SitePrincipal(string loginname,string tip)
        {

            identity = new SiteIdentity(loginname,tip);
            roleList = Kullanici.GetUserRoles(((SiteIdentity)identity).ID);
           //Kullanici user = new Kullanici(loginname,tip);

           // this.id = user.Id;
           // this.adi = user.Adi;
           // this.soyadi= user.Soyadi;
           // this.cinsiyet = user.Cinsiyet;
           // this.email = user.Email;
           // this.sifre = user.Sifre;
           // this.telefon = user.Telefon;
           // this.durum = user.Durum;
           // this.tarih = user.Tarih;
           // this.adres = user.Adres;
           // this.il = user.Il;
           // this.ilce = user.Ilce;
           // this.postakodu = user.PostaKodu;
           // this.kullanici_adi = user.Kullanici_Adi;
           // this.islem_yapan = user.Islem_Yapan;
         
           // roleList =Kullanici.GetUserRoles(this.id);
        }

        public SitePrincipal(int id)
        {
           
            
            //Kullanici user = new Kullanici(id);

            //this.id = user.Id;
            //this.adi = user.Adi;
            //this.soyadi = user.Soyadi;
            //this.cinsiyet = user.Cinsiyet;
            //this.email = user.Email;
            //this.sifre = user.Sifre;
            //this.telefon = user.Telefon;
            //this.durum = user.Durum;
            //this.tarih = user.Tarih;
            //this.adres = user.Adres;
            //this.il = user.Il;
            //this.ilce = user.Ilce;
            //this.postakodu = user.PostaKodu;
            //this.kullanici_adi = user.Kullanici_Adi;
            //this.islem_yapan = user.Islem_Yapan;
            
            //roleList = Kullanici.GetUserRoles(this.id);
            identity = new SiteIdentity(id);
            roleList = Kullanici.GetUserRoles(((SiteIdentity)identity).ID);

        }

      


        public static SitePrincipal ValidateLoginByEmail(string email, string sifre)
        {
            int userID;
            string connectionStr = GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionStr);

            connection.Open();

            SqlCommand command = new SqlCommand("ValidateLoginByEmail", connection);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Sifre", sifre);
            // add return value parameter
            command.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4,
                ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
            command.CommandType = CommandType.StoredProcedure;

            command.ExecuteNonQuery();
            userID = (int)command.Parameters["ReturnValue"].Value;

            command.Dispose();
            connection.Close();

            return (userID == 0 ? null : new SitePrincipal(userID));
        }

        public static SitePrincipal ValidateLoginByKullaniciAdi(string kullanici_adi, string sifre)
        {
            int userID;
            string connectionStr = GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionStr);

            connection.Open();

            SqlCommand command = new SqlCommand("ValidateLoginByKullaniciAdi", connection);
            command.Parameters.AddWithValue("@Kullanici_Adi",kullanici_adi);
            command.Parameters.AddWithValue("@sifre", sifre);
            // add return value parameter
            command.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4,
                ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
            command.CommandType = CommandType.StoredProcedure;

            command.ExecuteNonQuery();
            userID = (int)command.Parameters["ReturnValue"].Value;

            command.Dispose();
            connection.Close();

            return (userID == 0 ? null : new SitePrincipal(userID));
        }


        public bool IsInRole(string role)
        {
            return roleList.Contains(role);
        }

        // Properties
        public System.Security.Principal.IIdentity Identity
        {
            get { return identity; }
            set { identity = value; }
        }

        public ArrayList Roles
        {
            get { return roleList; }
        }

        #region IPrincipal Members

        System.Security.Principal.IIdentity System.Security.Principal.IPrincipal.Identity
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        bool System.Security.Principal.IPrincipal.IsInRole(string role)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}