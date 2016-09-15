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
/// Summary description for Foto
/// </summary>
public class Fotograf
{
    #region Fields

    protected int _id;
    protected string _foto_adi;
    protected string _foto;
 
    #endregion

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }
    public string Foto_Adi
    {
        get { return _foto_adi; }
        set { _foto_adi = value; }
    }

    public string Foto
    {
        get { return _foto; }
        set { _foto = value; }
    }

	public Fotograf()
	{

        _id = -1;
        //
		// TODO: Add constructor logic here
		//
	}
}
