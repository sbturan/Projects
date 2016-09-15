<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="urunler.aspx.cs" Inherits="urunler"      %>
<%@ Register Src="~/kutuphane/Navigasyon1.ascx" TagName="Navigasyon" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:MultiView ID="MultiView1" runat="server">
    
        <asp:View ID="View1" runat="server">
     <uc1:Navigasyon ID="Navigasyon2" runat="server" />
    <asp:DataList ID="dl_urunler" runat="server" DataSourceID="Obj_urunler" 
        RepeatColumns="3" HorizontalAlign="Justify" Width="633px" >

        <ItemTemplate>
        
            <table>
                 <tr><td style="height: 52px; width: 200px;" align="center">
             <a href="javascript: void(0)" 
   onclick="window.open('urundetay1.aspx?ID=<%# Eval("ID") %>', 
  'windowname1', 
  'width=600, height=600'); 
   return false;">           
               <asp:Label ID="ADILabel" runat="server" Text='<%# Eval("ADI") %>' 
                    Font-Bold="True" ForeColor="Black" />  </a>
            
           </td>
           </tr>
           
           <tr>
           <td height="50px" style="width: 200px" > 

           <a href="javascript: void(0)" 
   onclick="window.open('urundetay1.aspx?ID=<%# Eval("ID") %>', 
  'windowname1', 
  'width=600, height=600'); 
   return false;"><img id="Img1" src='<%# Eval("ICON") %>' runat="server"  style=" width:200px; height:150px " />  </a>

          
           </td>
                     
           </tr>
           
                <tr>
                    <td style="width: 200px"><table><tr>
                   
                                                                                    
                    <td class="style4" style="width: 64px" align="center">
                        <asp:ImageButton  ID="ImageButton1"  CommandName="pdf" OnClientClick='<%# "yonlendir(" +Eval("ID") + " );" %>' CommandArgument='<%#Eval("ID") %>' runat="server"  ImageUrl="~/images/1391707569_ACP_PDF 2_file_document.png" Height="26px" Width="51px"    />
                             </td>
                          <td style="width: 181px" align="center">
                        <asp:ImageButton ID="ImageButton2" CommandName="bilgi" OnClientClick='<%# "yonlendir2(" +Eval("ID") + " );" %>'  CommandArgument='<%#Eval("ID") %>' runat="server"  Height="24px" ImageUrl="~/images/1391707735_Information.png" Width="49px" />
                    </td>
                       
                    </tr></table>
                    </td>
                    
                  



                </tr>




                </table>

           
           
            

        </ItemTemplate>
    </asp:DataList>
              </asp:View>
        <asp:View ID="View2" runat="server">
            <uc1:Navigasyon ID="Navigasyon1" runat="server" />
             <asp:DataList ID="DataList1" runat="server" DataSourceID="Obj_urunler" ForeColor="#0000CC" Font-Bold="True" Font-Size="Large" Width="336px">
                <ItemTemplate>
                    <table>
                        <tr>
                                           <td> <asp:Image ID="Image1" runat="server" Height="41px" ImageUrl="~/images/Extras-Forward-icon.png" /></td>
                          
                            
                             <td style="height: 52px; width: 200px;" align="center">
             <a href="javascript: void(0)" 
   onclick="window.open('urundetay1.aspx?ID=<%# Eval("ID") %>', 
  'windowname1', 
  'width=600, height=600'); 
   return false;">           
               <asp:Label ID="ADILabel" runat="server" Text='<%# Eval("ADI") %>' 
                    Font-Bold="True" ForeColor="Black" />  </a>
            
           </td>
                              <td class="style4" style="width: 64px" align="center">
                        <asp:ImageButton  ID="ImageButton1"  CommandName="pdf" OnClientClick='<%# "yonlendir(" +Eval("ID") + " );" %>' CommandArgument='<%#Eval("ID") %>' runat="server"  ImageUrl="~/images/1391707569_ACP_PDF 2_file_document.png" Height="26px" Width="51px"    />
                             </td>
                          <td style="width: 181px" align="center">
                        <asp:ImageButton ID="ImageButton2" CommandName="bilgi" OnClientClick='<%# "yonlendir2(" +Eval("ID") + " );" %>'  CommandArgument='<%#Eval("ID") %>' runat="server"  Height="24px" ImageUrl="~/images/1391707735_Information.png" Width="49px" />
                    </td>
                        </tr>
                    
                    </table>
                </ItemTemplate>
            </asp:DataList>

               </asp:View>
    </asp:MultiView>
    <script type="text/javascript">
        function yonlendir(id) {
            javascript: window.open("urundetay1.aspx?ID="+id, "_blank", "height=700,width=700");
        } 
      function yonlendir2(id)
      {  
        javascript:window.open("bilgial.aspx?ID="+id,"_blank","height=440,width=360");
      }    

    </script>
    <asp:ObjectDataSource ID="Obj_urunler" runat="server" 
        DataObjectTypeName="UrunInfo" InsertMethod="Insert" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetUrunByKategoriID" TypeName="UrunBLL" UpdateMethod="Update">
        <SelectParameters>
            <asp:QueryStringParameter Name="ID" QueryStringField="ID" Type="Int32" />
            <asp:Parameter DefaultValue="True" Name="yayin_durumu" Type="Boolean" />
        </SelectParameters>
    </asp:ObjectDataSource>
    
</asp:Content>

