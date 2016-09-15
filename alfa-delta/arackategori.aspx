<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="arackategori.aspx.cs" Inherits="arackategori" %>
    <%@ Register Src="~/kutuphane/Navigasyon1.ascx" TagName="Navigasyon" TagPrefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <asp:MultiView ID="MultiView1" runat="server">
    
        <asp:View ID="View1" runat="server">
        <uc1:Navigasyon ID="Navigasyon2" runat="server" />
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="KategoriInfo"
                DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetAltKategoriler" TypeName="KategoriBLL" UpdateMethod="Update">
                <SelectParameters>
                    <asp:QueryStringParameter Name="ID" QueryStringField="ID" Type="Int32" />
                    <asp:SessionParameter Name="dil" SessionField="dil" Type="String" 
                        DefaultValue="tr" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:DataList ID="DataList2" runat="server" DataSourceID="ObjectDataSource1" 
                  
                Width="690px" OnItemCreated="DataList2_ItemCreated">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td>
                                 <a href='<%#Eval("SEVIYE").ToString() == "0" ? "arackategori.aspx?ID=" + Eval("ID").ToString() : "urunler.aspx?ID=" + Eval("ID").ToString()%>'>
                                    <asp:Label ID="adi" runat="server" Text='<%# Eval("ADI") %>' Width="200px" />
                                </a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href='<%#Eval("SEVIYE").ToString() == "0" ? "arackategori.aspx?ID=" + Eval("ID").ToString() : "urunler.aspx?ID=" + Eval("ID").ToString()%>'>
                                    <img src='<%# Eval("ICON") %>' style="height: 106px; width: 165px" /></a>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
       </asp:View>
        <asp:View ID="View2" runat="server">
             <uc1:Navigasyon ID="Navigasyon1" runat="server" />
            <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource1" ForeColor="#0000CC" Font-Bold="True" Font-Size="Large" Width="460px">
                <ItemTemplate>
                    <table>
                        <tr>
                                           <td> <asp:Image ID="Image1" runat="server" Height="41px" ImageUrl="~/images/Extras-Forward-icon.png" /></td>
                            <td>
                                 <a href='<%#Eval("SEVIYE").ToString() == "0" ? "arackategori.aspx?ID=" + Eval("ID").ToString() : "urunler.aspx?ID=" + Eval("ID").ToString()%>'>
                                    <asp:Label ID="adi" runat="server" Text='<%# Eval("ADI") %>' Width="290px" Font-Bold="True" Font-Size="X-Large" ForeColor="#0000CC" Height="38px" Font-Overline="False" Font-Underline="True" />
                                </a>
                            </td>
                        </tr>
                    
                    </table>
                </ItemTemplate>
            </asp:DataList>

               </asp:View>
    </asp:MultiView>
    
</asp:Content>
