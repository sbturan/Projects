<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="urundetay.aspx.cs" Inherits="urundetay" %>
     <%@ Register Src="~/kutuphane/Navigasyon1.ascx" TagName="Navigasyon" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <asp:Label ID="lbl_kontrol" runat="server" Text=""></asp:Label>
   <table><tr><td>
   <uc1:navigasyon ID="Navigasyon1" runat="server" /></td></tr></table>
    <asp:DataList ID="DataList2" runat="server" DataSourceID="ObjectDataSource1" 
        Width="490px" RepeatColumns="5" Height="21px">
        
        <ItemTemplate>
           <table><tr>
           <td bgcolor="#FF6600" align="center" width="500px">
                <asp:Label ID="ADILabel" runat="server" Text='<%# Eval("ADI") %>' ForeColor="White" Font-Size="X-Large" Font-Bold="True" />
            </td></tr></table>
            </ItemTemplate>
    </asp:DataList>
    <table align="center"><tr><td>
        <asp:DataList ID="DataList4" runat="server" DataSourceID="ObjectDataSource4" 
            Height="24px" Width="536px">
            <ItemTemplate>
                <table align="center"><tr><td align="center" width="50px" height="20px">
                <asp:Label ID="OZELLIK_ADILabel" runat="server" 
                    Text='<%# Eval("OZELLIK_ADI") %>' />
               
                </td><td align="center" width="50px" height="20px">
                <asp:Label ID="DEGERLabel" runat="server" Text='<%# Eval("DEGER") %>' />
              </td> </tr> </table>
            </ItemTemplate>
        </asp:DataList>
    
    </td></tr></table>
    
            <table align="center">
            <tr>
                <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource2" 
                     Height="58px" Width="553px">
                    <ItemTemplate>
                        
                        <table align="center"><tr><td>
                        <asp:Label ID="ACIKLAMALabel" runat="server" Text='<%# Eval("ACIKLAMA") %>' />
                       </td></tr> </table>
                       
                      
                    </ItemTemplate>
                </asp:DataList>
            </tr>
            </table>

   
        <table align="center"><tr><td>
            
                <asp:DataList ID="DataList3" runat="server" DataSourceID="ObjectDataSource3" 
                    Height="16px" Width="285px">
                    <ItemTemplate>
                        <table align="center"><tr><td>FIYAT:
                        <asp:Label ID="FIYATLabel" runat="server" Text='<%# Eval("FIYAT") %>' />
                       </td> <td>
                        <asp:Label ID="PARA_BIRIMLabel" runat="server" 
                            Text='<%# Eval("PARA_BIRIM") %>' />
                       </td> </tr> </table>
                    </ItemTemplate>
                </asp:DataList>
            </td></tr></table>
    
         
        <table>
        <tr>
            <td class="style1" colspan="2" rowspan="3">
                
            </td>
            <td class="spec">
                <table class="style9">
                    <tr>
                        <td>
                            <asp:TextBox CssClass="txt" Height="39px" Width="29px" ID="TextBox1" 
                                runat="server" Font-Size="Larger" >1</asp:TextBox>
                        </td>
                        <td>
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/ButtonSale.jpg"
                                OnClick="ImageButton1_Click" Height="39px" Width="73px" />
                        
                            
                        
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
        
        </table> 
        
        
        
        
      
          
            <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
        DataObjectTypeName="UrunInfo" DeleteMethod="Delete" InsertMethod="Insert" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetUrunFiyat" 
        TypeName="UrunBLL" UpdateMethod="Update">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="" Name="ID" QueryStringField="ID" 
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" 
        DataObjectTypeName="UrunOzOzInfo" DeleteMethod="Delete" InsertMethod="Insert" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetUrunOzOzByID4" 
        TypeName="UrunOzOzBLL" UpdateMethod="Update">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="" Name="ID" QueryStringField="ID" 
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        DataObjectTypeName="UrunInfo" DeleteMethod="Delete" InsertMethod="Insert" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetUrunByID" 
        TypeName="UrunBLL" UpdateMethod="Update">
        <SelectParameters>
            <asp:QueryStringParameter Name="ID" QueryStringField="ID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        DataObjectTypeName="UrunAciklamaInfo" DeleteMethod="Delete" 
        InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetUAbyUrunID" TypeName="UrunAciklamaBLL" 
        UpdateMethod="Update">
        <SelectParameters>
            <asp:QueryStringParameter Name="ID" QueryStringField="ID" Type="Int32" />
            <asp:SessionParameter DefaultValue="tr" Name="dil" SessionField="dil" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </div>
    </asp:Content>
