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
public class ParaalBLL
{
    public ParaalBLL()
    {

    }





    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public ParaalInfo GetKur()
    {
        ParaalDAL dal = new ParaalDAL();
        ParaalInfo info = dal.GetKur();
        dal = null;
        return info;

    }

   

    

    #region Insert  Operations
    [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
    public int Insert(ParaalInfo info)
    {
        ParaalDAL dal = new ParaalDAL();
        int ID = dal.Insert(info);
        dal = null;
        return ID;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
    public void Update(ParaalInfo info)
    {
        ParaalDAL dal = new ParaalDAL();
        dal.Update(info);
        dal = null;
    }
    public void Delete(ParaalInfo info)
    {
        ParaalDAL dal = new ParaalDAL();
        dal.Delete(info);
        dal = null;
    }


    #endregion





}
