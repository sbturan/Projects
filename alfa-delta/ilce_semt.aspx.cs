using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public partial class ilce_semt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindDropDowns();
    }

    private void BindDropDowns()
    {
        string tip = Request["tip"].ToString();
        string id = Request["id"].ToString();

        //bağlantılar
        SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["MSSqlConnString"]);
        DataTable dataTable = new DataTable();
        SqlCommand sqlCommand = new SqlCommand();
        SqlDataAdapter sqlAdapter = new SqlDataAdapter();

        sqlConnection.Open();
        try
        {
            if (tip == "ilce")
            {
                sqlCommand = new SqlCommand("Select * from ilceler where IlID=@ID", sqlConnection);
            }
            else if (tip == "semt")
            {
                sqlCommand = new SqlCommand("Select * from semtler where IlceID=@ID", sqlConnection);
            }

            sqlCommand.Parameters.Add("ID", SqlDbType.NVarChar);
            sqlCommand.Parameters["ID"].Value = id;

            sqlAdapter = new SqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dataTable);

            if (tip == "ilce")
                Response.Write(DataTableToJSon("0", dataTable, "IlceID,Ad"));
            else if (tip == "semt")
                Response.Write(DataTableToJSon("0", dataTable, "SemtID,Ad"));
        }
        catch
        {
            Response.Write("");
        }
        finally
        {
            sqlConnection.Close();
        }
    }

    /// <summary>Verilen datatable'ı JSON string olarak döndürür.</summary>
    /// <param name="type">"0" ise kolon adlarıyla dönüş yapar."1" ise row-col şeklinde dönüş yapar.</param>
    /// <param name="dt">JSON'a dönüştürülecek DataTable.</param>
    /// <param name="allowCols">İstenilen kolonlar.Virgül ile ayrılarak yazılacak.</param>
    /// <returns>JSON String.</returns>
    public string DataTableToJSon(string type, DataTable dt, string allowCols)
    {
        //allowCols string ini indexof kullanabilmek için List e atıyoruz
        List<string> listCols = new List<string>();
        if (allowCols != null)
        {
            foreach (string s in allowCols.Split(','))
            {
                listCols.Add(s);
            }
        }

        //dönüş string i
        StringBuilder JsonString = new StringBuilder();
        if (dt != null && dt.Rows.Count > 0)
        {
            if (type == "0")
            {
                JsonString.Append("{ ");
                JsonString.Append("\"Head\":[ ");
            }
            else
            {
                JsonString.Append("{ ");
                JsonString.Append("\"TABLE\":[{ ");
                JsonString.Append("\"ROW\":[ ");
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (type != "0")
                    JsonString.Append("\"COL\":[ ");

                JsonString.Append("{ ");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    //allowCols null sa veya bu colon allowCols ta var ise
                    if ((allowCols == null) || (listCols.IndexOf(dt.Columns[j].ColumnName.ToString()) > -1))
                    {
                        if (j < dt.Columns.Count - 1)
                        {
                            if (type == "0")
                                JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + dt.Rows[i][j].ToString() + "\",");
                            else
                                JsonString.Append("{" + "\"DATA\":\"" + dt.Rows[i][j].ToString() + "\"},");
                        }
                        else if (j == dt.Columns.Count - 1)
                        {
                            if (type == "0")
                                JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + dt.Rows[i][j].ToString() + "\"");
                            else
                                JsonString.Append("{" + "\"DATA\":\"" + dt.Rows[i][j].ToString() + "\"}");
                        }
                    }
                }
                if (i == dt.Rows.Count - 1)
                {
                    if (type == "0")
                        JsonString.Append("} ");
                    else
                        JsonString.Append("]} ");
                }
                else
                {
                    if (type == "0")
                        JsonString.Append("}, ");
                    else
                        JsonString.Append("]}, ");
                }
            }
            if (type == "0")
                JsonString.Append("]}");
            else
                JsonString.Append("]}]}");
            return JsonString.ToString();
        }
        else
        {
            return null;
        }
    }
}