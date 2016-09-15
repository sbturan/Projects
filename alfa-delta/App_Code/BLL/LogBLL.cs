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
public class LogBLL
{
    public LogBLL()
    {

    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<LogInfo> GetTumLoglar()
    {
        LogDAL dal = new LogDAL();
        List<LogInfo> list = dal.GetTumLoglar();
        dal = null;

        return list;
    }




    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public LogInfo GetLogByID(int ID)
    {
        LogDAL dal = new LogDAL();
        LogInfo info = dal.GetLogByID(SqlInject.InjectionManager.RejectInjection(ID));
        dal = null;
        return info;

    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<LogInfo> GetLogByKullaniciID(int ID)
    {
        LogDAL dal = new LogDAL();
        List<LogInfo> list = dal.GetLogByKullaniciID(SqlInject.InjectionManager.RejectInjection(ID));
        dal = null;
        return list;

    }

    #region Insert  Operations
    [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
    public int Insert(LogInfo info)
    {
        LogDAL dal = new LogDAL();
        int ID = dal.Insert(info);
        dal = null;
        return ID;
    }


    #endregion





}
