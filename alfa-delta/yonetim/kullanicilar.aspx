<%@ Page Language="C#" MasterPageFile="~/yonetim/yonetim.master" AutoEventWireup="true" CodeFile="kullanicilar.aspx.cs" Inherits="yonetim_kullanicilar" Title="Untitled Page"  ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <table style="width: 800px; position: static">
        <tr>
            <td style="width: 100%">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="11pt"
                    ForeColor="Crimson" Style="position: static" Text="KULLANICILAR" Width="344px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px">
               
                        <table style="width: 100%">
                            
                            <tr>
                                <td style="width: 100px">
                                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" DataSourceID="ObjectDataSource2" EnableModelValidation="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="Id" OnRowCreated="GridView1_RowCreated" OnRowEditing="GridView1_RowEditing" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                        <Columns>
                                            <asp:CommandField AccessibleHeaderText="DÜZENLE" ButtonType="Image" EditImageUrl="~/yonetim/images/edit.gif" HeaderText="DÜZENLE" SelectImageUrl="~/yonetim/images/edit.gif" ShowSelectButton="True" />
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
    
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        SelectMethod="GetirList" 
        OldValuesParameterFormatString="original_{0}" TypeName="UsersYonetimBLL">
    </asp:ObjectDataSource>
    </asp:Content>
