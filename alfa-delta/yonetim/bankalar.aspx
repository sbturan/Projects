<%@ Page Language="C#" MasterPageFile="~/yonetim/yonetim.master" AutoEventWireup="true" CodeFile="bankalar.aspx.cs" Inherits="yonetim_bank" Title="Untitled Page" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 102%">
        <tr>
            <td style="width: 100%; height: 25px">
                <asp:Label ID="lbl_Baslik" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="11pt"
                    ForeColor="#CC0000" Style="position: static" Text="BANKA BİLGİLERİ" Width="392px"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" style="width: 100%; height: 25px; text-align: right">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="ObjectBannerlar" EnableModelValidation="True" OnRowCreated="GridView1_RowCreated" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/yonetim/images/edit.gif" ShowSelectButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 272px" valign="top">
               
                <asp:ObjectDataSource ID="ObjectBannerlar" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetBilgiler" TypeName="BankBLL" 
                    DataObjectTypeName="HesapInfo" InsertMethod="Insert" 
                    UpdateMethod="Update"></asp:ObjectDataSource>
                
            </td>
        </tr>
    </table>
</asp:Content>

