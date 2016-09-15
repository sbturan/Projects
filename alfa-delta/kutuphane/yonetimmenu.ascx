<%@ Control Language="C#" AutoEventWireup="true" CodeFile="yonetimmenu.ascx.cs" Inherits="kutuphane_yonetimmenu" %>

<asp:MultiView ID="mvw_Yonetim" runat="server">
    <asp:View ID="vw_1" runat="server">
        <asp:TreeView ID="tree_Navigation1" runat="server" Font-Names="Tahoma" Font-Size="8pt"
            ImageSet="XPFileExplorer" NodeIndent="15" Style="position: static" 
            Width="100px">
            <ParentNodeStyle Font-Bold="False" />
            <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
            <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px"
                VerticalPadding="0px" />
            <Nodes>
                <asp:TreeNode Text="Yönetim " Value="Y&#246;netim B&#246;l&#252;m&#252;">
                    <asp:TreeNode Text="Sayfa İşlemleri" Value="Sayfa İşlemleri">
                        <asp:TreeNode Text="AltSayfa İşlemleri" Value="AltSayfa Ýþlemleri">
                            <asp:TreeNode NavigateUrl="~/yonetim/altsayfalar.aspx" Text="Alt Sayfalar" Value="Alt Sayfalar">
                            </asp:TreeNode>
                            <asp:TreeNode NavigateUrl="~/yonetim/altsayfaduzenle.aspx" Text="Alt Sayfa Ekle"
                                Value="Alt Sayfa Ekle"></asp:TreeNode>
                        </asp:TreeNode>
                         <asp:TreeNode Text="Banner" Value="Banner">
                            <asp:TreeNode NavigateUrl="~/yonetim/bannerYonetimi/bannerlar.aspx" Text="Banner Listesi"
                                Value="Kategoriler"></asp:TreeNode>
                            <asp:TreeNode NavigateUrl="~/yonetim/bannerYonetimi/bannerduzenle.aspx" Text="Banner Ekle"
                                Value="Kategori Ekle"></asp:TreeNode>
                             
                        </asp:TreeNode>
                        <asp:TreeNode Text="Kategoriler" Value="Kategoriler">
                            <asp:TreeNode NavigateUrl="~/yonetim/kategoriler.aspx" Text="Kategoriler"
                                Value="Kategoriler"></asp:TreeNode>
                            <asp:TreeNode NavigateUrl="~/yonetim/kategoriduzenle.aspx" Text="Kategori Ekle"
                                Value="Kategori Ekle"></asp:TreeNode>
                            
                           
                        </asp:TreeNode>
                        <asp:TreeNode Text="Ürünler" Value="Ürünler">
                            <asp:TreeNode NavigateUrl="~/yonetim/urunler.aspx" Text="Ürünler" Value="Urunler">
                            </asp:TreeNode>
                            <asp:TreeNode NavigateUrl="~/yonetim/urunduzenle.aspx" Text="Ürün Ekle" Value="Urun Ekle">
                            </asp:TreeNode>
                            <asp:TreeNode NavigateUrl="~/yonetim/urunKategori.aspx" Text="Ürün Kategori Değiştir" Value="Urun Kategori">
                            </asp:TreeNode>
                             <asp:TreeNode NavigateUrl="~/yonetim/kategorisizUrun.aspx" Text="Kategorisi Olmayan Ürünler" Value="Urun Kategori1">
                            </asp:TreeNode>
                        </asp:TreeNode>
                     
                        <asp:TreeNode Text="Menü Yönetimi" Value="Menü Yönetimi">
                            <asp:TreeNode NavigateUrl="~/yonetim/MenuDuzenle.aspx" Text="Menüler"
                                Value="Menüler"></asp:TreeNode>
                              <asp:TreeNode NavigateUrl="~/yonetim/MenuDuzenle1.aspx" Text="Menüler (İngilizce)"
                                Value="Menülerİn"></asp:TreeNode>
                        </asp:TreeNode>
                        <asp:TreeNode Text="Loglar" Value="Loglar">
                            <asp:TreeNode NavigateUrl="~/yonetim/loglar.aspx" Text="Loglar"
                                Value="Loglar"></asp:TreeNode>
                            <asp:TreeNode NavigateUrl="~/yonetim/logbilgi.aspx" Text="Log Sorgu"
                                Value="Loglar"></asp:TreeNode>
                            <asp:TreeNode NavigateUrl="~/yonetim/logkisi.aspx" Text="Log Silme"
                                Value="Loglar"></asp:TreeNode>
                        </asp:TreeNode>
                         <asp:TreeNode Text="Kulanıcılar" Value="Kullanıcılar">                 
                        <asp:TreeNode NavigateUrl="~/yonetim/kullanicilar.aspx" Text="Kullanıcılar" Value="Kullanici">
                        </asp:TreeNode>
                        <asp:TreeNode NavigateUrl="~/yonetim/Kullaniciduzenle.aspx" Text="Kullanıcı Ekle" Value="Kullaniciduzenle">
                        </asp:TreeNode> 
                         <asp:TreeNode NavigateUrl="~/yonetim/Aktifsil.aspx" Text="Aktif Olmayan Kullanıcı Sil" Value="Kullaniciduzenle">
                        </asp:TreeNode> 

                        </asp:TreeNode>
                           
                                <asp:TreeNode Text="Mail" Value="Loglar">                 
                        <asp:TreeNode NavigateUrl="~/yonetim/maillistesi.aspx" Text="Mail Listesi" Value="&#220;yeler">
                        </asp:TreeNode>
                       
                         <asp:TreeNode NavigateUrl="~/yonetim/kisilereemailgonder.aspx" Text="Liste Seç Mail Gönder" Value="Mail G&#246;nder">
                        </asp:TreeNode>  
                         <asp:TreeNode NavigateUrl="~/yonetim/Mailduzenle.aspx" Text="Mail yollama bilgileri" Value="Mail G&#246;nder">
                        </asp:TreeNode> 
                         </asp:TreeNode>  
                                 <asp:TreeNode Text="Bank Bilgileri" Value="Banka Bilgileri">                 
                        <asp:TreeNode NavigateUrl="~/yonetim/bankalar.aspx" Text="Bank Bilgileri" Value="&#220;yeler">
                        </asp:TreeNode>
                        <asp:TreeNode NavigateUrl="~/yonetim/bankduzenle.aspx" Text="Bank Bilgileri Ekle" Value="Mail G&#246;nder">
                        </asp:TreeNode> 

                         </asp:TreeNode>                   
                    </asp:TreeNode>
                   
                    <asp:TreeNode NavigateUrl="~/yonetim/parabirimi.aspx" Text="Doviz Duzenleme" Value="Doviz">
                    </asp:TreeNode>
                    <asp:TreeNode NavigateUrl="~/yonetim/sifredegistir.aspx" Text="Sifre Degistir" Value="Sifre Degistir">
                    </asp:TreeNode>
                    <asp:TreeNode NavigateUrl="~/yonetim/logout.aspx" Text="Cıkış" Value="&#199;ýkýþ">
                    </asp:TreeNode>
                </asp:TreeNode>
            </Nodes>
            <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px"
                NodeSpacing="0px" VerticalPadding="2px" />
        </asp:TreeView>
    </asp:View>
</asp:MultiView>