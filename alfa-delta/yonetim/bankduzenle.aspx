<%@ Page Language="C#" MasterPageFile="~/yonetim/yonetim.master" AutoEventWireup="true"
    CodeFile="bankduzenle.aspx.cs" Inherits="yonetim_urunduzenle" Title="Untitled Page"
    ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
   
    <table style="width: 800px; position: static">
        <tr>
            <td style="width: 800px">
                <asp:Label ID="lbl_Baslik" runat="server" Font-Bold="True" Font-Size="11pt" ForeColor="Crimson"
                    Style="position: static" Text="Bank Bilgileri İşlemleri" Width="208px"></asp:Label>
                <asp:Label ID="lbl_Mesaj" runat="server" Font-Bold="False" Style="position: static"
                    Visible="False" Width="256px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 606px" valign="top">
                <asp:FormView ID="frm_AltSayfaDuzen" runat="server" Style="position: static" DataSourceID="Objurunbyid"
                    OnItemCommand="frm_AltSayfaDuzen_ItemCommand" DataKeyNames="ID" OnItemCreated="frm_AltSayfaDuzen_ItemCreated"
                    OnModeChanged="frm_AltSayfaDuzen_ModeChanged">
                    <InsertItemTemplate>
                        <table style="width: 760px; position: static">
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lbl_Ekleme" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="RoyalBlue"
                                        Text="Bank Bilgileri Ekleme"></asp:Label>
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 207px; text-align: right">
                                    <strong>Bank Adı</strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:TextBox ID="txt_Adi" runat="server" Style="position: static" Width="245px" 
                                        Height="28px"></asp:TextBox>
                                </td>
                                <td style="width: 60px">
                                    <asp:RequiredFieldValidator ID="rqd_Adi" runat="server" ControlToValidate="txt_Adi"
                                        ErrorMessage="Adi Giriniz" Style="position: static" ValidationGroup="ICERIK">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                          
                             <tr>
                                <td style="width: 207px; text-align: right">
                                    <strong>&nbsp;Şube Adı</strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:TextBox ID="txt_stok" runat="server" Style="position: static" Width="242px" 
                                        Height="28px"></asp:TextBox>
                                </td>
                                <td style="width: 60px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_stok"
                                        ErrorMessage="Stok Miktarı Giriniz" Style="position: static" ValidationGroup="ICERIK">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                             <tr>
                                <td style="width: 207px; text-align: right">
                                    <strong>&nbsp;Hesap Türü</strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:TextBox ID="txt_kritik" runat="server" Style="position: static" 
                                        Width="244px" Height="28px"></asp:TextBox>
                                </td>
                                <td style="width: 60px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_kritik"
                                        ErrorMessage="Kritik Stok Miktarı Giriniz" Style="position: static" ValidationGroup="ICERIK">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                                <tr>
                                <td style="width: 207px; text-align: right">
                                    <strong>&nbsp;Hesap No</strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:TextBox ID="txt_fiyat" runat="server" Style="position: static" 
                                        Width="244px" Height="31px"></asp:TextBox>
                                </td>
                                <td style="width: 60px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_Adi"
                                        ErrorMessage="Fiyat Miktarı Giriniz" Style="position: static" ValidationGroup="ICERIK">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                          
                                <tr>
                                <td style="width: 207px; text-align: right">
                                    <strong>Iban No</strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:TextBox ID="txt_kdvorani" runat="server" Style="position: static" 
                                        Width="244px" Height="32px"></asp:TextBox>
                                </td>
                                <td style="width: 60px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_Adi"
                                        ErrorMessage="Kdv Oranı Giriniz" Style="position: static" ValidationGroup="ICERIK">*</asp:RequiredFieldValidator>
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
                                        Text="Banka Bilgileri Güncelleme"></asp:Label>
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 207px; text-align: right">
                                    <strong>Bank Adı</strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:TextBox ID="txt_Adi" runat="server" Style="position: static" Text='<%# Bind("BANK_ADI") %>'
                                        Width="299px" Height="25px"></asp:TextBox>
                                </td>
                                <td style="width: 60px">
                                    <asp:RequiredFieldValidator ID="rqd_Konu" runat="server" ControlToValidate="txt_Adi"
                                        ErrorMessage="Bank Adını Giriniz" Style="position: static" ValidationGroup="ICERIK">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                          
                             
                             <tr>
                                <td style="width: 207px; text-align: right">
                                    <strong>Şube Adı</strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:TextBox ID="txt_stok" runat="server" Style="position: static" Text='<%# Bind("SUBE_ADI") %>'
                                        Width="297px" Height="27px"></asp:TextBox>
                                </td>
                                <td style="width: 60px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_stok"
                                        ErrorMessage="Şube Adını Giriniz" Style="position: static" ValidationGroup="ICERIK">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                             <tr>
                                <td style="width: 207px; text-align: right">
                                    <strong>Hesap Türü</strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:TextBox ID="txt_kritik" runat="server" Style="position: static" Text='<%# Bind("HESAP_TUR") %>'
                                        Width="297px" Height="26px"></asp:TextBox>
                                </td>
                                <td style="width: 60px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txt_kritik"
                                        ErrorMessage="Hesap Türü Giriniz" Style="position: static" ValidationGroup="ICERIK">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 207px; text-align: right">
                                    <strong>Iban No</strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:TextBox ID="txt_fiyat" runat="server" Style="position: static" Text='<%# Bind("IBAN_NO") %>' 
                                        Width="299px" Height="25px"></asp:TextBox>
                                </td>
                                <td style="width: 60px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txt_fiyat"
                                        ErrorMessage="Iban No Giriniz" Style="position: static" ValidationGroup="ICERIK">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>

                           <tr>
                                <td style="width: 207px; text-align: right">
                                    <strong>Hesap No</strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:TextBox ID="txt_kdvorani" runat="server" Style="position: static" 
                                        Text='<%# Bind("HESAP_NO") %>' Height="28px" Width="298px" />
                                        &nbsp;</td>
                                <td style="width: 60px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txt_Adi"
                                        ErrorMessage="Hesap No Giriniz" Style="position: static" ValidationGroup="ICERIK">*</asp:RequiredFieldValidator>
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
                                    <asp:Button ID="btn_Duzenle" runat="server" CausesValidation="False" CommandName="Edit"
                                        CssClass="button" Font-Bold="True" OnClick="btn_Duzenle_Click" Style="position: static"
                                        Text="Düzenle" Width="110px" />
                                    <asp:Button ID="btn_Sil" runat="server" CssClass="button" Font-Bold="True" Style="position: static"
                                        Text="Sil" Width="110px" CommandName="_delete"  />
                                    
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 207px; text-align: right">
                                    <strong>Bank Adı </strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:Label ID="lbl_Adi" runat="server" Style="position: static" Text='<%# Eval("BANK_ADI") %>'
                                        Width="205px" Height="16px"></asp:Label>
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 207px; text-align: right; vertical-align: top">
                                    <strong>&nbsp;Şube Adı </strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:Label ID="lbl_kategoriid" runat="server" Style="position: static" Text='<%# Eval("SUBE_ADI") %>'
                                        Width="240px"></asp:Label>
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>
                             <tr>
                                <td style="width: 207px; text-align: right; vertical-align: top">
                                    <strong>Hesap Türü </strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:Label ID="Label1" runat="server" Style="position: static" Text='<%# Bind("HESAP_TUR") %>'
                                        Width="235px" Height="20px"></asp:Label>
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>
                            
                             <tr>
                                <td style="width: 207px; text-align: right; vertical-align: top">
                                    <strong>Hesap No </strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:Label ID="Label2" runat="server" Style="position: static" Text='<%# Bind("HESAP_NO") %>'
                                        Width="90px" Height="16px"></asp:Label>
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>
                             <tr>
                                <td style="width: 207px; text-align: right; vertical-align: top">
                                    <strong>Iban No </strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:Label ID="Label3" runat="server" Style="position: static" Text='<%# Bind("IBAN_NO") %>'
                                        Width="100px"></asp:Label>
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>
                           
                            
                           
                          

                        </table>

                        <cc1:ConfirmButtonExtender ID="cnfrm_Button" runat="server" ConfirmText="Silinecek ?"
                            TargetControlID="btn_Sil">
                        </cc1:ConfirmButtonExtender>
                       
                    </ItemTemplate>
                </asp:FormView>

                <asp:ObjectDataSource ID="Objurunbyid" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetBilgiByID" 
                    TypeName="BankBLL" DataObjectTypeName="HesapInfo" DeleteMethod="Delete" 
                    InsertMethod="Insert" UpdateMethod="Update">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="ID" QueryStringField="ID" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>


                    </td></tr></table>
    
   
</asp:Content> 