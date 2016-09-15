<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Email.ascx.cs" Inherits="kutuphane_Email" %>
<table cellpadding="0" cellspacing="0" style="width:250px; padding-top:2px;">
    <tr>
        <td>
            <div style="background-color:#ffffff; width:200px;height:40px;overflow:hidden;">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                    <td style="vertical-align: middle;padding-top:2px;" align="left">
                            
                        <div style="width:200px; float:left; text-align:center;">
                            <asp:TextBox ForeColor="#b9b8b8" ID="txt_mail" BorderColor="#d8d5d5" runat="server" Width="180px" BorderWidth="1" Text="E-mail Adresini Yazýn..." onblur="if (this.value=='') this.value='E-mail Adresini Yazýn...'"
                                onfocus="if (this.value=='E-mail Adresini Yazýn...') this.value=''" Font-Bold="True"  Font-Names="Arial" Font-Size="10pt" style=" padding:5px; margin-top:0px; "></asp:TextBox>
                        </div>
                       </td>
                    </tr>
                </table>
            </div>
        </td>
        <td style="padding-left:4px;">
            <asp:ImageButton ID="btn_Email" runat="server" ImageAlign="Middle" ImageUrl="~/images/ImgGonder.png"  OnClick="btn_Email_Click1" />
        </td>
       
    </tr>
</table>

  <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Names="Arial" Font-Size="12px" ShowMessageBox="True" ShowSummary="False" ValidationGroup="i" />
   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_mail" Display="None" ErrorMessage="Lütfen E-mail Adresi giriniz!" Font-Names="Arial" Font-Size="12px" ValidationGroup="i" InitialValue="E-Mail Adresini Yazýn..."></asp:RequiredFieldValidator>
   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_mail" Display="None" ErrorMessage="Email formatý hatalý!" Font-Names="Arial" Font-Size="12px" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="i"></asp:RegularExpressionValidator>
           