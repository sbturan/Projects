<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="sifremiunuttum.aspx.cs" Inherits="sifremiunuttum" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  
<table style="width: 393px"><tr>
    <td style="height: 65px"></td>
    <td style="height: 65px">&nbsp;</td>
    <td style="height: 65px">&nbsp;</td>
    <td style="height: 65px; width: 242px; color:#FF7D00">
        Şifremi Unuttum</td>
    </tr>
    <br />
    <tr><td style="color:#FF7D00">
        Mail Adresiniz:</td><td style="color:#FF7D00">
            &nbsp;</td><td style="color:#FF7D00">
            &nbsp;</td><td style="width: 242px">
        <asp:TextBox ID="YourEmail" runat="server" Width="250px" Height="22px" /></td>
        </tr>
        
    <tr><td style="height: 90px">
        
        </td><td style="height: 90px">
        
            &nbsp;</td><td style="height: 90px">
        
            &nbsp;</td><td style="height: 90px; width: 242px">
        <asp:Button ID="Button1" runat="server" Text="Gönder" onclick="Button1_Click" />
    </td>
    </tr>
    <tr >
    <td style=" width: 393px">
    <asp:Label ID="Label1" runat="server"></asp:Label></td>
    </tr>
    </table>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="SqlDataSource1" EnableModelValidation="True">
        <Columns>
            
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:alfa-deltaConnectionString %>" 
        
        SelectCommand="SELECT [portnumber], [email], [smtp], [sifre] FROM [gerekliler]"></asp:SqlDataSource>
</asp:Content>
