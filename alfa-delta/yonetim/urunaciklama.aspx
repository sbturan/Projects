<%@ Page Language="C#" MasterPageFile="~/yonetim/yonetim.master" AutoEventWireup="true"
    CodeFile="urunaciklama.aspx.cs" Inherits="yonetim_acıklamaduzenle" Title="Untitled Page"
    ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    &nbsp;<table style="width: 800px; position: static">
        <tr>
            <td style="width: 800px">
                <asp:Label ID="lbl_Baslik" runat="server" Font-Bold="True" Font-Size="11pt" ForeColor="Crimson"
                    Style="position: static" Text="Açıklama  Düzenleme" Width="208px"></asp:Label>
                <asp:Label ID="lbl_Mesaj" runat="server" Font-Bold="False" Style="position: static"
                    Visible="False" Width="256px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 606px" valign="top">
                <asp:FormView ID="frm_AltSayfaDuzen" runat="server" Style="position: static" DataSourceID="ObjectIcerikById"
                    OnItemCommand="frm_AltSayfaDuzen_ItemCommand" DataKeyNames="URUNAC_ID" OnItemCreated="frm_AltSayfaDuzen_ItemCreated"
                    OnModeChanged="frm_AltSayfaDuzen_ModeChanged">
                    <InsertItemTemplate>
                        <table style="width: 760px; position: static">
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lbl_Ekleme" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="RoyalBlue"
                                        Text="Açıklama Ekleme"></asp:Label>
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>
                           
                            <tr>
                                <td style="width: 207px; text-align: right; vertical-align: top">
                                    <strong>Açıklama</strong>
                                </td>
                                <td style="width: 500px">
                                    <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" Width="570px" Height="700px"
                                        BasePath="fckeditor/">
                                    </FCKeditorV2:FCKeditor>
                                </td>
                                <td style="width: 60px" valign="top">
                                    <asp:RequiredFieldValidator ID="rqd_Icerik" runat="server" ControlToValidate="FCKeditor1"
                                        ErrorMessage="Ýçerik Giriniz" Style="position: static" ValidationGroup="ICERIK">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                           
                            <tr>
                                                            <td style="width: 194px; text-align: right">
                                                                <strong>Dil</strong>
                                                            </td>
                                                            <td style="width: 432px">
                                                                <asp:DropDownList ID="drp_Dil" runat="server" Style="position: static" Width="464px"
                                                                    DataSourceID="XmlDil" DataTextField="adi" DataValueField="id">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr><td><asp:Button ID="btn_Kaydet" runat="server" OnClick="btn_Kaydet_Click" Style="position: static"
                                        Text="Kaydet" Width="168px" CssClass="button" Font-Bold="True" ValidationGroup="ICERIK" /></td></tr>
                            
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
                                        Text="Haber Güncelleme"></asp:Label>
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>
                            
                            <tr>
                                <td style="width: 207px; text-align: right; vertical-align: top">
                                    <strong>Açýklama</strong>
                                </td>
                                <td style="width: 500px">
                                    <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" Width="570px" Height="700px"
                                        Value='<%# Eval("ACIKLAMA") %>' BasePath="fckeditor/">
                                    </FCKeditorV2:FCKeditor>
                                </td>
                                <td style="width: 60px" valign="top">
                                    <asp:RequiredFieldValidator ID="rqd_Icerik" runat="server" ControlToValidate="FCKeditor1"
                                        ErrorMessage="Ýçerik Giriniz" Style="position: static" ValidationGroup="ICERIK">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            
                                                        <tr>
                                                            <td style="width: 194px; text-align: right">
                                                                <strong>Dil</strong>
                                                            </td>
                                                            <td style="width: 393px">
                                                                <asp:DropDownList ID="drp_Dil" runat="server" Style="position: static" Width="464px"
                                                                    DataSourceID="XmlDil" DataTextField="adi" DataValueField="id" SelectedValue='<%# Eval("DIL") %>'>
                                                                </asp:DropDownList>
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
                                <td style="width: 207px; text-align: right; vertical-align: top">
                                    <strong>Açýklama </strong>
                                </td>
                                <td style="width: 500px" bgcolor="whitesmoke">
                                    <asp:Panel ID="Panel1" runat="server" Height="300px" ScrollBars="Auto" Style="position: static"
                                        Width="575px">
                                        <asp:Literal ID="ltrl_Aciklama" runat="server" Text='<%# Eval("ACIKLAMA") %>'></asp:Literal></asp:Panel>
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>
                           
                          <tr>
                                                            <td style="width: 194px; text-align: right">
                                                                <strong>Dil</strong>
                                                            </td>
                                                            <td style="width: 393px">
                                                                <asp:DropDownList ID="drp_Dil" runat="server" Style="position: static" Width="464px"
                                                                    DataSourceID="XmlDil" DataTextField="adi" DataValueField="id" SelectedValue='<%# Eval("DIL") %>'
                                                                    Enabled="False">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                           
                            
                           
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
             
                <asp:ObjectDataSource ID="ObjectIcerikById" runat="server" 
                    DataObjectTypeName="UrunAciklamaInfo" DeleteMethod="Delete" 
                    InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" 
                    SelectMethod="GetUAbyUrunID" TypeName="UrunAciklamaBLL" UpdateMethod="Update">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="ID" QueryStringField="URUN_ID" Type="Int32" />
                        <asp:Parameter DefaultValue="tr" Name="dil" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                
                <asp:XmlDataSource ID="XmlDil" runat="server" DataFile="~/XML/XMLFile.xml" XPath="root/dil/item">
                </asp:XmlDataSource>
                
            </td>
        </tr>
    </table>
</asp:Content>
