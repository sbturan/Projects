using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.ComponentModel;


[DataObjectAttribute]
public class Users1BLL
{


    public Users1BLL() { }
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public Users1Info BulByID(int Id)
    {
        Users1DAL myDAL = new Users1DAL();
        Users1Info myInfo = myDAL.BulByID(Id);
        myDAL = null;
        return myInfo;
    }
    
    
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public Users1Info BulByEmailID(string email)
    {
        Users1DAL myDAL = new Users1DAL();
        Users1Info info = myDAL.BulByEmailID(email);
        myDAL = null;
        return info;
    }
   
    [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
    public int Insert(Users1Info myInfo)
    {
        Users1DAL myDAL = new Users1DAL();
        int myInfoID = Convert.ToInt32(myDAL.UsersEkleReturnID(myInfo));
        myDAL = null;
        return myInfoID;
    }
    public int Insert1(Users1Info myInfo)
    {
        Users1DAL myDAL = new Users1DAL();
        int myInfoID = Convert.ToInt32(myDAL.UsersEkleReturnID1(myInfo));
        myDAL = null;
        return myInfoID;
    }
    [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
    public void Sil(Users1Info entityID)
    {
        Users1DAL myDAL = new Users1DAL();
        myDAL.UsersSil(entityID);
        myDAL = null;
    }
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public bool SilReturnSonuc(Users1Info entityID)
    {
        bool sonuc = false;
        Users1DAL myDAL = new Users1DAL();
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
    public List<Users1Info> GetList(bool dropDown)
    {
        Users1DAL myDAL = new Users1DAL();
        List<Users1Info> myList = myDAL.GetirList();
        myDAL = null;
        if (dropDown)
        {
            Users1Info myDownInfo = new Users1Info();
            myList.Insert(0, myDownInfo);
        }
        return myList;
    }
    [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
    public void Guncelle(Users1Info myInfo)
    {
        Users1DAL myDAL = new Users1DAL();
        myDAL.UsersGuncelle(myInfo);
        myDAL = null;
    }
}
