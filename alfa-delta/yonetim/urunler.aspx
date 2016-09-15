<%@ Page Language="C#" MasterPageFile="~/yonetim/yonetim.master" AutoEventWireup="true" CodeFile="Urunler.aspx.cs" Inherits="yonetim_urunler" Title="Untitled Page"  ValidateRequest="false" %>
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
                        <%--<dxwgv:ASPxGridView ID="grd_IcerikTekli" runat="server" DataSourceID="ObjectDataSource2"
                            Style="position: static" Width="900px" AutoGenerateColumns="False"
                            OnSelectionChanged="grd_Icerik_SelectionChanged">
                            <Columns>

                                
<dxwgv:GridViewDataTextColumn FieldName="ADI" Caption="ÜRÜN ADI" VisibleIndex="1">
</dxwgv:GridViewDataTextColumn>
                                
                       
                               
                                
                                 <dxwgv:GridViewDataComboBoxColumn Caption="YAYIN DURUMU" FieldName="YAYIN_DURUMU" VisibleIndex="4"
                            Width="100px">
                            <PropertiesComboBox DataSourceID="XMLYayinDurumu" TextField="adi" ValueField="id"
                                ValueType="System.Int32">
                            </PropertiesComboBox>
                            <HeaderStyle Font-Bold="True" />
                        </dxwgv:GridViewDataComboBoxColumn>
                               
                                <dxwgv:GridViewDataTextColumn Caption="MARKA ADI" FieldName="MARKA" 
                                    VisibleIndex="2">
                                </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn Caption="KATEGORİ  ADI" FieldName="KTG" VisibleIndex="3">
                                </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn Caption="DIL" FieldName="DIL" VisibleIndex="5">
                                </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn VisibleIndex="6">
                                    <DataItemTemplate>
                                        <div onmouseover="this.style.cursor= 'hand'" title="Sayfa Düzenle">
                                            <asp:ImageButton ID="img_Edit" runat="server" CausesValidation="False" 
                                                CommandName="Select" ImageUrl="~/yonetim/images/edit.gif" 
                                                PostBackUrl='<%# "Urunduzenle.aspx?ID=" + Eval("ID") %>' 
                                                Style="position: static" />
                                        </div>
                                    </DataItemTemplate>
                                </dxwgv:GridViewDataTextColumn>
                                
                            </Columns>
                            <SettingsLoadingPanel Text="yükleniyor" />
                            <SettingsDetail AllowOnlyOneMasterRowExpanded="True" />
                            <Templates>
                                <DetailRow>
                                    &nbsp;
                                </DetailRow>
                            </Templates>
                            <SettingsPager PageSize="25">
                                <Summary AllPagesText="Sayfalar: {0} - {1} (Toplam {2} kayıt)" Text="Sayfa {0} / {1} (Toplam {2} kayıt)" />
                            </SettingsPager>
                            <Settings ShowFilterRow="True" />
                        </dxwgv:ASPxGridView>--%>
                                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" OnRowCommand="grdProducts_RowCommand" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="ObjectDataSource2" EnableModelValidation="True" OnRowCreated="GridView1_RowCreated" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                        <Columns>
                                            <asp:CommandField ButtonType="Image" HeaderText="DÜZENLE" SelectImageUrl="~/yonetim/images/edit.gif" ShowSelectButton="True" />
                                            <asp:TemplateField HeaderText="Delete">
	                <ItemTemplate>
		            <asp:Button ID="deleteButton" runat="server" CommandName="Delete" CommandArgument='<%#Eval("ID")%>' Text="Delete"
                    OnClientClick="return confirm('Bu ürün silinecek. Emin misiniz?');" />
	              </ItemTemplate>
                  </asp:TemplateField>
                                        
                                        </Columns>
                                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                        <RowStyle BackColor="White" ForeColor="#003399" />
                                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    </asp:GridView>
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
