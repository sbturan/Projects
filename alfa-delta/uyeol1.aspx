<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="uyeol1.aspx.cs" ValidateRequest="false" Inherits="uyeol1" Title="Untitled Page" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

   
    <div align="center" style="margin:auto;vertical-align:top;padding:0px;width:500px;left:0px;top:0px;overflow:hidden;">
        <asp:Label ID="Label3" runat="server" ></asp:Label>
    <center>
        <table border="0" cellpadding="0" cellspacing="0" width="500px">
            <tr>
                <td align="center" colspan="3" height="75px" valign="top" style="font-family: Arial; text-align:center;vertical-align:top; font-size: 14pt; color: #464646;font-weight: bold; background-image:url(images/altsayfaHeaderBg.png);background-repeat:no-repeat; height:75px; padding-top:17px;width:960px">
                    <asp:label ID="lblHeader" runat="server" ForeColor="#0000CC" Font-Names="Arial" 
                        Font-Size="14pt" Font-Bold="True" Text="Üyelik Formu" 
                        style="text-transform:uppercase;" meta:resourcekey="lblHeaderResource1"></asp:label>
                </td>
            </tr>
            <tr>
              
                    <asp:Panel ID="OnlineUye" runat="server" HorizontalAlign="Center" Width="500px" 
                        style="margin:auto;" meta:resourcekey="OnlineUyeResource1">
                        <center>
                        <table border="0" cellpadding="0" cellspacing="4" 
                                style="margin-right:140px; width: 466px;">
                                 <tr>
                                <td align="right"><asp:Label ID="lbl_Adi" runat="server" Font-Bold="True" 
                                        Font-Names="Tahoma" Font-Size="10pt" ForeColor="#393939" 
                                        Style="position: static" Width="160px" meta:resourcekey="lbl_AdiResource1"><font style="font-family:Tahoma; font-size:10pt;color:Red;font-weight:bold;">*</font> Ad :</asp:Label></td>
                                <td align="left" valign="middle">
                                   <asp:TextBox ID="txt_Adi" runat="server" Height="20px" Width="210px" 
                                        BorderColor="#EF9696" BorderWidth="2px" BackColor="White" ForeColor="Black" 
                                        Font-Names="arial" Font-Size="12px" meta:resourcekey="txt_AdiResource1"></asp:TextBox></td>
                                <td align="left" valign="top" style="height: 21px;">
                                    <asp:RequiredFieldValidator ID="rqf_Adi" runat="server" 
                                        ControlToValidate="txt_Adi" ValidationGroup="Uyelik" 
                                        ErrorMessage="Adý alaný zorunlu" Width="5px" ForeColor="#393939" 
                                        meta:resourcekey="rqf_AdiResource1">*</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="right"><asp:Label ID="lblSoyad" runat="server" Font-Bold="True" 
                                        Font-Names="Tahoma" Font-Size="10pt" ForeColor="#393939" 
                                        Style="position: static" Width="160px" meta:resourcekey="lblSoyadResource1"><font style="font-family:Tahoma; font-size:10pt;color:Red;font-weight:bold;">*</font> Soyad :</asp:Label></td>
                                <td align="left" valign="middle">
                                    <asp:TextBox ID="txt_Soyadi" runat="server" Height="20px" Width="210px" 
                                        BorderColor="#EF9696" BorderWidth="2px" BackColor="White" ForeColor="Black" 
                                        Font-Names="arial" Font-Size="12px" meta:resourcekey="txt_SoyadiResource1"></asp:TextBox></td>
                                <td align="left" valign="top" style="height: 21px;">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="txt_Soyadi" ValidationGroup="Uyelik" 
                                        ErrorMessage="Soyad alaný zorunlu" Width="5px" ForeColor="#393939" 
                                        meta:resourcekey="RequiredFieldValidator2Resource1">*</asp:RequiredFieldValidator></td>
                            </tr>
                          
                       
                            <tr>
                                <td align="right"><asp:Label ID="lblEmail" runat="server" Font-Bold="True" 
                                        Font-Names="Tahoma" Font-Size="10pt" ForeColor="#393939" 
                                        Style="position: static" Text="Email :" Width="160px" 
                                        meta:resourcekey="lblEmailResource1" > </asp:Label></td>
                                <td align="left" valign="middle">
                                    <asp:TextBox ID="txt_Email" runat="server" Height="20px" Width="210px" 
                                        BorderColor="#EF9696" BorderWidth="2px" BackColor="White" ForeColor="Black" 
                                        Font-Names="arial" Font-Size="12px" meta:resourcekey="txt_EmailResource1"></asp:TextBox>
                                <td>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                        ControlToValidate="txt_Email"  ValidationGroup="Uyelik" 
                                        ErrorMessage="Email Alaný boþ býrakýlmaz" Width="5px" ForeColor="#393939" 
                                        meta:resourcekey="RequiredFieldValidator11Resource1">*</asp:RequiredFieldValidator>
                                
                                </td>    
                         
                            <tr><td align="right">
                            
                            
                                <asp:Label ID="lblTelNo1" runat="server" Font-Bold="True" Font-Names="Tahoma" 
                                    Font-Size="10pt" ForeColor="#393939" Style="position: static" 
                                    Text="Güvenlik Kodu" Width="140px" meta:resourcekey="lblTelNo1Resource1"></asp:Label>
                            
                            
                            </td><td align="left">
                            
                                    
                                    <asp:Label ID="panpi" runat="server" BackColor="Black" BorderColor="#EF9696" BorderStyle="Solid" Font-Bold="True" Font-Italic="True" Font-Size="Medium" ForeColor="#6600FF" Width="211px"></asp:Label>
                            
                                    
                            </td></tr>
                            <tr><td align="right">
                                <asp:Label ID="lblTelNo0" runat="server" Font-Bold="True" Font-Names="Tahoma" 
                                    Font-Size="10pt" ForeColor="#393939" Style="position: static" Text="Kodu Doğrulayınız" 
                                    Width="140px" meta:resourcekey="lblTelNo0Resource1"></asp:Label>
                                </td>
                            
                            <td align="left">
                            
                                <asp:TextBox ID="txtCaptcha" runat="server" BackColor="White" 
                                    BorderColor="#EF9696" BorderWidth="2px" Font-Names="arial" Font-Size="12px" 
                                    ForeColor="Black" Height="20px" Width="210px" 
                                    meta:resourcekey="txtCaptchaResource1"></asp:TextBox>
                            </td>
                            </tr>
                                   <tr>
                                <td align="right" colspan="3" style="padding-right:10px;">
                                    <asp:ImageButton ID="BtnUyeBildirim"  runat="server" 
                                        ImageUrl="images/ImgGonder.png" ValidationGroup="Uyelik" onclick="Gonder_Click" 
                                        meta:resourcekey="BtnUyeBildirimResource1" />
                                </td>
                            </tr>
                       
                                </table>
                               
                                </asp:Panel>    
                </td>
             </tr>                                  
          </table>
      </center>
                          
                   
      
</div>
   
</asp:Content>



