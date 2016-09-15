using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for DBTools
/// </summary>
/// 
namespace Core
{
    public class DBTools
    {
        public int PageSize = 100;
        public DBTools()
        {
            
        }

        public Object FromDB(Object deger, SqlDbType type)
        {
            if (deger == DBNull.Value)
            {
                switch (type)
                {
                    case SqlDbType.BigInt: return -1;
                    case SqlDbType.Decimal: return -1;
                    case SqlDbType.Float: return -1;
                    case SqlDbType.Int: return -1;
                    case SqlDbType.Money: return -1;
                    case SqlDbType.Real: return -1;
                    case SqlDbType.SmallInt: return -1;
                    case SqlDbType.SmallMoney: return -1;
                    case SqlDbType.Char: return "";
                    case SqlDbType.NChar: return "";
                    case SqlDbType.NText: return "";
                    case SqlDbType.NVarChar: return "";
                    case SqlDbType.Text: return "";
                    case SqlDbType.VarChar: return "";
                    case SqlDbType.Bit: return false;
                    case SqlDbType.TinyInt: return 0;
                    case SqlDbType.Binary: return 0;
                    case SqlDbType.DateTime: return 0;
                    case SqlDbType.SmallDateTime:
                        DateTime date = new DateTime();
                        return date;
                    case SqlDbType.UniqueIdentifier: return "";
                }
                return deger;
            }
            else
            {
                //if (type == SqlDbType.UniqueIdentifier)
                //    return GuidToString(deger);
                //else
                return deger;
            }
        }

        public Object ToDB(Object deger, SqlDbType type)
        {
            //switch (type)
            //{
            //    case SqlDbType.TinyInt:
            //        if (Convert.ToInt32(deger) == 0)
            //            return DBNull.Value;
            //    case SqlDbType.BigInt:
            //        if (Convert.ToInt32(deger) == -1)
            //            return DBNull.Value;
            //    case SqlDbType.Decimal:
            //        if (Convert.ToInt32(deger) == -1)
            //            return DBNull.Value;
            //    case SqlDbType.Float:
            //        if (Convert.ToInt32(deger) == -1)
            //            return DBNull.Value;
            //    case SqlDbType.Int:
            //        if (Convert.ToInt32(deger) == -1)
            //            return DBNull.Value;
            //    case SqlDbType.Money:
            //        if (Convert.ToInt32(deger) == -1)
            //            return DBNull.Value;
            //    case SqlDbType.Real:
            //        if (Convert.ToInt32(deger) == -1)
            //            return DBNull.Value;
            //    case SqlDbType.SmallInt:
            //        if (Convert.ToInt32(deger) == -1)
            //            return DBNull.Value;
            //    case SqlDbType.SmallMoney:
            //        if (Convert.ToInt32(deger) == -1)
            //            return DBNull.Value;
            //}
            if (deger == null)
                return DBNull.Value;
            else
                return deger;
            //else
            //{
            //    if (SqlDbType.UniqueIdentifier == type)
            //        return StringToGuid(deger);
            //}
        }

        public DataTable CreateView(DataTable table, int page, int pagesize, string sort)
        {
            try
            {
                DataView view = table.DefaultView;
                view.Sort = sort;
                DataTable dt = new DataTable();
                dt = view.Table.Clone();
                DataTable dt2 = new DataTable();
                dt2 = view.ToTable();
                int s = 0;
                for (int i = (page - 1) * pagesize; i < view.Table.Rows.Count - 1; i++)
                {
                    dt.ImportRow(dt2.Rows[i]);
                    s += 1;
                    if (s == pagesize)
                        break;
                }
                return dt;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public DataView SortView(DataTable table, string sort)
        {
            try
            {
                DataView view = table.DefaultView;
                view.Sort = sort;
                return view;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlParameter Parameter(string name, SqlDbType type, ParameterDirection direction)
        {
            SqlParameter prm = new SqlParameter();
            prm.ParameterName = name;
            prm.Direction = direction;
            prm.SqlDbType = type;
            return prm;
        }

        public SqlParameter Parameter(string name, SqlDbType type, ParameterDirection direction, Object value)
        {
            SqlParameter prm = new SqlParameter();
            prm.ParameterName = name;
            prm.Direction = direction;
            prm.Value = ToDB(value, type);
            prm.SqlDbType = type;
            return prm;
        }

        public SqlParameter Parameter(string name, SqlDbType type, int size, ParameterDirection direction, Object value)
        {
            SqlParameter prm = new SqlParameter();
            prm.ParameterName = name;
            prm.Direction = direction;
            prm.Value = ToDB(value, type);
            prm.SqlDbType = type;
            prm.Size = size;
            return prm;
        }

        public string GuidToString(Guid val)
        {
            return val.ToString("N");
        }
        //public Guid StringToGuid(String val)
        //{
        //    return (Guid)val;
        //}
    }
}