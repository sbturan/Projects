using System;
using System.Collections.Generic;
using System.ComponentModel;

[DataObjectAttribute]
public class MailListeBLL
{
    public MailListeBLL() { }

    #region Select Type Operations
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<MailListeInfo> GetList()
    {
        MailListeDAL dal = new MailListeDAL();
        List<MailListeInfo> list = dal.GetList();
        dal = null;

        //if (dropdown)
        //{
        //    MailListeInfo info = new MailListeInfo();
        //    info.ID = 0;
        //    info.KONU = "Select...";
        //    list.Insert(0, info);
        //}

        return list;
    }

   

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<MailListeInfo> GetListById(int ID)
    {
        MailListeDAL dal = new MailListeDAL();
        List<MailListeInfo> list = dal.GetByID(SqlInject.InjectionManager.RejectInjection(ID));
        dal = null;

        return list;
    }

  
    //#region Insert / Update / Delete Operations
    //[DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
    //public int Insert(MailListeInfo info)
    //{
    //    MailListeDAL dal = new MailListeDAL();
    //    int ID = dal.Insert(info);
    //    dal = null;
    //    return ID;
    //}

    //[DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
    //public void Update(MailListeInfo info)
    //{
    //    MailListeDAL dal = new MailListeDAL();
    //    dal.Update(info);
    //    dal = null;
    //}

    //[DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
    //public void Delete(MailListeInfo info)
    //{
    //    MailListeDAL dal = new MailListeDAL();
    //    dal.Delete(info);
    //    dal = null;
    //}
    //#endregion

    #endregion

}
