using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.ComponentModel;


[DataObjectAttribute]
public class UserRolesBLL
{
 
 
public UserRolesBLL() { }
[DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
public UserRolesInfo BulByID(int Id)
{
 UserRolesDAL  myDAL = new UserRolesDAL();
 UserRolesInfo  myInfo = myDAL.BulByID(Id);
myDAL=null;
return myInfo;
}
[DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
public UserRolesInfo BulByID(UserRolesInfo entityID)
{
 UserRolesDAL  myDAL = new UserRolesDAL();
 UserRolesInfo  myInfo = myDAL.BulByID(entityID);
myDAL=null;
return myInfo;
}
[DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
public  int Insert( UserRolesInfo myInfo)
{
 UserRolesDAL  myDAL = new UserRolesDAL();
int myInfoID = Convert.ToInt32(myDAL.UserRolesEkle(myInfo));
myDAL=null;
return myInfoID;
}
[DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
public void Sil( UserRolesInfo entityID)
{
 UserRolesDAL  myDAL = new UserRolesDAL();
myDAL.UserRolesSil(entityID);
myDAL=null;
}
[DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
public bool SilReturnSonuc( UserRolesInfo entityID)
{
bool sonuc=false;
 UserRolesDAL  myDAL = new UserRolesDAL();
try
{
myDAL.UserRolesSil(entityID);
myDAL=null;
sonuc = true;
}
catch (Exception ex)
{
sonuc =false;
}
return sonuc;
}
[DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
public List< UserRolesInfo>GetList(bool dropDown)
{
 UserRolesDAL myDAL=new UserRolesDAL();
List< UserRolesInfo> myList = myDAL.GetirList();
myDAL=null;
if(dropDown)
{
 UserRolesInfo myDownInfo = new UserRolesInfo();
myList.Insert(0, myDownInfo);
}
return myList;
}
[DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
public void Guncelle( UserRolesInfo myInfo)
{
 UserRolesDAL myDAL = new UserRolesDAL();
myDAL.UserRolesGuncelle(myInfo);
myDAL=null;
}
}
