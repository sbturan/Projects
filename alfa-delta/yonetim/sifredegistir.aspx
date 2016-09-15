<%@ Page Language="C#" MasterPageFile="~/yonetim/yonetim.master" AutoEventWireup="true" CodeFile="sifredegistir.aspx.cs" Inherits="yonetim_sifredegistir" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 800px; position: static">
        <tr>
            <td style="width: 800px; height: 20px;">
                <asp:Label ID="lbl_Baslik" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="11pt"
                    ForeColor="Crimson" Style="position: static" Text="Şifre Değiştirme"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 800px; text-align: left">
               <table cellpadding="2" cellspacing="2" border="0" width="500">
        <tr><td colspan="2"></td></tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="Label2" runat="server" CssClass="caption" Style="position: static"
                Text="Kullanici Adi  :" ToolTip="Kullanici adinizi giriniz"></asp:Label></td>
        <td>
            <asp:TextBox ID="txtKullaniciAdi" runat="server" autocomplete="off" Enabled="False"
                Style="position: static" TabIndex="1" Width="320px"></asp:TextBox></td>
        <td>
        </td>
    </tr>
        <tr>
            <td style="text-align: right"><asp:Label ID="lblUsername" runat="server" AssociatedControlID="txtSifre" AccessKey="þ" ToolTip="Kullanýcý adýnýzý giriniz" Text="Şifre  :" CssClass="caption"></asp:Label></td>
            <td><asp:TextBox ID="txtSifre" runat="server" autocomplete="off" TabIndex="1" Width="320px" ToolTip="Þifrenizi giriniz" TextMode="Password"></asp:TextBox>
            </td>
            <td><asp:RequiredFieldValidator ID="valSifre" runat="server" Display="Dynamic" ControlToValidate="txtSifre" ErrorMessage="<img src='images/warning.gif' width='16' height='16' style='border-style: none' alt='' />"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="text-align: right"><asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtYeniSifre" AccessKey="y" ToolTip="Parolanýzý giriniz" Text="Yeni Şifre :" CssClass="caption"></asp:Label></td>
            <td><asp:TextBox ID="txtYeniSifre" runat="server" autocomplete="off" TabIndex="2" Width="320px" ToolTip="Yeni Þifrenizi Giriniz" TextMode="Password"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="valYeniSifre" runat="server" ControlToValidate="txtYeniSifre"
                    Display="Dynamic" ErrorMessage="<img src='images/warning.gif' width='16' height='16' style='border-style: none' alt='' />"
                    Style="position: static"></asp:RequiredFieldValidator></td>
        </tr>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" AccessKey="t" AssociatedControlID="txtYeniSifreTekrar"
                CssClass="caption" Style="position: static" Text="Yeni Şifreyi Tekrar Giriniz:"
                ToolTip="Parolanýzý giriniz"></asp:Label></td>
        <td>
            <asp:TextBox ID="txtYeniSifreTekrar" runat="server" autocomplete="off" Style="position: static"
                TabIndex="2" TextMode="Password" ToolTip="Yeni Þifrenizi Tekrar Giriniz" Width="320px"></asp:TextBox></td>
        <td>
            <asp:Button ID="btnSubmit" runat="server" TabIndex="3" ToolTip="Giriþ için týklayýn." AccessKey="g" Text="Kaydet" Width="80px" CssClass="button" OnClick="btnSubmit_Click" OnClientClick="this.enabled=false;" style="position: static"></asp:Button></td>
    </tr>
        <tr>
            <td></td>
            <td><asp:Label ID="lblError" runat="server" CssClass="error"></asp:Label></td>
            <td></td>
        </tr>
    </table>
                </td>
        </tr>
    </table>
</asp:Content>

