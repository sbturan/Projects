using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.ComponentModel;


[DataObjectAttribute]
public class UsersBLL
{


    public UsersBLL() { }
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public UsersInfo BulByID(int Id)
    {
        UsersDAL myDAL = new UsersDAL();
        UsersInfo myInfo = myDAL.BulByID(Id);
        myDAL = null;
        return myInfo;
    }
    
    
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public UsersInfo BulByEmailID(string email)
    {
        UsersDAL myDAL = new UsersDAL();
        UsersInfo info = myDAL.BulByEmailID(email);
        myDAL = null;
        return info;
    }
   
    [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
    public int Insert(UsersInfo myInfo)
    {
        UsersDAL myDAL = new UsersDAL();
        int myInfoID = Convert.ToInt32(myDAL.UsersEkleReturnID(myInfo));
        myDAL = null;
        return myInfoID;
    }
    [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
    public void Sil(UsersInfo entityID)
    {
        UsersDAL myDAL = new UsersDAL();
        myDAL.UsersSil(entityID);
        myDAL = null;
    }
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public bool SilReturnSonuc(UsersInfo entityID)
    {
        bool sonuc = false;
        UsersDAL myDAL = new UsersDAL();
        try
        {
            myDAL.UsersSil(entityID);
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
    public List<UsersInfo> GetList(bool dropDown)
    {
        UsersDAL myDAL = new UsersDAL();
        List<UsersInfo> myList = myDAL.GetirList();
        myDAL = null;
        if (dropDown)
        {
            UsersInfo myDownInfo = new UsersInfo();
            myList.Insert(0, myDownInfo);
        }
        return myList;
    }
    [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
    public void Guncelle(UsersInfo myInfo)
    {
        UsersDAL myDAL = new UsersDAL();
        myDAL.UsersGuncelle(myInfo);
        myDAL = null;
    }
    public void update(UsersInfo myInfo)
    {
        UsersDAL myDAL = new UsersDAL();
        myDAL.UsersUpdate(myInfo);
        myDAL = null;
    }



}
