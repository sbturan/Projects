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


public class BankDAL
{
    public BankDAL()
    {

    }

    public List<HesapInfo> GetBilgiler()
    {
        List<HesapInfo> list = new List<HesapInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetBilgiler") };
        string spName = "hesapbilgileri";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                HesapInfo info = new HesapInfo(dr);
                list.Add(info);
            }

        }

        return list;
    }




    public HesapInfo GetBilgiById(int id)
    {
        List<HesapInfo> list = new List<HesapInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetBilgiById"), new SqlParameter("@ID", id) };
        string spName = "hesapbilgileri";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                HesapInfo info = new HesapInfo(dr);
                return info;
            }

            return null;

        }

    }


    public void Insert(HesapInfo info)
    {
        SqlParameter[] spParametre = new SqlParameter[] 
        {
            new SqlParameter("@OPERATION", "Insert"),
             new SqlParameter("@HESAP_NO", info.HESAP_NO),
            new SqlParameter("@BANK_ADI", info.BANK_ADI),
             new SqlParameter("@SUBE_ADI", info.SUBE_ADI),
              new SqlParameter("@IBAN_NO", info.IBAN_NO),
               new SqlParameter("@HESAP_TURU", info.HESAP_TUR),
                new SqlParameter("@ID", info.ID)
        };
        string spName = "hesapbilgileri";

        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParametre);


    }


   
    public void Update(HesapInfo info)
    {
        SqlParameter[] spParametre = new SqlParameter[] 
        {
            new SqlParameter("@OPERATION", "Update"),
            new SqlParameter("@HESAP_NO", info.HESAP_NO),
            new SqlParameter("@BANK_ADI", info.BANK_ADI),
             new SqlParameter("@SUBE_ADI", info.SUBE_ADI),
              new SqlParameter("@IBAN_NO", info.IBAN_NO),
               new SqlParameter("@HESAP_TURU", info.HESAP_TUR),
               
                new SqlParameter("@ID", info.ID)
            
        };
        string spName = "hesapbilgileri";

        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParametre);

    }

    public void Delete(int id)
    {
        SqlParameter[] spParametre = new SqlParameter[]
        {
            new SqlParameter("@OPERATION","Delete"),
            new SqlParameter("@ID",id)

        };
        string spName = "hesapbilgileri";
        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParametre);
    }





}
