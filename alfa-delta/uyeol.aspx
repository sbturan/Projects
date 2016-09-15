<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="uyeol.aspx.cs" ValidateRequest="false" Inherits="uyeol" Title="Untitled Page" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

   
    <div align="center" style="margin:auto;vertical-align:top;padding:0px;width:500px;left:0px;top:0px;overflow:hidden;">
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
                <td align="center" valign="top" style="text-align:center;vertical-align:top;width:500px;">
                    <asp:Panel ID="OnlineUye" runat="server" HorizontalAlign="Center" Width="500px" 
                        style="margin:auto;" meta:resourcekey="OnlineUyeResource1">
                        <center>
                        <table border="0" cellpadding="0" cellspacing="4" 
                                style="margin-right:140px; width: 466px;">
                                
                            
                            <tr>
                                <td align="right"><asp:Label ID="lblSifre" runat="server" Font-Bold="True" 
                                        Font-Names="Tahoma" Font-Size="10pt" ForeColor="#393939" 
                                        Style="position: static" Width="160px" meta:resourcekey="lblSifreResource1"><font style="font-family:Tahoma; font-size:10pt;color:Red;font-weight:bold;">*</font> Şifre :</asp:Label></td>
                                <td align="left" valign="middle">
                                   <asp:TextBox ID="txt_Sifre" TextMode="Password" runat="server" Height="20px" 
                                        Width="210px" BorderColor="#EF9696" BorderWidth="2px" BackColor="White" 
                                        ForeColor="Black" Font-Names="arial" Font-Size="12px" 
                                        meta:resourcekey="txt_SifreResource1"></asp:TextBox>
                            
                                </td>
                                <td align="left" valign="top" style="height: 21px;">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" 
                                        ControlToValidate="txt_Sifre"  ValidationGroup="Uyelik" 
                                        ErrorMessage="Şifre Alanı boş bırakılamaz" Width="5px" ForeColor="#393939" 
                                        meta:resourcekey="RequiredFieldValidator16Resource1">*</asp:RequiredFieldValidator></td>
                            </tr> 
                       
                            <tr>
                               <td align="right"><asp:Label ID="lblSifreTerkar" runat="server" Font-Bold="True" 
                                       Font-Names="Tahoma" Font-Size="10pt" ForeColor="#393939" 
                                       Style="position: static" Width="160px" 
                                       meta:resourcekey="lblSifreTerkarResource1" 
                                        
                                       Text="&lt;font style=&quot;font-family:Tahoma; font-size:10pt;color:Red;font-weight:bold;&quot;&gt;*&lt;/font&gt; Şifre Tekrarı :"></asp:Label></td>
                                <td align="left" valign="middle">
                                
                                     <asp:TextBox ID="txt_SifreTekrar" TextMode="Password" Height="20px" 
                                         runat="server" Width="210px" BorderColor="#EF9696" BorderWidth="2px" 
                                         BackColor="White" ForeColor="Black" Font-Names="arial" Font-Size="12px" 
                                         meta:resourcekey="txt_SifreTekrarResource1"></asp:TextBox>
                                </td>
                                                                     
                                 <td align="left" valign="top" style="height: 21px;">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                         ControlToValidate="txt_Sifre"  ValidationGroup="Uyelik" 
                                         ErrorMessage="Tekrar Þifre Alaný boþ býrakýlamaz" Width="5px" 
                                         ForeColor="#393939" meta:resourcekey="RequiredFieldValidator9Resource1">*</asp:RequiredFieldValidator>
                                    </td>
                                  <td>  
                                    <asp:CompareValidator ID="CompareValidator2" runat="server" 
                                          ControlToCompare="txt_SifreTekrar" ErrorMessage="Şifreler uymuyor" 
                                          ControlToValidate="txt_Sifre" meta:resourcekey="CompareValidator2Resource1"></asp:CompareValidator>
                                    
                                    </td>
                            </tr>
                        <tr>
                                <td align="right"><asp:Label ID="lblTelNo" runat="server" Font-Bold="True" 
                                        Font-Names="Tahoma" Font-Size="10pt" ForeColor="#393939" 
                                        Style="position: static" Text="Telefon No" Width="140px" 
                                        meta:resourcekey="lblTelNoResource1"></asp:Label></td>
                                <td align="left" valign="middle">
                                   <asp:TextBox ID="txt_TelNo" runat="server" Height="20px" Width="210px" 
                                        BorderColor="#EF9696" BorderWidth="2px" BackColor="White" ForeColor="Black" 
                                        Font-Names="arial" Font-Size="12px" meta:resourcekey="txt_TelNoResource1"></asp:TextBox></td>
                                <td>&nbsp;</td>
                            </tr>
                           
                                   <tr>
                                <td align="right" colspan="3" style="padding-right:10px;">
                                    <asp:ImageButton ID="BtnUyeBildirim"  runat="server" 
                                        ImageUrl="images/ImgGonder.png" ValidationGroup="Uyelik" onclick="Gonder_Click" 
                                        meta:resourcekey="BtnUyeBildirimResource1" />
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



