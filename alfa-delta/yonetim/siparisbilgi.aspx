<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/yonetim.master" AutoEventWireup="true" CodeFile="siparisbilgi.aspx.cs" Inherits="yonetim_siparisbilgi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <table><tr><td>
       <asp:Label ID="Label1" runat="server" Text="Durum  Seçiniz:"></asp:Label>
   </td><td>
    <asp:DropDownList ID="DropDownList1" runat="server" style="margin-left: 0px; top: -2px; left: 1px; width: 214px; height: 23px;" 
                    BackColor="Black" CssClass="MainLiStyle" ForeColor="#FF7D00" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                    AutopostBack="True" 
        DataSourceID="ObjectDataSource1" DataTextField="DURUM_ADI" DataValueField="SD_ID" 
        Height="20px" Width="158px">
    </asp:DropDownList></td></tr></table>
   
    
    




    

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        DataObjectTypeName="SaDuInfo" DeleteMethod="Delete" InsertMethod="Insert" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetTumSaDu" 
        TypeName="SaDuBLL" UpdateMethod="Update"></asp:ObjectDataSource>
</asp:Content>

