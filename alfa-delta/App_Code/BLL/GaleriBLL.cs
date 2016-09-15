using System;
using System.Collections.Generic;
using System.ComponentModel;

[DataObjectAttribute]
public class GaleriBLL
{
     public GaleriBLL() { }



     [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
     public GaleriInfo GetResimByUrunId(int ID,int yayin_durumu)
     {
         GaleriDAL dal = new GaleriDAL();
         GaleriInfo info = dal.GetResimByUrunId(SqlInject.InjectionManager.RejectInjection(ID), SqlInject.InjectionManager.RejectInjection(yayin_durumu));
         dal = null;
         return info;
     }
     [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
     public GaleriInfo GetResimByResimId(int ID)
     {
         GaleriDAL dal = new GaleriDAL();
         GaleriInfo info = dal.GetResimByResimId(SqlInject.InjectionManager.RejectInjection(ID));
         dal = null;
         return info;
     }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<GaleriInfo> GetTumResimler()
    {
        GaleriDAL dal = new GaleriDAL();
        List<GaleriInfo> list = dal.GetTumResimler();
        dal = null;

        return list;
    }

    
   

    #region Insert / Update / Delete Operations
    [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
    public int Insert(GaleriInfo info)
    {
        GaleriDAL dal = new GaleriDAL();
        int ID = dal.Insert(info);
        dal = null;
        return ID;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
    public void Update(GaleriInfo info)
    {
        GaleriDAL dal = new GaleriDAL();
        dal.Update(info);
        dal = null;
    }
    [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
    public void Delete(GaleriInfo info)
    {
        GaleriDAL dal = new GaleriDAL();
        dal.Delete(info);
        dal = null;
    }
    
    #endregion

    

}
