<%@ Control Language="C#" AutoEventWireup="true" CodeFile="search.ascx.cs" Inherits="kutuphane_search" %>
<table cellpadding="0" cellspacing="0" style="width:150px; padding-top:6px;">
    <tr>
        <td>
            <div style="background-color:#ffffff; width:137px;height:20px;overflow:hidden;">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="padding-left:2px;padding-top:2px;"><div style="background-image:url(images/ImgSearch.png);background-repeat:repeat;width:14px;height:13px;"></div></td>
                        <td style="vertical-align: middle;padding-top:2px;" align="left">
                            <asp:TextBox ForeColor="#b9b8b8" ID="txt_Ara" runat="server" Width="135px" BorderWidth="0" Text="aranacak kelimeyi yazýn..." onblur="if (this.value=='') this.value='aranacak kelimeyi yazýn...'"
                                onfocus="if (this.value=='aranacak kelimeyi yazýn...') this.value=''" Font-Bold="True" Font-Names="Arial" Font-Size="7.5pt"></asp:TextBox>
                        </td>
                        
                    </tr>
                </table>
            </div>
        </td>
        <td style="padding-left:4px;">
            <asp:ImageButton ID="btn_Ara" runat="server" ImageAlign="Middle" ImageUrl="~/images/ImgBtnSearch.png" OnClick="btn_Ara_Click1" />
        </td>
    </tr>
</table>