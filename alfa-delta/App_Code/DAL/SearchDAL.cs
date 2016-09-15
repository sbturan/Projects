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
using System.Data.SqlClient;

/// <summary>
/// Summary description for SearchDAL
/// </summary>
public class SearchDAL
{
    public SearchDAL()
    {

    }

    public List<SearchInfo> GetForUrun(string keyword)
    {
        List<SearchInfo> list = new List<SearchInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetForUrun"), new SqlParameter("@KEYWORD", keyword) };
        string spName = "SearchDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                SearchInfo info = new SearchInfo(dr);
                list.Add(info);
            }
        }
        return list;
    }
}
   