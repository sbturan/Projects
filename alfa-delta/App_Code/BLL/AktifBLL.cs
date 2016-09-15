using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.ComponentModel;



[DataObjectAttribute]
public class AktifBLL
{
    public AktifBLL()
    {

    }





    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public void GetBilgiler(int x,DateTime tarih)
    {
        AktifDAL dal = new AktifDAL();
        dal.GetBilgiler(x,tarih);
       
        dal = null;
        

    }


}
    

    
