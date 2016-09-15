<%@ Control Language="C#" AutoEventWireup="true" CodeFile="emailgonder.ascx.cs" Inherits="kutuphane_emailgonder" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
&nbsp;<asp:Label ID="lbl_Mesaj" runat="server" Font-Bold="False" Style="position: static"
    Visible="False" Width="256px"></asp:Label><br />
<table style="position: static">
    <tr>
        <td style="width: 100px; text-align: right">
            <span style="font-size: 10pt; font-family: Tahoma"><strong>Konu</strong></span></td>
        <td style="width: 500px">
            <asp:TextBox ID="txt_Konu" runat="server" Style="position: static" Width="490px"></asp:TextBox></td>
        <td style="width: 100px">
            <asp:RequiredFieldValidator ID="rqf_Konu" runat="server" ControlToValidate="txt_Konu"
                ErrorMessage="Konu Giriniz" Style="position: static" ValidationGroup="EMAIL">*</asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td style="width: 100px; text-align: right; height: 402px;" valign="top">
            <span style="font-size: 10pt; font-family: Tahoma"><strong>Mesaj</strong></span></td>
        <td style="width: 100px; height: 402px;">
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
        <td style="width: 100px">
            <asp:CheckBoxList ID="chklist_dil" runat="server" RepeatDirection="Horizontal" Style="position: static"
                ValidationGroup="EMAIL" DataSourceID="XmlDil" DataTextField="adi" 
                DataValueField="id" Font-Names="Tahoma" Font-Size="10pt" Visible="False">
            </asp:CheckBoxList></td>
        <td style="width: 100px" valign="top">
        </td>
    </tr>
    <tr>
        <td style="width: 100px; text-align: right" valign="top">
        </td>
        <td style="width: 100px">
        </td>
        <td style="width: 100px" valign="top">
        </td>
    </tr>
    <tr>
        <td style="width: 100px">
        </td>
        <td style="width: 500px; text-align: center">
            <table style="width: 192px; position: static">
                <tr>
                    <td style="width: 100px; text-align: center">
                        <asp:Button ID="btn_Gonder" runat="server" Style="position: static" Text="Gönder"
                            Width="80px" OnClick="btn_Gonder_Click" CssClass="button" Font-Bold="True" /></td>
                    <td style="width: 100px">
                    </td>
                    <td style="width: 100px; text-align: center">
                        <asp:Button ID="btn_Vazgec" runat="server" Style="position: static" Text="Vazgeç"
                            Width="80px" CssClass="button" Font-Bold="True" /></td>
                </tr>
            </table>
        </td>
        <td style="width: 100px">
        </td>
    </tr>
</table>
<asp:XmlDataSource ID="XmlDil" runat="server" DataFile="~/XML/XMLFile.xml" XPath="root/dil/item">
</asp:XmlDataSource>
