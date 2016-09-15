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

public partial class kutuphane_LeftMenu : System.Web.UI.UserControl
{
    private string _display;

    public string PanelDisplay
    {
        get { return _display; }
        set { _display = value; }
    }
    private int index = 0;
    string dil;
    protected void Page_Load(object sender, EventArgs e)
    {
        
            if (Session["dil"] == null)
            {
                dil = "tr";
            }
            else
            {
                if ((Session["dil"] == "tr"))
                {

                    dil = "tr";
                }
                else
                {
                    dil = Session["dil"].ToString();

                }
            
        }
        List<MenuInfo> list = new List<MenuInfo>();
        list = new MenuBLL().GetByMenuGrupTopList2(0,dil);

        dtl_Menuler.DataSource = list;
        dtl_Menuler.DataBind();
    }


    protected void dtl_Menuler_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            index++;
            HiddenField hdnMenuID = (HiddenField)e.Item.FindControl("hdnMenuID");
            HtmlGenericControl div = (HtmlGenericControl)e.Item.FindControl("divMenu");
            HyperLink lnk = (HyperLink)e.Item.FindControl("lnk");
            Image img = (Image)e.Item.FindControl("img");
            Literal ltr = (Literal)e.Item.FindControl("ltr");
            string id = (e.Item.FindControl("hdnMenuID") as HiddenField).Value;
            if (!string.IsNullOrEmpty(Sabit.Navigasyon()) && !Sabit.Navigasyon().Equals("boþ Navigasyon"))
            {
                MenuInfo menu = new MenuDAL().MenuByID2(int.Parse(Sabit.Navigasyon()),dil);
                if (menu != null)
                {
                  
                    if (id == menu.SIRA.ToString())
                    {
                        //border-bottom:solid 2px #ffffff;
                        (e.Item.FindControl("dvNav") as HtmlGenericControl).Style.Add("width", DataBinder.Eval(e.Item.DataItem, "GENISLIK") + "px");
                        (e.Item.FindControl("dvNav") as HtmlGenericControl).Style.Add("background-color", "#ff7d00");
                        
                         
                                            }
                }
            }
            
            

            string html = string.Empty;
            int value = 0;
            List<MenuInfo> subMenu = new MenuBLL().GetByMenuGrupTopList2(2,dil);
            foreach (MenuInfo itemsub in subMenu)
                {
                    if (itemsub.ANA_MENU_GRUP.Equals(int.Parse(id)))
                    {
                        if(value==0)
                            html = string.Format(@"<div id='{0}' onmouseover=""showAndHideMenu('{0}')"" onmouseout=""showAndHideMenu('{0}')"" style='z-index:1002;width:100px;height:{1}px;position:absolute;float:left;left:0px;text-align:left;padding-left:10px;display:none;'> <ul id='nav'>", "divSubMenu" + index, (subMenu.Count * 10));
                        html += string.Format(@"<li><a href=""{0}"">{1}</a></li>", itemsub.LINK, itemsub.ADI);
                        value++;
                    }
                }

            if (value != 0)
            {
                html += "</ul></div>";
                ltr.Text = html;
                (e.Item.FindControl("dvNav") as HtmlGenericControl).Attributes.Add("onmouseover", string.Format("showAndHideMenu('{0}')", "divSubMenu" + index));
                (e.Item.FindControl("dvNav") as HtmlGenericControl).Attributes.Add("onmouseout", string.Format("showAndHideMenu('{0}')", "divSubMenu" + index));
                
            }

           
            
            if (DataBinder.Eval(e.Item.DataItem, "LINK").ToString().StartsWith("http") || DataBinder.Eval(e.Item.DataItem, "LINK").ToString().StartsWith("javascript"))
                lnk.NavigateUrl = DataBinder.Eval(e.Item.DataItem, "LINK").ToString();
            else
               lnk.NavigateUrl = "~/" + DataBinder.Eval(e.Item.DataItem, "LINK").ToString();


            div.Style.Add(HtmlTextWriterStyle.Width, DataBinder.Eval(e.Item.DataItem, "GENISLIK").ToString() + "px");
            div.Style.Add(HtmlTextWriterStyle.Height, DataBinder.Eval(e.Item.DataItem, "YUKSEKLIK").ToString() + "px");
        }
    }
}
