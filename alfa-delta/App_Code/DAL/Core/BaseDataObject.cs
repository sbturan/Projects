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
/// Summary description for BaseDataObject
/// </summary>
/// 
namespace Core
{
    public class BaseDataObject : DBTools
    {


        private readonly string Constr = System.Configuration.ConfigurationManager.ConnectionStrings["MSSqlConnString"].ConnectionString;
        private SqlConnection connection;
        //string vbNewLine = "vbCrlf";
        //public void SaveException(System.Exception ex)
        //{
        //    string filePath = System.Web.HttpContext.Current.Server.MapPath("~/DC/LOG/KORLogFile.txt");
        //    int GMT = DateTime.Compare(DateTime.Now, DateTime.UtcNow);
        //    string GMTstring = "";
        //    if (GMT > 0)
        //        GMTstring = " (GMT + " + GMT.ToString() + ")";
        //    else
        //        GMTstring = GMTstring = " (GMT  " + GMT.ToString() + ")";

        //    string errorDateTime = DateTime.Now.Year.ToString() + "." + DateTime.Now.Month.ToString() + "." + DateTime.Now.Day.ToString() + " @ " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + GMTstring;
        //    System.IO.StreamWriter strm = new System.IO.StreamWriter(filePath, true);

        //    try
        //    {
        //        if (ex.InnerException == null)
        //            strm.WriteLine("## " + errorDateTime + " ## " + vbNewLine + ex.StackTrace + vbNewLine + vbNewLine + "Message : " + ex.Message + vbNewLine + "Inner Exception :" + ex.InnerException.ToString() + " ##" + vbNewLine);
        //        else
        //        {
        //            strm.WriteLine("## " + errorDateTime + " ## " + vbNewLine + ex.StackTrace + vbNewLine + vbNewLine + "Message : " + ex.Message + vbNewLine + " ##" + vbNewLine);
        //            strm.WriteLine("--------------------------------------------------------------------------------------------------------------------------------" + vbNewLine);
        //        }
        //    }
        //    catch { }
        //    finally
        //    {
        //        strm.Close();
        //        strm.Dispose();
        //        strm = null;
        //    }
        //}
        public BaseDataObject()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void New()
        {
            connection = new SqlConnection(Constr);
        }
        public void closeConnection()
        {
            connection = new SqlConnection(Constr);
            if (this.connection.State == ConnectionState.Open)
                connection.Close();
        }
        public void openConnection()
        {
            connection = new SqlConnection(Constr);
            if ((this.connection.State == ConnectionState.Closed) || (this.connection.State == ConnectionState.Broken))
                connection.Open();
        }

        //public int RunProcedure(string storedProcName, IDataParameter[] parameters, int rowsAffected, Boolean AutoConnection)
        //{
        //    SqlCommand command = BuildQueryCommand(storedProcName, parameters, AutoConnection);
        //    command.Connection = connection;
        //    try
        //    {
        //        rowsAffected = command.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        closeConnection();
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (AutoConnection == true)
        //            closeConnection();
        //    }
        //    return rowsAffected;
        //}

        //public int RunSQL(string sqlCommand, IDataParameter[] parameters)
        //{
        //    int result = 1;
        //    SqlCommand command = BuildQueryCommand(sqlCommand, CommandType.Text, parameters, true);
        //    try
        //    {
        //        command.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally { closeConnection(); }
        //    return result;
        //}

        //public string RunScalar(string storedProcName, IDataParameter[] parameters, string Field, Boolean AutoConnection)
        //{
        //    string result = "";
        //    SqlDataReader reader;
        //    reader = null;
        //    try
        //    {
        //        reader = RunProcedure(storedProcName, parameters, "reader", AutoConnection);
        //        reader.Read();
        //    }
        //    catch (Exception ex)
        //    {
        //        closeConnection();
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (AutoConnection == true)
        //            closeConnection();
        //        reader.Close();
        //    }
        //    return result;
        //}

        //public SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters, string reader, Boolean AutoConnection)
        //{
        //    SqlDataReader returnReader;
        //    try
        //    {
        //        SqlCommand command = BuildQueryCommand(storedProcName, parameters, AutoConnection);
        //        returnReader = command.ExecuteReader(CommandBehavior.CloseConnection);
        //    }
        //    catch (Exception ex)
        //    {
        //        closeConnection();
        //        throw ex;
        //    }
        //    return returnReader;
        //}

        //public SqlDataReader RunProcedure(string storedProcName, string reader, Boolean AutoConnection)
        //{
        //    SqlDataReader returnReader;
        //    try
        //    {
        //        SqlCommand command = new SqlCommand(storedProcName, connection);
        //        if (AutoConnection == true)
        //            openConnection();
        //        returnReader = command.ExecuteReader(CommandBehavior.CloseConnection);
        //    }
        //    catch (Exception ex)
        //    {
        //        closeConnection();
        //        throw ex;
        //    }
        //    return returnReader;
        //}

        //public DataTable RunProcedure(string storedProcName)
        //{
        //    DataTable dataTable = new DataTable();
        //    try
        //    {
        //        openConnection();
        //        SqlCommand cmd = new SqlCommand(storedProcName, connection);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
        //        sqlDA.Fill(dataTable);
        //    }
        //    catch (Exception ex)
        //    {
        //        SaveException(ex);
        //        closeConnection();
        //        throw ex;
        //    }
        //    return dataTable;
        //}
        public DataTable RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(storedProcName, parameters, true);
                sqlDA.Fill(dataTable);
            }
            catch (Exception ex)
            {
                closeConnection();
                throw ex;
            }
            finally
            {
                closeConnection();
            }
            return dataTable;
        }


        //public DataTable RunSQLForDT(string sql, CommandType commandtype, IDataParameter[] parameters, int page, int pagesize)
        //{
        //    DataTable dataTable = new DataTable();
        //    SqlCommand command = BuildQueryCommand(sql, commandtype, parameters, false);
        //    try
        //    {
        //        SqlDataAdapter sqlDA = new SqlDataAdapter(command);
        //        if (pagesize > 0)
        //            sqlDA.Fill(dataTable);
        //        else
        //            sqlDA.Fill(((page - 1) * pagesize), pagesize, dataTable);
        //    }
        //    catch (Exception ex)
        //    {
        //        closeConnection();
        //        throw ex;
        //    }
        //    finally
        //    {
        //        closeConnection();
        //    }
        //    return dataTable;
        //}

        public SqlCommand BuildQueryCommand(string storedProcName, IDataParameter[] parameters, Boolean AutoConnect)
        {
            return BuildQueryCommand(storedProcName, CommandType.StoredProcedure, parameters, AutoConnect);
        }

        public SqlCommand BuildQueryCommand(string sqlcommand, CommandType commandType, IDataParameter[] parameters, Boolean AutoConnect)
        {
            SqlCommand command = new SqlCommand(sqlcommand, connection);
            command.CommandType = commandType;
            if ((parameters != null))
            {
                SqlParameter parameter = default(SqlParameter);
                foreach (IDataParameter p in parameters)
                {
                    command.Parameters.Add(p);
                }
            }
            if (AutoConnect == true)
            {
                closeConnection();
                openConnection();
            }
            command.Connection = connection;
            return command;
        }

    }

    public class BaseDataObjectForUI : BaseDataObject
    {
        //public BaseDataObjectForUI()
        //{
            
        //     TODO: Add constructor logic here
            
        //}

        //public int Run(string sql, IDataParameter[] parameters)
        //{
        //    return RunSQL(sql, parameters);
        //}

        //public DataTable GetDataTable(string sql, IDataParameter[] parameters)
        //{
        //    return RunSQLForDT(sql, CommandType.Text, parameters, 1, 0);
        //}
    }
}