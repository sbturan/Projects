<%@ Page Language="C#" MasterPageFile="~/yonetim/yonetim.master" AutoEventWireup="true"
    CodeFile="altsayfaduzenle.aspx.cs" Inherits="yonetim_altsayfaduzenle" Title="Untitled Page"
    ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">

        function dosyalardan(obje, deger, dil, iliski) {
            width = 260;
            height = 250;

            var left = (screen.width - width) / 2;
            var top = (screen.height - height) / 2;
            var url = "icerikler.aspx?obje=" + obje + "&deger=" + deger + "&dil=" + dil + "&iliski=" + iliski;
            win = window.open(url, 'dosyalar', "height=500,width=460,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes,left=" + left + ",top=" + top);
        }
    </script>

    <table style="width: 800px; position: static">
        <tr>
            <td style="width: 800px">
                <asp:Label ID="lbl_Baslik" runat="server" Font-Bold="True" Font-Size="11pt" ForeColor="Crimson"
                    Style="position: static" Text="Alt Sayfa Düzenle" Width="208px"></asp:Label>
                <asp:Label ID="lbl_Mesaj" runat="server" Font-Bold="False" Style="position: static"
                    Visible="False" Width="256px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:FormView ID="frm_AltSayfaDuzen" runat="server" Style="position: static" DataSourceID="ObjectIcerikById"
                    DataKeyNames="ID" OnItemCommand="frm_AltSayfaDuzen_ItemCommand" OnItemCreated="frm_AltSayfaDuzen_ItemCreated"
                    OnModeChanged="frm_AltSayfaDuzen_ModeChanged" EnableModelValidation="True">
                    <InsertItemTemplate>
                        <table style="width: 750px; position: static; height: 600px;">
                            <tr>
                                <td colspan="2" style="text-align: left">
                                    <asp:Label ID="lbl_Insert" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="RoyalBlue"
                                        Text="Alt Sayfa Ekleme"></asp:Label>
                                </td>
                                <td style="width: 50px">
                                </td>
                            </tr>
                             <tr>
                    <td style="width: 207px; text-align: right" valign="top">
                        &nbsp;</td>
                    <td style="width: 308px">
                        &nbsp;</td>
                    <td style="width: 60px">
                        </td>
                </tr>
                            <tr>
                                <td style="width: 165px; text-align: right">
                                    <strong>Konu&nbsp;</strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:TextBox ID="txt_Konu" runat="server" Style="position: static" Width="560px"></asp:TextBox>
                                </td>
                                <td style="width: 50px">
                                    <asp:RequiredFieldValidator ID="rqd_Konu" runat="server" ControlToValidate="txt_Konu"
                                        ErrorMessage="Konu Giriniz" Style="position: static" ValidationGroup="ICERIK">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 165px; text-align: right; vertical-align: top;">
                                    <strong>Açıklama&nbsp; </strong>
                                </td>
                                <td style="width: 500px; background-color: #003366;" valign="top">
                                    <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" BasePath="fckeditor/" Height="402px"
                                        Width="570px">
                                    </FCKeditorV2:FCKeditor>
                                </td>
                                <td style="width: 50px;" valign="top">
                                    <asp:RequiredFieldValidator ID="rqd_Icerik" runat="server" ControlToValidate="FCKeditor1"
                                        ErrorMessage="Ýçerik Giriniz" Style="position: static" ValidationGroup="ICERIK">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 194px; text-align: right">
                                    <strong>Dil</strong>
                                </td>
                                <td style="width: 432px">
                                    <asp:DropDownList ID="drp_Dil" runat="server" DataSourceID="XmlDil" DataTextField="adi"
                                        DataValueField="id" Style="position: static" Width="464px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
 <td style="width: 308px; height: 24px;">
                                    <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Yayın Durumu&nbsp; </strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:DropDownList ID="drp_YayinDurumu" runat="server" Style="position: static" Width="464px"
                                        DataSourceID="XMLYayinDurumu" DataTextField="adi" DataValueField="id">
                                    </asp:DropDownList>
                                </td>
                               
                                <td style="width: 100px; height: 24px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 165px; text-align: right">
                                    
                                </td>
                                <td style="width: 500px">
                                <asp:Button ID="btn_Kaydet" runat="server" CssClass="button" Font-Bold="True" OnClick="btn_Kaydet_Click"
                                        Style="position: static" Text="Kaydet" ValidationGroup="ICERIK" Width="168px" />
                                </td>
                                <td style="width: 100px">
                                </td>
                                <asp:ValidationSummary ID="vd_Summary" runat="server" ShowMessageBox="True" ShowSummary="False"
                                    Style="position: static" ValidationGroup="ICERIK" />
                            </tr>
                            <caption>
                                <br />
                                &nbsp;
                            </caption>
                            </tr>
                        </table>
                    </InsertItemTemplate>
                    <EditItemTemplate>
                        <table style="width: 760px; position: static">
                            <tr>
                                <td colspan="2" style="text-align: left">
                                    <asp:Label ID="lbl_Guncelle" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="RoyalBlue"
                                        Text="Alt Sayfa Güncelleme"></asp:Label>
                                </td>
                                <td style="width: 50px">
                                </td>
                            </tr>
                              <tr>
                    <td style="width: 207px; text-align: right" valign="top">
                        &nbsp;</td>
                    <td style="width: 308px">
                        &nbsp;</td>
                    <td style="width: 60px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drp_menu"
                            ErrorMessage="Menü Seçiniz" InitialValue="0" ValidationGroup="ICERIK">*</asp:RequiredFieldValidator></td>
                </tr>
                            <tr>
                                <td style="width: 160px; text-align: right">
                                    <strong>Konu&nbsp; </strong>
                                </td>
                                <td style="width: 540px">
                                    <asp:TextBox ID="txt_Konu" runat="server" Style="position: static" Text='<%# Bind("KONU") %>'
                                        Width="560px"></asp:TextBox>
                                </td>
                                <td style="width: 50px">
                                    <asp:RequiredFieldValidator ID="rqd_Konu" runat="server" ControlToValidate="txt_Konu"
                                        ErrorMessage="Konu Giriniz" Style="position: static" ValidationGroup="ICERIK">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 160px; text-align: right; vertical-align: top; height: 402px;">
                                    <strong>Açýklama&nbsp; </strong>
                                </td>
                                <td style="width: 540px; height: 402px; background-color: #003366;">
                                    <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" Width="570px" Height="400px"
                                        Value='<%# Eval("ACIKLAMA") %>' BasePath="fckeditor/">
                                    </FCKeditorV2:FCKeditor>
                                </td>
                                <td style="width: 50px; height: 402px;" valign="top">
                                    <asp:RequiredFieldValidator ID="rqd_Icerik" runat="server" ControlToValidate="FCKeditor1"
                                        ErrorMessage="Ýçerik Giriniz" Style="position: static" ValidationGroup="ICERIK">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 194px; text-align: right; height: 24px;">
                                    <strong>Dil</strong>
                                </td>
                                <td style="width: 432px; height: 24px;">
                                    <asp:DropDownList ID="drp_Dil" runat="server" Style="position: static" Width="464px"
                                        DataSourceID="XmlDil" DataTextField="adi" DataValueField="id" SelectedValue='<%# Eval("DIL") %>'>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        
                                               <tr>
                            <td style="width: 160px; text-align: right">
                                <strong>Yayın Durumu&nbsp; </strong>
                            </td>
                            <td style="width: 540px">
                                <asp:DropDownList ID="drp_YayinDurumu" runat="server" Style="position: static" Width="464px"
                                    DataSourceID="XMLYayinDurumu" DataTextField="adi" DataValueField="id" SelectedValue='<%# Eval("YAYIN_DURUMU") %>'>
                                </asp:DropDownList>
                            </td>
                            
                        </tr>
                        <tr>
                            <td style="width: 160px; text-align: right">
                            </td>
                            <td style="width: 540px">
                                <asp:Button ID="btn_Guncelle" runat="server" OnClick="btn_Guncelle_Click" Style="position: static"
                                    Text="Güncelle" Width="168px" CssClass="button" Font-Bold="True" ValidationGroup="ICERIK" />
                                &nbsp;<asp:Button
                                        ID="btn_Vazgec" runat="server" CssClass="button" Font-Bold="True" OnClick="btn_Vazgec_Click"
                                        Style="position: static" Text="Vazgeç" Width="168px" />
                            </td>
                            <td style="width: 50px">
                            </td>
                        </tr>
                        </table> &nbsp;
                        <asp:HiddenField ID="hdn_ID" runat="server" Value='<%# Eval("ID") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <table style="width: 760px; position: static">
                            <tr>
                                <td style="width: 165px; text-align: right">
                                </td>
                                <td style="width: 500px">
                                    &nbsp;<asp:Button ID="btn_Duzenle" runat="server"
                                            CausesValidation="False" CommandName="Edit" CssClass="button" Font-Bold="True"
                                            Style="position: static" Text="Düzenle" Width="110px" OnClick="btn_Duzenle_Click" />
                                    &nbsp;<asp:Button
                                                ID="btn_Sil" runat="server" CommandName="_delete" CssClass="button" Font-Bold="True"
                                                Style="position: static" Text="Sil" Width="110px" />
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                           <tr>
                <td style="width: 207px; text-align: right" valign="top">
                    &nbsp;</td>
                <td style="width: 308px">
                    &nbsp;</td>
                <td style="width: 60px">
                </td>
            </tr>
                          
                            <tr>
                                <td style="width: 165px; text-align: right">
                                    <strong>Konu&nbsp; </strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:Label ID="lbl_Konu" runat="server" Style="position: static" Text='<%# Eval("KONU") %>'
                                        Width="480px"></asp:Label>
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 165px; text-align: right; vertical-align: top">
                                    <strong>Açıklama&nbsp; </strong>
                                </td>
                                <td style="width: 500px" bgcolor="whitesmoke">
                                    <asp:Panel ID="Panel1" runat="server" Height="300px" ScrollBars="Auto" Style="position: static"
                                        Width="575px">
                                        <asp:Literal ID="ltrl_Aciklama" runat="server" Text='<%# Eval("ACIKLAMA") %>'></asp:Literal></asp:Panel>
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 194px; text-align: right">
                                    <strong>Dil</strong>
                                </td>
                                <td style="width: 432px">
                                    <asp:DropDownList ID="drp_Dil" runat="server" Style="position: static" Width="464px"
                                        DataSourceID="XmlDil" DataTextField="adi" DataValueField="id" SelectedValue='<%# Eval("DIL") %>'
                                        Enabled="False">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        
                        </td> </tr> </table> </strong></td>
                        <td style="width: 100px; height: 18px">
                        </td>
                        </tr>
                        <tr>
                            <td style="width: 165px; text-align: right; height: 24px;">
                                <strong>&nbsp; Yayın Durumu&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
                            </td>
                            <td style="width: 308px; height: 24px;">
                                <asp:DropDownList ID="drp_YayinDurumu" runat="server" Style="position: static" Width="464px"
                                    DataSourceID="XMLYayinDurumu" DataTextField="adi" DataValueField="id" SelectedValue='<%# Eval("YAYIN_DURUMU") %>'
                                    Enabled="False">
                                </asp:DropDownList>
                            </td>
                            
                        </tr>
                        <tr>
                            <td style="width: 165px; text-align: right">
                            </td>
                            <td style="width: 500px">
                                &nbsp;
                            </td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        </table>
                        <cc1:ConfirmButtonExtender ID="cnfrm_Button" runat="server" ConfirmText="Silinecek ?"
                            TargetControlID="btn_Sil">
                        </cc1:ConfirmButtonExtender>

                    </ItemTemplate>
                </asp:FormView>
            </td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="ObjectIcerikler" runat="server" DataObjectTypeName="IcerikInfo"
        DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetBilgiByID" TypeName="IcerikBLL" UpdateMethod="Update">
        <SelectParameters>
            <asp:QueryStringParameter Name="ID" QueryStringField="ID" Type="Int32" />
            <asp:Parameter DefaultValue="1" Name="YAYIN_DURUMU" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:XmlDataSource ID="XMLYayinDurumu" runat="server" DataFile="~/XML/XMLFile.xml"
        XPath="root/yayin_durumu/item"></asp:XmlDataSource>
    <asp:XmlDataSource ID="XmlDil" runat="server" DataFile="~/XML/XMLFile.xml" XPath="root/dil/item">
    </asp:XmlDataSource>
                    <asp:ObjectDataSource ID="ObjectMenuDoldur" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
                        TypeName="MenuDoldurBLL"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectIcerikById" runat="server" DataObjectTypeName="IcerikInfo"
        DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetBilgiByID" TypeName="IcerikBLL" UpdateMethod="Update">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="ID" QueryStringField="ID" Type="Int32" />
            <asp:QueryStringParameter DefaultValue="tr" Name="dil" QueryStringField="DIL" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
