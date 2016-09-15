
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.ComponentModel;

    [DataObjectAttribute]
    public class EventBLL
    {
        public List<EventInfo> GetEventByDate(int day, int month, int year)
        {
            EventDAL eventDAL = new EventDAL();
            List<EventInfo> data = eventDAL.GetEventByDay(day, month, year);
            return data;
        }
        public List<EventInfo> GetEventByMonth(int month, int year)
        {
           EventDAL eventDAL = new EventDAL();
           List<EventInfo> data = eventDAL.GetEventByMonth(month, year);
            return data;
        }
    }
