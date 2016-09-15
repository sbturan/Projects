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

/// <summary>
/// Summary description for bannerBLL
/// </summary>

[DataObjectAttribute]
public class KategoriBLL
{
    public KategoriBLL()
	{
		
	}

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<KategoriInfo> GetKategoriler()
    {
        KategoriDAL dal = new KategoriDAL();
        List<KategoriInfo> list = dal.GetKategoriler();
        dal = null;

        return list;
    }


    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<KategoriInfo> GetAltKategoriler(int ID,string dil)
    {
        KategoriDAL dal = new KategoriDAL();
        List<KategoriInfo> list = dal.GetAltKategoriler(ID,dil);
        dal = null;
       
            return list;
        
        
        
    }

    


    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public KategoriInfo GetKategoriByID(int ID)
    {
        KategoriDAL dal = new KategoriDAL();
        KategoriInfo info = dal.GetKategoriByID(SqlInject.InjectionManager.RejectInjection(ID));
        dal = null;
        return info;
    }

        

    #region Insert / Update / Delete Operations
    [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
    public int Insert(KategoriInfo info)
    {
        KategoriDAL dal = new KategoriDAL();
        int ID = dal.Insert(info);
        dal = null;
        return ID;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
    public void Update(KategoriInfo info)
    {
        KategoriDAL dal = new KategoriDAL();
        dal.Update(info);
        dal = null;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
    public void Delete(KategoriInfo info)
    {
        KategoriDAL dal = new KategoriDAL();
        dal.Delete(info);
        dal = null;
    }

    #endregion





}
