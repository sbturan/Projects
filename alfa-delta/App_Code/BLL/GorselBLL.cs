using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
[DataObjectAttribute]
public class GorselBLL
{
    public GorselBLL() { }

    #region Select Type Operations
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<GorselInfo> GetList(bool dropdown,int tur)
    {
        GorselDAL dal = new GorselDAL();
        List<GorselInfo> list = dal.GetList(SqlInject.InjectionManager.RejectInjection(tur));
        dal = null;

        if (dropdown)
        {
            GorselInfo info = new GorselInfo();
            info.ID = 0;
            //info.Name = "Select...";
            list.Insert(0, info);
        }

        return list;
    }
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public DataTable GetListByYayinYeriDT(int TUR, string DIL, int TIP_ID, string YAYIN_YERI, int UST_ID)
    {
        DataTable dt = new DataTable();
        GorselDAL dal = new GorselDAL();
        dt = dal.GetByYayinYeriDT(SqlInject.InjectionManager.RejectInjection(TUR),
            SqlInject.InjectionManager.RejectInjection(DIL),
            SqlInject.InjectionManager.RejectInjection(TIP_ID),
            SqlInject.InjectionManager.RejectInjection(YAYIN_YERI),
            SqlInject.InjectionManager.RejectInjection(UST_ID));
        dal = null;

        return dt;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<GorselInfo> GetListById(int ID, int YAYIN_DURUMU)
    {
        GorselDAL dal = new GorselDAL();
        List<GorselInfo> list = dal.GetByID(SqlInject.InjectionManager.RejectInjection(ID), 
            SqlInject.InjectionManager.RejectInjection(YAYIN_DURUMU));
        dal = null;

        return list;
    }

  
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<GorselInfo> GetListByTip(int TIP_ID,int UST_ID,int TUR,int YAYIN_DURUMU)
    {
        GorselDAL dal = new GorselDAL();
        List<GorselInfo> list = dal.GetListByTip(SqlInject.InjectionManager.RejectInjection(TIP_ID),
            SqlInject.InjectionManager.RejectInjection(UST_ID),
            SqlInject.InjectionManager.RejectInjection(TUR),
            SqlInject.InjectionManager.RejectInjection(YAYIN_DURUMU));
        dal = null;

        return list;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<GorselInfo> GetListByMasterId(int MASTER_ID, int YAYIN_DURUMU)
    {
        GorselDAL dal = new GorselDAL();
        List<GorselInfo> list = dal.GetListByMasterId(SqlInject.InjectionManager.RejectInjection(MASTER_ID), 
            SqlInject.InjectionManager.RejectInjection(YAYIN_DURUMU));
        dal = null;

        return list;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<GorselInfo> GetListByDil(int TUR,string DIL)
    {
        GorselDAL dal = new GorselDAL();
        List<GorselInfo> list = dal.GetListByDil(SqlInject.InjectionManager.RejectInjection(TUR), 
            SqlInject.InjectionManager.RejectInjection(DIL));
        dal = null;

        return list;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<GorselInfo> GetListByYayinYeri(int TUR, string DIL, int TIP_ID, string YAYIN_YERI,int UST_ID)
    {
        GorselDAL dal = new GorselDAL();
        List<GorselInfo> list = dal.GetByYayinYeri(SqlInject.InjectionManager.RejectInjection(TUR), 
            SqlInject.InjectionManager.RejectInjection(DIL), 
            SqlInject.InjectionManager.RejectInjection(TIP_ID), 
            SqlInject.InjectionManager.RejectInjection(YAYIN_YERI),
            SqlInject.InjectionManager.RejectInjection(UST_ID));
        dal = null;

        return list;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<GorselInfo> GetByKullanici(int YAYIN_DURUMU,int EKLEYEN,int TUR)
    {
        GorselDAL dal = new GorselDAL();
        List<GorselInfo> list = dal.GetByKullanici(SqlInject.InjectionManager.RejectInjection(YAYIN_DURUMU), 
            SqlInject.InjectionManager.RejectInjection(EKLEYEN),
            SqlInject.InjectionManager.RejectInjection(TUR));
        dal = null;

        return list;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<GorselInfo> GetListByUstID(int UST_ID)
    {
        GorselDAL dal = new GorselDAL();
        List<GorselInfo> list = dal.GetListByUstID(SqlInject.InjectionManager.RejectInjection(UST_ID));
        dal = null;

        return list;
    }


    #region Insert / Update / Delete Operations
    [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
    public int Insert(GorselInfo info)
    {
        GorselDAL dal = new GorselDAL();
        int ID = dal.Insert(info);
        dal = null;
        return ID;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
    public void Update(GorselInfo info)
    {
        GorselDAL dal = new GorselDAL();
        dal.Update(info);
        dal = null;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
    public void Delete(GorselInfo info)
    {
        GorselDAL dal = new GorselDAL();
        dal.Delete(info);
        dal = null;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
    public void UpdateYayinYeri(GorselInfo info)
    {
        GorselDAL dal = new GorselDAL();
        dal.UpdateYayinYeri(info);
        dal = null;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public GorselInfo GetBilgiByID(int ID, int YAYIN_DURUMU)
    {
        GorselDAL dal = new GorselDAL();
        GorselInfo info = dal.GetBilgiByID(Convert.ToInt32(SqlInject.InjectionManager.RejectInjection(ID.ToString())), 
            SqlInject.InjectionManager.RejectInjection(YAYIN_DURUMU));
        dal = null;
        return info;
    }

    
    #endregion

    #endregion

}
