<%@ Page Language="C#" MasterPageFile="~/yonetim/yonetim.master" AutoEventWireup="true" CodeFile="UserRoleEdit.aspx.cs" Inherits="yonetim_UserRoleEdit" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td colspan="2">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" ForeColor="Red"
                    Text="Kullanıcı Rolleri Düzenleme Ekranı" Width="265px"></asp:Label></td>
            <td style="width: 100px">
                <asp:Label ID="lbl_Mesaj" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:FormView ID="frw_Roller" runat="server" DataSourceID="wievObjectSource" Width="863px">
                    <EditItemTemplate><table style="width: 100%">
                        <tr>
                            <td style="width: 139px">
                                <asp:Button ID="btnDuzenle" runat="server" CssClass="button" OnClick="btnDuzenle_Click"
                                        Text="Güncelle" /></td>
                            <td style="width: 100px">
                                <asp:Button ID="btnVazgec" runat="server" CssClass="button" OnClick="btnVazgec_Click"
                                        Text="Vazgec" /></td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 139px">
                                Rol Adı :
                            </td>
                            <td style="width: 100px">
                                <asp:TextBox ID="rolAdTextBox" runat="server" Text='<%# Bind("rolAd") %>'>
                        </asp:TextBox></td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 139px">
                                Rol Tanımı :
                            </td>
                            <td style="width: 100px">
                                <asp:TextBox ID="rolTanimTextBox" runat="server" Text='<%# Bind("rolTanim") %>'>
                        </asp:TextBox></td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 139px">
                                Yönetilebilinir mi ?</td>
                            <td style="width: 100px">
                                <asp:CheckBox ID="YonetilebilirCheckBox" runat="server" Checked='<%# Bind("Yonetilebilir") %>' Width="172px" AutoPostBack="True" /></td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                            </td>
                        </tr>
                        </table>
                    </EditItemTemplate>
                    <InsertItemTemplate><table style="width: 100%">
                        <tr>
                            <td style="width: 139px">
                                <asp:Button ID="btnYeniKayit" runat="server" CssClass="button" OnClick="btnYeniKayit_Click"
                                        Text="Kaydet" /></td>
                            <td style="width: 100px">
                                <asp:Button ID="btnVazgec" runat="server" CssClass="button" OnClick="btnVazgec_Click"
                                        Text="Vazgec" /></td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 139px">
                                Rol Adı :
                            </td>
                            <td style="width: 100px">
                                <asp:TextBox ID="rolAdTextBox" runat="server" Text='<%# Bind("rolAd") %>'>
                        </asp:TextBox></td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 139px">
                                Rol Tanımı :
                            </td>
                            <td style="width: 100px">
                                <asp:TextBox ID="rolTanimTextBox" runat="server" Text='<%# Bind("rolTanim") %>'>
                        </asp:TextBox></td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 139px">
                                Yönetilebilinir mi ?</td>
                            <td style="width: 100px">
                                <asp:CheckBox ID="YonetilebilirCheckBox" runat="server" Checked='<%# Bind("Yonetilebilir") %>' Width="172px" /></td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                            </td>
                        </tr>
                    </table>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 100px">
                                    <asp:Button ID="btnYeni" runat="server" CssClass="button" OnClick="btnYeni_Click"
                                        Text="Yeni" /></td>
                                <td style="width: 100px">
                                    <asp:Button ID="btnGuncelle" runat="server" CssClass="button" OnClick="btnGuncelle_Click"
                                        Text="Güncelle" /></td>
                                <td style="width: 100px">
                                    <asp:Button ID="btnSil" runat="server" CssClass="button" OnClick="btnSil_Click" Text="Sil" /></td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                </td>
                                <td style="width: 100px">
                                    <asp:Label ID="rolAdLabel" runat="server" Text='<%# Bind("rolAd") %>'></asp:Label></td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" rowspan="2">
                                    <asp:Label ID="rolTanimLabel" runat="server" Text='<%# Bind("rolTanim") %>'></asp:Label></td>
                            </tr>
                            <tr>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                </td>
                                <td style="width: 100px">
                                    <asp:CheckBox ID="YonetilebilirCheckBox" runat="server" Checked='<%# Bind("Yonetilebilir") %>'
                            Enabled="false" AutoPostBack="True" /></td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:FormView>
                <asp:ObjectDataSource ID="wievObjectSource" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetByRolID" TypeName="usrRolBLL">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="rolID" QueryStringField="ID" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
</asp:Content>

