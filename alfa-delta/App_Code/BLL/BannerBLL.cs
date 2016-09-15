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
public class BannerBLL
{
	public BannerBLL()
	{
		
	}

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<BannerInfo> GetTumBannerlar()
    {
        BannerDAL dal = new BannerDAL();
        List<BannerInfo> list = dal.GetTumBannerlar();
        dal = null;

        return list;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<BannerInfo> GetTipveYayinYeri(int Tip, int YayinYeri, bool Durum)
    {
        BannerDAL dal = new BannerDAL();
        List<BannerInfo> list = dal.GetTipveYayinYeri(SqlInject.InjectionManager.RejectInjection(Tip),
            SqlInject.InjectionManager.RejectInjection(YayinYeri),
            SqlInject.InjectionManager.RejectInjection(Durum));
        dal = null;

        return list;
    }


    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public BannerInfo GetBannerByID(int ID)
    {
        BannerDAL dal = new BannerDAL();
        BannerInfo info = dal.GetBannerByID(SqlInject.InjectionManager.RejectInjection(ID));
        dal = null;
        return info;
    }

        

    #region Insert / Update / Delete Operations
    [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
    public int Insert(BannerInfo info)
    {
        BannerDAL dal = new BannerDAL();
        int ID = dal.Insert(info);
        dal = null;
        return ID;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
    public void Update(BannerInfo info)
    {
        BannerDAL dal = new BannerDAL();
        dal.Update(info);
        dal = null;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
    public void Delete(BannerInfo info)
    {
        BannerDAL dal = new BannerDAL();
        dal.Delete(info);
        dal = null;
    }

    #endregion





}
