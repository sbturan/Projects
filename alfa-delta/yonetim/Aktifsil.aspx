<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/yonetim.master" AutoEventWireup="true" CodeFile="Aktifsil.aspx.cs" Inherits="yonetim_aktifsil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
     <table style="width: 800px; position: static">
        <tr>
            <td style="width: 100%">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="11pt"
                    ForeColor="Crimson" Style="position: static" Text="AKTİF OLMAYAN KULLANICILAR" Width="344px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px">
               
                        <table style="width: 100%">
                            
                            <tr>
                                <td style="width: 100px">
                                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" DataSourceID="SqlDataSource1" EnableModelValidation="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="284px" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                        <Columns>
                                             <asp:CommandField AccessibleHeaderText="DÜZENLE" ButtonType="Image" EditImageUrl="~/yonetim/images/edit.gif" HeaderText="DÜZENLE" SelectImageUrl="~/yonetim/images/edit.gif" ShowSelectButton="True" />
                                            <asp:TemplateField HeaderText="Delete">
	                <ItemTemplate>
		            <asp:Button ID="deleteButton" runat="server" CommandName="Delete" CommandArgument='<%#Eval("KullaniciID")%>' Text="Delete"
                    OnClientClick="return confirm('Are you sure you want to delete this user?');" />
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
               </td>
        </tr>
    </table>
    
     <table><tr><td>
        &nbsp;</td><td>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:alfadeltaConnectionString %>" SelectCommand="SELECT [KullaniciID], [KullaniciAdi], [Durum], [KullaniciSoyad], [Aktivasyon_tarih], [Email] FROM [kullanicilar] WHERE ([Durum] = @Durum)">
                <SelectParameters>
                    <asp:Parameter DefaultValue="False" Name="Durum" Type="Boolean" />
                </SelectParameters>
            </asp:SqlDataSource>
        </td></tr><tr><td>
            &nbsp;</td></tr></table>
   
    
    




    

    </asp:Content>

