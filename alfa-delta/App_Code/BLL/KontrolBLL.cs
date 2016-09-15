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
public class KontrolBLL
{
    public KontrolBLL()
	{
		
	}

   

  


    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public KontrolInfo GetByID(int ID)
    {
        KontrolDAL dal = new KontrolDAL();
        KontrolInfo info = dal.GetByID(SqlInject.InjectionManager.RejectInjection(ID));
        dal = null;
        return info;
    }

        

    #region Insert / Update / Delete Operations
    [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
    public void Insert(KontrolInfo info)
    {
        KontrolDAL dal = new KontrolDAL();
         dal.Insert(info);
        dal = null;
        
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
    public void Update(KontrolInfo info)
    {
        KontrolDAL dal = new KontrolDAL();
        dal.Update(info);
        dal = null;
    }

   
    #endregion





}
