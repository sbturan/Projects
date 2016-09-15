using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using System.Collections.Generic;

/// <summary>
/// Summary description for ModulBLL
/// </summary>
public class ModulBLL
{
	public ModulBLL()
	{
		
	}

    #region Select Type Operations

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public ModulInfo GetModuller()
    {
        ModulDAL dal = new ModulDAL();
        ModulInfo info = dal.GetModuller();
        dal = null;
        return info;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<ModulInfo> GetModulByUstID(int UstID)
    {
        ModulDAL dal = new ModulDAL();
        List<ModulInfo> list = dal.GetModulByUstID(SqlInject.InjectionManager.RejectInjection(UstID));
        dal = null;

        return list;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<ModulInfo> GetModulByID(int ID)
    {
        ModulDAL dal = new ModulDAL();
        List<ModulInfo> list = dal.GetModulByID(SqlInject.InjectionManager.RejectInjection(ID));
        dal = null;

        return list;
    }

    
    #region Insert / Update / Delete Operations
    [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
    public int Insert(ModulInfo info)
    {
        ModulDAL dal = new ModulDAL();
        int ID = dal.Insert(info);
        dal = null;
        return ID;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
    public void Update(ModulInfo info)
    {
        ModulDAL dal = new ModulDAL();
        dal.Update(info);
        dal = null;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
    public void Delete(ModulInfo info)
    {
        ModulDAL dal = new ModulDAL();
        dal.Delete(info);
        dal = null;
    }


    #endregion

    #endregion
}
