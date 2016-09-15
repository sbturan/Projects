using System;
using System.Collections.Generic;
using System.ComponentModel;

[DataObjectAttribute]
public class IkBLL
{
    public IkBLL() { }

    #region Select Type Operations
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<IkInfo> GetList(bool dropdown,int YAYIN_DURUMU)
    {
        IkDAL dal = new IkDAL();
        List<IkInfo> list = dal.GetList(SqlInject.InjectionManager.RejectInjection(YAYIN_DURUMU));
        dal = null;

        if (dropdown)
        {
            IkInfo info = new IkInfo();
            info.ID = 0;
            info.KONU = "Select...";
            list.Insert(0, info);
        }

        return list;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<IkInfo> GetListById(int ID, int YAYIN_DURUMU)
    {
        IkDAL dal = new IkDAL();
        List<IkInfo> list = dal.GetByID(SqlInject.InjectionManager.RejectInjection(ID), 
            SqlInject.InjectionManager.RejectInjection(YAYIN_DURUMU));
        dal = null;

        return list;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public IkInfo GetBilgiByID(int ID, int YAYIN_DURUMU)
    {
        IkDAL dal = new IkDAL();
        IkInfo info = dal.GetBilgiByID(SqlInject.InjectionManager.RejectInjection(ID), SqlInject.InjectionManager.RejectInjection(YAYIN_DURUMU));
        dal = null;
        return info;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<IkInfo> GetBilgiByDil(string DIL, int YAYIN_DURUMU)
    {
        IkDAL dal = new IkDAL();
        List<IkInfo> list = dal.GetByDil(SqlInject.InjectionManager.RejectInjection(DIL), 
            SqlInject.InjectionManager.RejectInjection(YAYIN_DURUMU));
        dal = null;

        return list;
    }
  
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<IkInfo> GetListByMasterId(int MASTER_ID,int YAYIN_DURUMU)
    {
        IkDAL dal = new IkDAL();
        List<IkInfo> list = dal.GetByMasterID(SqlInject.InjectionManager.RejectInjection(MASTER_ID),
            SqlInject.InjectionManager.RejectInjection(YAYIN_DURUMU));
        dal = null;

        return list;
    }

    #region Insert / Update / Delete Operations
    [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
    public int Insert(IkInfo info)
    {
        IkDAL dal = new IkDAL();
        int ID = dal.Insert(info);
        dal = null;
        return ID;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
    public void Update(IkInfo info)
    {
        IkDAL dal = new IkDAL();
        dal.Update(info);
        dal = null;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
    public void Delete(IkInfo info)
    {
        IkDAL dal = new IkDAL();
        dal.Delete(info);
        dal = null;
    }
    #endregion

    #endregion

}
