<%@ Page Language="C#" MasterPageFile="~/yonetim/yonetim.master" AutoEventWireup="true" CodeFile="emailgonder.aspx.cs" Inherits="yonetim_emailgonder"  ValidateRequest="false" %>

<%@ Register Src="../kutuphane/emailgonder.ascx" TagName="emailgonder" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 800px; position: static">
        <tr>
            <td style="width: 800px">
                <asp:Label ID="lbl_Baslik" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="11pt"
                    ForeColor="Crimson" Style="position: static" Text="Tüm Kullanýcýlara Email Gönder"></asp:Label>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 800px; text-align: center">
                <br />
                <uc1:emailgonder id="Emailgonder1" runat="server">
                </uc1:emailgonder></td>
        </tr>
    </table>
</asp:Content>

