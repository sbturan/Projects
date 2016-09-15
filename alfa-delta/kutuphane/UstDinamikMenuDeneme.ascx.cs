using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

public partial class kutuphane_UstDinamikMenuDeneme : System.Web.UI.UserControl
{
    public void itemInsert(int anaGrupID, MenuItem rootMenuItem)
    {
        List<MenuInfo> myMenuList = new List<MenuInfo>();
        MenuDAL myMenuDal = new MenuDAL();
        myMenuList = myMenuDal.GetByAnaMenuGrupList(anaGrupID);
        if (myMenuList.Count > 0)
        {
            for (int i = 0; i < myMenuList.Count; i++)
            {
                MenuItem myItem = new MenuItem();
                //if (myMenuList[i].ADI != "xxx")
                //{
                myItem.Text = myMenuList[i].ADI.ToString();
                myItem.NavigateUrl = "~/" + myMenuList[i].LINK.ToString();
                rootMenuItem.ChildItems.Add(myItem);
                itemInsert(myMenuList[i].ID, rootMenuItem.ChildItems[i]);
                myMenuList.Clear();
                myMenuList = myMenuDal.GetByAnaMenuGrupList(anaGrupID);
                //}

            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack)
            return;

        //List<MenuInfo> myMenuList = new List<MenuInfo>();
        //MenuDAL menuDal = new MenuDAL();
        //myMenuList = menuDal.GetAllListByDil(0);
        //foreach (MenuInfo myObj in myMenuList)
        //{
        //    MenuItem rootMenuItem = new MenuItem();
        //    MenuItem childMenuItem = new MenuItem();
        //    MenuItem altChildItem = new MenuItem();
        //    List<MenuInfo> listmenu = new List<MenuInfo>();

        //    if (myObj.ANA_MENU_GRUP == 0)
        //    {
        //        rootMenuItem.NavigateUrl = "~/" + myObj.LINK.ToString();
        //        rootMenuItem.Text = myObj.ADI.ToString();
        //        rootMenuItem.Selectable = true;
        //        rootMenuItem.Selectable = true;
        //        Menu1.Items.AddAt(0, rootMenuItem);
        //        itemInsert(myObj.ID, rootMenuItem);
        //        myMenuList = menuDal.GetAllListByDil(0);

        //    }


        //}

        //myMenuList.Clear();
    }
    //protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    //{

    //}
}