<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/yonetim.master" AutoEventWireup="true" CodeFile="loglar.aspx.cs" Inherits="yonetim_loglar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table><tr><td width="60px">
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="ObjectDataSource1" EnableModelValidation="True" OnRowCreated="GridView1_RowCreated">
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        </asp:GridView>
        </td></tr>
        <tr><td>
            <asp:LinkButton ID="ExceleAktarLinkButton" runat="server" OnClick="ExceleAktarLinkButton_Click">Excele Aktar</asp:LinkButton>

            </td></tr>

    </table>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        DataObjectTypeName="LogInfo" InsertMethod="Insert" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetTumLoglar" 
        TypeName="LogBLL"></asp:ObjectDataSource>
</asp:Content>

