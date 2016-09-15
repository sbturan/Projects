<%@ Control Language="C#" AutoEventWireup="true" CodeFile="altsayfadetay.ascx.cs"   Inherits="kutuphane_altsayfadetay" %>

<div  style="margin-top: 0px;border:solid 1px #d9d9d6; background-color:#ffffff;width:734px;">
    <table border="0"  style="width: 606px; height: 166px;">
        <tr>
            <td valign="top">
                <table border="0"  style="width: 606px">
                    <tr>
                        <td align="left" valign="top" style="font-family: Arial; font-weight: bold;height:45px;padding:5px 0px 15px 15px;vertical-align:bottom;">
                            <div style="color:#ffffff;width:563px; background-color:#f69334;font-family:Arial;font-size:12pt; font-weight:bold;padding-left:10px;">    <%= baslik %> </div>
                        </td>
                    </tr>
                    <tr>
    	                 <td  style="padding:0px 15px 15px 15px;"><div style="border-bottom:solid 1px #d9d9d6;"></div></td>
    	            </tr>
                    <tr>
                        <td align="left" style="font-family: Arial; font-size: 12px; color: #545454; 
                            text-align: justify; line-height: 18px; height: 18px;padding:10px 15px 20px 15px;vertical-align:top;">
                            <asp:Literal ID="ltrl_Aciklama" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding:5px 15px 10px 0px;"><a href="javascript: window.history. go( -1 )"><asp:Image ID="Image2" runat="server" ImageUrl="~/images/btngeri.png" /></a></td>
        </tr>
    </table>
</div>
<asp:HiddenField ID="hdn_ID" runat="server" />
