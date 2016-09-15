<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/yonetim.master" AutoEventWireup="true" CodeFile="urunKategori.aspx.cs" Inherits="yonetim_urunKategori" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table><tr><td>

        <asp:Label ID="lbluyarı" runat="server" Font-Bold="True" Text="Label" Visible="False"></asp:Label>
        </td>
        </tr>
        <tr><td>

    <asp:DropDownList ID="drp" runat="server" Height="30px" Width="220px">
    </asp:DropDownList>
            </td></tr>
        <tr><td></td></tr>
        <tr><td></td></tr>
        <tr><td></td></tr>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Boşa AL" OnClick="Button1_Click" />


            </td>
            <td>

                <asp:Label ID="Label1" runat="server" Text="Üst Kategorisi değiştirmek istediğiniz ürün grubunun öncelikle kategorisini boşaltmak için kullanınız"></asp:Label>
            </td>


        </tr>


    </table>

</asp:Content>

