using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.ComponentModel;


[DataObjectAttribute]
public class UsersYonetimBLL
{


    public UsersYonetimBLL() { }
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public UsersYonetimInfo BulByID(int Id)
    {
        UsersYonetimDAL myDAL = new UsersYonetimDAL();
        UsersYonetimInfo myInfo = myDAL.BulByID(Id);
        myDAL = null;
        return myInfo;
    }


    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public UsersYonetimInfo BulByEmailID(string email)
    {
        UsersYonetimDAL myDAL = new UsersYonetimDAL();
        UsersYonetimInfo info = myDAL.BulByEmailID(email);
        myDAL = null;
        return info;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
    public int Insert(UsersYonetimInfo myInfo)
    {
        UsersYonetimDAL myDAL = new UsersYonetimDAL();
        int myInfoID = Convert.ToInt32(myDAL.UsersYonetimEkleReturnID(myInfo));
        myDAL = null;
        return myInfoID;
    }
    [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
    public void Sil(UsersYonetimInfo entityID)
    {
        UsersYonetimDAL myDAL = new UsersYonetimDAL();
        myDAL.UsersYonetimSil(entityID);
        myDAL = null;
    }
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public bool SilReturnSonuc(UsersYonetimInfo entityID)
    {
        bool sonuc = false;
        UsersYonetimDAL myDAL = new UsersYonetimDAL();
        try
        {
            myDAL.UsersYonetimSil(entityID);
            myDAL = null;
            sonuc = true;
        }
        catch (Exception ex)
        {
            sonuc = false;
        }
        return sonuc;
    }
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<UsersYonetimInfo> GetList(bool dropDown)
    {
        UsersYonetimDAL myDAL = new UsersYonetimDAL();
        List<UsersYonetimInfo> myList = myDAL.GetirList();
        myDAL = null;
        if (dropDown)
        {
            UsersYonetimInfo myDownInfo = new UsersYonetimInfo();
            myList.Insert(0, myDownInfo);
        }
        return myList;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<UsersYonetimInfo> GetirList()
    {
        UsersYonetimDAL myDAL = new UsersYonetimDAL();
        List<UsersYonetimInfo> myList = myDAL.GetirList();
        myDAL = null;
        return myList;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
    public void Guncelle(UsersYonetimInfo myInfo)
    {
        UsersYonetimDAL myDAL = new UsersYonetimDAL();
        myDAL.UsersYonetimGuncelle(myInfo);
        myDAL = null;
    }
}
