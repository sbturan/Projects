<%@ Page Language="C#" MasterPageFile="~/yonetim/yonetim.master" AutoEventWireup="true" CodeFile="parabirimi.aspx.cs" Inherits="yonetim_parabirimi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">





   <table>
                <tr>
                    <td>DOLAR ALIŞ</td>
                    <td class="auto-style2" style="width: 229px">

                        <asp:TextBox ID="txt_doa" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lbl_doa" runat="server"></asp:Label>

                        <asp:TextBox ID="txt_1" runat="server"></asp:TextBox>

                    </td>

                    <td>



                        <asp:Label ID="Label3" runat="server" Text="Güncellenme Tarihi:"></asp:Label>
                    </td>
                    <td>



                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>DOLAR SATIŞ</td>
                    <td class="auto-style2" style="width: 229px">
                        <asp:TextBox ID="txt_dos" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lbl_dos" runat="server"></asp:Label>

                        <asp:TextBox ID="txt_2" runat="server"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td>EURO ALIŞ
                    </td>
                    <td class="auto-style2" style="width: 229px">

                        <asp:TextBox ID="txt_euoa" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lbl_eua" runat="server"></asp:Label>

                        <asp:TextBox ID="Txt_3" runat="server"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td>EURO   SATIŞ
                    </td>
                    <td class="auto-style2" style="width: 229px">

                        <asp:TextBox ID="txt_euos" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lbl_euos" runat="server"></asp:Label>
                        <asp:TextBox ID="Txt_4" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td class="auto-style2" style="width: 229px">
                        <asp:Button ID="Button2" runat="server" Height="29px" OnClick="Button3_Click"
                            Text="TCMB DEĞERLERİNİ KULLAN" Width="200px" Font-Size="Smaller" OnClientClick = " return confirm('Web sayfasi kurlari TCMB kurlari ile degitirilecek  ?');" Style="margin-left: 0px" />

                    </td>
                    <td align="center">

                        <asp:Button ID="Button5" runat="server" OnClick="Button1_Click"
                            Text="YUKARDAKİ KURU KULLAN" Width="161px" Height="25px" OnClientClick = " return confirm('Web sayfasi kurlari belrilenen   kur ile degitirilecek  ?');" />
                    </td>
                </tr>
            </table>
            <div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      
        <br />
                <br />
                <br />
                <asp:Label ID="Label1" runat="server"></asp:Label>
                <br />
                <br />
                <br />


            </div>
    

</asp:Content>
