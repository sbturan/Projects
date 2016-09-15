<%@ Control Language="C#" AutoEventWireup="true" CodeFile="urlistatistik.ascx.cs" Inherits="kutuphane_urlistatistik" %>
<table border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td style="width: 20px; height: 20px">
            <asp:Image ID="img_Aktif" runat="server" ImageUrl="~/images/ip.gif" /></td>
        <td style="width: 100px">
<asp:Literal id="ltZiyaret" runat="server"></asp:Literal></td>
    </tr>
    <tr>
        <td style="width: 20px; height: 20px">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/user.gif" /></td>
        <td style="width: 100px">
<asp:Literal ID="ltBugunGiris" runat="server"></asp:Literal></td>
    </tr>
    <tr>
        <td style="width: 20px; height: 20px">
            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/users.gif" /></td>
        <td style="width: 100px">
<asp:Literal ID="ltToplamZiyaretci" runat="server"></asp:Literal></td>
    </tr>
</table>
