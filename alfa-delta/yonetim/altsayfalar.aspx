<%@ Page Language="C#" MasterPageFile="~/yonetim/yonetim.master" AutoEventWireup="true" CodeFile="altsayfalar.aspx.cs" Inherits="yonetim_altsayfalar" Title="Untitled Page" ValidateRequest="false" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 723px; position: static">
        <tr>
            <td style="width: 100px">
                <asp:Label ID="lbl_Baslik" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="11pt"
                    ForeColor="#CC0000" Style="position: static" Text="Alt Sayfalar" Width="392px"></asp:Label>
                </td>
        </tr>
     
     <table><tr><td>
         <asp:GridView ID="GridView1" runat="server" AllowPaging="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="ObjectIcerikler" EnableModelValidation="True" OnRowCreated="GridView1_RowCreated"  OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
             <Columns>
                 <asp:CommandField ButtonType="Image" HeaderText="DÜZENLE" SelectImageUrl="~/yonetim/images/edit.gif" ShowSelectButton="True" />
             </Columns>
             <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
             <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
             <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
             <RowStyle BackColor="White" ForeColor="#003399" />
             <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
         </asp:GridView>

        </td></tr></table>

        

    <asp:ObjectDataSource ID="ObjectIcerikler" runat="server" 
        SelectMethod="GetTumList" DataObjectTypeName="IcerikInfo" DeleteMethod="Delete" 
        InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" 
        TypeName="IcerikBLL" UpdateMethod="Update">
    </asp:ObjectDataSource>
    <asp:XmlDataSource ID="XMLYayinDurumu" runat="server" DataFile="~/XML/XMLFile.xml"
        XPath="root/yayin_durumu/item"></asp:XmlDataSource>
</asp:Content>

