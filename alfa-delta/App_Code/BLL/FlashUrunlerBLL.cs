using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.ComponentModel;


[DataObjectAttribute]
public class FlashUrunlerBLL
{
 
 
public FlashUrunlerBLL() { }
[DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
public FlashUrunlerInfo BulByID(int Id)
{
 FlashUrunlerDAL  myDAL = new FlashUrunlerDAL();
 FlashUrunlerInfo  myInfo = myDAL.BulByID(Id);
myDAL=null;
return myInfo;
}
[DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
public FlashUrunlerInfo BulByID(FlashUrunlerInfo entityID)
{
 FlashUrunlerDAL  myDAL = new FlashUrunlerDAL();
 FlashUrunlerInfo  myInfo = myDAL.BulByID(entityID);
myDAL=null;
return myInfo;
}
[DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
public  int Insert( FlashUrunlerInfo myInfo)
{
 FlashUrunlerDAL  myDAL = new FlashUrunlerDAL();
int myInfoID = Convert.ToInt32(myDAL.FlashUrunlerEkle(myInfo));
myDAL=null;
return myInfoID;
}
[DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
public void Sil( FlashUrunlerInfo entityID)
{
 FlashUrunlerDAL  myDAL = new FlashUrunlerDAL();
myDAL.FlashUrunlerSil(entityID);
myDAL=null;
}
[DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
public bool SilReturnSonuc( FlashUrunlerInfo entityID)
{
bool sonuc=false;
 FlashUrunlerDAL  myDAL = new FlashUrunlerDAL();
try
{
myDAL.FlashUrunlerSil(entityID);
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
public List< FlashUrunlerInfo>GetList(bool dropDown)
{
 FlashUrunlerDAL myDAL=new FlashUrunlerDAL();
List< FlashUrunlerInfo> myList = myDAL.GetirList();
myDAL=null;
if(dropDown)
{
 FlashUrunlerInfo myDownInfo = new FlashUrunlerInfo();
myList.Insert(0, myDownInfo);
}
return myList;
}
[DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
public void Guncelle( FlashUrunlerInfo myInfo)
{
 FlashUrunlerDAL myDAL = new FlashUrunlerDAL();
myDAL.FlashUrunlerGuncelle(myInfo);
myDAL=null;
}
}
