<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/yonetim.master" AutoEventWireup="true" CodeFile="Mailduzenle.aspx.cs" Inherits="yonetim_Mailduzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="height: 44px; width: 559px"><tr><td style="height: 39px" 
        width="100px" align="center">
    <asp:Label ID="Label1" runat="server" Text="Mail"></asp:Label>   </td>
<td style="height: 39px" align="center">
    <asp:Label ID="Label2" runat="server" Text="Sifre" width="100px"></asp:Label></td>
<td style="height: 39px" align="center">
    <asp:Label ID="Label3" runat="server" Text="PORT" width="100px"></asp:Label></td>
<td style="height: 39px" align="center">
    <asp:Label ID="Label4" runat="server" Text="SMTF BILGISI" width="100px"></asp:Label></td></tr><tr>
<td>
    <asp:TextBox ID="txt_mail" runat="server"></asp:TextBox> </td>
<td style="height: 39px"width="100px">
    <asp:TextBox ID="txt_sifre" runat="server"></asp:TextBox> </td>
<td style="height: 39px" width="100px">
    <asp:TextBox ID="txt_port" runat="server"></asp:TextBox></td>
<td style="height: 39px" width="100px">
   <asp:TextBox ID="txt_smtf" runat="server"></asp:TextBox></td></tr><tr><td>
       <asp:Label ID="Label5" runat="server" Text="Basariyla Guncellenmistir"></asp:Label>
   </td></tr></table>
   <div style=" width:550px; float:right" >
    <asp:Button ID="Button1" runat="server" onclientclick="return confirm('Onaylamak istiyormusun?')" Text="Guncelle" onclick="Button1_Click" /></div>
</asp:Content>

