using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web.UI.MobileControls;

/// <summary>
/// Summary description for MenuDAL
/// </summary>
public class MenuDAL : Core.BaseDataObject
{
    public MenuDAL()
    {

    }

    #region Select Type Operations
    public MenuInfo GetTumMenular()
    {
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "TumMenular") };
        string spName = "MenuYonetimiDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                MenuInfo info = new MenuInfo(dr);
                return info;
            }
            return null;
        }

    }
    public MenuInfo MenuByID(int ID)
    {
        List<MenuInfo> list = new List<MenuInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "MenuByID"), new SqlParameter("@ID", ID) };
        string spName = "MenuYonetimiDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                MenuInfo info = new MenuInfo(dr);
                return info;
                //list.Add(info);
            }
            return null;
        }

    }
    public MenuInfo MenuByID2(int ID,string dil)
    {
        List<MenuInfo> list = new List<MenuInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "MenuByID2"), new SqlParameter("@ID", ID), new SqlParameter("@DIL", dil) };
        string spName = "MenuYonetimiDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                MenuInfo info = new MenuInfo(dr);
                return info;
                //list.Add(info);
            }
            return null;
        }

    }

    public MenuInfo MenuByLink(string link)
    {        
        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, "MenuYonetimiDuzenle", new SqlParameter[] { new SqlParameter("@OPERATION", "MenuByLink"), new SqlParameter("@LINK", link)}))
        {
            if (dr.Read())
            {
                return new MenuInfo(dr);
            }
            return null;
        }

    }

    public List<MenuInfo> MenuByGrup(int MenuGrup, int AnaMenuGrup)
    {
        List<MenuInfo> list = new List<MenuInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "MenuByGrup"), new SqlParameter("@MENU_GRUP", MenuGrup), new SqlParameter("@ANA_MENU_GRUP", AnaMenuGrup) };
        string spName = "MenuYonetimiDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            while (dr.Read())
            {
                list.Add(new MenuInfo(dr));
            }
        }
        return list;
    }

    public DataTable GetAll2()
    {
        DataTable dt = new DataTable();
        List<MenuInfo> list = new List<MenuInfo>();
        string spName = "MenuYonetimiDuzenle";
        SqlParameter[] param ={ Parameter("@OPERATION", SqlDbType.NVarChar, ParameterDirection.Input, "GetAll") };
        //SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetAll") };
        dt = SqlHelper.ExecuteDatasetOkan(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, param);
        
        return dt;
    }

    public DataTable GetAll3()
    {
        DataTable dt = new DataTable();
        List<MenuInfo> list = new List<MenuInfo>();
        string spName = "MenuYonetimiDuzenle";
        SqlParameter[] param = { Parameter("@OPERATION", SqlDbType.NVarChar, ParameterDirection.Input, "GetAll2") };
        //SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetAll") };
        dt = SqlHelper.ExecuteDatasetOkan(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, param);

        return dt;
    }






    public List<MenuInfo> GetAllList()
    {
        List<MenuInfo> myListInfo = new List<MenuInfo>();
        SqlParameter[] myParam = new SqlParameter[] { new SqlParameter("OPERATION", "GetAllDESC") };
        string spNames = "MenuYonetimiDuzenle";
        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spNames,myParam))
        {
            //if (dr.Read())
            //{
            //    MenuInfo myInfo = new MenuInfo(dr);
            //    myListInfo.Add(myInfo);
                
            //}
            //else
            //    return null;
            while (dr.Read())
            {
                MenuInfo myInfo = new MenuInfo(dr);
                myListInfo.Add(myInfo);
            }
        }
        return myListInfo;
    }

    public DataTable GetAllForYonetim()
    {
        DataTable dt = new DataTable();
        List<MenuInfo> list = new List<MenuInfo>();
        string spName = "MenuYonetimiDuzenle";
        SqlParameter[] param ={ Parameter("@OPERATION", SqlDbType.NVarChar, ParameterDirection.Input, "GetAllForYonetim") };
        //SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetAll") };
        dt = SqlHelper.ExecuteDatasetOkan(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, param);

        return dt;
    }

    public DataTable GetByAnaMenuGrup(int GrupID)
    {
        DataTable dt = new DataTable();
        string spName = "MenuYonetimiDuzenle";
        SqlParameter[] param ={ Parameter("@OPERATION", SqlDbType.NVarChar, ParameterDirection.Input, "GetByAnaMenuGrup"), Parameter("@ANA_MENU_GRUP", SqlDbType.Int, ParameterDirection.Input, GrupID) };
        //SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetAll") };
        dt = SqlHelper.ExecuteDatasetOkan(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, param);
        return dt;
    }
    public DataTable GetByAnaMenuGrup1(int GrupID, string dil)
    {
        DataTable dt = new DataTable();
        string spName = "MenuYonetimiDuzenle";
        SqlParameter[] param = { Parameter("@OPERATION", SqlDbType.NVarChar, ParameterDirection.Input, "GetByAnaMenuGrup1"), Parameter("@ANA_MENU_GRUP", SqlDbType.Int, ParameterDirection.Input, GrupID), Parameter("@DIL", SqlDbType.NVarChar, ParameterDirection.Input, dil) };
        //SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetAll") };
        dt = SqlHelper.ExecuteDatasetOkan(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, param);
        return dt;
    }


    public List<MenuInfo> GetByMenuGrupTopList(int GrupID)
    {
        List<MenuInfo> list = new List<MenuInfo>();
        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, "MenuYonetimiDuzenle", new SqlParameter[] { new SqlParameter("@OPERATION", "GetByMenuGrupTop"), new SqlParameter("@MENU_GRUP", GrupID)}))
        {
            while (dr.Read())
            {
                list.Add(new MenuInfo(dr));
            }
        }
        return list;
    }
    public List<MenuInfo> GetByMenuGrupTopList2(int GrupID,string dil)
    {
        List<MenuInfo> list = new List<MenuInfo>();
        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, "MenuYonetimiDuzenle", new SqlParameter[] { new SqlParameter("@OPERATION", "GetByMenuGrupTop2"), new SqlParameter("@MENU_GRUP", GrupID),new SqlParameter("@DIL",dil) }))
        {
            while (dr.Read())
            {
                 list.Add(new MenuInfo(dr));
            }
        }
        return list;
    }
    public List<MenuInfo> GetByMenuGrupFooterList()
    {
        List<MenuInfo> list = new List<MenuInfo>();
        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, "MenuYonetimiDuzenle", new SqlParameter[] { new SqlParameter("@OPERATION", "GetByMenuGrupFooter")}))
        {
            while (dr.Read())
            {
                list.Add(new MenuInfo(dr));
            }
        }
        return list;
    }

    public List<MenuInfo> GetByAnaMenuGrupListDESC(int GrupID)
    {
        List<MenuInfo> list = new List<MenuInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetByAnaMenuGrupDesc"), new SqlParameter("@ANA_MENU_GRUP", GrupID) };
        string spName = "MenuYonetimiDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            //if (dr.Read())
            //{
            //    MenuInfo info = new MenuInfo(dr);
            //    list.Add(info);
            //    return list;
            //}
            //else
            //    return null;
            while (dr.Read())
            {
                MenuInfo info = new MenuInfo(dr);
                list.Add(info);
            }

        }
        return list;

    }

    public bool AltiVarmi(int ana_menu_grup)
    {
        DataTable dt = new DataTable();
        string spName = "MenuYonetimiDuzenle";
        SqlParameter[] param ={ Parameter("@OPERATION", SqlDbType.NVarChar, ParameterDirection.Input, "AltiVarmi"), Parameter("@ID", SqlDbType.Int, ParameterDirection.Input, ana_menu_grup) };
        dt = SqlHelper.ExecuteDatasetOkan(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, param);
        if (dt.Rows.Count == 0)
            return false;
        else
            return true;
    }

    public bool Yukari(int AnaGrup, int ID)
    {
        int k = 0;
        MenuBLL bl = new MenuBLL();
        MenuInfo inf = new MenuInfo();
        MenuInfo a = new MenuInfo();
        a = bl.MenuByID(ID);
        string b = "'"+a.DIL+"'";
        MenuInfo inf2 = new MenuInfo();
        DataTable dt = new DataTable();
        DataTable dtr = new DataTable();
        List<DataRow> list = new List<DataRow>();
        dt = bl.GetByAnaMenuGrup1(AnaGrup,a.DIL);

       
    
     
       
        if (dt.Rows.Count <= 1)
            return false;          // o bölümde tek menü var sýra deðiþmiyor.
        else
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                
                    k = k + 1;
                    if (Convert.ToInt32(dt.Rows[i]["menu_ID"].ToString()) == ID)
                    {
                        if (i == 0) // zaten ilk sýradaymýþ..
                        {
                            return false;
                        }
                        else // ilk sýrada deðil. deðiþtirilecekk...
                        {
                            int geleninki = i;
                            inf2 = bl.MenuByID(Convert.ToInt32(dt.Rows[i - 1]["menu_ID"].ToString()));
                            inf = bl.MenuByID(Convert.ToInt32(dt.Rows[i]["menu_ID"].ToString()));

                            geleninki = inf.SIRA;
                            inf.SIRA = inf2.SIRA;
                            inf2.SIRA = geleninki;

                            bl.Update(inf);
                            bl.Update(inf2);
                            return true;
                        }
                    }
                
            }
        }



        string spName = "MenuYonetimiDuzenle";
        SqlParameter[] param ={ Parameter("@OPERATION", SqlDbType.NVarChar, ParameterDirection.Input, "Yukari"), Parameter("@ANA_MENU_GRUP", SqlDbType.Int, ParameterDirection.Input, AnaGrup), Parameter("@ID", SqlDbType.Int, ParameterDirection.Input, ID) };
        dt = SqlHelper.ExecuteDatasetOkan(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, param);
        if (dt.Rows[0][0] == DBNull.Value)
            return false;
        else
            return true;
    }

    public bool Asagi(int AnaGrup, int ID)
    {
        MenuBLL bl = new MenuBLL();
        MenuInfo inf = new MenuInfo();
        MenuInfo inf2 = new MenuInfo();
        DataTable dt = new DataTable();
        MenuInfo a = new MenuInfo();
        a = bl.MenuByID(ID);
        dt = bl.GetByAnaMenuGrup1(AnaGrup,a.DIL);
        
       
        if (dt.Rows.Count <= 1)
            return false;          // o bölümde tek menü var sýra deðiþmiyor.
        else
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt.Rows[i]["menu_ID"].ToString()) == ID)
                {
                    if (i == dt.Rows.Count - 1) // zaten ilk sýradaymýþ..
                    {
                        return false;
                    }
                    else // ilk sýrada deðil. deðiþtirilecekk...
                    {
                        int geleninki = i;
                        inf2 = bl.MenuByID(Convert.ToInt32(dt.Rows[i - 1]["menu_ID"].ToString()));
                        inf = bl.MenuByID(Convert.ToInt32(dt.Rows[i]["menu_ID"].ToString()));

                        geleninki = inf.SIRA;
                        inf.SIRA = inf2.SIRA;
                        inf2.SIRA = geleninki;

                        bl.Update(inf);
                        bl.Update(inf2);
                        return true;
                    }
                }
            }
        }



        string spName = "MenuYonetimiDuzenle";
        SqlParameter[] param ={ Parameter("@OPERATION", SqlDbType.NVarChar, ParameterDirection.Input, "Yukari"), Parameter("@ANA_MENU_GRUP", SqlDbType.Int, ParameterDirection.Input, AnaGrup), Parameter("@ID", SqlDbType.Int, ParameterDirection.Input, ID) };
        dt = SqlHelper.ExecuteDatasetOkan(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, param);
        if (dt.Rows[0][0] == DBNull.Value)
            return false;
        else
            return true;
    }

    public List<MenuInfo> GetAll()
    {
        List<MenuInfo> list = new List<MenuInfo>();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetAll") };
        string spName = "MenuYonetimiDuzenle";

        using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter))
        {
            if (dr.Read())
            {
                MenuInfo info = new MenuInfo(dr);
                list.Add(info);
            }
        }
        return list;
    }

    public int GetSira(int AnaMenuGrup)
    {
        DataTable dt = new DataTable();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetSira"), new SqlParameter("@ANA_MENU_GRUP", AnaMenuGrup) };
        string spName = "MenuYonetimiDuzenle";
        dt = SqlHelper.ExecuteDatasetOkan(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
        if (dt.Rows[0][0] == DBNull.Value)
            return 1;
        else
            return Convert.ToInt32(dt.Rows[0][0].ToString()) + 1;
    }
    public int GetSira1(int AnaMenuGrup)
    {
        DataTable dt = new DataTable();
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "GetSira1"), new SqlParameter("@ANA_MENU_GRUP", AnaMenuGrup) };
        string spName = "MenuYonetimiDuzenle";
        dt = SqlHelper.ExecuteDatasetOkan(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
        if (dt.Rows[0][0] == DBNull.Value)
            return 1;
        else
            return Convert.ToInt32(dt.Rows[0][0].ToString()) + 1;
    }

    #endregion


    #region Insert / Update / Delete Type Operations
    public Int32 Insert(MenuInfo info)
    {
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Insert"), 
                                                          new SqlParameter("@ADI", info.ADI),
                                                          new SqlParameter("@LINK", info.LINK),
                                                          new SqlParameter("@RESIM", info.RESIM),
                                                          new SqlParameter("@DIL", info.DIL),
                                                          new SqlParameter("@SIRA",info.SIRA),
                                                          new SqlParameter("@MENU_GRUP",info.MENU_GRUP),
                                                          new SqlParameter("@ANA_MENU_GRUP", info.ANA_MENU_GRUP),
                                                         new SqlParameter("@YUKSEKLIK",info.YUKSEKLIK),
                                                          new SqlParameter("@GENISLIK", info.GENISLIK),
                                                          
                                                          new SqlParameter("@YAYIN_DURUMU", info.YAYIN_DURUMU)
                                                                                                                  
                                                         };
        string spName = "MenuYonetimiDuzenle";
        return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter));

    }

    public void Update(MenuInfo info)
    {
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Update"), 
                                                          new SqlParameter("@ADI", info.ADI),
                                                          new SqlParameter("@LINK", info.LINK),
                                                          new SqlParameter("@RESIM", info.RESIM),
                                                          new SqlParameter("@DIL", info.DIL),
                                                          new SqlParameter("@SIRA",info.SIRA),
                                                          new SqlParameter("@MENU_GRUP",info.MENU_GRUP),
                                                          new SqlParameter("@ANA_MENU_GRUP", info.ANA_MENU_GRUP),
                                                          new SqlParameter("@YUKSEKLIK",info.YUKSEKLIK),
                                                          new SqlParameter("@GENISLIK", info.GENISLIK),
                                                         new SqlParameter("@YAYIN_DURUMU", info.YAYIN_DURUMU),
                                                          new SqlParameter("@ID",info.ID)
                                                          };
        string spName = "MenuYonetimiDuzenle";
        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
    }

    public void Delete(MenuInfo info)
    {
        SqlParameter[] spParameter = new SqlParameter[] { new SqlParameter("@OPERATION", "Delete"), new SqlParameter("@ID", info.ID) };
        string spName = "MenuYonetimiDuzenle";
        SqlHelper.ExecuteNonQuery(SqlHelper.CONNECTION_STRING, CommandType.StoredProcedure, spName, spParameter);
    }

    #endregion
}
