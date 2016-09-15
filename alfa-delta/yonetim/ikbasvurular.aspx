<%@ Page Language="C#" MasterPageFile="~/yonetim/yonetim.master" AutoEventWireup="true" CodeFile="ikbasvurular.aspx.cs" Inherits="yonetim_ikbasvurular" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 800px; position: static">
        <tr>
            <td style="width: 100px; height: 20px">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="11pt"
                    ForeColor="Crimson" Style="position: static" Text="Dosyalar" Width="344px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 20px">
                <asp:Label ID="lbl_IkKonu" runat="server" Style="position: static" Width="432px"></asp:Label>
                <asp:Label ID="lbl_IkKonu0" runat="server" Style="position: static" Width="432px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px">
               
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" DataSourceID="ObjectIKBasvurular" EnableModelValidation="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="Id" OnRowEditing="GridView1_RowEditing" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCommand="GridView1_RowCommand">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField AccessibleHeaderText="OKU" ButtonType="Image" EditImageUrl="~/yonetim/images/edit.gif" HeaderText="OKU" SelectImageUrl="~/yonetim/images/edit.gif" ShowSelectButton="True" />
                        <asp:TemplateField HeaderText="Delete">
	                <ItemTemplate>
		            <asp:Button ID="deleteButton" runat="server" CommandName="Delete" CommandArgument='<%#Eval("ID")%>' Text="Delete"
                    OnClientClick="return confirm('Bu dosya silinecek. Emin misiniz?');" />
	              </ItemTemplate>
                  </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
            </td>
      </tr>
    </table>
    <asp:ObjectDataSource ID="ObjectIKBasvurular" runat="server" DataObjectTypeName="IkDetayInfo"
        DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetList" TypeName="IkDetayBLL" UpdateMethod="Update">
    </asp:ObjectDataSource>
    <asp:XmlDataSource ID="XMLIkDurumu" runat="server" DataFile="~/XML/XMLFile.xml" XPath="root/ik_durum/item">
    </asp:XmlDataSource>
</asp:Content>

