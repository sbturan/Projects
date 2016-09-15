<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/yonetim.master" AutoEventWireup="true" CodeFile="logbilgi.aspx.cs" Inherits="yonetim_logbilgi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table><tr><td style="height: 43px">
       <asp:Label ID="Label1" runat="server" Text="Kullanici  seciniz:"></asp:Label>
   </td><td style="height: 43px">
    <asp:DropDownList ID="DropDownList1" runat="server" style="margin-left: 0px; top: -2px; left: 1px; width: 214px; height: 23px;" 
                    BackColor="White" CssClass="MainLiStyle" ForeColor="#FF7D00" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                    AutopostBack="True" 
        DataSourceID="SqlDataSource1" DataTextField="Expr1" DataValueField="KullaniciID" 
        Height="20px" Width="158px">
    </asp:DropDownList></td></tr>
       <tr><td>
       <asp:Label ID="Label2" runat="server" Text=" Başlangıç Tarihi  seciniz:"></asp:Label>
   </td> <td> <asp:Calendar ID="Calendar2" runat="server" Height="226px" Width="180px" style="margin-top: 22px" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" NextPrevFormat="ShortMonth">
               <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
               <DayStyle BackColor="#CCCCCC" />
               <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
               <OtherMonthDayStyle ForeColor="#999999" />
               <SelectedDayStyle BackColor="#333399" ForeColor="White" />
               <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
               <TodayDayStyle BackColor="#999999" ForeColor="White" />
               </asp:Calendar></td></tr>
       <tr><td>
       <asp:Label ID="Label3" runat="server" Text=" Bitiş Tarihi  seciniz:"></asp:Label>
   </td> <td>
               <asp:Calendar ID="Calendar1" runat="server" Height="143px" Width="158px" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" NextPrevFormat="ShortMonth">
                   <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                   <DayStyle BackColor="#CCCCCC" />
                   <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                   <OtherMonthDayStyle ForeColor="#999999" />
                   <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                   <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
                   <TodayDayStyle BackColor="#999999" ForeColor="White" />
               </asp:Calendar>
           </td></tr><tr><td>

              

                         </td><td align="center">

               <asp:Button ID="Button2" runat="server" Text="Bul" Width="124px" OnClick="Button2_Click" />

                         </td></tr>
   </table>
   <table><tr><td>


       <asp:GridView ID="GridView1" runat="server" CellPadding="3" EnableModelValidation="True" Visible="False" Width="363px" AllowPaging="True" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2"  OnPageIndexChanging="GridView1_PageIndexChanging"   OnRowCancelingEdit="GridView1_RowCancelingEdit">
           <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
           <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
           <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
           <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
           <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
       </asp:GridView>

              </td></tr>
        <tr><td>
            <asp:LinkButton ID="ExceleAktarLinkButton" runat="server" OnClick="ExceleAktarLinkButton_Click" Visible="False">Excele Aktar</asp:LinkButton>

            </td></tr>


   </table>
    
    




    

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:alfadeltaConnectionString %>" 
        SelectCommand="SELECT [KullaniciID], KullaniciAdi + KullaniciSoyad AS Expr1 FROM [kullanicilar] WHERE ([Durum] = @Durum)">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="Durum" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>
    
</asp:Content>

