<%@ Page Language="C#" MasterPageFile="~/yonetim/yonetim.master" AutoEventWireup="true" CodeFile="kategorisizUrun.aspx.cs" Inherits="yonetim_kategorisizUrun" Title="Untitled Page"  ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 800px; position: static">
        <tr>
            <td style="width: 100%">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="11pt"
                    ForeColor="Crimson" Style="position: static" Text="Ürünler" Width="344px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px">
               
                        <table style="width: 674%">
                            
                            <tr>
                                <td style="width: 100px">
                   
                                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource1" EnableModelValidation="True" OnRowCreated="GridView1_RowCreated" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCommand="GridView1_RowCommand">
                                       <Columns>
                        <asp:CommandField ButtonType="Image" HeaderText="DÜZENLE" SelectImageUrl="~/yonetim/images/edit.gif" ShowSelectButton="True" />
                      
                         <asp:TemplateField HeaderText="Delete">
	                <ItemTemplate>
		            <asp:Button ID="deleteButton" runat="server" CommandName="Delete" CommandArgument='<%#Eval("urun_id")%>' Text="Delete"
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
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:alfadeltaConnectionString %>" SelectCommand="SELECT [urun_id], [adi], [ktg_id], [icon], [yayin_durumu] FROM [urunler] WHERE ([ktg_id] = @ktg_id)">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="-1" Name="ktg_id" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                         </td>
                            </tr>
                        </table>
               
                <br />
                &nbsp;</td>
        </tr>
    </table>
    <br />
    <asp:ObjectDataSource ID="ObjectIcerikler" runat="server" 
        SelectMethod="GetUrunler" OldValuesParameterFormatString="original_{0}"
        TypeName="UrunBLL" DataObjectTypeName="UrunInfo" 
        DeleteMethod="Delete" InsertMethod="Insert" UpdateMethod="Update" 
        onselecting="ObjectIcerikler_Selecting">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        SelectMethod="GetUrunler" 
        OldValuesParameterFormatString="original_{0}" TypeName="UrunBLL" 
        DataObjectTypeName="UrunInfo" InsertMethod="Insert" 
        UpdateMethod="Update" DeleteMethod="Delete">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
    </asp:ObjectDataSource>
    <asp:XmlDataSource ID="XmlDil" runat="server" DataFile="~/XML/XMLFile.xml" XPath="root/dil/item">
                </asp:XmlDataSource>
    <asp:XmlDataSource ID="XMLYayinDurumu" runat="server" DataFile="~/XML/XMLFile.xml"
        XPath="root/yayin_durumu/item"></asp:XmlDataSource>
</asp:Content>
