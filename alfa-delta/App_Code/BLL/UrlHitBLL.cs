using System;
using System.Collections.Generic;
using System.ComponentModel;

[DataObjectAttribute]
public class UrlHitBLL
{
    public UrlHitBLL() { }

    #region Select Type Operations
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public Int32 GetMevcutZiyaret(string DIL, string URL, string REMOTE_IP, string OTURUM, string SAYFA_ISMI)
    {
        int mevcutziyaret = 0;
        UrlHitDAL dal = new UrlHitDAL();
        mevcutziyaret = dal.GetMevcutZiyaret(DIL, URL, REMOTE_IP, OTURUM, SAYFA_ISMI);
        dal = null;

        return mevcutziyaret;
    }


    public Int32 GetGunlukZiyaret(string DIL, string SAYFA_ISMI, string URL, DateTime TARIH)
    {
        int gunlukziyaret=0;
        UrlHitDAL dal = new UrlHitDAL();
        gunlukziyaret = dal.GetGunlukZiyaret(DIL,SAYFA_ISMI,URL,TARIH);
        dal = null;

        return gunlukziyaret;
    }

    public Int32 GetToplamZiyaret(string DIL, string SAYFA_ISMI, string URL)
    {
        int toplamziyaret = 0;
        UrlHitDAL dal = new UrlHitDAL();
        toplamziyaret = dal.GetToplamZiyaret(DIL, SAYFA_ISMI, URL);
        dal = null;

        return toplamziyaret;
    }

   

  
    #region Insert / Update / Delete Operations
    [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
    public int Insert(UrlHitInfo info)
    {
        UrlHitDAL dal = new UrlHitDAL();
        int ID = dal.Insert(info);
        dal = null;
        return ID;
    }

   
    
    #endregion

    #endregion

}
