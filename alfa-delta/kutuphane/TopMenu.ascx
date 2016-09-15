<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TopMenu.ascx.cs" Inherits="kutuphane_LeftMenu" %>
<div style="width:950px;height:20px; float:left;left:4px;top:0;vertical-align:top;margin:0;font-family:Arial;font-size:1pt;z-index:1000;">
   <%-- <div style="width:727px;height:34px;float:left;position:relative;top:0;margin:auto;padding:0;">--%>
                    <asp:DataList ID="dtl_Menuler" runat="server" RepeatDirection="Horizontal" CellPadding="0" OnItemDataBound="dtl_Menuler_ItemDataBound">
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td align="right" valign="top"  >
                                            <div style="vertical-align:top;text-align:center;position:relative;top:0;float:left;z-index:1001;left:6px;">
                                            <div style="vertical-align:top;text-align:center;overflow:hidden;" id="divMenu" runat="server">
                                                <table cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                         <td> <div align="center" runat="server" id="dvNav" valign="top" style="height:34px; text-align:center;vertical-align:top;">
                                                            <center><table border="0" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td style="padding-top:7px;">
                                                                        <asp:HyperLink CssClass="MenuStyle" PostBackUrl='<%# Eval("LINK") %>' ID="lnk" runat="server"><%#Eval("ADI") %></asp:HyperLink>
                                                                        <asp:HiddenField ID="hdnMenuID" Value='<%#Eval("ID") %>' runat="server" />
                                                                    </td>
                                                                </tr>
                                                            </table></center>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <asp:Literal ID="ltr" runat="server"></asp:Literal></div>
                                        </td>
                                    </tr>
                                </table>
                        </ItemTemplate>
                    </asp:DataList><%--</div>--%>
      
    </div>
    