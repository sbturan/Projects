<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/yonetim.master" AutoEventWireup="true" CodeFile="logkisi.aspx.cs" Inherits="yonetim_logkisi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
        <p>
            Belirli bir zamandan önceki logları silmek için bu modülü kullanınız.</p>
    <table>
        
         <tr><td align="right">
             <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>


            </td></tr>
        
        <tr><td>


        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
               </td></tr>
        <tr><td align="right">
            <asp:Button ID="Button1" runat="server" Text="SİL" Width="111px" OnClick="Button1_Click" />


            </td></tr>


    </table>
    
        </asp:Content>

