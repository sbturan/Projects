using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

[DataObjectAttribute]
public class IcerikBLL
{
    public IcerikBLL() { }

    #region Select Type Operations
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public IcerikInfo GetBilgiByID(int ID,string dil)
    {
        IcerikDAL dal = new IcerikDAL();
        IcerikInfo info = dal.GetBilgiByID(ID,dil);
        dal = null;
        return info;
    }
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<IcerikInfo> GetList(bool dropdown)
    {
        IcerikDAL dal = new IcerikDAL();
        List<IcerikInfo> list = dal.GetList();
        dal = null;

        if (dropdown)
        {
            IcerikInfo info = new IcerikInfo();
            info.ID = 0;

            list.Insert(0, info);
        }

        return list;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<IcerikInfo> GetTumList()
    {
        IcerikDAL dal = new IcerikDAL();
        List<IcerikInfo> info = dal.GetTumList();
        dal = null;
        return info;
    }
   

    #region Insert / Update / Delete Operations
    [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
    public int Insert(IcerikInfo info)
    {
        IcerikDAL dal = new IcerikDAL();
        int ID = dal.Insert(info);
        dal = null;
        return ID;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
    public void Update(IcerikInfo info)
    {
        IcerikDAL dal = new IcerikDAL();
        dal.Update(info);
        dal = null;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
    public void Delete(IcerikInfo info)
    {
        IcerikDAL dal = new IcerikDAL();
        dal.Delete(info);
        dal = null;
    }
    #endregion

    #endregion


    
    
}
