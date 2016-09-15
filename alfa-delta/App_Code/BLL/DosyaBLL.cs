using System;
using System.Collections.Generic;
using System.ComponentModel;

[DataObjectAttribute]
public class DosyaBLL
{
    public DosyaBLL() { }

    #region Select Type Operations
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<DosyaInfo> GetList(bool dropdown)
    {
        DosyaDAL dal = new DosyaDAL();
        List<DosyaInfo> list = dal.GetList();
        dal = null;

        if (dropdown)
        {
            DosyaInfo info = new DosyaInfo();
            info.ID = 0;
            //info.Name = "Select...";
            list.Insert(0, info);
        }

        return list;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public DosyaInfo GetBilgiByID(int ID)
    {
        DosyaDAL dal = new DosyaDAL();
        DosyaInfo info = dal.GetBilgiByID(SqlInject.InjectionManager.RejectInjection(ID));
        dal = null;
        return info;
    }


    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<DosyaInfo> GetListById(int ID)
    {
        DosyaDAL dal = new DosyaDAL();
        List<DosyaInfo> list = dal.GetByID(SqlInject.InjectionManager.RejectInjection(ID));
        dal = null;

        return list;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<DosyaInfo> GetListByTur(int TUR)
    {
        DosyaDAL dal = new DosyaDAL();
        List<DosyaInfo> list = dal.GetListByTur(SqlInject.InjectionManager.RejectInjection(TUR));
        dal = null;

        return list;
    }

  
    #region Insert / Update / Delete Operations
    [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
    public int Insert(DosyaInfo info)
    {
        DosyaDAL dal = new DosyaDAL();
        int ID = dal.Insert(info);
        dal = null;
        return ID;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
    public void Update(DosyaInfo info)
    {
        DosyaDAL dal = new DosyaDAL();
        dal.Update(info);
        dal = null;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
    public void Delete(DosyaInfo info)
    {
        DosyaDAL dal = new DosyaDAL();
        dal.Delete(info);
        dal = null;
    }

    
    #endregion

    #endregion


}
