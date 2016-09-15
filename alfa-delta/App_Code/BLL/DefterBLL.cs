using System;
using System.Collections.Generic;
using System.ComponentModel;

[DataObjectAttribute]
public class DefterBLL
{
    public DefterBLL() { }

    #region Select Type Operations
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<DefterInfo> GetList(int YAYIN_DURUMU)
    {
        DefterDAL dal = new DefterDAL();
        List<DefterInfo> list = dal.GetList(Convert.ToInt32(SqlInject.InjectionManager.RejectInjection(YAYIN_DURUMU)));
        dal = null;
        return list;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<DefterInfo> GetById(int ID, int YAYIN_DURUMU)
    {
        DefterDAL dal = new DefterDAL();
        List<DefterInfo> list = dal.GetByID(Convert.ToInt32(SqlInject.InjectionManager.RejectInjection(ID)), 
            Convert.ToInt32(SqlInject.InjectionManager.RejectInjection(YAYIN_DURUMU)));
        dal = null;

        return list;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public DefterInfo GetBilgiByID(int ID, int YAYIN_DURUMU)
    {
        DefterDAL dal = new DefterDAL();
        DefterInfo info = dal.GetBilgiByID(Convert.ToInt32(SqlInject.InjectionManager.RejectInjection(ID)), 
            Convert.ToInt32(SqlInject.InjectionManager.RejectInjection(YAYIN_DURUMU)));
        dal = null;
        return info;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<DefterInfo> GetListByDil(string DIL, int YAYIN_DURUMU)
    {
        DefterDAL dal = new DefterDAL();
        List<DefterInfo> list = dal.GetListByDil(SqlInject.InjectionManager.RejectInjection(DIL), 
            Convert.ToInt32(SqlInject.InjectionManager.RejectInjection(YAYIN_DURUMU)));
        dal = null;

        return list;
    }
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<DefterInfo> GetListByDil2(string DIL, int YAYIN_DURUMU)
    {
        DefterDAL dal = new DefterDAL();
        List<DefterInfo> list = dal.GetListByDil2(SqlInject.InjectionManager.RejectInjection(DIL),
            Convert.ToInt32(SqlInject.InjectionManager.RejectInjection(YAYIN_DURUMU)));
        dal = null;

        return list;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<DefterInfo> GetListByAnaSayfa(string DIL)
    {
        DefterDAL dal = new DefterDAL();
        List<DefterInfo> list = dal.GetListByAnaSayfa(SqlInject.InjectionManager.RejectInjection(DIL));
        dal = null;

        return list;
    }


    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<DefterInfo> GetListByKullaniciId(int KULLANICI_ID, int YAYIN_DURUMU)
    {
        DefterDAL dal = new DefterDAL();
        List<DefterInfo> list = dal.GetListByKullaniciId(Convert.ToInt32(SqlInject.InjectionManager.RejectInjection(KULLANICI_ID)), 
            Convert.ToInt32(SqlInject.InjectionManager.RejectInjection(YAYIN_DURUMU)));
        dal = null;

        return list;
    }


    

    #region Insert / Update / Delete Operations
    [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
    public int Insert(DefterInfo info)
    {
        DefterDAL dal = new DefterDAL();
        int ID = dal.Insert(info);
        dal = null;
        return ID;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
    public void Update(DefterInfo info)
    {
        DefterDAL dal = new DefterDAL();
        dal.Update(info);
        dal = null;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
    public void Delete(DefterInfo info)
    {
        DefterDAL dal = new DefterDAL();
        dal.Delete(info);
        dal = null;
    }
    #endregion

    #endregion

}
