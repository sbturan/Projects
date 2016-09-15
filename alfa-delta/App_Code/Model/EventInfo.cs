using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

[Serializable]

    public class EventInfo
    {
     #region Member Variables
        private int Id;
        private string Foto;
        private string Konu;
                
     #endregion
        #region Constructors
        public EventInfo() { }
        public EventInfo(int id, string foto, string konu)
        {
            this.Id = id;
            this.Foto = foto;
            this.Konu = konu;
        }
        public EventInfo(SqlDataReader dr)
        {
            this.Id = DataReader.GetInt32(dr["id"]);
            this.Foto = DataReader.GetString(dr["foto"]);
            this.Konu = DataReader.GetString(dr["konu"]);
        }
        #endregion

        #region Properties
        public int ID
        {
            get { return Id; }
            set { Id= value; }
        }
        public string KONU 
        {
            get { return Konu; }
            set { Konu = value; }
        }
        public string FOTO
        {
            get { return Foto; }
            set { Foto = value; }
        }

        #endregion


    }
