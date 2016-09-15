<%@ Page Language="C#" MasterPageFile="~/yonetim/yonetim.master" AutoEventWireup="true"
    CodeFile="MenuDuzenle1.aspx.cs" Inherits="yonetim_MenuDuzenle1" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
         <script type="text/javascript"  language="javascript">


             function dosyalardan(obje, deger) {
                 width = 260;
                 height = 250;

                 var left = (screen.width - width) / 2;
                 var top = (screen.height - height) / 2;
                 var url = "dosyalar.aspx?obje=" + obje + "&deger=" + deger;
                 win = window.open(url, 'dosyalar', "height=500,width=680,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes,left=" + left + ",top=" + top);

             }
    </script>
   
        <contenttemplate>
<TABLE style="WIDTH: 800px; POSITION: static"><TBODY><TR><TD style="WIDTH: 800px"><asp:Label style="POSITION: static" id="lbl_Baslik" runat="server" __designer:wfdid="w33" Font-Size="11pt" ForeColor="Crimson" Font-Bold="True" Width="208px" Text="Menü Düzenleme"></asp:Label> <asp:Label style="POSITION: static" id="lbl_Mesaj" runat="server" __designer:wfdid="w34" Font-Bold="False" Width="256px" Visible="False"></asp:Label></TD></TR><TR><TD style="WIDTH: 800px; HEIGHT: 606px" vAlign=top><asp:Button id="btn_Yeni" onclick="btn_Yeni_Click" runat="server" __designer:wfdid="w35" Font-Bold="True" Width="110px" Text="Yeni Menü" CssClass="button"></asp:Button>&nbsp;  
    <asp:Button id="btn_Sil" onclick="btn_Sil_Click" runat="server" Text="MENÜ SİL" Width="107px" CssClass="button" Font-Bold="True" OnClientClick = " return confirm('Menü Silinecek Emin misiniz ?');"  />
    &nbsp; <asp:Button id="btn_Duzenle" onclick="btn_Duzenle_Click" runat="server" __designer:wfdid="w37" Font-Bold="True" Width="110px" Text="Menü Düzenle" CssClass="button"></asp:Button>&nbsp; <BR /><BR /><asp:Button id="btn_Yukari" onclick="btn_Yukari_Click" runat="server" __designer:wfdid="w38" Font-Bold="True" Width="110px" Text="Yukarı" CssClass="button"></asp:Button>&nbsp; <asp:Button id="btn_Asagi" onclick="btn_Asagi_Click" runat="server" __designer:wfdid="w39" Font-Bold="True" Width="110px" Text="Aşağı" CssClass="button"></asp:Button>&nbsp; <asp:Button id="Button3" onclick="Button3_Click" runat="server" __designer:wfdid="w40" Font-Bold="True" Width="110px" Text="Seçimi İptal Et" CssClass="button"></asp:Button>&nbsp; <BR /><BR /><asp:Label id="lbl_hata" runat="server" __designer:wfdid="w2" ForeColor="Red" Text="Label" Visible="False"></asp:Label><BR /><BR /><BR /><asp:TreeView id="TreeView1" runat="server" __designer:wfdid="w1" OnTreeNodeCheckChanged="TreeView1_TreeNodeCheckChanged" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" EnableViewState="False" EnableTheming="True" ImageSet="Arrows">
<ParentNodeStyle Font-Bold="False"></ParentNodeStyle>

<HoverNodeStyle Font-Underline="True" ForeColor="#5555DD"></HoverNodeStyle>

<SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" BackColor="#80FFFF" Font-Underline="True" ForeColor="#5555DD"></SelectedNodeStyle>

<NodeStyle HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black"></NodeStyle>
</asp:TreeView></TD></TR><TR><TD></TD></TR></TBODY></TABLE><cc1:ModalPopupExtender id="ModalPopupExtender1" runat="server" __designer:wfdid="w41" TargetControlID="HiddenField1" BackgroundCssClass="modalBackground" PopupControlID="Panel1">
    </cc1:ModalPopupExtender> <cc1:ModalPopupExtender id="ModalPopupExtender2" runat="server" __designer:wfdid="w42" TargetControlID="HiddenField2" BackgroundCssClass="modalBackground" PopupControlID="Panel2">
    </cc1:ModalPopupExtender> <cc1:ModalPopupExtender id="ModalPopupExtender3" runat="server" __designer:wfdid="w4" TargetControlID="HiddenField3" BackgroundCssClass="modalBackground" PopupControlID="Panel3"></cc1:ModalPopupExtender> <asp:HiddenField id="HiddenField1" runat="server" __designer:wfdid="w43">
        </asp:HiddenField> <asp:HiddenField id="HiddenField2" runat="server" __designer:wfdid="w44">
        </asp:HiddenField> <asp:HiddenField id="HiddenField3" runat="server" __designer:wfdid="w3"></asp:HiddenField> <asp:Panel id="Panel2" runat="server" __designer:wfdid="w45" BackColor="white" BorderStyle="Dashed" BorderWidth="1"><TABLE cellSpacing=0 cellPadding=4 width=250><TBODY><TR><TD style="WIDTH: 250px">
             &nbsp;</TD></TR><TR>
                <td style="WIDTH: 250px">
                    &nbsp;</td></TR><TR><TD style="WIDTH: 250px"><asp:Button id="btn_Kapat2" onclick="btn_Kapat2_Click" runat="server" __designer:wfdid="w48" Font-Bold="True" Width="110px" Text="Kapat" CssClass="button"></asp:Button>&nbsp; </TD></TR></TBODY></TABLE>
             <asp:ObjectDataSource id="ObjectDataSource1" runat="server" 
                 __designer:wfdid="w49" UpdateMethod="Update" DataObjectTypeName="IcerikInfo" 
                 OldValuesParameterFormatString="original_{0}" TypeName="IcerikBLL" 
                 SelectMethod="GetTumList" InsertMethod="Insert" DeleteMethod="Delete">
        </asp:ObjectDataSource>
         </asp:Panel>
          <asp:Panel id="Panel1" runat="server" __designer:wfdid="w50" BackColor="white" BorderStyle="Dashed" BorderWidth="1">
          <TABLE cellSpacing=0 cellPadding=4 width=350>
          <TBODY>
          <TR>
          <TD colSpan=2><asp:Label id="Menu_Adi" runat="server" Font-Bold="true" Text="Menü Ekleme Bölümü">
          </asp:Label> </TD></TR><TR><TD colSpan=2><asp:Label id="Label1" runat="server" __designer:wfdid="w52" Text="Şu Anda bu bölüme ekliyorsunuz"></asp:Label> <BR /><BR /><asp:Label id="lbl_Uyari" runat="server" __designer:wfdid="w63" ForeColor="Red" Visible="False"></asp:Label> </TD></TR><TR><TD style="PADDING-RIGHT: 10px" align=right>Menü Adı : </TD><TD><asp:TextBox id="txt_MenuAd" runat="server" __designer:wfdid="w53" Width="150"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" __designer:wfdid="w54" ValidationGroup="ekleme" ControlToValidate="txt_MenuAd" ErrorMessage="(*)"></asp:RequiredFieldValidator> </TD></TR><TR><TD style="PADDING-RIGHT: 10px" align=right>Menü Link : </TD><TD>
              <asp:DropDownList ID="DropDownList2" runat="server" 
                  Height="49px" Width="201px">
              </asp:DropDownList>
              </TD></TR><TR vAlign=top><TD style="PADDING-RIGHT: 10px" align=right>&nbsp;</TD><TD></TD></TR><TR style="FONT-WEIGHT: bold"><TD style="TEXT-ALIGN: left" colSpan=2></TD><TD style="WIDTH: 5px" vAlign=middle align=center colSpan=1 rowSpan=2><STRONG>&nbsp; </STRONG></TD></TR><TR style="FONT-WEIGHT: bold"><TD style="WIDTH: 330px; TEXT-ALIGN: left" colSpan=2><SPAN style="FONT-SIZE: 10pt; FONT-FAMILY: Tahoma"></SPAN>&nbsp;</TD></TR>
               <tr>
                                                            <td style="width: 194px; text-align: right">
                                                                <strong>Dil</strong>
                                                            </td>
                                                            <td style="width: 393px">
                                                                &nbsp;</td>
                                                        </tr>
                <tr vAlign="top">
                                                          
                                        
                    <td align="right" style="PADDING-RIGHT: 10px">
                    </td>
                    <td>
                        <asp:Button ID="btn_Guncelle" runat="server" __designer:wfdid="w58" 
                            CssClass="button" Font-Bold="True" onclick="btn_Guncelle_Click1" Text="Ekle" 
                            ValidationGroup="ekleme" Width="110px" />
                        &nbsp;
                        <br />
                    </td>
              <tr>
                  <td colspan="2">
                      <asp:LinkButton ID="sayfaGoster" runat="server" __designer:wfdid="w59" 
                          onclick="sayfaGoster_Click">Sayfa ID lerini Göster</asp:LinkButton>
                  </td>
              </tr>
              <tr>
                  <td align="center" colspan="2">
                      <asp:Button ID="btn_Cancel" runat="server" __designer:wfdid="w60" 
                          CssClass="button" Font-Bold="True" onclick="btn_Cancel_Click" Text="Kapat" 
                          Width="110px" />
                      &nbsp;
                      <asp:HiddenField ID="hdn_Deger" runat="server" __designer:wfdid="w61" />
                  </td>
              </tr>
              </TBODY></TABLE></asp:Panel> <asp:Panel id="Panel3" runat="server" BackColor="white" BorderStyle="Dashed" BorderWidth="1"><TABLE cellSpacing=0 cellPadding=4 width=350><TBODY><TR><TD colSpan=2><asp:Label id="Menu_AdiEdit" runat="server" Font-Bold="true" Text="Menü Güncelleme Bölümü"></asp:Label> </TD></TR><TR><TD colSpan=2>
             <asp:Label id="lbl_sorgu_edit" runat="server" 
                 Text="Şu Anda bu bölüme ekliyorsunuz"></asp:Label> <BR /><BR /><asp:Label id="lbl_UyariEdit" runat="server" ForeColor="Red" Visible="False"></asp:Label> <asp:HiddenField id="hdn_AnaGrupID" runat="server" __designer:wfdid="w6"></asp:HiddenField> <asp:HiddenField id="hdn_EditSira" runat="server" __designer:wfdid="w7"></asp:HiddenField></TD></TR><TR><TD style="PADDING-RIGHT: 10px" align=right>
                 Menü Adı : </TD><TD><asp:TextBox id="txt_MenuAdEdit" runat="server" Width="150"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ValidationGroup="duzenleme" ControlToValidate="txt_MenuAdEdit" ErrorMessage="(*)"></asp:RequiredFieldValidator> </TD></TR><TR><TD style="PADDING-RIGHT: 10px" align=right>Menü Link : </TD><TD>
             <asp:DropDownList ID="DropDownList3" runat="server" 
                 Height="17px"  
                 Width="145px" Visible="False">
             </asp:DropDownList>
             </TD></TR><TR vAlign=top><TD style="PADDING-RIGHT: 10px" align=right>&nbsp;</TD><TD>&nbsp;</TD></TR><TR style="FONT-WEIGHT: bold"><TD style="TEXT-ALIGN: left" colSpan=2>&nbsp;</TD><TD style="WIDTH: 5px" vAlign=middle align=center colSpan=1 rowSpan=2><STRONG>&nbsp; </STRONG></TD></TR><TR style="FONT-WEIGHT: bold"><TD style="WIDTH: 330px; TEXT-ALIGN: left" colSpan=2><SPAN style="FONT-SIZE: 10pt; FONT-FAMILY: Tahoma"></SPAN>&nbsp;</TD></TR>
               <tr>
                                                            <td style="width: 194px; text-align: right">
                                                                &nbsp;</td>
                                                            <td style="width: 393px">
                                                                &nbsp;</td>
                                                        </tr>
                <tr vAlign="top">
                    <td align="right" style="PADDING-RIGHT: 10px">
                    </td>
                    <td>
                        <asp:Button ID="btn_GuncelleEdit" runat="server" CssClass="button" 
                            Font-Bold="True" onclick="btn_GuncelleEdit_Click" Text="Güncelle" 
                            ValidationGroup="duzenleme" Width="110px" />
                        &nbsp;
                        <br />
                    </td>
             <tr>
                 <td colspan="2">
                     <asp:LinkButton ID="sayfaGosterEdit" runat="server" onclick="sayfaGoster_Click">Sayfa ID lerini Göster</asp:LinkButton>
                 </td>
             </tr>
             <tr>
                 <td align="center" colspan="2">
                     <asp:Button ID="btn_CancelEdit" runat="server" CssClass="button" 
                         Font-Bold="True" onclick="btn_CancelEdit_Click" Text="Kapat" Width="110px" />
                     &nbsp;
                     <asp:HiddenField ID="hdn_DegerEdit" runat="server" />
                 </td>
             </tr>
             </TBODY></TABLE></asp:Panel> <asp:ObjectDataSource id="ObjectLinkler" runat="server" __designer:wfdid="w65" UpdateMethod="Delete" DataObjectTypeName="MenuInfo" OldValuesParameterFormatString="original_{0}" TypeName="MenuBLL" SelectMethod="GetAll" InsertMethod="Insert"></asp:ObjectDataSource> 
         
</contenttemplate>
    
         <asp:XmlDataSource ID="XmlDil" runat="server" DataFile="~/XML/XMLFile.xml" 
             XPath="root/dil/item"></asp:XmlDataSource>
    
</asp:Content>
