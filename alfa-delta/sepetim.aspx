<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="sepetim.aspx.cs" Inherits="sepetim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="left"><tr><td>
        &nbsp;</td></tr></table>
   <center> <asp:Label ID="Label2" runat="server" ></asp:Label></center>
    <asp:DataList ID="DataList1" runat="server" CellPadding="6" OnItemCommand="DataList1_ItemCommand"
            ForeColor="#333333" BorderColor="Black" BorderWidth="4px" 
        CellSpacing="5" Font-Bold="False"
            Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"
            HorizontalAlign="Center" ShowFooter="False" Height="311px" 
        style="margin-left: 0px" Width="532px" GridLines="Vertical" 
       >
            <FooterStyle BackColor="#FF7D00" ForeColor="White" Font-Bold="True" />
            <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
            <ItemStyle BackColor="#DEDFDE" ForeColor="Black" />

            <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderTemplate>
                <table align="center" cellpadding="3" cellspacing="3" style="width: 449px">
                    <tr>
                        
                        <td align="center" width="60px">
                            <asp:Label ID="Label3" runat="server" Text="Ad"></asp:Label>
                        </td>
                        <td align="center" width="60px">
                            <asp:Label ID="Label4" runat="server" Text="Fiyat"></asp:Label>
                        </td>
                        <td align="left" width="60px"">
                            <asp:Label ID="Label5" runat="server" Text="Adet"></asp:Label>
                        </td>
                        <td align="left" width="60px">
                            <asp:Label ID="Label6" runat="server" Text="Tutar"></asp:Label>
                        </td>
                        <td align="left" width="60px">
                            <asp:Label ID="Label7" runat="server" Text="İndirim Oranı"></asp:Label>
                        </td>
                        <td align="left" width="60px">
                            <asp:Label ID="Label8" runat="server" Text="KDV Oranı"></asp:Label>
                        </td>
                        
                    </tr>
                </table>
            </HeaderTemplate>
            <HeaderStyle BackColor="#FF7D00" Font-Bold="True" ForeColor="White" />
            <ItemTemplate>
                <table align="center" cellpadding="3" cellspacing="3" style="width: 451px">
                    <tr>
                        <td align="left" class="style3" style="width: 10px">
                           
                        </td>
                        <td align="left" class="style3" style="width: 83px" width="auto">
<a href="javascript: void(0)" 
   onclick="window.open('urundetay1.aspx?ID=<%# Eval("ID") %>', 
  'windowname1', 
  'width=600, height=600'); 
   return false;">            
               <asp:Label ID="ADILabel" runat="server" Text='<%# Eval("isim") %>' />  </a>
                        
                         </td>  
                       
                        <td align="right" width="54px">
                            <%# Eval("fiyat") %> TL
                        </td>
                        <td align="right" class="style3" style="width: 42px">
                            <%# Eval("adet") %>
                        </td>
                        <td align="right" width="92px">
                            <%# Eval("tutar") %> TL              
                        </td>
                        <td align="right" width="75px">
                           % <%# Eval("indiri") %>               
                        </td>
                        <td align="right" style="padding-left:-33px"></td>
                        <td align="right" width="60px">
                           % <%# Eval("kd") %>               
                        </td>
                        
                        <td align="right" width="10px" >
                            <asp:LinkButton ID="btnSil" runat="server" CommandArgument='<%# Eval("id") %>' 
                                CommandName="silme" >Kaldir</asp:LinkButton>
                        </td>
                    
                    <tr><td class="style3" style="width: 10px">  <center>
            <asp:Label ID="Label1" runat="server"></asp:Label></center></td></tr>
                </table>
                 
            </ItemTemplate>
        </asp:DataList>
          <table align="left" cellpadding="3" cellspacing="3" 
        style="width: 530px">
                    <tr bgcolor="#FF7D00">
                         <td align="left" width="60px">
                            <asp:Label ID="Label6" runat="server" Text="Fİyat"></asp:Label>
                        </td>
                        <td align="center" width="60px">
                            <asp:Label ID="Label3" runat="server" Text="İSKONTO"></asp:Label>
                        </td>
                        <td align="center" width="60px">
                            <asp:Label ID="Label4" runat="server" Text="KDV"></asp:Label>
                        </td>
                        <td align="left" width="60px"">
                            <asp:Label ID="Label5" runat="server" Text="ÖDENECEK"></asp:Label>
                        </td>

                       
                        
                    </tr>


                    <tr bgcolor="White">
                         <td align="left" width="60px">
                            <asp:Label ID="lblfiyat" runat="server" ></asp:Label>
                        </td>
                        <td align="center" width="60px">
                            <asp:Label ID="lbliskonto" runat="server" ></asp:Label>
                        </td>
                        <td align="center" width="60px">
                            <asp:Label ID="lblkdv" runat="server" ></asp:Label>
                        </td>
                        <td align="left" width="60px"" bgcolor="Black">
                            <asp:Label ID="lblodenecek" runat="server" ForeColor="#FF7D00" ></asp:Label>
                        </td>

                       
                        
                    </tr>
                </table>


        <table><tr><td>
            <img alt="" class="style10" src="images/Check.png" 
                style="height: 24px; width: 48px" />
              </td><td>
                <asp:LinkButton ID="LinkButton5" 
                runat="server" onclick="LinkButton5_Click" 
                onclientclick="return confirm('Onaylamak istiyormusun?')" BackColor="#FF7D00">Sepeti Onayla </asp:LinkButton>
    
   </td> </tr></table>
    </asp:Content>

