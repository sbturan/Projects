<%@ Page Language="C#" MasterPageFile="~/yonetim/yonetim.master" AutoEventWireup="true" CodeFile="kategoriler.aspx.cs" Inherits="yonetim_kategoriler" Title="Untitled Page"  ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 800px; position: static">
        <tr>
            <td style="width: 100%">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="11pt"
                    ForeColor="Crimson" Style="position: static" Text="Kategoriler" Width="344px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px" align="center">
                     
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" OnRowCommand="grdProducts_RowCommand"  BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="ObjectDataSource2" EnableModelValidation="True" DataKeyNames="Id" OnRowCreated="GridView1_RowCreated" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"  >
                    <Columns>
                        <asp:CommandField ButtonType="Image" HeaderText="DÜZENLE" SelectImageUrl="~/yonetim/images/edit.gif" ShowSelectButton="True" />
                      
                         <asp:TemplateField HeaderText="Delete">
	                <ItemTemplate>
		            <asp:Button ID="deleteButton" runat="server" CommandName="Delete" CommandArgument='<%#Eval("ID")%>' Text="Delete"
                    OnClientClick="return confirm('Bu kategori silinecek. Emin misiniz?');" />
	              </ItemTemplate>
                  </asp:TemplateField>
                    
                    
                    </Columns>
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                </asp:GridView>
              
        </tr>
    </table>
    
    <asp:ObjectDataSource ID="ObjectIcerikler" runat="server" 
        SelectMethod="GetKategoriler" OldValuesParameterFormatString="original_{0}"
        TypeName="KategoriBLL" DataObjectTypeName="KategoriInfo" 
        DeleteMethod="Delete" InsertMethod="Insert" UpdateMethod="Update">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        SelectMethod="GetKategoriler" 
        OldValuesParameterFormatString="original_{0}" TypeName="KategoriBLL" 
        DataObjectTypeName="KategoriInfo" DeleteMethod="Delete" InsertMethod="Insert" 
        UpdateMethod="Update">
    </asp:ObjectDataSource>
        <asp:XmlDataSource ID="XmlDil" runat="server" DataFile="~/XML/XMLFile.xml" XPath="root/dil/item">
                </asp:XmlDataSource>
    <asp:XmlDataSource ID="XMLYayinDurumu" runat="server" DataFile="~/XML/XMLFile.xml"
        XPath="root/yayin_durumu/item"></asp:XmlDataSource>
</asp:Content>
