using System;
using System.Collections.Generic;
using System.ComponentModel;

[DataObjectAttribute]
public class IkDetayBLL
{
    public IkDetayBLL() { }

    #region Select Type Operations
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<IkDetayInfo> GetList()
    {
        IkDetayDAL dal = new IkDetayDAL();
        List<IkDetayInfo> list = dal.GetList();
        dal = null;

       

        return list;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public IkDetayInfo GetBilgiByID(int ID)
    {
        IkDetayDAL dal = new IkDetayDAL();
        IkDetayInfo info = dal.GetBilgiByID(SqlInject.InjectionManager.RejectInjection(ID));
        dal = null;
        return info;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<IkDetayInfo> GetListById(int ID)
    {
        IkDetayDAL dal = new IkDetayDAL();
        List<IkDetayInfo> list = dal.GetByID(SqlInject.InjectionManager.RejectInjection(ID));
        dal = null;

        return list;
    }

   

   
  
   

    #region Insert / Update / Delete Operations
    [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
    public int Insert(IkDetayInfo info)
    {
        IkDetayDAL dal = new IkDetayDAL();
        int ID = dal.Insert(info);
        dal = null;
        return ID;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
    public void Update(IkDetayInfo info)
    {
        IkDetayDAL dal = new IkDetayDAL();
        dal.Update(info);
        dal = null;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
    public void Delete(int id)
    {
        IkDetayDAL dal = new IkDetayDAL();
        dal.Delete(id);
        dal = null;
    }

   
    #endregion

    #endregion


    public IkDetayInfo GetBilgiById(int p)
    {
        throw new NotImplementedException();
    }
}
