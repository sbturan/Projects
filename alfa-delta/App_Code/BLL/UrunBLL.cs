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
/// Summary description for bannerBLL
/// </summary>

[DataObjectAttribute]
public class UrunBLL 
{
    public UrunBLL()
	{
		
	}

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<UrunInfo> GetIndirimdekiler()
    {
        UrunDAL dal = new UrunDAL();
        List<UrunInfo> list = dal.GetIndirimdekiler();
        dal = null;

        return list;
    }
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public void Updateurunkategori(int sayi)
    {
        UrunDAL dal = new UrunDAL();
       dal.Updateurunkategori(sayi);
        dal = null;

       
    }
    public List<Urun1Info> GetUrunler()
    {
        UrunDAL dal = new UrunDAL();
        List<Urun1Info> list = dal.GetUrunler();
        dal = null;

        return list;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public UrunInfo GetUrunStok(int ID)
    {
        UrunDAL dal = new UrunDAL();
        UrunInfo info = dal.GetUrunStok(SqlInject.InjectionManager.RejectInjection(ID));
        dal = null;
        return info;
    }

     


    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public Urun1Info GetUrunByID(int ID)
    {
        UrunDAL dal = new UrunDAL();
        Urun1Info info = dal.GetUrunByID(SqlInject.InjectionManager.RejectInjection(ID));
        dal = null;
        return info;
    }
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public UrunInfo GetUrunBy1ID(int ID)
    {
        UrunDAL dal = new UrunDAL();
        UrunInfo info = dal.GetUrunBy1ID(SqlInject.InjectionManager.RejectInjection(ID));
        dal = null;
        return info;
    }
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public ParaUrunInfo GetUrunFiyat(int ID,int para_kontrol)
    {
        UrunDAL dal = new UrunDAL();
        ParaUrunInfo info = dal.GetUrunFiyat(SqlInject.InjectionManager.RejectInjection(ID), SqlInject.InjectionManager.RejectInjection(para_kontrol));
        dal = null;
        return info;
    }


    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<UrunInfo> GetUrunByKategoriID(int ID, bool yayin_durumu)
    {
        UrunDAL dal = new UrunDAL();
        List<UrunInfo> info = dal.GetUrunByKategoriID(SqlInject.InjectionManager.RejectInjection(ID), SqlInject.InjectionManager.RejectInjection(yayin_durumu));
        dal = null;
        return info;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<UrunInfo> GetSonUrunler()
    {
        UrunDAL dal = new UrunDAL();
        List<UrunInfo> info = dal.GetSonUrunler();
        dal = null;
        return info;
    }


    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<UrunInfo> GetUrunByMarkaID(int ID, bool yayin_durumu)
    {
        UrunDAL dal = new UrunDAL();
        List<UrunInfo> info = dal.GetUrunByMarkaID(SqlInject.InjectionManager.RejectInjection(ID), SqlInject.InjectionManager.RejectInjection(yayin_durumu));
        dal = null;
        return info;
    }
  
    #region Insert / Update / Delete Operations
    [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
    public int Insert(UrunInfo info)
    {
        UrunDAL dal = new UrunDAL();
        int ID = dal.Insert(info);
        dal = null;
        return ID;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
    public void Update(UrunInfo info)
    {
        UrunDAL dal = new UrunDAL();
        dal.Update(info);
        dal = null;
    }
    public void Update1(int id,int stok)
    {
        UrunDAL dal = new UrunDAL();
        dal.Update1(id,stok);
        dal = null;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
    public void Delete(int id )
    {
        UrunDAL dal = new UrunDAL();
        dal.Delete(id);
        dal = null;
    }

    #endregion





}
