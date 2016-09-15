<%@ Page Language="C#" MasterPageFile="~/yonetim/yonetim.master" AutoEventWireup="true" CodeFile="bannerlar.aspx.cs" Inherits="yonetim_bannerYonetimi_bannerlar" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 102%">
        <tr>
            <td style="width: 100%; height: 25px">
                <asp:Label ID="lbl_Baslik" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="11pt"
                    ForeColor="#CC0000" Style="position: static" Text="Bannerlar" Width="392px"></asp:Label></td>
        </tr>
     
   <tr><td>
       <asp:DataList ID="DataList1" runat="server" BackColor="White" 
           BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
           DataSourceID="ObjectBannerlar" GridLines="Both">
           <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
           <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
           <ItemStyle BackColor="White" ForeColor="#330099" />
           <ItemTemplate>
            <table><tr>
             
             <td align="center" >yayın durumu:
               <asp:Label ID="YAYIN_DURUMULabel" runat="server" 
                   Text='<%# Eval("YAYIN_DURUMU") %>' />
            </td>
             
                <td align="center" colspan="1" rowspan="2" style="width: 5px; font-size: 9pt; font-family: Arial;"
                                                    valign="middle">
                                                    <asp:Image ID="img_Resim" runat="server" Height="120px" Style="position: static" Width="201px"
                                                        
                                                        ImageUrl='<%# "~/resize.ashx?adres=" + Eval("DOSYA") + "&gen=100&yuk=80&tip=K" %>' /><span
                                                            style="font-size: 10pt"><strong> </strong></span>
                                                </td>
              <td style="width: 45px">
              
              <asp:ImageButton ID="img_Edit" runat="server" CausesValidation="False" CommandName="Select"
                                                    ImageUrl="~/yonetim/images/edit.gif" PostBackUrl='<%# "bannerduzenle.aspx?BANNER_ID=" + Eval("ID") %>'
                                                    Style="position: static" />
              
              </td>
              
              </tr></table>
           </ItemTemplate>
           <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
       </asp:DataList>
               
               
   
                       </td></tr>                
                <asp:ObjectDataSource ID="ObjectBannerlar" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetTumBannerlar" TypeName="BannerBLL" 
                    DataObjectTypeName="BannerInfo" DeleteMethod="Delete" InsertMethod="Insert" 
                    UpdateMethod="Update"></asp:ObjectDataSource>
                <asp:XmlDataSource ID="XmlGorselTipi" runat="server" DataFile="~/XML/XMLFile.xml"
                    XPath="root/banner_tipi/item"></asp:XmlDataSource>
                
                <asp:XmlDataSource ID="XMLYayinDurumu" runat="server" 
                    DataFile="~/XML/XMLFile.xml" XPath="root/yayin_durumu/item">
                </asp:XmlDataSource>
      
    </table>
</asp:Content>

