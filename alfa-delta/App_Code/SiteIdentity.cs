using System;
using System.Data;
using System.Data.SqlClient;

namespace AlfaDeltaLogin
{
	public class SiteIdentity: System.Security.Principal.IIdentity
	{
		private int id;
		private string kullanici_adi;
		private string email;
		private string sifre;
		
		public SiteIdentity(string loginname,string logintype)
		{
			Kullanici user = new Kullanici(loginname,logintype);

			this.id = user.Id;
			this.kullanici_adi = user.Adi;
			this.email = user.Email;
			this.sifre = user.Sifre;
		}

		public SiteIdentity( int userID )
		{
            Kullanici user = new Kullanici(userID);


            this.id = user.Id;
            this.kullanici_adi = user.Adi;
            this.email = user.Email;
            this.sifre = user.Sifre;
		}

		// Properties
		public string AuthenticationType
		{
			get { return "Custom Authentication"; }
		}

		public bool IsAuthenticated
		{
			get 
			{
				// assumption: all instances of a SiteIdentity have already
				// been authenticated.
				return true;
			}
		}

		public int ID
		{
			get { return id; }
		}

		
		public string Email
		{
			get { return email; }
		}				

		public string Sifre
		{
			get { return sifre; }
		}

        #region IIdentity Members


        public string Name
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion
    }
}
