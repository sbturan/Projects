<%@ Control Language="C#" AutoEventWireup="true" CodeFile="yorumlar.ascx.cs" Inherits="kutuphane_yorumlar" %>
<table cellpadding="0" cellspacing="0" style="width: 413px; height: 98px">
    <tr valign="top" style="height: 39px;">
        <td style="width: 413px; background-color: #f2f2f2; border: solid 1px #dbdbdb; height: 40px;
            vertical-align: middle;" align="left">
            <table cellpadding="0" cellspacing="0" style="height: 36px;"  width="408">
                <tr style="height: 36px">
                    <td style="padding-left: 20px; color: #7f7f7f">
                        <span style="font-size: 22px; font-family: Arial"><strong style="font-size: 9pt; font-family: Arial">Müþteri Yorumlarý
                        </strong></span>
                    </td>
                    <td align="right" style="height: 36px; padding-right: 5px;">
                         <span style="color: #7f7f7f; font-size: 8.5pt; font-family: Arial"><strong><a
                            href="MusteriYorumlar.aspx" style="color: #7f7f7f;text-decoration:underline;">
                            Tümünü Göster</a></strong></span>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr style="height: 6px" valign="middle">
        <td style="padding-left: 20px; font-size: 14px; font-family: Arial; height: 6px;
            text-align: left">
        </td>
    </tr>
    <tr valign="top" style="height: 149px;">
        <td style="width: 202px; text-align: left; font-family: Arial; font-size: 8.5pt; padding-left: 16px;
             border: 1px solid #cccccc;" valign="middle" >
             <div style="height:149px">
            <%=musteriYorumlar %>
            </div>
        </td>
    </tr>
</table>
