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
public class BankBLL
{
    public BankBLL()
    {

    }
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public HesapInfo GetBilgiByID(int ID)
    {
        BankDAL dal = new BankDAL();
        HesapInfo info = dal.GetBilgiById(SqlInject.InjectionManager.RejectInjection(ID));
        dal = null;
        return info;
    }




    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<HesapInfo> GetBilgiler()
    {
        BankDAL dal = new BankDAL();
        List<HesapInfo> list = dal.GetBilgiler();
        dal = null;

        return list;
    }
  





    #region Insert / Update / Delete Operations


    [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
    public void Insert(HesapInfo info)
    {
        BankDAL dal = new BankDAL();
        dal.Insert(info);
        dal = null;
        
    }
   
    
    
    [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
    public void Update(HesapInfo info)
    {
        BankDAL dal = new BankDAL();
        dal.Update(info);
        dal = null;
    }
    [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
    public void Delete(int id)
    {
        BankDAL dal = new BankDAL();
        dal.Delete(id);
        dal = null;
    }




    #endregion





}
