<%@ Page Language="C#" MasterPageFile="~/yonetim/yonetim.master" AutoEventWireup="true" CodeFile="bannerduzenle.aspx.cs" Inherits="yonetim_bannerYonetimi_bannerduzenle" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
      <script language="javascript" type="text/javascript">
 
      
        
        function openResimTarayici(obj, type, target)
        { 
           currentobj = target; 
           urlobj = obj; 
           if (type == '') type = 'Image'; 
           var width = 580; 
           var height = 440; 
           var top = ((screen.availHeight - height) / 2) - 20; 
           var left = (screen.availWidth - width) / 2; 
           var newwin = window.open('../fckeditor/editor/filemanager/browser/default/browser.html?Type=' + type + '&Connector=connectors/aspx/connector.aspx', 'FileBrowser', 'resizable=no,scrollbars=no,dependent=yes,width='+width+',height='+height+',top='+top+',left='+left); 
           newwin.focus(); 
           return false; 
        }
      
      
    </script>
   
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100px">
        <tr>
            <td style="width: 100%; height: 20px">
                <asp:Label ID="lbl_Baslik" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="11pt"
                    ForeColor="#CC0000" Style="position: static" Text="Banner Düzenle" Width="190px"></asp:Label>
                <asp:Label ID="lbl_Mesaj" runat="server" Font-Bold="False" Style="position: static"
                    Visible="False" Width="256px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100%; height: 143px" valign="top">
                <asp:FormView ID="frm_Banner" runat="server" DataKeyNames="ID" DataSourceID="ObjectBannerDuzenle"
                    OnItemCommand="frm_Banner_ItemCommand" OnItemCreated="frm_Banner_ItemCreated"
                    OnModeChanged="frm_Banner_ModeChanged" Width="562px" 
                    OnPageIndexChanging="frm_Banner_PageIndexChanging" EnableModelValidation="True">
                    <EditItemTemplate><table style="width: 524px; height: 97px;">
                        <tr>
                            <td colspan="2" style="text-align: left; height: 20px; width: 100%;">
                                <asp:Label ID="lbl_Guncelle" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="RoyalBlue"
                                    Text="Banner Güncelleme"></asp:Label></td>
                        </tr>
                        <tr style="color: #000000">
                            <td style="width: 110px;" align="right">
                                <asp:RequiredFieldValidator ID="val_Ad" runat="server" ControlToValidate="txt_Adi"
                                    ErrorMessage="Ad Giriniz" ValidationGroup="BannerDuzenle" Width="15px">*</asp:RequiredFieldValidator><strong>
                                    </strong>
                                <asp:Label ID="lbl_BannerAdi" runat="server" Font-Bold="True" Text="Banner Adý" Width="76px"></asp:Label></td>
                            <td style="width: 400px; height: 18px;">
                                <asp:TextBox ID="txt_Adi" runat="server" Text='<%# Bind("ADI") %>' Width="380px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 110px" valign="top">
                                &nbsp;<asp:Label ID="lbl_Dosya" runat="server" Font-Bold="True" Text="Dosya Yolu" Width="83px"></asp:Label></td>
                            <td style="width: 380px; height: 18px">
                                <asp:TextBox ID="txt_Banner" runat="server" Width="289px"></asp:TextBox>
                                <asp:Button
                                        ID="btn_Ara" runat="server" CssClass="button" OnLoad="GetImageBrowser" Text="Araþtýr"
                                        Width="80px" /><br />
                                <asp:Label ID="lbl_Yuklenen" runat="server" BackColor="#FFFF80" Font-Names="Tahoma"
                                    Font-Size="10pt" ForeColor="DimGray" Height="30px" Text='<%# Eval("DOSYA") %>'
                                    Width="385px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 110px">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_URL"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="URL"></asp:Label></td>
                            <td style="width: 380px; height: 18px">
                                <asp:TextBox ID="txt_URL" runat="server" Text='<%# Bind("URL") %>' Width="380px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 110px">
                                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Geniþlik"></asp:Label></td>
                            <td style="width: 380px">
                                <asp:TextBox ID="txt_genislik" runat="server" Text='<%# Bind("GENISLIK") %>' Width="50px"></asp:TextBox>
                                px</td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 110px">
                                <asp:Label ID="label3" runat="server" Font-Bold="True" Text="Yükseklik"></asp:Label></td>
                            <td style="width: 380px; height: 26px">
                                <asp:TextBox ID="txt_yukseklik" runat="server" Text='<%# Bind("YUKSEKLIK") %>' Width="50px"></asp:TextBox>
                                px</td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 110px">
                                <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Gösterim Süresi" Width="103px"></asp:Label></td>
                            <td style="width: 380px">
                                <asp:TextBox ID="txt_relay" runat="server" Text='<%# Bind("RELAY") %>' Width="50px"></asp:TextBox>
                                msn</td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 110px">
                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Durum"></asp:Label></td>
                            <td style="width: 380px">
                                <asp:DropDownList ID="drp_durum" runat="server" DataSourceID="XMLYayinDurumu" DataTextField="adi"
                                        DataValueField="id" Width="360px" SelectedValue='<%# Bind("YAYIN_DURUMU") %>'>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 110px">
                                <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Yayýn Tipi"></asp:Label></td>
                            <td style="width: 380px; height: 24px">
                                <asp:DropDownList ID="drp_yayintipi" runat="server" DataSourceID="XmlGorselTipi"
                                        DataTextField="adi" DataValueField="id" Width="360px" SelectedValue='<%# Bind("TIP") %>'>
                                </asp:DropDownList></td>
                        </tr>
                        
                        <tr>
                            <td style="width: 110px; text-align: right; height: 26px;">
                            </td>
                            <td style="width: 380px; height: 26px;">
                                &nbsp;<strong>Güncelleden Sonra</strong>
                                <asp:RadioButton ID="rdGeri" runat="server" Checked="True" GroupName="redirect" Text="Geri Dön" />
                                <asp:RadioButton ID="rdList" runat="server" GroupName="redirect" Text="Listeye Dön" />
                                <asp:Button ID="btn_Guncelle" runat="server" CssClass="button" Font-Bold="True"
                                         Text="Güncelle" ValidationGroup="BannerDuzenle"
                                        Width="104px" OnClick="btn_Guncelle_Click" />&nbsp;</td>
                        </tr>
                    </table>
                        <br />
                        <asp:HiddenField ID="hdn_ID" runat="server" Value='<%# Eval("ID") %>' />
                        <asp:HiddenField ID="hdn_Dosya" runat="server" Value='<%# Eval("DOSYA") %>' />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <table style="width: 520px; height: 97px;">
                            <tr>
                                <td colspan="2" style="text-align: left; height: 20px; width: 100%;">
                                    <asp:Label ID="lbl_Guncelle" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="RoyalBlue"
                                        Text="Banner Ekleme"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 110px;" align="right">
                                    <asp:RequiredFieldValidator ID="val_Ad" runat="server" ControlToValidate="txt_Adi"
                                        ErrorMessage="Ad Giriniz" ValidationGroup="BannerDuzenle" Width="15px">*</asp:RequiredFieldValidator>
                                    <asp:Label ID="lbl_BannerAdi" runat="server" Font-Bold="True" Text="Banner Adý" Width="76px"></asp:Label></td>
                                <td style="width: 400px; height: 18px;">
                                    <asp:TextBox ID="txt_Adi" runat="server" Width="380px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 110px" valign="top">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_Banner"
                                        ErrorMessage="Dosya Ekleyiniz" ValidationGroup="BannerDuzenle" Width="15px">*</asp:RequiredFieldValidator>
                                    <asp:Label ID="lbl_Dosya" runat="server" Font-Bold="True" Text="Dosya Yolu" Width="83px"></asp:Label></td>
                                <td style="width: 380px; height: 18px">
                                    <asp:TextBox ID="txt_Banner" runat="server" Width="289px"></asp:TextBox>
                                    <asp:Button
                                        ID="btn_Ara" runat="server" CssClass="button" OnLoad="GetImageBrowser" Text="Araþtýr"
                                        Width="80px" /><br />
                                    <asp:Label ID="lbl_Yuklenen" runat="server" BackColor="#FFFF80" Font-Names="Tahoma"
                                        Font-Size="10pt" ForeColor="DimGray" Height="30px" Text='<%# Bind("foto") %>'
                                        Width="385px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 110px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_URL"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="URL"></asp:Label></td>
                                <td style="width: 380px; height: 18px">
                                    <asp:TextBox ID="txt_URL" runat="server" Width="380px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 110px">
                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Geniþlik"></asp:Label></td>
                                <td style="width: 380px">
                                    <asp:TextBox ID="txt_genislik" runat="server" Width="50px">0</asp:TextBox>
                                    px</td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 110px">
                                    <asp:Label ID="label3" runat="server" Font-Bold="True" Text="Yükseklik"></asp:Label></td>
                                <td style="width: 380px; height: 26px">
                                    <asp:TextBox ID="txt_yukseklik" runat="server" Width="50px">0</asp:TextBox>
                                    px</td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 110px">
                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Gösterim Süresi" Width="103px"></asp:Label></td>
                                <td style="width: 380px">
                                    <asp:TextBox ID="txt_relay" runat="server" Width="50px">0</asp:TextBox>
                                    msn</td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 110px">
                                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Durum"></asp:Label></td>
                                <td style="width: 380px">
                                    <asp:DropDownList ID="drp_durum" runat="server" DataSourceID="XMLYayinDurumu" DataTextField="adi"
                                        DataValueField="id" Width="360px" 
                                        SelectedValue='<%# Bind("YAYIN_DURUMU") %>'>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 110px">
                                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Yayýn Tipi"></asp:Label></td>
                                <td style="width: 380px; height: 24px">
                                    <asp:DropDownList ID="drp_yayintipi" runat="server" DataSourceID="XmlGorselTipi"
                                        DataTextField="adi" DataValueField="id" Width="360px">
                                    </asp:DropDownList></td>
                            </tr>
                            
                            <tr>
                                <td style="width: 110px; text-align: right; height: 26px;">
                                </td>
                                <td style="width: 380px; height: 26px;">
                                    <asp:Button ID="btn_BannerEkle" runat="server" CssClass="button" Font-Bold="True"
                                         Text="Banner Ekle" ValidationGroup="BannerDuzenle"
                                        Width="105px" OnClick="btn_BannerEkle_Click" />
                                    <strong>Ekledikten Sonra</strong>
                                    <asp:RadioButton ID="rdGeri" runat="server" Checked="True" GroupName="redirect" Text="Geri Dön" />
                                    <asp:RadioButton ID="rdList" runat="server" GroupName="redirect" Text="Listeye Dön" /></td>
                            </tr>
                        </table>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <table style="width: 592px; height: 54px">
                            <tr style="font-weight: bold; color: #000000">
                                <td style="width: 120px; height: 26px; text-align: right">
                                </td>
                                <td style="width: 450px; height: 26px">
                                    &nbsp;<asp:Button ID="btn_Duzenle" runat="server"
                                            CausesValidation="False" CommandName="Edit" CssClass="button" Font-Bold="True"
                                             Style="position: static" Text="Düzenle" Width="110px" OnClick="btn_Duzenle_Click" />
                                    &nbsp;<asp:Button
                                                ID="btn_Sil" runat="server" CommandName="_delete" CssClass="button" Font-Bold="True"
                                                Style="position: static" Text="Sil" Width="110px" /></td>
                            </tr>
                            <tr style="font-weight: bold; color: #000000">
                                <td style="width: 120px; height: 26px; text-align: right" align="left">
                                    <asp:Label ID="lbl_Ad" runat="server" Font-Bold="True" Text="Adý"></asp:Label></td>
                                <td style="width: 150px; height: 26px">
                                    <asp:Label ID="lbl_Adi" runat="server" Font-Bold="False" Text='<%# Eval("ADI") %>'
                                        Width="380px"></asp:Label></td>
                            </tr>
                            <tr style="font-weight: bold; color: #000000">
                                <td style="width: 120px; height: 26px; text-align: right" align="left">
                                    <asp:Label ID="lbl_Dosya" runat="server" Font-Bold="True" Text="Dosya Yolu" Width="83px"></asp:Label></td>
                                <td style="width: 150px; height: 26px">
                                    <asp:Label ID="lbl_dosya_yolu" runat="server" Text='<%# Eval("DOSYA") %>' Font-Bold="False" Width="380px"></asp:Label></td>
                            </tr>
                            <tr style="font-weight: bold; color: #000000">
                                <td style="width: 120px; height: 26px; text-align: right">
                                    <asp:Label ID="Label1" runat="server" Text="URL"></asp:Label></td>
                                <td style="width: 150px; height: 26px">
                                    <asp:Label ID="lbl_Url" runat="server" Text='<%# Eval("URL") %>' Font-Bold="False" Width="380px"></asp:Label></td>
                            </tr>
                            <tr style="font-weight: bold; color: #000000">
                                <td style="width: 120px; height: 26px; text-align: right">
                                    <asp:Label ID="Label2" runat="server" Text="Geniþlik"></asp:Label></td>
                                <td style="width: 150px; height: 26px">
                                    <asp:Label ID="lbl_genislik" runat="server" Text='<%# Eval("GENISLIK").ToString() != "" ? Eval("GENISLIK") + " px" : "" %>' Font-Bold="False" Width="50px"></asp:Label></td>
                            </tr>
                            <tr style="font-weight: bold; color: #000000">
                                <td style="width: 120px; height: 26px; text-align: right">
                                    <asp:Label ID="label3" runat="server" Text="Yükseklik"></asp:Label></td>
                                <td style="width: 150px; height: 26px">
                                    <asp:Label ID="lbl_yukseklik" runat="server" Text='<%# Eval("YUKSEKLIK").ToString() != "" ? Eval("YUKSEKLIK") + " px" : "" %>' Font-Bold="False" Width="50px"></asp:Label></td>
                            </tr>
                            <tr style="font-weight: bold; color: #000000">
                                <td style="width: 120px; height: 26px; text-align: right">
                                    <asp:Label ID="Label4" runat="server" Text="Gösterim Süresi" Width="103px"></asp:Label></td>
                                <td style="width: 150px; height: 26px">
                                    <asp:Label ID="lbl_relay" runat="server" Text='<%# Eval("RELAY").ToString() != "" ?  Eval("RELAY") + "msn" : "" %>' Font-Bold="False" Width="50px"></asp:Label></td>
                            </tr>
                            <tr style="font-weight: bold; color: #000000">
                                <td style="width: 120px; height: 26px; text-align: right">
                                    <asp:Label ID="Label6" runat="server" Text="Tarih"></asp:Label>
                                </td>
                                <td style="width: 150px; height: 26px">
                                    <asp:Label ID="lbl_tarih" runat="server" Text='<%# Eval("TARIH", "{0:d}") %>' Font-Bold="False" Width="380px"></asp:Label></td>
                            </tr>
                            <tr style="font-weight: bold; color: #000000">
                                <td style="width: 120px; height: 26px; text-align: right">
                                    <asp:Label ID="Label5" runat="server" Text="Durum"></asp:Label></td>
                                <td style="width: 150px; height: 26px">
                                    <asp:DropDownList ID="drp_durum" runat="server" DataSourceID="XMLYayinDurumu" DataTextField="adi" DataValueField="id" SelectedValue='<%# Bind("YAYIN_DURUMU") %>' Width="360px" Enabled="False">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr style="font-weight: bold; color: #000000">
                                <td style="width: 120px; height: 26px; text-align: right">
                                    <asp:Label ID="Label7" runat="server" Text="Dosya Tipi"></asp:Label></td>
                                <td style="width: 150px; height: 26px">
                                    <asp:DropDownList ID="drp_yayin_tipi" runat="server" DataSourceID="XmlGorselTipi" DataTextField="adi" DataValueField="id" Width="360px" SelectedValue='<%# Bind("TIP") %>' Enabled="False">
                                    </asp:DropDownList></td>
                            </tr>
                            
                            <tr style="font-weight: bold; color: #000000">
                                <td style="width: 120px; height: 26px; text-align: right">
                                    <asp:Label ID="Label9" runat="server" Text="Hit"></asp:Label></td>
                                <td style="width: 150px; height: 26px">
                                    <asp:Label ID="lbl_hit" runat="server" Text='<%# Eval("HIT") %>' Font-Bold="False" Width="380px"></asp:Label></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:FormView>
                <asp:ObjectDataSource ID="ObjectBannerDuzenle" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetBannerByID" TypeName="BannerBLL" 
                    DataObjectTypeName="BannerInfo" DeleteMethod="Delete" InsertMethod="Insert" 
                    UpdateMethod="Update">
                    <SelectParameters>
                        <asp:QueryStringParameter DefaultValue="0" Name="ID" QueryStringField="BANNER_ID"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:XmlDataSource ID="XMLYayinDurumu" runat="server" DataFile="~/XML/XMLFile.xml"
                    XPath="root/yayin_durumu/item"></asp:XmlDataSource>
                <asp:XmlDataSource ID="XmlGorselTipi" runat="server" DataFile="~/XML/XMLFile.xml"
                    XPath="root/banner_tipi/item"></asp:XmlDataSource>
                
            </td>
        </tr>
    </table>
</asp:Content>

