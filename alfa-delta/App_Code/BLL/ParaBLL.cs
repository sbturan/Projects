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
public class ParaBLL
{
    public ParaBLL()
	{
		
	}

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<ParaInfo> GetTumBirimler()
    {
        ParaDAL dal = new ParaDAL();
        List<ParaInfo> list = dal.GetTumBirimler();
        dal = null;

        return list;
    }

  


    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public ParaInfo GetParaByID(int ID)
    {
        ParaDAL dal = new ParaDAL();
        ParaInfo info = dal.GetParaByID(SqlInject.InjectionManager.RejectInjection(ID));
        dal = null;
        return info;
    }

        

    #region Insert / Update / Delete Operations
    [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
    public int Insert(ParaInfo info)
    {
        ParaDAL dal = new ParaDAL();
        int ID = dal.Insert(info);
        dal = null;
        return ID;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
    public void Update(ParaInfo info)
    {
        ParaDAL dal = new ParaDAL();
        dal.Update(info);
        dal = null;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
    public void Delete(ParaInfo info)
    {
        ParaDAL dal = new ParaDAL();
        dal.Delete(info);
        dal = null;
    }

    #endregion





}
