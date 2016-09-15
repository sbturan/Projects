<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Uye.aspx.cs" Inherits="Uye" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <style type="text/css">
        #uye
        {
            width: 250px;
            height: 272px;
        }
        .style5
        {
            height: 26px;
            width: 27px;
        }
        .style6
        {
            width: 100%;
        }
        .style7
        {
            width: 207px;
        }
        </style>
</head>
<body background="images/arkaplan.jpg">
    <form id="form1" runat="server">
            <asp:Panel ID="Panel2" runat="server" Width="275px" 
        style="margin-top: 19px" Height="146px">
            <tr>
                <td align="right" style="text-align: left; " class="style5">
                    <span style="font-size: 10pt"></span>&nbsp;<table class="style6">
                        <tr>
                            <td>
                                <asp:Label ID="lbl_UyeAdi" runat="server" Font-Bold="True" ForeColor="#ff7d00" 
                                    Style="position: static" Text="Emailiniz:" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtUsername" runat="server" Font-Size="8pt" 
                                    style="position: static" Width="130px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbl_Sifre" runat="server" Font-Bold="True" ForeColor="#ff7d00" 
                                    Style="position: static" Text="Şifreniz:" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPassword" runat="server" Font-Size="8pt" 
                                    TextMode="Password" Width="130px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblError" runat="server" Font-Size="8pt" 
                                    Style="position: static" Width="126px"></asp:Label>
                            </td>
                            <td>
                                <asp:Button ID="btnSubmit" runat="server" BackColor="#FF7D00" CssClass="button" 
                                    Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" Height="31px" 
                                    onclick="btnSubmit_Click" OnCommand="btnSubmit_Click" style="position: static" 
                                    Text="Giriş" Width="66px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:HyperLink ID="hypuyeOl" runat="server" Font-Size="8pt" 
                                    NavigateUrl="uyeol1.aspx" Style="position: static" target="_parent" 
                                    Text="Üye Ol" Width="72px"></asp:HyperLink>
                            </td>
                            <td>
                                <asp:HyperLink ID="hypSifremiUnuttum" runat="server" Font-Size="8pt" target="_parent"
                                    NavigateUrl="sifremiunuttum.aspx" Style="position: static" Width="80px">Şifremi Unuttum</asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td>
                               <asp:HyperLink ID="HyperLink3" runat="server" Font-Size="8pt" target="_parent"
                                    NavigateUrl="aktivasyon.aspx" Style="position: static" Width="80px">Aktivasyon Onayı</asp:HyperLink> </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                    <br />
                    <p style="height: 0px">
                        &nbsp;</p>
                 </td>
            </tr>
    
    </asp:Panel>
    <p>
                 </td>
                 <td class="style1" __designer:mapid="155">   
                    </td>
            </tr>
            <tr __designer:mapid="157">
                <td align="right"  style="text-align: left; " class="style6" 
                    __designer:mapid="158">
                    &nbsp;</td><td class="style7" __designer:mapid="15b"></td></tr><tr __designer:mapid="15d"><td align="left" style="text-align: left" class="style3" __designer:mapid="15e"></td><td align="left" style="padding-right: 10px; text-align: left" 
                    class="style4" __designer:mapid="160"></td></tr><tr __designer:mapid="162"><td align="left" style="text-align: left" class="style8" __designer:mapid="163"></td><td align="right" style="padding-right: 10px; text-align: left" 
                    class="style9" __designer:mapid="165"></td></tr><tr __designer:mapid="167"><td valign="middle" class="style5" __designer:mapid="168"><%--<a href="uyeol.aspx?ID=1" target="_parent" ><font style="size:8pt">Üye Olacağım</font></a>--%></td><td class="style2" __designer:mapid="16a">&nbsp;</td>
            </tr>
            </table __designer:mapid="16b">       
       
  <asp:Panel ID="Panel1" runat="server" Width="248px" Height="89px">
    
       
        <table style="width: 249px; position: static; font-size: 8pt; font-family: Tahoma, Arial; height: 70px;">
            <tr>
                <td align="right" style="text-align: left; " class="style5">
                        <asp:Label ID="lbl_hi" runat="server"
                        Style="position: static;overflow:hidden;" Width="70px" Font-Bold="True" 
                            ForeColor="#FF7D00" Height="16px"></asp:Label>
                        <asp:Label ID="lbl_hos" runat="server" Text="Hoşgeldiniz" Visible="False"></asp:Label>
                 </td>
                 <td class="style7">   
                            <asp:Button ID="BtnSubmit2" runat="server" BackColor="#FF7D00" 
                                ForeColor="Black" Height="31px" onclick="BtnSubmit2_Click" 
                                PostBackUrl="~/Uye.aspx" Text="Çıkış" Visible="False" Width="66px" 
                                Font-Bold="True" Font-Size="Small" />
                        </td>
            </tr>
            <tr>
                <td align="right" style="text-align: left; " class="style5">
                    <asp:HyperLink ID="adres" runat="server" Font-Size="8pt" target="_parent" NavigateUrl="adresekle.aspx"
                        Style="position: static" Width="70px" Visible="false" Text="Adres Ekle"></asp:HyperLink>
                 </td>
                 <td class="style7">   
                     <asp:HyperLink ID="updateusr" runat="server" Font-Size="8pt" target="_parent" NavigateUrl="userupdate.aspx"
                        Style="position: static" Width="70px" Visible="False" Height="16px" Text="Kayıt Düzenle"></asp:HyperLink></td>
            </tr>
            <tr>
                <td align="right" style="text-align: left; " class="style5">
                
                    <asp:HyperLink ID="HyperLink2" runat="server"  target="_parent" NavigateUrl="~/sifredegistir.aspx">Sifre Değiştir</asp:HyperLink>
                
                    <asp:HyperLink ID="admin" runat="server" Font-Size="8pt" target="_parent"
                        Style="position: static" Width="80px" NavigateUrl="yonetim/default.aspx" 
                        Visible="False" Height="16px">Yönetim Sayfası</asp:HyperLink>
                 </td>
                 <td class="style7">   
                     &nbsp;</td>
            </tr>
            <tr><td>
                &nbsp;</td></tr>
            </asp:Panel>
       
        </p>
    </form>
        
        
       
    
</body>
</html>
