<%@ Page Language="C#" MasterPageFile="~/yonetim/yonetim.master" AutoEventWireup="true"
    CodeFile="Urunduzenle1.aspx.cs" Inherits="yonetim_urunduzenle1" Title="Untitled Page"
    ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
   
    <table style="width: 800px; position: static">
        <tr>
            <td style="width: 800px">
                <asp:Label ID="lbl_Baslik" runat="server" Font-Bold="True" Font-Size="11pt" ForeColor="Crimson"
                    Style="position: static" Text="Ürün İşlemleri" Width="208px"></asp:Label>
                <asp:Label ID="lbl_Mesaj" runat="server" Font-Bold="False" Style="position: static"
                    Visible="False" Width="256px"></asp:Label>
            </td>
        </tr>

        <table style="width: 760px; position: static">
                            <tr>
                                <td colspan="2" style="text-align: left">
                                    <asp:Label ID="lbl_Guncelleme" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="RoyalBlue"
                                        Text="Ürün Güncelleme"></asp:Label>
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 207px; text-align: right">
                                    <strong>Adı</strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:TextBox ID="txt_Adi" runat="server" Style="position: static" 
                                        Width="299px" Height="25px"></asp:TextBox>
                                </td>
                                <td style="width: 60px">
                                    <asp:RequiredFieldValidator ID="rqd_Konu" runat="server" ControlToValidate="txt_Adi"
                                        ErrorMessage="Konu Giriniz" Style="position: static" ValidationGroup="ICERIK">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 207px; text-align: right; vertical-align: top; height: 40px;">
                                    <strong>Kategori İSMİ</strong>
                                </td>
                                
                                    
                                  <td style="width: 308px; height: 40px;">
                                    
                                        <asp:DropDownList ID="Drpustid" runat="server" Height="23px" Width="260px">
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
                                                    <asp:Image ID="img_Resim" runat="server" Height="120px" Style="position: static" Width="201px"
                                                        
                                                       /><span
                                                            style="font-size: 10pt"><strong> </strong></span>
                                                </td>
                                            </tr>
                                            <tr style="font-weight: bold; font-size: 10pt; font-family: Arial">
                                                <td style="width: 330px; text-align: left; height: 54px;">
                                                    <span style="font-family: Tahoma"></span>
                                                    <asp:Label ID="lbl_Yuklenen" runat="server" BackColor="#FFFF80" Font-Names="Tahoma"
                                                        Font-Size="10pt" ForeColor="DimGray" Height="30px" 
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
                                <td style="width: 207px; text-align: right; vertical-align: top">
                                    <strong>PDF</strong>
                                </td>
                                <td style="width: 308px">
                                    <table style="width: 344px; position: static;">
                                        <tbody>
                                            <tr style="font-weight: bold; font-size: 10pt; font-family: Arial">
                                                <td style="text-align: left">
                                                    <asp:TextBox ID="TextBox1" runat="server" Width="190px"></asp:TextBox>
                                                    <asp:Button ID="Button1" runat="server" CssClass="button" OnLoad="GetImageBrowser1"
                                                        Text="Araştır" Width="80px"  />
                                                </td>
                                              
                                            </tr>
                                            <tr style="font-weight: bold; font-size: 10pt; font-family: Arial">
                                                <td style="width: 330px; text-align: left; height: 54px;">
                                                    <span style="font-family: Tahoma"></span>
                                                    <asp:Label ID="Label2" runat="server" BackColor="#FFFF80" Font-Names="Tahoma"
                                                        Font-Size="10pt" ForeColor="DimGray" Height="30px" 
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
                                <td style="width: 194px; text-align: right">
                                    <strong>Dil</strong>
                                </td>
                                <td style="width: 432px">
                                    <asp:DropDownList ID="drp_Dil" runat="server" Style="position: static" Width="464px"
                                        DataSourceID="XmlDil" DataTextField="adi" DataValueField="id" 
                                        Enabled="False">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                       
                            <tr>
                                <td style="width: 207px; text-align: right">
                                    <strong>Yayın Durumu</strong>
                                </td>
                                <td style="width: 308px">
                                    <asp:DropDownList ID="drp_YayinDurumu" runat="server" Style="position: static" Width="464px"
                                        DataSourceID="XMLYayinDurumu" DataTextField="adi" DataValueField="id" >
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 207px; text-align: right">
                                </td>
                                <td style="width: 500px">
                                    <asp:Button ID="btn_Guncelle" runat="server" OnClick="btn_Guncelle_Click" Style="position: static"
                                        Text="Güncelle" Width="168px" CssClass="button" Font-Bold="True" ValidationGroup="ICERIK" />
                                   
                                </td>
                                <td style="width: 60px">
                                </td>
                            </tr>
                        </table>
                        <asp:ValidationSummary ID="vd_Summary" runat="server" ShowMessageBox="True" ShowSummary="False"
                            Style="position: static" ValidationGroup="ICERIK" />
                        <asp:HiddenField ID="hdn_Foto" runat="server" Value='<%# Eval("ICON") %>' />
                        <asp:HiddenField ID="hdn_ID" runat="server" Value='<%# Eval("ID") %>' />
                        <asp:HiddenField ID="hdn_PDF" runat="server" Value='<%# Eval("PDF") %>' />













        <tr>
            <td style="width: 100px; height: 606px" valign="top">
                 <asp:XmlDataSource ID="XMLYayinDurumu" runat="server" DataFile="~/XML/XMLFile.xml"
                    XPath="root/yayin_durumu/item"></asp:XmlDataSource>

                <asp:ObjectDataSource ID="Objurunbyid" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetUrunByID" 
                    TypeName="UrunBLL" DataObjectTypeName="UrunInfo" DeleteMethod="Delete" 
                    InsertMethod="Insert" UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="id" Type="Int32" />
                    </DeleteParameters>
                    <SelectParameters>
                        <asp:QueryStringParameter Name="ID" QueryStringField="ID" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>


                <asp:XmlDataSource ID="XmlDil" runat="server" DataFile="~/XML/XMLFile.xml" XPath="root/dil/item">
                </asp:XmlDataSource>


                    </td></tr></table>
    
   
</asp:Content> 