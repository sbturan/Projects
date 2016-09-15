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


[DataObjectAttribute]
public class UrunAciklamaBLL
{
    public UrunAciklamaBLL()
	{
		
	}

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<UrunAciklamaInfo> GetTumUA(string dil)
    {
        UrunAciklamaDAL dal = new UrunAciklamaDAL();
        List<UrunAciklamaInfo> list = dal.GetTumUA(SqlInject.InjectionManager.RejectInjection(dil));
        dal = null;

        return list;
    }

  


    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<UrunAciklamaInfo> GetUAbyUrunID(int ID, string dil)
    {
        UrunAciklamaDAL dal = new UrunAciklamaDAL();
        List<UrunAciklamaInfo> list = dal.GetUAbyUrunID(SqlInject.InjectionManager.RejectInjection(ID), SqlInject.InjectionManager.RejectInjection(dil));
        dal = null;
        return list;
    }

        

    #region Insert / Update / Delete Operations
    [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
    public int Insert(UrunAciklamaInfo info)
    {
        UrunAciklamaDAL dal = new UrunAciklamaDAL();
        int ID = dal.Insert(info);
        dal = null;
        return ID;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
    public void Update(UrunAciklamaInfo info)
    {
        UrunAciklamaDAL dal = new UrunAciklamaDAL();
        dal.Update(info);
        dal = null;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
    public void Delete(UrunAciklamaInfo info)
    {
        UrunAciklamaDAL dal = new UrunAciklamaDAL();
        dal.Delete(info);
        dal = null;
    }

    #endregion





}
