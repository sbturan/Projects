using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.ComponentModel;

/// <summary>
/// Summary description for MenuBLL
/// </summary>
[DataObjectAttribute]
public class MenuBLL
{
    public MenuBLL()
    {

    }

    #region Select Type Operations

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public MenuInfo GetModuller()
    {
        MenuDAL dal = new MenuDAL();
        MenuInfo info = dal.GetTumMenular();
        dal = null;
        return info;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public MenuInfo MenuByID2(int ID,string dil)
    {
        MenuDAL dal = new MenuDAL();
        MenuInfo list = dal.MenuByID2(SqlInject.InjectionManager.RejectInjection(ID), SqlInject.InjectionManager.RejectInjection(dil));
        dal = null;

        return list;
    }
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public MenuInfo MenuByID(int ID)
    {
        MenuDAL dal = new MenuDAL();
        MenuInfo list = dal.MenuByID(SqlInject.InjectionManager.RejectInjection(ID));
        dal = null;

        return list;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public MenuInfo MenuByLink(string link)
    {
      //  return new MenuDAL().MenuByLink(link);

        MenuDAL dal = new MenuDAL();
        MenuInfo list = dal.MenuByLink(link);
        dal = null;

        return list;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<MenuInfo> GetAll()
    {
        MenuDAL dal = new MenuDAL();
        List<MenuInfo> list = new List<MenuInfo>();
        list = dal.GetAll();
        dal = null;

        return list;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public bool AltiVarmi(int grupID)
    {
        MenuDAL dal = new MenuDAL();
        return dal.AltiVarmi(SqlInject.InjectionManager.RejectInjection(grupID));
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public bool Yukari(int AnaGrup, int ID)
    {
        MenuDAL dal = new MenuDAL();
        return dal.Yukari(SqlInject.InjectionManager.RejectInjection(AnaGrup), SqlInject.InjectionManager.RejectInjection(ID));
    }

    public bool Asagi(int AnaGrup, int ID)
    {
        MenuDAL dal = new MenuDAL();
        return dal.Asagi(SqlInject.InjectionManager.RejectInjection(AnaGrup), SqlInject.InjectionManager.RejectInjection(ID));
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public DataTable GetByAnaMenuGrup(int grupID)
    {
        MenuDAL dal = new MenuDAL();
        return dal.GetByAnaMenuGrup(SqlInject.InjectionManager.RejectInjection(grupID));
    }
    public DataTable GetByAnaMenuGrup1(int grupID, string dil)
    {
        MenuDAL dal = new MenuDAL();
        return dal.GetByAnaMenuGrup1(SqlInject.InjectionManager.RejectInjection(grupID), SqlInject.InjectionManager.RejectInjection(dil));
    }
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<MenuInfo> GetByMenuGrupTopList2(int grupID,string dil)
    {
        return new MenuDAL().GetByMenuGrupTopList2(SqlInject.InjectionManager.RejectInjection(grupID), SqlInject.InjectionManager.RejectInjection(dil));
    }
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<MenuInfo> GetByMenuGrupTopList(int grupID)
    {
        return new MenuDAL().GetByMenuGrupTopList(SqlInject.InjectionManager.RejectInjection(grupID));
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<MenuInfo> GetByMenuGrupFooterList()
    {
        return new MenuDAL().GetByMenuGrupFooterList();
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<MenuInfo> MenuByGrup(int MenuGrup, int AnaMenuGrup)
    {
        MenuDAL dal = new MenuDAL();
        List<MenuInfo> list = dal.MenuByGrup(SqlInject.InjectionManager.RejectInjection(MenuGrup), 
            SqlInject.InjectionManager.RejectInjection(AnaMenuGrup));
        dal = null;

        return list;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public int GetSira(int AnaMenuGrup)
    {
        MenuDAL menu = new MenuDAL();
        int sira = menu.GetSira(SqlInject.InjectionManager.RejectInjection(AnaMenuGrup));
        return sira;
    }
    public int GetSira1(int AnaMenuGrup)
    {
        MenuDAL menu = new MenuDAL();
        int sira = menu.GetSira1(SqlInject.InjectionManager.RejectInjection(AnaMenuGrup));
        return sira;
    }

    #region Insert / Update / Delete Operations
    [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
    public int Insert(MenuInfo info)
    {
        MenuDAL dal = new MenuDAL();
        int ID = dal.Insert(info);
        dal = null;
        return ID;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
    public void Update(MenuInfo info)
    {
        MenuDAL dal = new MenuDAL();
        dal.Update(info);
        dal = null;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
    public void Delete(MenuInfo info)
    {
        MenuDAL dal = new MenuDAL();
        dal.Delete(info);
        dal = null;
    }


    #endregion

    #endregion


}
