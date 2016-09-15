<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MenuPopup.aspx.cs" Inherits="yonetim_MenuPopup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellpadding="4" cellspacing="0" width="250">
    <tr>
    <td colspan="2">
        <asp:Label ID="Menu_Adi" runat="server" Text="Menü Ekleme Bölümü"></asp:Label>
    </td>
    </tr>
    <tr>
    <td colspan="2">
        <asp:Label ID="Label1" runat="server" Text="Þu Anda þu bölüme ekliyorsunuz"></asp:Label>
    </td>
    </tr>
    <tr>
    <td align="right" style="padding-right:10px;">
        Menü Adý :
    </td>
    <td>
        <asp:TextBox ID="txt_MenuAd" Width="150" runat="server"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td align="right" style="padding-right:10px;">
        Menü Adý :
    </td>
    <td>
        <asp:TextBox ID="txt_MenuLink" Width="150" runat="server"></asp:TextBox>
    </td>
    </tr>
    <tr valign="top">
    <td align="right" style="padding-right:10px;">
        Target :
    </td>
    <td>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Text="Self" Value="0" Selected="True"></asp:ListItem>
        <asp:ListItem Text="Blank" Value="1"></asp:ListItem>
        </asp:RadioButtonList>
    </td>
    </tr>
    <tr valign="top">
    <td align="right" style="padding-right:10px;">
       
    </td>
    <td>
    <asp:Button ID="btn_Guncelle" runat="server" CssClass="button" Font-Bold="True" Text="Güncelle" Width="110px" />&nbsp;
    </td>
    </tr>
    <tr>
    <td colspan="2">
    <a href="#" >Sayfa ID lerini Göster</a>
    </td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
