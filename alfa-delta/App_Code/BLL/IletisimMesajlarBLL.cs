using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.ComponentModel;


[DataObjectAttribute]
public class IletisimMesajlarBLL
{
 
 
public IletisimMesajlarBLL() { }
[DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
public IletisimMesajlarInfo GetByID(int Id)
{
 IletisimMesajlarDAL  myDAL = new IletisimMesajlarDAL();
 IletisimMesajlarInfo  myInfo = myDAL.GetByID(Id);
myDAL=null;
return myInfo;
}
[DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
public int Insert( IletisimMesajlarInfo myInfo)
{
 IletisimMesajlarDAL  myDAL = new IletisimMesajlarDAL();
int myInfoID = Convert.ToInt32(myDAL.Insert(myInfo));
myDAL=null;
return myInfoID;
}
[DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
public void Delete( IletisimMesajlarInfo entityID)
{
 IletisimMesajlarDAL  myDAL = new IletisimMesajlarDAL();
myDAL.Delete(entityID);
myDAL=null;
}
[DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
public List< IletisimMesajlarInfo>GetAll(bool dropDown)
{
 IletisimMesajlarDAL myDAL=new IletisimMesajlarDAL();
List< IletisimMesajlarInfo> myList = myDAL.GetAll();
myDAL=null;
if(dropDown)
{
 IletisimMesajlarInfo myDownInfo = new IletisimMesajlarInfo();
myList.Insert(0, myDownInfo);
}
return myList;
}
[DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
public void Update( IletisimMesajlarInfo myInfo)
{
 IletisimMesajlarDAL myDAL = new IletisimMesajlarDAL();
myDAL.Update(myInfo);
myDAL=null;
}
}
