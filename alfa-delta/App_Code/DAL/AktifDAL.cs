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


public class AktifDAL
{
    public AktifDAL()
    {

    }






    public void GetBilgiler(int x, DateTime tarih)
    {

        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@Tarih", tarih), new SqlParameter("@Gun", x) };
        string spName = "AktifolmayanSil";

        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);

    }
   


   







}
