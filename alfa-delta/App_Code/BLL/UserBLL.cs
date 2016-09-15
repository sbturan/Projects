using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using AlfaDeltaLogin;

/// <summary>
/// Summary description for UserBLL
/// </summary>
[DataObjectAttribute]
public class UserBLL
{
	public UserBLL()
	{}

    #region Select Type Operations
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public DataTable GetUserList()
    {
        DataTable dst_User = new DataTable();
        dst_User = Kullanici.GetUsers().Tables[0];
        

        return dst_User;
    }

    #endregion


}
