<%@ Page Language="C#" MasterPageFile="~/yonetim/yonetim.master" AutoEventWireup="true"
    CodeFile="Kullaniciduzenle.aspx.cs" Inherits="yonetim_kullaniciduzenle" Title="Untitled Page"
    ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
   
    <table style="width: 800px; position: static">
        <tr>
            <td style="width: 800px">
                <asp:Label ID="lbl_Baslik" runat="server" Font-Bold="True" Font-Size="11pt" ForeColor="Crimson"
                    Style="position: static" Text="Kullanıcı Düzenleme" Width="208px"></asp:Label>
                <asp:Label ID="lbl_Mesaj" runat="server" Font-Bold="False" Style="position: static"
                    Visible="False" Width="256px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 606px" valign="top">
                <asp:FormView ID="frm_AltSayfaDuzen" runat="server" Style="position: static" DataSourceID="Objurunbyid"
                    OnItemCommand="frm_AltSayfaDuzen_ItemCommand" DataKeyNames="Id" OnItemCreated="frm_AltSayfaDuzen_ItemCreated"
                    OnModeChanged="frm_AltSayfaDuzen_ModeChanged" EnableModelValidation="True">
                    <InsertItemTemplate>
                        <table style="width: 760px; position: static">
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lbl_Ekleme" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="RoyalBlue"
                                        Text="Kullanıcı Ekleme"></asp:Label>
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 207px; text-align: right">
                                    <strong>Adı</strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:TextBox ID="txt_Adi" runat="server" Style="position: static" Width="560px"></asp:TextBox>
                                </td>
                                <td style="width: 60px">
                                    <asp:RequiredFieldValidator ID="rqd_Adi" runat="server" ControlToValidate="txt_Adi"
                                        ErrorMessage="Adi Giriniz" Style="position: static" ValidationGroup="ICERIK">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                                  <tr>
                                <td style="width: 207px; text-align: right">
                                    <strong>Soyadı</strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:TextBox ID="txt_Soyadi" runat="server" Style="position: static" Width="560px"></asp:TextBox>
                                </td>
                                <td style="width: 60px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txt_Soyadi"
                                        ErrorMessage="Soyadı Giriniz" Style="position: static" ValidationGroup="ICERIK">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                               <tr>
                                <td style="width: 207px; text-align: right">
                                    <strong>Email</strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:TextBox ID="txt_Email" runat="server" Style="position: static" Width="560px"></asp:TextBox>
                                </td>
                                <td style="width: 60px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txt_Soyadi"
                                        ErrorMessage="Email Giriniz" Style="position: static" ValidationGroup="ICERIK">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            
                            <tr>
                                <td style="width: 207px; text-align: right">
                                    <strong>Telefon</strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:TextBox ID="txt_TelNo" runat="server" Style="position: static" Width="560px"></asp:TextBox>
                                </td>
                                <td style="width: 60px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txt_Soyadi"
                                        ErrorMessage="Telefon Giriniz" Style="position: static" ValidationGroup="ICERIK">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                             <tr>
                                <td style="width: 207px; text-align: right">
                                    <strong>Şifre</strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:TextBox ID="TextBox2" runat="server" Style="position: static" Width="560px"></asp:TextBox>
                                </td>
                                <td style="width: 60px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_Soyadi"
                                        ErrorMessage="Telefon Giriniz" Style="position: static" ValidationGroup="ICERIK">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                                                 
                    
                            <tr>
                                <td style="width: 207px; text-align: right; vertical-align: top">
                                    <strong>Durum </strong>
                                </td>
                                <td style="width: 308px">
                                     <asp:DropDownList ID="drpdurum" runat="server" Height="24px" Width="129px">
                                          <asp:ListItem Value="-1">Durumunu Seçiniz</asp:ListItem>
                                        <asp:ListItem Value="True">Aktif</asp:ListItem>
                                        <asp:ListItem Value="False">Pasif</asp:ListItem>
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
                                        Text="Kullanıcı Güncelleme"></asp:Label>
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>
                         <tr>
                                <td style="width: 207px; text-align: right">
                                    <strong>Adı</strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:TextBox ID="txt_Adi" runat="server" Style="position: static" Width="560px" Text='<%# Eval("Adi") %>'></asp:TextBox>
                                </td>
                                <td style="width: 60px">
                                    <asp:RequiredFieldValidator ID="rqd_Adi" runat="server" ControlToValidate="txt_Adi"
                                        ErrorMessage="Adi Giriniz" Style="position: static" ValidationGroup="ICERIK">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                                  <tr>
                                <td style="width: 207px; text-align: right">
                                    <strong>Soyadı</strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:TextBox ID="txt_Soyadi" runat="server" Style="position: static" Width="560px" Text='<%# Eval("Soyadi") %>'></asp:TextBox>
                                </td>
                                <td style="width: 60px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txt_Soyadi"
                                        ErrorMessage="Soyadı Giriniz" Style="position: static" ValidationGroup="ICERIK">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                               <tr>
                                <td style="width: 207px; text-align: right">
                                    <strong>Email</strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:TextBox ID="txt_Email" runat="server" Style="position: static" Width="560px" Text='<%# Eval("Email") %>'></asp:TextBox>
                                </td>
                                <td style="width: 60px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txt_Soyadi"
                                        ErrorMessage="Email Giriniz" Style="position: static" ValidationGroup="ICERIK">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            
                            <tr>
                                <td style="width: 207px; text-align: right">
                                    <strong>Telefon</strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:TextBox ID="txt_TelNo" runat="server" Style="position: static" Width="560px" Text='<%# Eval("Telefon") %>'></asp:TextBox>
                                </td>
                                <td style="width: 60px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txt_Soyadi"
                                        ErrorMessage="Telefon Giriniz" Style="position: static" ValidationGroup="ICERIK">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 207px; text-align: right">
                                    <strong>Şifre</strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:TextBox ID="TextBox2" runat="server" Style="position: static" Width="560px" Text='<%# Eval("Sifre") %>'></asp:TextBox>
                                </td>
                                <td style="width: 60px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_Soyadi"
                                        ErrorMessage="Telefon Giriniz" Style="position: static" ValidationGroup="ICERIK">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 207px; text-align: right; vertical-align: top">
                                    <strong>Durum </strong>
                                </td>
                                <td style="width: 308px">
                                     <asp:DropDownList ID="drpdurum" runat="server" SelectedValue='<%# Eval("Durum") %>' Height="25px">
                                       <asp:ListItem Value="-1">Durumunu Seçiniz</asp:ListItem>
                                          <asp:ListItem Value="True">Aktif</asp:ListItem>
                                        <asp:ListItem Value="False">Pasif</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>      
                            <tr>
                                <td style="width: 207px; text-align: right; vertical-align: top">
                                    <strong>&nbsp;</strong></td>
                                <td style="width: 308px">
                                     &nbsp;</td>
                                <td style="width: 60px">
                                </td>
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
                    <asp:HiddenField ID="hdn_ID" runat="server" Value='<%# Eval("ID") %>' />
                    
                    
                    </EditItemTemplate>
                    <ItemTemplate>
                        <table style="width: 760px; position: static">
                            <tr>
                                <td style="width: 207px; text-align: right">
                                </td>
                                <td style="width: 500px">
                                    <asp:Button ID="btn_Yeni" runat="server" CausesValidation="False" CommandName="New"
                                        CssClass="button" Font-Bold="True" OnClick="btn_Yeni_Click" Style="position: static"
                                        Text="Yeni Kayit" Width="110px" />
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
                                    <asp:Label ID="lbl_Adi" runat="server" Style="position: static" Text='<%# Eval("Adi") %>'
                                        Width="568px"></asp:Label>
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>
                              <tr>
                                <td style="width: 207px; text-align: right">
                                    <strong>Soyadı </strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:Label ID="Label9" runat="server" Style="position: static" Text='<%# Eval("Soyadi") %>'
                                        Width="568px"></asp:Label>
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 207px; text-align: right">
                                    <strong>Telefon </strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:Label ID="Label10" runat="server" Style="position: static" Text='<%# Eval("Telefon") %>'
                                        Width="568px"></asp:Label>
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 207px; text-align: right">
                                    <strong>Email </strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:Label ID="Label11" runat="server" Style="position: static" Text='<%# Eval("Email") %>'
                                        Width="568px"></asp:Label>
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>
                              <tr>
                                <td style="width: 207px; text-align: right">
                                    <strong>Sifre </strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:Label ID="Label1" runat="server" Style="position: static" Text='<%# Eval("Sifre") %>'
                                        Width="568px"></asp:Label>
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>
                           
                             <tr>
                                <td style="width: 207px; text-align: right; vertical-align: top">
                                    <strong>Durum </strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:Label ID="Label7" runat="server" Style="position: static" Text='<%# Bind("Durum") %>' Width="568px"></asp:Label>
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>
                             <tr>
                                <td style="width: 207px; text-align: right; vertical-align: top">
                                    &nbsp;</td>
                                <td style="width: 308px">
                                    &nbsp;</td>
                                <td style="width: 60px">
                                </td>
                            </tr>
                            
                             <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                                DataObjectTypeName="UserRolesInfo" DeleteMethod="Sil" InsertMethod="Insert" 
                                OldValuesParameterFormatString="original_{0}" SelectMethod="BulByID" 
                                TypeName="UserRolesBLL" UpdateMethod="Guncelle">
                                 <SelectParameters>
                                     <asp:QueryStringParameter DefaultValue="" Name="Id" QueryStringField="ID" 
                                         Type="Int32" />
                                 </SelectParameters>
                            </asp:ObjectDataSource>
                     
                            <tr>
                                <td style="width: 207px; text-align: right">
                                </td>
                                <td style="width: 308px">
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>

                        </table>
                  
                        <br />
                        <cc1:ConfirmButtonExtender ID="cnfrm_Button" runat="server" ConfirmText="Silinecek ?"
                            TargetControlID="btn_Sil">
                        </cc1:ConfirmButtonExtender>
                   
                    </ItemTemplate>
                </asp:FormView>
                 <asp:XmlDataSource ID="XMLYayinDurumu" runat="server" DataFile="~/XML/XMLFile.xml"
                    XPath="root/yayin_durumu/item"></asp:XmlDataSource>

                <asp:ObjectDataSource ID="Objurunbyid" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="BulByID" 
                    TypeName="Users1BLL">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="ID" QueryStringField="ID" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>


                <asp:XmlDataSource ID="XmlDil" runat="server" DataFile="~/XML/XMLFile.xml" XPath="root/dil/item">
                </asp:XmlDataSource>


                    </td></tr></table>
    
   
</asp:Content> 