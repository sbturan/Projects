<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ikbasvuru.ascx.cs" Inherits="kutuphane_ikbasvuru" %>
<style type="text/css">


a
{
	color: #19510E;
	text-decoration: none;
	font-weight: bold;
}

</style>
<table style="width: 332px; position: static">
    <tr>
        <td style="width: 120px; text-align: right" align="left">
            <asp:Label ID="lbl_Adi" runat="server" Font-Bold="True" Style="position: static" Font-Names="Arial" Font-Size="8.5pt">Adı</asp:Label></td>
        <td>
            <asp:TextBox ID="txt_Adi" runat="server" Style="position: static" Width="195px" BorderColor="#A8A8A8" BorderStyle="Solid" BorderWidth="1px" Font-Names="Arial" Font-Size="8.5pt"></asp:TextBox></td>
        <td>
            <asp:RequiredFieldValidator ID="rqf_Adi" runat="server" ControlToValidate="txt_Adi"
                Style="position: static" ValidationGroup="IKBASVURU">*</asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td style="width: 120px; text-align: right" align="left">
            <asp:Label ID="lbl_Soyadi" runat="server" Font-Bold="True" Style="position: static" Font-Names="Arial" Font-Size="8.5pt">Soyadı</asp:Label></td>
        <td>
            <asp:TextBox ID="txt_Soyadi" runat="server" MaxLength="50" Style="position: static"
                Width="195px" BorderColor="#A8A8A8" BorderStyle="Solid" BorderWidth="1px" Font-Names="Arial" Font-Size="8.5pt"></asp:TextBox></td>
        <td>
            <asp:RequiredFieldValidator ID="rqf_Soyadi" runat="server" ControlToValidate="txt_Soyadi"
                Style="position: static" ValidationGroup="IKBASVURU">*</asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td style="width: 120px; height: 26px; text-align: right" align="left">
            <asp:Label ID="lbl_Telefon" runat="server" Font-Bold="True" Style="position: static" Font-Names="Arial" Font-Size="8.5pt">Telefon</asp:Label></td>
        <td>
            <asp:TextBox ID="txt_Telefon" runat="server" MaxLength="20" Style="position: static"
                Width="195px" BorderColor="#A8A8A8" BorderStyle="Solid" BorderWidth="1px" Font-Names="Arial" Font-Size="8.5pt"></asp:TextBox></td>
        <td>
            <asp:RequiredFieldValidator ID="rqf_Telefon" runat="server" ControlToValidate="txt_Telefon"
                Style="position: static" ValidationGroup="IKBASVURU">*</asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td style="width: 120px; text-align: right" align="left">
            <asp:Label ID="lbl_Email" runat="server" Font-Bold="True" Style="position: static" Font-Names="Arial" Font-Size="8.5pt">Email</asp:Label></td>
        <td>
            <asp:TextBox ID="txt_Email" runat="server" MaxLength="100" Style="position: static"
                Width="195px" BorderColor="#A8A8A8" BorderStyle="Solid" BorderWidth="1px" Font-Names="Arial" Font-Size="8.5pt"></asp:TextBox></td>
        <td>
            <asp:RequiredFieldValidator ID="rqf_Email" runat="server" ControlToValidate="txt_Email"
                Style="position: static" ValidationGroup="IKBASVURU">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rge_Email" runat="server" ControlToValidate="txt_Email"
                Style="position: static" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ValidationGroup="IKBASVURU">*</asp:RegularExpressionValidator></td>
    </tr>
    
    <tr>
        <td style="width: 120px; text-align: right" align="left">
            <asp:Label ID="lbl_Dosya" runat="server" Font-Bold="True" Style="position: static" Font-Names="Arial" Text="Yüklenecek Dosya" Font-Size="8.5pt"></asp:Label></td>
        <td style="width: 100px">
            <asp:FileUpload ID="flp_Dosya" runat="server" Style="position: static" Width="195px" BorderColor="#A8A8A8" BorderStyle="Solid" BorderWidth="1px" Font-Names="Arial" Font-Size="8.5pt" /></td>
        <td>
            <asp:RequiredFieldValidator ID="rqf_Dosya" runat="server" ControlToValidate="flp_Dosya"
                Style="position: static" ValidationGroup="IKBASVURU">*</asp:RequiredFieldValidator></td>
    </tr>
     <tr>
        <td style="width: 120px; text-align: right" align="left">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Style="position: static" Font-Names="Arial" Text="Sorunuz" Font-Size="8.5pt"></asp:Label></td>
         <td>
            <asp:TextBox ID="TextBox1" runat="server" MaxLength="100" Style="position: static"
                Width="196px" BorderColor="#A8A8A8" BorderStyle="Solid" BorderWidth="1px" 
                 Font-Names="Arial" Font-Size="8.5pt" Height="109px"></asp:TextBox></td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_Email"
                Style="position: static" ValidationGroup="IKBASVURU">*</asp:RequiredFieldValidator>
           
    </tr>




    <tr><td align="right">
            <asp:Label ID="lbl_Dosya0" runat="server" Font-Bold="True" 
            Style="position: static" Font-Names="Arial" Font-Size="8.5pt">Güvenlik Kodu</asp:Label>
        </td><td>
           
            <asp:Label ID="panpi" runat="server" BackColor="Black" BorderColor="#CCFF66" BorderStyle="Solid" Font-Bold="True" Font-Italic="True" Font-Size="Medium" ForeColor="#6600FF" Width="224px"></asp:Label>
           
        </td></tr>
    <tr><td align="right">
       
    
    
           
       
    
    
            <asp:Label ID="lbl_Dosya1" runat="server" Font-Bold="True" 
            Style="position: static" Font-Names="Arial" Font-Size="8.5pt">Güvenlik Kodunu Doğrulayınız</asp:Label>
       
    
    
           
       
    
    
    </td><td>
        <asp:TextBox ID="txtCaptcha" runat="server" Width="197px"></asp:TextBox> 
    
    </td></tr>
    <tr>
        <td colspan="3" style="text-align: center">
            <asp:Label ID="lbl_Mesaj" runat="server" Font-Bold="True" ForeColor="Crimson" Style="position: static"
                Width="360px" Font-Names="Arial" Font-Size="8.5pt"></asp:Label></td>
    </tr>
    <tr>
        <td style="width: 120px">
        </td>
        <td style="width: 100px">
            <table style="position: static">
                <tr>
                    <td style="width: 100px; text-align: center">
                        <asp:Button ID="btn_Gonder" runat="server" BackColor="#908E8E" CssClass="button"
                            Font-Bold="True" ForeColor="WhiteSmoke" Style="position: static" Text="Gönder"
                            ValidationGroup="IKBASVURU" Width="100px" OnClick="btn_Gonder_Click" /></td>
                    <td style="width: 100px; text-align: center">
                        <asp:Button ID="btn_Vazgec" runat="server" BackColor="#908E8E" CssClass="button"
                            Font-Bold="True" ForeColor="WhiteSmoke" Style="position: static" Text="Vazgeç"
                            Width="100px" /></td>
                </tr>
            </table>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td colspan="3" style="height: 21px; text-align: center">
            <asp:Label ID="lbl_Bilgi" runat="server" Font-Bold="False" ForeColor="Blue" Style="position: static"
                Width="360px" Height="19px"></asp:Label></td>
    </tr>
</table>
<asp:HiddenField ID="hdn_DIL" runat="server" />
<asp:ValidationSummary ID="vs" runat="server" ShowMessageBox="True" ShowSummary="False"
    Style="position: static" ValidationGroup="IKBASVURU" Width="156px" />
