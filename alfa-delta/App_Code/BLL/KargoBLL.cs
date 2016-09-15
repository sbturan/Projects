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
public class KargoBLL
{
    public KargoBLL()
	{
		
	}

   

  


    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public KargoInfo GetByID(int ID)
    {
        KargoDAL dal = new KargoDAL();
        KargoInfo info = dal.GetByID(SqlInject.InjectionManager.RejectInjection(ID));
        dal = null;
        return info;
    }

        

    #region Insert / Update / Delete Operations
    [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
    public void Insert(KargoInfo info)
    {
        KargoDAL dal = new KargoDAL();
         dal.Insert(info);
        dal = null;
        
    }

   
   
    #endregion





}
