using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

[DataObjectAttribute]
public class ILIlceSemtBLL
{
    public ILIlceSemtBLL() { }

    #region Select Type Operations
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<IlInfo> GetIller()
    {
        IlIlceSemtDAL dal = new IlIlceSemtDAL();
        List<IlInfo> info = dal.GetIller();
        dal = null;
        return info;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<IlceInfo> GetIlceler(int ilid)
    {
        IlIlceSemtDAL dal = new IlIlceSemtDAL();
        List<IlceInfo> info = dal.GetIlceler(ilid);
        dal = null;
        return info;
    }
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<SemtInfo> GetSemtler(int ilceid)
    {
        IlIlceSemtDAL dal = new IlIlceSemtDAL();
        List<SemtInfo> info = dal.GetSemtler(ilceid);
        dal = null;
        return info;
    }


   
    #endregion


    
    
}
