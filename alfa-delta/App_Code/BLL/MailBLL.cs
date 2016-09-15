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
public class MailBLL
{
    public MailBLL()
    {

    }





    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public MailInfo Getmail()
    {
        MailDAL dal = new MailDAL();
        MailInfo info = dal.Getmail();
        dal = null;
        return info;

    }

   

    

    #region Insert  Operations
    [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
    public int Insert(MailInfo info)
    {
        MailDAL dal = new MailDAL();
        int ID = dal.Insert(info);
        dal = null;
        return ID;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
    public void Update(MailInfo info)
    {
        MailDAL dal = new MailDAL();
        dal.Update(info);
        dal = null;
    }


    #endregion





}
