<%@ Page Language="C#" MasterPageFile="~/yonetim/yonetim.master" AutoEventWireup="true"
    CodeFile="kategoriduzenle.aspx.cs" Inherits="yonetim_kategoriduzenle" Title="Untitled Page"
    ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 800px; position: static">
        <tr>
            <td style="width: 800px">
                <asp:Label ID="lbl_Baslik" runat="server" Font-Bold="True" Font-Size="11pt" ForeColor="Crimson"
                    Style="position: static" Text="kategori  Düzenleme" Width="208px"></asp:Label>
                <asp:Label ID="lbl_Mesaj" runat="server" Font-Bold="False" Style="position: static"
                    Visible="False" Width="256px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 606px" valign="top">
                <asp:FormView ID="frm_AltSayfaDuzen" runat="server" Style="position: static" DataSourceID="Objkategoribyid"
                    OnItemCommand="frm_AltSayfaDuzen_ItemCommand" DataKeyNames="ID" OnItemCreated="frm_AltSayfaDuzen_ItemCreated"
                    OnModeChanged="frm_AltSayfaDuzen_ModeChanged">
                    <InsertItemTemplate>
                        <table style="width: 760px; position: static">
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lbl_Ekleme" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="RoyalBlue"
                                        Text="Kategorı Ekleme"></asp:Label>
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 207px; text-align: right">
                                    <strong>Adı</strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:TextBox ID="txt_Adi" runat="server" Style="position: static" Width="286px" 
                                        Height="23px"></asp:TextBox>
                                </td>
                                <td style="width: 60px">
                                    <asp:RequiredFieldValidator ID="rqd_Adi" runat="server" ControlToValidate="txt_Adi"
                                        ErrorMessage="Adi Giriniz" Style="position: static" ValidationGroup="ICERIK">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 207px; text-align: right; vertical-align: top">
                                    <strong>Ust ID</strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:DropDownList ID="Drpustid" runat="server" Visible="true" Height="25px" Width="195px">
                                    </asp:DropDownList>
                                    <br />
                                    <br />
                                </td>
                                <td style="width: 60px" valign="top">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 207px; text-align: right; vertical-align: top">
                                    <strong>Resim</strong>
                                </td>
                                <td style="width: 308px">
                                    <table style="width: 344px; position: static;">
                                        <tbody>
                                            <tr style="font-weight: bold; font-size: 10pt; font-family: Arial">
                                                <td style="text-align: left">
                                                    <asp:TextBox ID="txt_Resim" runat="server" Width="190px"></asp:TextBox>&nbsp;<asp:Button
                                                        ID="btn_Ara" runat="server" CssClass="button" OnLoad="GetImageBrowser" Text="Araştır"
                                                        Width="80px" />
                                                </td>
                                                <td align="center" colspan="1" rowspan="2" style="width: 5px; font-size: 9pt; font-family: Arial;"
                                                    valign="middle">
                                                    <asp:Image ID="img_Resim" runat="server" Height="80px" Style="position: static" Width="100px"
                                                        Visible="False" /><span style="font-size: 10pt"><strong>&nbsp; </strong></span>
                                                </td>
                                            </tr>
                                            <tr style="font-weight: bold; font-size: 10pt; font-family: Arial">
                                                <td style="width: 330px; text-align: left; height: 54px;">
                                                    <span style="font-family: Tahoma"></span>
                                                    <asp:Label ID="lbl_Yuklenen" runat="server" BackColor="#FFFF80" Font-Names="Tahoma"
                                                        Font-Size="10pt" ForeColor="DimGray" Height="30px" Text='<%# Bind("foto") %>'
                                                        Width="280px"></asp:Label>&nbsp;
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>
                           
                            <tr>
                                <td style="width: 207px; text-align: right">
                                    <strong>Yayın Durumu</strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:DropDownList ID="drp_YayinDurumu" runat="server" Style="position: static" Width="194px"
                                        DataSourceID="XMLYayinDurumu" DataTextField="adi" DataValueField="id" AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>

                            <tr> <td style="width: 207px; text-align: right">
                                    <strong>Bu kategori altında<br /> &nbsp;Görünüm Şekli</strong></td>
                                <td>
                                    <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="XmlDataSource1" DataTextField="adi" DataValueField="id" Width="190px" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>

                                </td>
                                 <td style="width: 60px">
                                </td>

                            </tr>

                          



  <tr>
                                <td style="width: 207px; text-align: right">
                                    <strong></strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:DropDownList ID="DropDownList2" runat="server" Style="position: static" Width="199px"
                                        DataSourceID="XmlDataSource2" DataTextField="adi"  Height="26px" Visible="False" DataValueField="id">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 207px; text-align: right">
                                </td>
                                <td style="width: 308px">
                                    <asp:Button ID="btn_Kaydet" runat="server" OnClick="btn_Kaydet_Click" Style="position: static"
                                        Text="Kaydet" Width="168px" CssClass="button" Font-Bold="True" ValidationGroup="ICERIK" />
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>
                        </table>
                        <asp:ValidationSummary ID="vd_Summary" runat="server" ShowMessageBox="True" ShowSummary="False"
                            Style="position: static" ValidationGroup="ICERIK" />
                        <br />
                        &nbsp;
                      
                    </InsertItemTemplate>
                    <EditItemTemplate>
                        <table style="width: 760px; position: static">
                            <tr>
                                <td colspan="2" style="text-align: left">
                                    <asp:Label ID="lbl_Guncelleme" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="RoyalBlue"
                                        Text="Kategori Güncelleme"></asp:Label>
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 207px; text-align: right">
                                    <strong>Adı</strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:TextBox ID="txt_Adi" runat="server" Style="position: static" Text='<%# Bind("ADI") %>'
                                        Width="560px"></asp:TextBox>
                                </td>
                                <td style="width: 60px">
                                    <asp:RequiredFieldValidator ID="rqd_Konu" runat="server" ControlToValidate="txt_Adi"
                                        ErrorMessage="Konu Giriniz" Style="position: static" ValidationGroup="ICERIK">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 207px; text-align: right; vertical-align: top; height: 40px;">
                                    <strong>Ust ID ADI</strong>
                                </td>
                                <td style="width: 308px; height: 40px;">
                                    
                                        <asp:DropDownList ID="Drpustid" runat="server" Height="31px" Width="268px">
                                    </asp:DropDownList>
                                        <br />
                                        <br />

                                </td>
                                <td style="width: 60px; height: 40px;" valign="top">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 207px; text-align: right; vertical-align: top">
                                    <strong>Resim</strong>
                                </td>
                                <td style="width: 308px">
                                    <table style="width: 344px; position: static;">
                                        <tbody>
                                            <tr style="font-weight: bold; font-size: 10pt; font-family: Arial">
                                                <td style="text-align: left">
                                                    <asp:TextBox ID="txt_Resim" runat="server" Width="190px"></asp:TextBox>
                                                    <asp:Button ID="btn_Ara" runat="server" CssClass="button" OnLoad="GetImageBrowser"
                                                        Text="Araştır" Width="80px" />
                                                </td>
                                                <td align="center" colspan="1" rowspan="2" style="width: 5px; font-size: 9pt; font-family: Arial;"
                                                    valign="middle">
                                                    <asp:Image ID="img_Resim" runat="server" Height="80px" Style="position: static" Width="100px"
                                                        ImageUrl='<%# "~/resize.ashx?adres=" + Eval("ICON") + "&gen=100&yuk=80&tip=K" %>' /><span
                                                            style="font-size: 10pt"><strong> </strong></span>
                                                </td>
                                            </tr>
                                            <tr style="font-weight: bold; font-size: 10pt; font-family: Arial">
                                                <td style="width: 330px; text-align: left; height: 54px;">
                                                    <span style="font-family: Tahoma"></span>
                                                    <asp:Label ID="lbl_Yuklenen" runat="server" BackColor="#FFFF80" Font-Names="Tahoma"
                                                        Font-Size="10pt" ForeColor="DimGray" Height="30px" Text='<%# Bind("ICON") %>'
                                                        Width="280px"></asp:Label>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>
                           
                            
                           
                            <tr>
                                <td style="width: 207px; text-align: right">
                                    <strong>Yayın Durumu</strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:DropDownList ID="drp_YayinDurumu" runat="server" Style="position: static" Width="280px"
                                        DataSourceID="XMLYayinDurumu" DataTextField="adi" DataValueField="id" SelectedValue='<%# Eval("YAYIN_DURUMU") %>' AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>
                             <tr>
                                <td style="width: 207px; text-align: right">
                                    <strong>Bu kategori altında Görünüm Şekli</strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:DropDownList ID="DropDownList3" runat="server" Style="position: static" Width="280px"
                                        DataSourceID="XmlDataSource1" DataTextField="adi" DataValueField="id" SelectedValue='<%# Eval("LISTE") %>' Height="18px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged1" >
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>

                              <tr>
                                <td style="width: 207px; text-align: right">
                                    <strong></strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:DropDownList ID="DropDownList2" runat="server" Style="position: static" Width="280px"
                                        DataSourceID="XmlDataSource2" DataTextField="adi" DataValueField="id"   Height="18px" Visible="False">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>



                              <tr>
                                                            <td style="width: 194px; text-align: right">
                                                                &nbsp;</td>
                                                            <td style="width: 393px">
                                                                &nbsp;</td>
                                                        </tr>
                            <tr>
                                <td style="width: 207px; text-align: right">
                                </td>
                                <td style="width: 500px">
                                    <asp:Button ID="btn_Guncelle" runat="server" OnClick="btn_Guncelle_Click" Style="position: static"
                                        Text="Güncelle" Width="168px" CssClass="button" Font-Bold="True" ValidationGroup="ICERIK" />
                                    <asp:Button ID="btn_Vazgec" runat="server" CssClass="button" Font-Bold="True" OnClick="btn_Vazgec_Click"
                                        Style="position: static" Text="Vazgeç" Width="168px" />
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>
                        </table>
                        <asp:ValidationSummary ID="vd_Summary" runat="server" ShowMessageBox="True" ShowSummary="False"
                            Style="position: static" ValidationGroup="ICERIK" />
                       <asp:HiddenField ID="hdn_Foto" runat="server" Value='<%# Eval("ICON") %>' />

                        <asp:HiddenField ID="hdn_ID" runat="server" Value='<%# Eval("ID") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <table style="width: 760px; position: static">
                            <tr>
                                <td style="width: 207px; text-align: right">
                                </td>
                                <td style="width: 500px">
                                    <asp:Button ID="btn_Duzenle" runat="server" CausesValidation="False" CommandName="Edit"
                                        CssClass="button" Font-Bold="True" OnClick="btn_Duzenle_Click" Style="position: static"
                                        Text="Düzenle" Width="110px" />
                                    <asp:Button ID="btn_Sil" runat="server" CssClass="button" Font-Bold="True" Style="position: static"
                                        Text="Sil" Width="110px" CommandName="_delete" OnClick="btn_Sil_Click1" />
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 207px; text-align: right">
                                    <strong>Adı </strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:Label ID="lbl_Adi" runat="server" Style="position: static" Text='<%# Eval("ADI") %>'
                                        Width="568px"></asp:Label>
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 207px; text-align: right; vertical-align: top; height: 113px;">
                                    <strong>Resim </strong>
                                </td>
                                  <td align="center" colspan="1" rowspan="2" style="width: 5px; font-size: 9pt; font-family: Arial;"
                                                    valign="middle">
                                                    <asp:Image ID="img_Resim" runat="server" Height="108px" Style="position: static" Width="201px"
                                                        
                                                        ImageUrl='<%# "~/resize.ashx?adres=" + Eval("ICON") + "&gen=100&yuk=80&tip=K" %>' /><span
                                                            style="font-size: 10pt"><strong> </strong></span>
                                                </td>
                             
                            </tr>
                           
                            <tr><td></td></tr>
                            
                            <tr>
                                <td style="width: 207px; text-align: right; height: 15px;">
                                    <strong>Yayın Durumu </strong>
                                </td>
                                <td style="width: 308px; height: 15px;">
                                    <asp:DropDownList ID="drp_YayinDurumu" runat="server" Style="position: static" Width="215px"
                                        DataSourceID="XMLYayinDurumu" DataTextField="adi" DataValueField="id" SelectedValue='<%# Eval("YAYIN_DURUMU") %>'
                                        Enabled="False" Height="25px">
                                    </asp:DropDownList>
                                </td>
                               
                            </tr>
                           
                           
                            
                        </table>
                        <asp:HiddenField ID="hdn_Foto" runat="server" Value='<%# Eval("ICON") %>' />
                        <br />
                        <cc1:ConfirmButtonExtender ID="cnfrm_Button" runat="server" ConfirmText="Silinecek ?"
                            TargetControlID="btn_Sil">
                        </cc1:ConfirmButtonExtender>
                    </ItemTemplate>
                </asp:FormView>
                 <asp:XmlDataSource ID="XMLYayinDurumu" runat="server" DataFile="~/XML/XMLFile.xml"
                    XPath="root/yayin_durumu/item"></asp:XmlDataSource>
                <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/XML/XMLFile.xml"
                    XPath="root/liste_durumu/item"></asp:XmlDataSource>
                <asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile="~/XML/XMLFile.xml"
                    XPath="root/liste_gorunumu/item"></asp:XmlDataSource>
                <asp:ObjectDataSource ID="Objkategoribyid" runat="server" 
                    DataObjectTypeName="KategoriInfo" DeleteMethod="Delete" InsertMethod="Insert" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetKategoriByID" 
                    TypeName="KategoriBLL" UpdateMethod="Update">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="ID" QueryStringField="ID" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                  <asp:XmlDataSource ID="XmlDil" runat="server" DataFile="~/XML/XMLFile.xml" XPath="root/dil/item">
                </asp:XmlDataSource>


                    </td></tr></table>


</asp:Content> 