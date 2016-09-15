<%@ Page Language="C#" MasterPageFile="~/yonetim/yonetim.master" AutoEventWireup="true" CodeFile="rolmanager.aspx.cs" Inherits="yonetim_rolmanager" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript">	
			function DeleteRole(roleID)
			{
				if (confirm("Do you want to delete this news?"))
				{
					document.all.RoleIDHidden.value = roleID;
					__doPostBack('Delete','');
				}
			}
		</script>
<input type="hidden" id="RoleIDHidden" value="0" runat="server">
			<asp:Button ID="Delete" Runat="server" Visible="False" onclick="Delete_Click"></asp:Button>
			<div style="WIDTH: 300px; BACKGROUND-COLOR: white">
				
				<div style="PADDING-RIGHT: 2px; PADDING-LEFT: 2px; FONT-WEIGHT: bold; PADDING-BOTTOM: 2px; COLOR: white; PADDING-TOP: 2px; BACKGROUND-COLOR: #336699">Role 
					Manager</div>
				<table width="100%" bgcolor="gray" style="BORDER-BOTTOM: black 1px solid">
					<tr>
						<td>New Role</td>
					</tr>
				</table>
				<table width="100%">
					<tr>
						<td width="100">Role Name</td>
						<td><asp:TextBox Runat="server" ID="RoleName" Width="200px"></asp:TextBox></td>
					</tr>
					<tr>
						<td></td>
						<td><asp:Button Width="80" Runat="server" ID="AddRole" Text="Add" onclick="AddRole_Click"></asp:Button></td>
					</tr>
				</table>
				<table width="100%" bgcolor="gray" style="BORDER-BOTTOM: black 1px solid">
					<tr>
						<td>All Roles</td>
					</tr>
				</table>
				<asp:DataGrid Width="100%" ID="RolesGrid" Runat="server" AllowPaging="False" AllowSorting="False" AutoGenerateColumns="False" ShowHeader="False" ShowFooter="False">
					<Columns>
						<asp:TemplateColumn>
							<ItemTemplate>
								<%# DataBinder.Eval(Container.DataItem, "RoleName")%>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:TextBox ID="RoleNameEdit" Width="100%" Runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RoleName")%>'>
								</asp:TextBox>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:EditCommandColumn EditText="Edit" ItemStyle-Width="40" UpdateText="<img src='Images/yes.gif' alt='Update' border='0'>" CancelText="<img src='Images/no.gif' alt='Cancel' border='0'>"></asp:EditCommandColumn>
						<asp:TemplateColumn ItemStyle-Width="40">
							<ItemTemplate>
								<a href='<%# string.Format("javascript:DeleteRole(\"{0}\")", DataBinder.Eval(Container.DataItem, "RoleID")) %>'>
									Delete</a>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn Visible="False">
							<ItemTemplate>
								<asp:Label ID="RoleID" Runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RoleID") %>'>
								</asp:Label>
							</ItemTemplate>
						</asp:TemplateColumn>
					</Columns>
				</asp:DataGrid>
			</div>
</asp:Content>

