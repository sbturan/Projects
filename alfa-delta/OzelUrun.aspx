<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OzelUrun.aspx.cs"
    Inherits="tr_ikbasvuru" Title="Untitled Page" %>

<%@ Register Src="kutuphane/ikbasvuru.ascx" TagName="ikbasvuru" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" style="position: static; width: 588px;
        vertical-align: top">
        <tr>
            <td style="text-align: left" valign="middle">
                <table border="0" cellpadding="0" cellspacing="0" style="height: 27px; width: 100%;">
                    <tr style="background-color: #a8a8a8;">
                        <td align="left" style="line-height: 30px; padding-left: 8px; height: 30px; color: #FFF;
                            font-size: 9pt; font-weight: bold; font-family: Arial; width: 100%;" colspan="3">
                            <img src="images/baslik_yan.png" style="vertical-align: middle;" />&nbsp;&nbsp;
                            <asp:Label ID="Label1" runat="server" Text="ÖZEL ÜRÜN ÇİZİM FORMU"></asp:Label>                   </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="padding-right: 10px; padding-left: 10px; height: 380px; text-align: justify"
                valign="top">
                <table style="width: 100%">
                    <tr>
                        <td colspan="2" valign="top">
                <asp:Label ID="lbl_IkBilgi" runat="server" Font-Bold="True" Font-Size="8.5pt" Style="position: static"
                    Width="424px" ForeColor="#FF6633" Font-Names="Arial" Visible="False"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2" valign="top">
                            <asp:Label ID="lblAciklama" runat="server" Font-Names="Arial" Font-Size="8.5pt" ForeColor="#404040"
                                Visible="False"></asp:Label></td>
                    </tr>
                    <tr>
                        <td valign="top" style="text-align:left" align="left">
                <uc1:ikbasvuru ID="Ikbasvuru1" runat="server" />
                        </td>
                       
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
