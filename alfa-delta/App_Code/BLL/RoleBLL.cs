using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using AlfaDeltaLogin;

/// <summary>
/// Summary description for UserBLL
/// </summary>
[DataObjectAttribute]
public class RoleBLL
{
	public RoleBLL()
	{}

    #region Select Type Operations
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public DataTable GetRoleList()
    {
        DataTable dst_Roles = new DataTable();
        dst_Roles = Role.GetRoles().Tables[0];
        

        return dst_Roles;
    }

    #endregion


}
