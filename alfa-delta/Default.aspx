<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" Title="ALFA-DELTA Web Sitesi" %>
  <%@ Register Src="~/kutuphane/Navigasyon1.ascx" TagName="Navigasyon" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-47050117-1', 'alfa-delta.com');
        ga('send', 'pageview');

    </script>
    <table style="width: 97%; height: 318px; background-image: url('images/arkaplan.jpg');" 
        frame="void" >
        <tr>
        <td style="height: 35px" align="right">
        
         <uc1:Navigasyon ID="Navigasyon1" runat="server" />
    <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource4" 
         Height="312px" RepeatColumns="2" Width="686px" 
                CssClass="MainLiAStyle">
       
        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
       
        <ItemTemplate>
        <table style="width: 252px" >
        <tr>
        <td align="center">
            
      
            <a href='<%# "arackategori.aspx?"+"ID=" + Eval("urun_kategoriID").ToString()  %>'>
           <asp:Label ID="Label1" runat="server" Text='<%# Eval("KADI") %>' Height="45px" 
                                    Width="104px" ForeColor="Blue" Font-Bold="True" /> </a>
             </td></tr>
            <tr><td  width="20px" height="20px" align="center" >
            <a href='<%# "arackategori.aspx?"+"ID=" + Eval("urun_kategoriID").ToString()  %>'>
            <img src='<%# Eval("ICON") %>' style="height: 106px; width: 165px" align="bottom" /></a></td></tr></table>
           
        </ItemTemplate  >
        <SelectedItemStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
    </asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
        ConnectionString="<%$ ConnectionStrings:alfadeltaConnectionString2 %>" 
        
                
                SelectCommand="SELECT [icon], [kadi], [urun_kategoriID], [dil], [sayfa] FROM [urun_kategori] WHERE (([ust_id] = @ust_id) AND ([yayin_durumu] = @yayin_durumu))">
        <SelectParameters>
            <asp:Parameter DefaultValue="44" Name="ust_id" Type="Int32" />
            <asp:Parameter DefaultValue="True" Name="yayin_durumu" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>
      
        
        
        
        </td>
                                                    
          
        </tr>
    </table>
</asp:Content>
