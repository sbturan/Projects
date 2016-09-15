<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="urunkategori.aspx.cs" Inherits="urunkategori" %>
  <%@ Register Src="~/kutuphane/Navigasyon1.ascx" TagName="Navigasyon" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    
    
    <asp:MultiView ID="MultiView1" runat="server">
    
        <asp:View ID="View1" runat="server">
         <uc1:Navigasyon ID="Navigasyon1" runat="server" />
    <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource4" 
         Height="497px" RepeatColumns="3" Width="686px" 
                CssClass="MainLiAStyle">
       
        <ItemTemplate>
        <table style="width: 252px">
        <tr>
        <td>
      
           <a href='<%#Eval("SEVIYE").ToString() == "0" ? "urunkategori.aspx?ID=" + Eval("urun_kategoriID").ToString() : "urunler.aspx?ID=" + Eval("urun_kategoriID").ToString()%>'>
          
           <asp:Label ID="Label1" runat="server" Text='<%# Eval("KADI") %>' Height="45px" 
                                    Width="62px" ForeColor="Blue" /> </a>
             </td></tr>
            <tr><td  width="20px" height="20px">
             <a href='<%#Eval("SEVIYE").ToString() == "0" ? "urunkategori.aspx?ID=" + Eval("urun_kategoriID").ToString() : "urunler.aspx?ID=" + Eval("urun_kategoriID").ToString()%>'>
            <img src='<%# Eval("ICON") %>' style="height: 106px; width: 165px" align="bottom" /></a></td></tr></table>
            

        </ItemTemplate>
        <SelectedItemStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
    </asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
        ConnectionString="<%$ ConnectionStrings:alfa-deltaConnectionString %>" 
        
                
                SelectCommand="SELECT [kadi], [icon], [urun_kategoriID], [seviye] FROM [urun_kategori] WHERE (([ust_id] = @ust_id) AND ([dil] = @dil))">
        <SelectParameters>
            <asp:QueryStringParameter Name="ust_id" QueryStringField="ust_id" 
                Type="Int32" />
            <asp:SessionParameter Name="dil" SessionField="dil" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    </asp:View>
        <asp:View ID="View2" runat="server">
         <uc1:Navigasyon ID="Navigasyon2" runat="server" />

            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                DataObjectTypeName="KategoriInfo" DeleteMethod="Delete" InsertMethod="Insert" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAltKategoriler" 
                TypeName="KategoriBLL" UpdateMethod="Update">
                <SelectParameters>
                    <asp:QueryStringParameter Name="ID" QueryStringField="ID" Type="Int32" />
                    <asp:SessionParameter DefaultValue="tr" Name="dil" SessionField="dil" 
                        Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
             <asp:DataList ID="DataList2" runat="server" DataSourceID="ObjectDataSource1" 
                 RepeatColumns="3" 
                Width="690px">
                <ItemTemplate>
                    
          <table frame="border">
        <tr>
        <td>
            <a href='<%#Eval("SEVIYE").ToString() == "0" ? "urunkategori.aspx?ID=" + Eval("ID").ToString() : "urunler.aspx?ID=" + Eval("ID").ToString()%>'>
           <asp:Label ID="adi" runat="server" Text='<%# Eval("ADI") %>' Width="200px" /> </a>  </td></tr>
            <tr><td>
            <a href='<%#Eval("SEVIYE").ToString() == "0" ? "urunkategori.aspx?ID=" + Eval("ID").ToString() : "urunler.aspx?ID=" + Eval("ID").ToString()%>'>
             <img src='<%# Eval("ICON") %>' style="height: 106px; width: 165px" /></a></td></tr></table>               
                   
                </ItemTemplate>
              
            </asp:DataList>


        </asp:View>
    </asp:MultiView>
    
</asp:Content>

