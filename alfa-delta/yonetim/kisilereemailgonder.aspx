<%@ Page Language="C#" MasterPageFile="~/yonetim/yonetim.master" AutoEventWireup="true" CodeFile="kisilereemailgonder.aspx.cs" Inherits="yonetim_kisilereemailgonder"  ValidateRequest="false" %>

<%@ Register Src="../kutuphane/kisilereemailgonder.ascx" TagName="emailgonder" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 800px; position: static">
        <tr>
            <td style="width: 800px">
                <asp:Label ID="lbl_Baslik" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="11pt"
                    ForeColor="Crimson" Style="position: static" Text="Kisilere Email Gönder"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" Text="Tum kullanicalara mail yollamak icin CTRL+SHIFT tusuna basili tutarak tum kullanicilari secip bir seferede soldan saga aktararak tumune mail yollayabilirsiniz" Font-Bold="True" ForeColor="#CC3300"></asp:Label>
            </td>
        </tr>
        <tr>
        <td>
         <uc1:emailgonder id="Emailgonder1" runat="server">
                </uc1:emailgonder>
        </td>
        
        </tr>
        </table>
   
</asp:Content>

