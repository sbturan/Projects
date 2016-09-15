
﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OboutInc.Show;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using AlfaDeltaLogin;
public partial class _Default : System.Web.UI.Page
{
 
    protected void Page_Load(object sender, EventArgs e)
    {
     

        
 string[] bolunmusadres = this.Page.Request.Url.PathAndQuery.Split('/');

        MenuInfo info = new MenuBLL().MenuByLink(bolunmusadres[bolunmusadres.Length - 1]);
        if (info != null)
        {
            Sabit.Navigasyon(info.SIRA.ToString());
        }
        else
        {
            Sabit.Navigasyon("boþ Navigasyon");
        }

        if (SqlInject.InjectionManager.HasInjection("2077") == false)
        {
            IcerikInfo icinfo = new IcerikInfo();
            IcerikBLL icBLL = new IcerikBLL();
            //icinfo = icBLL.GetBilgiByID(4, 1);
     
        }

       


        #region Slider
        
       
        #endregion

        ClientScript.RegisterStartupScript(this.GetType(), "Set Active", @"<Script type=""text/javascript"">document.getElementById(""divMenu1"").className = ""active""</Script>");
    
    }
    protected void ImgBtnSend_Click(object sender, ImageClickEventArgs e)
    {
        
    }

    protected void dlKategori_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
}