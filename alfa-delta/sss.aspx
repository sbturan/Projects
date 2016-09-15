<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="sss.aspx.cs" Inherits="sss" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <asp:FormView ID="FormView1" runat="server" DataSourceID="SqlDataSource2" 
            EnableModelValidation="True" Height="275px" Width="747px" CellPadding="4" 
            ForeColor="#333333">
            <EditItemTemplate>
                konu:
                <asp:TextBox ID="konuTextBox" runat="server" Text='<%# Bind("konu") %>' />
                <br />
                aciklama:
                <asp:TextBox ID="aciklamaTextBox" runat="server" 
                    Text='<%# Bind("aciklama") %>' />
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                    CommandName="Update" Text="Update" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                    CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </EditItemTemplate>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <InsertItemTemplate>
                konu:
                <asp:TextBox ID="konuTextBox" runat="server" Text='<%# Bind("konu") %>' />
                <br />
                aciklama:
                <asp:TextBox ID="aciklamaTextBox" runat="server" 
                    Text='<%# Bind("aciklama") %>' />
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                    CommandName="Insert" Text="Insert" />
                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                    CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </InsertItemTemplate>
            <ItemTemplate>
               
                <asp:Label ID="aciklamaLabel" runat="server" Text='<%# Bind("aciklama") %>' />
               
                <br />
                
            </ItemTemplate>
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
        </asp:FormView>
        <br />
    </p>
    <p>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:alfa-deltaConnectionString %>" 
            SelectCommand="SELECT [aciklama] FROM [icerik]">
        </asp:SqlDataSource>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>

