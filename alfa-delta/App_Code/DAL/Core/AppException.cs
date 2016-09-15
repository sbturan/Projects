using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Core
{
    public partial class AppException
    {
        public AppException()
        {

        }
        string vbNewLine = "vbCrlf";
        public void SaveException(System.Exception ex)
        {
            string filePath = System.Web.HttpContext.Current.Server.MapPath("~/DC/LOG/KORLogFile.txt");
            int GMT = DateTime.Compare(DateTime.Now, DateTime.UtcNow);
            string GMTstring = "";
            if (GMT > 0)
                GMTstring = " (GMT + " + GMT.ToString() + ")";
            else
                GMTstring = GMTstring = " (GMT  " + GMT.ToString() + ")";

            string errorDateTime = DateTime.Now.Year.ToString() + "." + DateTime.Now.Month.ToString() + "." + DateTime.Now.Day.ToString() + " @ " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + GMTstring;
            System.IO.StreamWriter strm = new System.IO.StreamWriter(filePath, true);

            try
            {
                if (ex.InnerException == null)
                    strm.WriteLine("## " + errorDateTime + " ## " + vbNewLine + ex.StackTrace + vbNewLine + vbNewLine + "Message : " + ex.Message + vbNewLine + "Inner Exception :" + ex.InnerException.ToString() + " ##" + vbNewLine);
                else
                {
                    strm.WriteLine("## " + errorDateTime + " ## " + vbNewLine + ex.StackTrace + vbNewLine + vbNewLine + "Message : " + ex.Message + vbNewLine + " ##" + vbNewLine);
                    strm.WriteLine("--------------------------------------------------------------------------------------------------------------------------------" + vbNewLine);
                }
            }
            catch { }
            finally
            {
                strm.Close();
                strm.Dispose();
                strm = null;
            }
        }
    }
}