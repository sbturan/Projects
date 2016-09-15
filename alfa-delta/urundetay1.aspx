<%@ Page Language="C#" AutoEventWireup="true" CodeFile="urundetay1.aspx.cs" Inherits="urundetay1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 <%@ Register Src="~/kutuphane/Navigasyon1.ascx" TagName="Navigasyon" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    

   

    
   

         
        <table align="center">
            <tr>
                <td>
                
                    &nbsp;</td>



            </tr>


        <tr>
            <td class="style1" colspan="2" rowspan="3" align="center">
                
                &nbsp;</td>
            
            <td class="spec">
                <table class="style9">
                    <tr>
                        <td style="padding-left:50px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        
        
        </table> 
        
        
        
        
      
          
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        DataObjectTypeName="UrunInfo" DeleteMethod="Delete" InsertMethod="Insert" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetUrunByID" 
        TypeName="UrunBLL" UpdateMethod="Update">
        <SelectParameters>
            <asp:QueryStringParameter Name="ID" QueryStringField="ID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

    </div>
    </div>
    </form>
</body>
</html>
