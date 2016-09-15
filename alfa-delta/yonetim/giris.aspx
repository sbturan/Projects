<%@ Page Language="C#" MasterPageFile="~/yonetim/yonetim.master" AutoEventWireup="true" CodeFile="giris.aspx.cs" Inherits="yonetim_giris" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table cellpadding="2" cellspacing="2" border="0" width="500">
        <tr><td colspan="2">
            <asp:Label ID="Label1" runat="server" Style="position: static" Width="400px"></asp:Label></td></tr>
        <tr><td colspan="2"><div class="subtitle">Lütfen giriş yapınız.</div></td></tr>
        <tr>
            <td><asp:Label ID="lblUsername" runat="server" AssociatedControlID="txtUsername" AccessKey="k" ToolTip="Kullanýcý adýnýzý giriniz" Text="Kullanıcı Adı:" CssClass="caption"></asp:Label></td>
            <td><asp:TextBox ID="txtUsername" runat="server" autocomplete="off" TabIndex="1" Width="320px" ToolTip="Kullanýcý adýnýzý giriniz"></asp:TextBox>
            </td>
            <td><asp:RequiredFieldValidator ID="valUsername" runat="server" Display="Dynamic" ControlToValidate="txtUserName" ErrorMessage="<img src='images/warning.gif' width='16' height='16' style='border-style: none' alt='' />"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword" AccessKey="p" ToolTip="Parolanýzý giriniz" Text="<u>P</u>arola:" CssClass="caption"></asp:Label></td>
            <td><asp:TextBox ID="txtPassword" runat="server" autocomplete="off" TabIndex="2" Width="320px" ToolTip="Parolanýzý giriniz" TextMode="Password"></asp:TextBox></td>
            <td><asp:Button ID="btnSubmit" runat="server" TabIndex="3" ToolTip="Giriş için tıklayın." AccessKey="g" Text="Giriş" Width="80px" CssClass="button" OnClick="btnSubmit_Click" OnClientClick="this.enabled=false;"></asp:Button></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Label ID="lblError" runat="server" CssClass="error"></asp:Label></td>
            <td></td>
        </tr>
        <tr><td colspan="3"><div class="footnote">Lütfen giriş yapmak için emailinizi ve parolanızı girerek "Giriş" tuşuna basınız.<br /><br />İşlemlerinizi yaparken bu sayfaya yönlendirildiyseniz, oturumunuz zaman aşımına uğramış olabilir ya da erişimi kayıtlı bir sayfayı açmaya çalışmış olabilirsiniz.<br />Her iki durumda da tekrar giriş yapmanız gerekecektir.</div></td></tr>
        
    </table>

</asp:Content>

