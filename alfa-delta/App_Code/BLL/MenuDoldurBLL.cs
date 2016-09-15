using System;
using System.Collections.Generic;
using System.ComponentModel;

[DataObjectAttribute]
public class MenuDoldurBLL
{
	public MenuDoldurBLL()
	{	}
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<MenuDoldurInfo> GetList()
    {
        MenuDoldurDAL dal = new MenuDoldurDAL();
        List<MenuDoldurInfo> list =dal.GetList();
        dal = null;
        return list;
    }
}
