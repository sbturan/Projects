using System;
using System.Collections.Generic;
using System.ComponentModel;


[DataObjectAttribute]
public class usrRolBLL
{
    public usrRolBLL(){ }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<usrRolInfo> GetList()
    {
        usrRolDAL dal = new usrRolDAL();
        List<usrRolInfo> list = dal.GetAllRols();
        dal = null;

        return list;
    }
    //[DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    //public List<usrRolInfo> GetByYonetilebilinir(usrRolInfo yonetileBilini)
    //{
    //    usrRolDAL dal = new usrRolDAL();
    //    List<usrRolInfo> list = dal.GetRolsByYonetilebilinir(yonetileBilini);
    //    dal = null;

    //    return list;
    //}
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<usrRolInfo> GetByYonetilebilinir(bool yonetileBilini)
    {
        usrRolDAL dal = new usrRolDAL();
        List<usrRolInfo> list = dal.GetRolsByYonetilebilinir(yonetileBilini);
        dal = null;

        return list;
    }
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public usrRolInfo GetByRolID(int rolID)
    {
        usrRolDAL dal = new usrRolDAL();
        usrRolInfo info=new usrRolInfo();
        info = dal.GetRolsByRolID(rolID);
        dal = null;

        return info;
    }
    //[DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    //public usrRolInfo GetByRolID(usrRolInfo rolID)
    //{
    //    usrRolDAL dal = new usrRolDAL();
    //    usrRolInfo info = new usrRolInfo();
    //    info = dal.GetRolsByRolID(rolID.rolID);
    //    dal = null;

    //    return info;
    //}



}
