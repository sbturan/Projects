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
using System.Web.UI.MobileControls;

/// <summary>
/// Summary description for SearchBLL
/// </summary>
[DataObjectAttribute]
public class SearchBLL
{
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public List<SearchInfo> GetForUrun(string keyword)
    {
        SearchDAL dal = new SearchDAL();
        List<SearchInfo> info = dal.GetForUrun(SqlInject.InjectionManager.RejectInjection(keyword)
            );
        dal = null;
        return info;
    }


}
