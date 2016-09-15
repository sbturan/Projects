<%@ Control Language="C#" AutoEventWireup="true" CodeFile="kisilereemailgonder.ascx.cs" Inherits="kutuphane_kisilereemailgonder" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<style type="text/css">
    .style1
    {
        width: 417px;
    }
    .style2
    {
        height: 402px;
        width: 417px;
    }
</style>
&nbsp;<asp:Label ID="lbl_Mesaj" runat="server" Font-Bold="False" Style="position: static"
    Visible="False" Width="256px"></asp:Label><br />
<table style="position: static">
    <tr>
            <td style="width: 300px; text-align: center">
                <asp:ListBox ID="lstsecimlik" runat="server" Width="239px" 
                    DataSourceID="ObjectDataSource1" DataTextField="EMAIL" 
                    DataValueField="EMAIL" SelectionMode="Multiple"></asp:ListBox>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
                    TypeName="MailListeBLL">
                </asp:ObjectDataSource>
            </td>
                <td  style="text-align: center" class="style1">
                    <asp:Button ID="Button1" runat="server" Text=">" Width="74px" 
                        onclick="Button1_Click" /><br /><br />
                    <asp:Button ID="Button2" runat="server" Text="<" Width="74px" 
                        onclick="Button2_Click" /> <br /><br />
                    <asp:Button ID="Button4" runat="server" Text="Tümünü Temizle" 
                        onclick="Button4_Click" />  
                </td>
                <td  style="width: 300px; text-align: center">
                <asp:ListBox ID="lstsecilen" runat="server" Width="200px" SelectionMode="Multiple"></asp:ListBox>
                </td>
                
        </tr>
        <tr>
        <td>
        </td>
        </tr>
    
    
    
    
    <tr>
        <td style="width: 100px; text-align: right">
            <span style="font-size: 10pt; font-family: Tahoma"><strong>Konu</strong></span></td>
        <td class="style1">
            <asp:TextBox ID="txt_Konu" runat="server" Style="position: static" Width="490px"></asp:TextBox></td>
        <td style="width: 100px">
            <asp:RequiredFieldValidator ID="rqf_Konu" runat="server" ControlToValidate="txt_Konu"
                ErrorMessage="Konu Giriniz" Style="position: static" ValidationGroup="EMAIL">*</asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td style="width: 100px; text-align: right; height: 402px;" valign="top">
            <span style="font-size: 10pt; font-family: Tahoma"><strong>Mesaj</strong></span></td>
        <td class="style2">
            <fckeditorv2:fckeditor id="FCKeditor1" runat="server" height="400px" toolbarset="Basic"
                width="500px" BasePath="fckeditor/"></fckeditorv2:fckeditor>
        </td>
        <td style="width: 100px; height: 402px;" valign="top">
            <asp:RequiredFieldValidator ID="rqf_Mesaj" runat="server" ControlToValidate="FCKeditor1"
                ErrorMessage="Konu Giriniz" Style="position: static" ValidationGroup="EMAIL">*</asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td style="width: 100px; text-align: right" valign="top">
            <strong><span style="font-size: 10pt; font-family: Tahoma"></span></strong>
        </td>
        <td class="style1">
            &nbsp;</td>
        <td style="width: 100px" valign="top">
        </td>
    </tr>
    <tr>
        <td style="width: 100px; text-align: right" valign="top">
        </td>
        <td class="style1">
        </td>
        <td style="width: 100px" valign="top">
        </td>
    </tr>
    <tr>
        <td style="width: 100px">
        </td>
        <td style="text-align: center" class="style1">
            <table style="width: 192px; position: static">
                <tr>
                    <td style="width: 100px; text-align: center">
                        <asp:Button ID="btn_Gonder" runat="server" Style="position: static" Text="Listeye Gönder"
                            Width="109px" OnClick="btn_Gonder_Click" CssClass="button" 
                            Font-Bold="True" /></td>
                     <td>
                         &nbsp;</td>
        <td>
            &nbsp;</td>
                    
                    <td style="width: 100px">
                        <asp:Button ID="btn_Vazgec" runat="server" Style="position: static" Text="Vazgeç"
                            Width="80px" CssClass="button" Font-Bold="True" Height="26px" />
                    </td>
                    <td style="width: 100px; text-align: center">
                        &nbsp;</td>
            
                </tr>
            </table>
        </td>
        <td style="width: 100px">
        </td>
    </tr>
    
</table>
<asp:XmlDataSource ID="XmlDil" runat="server" DataFile="~/XML/XMLFile.xml" XPath="root/dil/item">
</asp:XmlDataSource>
