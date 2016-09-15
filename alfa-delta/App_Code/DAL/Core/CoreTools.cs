using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for CoreTools
/// </summary>
/// 
namespace Core
{

    public class CoreTools
    {
        public CoreTools()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string HtmlEncode(string text)
        {
            if (text != "")
            {
                text = text.Replace("<", "&lt;");
                text = text.Replace(">", "&gt;");
                return text;
            }
            else
                return "";
        }

        public string HtmlDecode(string text)
        {
            return text;
        }

        public int SayfaSayisiAyarla(int toplamKayit, int SayfaBoyutu)
        {
            if((toplamKayit>0) && (SayfaBoyutu>0))
                return 1;
            return 1;
        }

        public string Encrypt(System.Int64 ID)
        {
            return ID.ToString();
        }

        public System.Int64 Encrypt(String ID)
        {
            return Convert.ToInt64(ID);
        }
    }
}