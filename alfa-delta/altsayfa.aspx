<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="altsayfa.aspx.cs" Inherits="altsayfa" Title="Sosyal Demokrat Belediyeler Derneði Web Sitesi" %>
<%@ Register Src="kutuphane/altsayfadetay.ascx" TagName="altsayfadetay" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-47050117-1', 'alfa-delta.com');
        ga('send', 'pageview');

    </script>
<div  style="margin:0;vertical-align:top;width:746px; left:0px;top:0px;padding-top:10px;padding-bottom:5px; padding-left: 0px; padding-right: 0px;">
   
        <table border="0" cellpadding="0" cellspacing="0" style="width: 760px">
            <tr>
                <td align="left" style="width:700px;vertical-align:top;text-align:left;left:0px;top:0px;">
                   <uc1:altsayfadetay ID="Altsayfadetay2" runat="server" />
                </td>
            </tr>
        </table>
  
</div>
</asp:Content>
