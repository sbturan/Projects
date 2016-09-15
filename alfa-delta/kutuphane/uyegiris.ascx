<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uyegiris.ascx.cs" Inherits="kutuphane_uyegiris" %>
<asp:MultiView ID="MusteriGorunum" runat="server">
    <asp:View ID="Gorunum1" runat="server">
        <table style="width: 193px; position: static; font-size: 8pt; font-family: Tahoma, Arial; height: 100px;">
            <tr>
                <td align="right" class="style5" colspan="2" style="height: 26px; text-align: left; width: 210px;">
                    <span style="font-size: 10pt"></span>&nbsp;<asp:Label ID="lbl_UyeAdi" runat="server"
                        Style="position: static" Text="Kullanýcý Adý" Width="70px" Font-Bold="True" ForeColor="WhiteSmoke"></asp:Label>:
                    <asp:TextBox ID="txt_KullaniciAdi" runat="server" Width="100px" Font-Size="8pt" style="position: static"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" class="style5" colspan="2" style="text-align: left; width: 210px;">
                    <span style="font-size: 10pt"></span>&nbsp;<asp:Label ID="lbl_Sifre" runat="server"
                        Style="position: static" Text="Þifre" Width="70px" Font-Bold="True" ForeColor="WhiteSmoke"></asp:Label>:
                    <asp:TextBox ID="txt_Sifre" runat="server" Width="100px" TextMode="Password" Font-Size="8pt"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td align="right" class="style5" colspan="2" style="padding-right: 10px; width: 210px;
                    text-align: right">
                    <asp:Button ID="btn_Giris" runat="server" Text="Giriþ" Width="50px" OnCommand="btn_Giris_Command" style="position: static" Font-Size="8pt" Font-Bold="True" Font-Names="Tahoma" CssClass="button" /></td>
            </tr>
            <tr>
                <td style="width: 177px; height: 26px" valign="middle">
                    &nbsp;<asp:HyperLink ID="uyeOl" runat="server" Font-Size="8pt" NavigateUrl="~/uyelik.aspx"
                        Style="position: static" Width="70px">Üye Olacaðým</asp:HyperLink></td>
                <td class="style6" style="width: 160px; height: 26px">
                    &nbsp;<asp:HyperLink ID="hypSifremiUnuttum" runat="server" Font-Size="8pt"
                        Style="position: static" Width="80px" NavigateUrl="~/sifremiunuttum.aspx">Þifremi Unuttum</asp:HyperLink></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 21px; text-align: left; width: 240px;">
                    <asp:Label ID="lbl_Error" runat="server" Font-Size="8pt" Style="position: static" Width="180px"></asp:Label></td>
            </tr>
        </table>
    </asp:View>
    <asp:View ID="Gorunum2" runat="server">
        <table style="position: static; font-size: 8pt; font-family: Arial, Tahoma; width: 188px; text-align: left; height: 140px;">
            <tr>
                <td style="width: 210px; height: 21px; text-align: left;" valign="middle">
        <asp:Label ID="lbl_Karsilama" runat="server" Style="position: static" Width="180px" Font-Bold="True" ForeColor="WhiteSmoke" Font-Size="8pt" Height="30px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 210px; height: 12px; text-align: left">
                    <asp:HyperLink ID="hyp_Uyelik" runat="server" Font-Bold="True" ForeColor="WhiteSmoke"
                        NavigateUrl="~/uyebilgileri.aspx">Kullanýcý Bilgilerim</asp:HyperLink></td>
            </tr>
            <tr>
                <td style="width: 210px; height: 12px; text-align: left">
                    <asp:HyperLink ID="hyp_SifreDegistir" runat="server" Font-Bold="True" ForeColor="WhiteSmoke"
                        NavigateUrl="~/sifredegistir.aspx">Þifre Deðiþtir</asp:HyperLink></td>
            </tr>
            <tr>
                <td style="width: 210px; height: 12px; text-align: left">
                    <asp:HyperLink ID="hyp_Fotograflarim" runat="server" Font-Bold="True" ForeColor="WhiteSmoke"
                        NavigateUrl="~/fotograflarim.aspx">Fotoðraflarým</asp:HyperLink></td>
            </tr>
            <tr>
                <td style="width: 210px; height: 12px; text-align: left;">
                    <asp:HyperLink ID="hyp_Yazilarim" runat="server" Font-Bold="True" ForeColor="WhiteSmoke"
                        NavigateUrl="~/yazilarim.aspx">Mesajlarým</asp:HyperLink></td>
            </tr>
            <tr>
                <td style="width: 210px; height: 12px; text-align: left">
                    <asp:HyperLink ID="hyp_Davetiye" runat="server" Font-Bold="True" ForeColor="WhiteSmoke"
                        NavigateUrl="~/davetiyegonder.aspx">Davetiye Gönder</asp:HyperLink></td>
            </tr>
            <tr>
                <td style="width: 210px; height: 12px; text-align: left;">
                    <asp:LinkButton ID="lnk_Cikis" runat="server" Font-Bold="True" ForeColor="WhiteSmoke" OnCommand="lnk_Cikis_Command">Çýkýþ</asp:LinkButton></td>
            </tr>
        </table>
        <br />
    </asp:View>
    
</asp:MultiView>
