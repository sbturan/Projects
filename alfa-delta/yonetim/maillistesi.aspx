<%@ Page Language="C#" MasterPageFile="~/yonetim/yonetim.master" AutoEventWireup="true" CodeFile="maillistesi.aspx.cs" Inherits="yonetim_maillistesi" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <table style="width: 800px; position: static">
        <tr>
            <td style="width: 100px; height: 20px">
                <asp:Label ID="lbl_MailListesi" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="11pt"
                    ForeColor="Crimson" Style="position: static" Text="Mail Listesi" Width="344px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 20px">

            <asp:GridView ID="gvMail" DataSourceID="ObjectMailListesi" runat="server" 
        AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
        GridLines="None" Width="100%" EnableModelValidation="True">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                                <asp:BoundField DataField="ADI" HeaderText="ADI" SortExpression="ADI" />
                                <asp:BoundField DataField="SOYADI" HeaderText="SOYADI" 
                                    SortExpression="SOYADI" />
                                <asp:BoundField DataField="EMAIL" HeaderText="EMAIL" SortExpression="EMAIL" />
                                <asp:CheckBoxField DataField="DURUM" HeaderText="DURUM" 
                                    SortExpression="DURUM" />
                              
                                     
                            </Columns>
                            <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#00A0C6" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                            <PagerStyle BackColor="#00A0C6" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                </td>
        </tr>
        
    </table>
    
    
    <asp:ObjectDataSource ID="ObjectMailListesi" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetList" TypeName="MailListeBLL">
    </asp:ObjectDataSource>
    
    <asp:LinkButton ID="ExceleAktarLinkButton" runat="server" OnClick="ExceleAktarLinkButton_Click">Excele Aktar</asp:LinkButton>

</asp:Content>

