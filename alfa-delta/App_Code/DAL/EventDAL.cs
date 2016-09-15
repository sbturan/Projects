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
using System.Collections.Generic;
using System.Web.UI.MobileControls;

    public class EventDAL : Core.BaseDataObject
    {
        public List<EventInfo> GetEventByDay(int day, int month,int year)
        {
            List<EventInfo> list = new List<EventInfo>();
            SqlParameter[] spParameter = new SqlParameter[] {  
                new SqlParameter("@OPERATION", "GunlukEtkinlikler"),
                new SqlParameter("@GUN",day),
                new SqlParameter("@HANGIAY",month),
                new SqlParameter("@TARIH",year) };
            string spName = "IcerikDuzenle";

            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
            {
                while (dr.Read())
                {
                    EventInfo info = new EventInfo(dr);
                    list.Add(info);
                }

            }

            return list;
        }
        public List<EventInfo> GetEventByMonth(int month, int year)
        {
            List<EventInfo> list = new List<EventInfo>();
            SqlParameter[] spParameter = new SqlParameter[] {  
                new SqlParameter("@OPERATION", "Aylik_Etkinlikler"),
                new SqlParameter("@HANGIAY",month),
                new SqlParameter("@TARIH",year) };
            string spName = "IcerikDuzenle";

            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
            {
                while (dr.Read())
                {
                    EventInfo info = new EventInfo(dr);
                    list.Add(info);
                }

            }

            return list;
        }
    }
