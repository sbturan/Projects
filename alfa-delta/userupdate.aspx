<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="userupdate.aspx.cs" ValidateRequest="false" Inherits="uyeol" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

   
   <div align="center" style="margin:auto;vertical-align:top;padding:0px;width:500px;left:0px;top:0px;overflow:hidden;">
    <center>
        <table border="0" cellpadding="0" cellspacing="0" width="500px">
            <tr>
                <td align="center" colspan="3" height="75px" valign="top" style="font-family: Arial; text-align:center;vertical-align:top; font-size: 14pt; color: #464646;font-weight: bold; background-image:url(images/altsayfaHeaderBg.png);background-repeat:no-repeat; height:75px; padding-top:17px;width:960px">
                    <asp:label ID="lblHeader" runat="server" ForeColor="#0000CC" Font-Names="Arial" 
                        Font-Size="14pt" Font-Bold="True" Text="Üye Duzenleme Formu" 
                        style="text-transform:uppercase;"></asp:label>
                </td>
            </tr>
            <tr>
                <td align="center" valign="top" style="text-align:center;vertical-align:top;width:500px;">
                    <asp:Panel ID="OnlineUye" runat="server" Visible="true" HorizontalAlign="Center" Width="500px" style="margin:auto;">
                        <center>
                        <table border="0" cellpadding="0" cellspacing="4" 
                                style="margin-right:140px; width: 466px;">
                                 <tr>
                                <td align="right"><asp:Label ID="lbl_Adi" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="10pt" ForeColor="#393939" Style="position: static" Width="160px"><font style="font-family:Tahoma; font-size:10pt;color:Red;font-weight:bold;">*</font> Ad :</asp:Label></td>
                                <td align="left" valign="middle">
                                   <asp:TextBox ID="txt_Adi" runat="server" Height="20px" Width="210px" BorderColor="#ef9696" BorderWidth="2px" BackColor="White" ForeColor="Black" Font-Names="arial" Font-Size="12px"></asp:TextBox></td>
                                <td align="left" valign="top" style="height: 21px;">
                                    <asp:RequiredFieldValidator ID="rqf_Adi" runat="server" ControlToValidate="txt_Adi" ValidationGroup="Uyelik" ErrorMessage="Adý alaný zorunlu" Width="5px" ForeColor="#393939">*</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="right"><asp:Label ID="lblSoyad" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="10pt" ForeColor="#393939" Style="position: static" Width="160px"><font style="font-family:Tahoma; font-size:10pt;color:Red;font-weight:bold;">*</font> Soyad :</asp:Label></td>
                                <td align="left" valign="middle">
                                    <asp:TextBox ID="txt_Soyadi" runat="server" Height="20px" Width="210px" BorderColor="#ef9696" BorderWidth="2px" BackColor="White" ForeColor="Black" Font-Names="arial" Font-Size="12px"></asp:TextBox></td>
                                <td align="left" valign="top" style="height: 21px;">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_Soyadi" ValidationGroup="Uyelik" ErrorMessage="Soyad alaný zorunlu" Width="5px" ForeColor="#393939">*</asp:RequiredFieldValidator></td>
                            </tr>
                             
                       
                            
                       
                            <tr>
                                <td align="right"><asp:Label ID="lblEmail" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="10pt" ForeColor="#393939" Style="position: static" Text="Email :" Width="160px"></asp:Label></td>
                                <td align="left" valign="middle">
                                    <asp:TextBox ID="txt_Email" runat="server" Height="20px" Width="210px" BorderColor="#ef9696" BorderWidth="2px" BackColor="White" ForeColor="Black" Font-Names="arial" Font-Size="12px"></asp:TextBox>
                                <td>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txt_Email"  ValidationGroup="Uyelik" ErrorMessage="Email Alaný boþ býrakýlmaz" Width="5px" ForeColor="#393939">*</asp:RequiredFieldValidator>
                                
                                </td>    
                            </tr>
                            <tr>
                                <td align="right"><asp:Label ID="lblTelNo" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="10pt" ForeColor="#393939" Style="position: static" Text="Telefon No" Width="140px"></asp:Label></td>
                                <td align="left" valign="middle">
                                   <asp:TextBox ID="txt_TelNo" runat="server" Height="20px" Width="210px" BorderColor="#ef9696" BorderWidth="2px" BackColor="White" ForeColor="Black" Font-Names="arial" Font-Size="12px"></asp:TextBox></td>
                                <td>&nbsp;</td>
                            </tr>
                            
                                   <tr>
                                <td align="right" colspan="3" style="padding-right:10px;">
                                    <asp:ImageButton ID="BtnUyeBildirim"  runat="server" ImageUrl="images/ImgGonder.png" ValidationGroup="Uyelik" onclick="Gonder_Click" />
                                </td>
                            </tr>
                       
                                </table>
                                </center>
                                </asp:Panel>    
                </td>
             </tr>                                  
          </table>
      </center>
                          
                   
      
</div>
   
</asp:Content>



