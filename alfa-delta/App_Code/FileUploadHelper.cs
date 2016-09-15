using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using AlfaDeltaLogin;
using System.Net.Mail;
using System.Net;
using System.Collections.Generic;

/// <summary>
/// Summary description for FileUploadHelper
/// </summary>
public class FileUploadHelper
{
    public FileUploadHelper(string uploadPath, System.Web.UI.WebControls.FileUpload htmlInputFileControl)
    {
        this._uploadPath = uploadPath;
        this._htmlInputFileControl = htmlInputFileControl;
        this._maxSize = int.MaxValue;
    }

    private string _uploadPath;
    private System.Web.UI.WebControls.FileUpload _htmlInputFileControl;
    private int _maxSize;

    private bool isFileValid()
    {
        int fileSize = _htmlInputFileControl.PostedFile.ContentLength;
        string contentType = this._htmlInputFileControl.PostedFile.ContentType;

        if ( fileSize == 0) // dosya büyüklüðünü komtrol et
            return false;
        else if (this.ContentTypes.Count > 0)
        {
            // Dosya içeriðini kontrol et :
            if (this.ContentTypes.Contains(contentType))
                return true;
            else
                return false;
        }
        else
            return true;
    }

    public int MaxUploadSize
    {
        set
        {
            if (value > 0)
                _maxSize = value;
            else
                _maxSize = 0;
        }

        get { return this._maxSize; }
    }

    public ArrayList ContentTypes = new ArrayList();

    public bool UploadFile()
    {
        if (this.isFileValid())
        {
            try
            {
                this._htmlInputFileControl.PostedFile.SaveAs(this._uploadPath);
            }
            catch
            {
                

            }
            return true;
        }
        else
        {
            return false;
        }
    }

    
    public FileUploadHelper()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
